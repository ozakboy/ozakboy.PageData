namespace Ozakboy.PageData.Tests;

/// <summary>
/// 六個 <c>ToPageData</c> 擴充方法各自要接到正確的建構函式多載。
/// 這裡的重點不是重測切頁演算法，而是「呼叫哪個多載，就走到哪個建構函式」。
/// </summary>
[TestClass]
public sealed class ToPageDataExtensionsTests
{
    [TestMethod]
    public void ListOverloadSlices()
    {
        var page = TestData.Items(14).ToPageData(2, 10);

        CollectionAssert.AreEqual(new[] { 11, 12, 13, 14 }, TestData.Ids(page.PageData));
        Assert.AreEqual(14, page.PageInfo.Total);
    }

    [TestMethod]
    public void ListOverloadWithTotalDoesNotSlice()
    {
        var page = TestData.Items(4).ToPageData(2, 4, 40);

        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, TestData.Ids(page.PageData));
        Assert.AreEqual(40, page.PageInfo.Total);
        Assert.AreEqual(10, page.PageInfo.TotalPage);
    }

    [TestMethod]
    public void QueryableOverloadSlices()
    {
        var page = TestData.Items(14).AsQueryable().ToPageData(3, 5);

        CollectionAssert.AreEqual(new[] { 11, 12, 13, 14 }, TestData.Ids(page.PageData));
        Assert.AreEqual(14, page.PageInfo.Total);
        Assert.AreEqual(3, page.PageInfo.TotalPage);
    }

    [TestMethod]
    public void QueryableOverloadWithTotalDoesNotSlice()
    {
        var page = TestData.Items(5).AsQueryable().ToPageData(1, 5, 23);

        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, TestData.Ids(page.PageData));
        Assert.AreEqual(23, page.PageInfo.Total);
        Assert.AreEqual(5, page.PageInfo.TotalPage);
    }

    [TestMethod]
    public void EnumerableOverloadSlices()
    {
        IEnumerable<TestItem> source = TestData.Items(14);

        var page = source.ToPageData(1, 6);

        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, TestData.Ids(page.PageData));
        Assert.AreEqual(14, page.PageInfo.Total);
    }

    [TestMethod]
    public void EnumerableOverloadWithTotalDoesNotSlice()
    {
        IEnumerable<TestItem> source = TestData.Items(3);

        var page = source.ToPageData(4, 3, 12);

        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, TestData.Ids(page.PageData));
        Assert.AreEqual(4, page.PageInfo.Page);
        Assert.AreEqual(12, page.PageInfo.Total);
        Assert.AreEqual(4, page.PageInfo.TotalPage);
    }

    /// <summary>
    /// 對 <see cref="List{T}"/> 呼叫時要綁到 List 多載，不能被 IEnumerable 多載吃掉 ——
    /// 兩者在切頁多載上結果相同，但 List 多載少一次介面分派，這裡順便鎖住多載解析的結果。
    /// </summary>
    [TestMethod]
    public void ListAndEnumerableOverloadsAgreeOnTheSameData()
    {
        var items = TestData.Items(14);
        IEnumerable<TestItem> asEnumerable = items;

        var fromList = items.ToPageData(2, 10);
        var fromEnumerable = asEnumerable.ToPageData(2, 10);

        CollectionAssert.AreEqual(TestData.Ids(fromList.PageData), TestData.Ids(fromEnumerable.PageData));
        Assert.AreEqual(fromList.PageInfo.Total, fromEnumerable.PageInfo.Total);
    }

    /// <summary>
    /// 延續 README 的用法：先過濾再分頁，總筆數要算過濾之後的筆數。
    /// </summary>
    [TestMethod]
    public void FilterThenPaginateCountsTheFilteredTotal()
    {
        var page = TestData.Items(14).Where(x => x.Id > 9).ToPageData(1, 10);

        CollectionAssert.AreEqual(new[] { 10, 11, 12, 13, 14 }, TestData.Ids(page.PageData));
        Assert.AreEqual(5, page.PageInfo.Total);
        Assert.AreEqual(1, page.PageInfo.TotalPage);
    }
}
