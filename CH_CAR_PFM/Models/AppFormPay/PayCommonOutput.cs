using System.Collections.Generic;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 繳款相關API Output共用欄位
    /// </summary>
    public class PayCommonOutput: PayCommonBaseOutput
    {
        /// <summary>
        /// '契約編號
        /// </summary>
        public string CNTRT_NO { get; set; }

        /// <summary>
        /// 繳款狀態描述
        /// </summary>
        public string PAYMENT_DESC { get; set; }

        /// <summary>
        /// 總金額
        /// </summary>
        public decimal TTL_AMT { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string BUY_DT { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string IS_FINISH { get; set; }
    }
}