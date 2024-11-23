using System;

namespace Ozakboy.PageData
{
    /// <summary>
    /// 封裝分頁相關資訊的類別，提供完整的分頁參數和計算結果。
    /// Encapsulates pagination-related information and calculations.
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// 初始化 <see cref="PageInfo"/> 類別的新執行個體。
        /// Initializes a new instance of the <see cref="PageInfo"/> class.
        /// </summary>
        public PageInfo() { }

        /// <summary>
        /// 使用指定的頁碼、每頁筆數和總筆數初始化 <see cref="PageInfo"/> 類別的新執行個體。
        /// Initializes a new instance of the <see cref="PageInfo"/> class with specified parameters.
        /// </summary>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        public PageInfo(int _page, int _Limit, int _total)
        {
            Page = _page;
            Limit = _Limit;
            Total = _total;
            TotalPage = (int)Math.Ceiling(_total / (double)_Limit);
        }

        /// <summary>
        /// 取得或設定目前頁碼。
        /// Gets or sets the current page number.
        /// </summary>
        public int Page { get; set; } = 0;

        /// <summary>
        /// 取得或設定每頁顯示筆數。
        /// Gets or sets the number of items per page.
        /// </summary>
        public int Limit { get; set; } = 0;

        /// <summary>
        /// 取得或設定資料總筆數。
        /// Gets or sets the total number of items.
        /// </summary>
        public int Total { get; set; } = 0;

        /// <summary>
        /// 取得或設定總頁數。根據總筆數和每頁筆數自動計算。
        /// Gets or sets the total number of pages. Automatically calculated based on total items and items per page.
        /// </summary>
        public int TotalPage { get; set; } = 0;
    }
}
