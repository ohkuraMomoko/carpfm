using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 繳款相關API Output共用欄位
    /// </summary>
    public class PayCommonBaseOutput
    {
        /// <summary>
        /// 應繳該期金額
        /// </summary>
        public decimal AR_AMT { get; set; }

        /// <summary>
        /// 標的物陣列
        /// </summary>
        public List<ObjItems> OBJ_ITEMS { get; set; }

        /// <summary>
        /// 繳款截止日(含狀態)，如果逾期多期, 則顯示逾期第一期, 如準時繳款, 則顯示應繳下一期
        /// </summary>
        public string AR_DT { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string OBJ_NAME { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string VENDER_NME { get; set; }
    }
}