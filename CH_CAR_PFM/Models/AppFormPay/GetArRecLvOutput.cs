using System.Collections.Generic;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得標的物資料(繳款紀錄) Output
    /// </summary>
    public class GetArRecLvOutput: PayCommonOutput
    {
        /// <summary>
        /// 已繳期數
        /// </summary>
        public int PAY_AR_CNT { get; set; }

        /// <summary>
        /// 總期數
        /// </summary>
        public int TOTAL_AR_CNT { get; set; }

        /// <summary>
        /// 車貸申請日 (yyyy/mm/dd)
        /// </summary>
        public string APLY_DT { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string APR_DT { get; set; }

        /// <summary>
        /// 最後一期繳款時間
        /// </summary>
        public string LAST_PAYDT { get; set; }
    }
}