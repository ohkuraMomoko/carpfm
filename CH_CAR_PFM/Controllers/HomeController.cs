using CH_CAR_PFM.Models;
using CH_CAR_PFM.Models.AppFormPay;
using CH_CAR_PFM.Service;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CH_CAR_PFM.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 繳款
        /// </summary>
        /// <param name="MbrId">會員編號(持久登入驗證)</param>
        /// <param name="DevId">裝置編號(持久登入驗證)</param>
        /// <param name="Token">持久登入用Token(持久登入驗證)</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(string MbrId, string DevId, string Token)
        {
            if (string.IsNullOrEmpty(MbrId) && string.IsNullOrEmpty(this.TokenVerify?.MbrId))
            {
                return this.Json(new { isError = true, message = "查無資料!!!" }, JsonRequestBehavior.AllowGet);
            }

            GetCustInfoInput model = new GetCustInfoInput
            {
                MBR_ID = string.IsNullOrEmpty(MbrId) ? this.TokenVerify.MbrId : MbrId,
                MbrId = string.IsNullOrEmpty(MbrId) ? this.TokenVerify.MbrId : MbrId,
                DevId = string.IsNullOrEmpty(DevId) ? this.TokenVerify.DevId : DevId,
                Token = string.IsNullOrEmpty(Token) ? this.TokenVerify.Token : Token
            };


            // 取得會員資料
            HomeService homeService = new HomeService();
            GetCustInfoOutput result = await homeService.GetCustInfo(model);

            // 是否已綁定個人資料或代繳契約
            CustProxyPayStatus proxyPayStatus = await homeService.GetCustProxyPayStatus(model);
            if (string.IsNullOrEmpty(result.ID) ||
                proxyPayStatus.REG_COUNT < 3)
            {
                this.ViewBag.ShowAddButton = true;
            }
            else
            {
                this.ViewBag.ShowAddButton = false;
            }

            if (!string.IsNullOrEmpty(MbrId) && (string.IsNullOrEmpty(this.TokenVerify?.MbrId) || this.TokenVerify.MbrId != MbrId))
            {
                //// 取得會員資料
                //HomeService homeService = new HomeService();
                //GetCustInfoOutput result = await homeService.GetCustInfo(model);

                //// 是否已綁定個人資料或代繳契約
                //CustProxyPayStatus proxyPayStatus = await homeService.GetCustProxyPayStatus(model);
                //if (string.IsNullOrEmpty(result.ID) ||
                //    proxyPayStatus.REG_COUNT < 3)
                //{
                //    this.ViewBag.ShowAddButton = true;
                //}
                //else
                //{
                //    this.ViewBag.ShowAddButton = false;
                //}

                // 取得全資料
                InitOutput initOutput = await homeService.INIT(result.ID);

                // 加入Cookie
                System.Web.HttpCookie AridCookie = this.AirdCookie(result.ID ?? string.Empty, MbrId, DevId, Token, initOutput?.CUST_ID ?? string.Empty, initOutput?.CNTRT_NO ?? string.Empty);
                this.Response.Cookies.Add(AridCookie);
            }
            
            this.ViewBag.Title = "我的帳單";
            
            return this.View();
        }

        public ActionResult PaymentAR()
        {
            return this.View();
        }

        /// <summary>
        /// 繳款紀錄
        /// </summary>
        /// <returns></returns>
        public ActionResult Record()
        {
            return this.View();
        }

        public ActionResult RecordDetail()
        {
            return this.View();
        }

        public ActionResult PaymentList()
        {
            return this.View();
        }

        public ActionResult PaymentATM()
        {
            return this.View();
        }

        public ActionResult PaymentConStore()
        {
            return this.View();
        }

        public ActionResult Barcode()
        {
            return this.View();
        }

        public ActionResult Close()
        {
            return this.View();
        }

        public ActionResult Rescue()
        {
            return this.View();
        }

        public ActionResult Add()
        {
            return this.View();
        }
    }
}