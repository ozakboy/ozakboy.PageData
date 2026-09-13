using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozakboy.PageData
{
    /// <summary>
    /// 泛型分頁資料容器，包含分頁後的資料集合和分頁資訊。
    /// Generic container for paginated data, including the data collection and pagination information.
    /// </summary>
    /// <typeparam name="T">資料項目的型別 (The type of items in the data collection)</typeparam>
    public class VPageData<T>
    {
        /// <summary>
        /// 初始化 <see cref="VPageData{T}"/> 類別的新執行個體。
        /// Initializes a new instance of the <see cref="VPageData{T}"/> class.
        /// </summary>
        public VPageData() { }

        /// <summary>
        /// 使用「已經切好頁」的資料集合初始化新執行個體，本建構函式不再切頁，總筆數由呼叫端提供。
        /// Initializes a new instance from an already-paginated collection; no slicing happens here and the caller supplies the total.
        /// </summary>
        /// <param name="_Data">已經切好頁的資料集合 (The already-paginated data collection)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        public VPageData(List<T> _Data, int _page, int _Limit, int _total)
        {
            PageData = _Data;
            PageInfo = new PageInfo(_page, _Limit, _total);
        }

        /// <summary>
        /// 使用未分頁的完整資料集合初始化新執行個體，由本建構函式切出指定頁並計算總筆數。
        /// Initializes a new instance from the complete collection, slicing the requested page and counting the total here.
        /// </summary>
        /// <param name="_Data">未分頁的完整資料集合 (The complete, unpaginated data collection)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        public VPageData(List<T> _Data, int _page, int _Limit)
        {
            PageData = _Data.Skip((_page - 1) * _Limit).Take(_Limit).ToList();
            PageInfo = new PageInfo(_page, _Limit, _Data.Count());
        }

        /// <summary>
        /// 使用未分頁的完整查詢初始化新執行個體，由本建構函式切出指定頁並計算總筆數。
        /// Initializes a new instance from the complete query, slicing the requested page and counting the total here.
        /// </summary>
        /// <remarks>
        /// 資料來源是 Entity Framework Core 之類的查詢時，切頁與計數都會轉譯成資料庫端的操作。
        /// For an Entity Framework Core query both the slice and the count are translated to the database.
        /// </remarks>
        /// <param name="_Data">未分頁的完整查詢 (The complete, unpaginated query)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        public VPageData(IQueryable<T> _Data, int _page, int _Limit)
        {
            PageData = _Data.Skip((_page - 1) * _Limit).Take(_Limit).ToList();
            PageInfo = new PageInfo(_page, _Limit, _Data.Count());
        }


        /// <summary>
        /// 使用未分頁的完整資料序列初始化新執行個體，由本建構函式切出指定頁並計算總筆數。
        /// Initializes a new instance from the complete sequence, slicing the requested page and counting the total here.
        /// </summary>
        /// <param name="_Data">未分頁的完整資料序列 (The complete, unpaginated sequence)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        public VPageData(IEnumerable<T> _Data, int _page, int _Limit)
        {
            PageData = _Data.Skip((_page - 1) * _Limit).Take(_Limit).ToList();
            PageInfo = new PageInfo(_page, _Limit, _Data.Count());
        }

        /// <summary>
        /// 使用「已經切好頁」的資料序列初始化新執行個體，本建構函式不再切頁，總筆數由呼叫端提供。
        /// Initializes a new instance from an already-paginated sequence; no slicing happens here and the caller supplies the total.
        /// </summary>
        /// <param name="_Data">已經切好頁的資料序列 (The already-paginated sequence)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="Count">資料總筆數 (The total number of items)</param>
        public VPageData(IEnumerable<T> _Data, int _page, int _Limit, int Count)
        {
            PageData = _Data.ToList();
            PageInfo = new PageInfo(_page, _Limit, Count);
        }

        /// <summary>
        /// 將資料轉換為另一種型別的分頁資料。
        /// Transforms the data to a new type while maintaining pagination information.
        /// </summary>
        /// <typeparam name="TResult">目標轉換型別 (The target type to transform to)</typeparam>
        /// <param name="selector">轉換函式 (The transformation function)</param>
        /// <returns>轉換後的分頁資料 (The transformed paginated data)</returns>
        public VPageData<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            var transformedData = PageData.ConvertAll(x => selector(x));
            return new VPageData<TResult>(transformedData, PageInfo.Page, PageInfo.Limit, PageInfo.Total);
        }


        /// <summary>
        /// 取得或設定分頁後的資料集合。預設為空集合，不會是 Null。
        /// Gets or sets the paginated data collection. Defaults to an empty collection, never null.
        /// </summary>
        public List<T> PageData { get; set; } = new List<T>();

        /// <summary>
        /// 取得或設定分頁資訊。預設為各欄位皆為 0 的執行個體，不會是 Null。
        /// Gets or sets the pagination information. Defaults to an all-zero instance, never null.
        /// </summary>
        public PageInfo PageInfo { get; set; } = new PageInfo();
    }
}
