using System.Collections.Generic;
using System.Linq;

namespace Ozakboy.PageData
{
    /// <summary>
    /// 提供將各種集合型別轉換為分頁資料的擴充方法。
    /// Provides extension methods for converting various collection types to paginated data.
    /// </summary>
    public static class ToPageDataExtensions
    {
        /// <summary>
        /// 將 List&lt;T&gt; 轉換為分頁資料。
        /// Converts a List&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的資料集合 (The data collection to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        public static VPageData<T> ToPageData<T>(this List<T> _Data, int _page, int _Limit, int _total)
        {
            return new VPageData<T>(_Data, _page, _Limit, _total);
        }
        /// <summary>
        /// 將 List&lt;T&gt; 轉換為分頁資料。
        /// Converts a List&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的資料集合 (The data collection to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        public static VPageData<T> ToPageData<T>(this List<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }
        /// <summary>
        /// 將 List&lt;T&gt; 轉換為分頁資料。
        /// Converts a List&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的資料集合 (The data collection to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        public static VPageData<T> ToPageData<T>(this IQueryable<T> _Data, int _page, int _Limit, int _total)
        {
            return new VPageData<T>(_Data, _page, _Limit, _total);
        }
        /// <summary>
        /// 將 List&lt;T&gt; 轉換為分頁資料。
        /// Converts a List&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的資料集合 (The data collection to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        public static VPageData<T> ToPageData<T>(this IQueryable<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }
        /// <summary>
        /// 將 List&lt;T&gt; 轉換為分頁資料。
        /// Converts a List&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的資料集合 (The data collection to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        public static VPageData<T> ToPageData<T>(this IEnumerable<T> _Data, int _page, int _Limit, int _total)
        {
            return new VPageData<T>(_Data, _page, _Limit, _total);
        }
        /// <summary>
        /// 將 List&lt;T&gt; 轉換為分頁資料。
        /// Converts a List&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的資料集合 (The data collection to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        public static VPageData<T> ToPageData<T>(this IEnumerable<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }
    }
}
