using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ozakboy.PageData.Core.Models;

namespace Ozakboy.PageData.Core.Extensions
{
    public static class ToPageDataHelper
    {
        public static VPageData<T> ToPageData<T>(this List<T> _Data, int _page, int _Limit, int _total)
        {
            return new VPageData<T>(_Data, _page, _Limit, _total);
        }
        public static VPageData<T> ToPageData<T>(this List<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }
        public static VPageData<T> ToPageData<T>(this IQueryable<T> _Data, int _page, int _Limit, int _total)
        {
            return new VPageData<T>(_Data, _page, _Limit, _total);
        }
        public static VPageData<T> ToPageData<T>(this IQueryable<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }

        public static VPageData<T> ToPageData<T>(this IEnumerable<T> _Data, int _page, int _Limit, int _total)
        {
            return new VPageData<T>(_Data, _page, _Limit, _total);
        }
        public static VPageData<T> ToPageData<T>(this IEnumerable<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }
    }
}
