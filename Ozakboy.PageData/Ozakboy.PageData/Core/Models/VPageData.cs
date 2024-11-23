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
        /// 使用指定的資料集合和分頁參數初始化新執行個體。
        /// Initializes a new instance with the specified data collection and pagination parameters.
        /// </summary>
        /// <param name="_Data">分頁後的資料集合 (The paginated data collection)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        public VPageData(List<T> _Data, int _page, int _Limit, int _total)
        {
            PageData = _Data;
            PageInfo = new PageInfo(_page, _Limit, _total);
        }
        
        public VPageData(List<T> _Data, int _page, int _Limit)
        {
            PageData = _Data.Skip((_page - 1) * _Limit).Take(_Limit).ToList();
            PageInfo = new PageInfo(_page, _Limit, _Data.Count());
        }

        public VPageData(IQueryable<T> _Data, int _page, int _Limit)
        {
            PageData = _Data.Skip((_page - 1) * _Limit).Take(_Limit).ToList();
            PageInfo = new PageInfo(_page, _Limit, _Data.Count());
        }


        public VPageData(IEnumerable<T> _Data, int _page, int _Limit)
        {
            PageData = _Data.Skip((_page - 1) * _Limit).Take(_Limit).ToList();
            PageInfo = new PageInfo(_page, _Limit, _Data.Count());
        }

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
        /// 取得或設定分頁後的資料集合。
        /// Gets or sets the paginated data collection.
        /// </summary>
        public List<T> PageData { get; set; }

        /// <summary>
        /// 取得或設定分頁資訊。
        /// Gets or sets the pagination information.
        /// </summary>
        public PageInfo PageInfo { get; set; }
    }
}
