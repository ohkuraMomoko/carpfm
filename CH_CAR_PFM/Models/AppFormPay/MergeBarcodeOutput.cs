using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得付款條碼 & ATM Output
    /// </summary>
    public class MergeBarcodeOutput
    {
        /// <summary>
        /// 條碼一
        /// </summary>
        public string BARCODE1 { get; set; }

        /// <summary>
        /// 條碼一
        /// </summary>
        public string BarCodeImage1 { get; set; }

        /// <summary>
        /// 條碼二
        /// </summary>
        public string BARCODE2 { get; set; }

        /// <summary>
        /// 條碼二
        /// </summary>
        public string BarCodeImage2 { get; set; }

        /// <summary>
        /// 條碼三
        /// </summary>
        public string BARCODE3 { get; set; }

        /// <summary>
        /// 條碼三
        /// </summary>
        public string BarCodeImage3 { get; set; }

        /// <summary>
        /// 銀行分行代碼
        /// </summary>
        public string BANK_CODE { get; set; }

        /// <summary>
        /// 銀行分行名稱
        /// </summary>
        public string BANK_NME { get; set; }

        /// <summary>
        /// 銀行匯款帳號
        /// </summary>
        public string ATM_ACCNTNO { get; set; }

        /// <summary>
        /// 繳款總金額
        /// </summary>
        public string TTL_AMT { get; set; }

        /// <summary>
        /// OINO
        /// </summary>
        public string OINO { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string PAY_DESC { get; set; }

        /// <summary>
        /// 空
        /// </summary>
        public string FEE_DESC { get; set; }

    }
}