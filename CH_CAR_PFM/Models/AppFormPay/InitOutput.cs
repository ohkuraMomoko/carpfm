using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得全資料(已繳/未繳/逾期) Output
    /// </summary>
    public class InitOutput
    {
        /// <summary>
        /// 契約編號
        /// </summary>
        public string CNTRT_NO { get; set; }

        /// <summary>
        /// 標的物陣列
        /// </summary>
        public List<ObjItems> OBJ_ITEMS { get; set; }

        /// <summary>
        /// 繳款狀態描述
        /// </summary>
        public string PAYMENT_DESC { get; set; }

        /// <summary>
        /// 繳款截止日(含狀態) 如果逾期多期, 則顯示逾期第一期, 如準時繳款, 則顯示應繳下一期
        /// </summary>
        public string AR_DT { get; set; }

        /// <summary>
        /// 應繳該期金額
        /// </summary>
        public string AR_AMT { get; set; }

        /// <summary>
        /// 總金額
        /// </summary>
        public string TTL_AMT { get; set; }

        /// <summary>
        /// AR清單
        /// </summary>
        public List<ArList> AR_LIST { get; set; }

        /// <summary>
        /// 同INPUT 客戶ID
        /// </summary>
        public string CUST_ID { get; set; }

        /// <summary>
        /// 車貸申請日
        /// </summary>
        public string APLY_DT { get; set; }

        /// <summary>
        /// 畫面顯示區塊(1:繳款 2:紀錄), 如果一個契編同時存在於兩個地方, 則用逗點隔開
        /// </summary>
        public string VW_ITEMS { get; set; }

        /// <summary>
        /// 已繳期數
        /// </summary>
        public int PAY_AR_CNT { get; set; }

        /// <summary>
        /// 契約總期數
        /// </summary>
        public int TOTAL_AR_CNT { get; set; }

    }
}