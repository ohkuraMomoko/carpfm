using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models
{
    /// <summary>
    /// 取得會員資訊 Output
    /// </summary>
    public class GetCustInfoOutput
    {
        /// <summary>
        /// 身分證字號(統編)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        public string NICK_NME { get; set; }
    }
}