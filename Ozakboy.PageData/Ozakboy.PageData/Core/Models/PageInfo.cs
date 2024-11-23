using System;

namespace Ozakboy.PageData
{
    /// <summary>
    /// 分頁資訊
    /// </summary>
    public class PageInfo
    {
        public PageInfo() { }
        public PageInfo(int _page, int _Limit, int _total)
        {
            Page = _page;
            Limit = _Limit;
            Total = _total;
            TotalPage = (int)Math.Ceiling(_total / (double)_Limit);
        }
        /// <summary>
        /// 目前頁數
        /// </summary>
        public int Page { get; set; } = 0;

        /// <summary>
        /// 每頁數量
        /// </summary>
        public int Limit { get; set; } = 0;

        /// <summary>
        /// 資料總比數
        /// </summary>
        public int Total { get; set; } = 0;

        /// <summary>
        /// 總頁數
        /// </summary>
        public int TotalPage { get; set; } = 0;
    }
}
