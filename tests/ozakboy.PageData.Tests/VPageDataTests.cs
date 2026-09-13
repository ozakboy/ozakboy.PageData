namespace Ozakboy.PageData.Tests;

/// <summary>
/// <see cref="VPageData{T}"/> 各建構函式的切頁行為，以及 Select 的型別轉換。
/// </summary>
[TestClass]
public sealed class VPageDataTests
{
    /// <summary>
    /// 1.2.0 起無參數建構函式不再留下 Null，呼叫端不必為了空頁多寫一次 Null 檢查。
    /// </summary>
    [TestMethod]
    public void ParameterlessConstructorLeavesNoNulls()
    {
        var page = new VPageData<TestItem>();

        Assert.IsNotNull(page.PageData);
        Assert.IsEmpty(page.PageData);
        Assert.IsNotNull(page.PageInfo);
        Assert.AreEqual(0, page.PageInfo.Total);
    }

    /// <summary>
    /// 帶總筆數的多載視資料為「已經切好頁」，原樣收下不再切。
    /// </summary>
    [TestMethod]
    public void ListConstructorWithTotalDoesNotSliceAgain()
    {
        var alreadyPaged = TestData.Items(3);

        var page = new VPageData<TestItem>(alreadyPaged, 2, 3, 99);

        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, TestData.Ids(page.PageData));
        Assert.AreEqual(2, page.PageInfo.Page);
        Assert.AreEqual(3, page.PageInfo.Limit);
        Assert.AreEqual(99, page.PageInfo.Total);
        Assert.AreEqual(33, page.PageInfo.TotalPage);
    }

    [TestMethod]
    public void ListConstructorSlicesFirstPage()
    {
        var page = new VPageData<TestItem>(TestData.Items(14), 1, 10);

        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, TestData.Ids(page.PageData));
        Assert.AreEqual(14, page.PageInfo.Total);
        Assert.AreEqual(2, page.PageInfo.TotalPage);
    }

    /// <summary>
    /// 最後一頁不足一整頁時只回剩下的筆數，不補也不溢位。
    /// </summary>
    [TestMethod]
    public void ListConstructorSlicesPartialLastPage()
    {
        var page = new VPageData<TestItem>(TestData.Items(14), 2, 10);

        CollectionAssert.AreEqual(new[] { 11, 12, 13, 14 }, TestData.Ids(page.PageData));
        Assert.AreEqual(2, page.PageInfo.Page);
        Assert.AreEqual(14, page.PageInfo.Total);
    }

    [TestMethod]
    public void ListConstructorReturnsEmptyPageBeyondTheLastPage()
    {
        var page = new VPageData<TestItem>(TestData.Items(14), 5, 10);

        Assert.IsEmpty(page.PageData);
        Assert.AreEqual(14, page.PageInfo.Total);
        Assert.AreEqual(2, page.PageInfo.TotalPage);
    }

    [TestMethod]
    public void QueryableConstructorSlices()
    {
        var source = TestData.Items(14).AsQueryable();

        var page = new VPageData<TestItem>(source, 2, 5);

        CollectionAssert.AreEqual(new[] { 6, 7, 8, 9, 10 }, TestData.Ids(page.PageData));
        Assert.AreEqual(14, page.PageInfo.Total);
        Assert.AreEqual(3, page.PageInfo.TotalPage);
    }

    [TestMethod]
    public void EnumerableConstructorSlices()
    {
        IEnumerable<TestItem> source = TestData.Items(14).Where(x => x.Id > 4);

        var page = new VPageData<TestItem>(source, 1, 4);

        CollectionAssert.AreEqual(new[] { 5, 6, 7, 8 }, TestData.Ids(page.PageData));
        Assert.AreEqual(10, page.PageInfo.Total);
    }

    /// <summary>
    /// 帶總筆數的 IEnumerable 多載同樣不切頁，總筆數以呼叫端給的為準。
    /// </summary>
    [TestMethod]
    public void EnumerableConstructorWithTotalDoesNotSliceAgain()
    {
        IEnumerable<TestItem> alreadyPaged = TestData.Items(4);

        var page = new VPageData<TestItem>(alreadyPaged, 3, 4, 40);

        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, TestData.Ids(page.PageData));
        Assert.AreEqual(3, page.PageInfo.Page);
        Assert.AreEqual(40, page.PageInfo.Total);
        Assert.AreEqual(10, page.PageInfo.TotalPage);
    }

    /// <summary>
    /// Select 只換資料型別，分頁資訊要原封不動帶過去 —— 轉成 DTO 之後總筆數還得是原本的總筆數。
    /// </summary>
    [TestMethod]
    public void SelectTransformsDataAndKeepsPageInfo()
    {
        var page = new VPageData<TestItem>(TestData.Items(14), 2, 10);

        var projected = page.Select(x => $"#{x.Id}");

        CollectionAssert.AreEqual(new[] { "#11", "#12", "#13", "#14" }, projected.PageData);
        Assert.AreEqual(2, projected.PageInfo.Page);
        Assert.AreEqual(10, projected.PageInfo.Limit);
        Assert.AreEqual(14, projected.PageInfo.Total);
        Assert.AreEqual(2, projected.PageInfo.TotalPage);
    }

    [TestMethod]
    public void SelectOnAnEmptyPageReturnsAnEmptyPage()
    {
        var page = new VPageData<TestItem>(new List<TestItem>(), 1, 10);

        var projected = page.Select(x => x.Id);

        Assert.IsEmpty(projected.PageData);
        Assert.AreEqual(0, projected.PageInfo.Total);
    }

    [TestMethod]
    public void PropertiesRemainSettable()
    {
        var page = new VPageData<TestItem>
        {
            PageData = TestData.Items(2),
            PageInfo = new PageInfo(1, 2, 2),
        };

        Assert.HasCount(2, page.PageData);
        Assert.AreEqual(1, page.PageInfo.TotalPage);
    }
}
