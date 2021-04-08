namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 繳款相關API Input共用欄位
    /// </summary>
    public class PayCommonInput
    {
        /// <summary>
        /// 系統代碼(固定塞 "CHAI_CAR_PAY")
        /// </summary>
        public string SYS_ID { get; set; }

        /// <summary>
        /// 會員編號(持久登入驗證)
        /// </summary>
        public string MbrId { get; set; }

        /// <summary>
        /// 裝置編號(持久登入驗證)
        /// </summary>
        public string DevId { get; set; }

        /// <summary>
        /// 持久登入用Token(持久登入驗證)
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// APP識別項目。A：重車、B：小車
        /// </summary>
        public string CAR_TYPE { get; set; } = "B";
    }
}