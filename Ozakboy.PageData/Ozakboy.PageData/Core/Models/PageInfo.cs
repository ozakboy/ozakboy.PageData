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
            TotalPage = CalculateTotalPage(_total, _Limit);
        }

        /// <summary>
        /// 由總筆數與每頁筆數算出總頁數(向上取整)。
        /// 每頁筆數小於等於 0 或總筆數小於等於 0 時回傳 0:沒有「一頁」可言,也沒有資料可分。
        /// 1.2.0 以前每頁筆數為 0 會除以零(double 的 Infinity 轉 int 是未定義行為,實務上得到 int.MinValue)。
        /// Computes the total number of pages (rounded up) from the item count and page size.
        /// Returns 0 when the page size or the item count is zero or negative: there is no page to speak of.
        /// Before 1.2.1 a page size of 0 divided by zero (double Infinity cast to int is undefined; int.MinValue in practice).
        /// </summary>
        /// <param name="total">資料總筆數 (Total number of items)</param>
        /// <param name="limit">每頁筆數 (Items per page)</param>
        /// <returns>總頁數 (Total number of pages)</returns>
        public static int CalculateTotalPage(int total, int limit)
        {
            if (limit <= 0 || total <= 0)
            {
                return 0;
            }

            // 用整數運算向上取整,不經過 double;用 long 避免 total + limit 溢位。
            // Integer ceiling without going through double; long avoids overflow in total + limit.
            return (int)(((long)total + limit - 1) / limit);
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
