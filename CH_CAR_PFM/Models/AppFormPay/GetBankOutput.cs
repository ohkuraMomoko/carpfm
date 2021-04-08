namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 銀行列表相關 MODEL
    /// </summary>
    public class GetBankOutput
    {
        /// <summary>
        /// SewId
        /// </summary>
        public string BANK_SEQ { get; set; }

        /// <summary>
        /// 銀行名稱
        /// </summary>
        public string BANK_NME { get; set; }

        /// <summary>
        /// 銀行網址
        /// </summary>
        public string BANK_URL { get; set; }

        /// <summary>
        /// 銀行電話
        /// </summary>
        public string BANK_TEL { get; set; }

        /// <summary>
        /// 銀行顯示電話
        /// </summary>
        public string BANK_TEL_DISPLAY { get; set; }

        /// <summary>
        /// 順序
        /// </summary>
        public string SORT_NO { get; set; }
    }
}