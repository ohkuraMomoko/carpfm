using CH_CAR_PFM.Helps;
using CH_CAR_PFM.Models;
using CH_CAR_PFM.Models.AppFormPay;
using CH_CAR_PFM.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CH_CAR_PFM.Controllers
{
    /// <summary>
    /// APP 繳款 Controller
    /// </summary>
    public class AppFormPayController : BaseController
    {
        /// <summary>
        /// 取得標的物資料(繳款紀錄)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AppFormPay/GetArRecLv1")]
        public async Task<ActionResult> GetArRecLv1()
        {
            GetCustInfoInput cusModel = new GetCustInfoInput();
            GetCustInfoOutput cusResult = new GetCustInfoOutput();

            if (this.TokenVerify.Id == string.Empty)
            {
                cusModel = new GetCustInfoInput
                {
                    MBR_ID = this.TokenVerify.MbrId,
                    MbrId = this.TokenVerify.MbrId,
                    DevId = this.TokenVerify.DevId,
                    Token = this.TokenVerify.Token
                };

                // 取得會員資料
                HomeService homeService = new HomeService();
                cusResult = await homeService.GetCustInfo(cusModel);

                if(cusResult.ID != string.Empty)
                {
                    // 取得全資料
                    InitOutput initOutput = await homeService.INIT(cusResult.ID);

                    System.Web.HttpCookie AridCookie = this.AirdCookie(cusResult.ID ?? string.Empty, this.TokenVerify.MbrId, this.TokenVerify.DevId, this.TokenVerify.Token, initOutput?.CUST_ID ?? string.Empty, initOutput?.CNTRT_NO ?? string.Empty);
                    this.Response.Cookies.Add(AridCookie);
                }               
            }


            GetArRecLvInput model = new GetArRecLvInput
            {
                //ID = this.TokenVerify.Id,
                ID = !string.IsNullOrEmpty(cusResult.ID) ? cusResult.ID : this.TokenVerify.Id,
                COMP_ID = this.TokenVerify.CustId,
                MbrId = this.TokenVerify.MbrId,
                DevId = this.TokenVerify.DevId,
                Token = this.TokenVerify.Token,
                SYS_ID = Common.GetSysId()
            };

            AppFormPayService appFormPayService = new AppFormPayService();
            BaseListResult<GetArRecLvOutput> result = await appFormPayService.GetArRecLv1(model);

            return this.Json(result);
        }

        /// <summary>
        /// 取得往來明細清單(未繳/逾期)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AppFormPay/GetArLv1New")]
        public async Task<ActionResult> GetArLv1New()
        {
            var dataList = new List<GetArRecLvNewOutput>();
            var data = new GetArRecLvNewOutput();
            var ar = new ArList();
            var arList = new List<ArList>();

            GetArRecLvInput model = new GetArRecLvInput
            {
                ID = this.TokenVerify.Id,
                COMP_ID = this.TokenVerify.CustId,
                MbrId = this.TokenVerify.MbrId,
                DevId = this.TokenVerify.DevId,
                Token = this.TokenVerify.Token,
                SYS_ID = Common.GetSysId()
            };

            AppFormPayService appFormPayService = new AppFormPayService();
            BaseListResult<GetArRecLvNewOutput> result = await appFormPayService.GetArLv1New(model);

            foreach (var item in result.Data)
            {
                data = new GetArRecLvNewOutput();
                arList = new List<ArList>();

                data.IS_PROXY = item.IS_PROXY;
                data.PAYABLE_AMT = item.PAYABLE_AMT;
                data.CNTRT_NO = item.CNTRT_NO;
                data.OBJ_ITEMS = item.OBJ_ITEMS;
                data.PAYMENT_DESC = item.PAYMENT_DESC;
                data.AR_DT = item.AR_DT;
                data.AR_AMT = item.AR_AMT;
                data.TTL_AMT = item.TTL_AMT;
                data.OBJ_NAME = item.OBJ_NAME;
                data.VENDER_NME = item.VENDER_NME;
                data.BUY_DT = item.BUY_DT;
                data.IS_FINISH = item.IS_FINISH;

                foreach (var itemList in item.AR_LIST)
                {
                    ar = new ArList();
                    ar.AR_AMT = itemList.AR_AMT;
                    ar.AR_CNT = itemList.AR_CNT;
                    ar.AR_DESC = itemList.AR_DESC;
                    ar.AR_DT = itemList.AR_DT;
                    ar.AR_ID = itemList.AR_ID;
                    ar.AR_PAYDT = itemList.AR_PAYDT;
                    ar.AR_PK = itemList.AR_PK;
                    ar.ISCURRENT = itemList.ISCURRENT;
                    ar.OVERDUE = itemList.OVERDUE;
                    ar.PAYMENT_STATUS = itemList.PAYMENT_STATUS;

                    if (item.IS_PROXY == "Y" && itemList.PAYMENT_STATUS == "1" && itemList.ISCURRENT == "Y")
                    {
                        data.PAYABLE_AMT = 0;
                        data.AR_DT = itemList.AR_DT;
                    }

                    arList.Add(ar);
                }

                data.AR_LIST = arList;
                dataList.Add(data);
            }

            result.Data = dataList;

            return this.Json(result);
        }

        /// <summary>
        /// 驗證最後送出AR資訊是否正確
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AppFormPay/ValidateArPay")]
        public async Task<ActionResult> ValidateArPay(int[] arIdItems, Decimal arAmtSum, string payMethod, string CNTRT_NO)
        {
            ValidArPayInput model = new ValidArPayInput
            {
                CNTRT_NO = CNTRT_NO,
                AR_ID_ITEMS = arIdItems,
                AR_AMT_SUM = arAmtSum,
                PAY_METHOD = payMethod,
                MbrId = this.TokenVerify.MbrId,
                DevId = this.TokenVerify.DevId,
                Token = this.TokenVerify.Token,
                SYS_ID = Common.GetSysId()
            };

            AppFormPayService appFormPayService = new AppFormPayService();
            BaseResult<ValidArPayOutput> result = await appFormPayService.ValidateArPay(model);

            return this.Json(result);
        }

        /// <summary>
        /// 取得 7-11 超商繳費 BarCode 圖片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AppFormPay/Get711BarCodeImg")]
        public async Task<ActionResult> Get711BarCodeImg(List<ArList> arList)
        {
            BaseResult<MergeBarcodeOutput> resultModel = await this.GetMergeBarCodeData(arList);
            if (resultModel.Result.ReturnCode != 0)
            {
                return null;
            }

            // 7-11 要自行抽換 barCode 前四碼
            string checkBarCodeHead = ConfigurationManager.AppSettings["CheckBarCodeHead"];
            string barCodeHead = barCodeHead = ConfigurationManager.AppSettings["711BarCodeHead"];

            // 如果前四碼不是G800的話，就抽換成創鉅的 G910
            if (resultModel.Data.BARCODE2.Substring(0, 4) != checkBarCodeHead)
            {
                barCodeHead = ConfigurationManager.AppSettings["711BarCodeHead2"];
            }

            string barCode2 = barCodeHead + resultModel.Data.BARCODE2.Substring(4, resultModel.Data.BARCODE2.Length - 4);
            int totalAmount = arList.Sum(x => int.Parse(x.AR_AMT));

            Barcode711Input model = new Barcode711Input
            {
                COMP_ID = this.TokenVerify.CustId,
                Oino = resultModel.Data.OINO,
                OL_Amount = totalAmount.ToString(),
                OL_Code_2 = barCode2,
                TraceID = barCode2,
                MbrId = this.TokenVerify.MbrId,
                DevId = this.TokenVerify.DevId,
                Token = this.TokenVerify.Token,
                SYS_ID = Common.GetSysId()
            };

            AppFormPayService appFormPayService = new AppFormPayService();
            BaseResult<Barcode711Output> result = await appFormPayService.Get711BarCodeImg(model);

            return this.Json(result);
        }

        /// <summary>
        /// 取得超商繳費 BarCode
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AppFormPay/GetMergeBarCode")]
        public async Task<ActionResult> GetMergeBarCode(List<ArList> arList)
        {
            BaseResult<MergeBarcodeOutput> result = await this.GetMergeBarCodeData(arList);

            return this.Json(result);
        }

        /// <summary>
        /// 取得繳款紀錄(含已繳項目)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AppFormPay/GetArRec")]
        public async Task<ActionResult> GetArRec(string cntrtNo)
        {
            GetArRecInput model = new GetArRecInput
            {
                ID = this.TokenVerify.Id,
                CNTRT_NO = cntrtNo,
                COMP_ID = this.TokenVerify.CustId,
                MbrId = this.TokenVerify.MbrId,
                DevId = this.TokenVerify.DevId,
                Token = this.TokenVerify.Token,
                SYS_ID = Common.GetSysId()
            };

            AppFormPayService appFormPayService = new AppFormPayService();
            BaseListResult<GetArRecOutput> result = await appFormPayService.GetArRec(model);

            return this.Json(result);
        }

        [HttpGet]
        [Route("AppFormPay/GetBarCodeImage")]
        public string GetBarCodeImage(string barcodeStr)
        {
            //產生圖片檔案
            string SavePath = @"C:\Outsourcing\barcode.png";
            //Barcode條碼需在前後加上*字號代表開始與結束
            Bitmap barcode = this.CreateBarCode("*" + barcodeStr + "*");
            barcode.Save(SavePath, ImageFormat.Png);
            barcode.Dispose();

            //將圖片檔案轉成Base64字串
            using (FileStream fs = new FileStream(SavePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                string base64String = Convert.ToBase64String(buffer);
                string ImgBase64 = string.Format("data:image/png;base64,{0}'", base64String);
                return ImgBase64;
            }
        }

        /// <summary>
        /// 將字串轉為Barcode圖片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Bitmap CreateBarCode(string data)
        {
            Bitmap barcode = new Bitmap(1, 1);
            Font threeOfNine = new Font("細明體", 60,
                                    FontStyle.Regular,
                                    GraphicsUnit.Point);

            Graphics graphics = Graphics.FromImage(barcode);

            SizeF dataSize = graphics.MeasureString(data, threeOfNine);

            barcode = new Bitmap(barcode, dataSize.ToSize());
            graphics = Graphics.FromImage(barcode);
            graphics.Clear(Color.White);

            graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

            graphics.DrawString(data, threeOfNine, new SolidBrush(Color.Black), 0, 0);

            graphics.Flush();
            threeOfNine.Dispose();
            graphics.Dispose();

            return barcode;
        }


        /// <summary>
        /// 取得銀行列表
        /// </summary>
        /// <returns>銀行列表</returns>
        [HttpPost]
        [Route("AppFormPay/GetBank")]
        public async Task<ActionResult> GetBank()
        {
            AppFormPayService appFormPayService = new AppFormPayService();
            BaseListResult<GetBankOutput> result = await appFormPayService.GetBank();

            return this.Json(result);
        }


        /// <summary>
        /// 取得保險列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AppFormPay/GetInsurance")]
        public async Task<ActionResult> GetInsurance()
        {
            AppFormPayService appFormPayService = new AppFormPayService();
            BaseListResult<GetInsuranceOutput> result = await appFormPayService.GetInsurance();

            return this.Json(result);
        }


        /// <summary>
        /// 取得 Barcod 等其他資訊
        /// </summary>
        /// <param name="arList"></param>
        /// <returns></returns>
        private async Task<BaseResult<MergeBarcodeOutput>> GetMergeBarCodeData(List<ArList> arList)
        {
            MergeBarcodeInput model = new MergeBarcodeInput
            {
                CUST_NO = this.TokenVerify.Id,
                // COMP_ID = this.TokenVerify.CntrtNo,
                MbrId = this.TokenVerify.MbrId,
                DevId = this.TokenVerify.DevId,
                Token = this.TokenVerify.Token,
                SYS_ID = Common.GetSysId(),
                AR_DATA = arList.Select(x => new ArData
                {
                    MIN_AR_ID = x.AR_ID,
                    CNTRT_NO = x.AR_PK.Substring(0, x.AR_PK.IndexOf("_")),
                    PAY_AMT = int.Parse(x.AR_AMT)
                }).ToList()
            };

            AppFormPayService appFormPayService = new AppFormPayService();
            BaseResult<MergeBarcodeOutput> result = await appFormPayService.GetMergeBarCode(model);

            return result;
        }
    }
}