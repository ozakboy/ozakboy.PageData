using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozakboy.PageData.Core.Abstract
{
    /// <summary>
    /// 搜尋指定頁數資料
    /// </summary>
    public abstract class ASearchPageInfo
    {
        int _page = 1;
        /// <summary>
        /// 當前頁數
        /// </summary>
        public int Page { get { return _page < 1 ? 1 : _page; } set { _page = value; } }

        /// <summary>
        /// 每頁限制顯示數
        /// </summary>
        public int Limit { get; set; } = 10;
    }
}
