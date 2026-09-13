namespace Ozakboy.PageData.Tests;

/// <summary>
/// <see cref="ASearchPageInfo"/> 的預設值與頁碼下限保護。
/// </summary>
[TestClass]
public sealed class ASearchPageInfoTests
{
    /// <summary>
    /// 具體子類別，用來驗證抽象基底的行為；同時示範實際專案的用法。
    /// </summary>
    private sealed class UserSearch : ASearchPageInfo
    {
        public string? Keyword { get; set; }
    }

    [TestMethod]
    public void DefaultsToFirstPageAndTenItems()
    {
        var search = new UserSearch();

        Assert.AreEqual(1, search.Page);
        Assert.AreEqual(10, search.Limit);
    }

    /// <summary>
    /// 頁碼小於 1 一律讀成 1，避免 Skip((page - 1) * limit) 算出負數。
    /// </summary>
    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    [DataRow(int.MinValue)]
    public void PageBelowOneReadsBackAsOne(int page)
    {
        var search = new UserSearch { Page = page };

        Assert.AreEqual(1, search.Page);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(999)]
    public void PageAtOrAboveOneIsKept(int page)
    {
        var search = new UserSearch { Page = page };

        Assert.AreEqual(page, search.Page);
    }

    [TestMethod]
    public void LimitIsSettable()
    {
        var search = new UserSearch { Limit = 50 };

        Assert.AreEqual(50, search.Limit);
    }

    [TestMethod]
    public void DerivedPropertiesCoexistWithPagingProperties()
    {
        var search = new UserSearch { Page = 2, Limit = 20, Keyword = "john" };

        Assert.AreEqual(2, search.Page);
        Assert.AreEqual(20, search.Limit);
        Assert.AreEqual("john", search.Keyword);
    }
}
