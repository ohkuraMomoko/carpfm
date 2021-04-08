using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得繳款紀錄(含已繳項目)
    /// </summary>
    public class GetArRecInput : PayCommonInput
    {
        /// <summary>
        /// 客戶ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 契約編號
        /// </summary>
        public string CNTRT_NO { get; set; }

        /// <summary>
        /// 公司代碼(多筆請用逗點隔開, 固定塞 "3,103" )
        /// </summary>
        public string COMP_ID { get; set; }
    }
}