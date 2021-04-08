using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得繳款紀錄(含已繳項目) Output
    /// </summary>
    public class GetArRecOutput: PayCommonBaseOutput
    {
        /// <summary>
        /// 契約編號_{{期數}}
        /// </summary>
        public string AR_PK { get; set; }

        /// <summary>
        /// 期數
        /// </summary>
        public int AR_ID { get; set; }

        /// <summary>
        /// 共N期
        /// </summary>
        public int AR_CNT { get; set; }

        /// <summary>
        /// 繳款提示
        /// </summary>
        public string AR_DESC { get; set; }

        /// <summary>
        /// 系統收款日
        /// </summary>
        public string AR_PAYDT { get; set; }

        /// <summary>
        /// 繳款狀態(1: 已款繳 2:未繳款 3:逾時未繳款)
        /// </summary>
        public string PAYMENT_STATUS { get; set; }

        /// <summary>
        /// 是否已逾期(Y/N)
        /// </summary>
        public string OVERDUE { get; set; }

        /// <summary>
        /// 已繳期數
        /// </summary>
        public int PAY_AR_CNT { get; set; }

        /// <summary>
        /// 總期數
        /// </summary>
        public int TOTAL_AR_CNT { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string FIRST_PERIOD { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string MERGE_LIMIT { get; set; }

        /// <summary>
        /// 是否為當期(Y/N)
        /// </summary>
        public string ISCURRENT { get; set; }

    }
}