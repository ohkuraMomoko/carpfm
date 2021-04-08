namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// AR DATA
    /// </summary>
    public class ArData
    {
        /// <summary>
        /// '契約編號
        /// </summary>
        public string CNTRT_NO { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public int PRD_NUM { get; set; }

        /// <summary>
        /// 繳款應繳(逾期/當期), 第一期期數
        /// </summary>
        public int MIN_AR_ID { get; set; }

        /// <summary>
        /// 繳款總金額
        /// </summary>
        public int PAY_AMT { get; set; }
    }
}