using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CH_CAR_PFM.Helps
{
    public class Common
    {
        /// <summary>
        /// 取得 SYS_ID
        /// </summary>
        /// <returns></returns>
        public static string GetSysId()
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings["SYS_ID"];
        }

        /// <summary>
        /// 取得 AES加密KEY
        /// </summary>
        /// <returns></returns>
        public static string GetAesKey()
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings["AES_KEY"];
        }

        /// <summary>
        /// 取得 AES加密IV
        /// </summary>
        /// <returns></returns>
        public static string GetAesIv()
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings["AES_IV"];
        }
    }
}