using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models.AppFormPay
{
    /// <summary>
    /// 取得往來明細清單(未繳/逾期) Output
    /// </summary>
    public class GetArRecLvNewOutput: PayCommonOutput
    {
        /// <summary>
        /// 是否為代繳(Y/N)
        /// </summary>
        public string IS_PROXY { get; set; }

        /// <summary>
        /// 應繳總金額(本期+逾期)
        /// </summary>
        public decimal PAYABLE_AMT { get; set; }

        /// <summary>
        /// AR 清單
        /// </summary>
        public List<ArList> AR_LIST { get; set; }
    }
}