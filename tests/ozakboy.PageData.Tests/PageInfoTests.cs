namespace Ozakboy.PageData.Tests;

/// <summary>
/// <see cref="PageInfo"/> 的建構與總頁數計算。
/// </summary>
[TestClass]
public sealed class PageInfoTests
{
    [TestMethod]
    public void ParameterlessConstructorLeavesEveryFieldAtZero()
    {
        var info = new PageInfo();

        Assert.AreEqual(0, info.Page);
        Assert.AreEqual(0, info.Limit);
        Assert.AreEqual(0, info.Total);
        Assert.AreEqual(0, info.TotalPage);
    }

    [TestMethod]
    public void ConstructorKeepsSuppliedValues()
    {
        var info = new PageInfo(2, 10, 14);

        Assert.AreEqual(2, info.Page);
        Assert.AreEqual(10, info.Limit);
        Assert.AreEqual(14, info.Total);
    }

    /// <summary>
    /// 總頁數一律向上取整：14 筆、每頁 10 筆要算成 2 頁，不能是 1 頁。
    /// </summary>
    [TestMethod]
    [DataRow(0, 10, 0)]
    [DataRow(1, 10, 1)]
    [DataRow(10, 10, 1)]
    [DataRow(11, 10, 2)]
    [DataRow(14, 10, 2)]
    [DataRow(20, 10, 2)]
    [DataRow(21, 10, 3)]
    [DataRow(7, 3, 3)]
    public void TotalPageRoundsUp(int total, int limit, int expectedTotalPage)
    {
        var info = new PageInfo(1, limit, total);

        Assert.AreEqual(expectedTotalPage, info.TotalPage);
    }

    [TestMethod]
    public void PropertiesRemainSettable()
    {
        var info = new PageInfo
        {
            Page = 3,
            Limit = 25,
            Total = 100,
            TotalPage = 4,
        };

        Assert.AreEqual(3, info.Page);
        Assert.AreEqual(25, info.Limit);
        Assert.AreEqual(100, info.Total);
        Assert.AreEqual(4, info.TotalPage);
    }
}
