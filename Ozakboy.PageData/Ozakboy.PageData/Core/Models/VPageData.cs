

using System.Collections.Generic;
using System.Linq;

namespace Ozakboy.PageData.Core.Models
{
    /// <summary>
    /// 分頁式資料回傳架構
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VPageData<T>
    {
        public VPageData() { }
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
        /// 呈現資料
        /// </summary>
        public List<T> PageData { get; set; }

        /// <summary>
        /// 分頁資訊
        /// </summary>
        public PageInfo PageInfo { get; set; }
    }
}
