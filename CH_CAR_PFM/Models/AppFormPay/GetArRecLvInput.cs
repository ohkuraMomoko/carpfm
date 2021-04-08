using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得標的物資料(繳款紀錄) Input
    /// </summary>
    public class GetArRecLvInput : PayCommonInput
    {
        /// <summary>
        /// 客戶ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 公司代碼(多筆請用逗點隔開, 固定塞 "3,103" )
        /// </summary>
        public string COMP_ID { get; set; }
    }
}