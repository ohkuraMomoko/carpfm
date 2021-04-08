using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models
{
    /// <summary>
    /// 取得會員資訊 Input
    /// </summary>
    public class GetCustInfoInput
    {
        /// <summary>
        /// 會員編號
        /// </summary>
        public string MBR_ID { get; set; }

        /// <summary>
        /// 會員編號(持久登入驗證)
        /// </summary>
        public string MbrId { get; set; }

        /// <summary>
        /// 裝置編號(持久登入驗證)
        /// </summary>
        public string DevId { get; set; }

        /// <summary>
        /// 持久登入用Token(持久登入驗證)
        /// </summary>
        public string Token { get; set; }
    }
}