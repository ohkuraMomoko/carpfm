using System.Collections.Generic;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得付款條碼 & ATM Input
    /// </summary>
    public class MergeBarcodeInput : PayCommonInput
    {
        /// <summary>
        /// 公司代碼(多筆請用逗點隔開, 固定塞 "3,103" )
        /// </summary>
        public string COMP_ID { get; set; }

        /// <summary>
        /// 客戶ID
        /// </summary>
        public string CUST_NO { get; set; }

        /// <summary>
        /// AR DATA
        /// </summary>
        public List<ArData> AR_DATA { get; set; }
    }
}