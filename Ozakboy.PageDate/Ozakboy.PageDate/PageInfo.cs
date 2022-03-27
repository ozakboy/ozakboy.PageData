using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.Page = _page;
            this.Limit = _Limit;
            this.Total = _total;
            this.TotalPage = (int)Math.Ceiling(((double)_total / (double)_Limit));
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
