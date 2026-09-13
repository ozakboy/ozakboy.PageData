namespace Ozakboy.PageData.Tests;

/// <summary>
/// 測試用的資料項目。
/// </summary>
internal sealed class TestItem
{
    public TestItem(int id)
    {
        Id = id;
    }

    public int Id { get; }
}

/// <summary>
/// 測試用的資料來源工廠，統一產生 1..n 的項目，讓各測試對切頁結果的預期一致。
/// </summary>
internal static class TestData
{
    /// <summary>
    /// 產生 Id 為 1 到 <paramref name="count"/> 的項目清單。
    /// </summary>
    public static List<TestItem> Items(int count)
    {
        var list = new List<TestItem>(count);
        for (var i = 1; i <= count; i++)
        {
            list.Add(new TestItem(i));
        }

        return list;
    }

    /// <summary>
    /// 取出各項目的 Id，方便以序列比對斷言切頁結果。
    /// </summary>
    public static int[] Ids(IEnumerable<TestItem> items)
    {
        return items.Select(x => x.Id).ToArray();
    }
}
