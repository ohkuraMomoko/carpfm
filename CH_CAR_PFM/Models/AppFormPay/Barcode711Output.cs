namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得7-11條碼 Output
    /// </summary>
    public class Barcode711Output
    {
        /// <summary>
        /// 結果Code
        /// </summary>
        public string resultCode { get; set; }

        /// <summary>
        /// 結果訊息
        /// </summary>
        public string resultMsg { get; set; }

        /// <summary>
        /// base64條碼圖
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 同條碼二
        /// </summary>
        public string TraceID { get; set; }
    }
}