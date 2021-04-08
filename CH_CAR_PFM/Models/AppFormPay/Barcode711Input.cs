namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得7-11條碼 Input
    /// </summary>
    public class Barcode711Input : PayCommonInput
    {
        /// <summary>
        /// oino
        /// </summary>
        public string Oino { get; set; }

        /// <summary>
        /// 公司代碼(多筆請用逗點隔開, 固定塞 "3,103" )
        /// </summary>
        public string COMP_ID { get; set; }

        /// <summary>
        /// 條碼二
        /// </summary>
        public string OL_Code_2 { get; set; }

        /// <summary>
        /// 繳費總金額
        /// </summary>
        public string OL_Amount { get; set; }

        /// <summary>
        /// 同條碼二
        /// </summary>
        public string TraceID { get; set; }

    }
}