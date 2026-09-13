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
        /// <remarks>
        /// 本多載視 <paramref name="_Data"/> 為「已經切好頁」的資料，不會再切頁。
        /// This overload treats <paramref name="_Data"/> as already paginated and does not slice it again.
        /// </remarks>
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
        /// <returns>分頁後的資料 (The paginated data)</returns>
        /// <remarks>
        /// 本多載視 <paramref name="_Data"/> 為未分頁的完整資料，會自行切頁並計算總筆數。
        /// This overload treats <paramref name="_Data"/> as the complete data set, slicing it and counting the total.
        /// </remarks>
        public static VPageData<T> ToPageData<T>(this List<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }
        /// <summary>
        /// 將 IQueryable&lt;T&gt; 轉換為分頁資料。
        /// Converts an IQueryable&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的查詢 (The query to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        /// <remarks>
        /// 本多載視 <paramref name="_Data"/> 為「已經切好頁」的查詢，不會再切頁。
        /// This overload treats <paramref name="_Data"/> as already paginated and does not slice it again.
        /// </remarks>
        public static VPageData<T> ToPageData<T>(this IQueryable<T> _Data, int _page, int _Limit, int _total)
        {
            return new VPageData<T>(_Data, _page, _Limit, _total);
        }
        /// <summary>
        /// 將 IQueryable&lt;T&gt; 轉換為分頁資料。
        /// Converts an IQueryable&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的查詢 (The query to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        /// <remarks>
        /// 本多載視 <paramref name="_Data"/> 為未分頁的完整查詢，會自行切頁並計算總筆數；
        /// 資料來源是 Entity Framework Core 時，兩者都會轉譯成資料庫端的操作。
        /// This overload treats <paramref name="_Data"/> as the complete query, slicing it and counting the total;
        /// against Entity Framework Core both are translated to the database.
        /// </remarks>
        public static VPageData<T> ToPageData<T>(this IQueryable<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }
        /// <summary>
        /// 將 IEnumerable&lt;T&gt; 轉換為分頁資料。
        /// Converts an IEnumerable&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的資料序列 (The sequence to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <param name="_total">資料總筆數 (Total number of items)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        /// <remarks>
        /// 本多載視 <paramref name="_Data"/> 為「已經切好頁」的資料，不會再切頁。
        /// This overload treats <paramref name="_Data"/> as already paginated and does not slice it again.
        /// </remarks>
        public static VPageData<T> ToPageData<T>(this IEnumerable<T> _Data, int _page, int _Limit, int _total)
        {
            return new VPageData<T>(_Data, _page, _Limit, _total);
        }
        /// <summary>
        /// 將 IEnumerable&lt;T&gt; 轉換為分頁資料。
        /// Converts an IEnumerable&lt;T&gt; to paginated data.
        /// </summary>
        /// <typeparam name="T">集合中項目的型別 (The type of items in the collection)</typeparam>
        /// <param name="_Data">要分頁的資料序列 (The sequence to paginate)</param>
        /// <param name="_page">頁碼 (The page number)</param>
        /// <param name="_Limit">每頁筆數 (Items per page)</param>
        /// <returns>分頁後的資料 (The paginated data)</returns>
        /// <remarks>
        /// 本多載視 <paramref name="_Data"/> 為未分頁的完整資料，會自行切頁並計算總筆數；
        /// 序列會被列舉兩次（一次切頁、一次計數），來源若只能列舉一次請先 <c>ToList()</c>。
        /// This overload treats <paramref name="_Data"/> as the complete sequence, slicing it and counting the total;
        /// the sequence is enumerated twice, so materialise a single-pass source with <c>ToList()</c> first.
        /// </remarks>
        public static VPageData<T> ToPageData<T>(this IEnumerable<T> _Data, int _page, int _Limit)
        {
            return new VPageData<T>(_Data, _page, _Limit);
        }
    }
}
