using CH_CAR_PFM.Helps;
using CH_CAR_PFM.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace CH_CAR_PFM.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 取得Cookie解密資訊
        /// </summary>
        protected TokenVerifyModel TokenVerify
        {
            get
            {
                HttpCookie Authcookie = this.Request.Cookies["CAR"];

                if (Authcookie != null)
                {
                    TokenVerifyModel verifyModel = new TokenVerifyModel
                    {
                        //AES解密
                        Id = Authcookie.Values["Id"] != null ? new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Decryptor(Authcookie.Values["Id"].ToString()) : string.Empty,
                        MbrId = Authcookie.Values["MbrId"] != null ? new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Decryptor(Authcookie?.Values["MbrId"].ToString()) : string.Empty,
                        DevId = Authcookie.Values["DevId"] != null ? new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Decryptor(Authcookie?.Values["DevId"].ToString()) : string.Empty,
                        Token = Authcookie.Values["Token"] != null ? new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Decryptor(Authcookie?.Values["Token"].ToString()) : string.Empty,
                        CustId = Authcookie.Values["CustId"] != null ? new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Decryptor(Authcookie?.Values["CustId"].ToString()) : string.Empty,
                        CntrtNo = Authcookie.Values["CntrtNo"] != null ? new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Decryptor(Authcookie?.Values["CntrtNo"].ToString()) : string.Empty
                    };

                    return verifyModel;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 加入Cookie
        /// </summary>
        /// <param name="id">身分證字號(統編)</param>
        /// <param name="mbrId">會員編號(持久登入驗證)</param>
        /// <param name="devId">裝置編號(持久登入驗證)</param>
        /// <param name="token">持久登入用Token(持久登入驗證)</param>
        /// <returns></returns>
        protected HttpCookie AirdCookie(string id, string mbrId, string devId, string token, string custId, string cntrtNo)
        {
            HttpCookie AirdCookie = new HttpCookie("CAR");
            AirdCookie.Values.Add("Id", new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Encryptor(id));
            AirdCookie.Values.Add("MbrId", new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Encryptor(mbrId));
            AirdCookie.Values.Add("DevId", new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Encryptor(devId));
            AirdCookie.Values.Add("Token", new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Encryptor(token));
            AirdCookie.Values.Add("CustId", new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Encryptor(custId));
            AirdCookie.Values.Add("CntrtNo", new AesCrypto(Common.GetAesKey(), Common.GetAesIv()).Encryptor(cntrtNo));
            AirdCookie.Expires = DateTime.Now.AddMonths(1);

            return AirdCookie;
        }
    }
}