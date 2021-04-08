using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 驗證最後送出AR資訊是否正確
    /// </summary>
    public class ValidArPayInput : PayCommonInput
    {
        /// <summary>
        /// 客戶統編/身份證
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 契約編號
        /// </summary>
        public string CNTRT_NO { get; set; }

        /// <summary>
        /// 應繳款該期期數[陣列]
        /// </summary>
        public int[] AR_ID_ITEMS { get; set; }

        /// <summary>
        /// 應繳款總金額
        /// </summary>
        public decimal AR_AMT_SUM { get; set; }

        /// <summary>
        /// 繳款方式(1:ATM 2:超商繳款)
        /// </summary>
        public string PAY_METHOD { get; set; }
    }
}