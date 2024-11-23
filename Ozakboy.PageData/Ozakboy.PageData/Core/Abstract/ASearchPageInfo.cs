
namespace Ozakboy.PageData
{
    /// <summary>
    /// 提供分頁查詢的抽象基礎類別。包含基本的分頁參數設定。
    /// Abstract base class for pagination query parameters.
    /// </summary>
    /// <remarks>
    /// 此類別作為所有需要分頁功能查詢參數的基礎類別。
    /// 繼承此類別可獲得基本的分頁參數屬性，包括頁碼和每頁筆數限制。
    /// </remarks>
    public abstract class ASearchPageInfo
    {
        int _page = 1;

        /// <summary>
        /// 取得或設定當前頁碼。值必須大於等於1，若小於1將自動調整為1。
        /// Gets or sets the current page number. Must be greater than or equal to 1.
        /// </summary>
        /// <value>
        /// 當前頁碼。預設值為1。
        /// The current page number. Defaults to 1.
        /// </value>
        public int Page { get { return _page < 1 ? 1 : _page; } set { _page = value; } }

        /// <summary>
        /// 取得或設定每頁顯示的資料筆數。
        /// Gets or sets the number of items to display per page.
        /// </summary>
        /// <value>
        /// 每頁顯示筆數。預設值為10。
        /// Number of items per page. Defaults to 10.
        /// </value>
        public int Limit { get; set; } = 10;
    }
}
