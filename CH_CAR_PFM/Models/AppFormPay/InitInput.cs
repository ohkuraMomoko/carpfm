namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得全資料(已繳/未繳/逾期)
    /// </summary>
    public class InitInput : PayCommonInput
    {
        /// <summary>
        /// 客戶ID
        /// </summary>
        public string ID { get; set; }
    }
}