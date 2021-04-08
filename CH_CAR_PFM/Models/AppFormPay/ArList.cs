using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// AR 清單
    /// </summary>
    public class ArList
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
        /// 當期應繳金額
        /// </summary>
        public string AR_AMT { get; set; }

        /// <summary>
        /// 繳款截止日(含狀態)
        /// </summary>
        public string AR_DT { get; set; }

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
        /// 是否為當期(Y/N)
        /// </summary>
        public string ISCURRENT { get; set; }
    }
}