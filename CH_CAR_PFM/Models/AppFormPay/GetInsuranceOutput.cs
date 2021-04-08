namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得保險列表
    /// </summary>
    public class GetInsuranceOutput
    {
        /// <summary>
        /// SewId
        /// </summary>
        public string INSURANCE_SEQ { get; set; }

        /// <summary>
        /// 保險公司名稱
        /// </summary>
        public string INSURANCE_NME { get; set; }

        /// <summary>
        /// 保險公司電話
        /// </summary>
        public string INSURANCE_TEL { get; set; }

        /// <summary>
        /// 保險公司顯示電話
        /// </summary>
        public string INSURANCE_TEL_DISPLAY { get; set; }

        /// <summary>
        /// 順序
        /// </summary>
        public string SORT_NO { get; set; }
    }
}