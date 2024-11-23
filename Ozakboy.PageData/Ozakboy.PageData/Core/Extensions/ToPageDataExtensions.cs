using System.Collections.Generic;
using System.Linq;

namespace Ozakboy.PageData
{
    public static class ToPageDataExtensions
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
