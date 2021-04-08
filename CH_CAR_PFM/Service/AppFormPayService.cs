using CH_CAR_PFM.Models;
using CH_CAR_PFM.Models.AppFormPay;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Threading.Tasks;

namespace CH_CAR_PFM.Service
{
    /// <summary>
    /// 繳費相關服務
    /// </summary>
    public class AppFormPayService
    {
        /// <summary>
        /// 取得標的物資料(繳款紀錄)
        /// </summary>
        /// <param name="model">取得標的物資料(繳款紀錄) Input</param>
        /// <returns>取得標的物資料(繳款紀錄) Output</returns>
        public async Task<BaseListResult<GetArRecLvOutput>> GetArRecLv1(GetArRecLvInput model)
        {
            // 透過 Api 把資料送出去
            string apiUrl = "APP_FORM_PAY/GET_AR_REC_LV1";
            BaseListResult<GetArRecLvOutput> result = await ApiService.Instance.ApiGetArRecLv1(model, apiUrl);

            return result;
        }

        /// <summary>
        /// 取得往來明細清單(未繳/逾期)
        /// </summary>
        /// <param name="model">取得標的物資料(繳款紀錄) Input</param>
        /// <returns>取得往來明細清單(未繳/逾期) Output</returns>
        public async Task<BaseListResult<GetArRecLvNewOutput>> GetArLv1New(GetArRecLvInput model)
        {
            // 透過 Api 把資料送出去
            string apiUrl = "V2/APP_FORM_PAY/GET_AR_LV1_NEW";
            BaseListResult<GetArRecLvNewOutput> result = await ApiService.Instance.ApiGetArLv1New(model, apiUrl);

            return result;
        }

        /// <summary>
        /// 取得往來明細清單(未繳/逾期)
        /// </summary>
        /// <param name="model">取得標的物資料(繳款紀錄) Input</param>
        /// <returns>取得往來明細清單(未繳/逾期) Output</returns>
        public async Task<BaseResult<ValidArPayOutput>> ValidateArPay(ValidArPayInput model)
        {
            // 透過 Api 把資料送出去
            //string apiUrl = "APP_FORM_PAY/VALIDATE_AR_PAY";
            string apiUrl = "V2/APP_FORM_PAY/VALIDATE_AR_PAY_NEW";
            BaseResult<ValidArPayOutput> result = await ApiService.Instance.ApiValidateArPay(model, apiUrl);

            return result;
        }

        /// <summary>
        /// 取得 7-11 超商繳費 BarCode 圖片
        /// </summary>
        /// <param name="model">取得標的物資料(繳款紀錄) Input</param>
        /// <returns>取得往來明細清單(未繳/逾期) Output</returns>
        public async Task<BaseResult<Barcode711Output>> Get711BarCodeImg(Barcode711Input model)
        {
            // 透過 Api 把資料送出去
            string apiUrl = "APP_FORM_PAY/GET_711_BARCODE_IMG";
            BaseResult<Barcode711Output> result = await ApiService.Instance.ApiGet711BarCodeImg(model, apiUrl);

            return result;
        }

        /// <summary>
        /// 取得超商繳費 BarCode
        /// </summary>
        /// <param name="model">取得標的物資料(繳款紀錄) Input</param>
        /// <returns>取得往來明細清單(未繳/逾期) Output</returns>
        public async Task<BaseResult<MergeBarcodeOutput>> GetMergeBarCode(MergeBarcodeInput model)
        {
            // 透過 Api 把資料送出去
            string apiUrl = "APP_FORM_PAY/GET_MERGE_BARCODE";

            BaseResult<MergeBarcodeOutput> result = await ApiService.Instance.ApiGetMergeBarCode(model, apiUrl);

            if (result.Result.ReturnCode == 0 && result.Data != null)
            {
                result.Data.BarCodeImage1 = this.GetBarCodeImage(result.Data.BARCODE1);
                result.Data.BarCodeImage2 = this.GetBarCodeImage(result.Data.BARCODE2);
                result.Data.BarCodeImage3 = this.GetBarCodeImage(result.Data.BARCODE3);
            }

            return result;
        }

        /// <summary>
        /// 取得繳款紀錄(含已繳項目)
        /// </summary>
        /// <param name="model">取得標的物資料(繳款紀錄) Input</param>
        /// <returns>取得標的物資料(繳款紀錄) Output</returns>
        public async Task<BaseListResult<GetArRecOutput>> GetArRec(GetArRecInput model)
        {
            // 透過 Api 把資料送出去
            string apiUrl = "APP_FORM_PAY/GET_AR_REC";
            BaseListResult<GetArRecOutput> result = await ApiService.Instance.ApiGetArRec(model, apiUrl);

            return result;
        }

        /// <summary>
        /// Image To base64
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public string GetBarCodeImage(string barcode)
        {
            //將Code39條碼寫入記憶體流，並將其以 "image/Png" 格式輸出
            MemoryStream stream = new MemoryStream();
            try
            {
                Bitmap oBmp = this.GetCode39(barcode);

                oBmp.Save(stream, ImageFormat.Png);
                oBmp.Dispose();
            }
            finally
            {
                //釋放資源
                stream.Dispose();
            }

            byte[] imageBytes = stream.ToArray();

            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
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
        /// <param name="model">取得標的物資料(繳款紀錄) Input</param>
        /// <returns>銀行列表 Output</returns>
        public async Task<BaseListResult<GetBankOutput>> GetBank()
        {
            // 透過 Api 把資料送出去
            string apiUrl = "/api/AppBack/GetBank";
            BaseListResult<GetBankOutput> result = await ApiService.Instance.ApiGetBank(null, apiUrl);

            return result;
        }

        /// <summary>
        /// 取得保險列表
        /// </summary>
        /// <param name="model">取得標的物資料(繳款紀錄) Input</param>
        /// <returns>銀行列表 Output</returns>
        public async Task<BaseListResult<GetInsuranceOutput>> GetInsurance()
        {
            // 透過 Api 把資料送出去
            string apiUrl = "/api/AppBack/GetInsurance";
            BaseListResult<GetInsuranceOutput> result = await ApiService.Instance.ApiGetInsurance(null, apiUrl);

            return result;
        }

        private Bitmap GetCode39(string strSource)
        {
            int x = 5; //左邊界
            int y = 0; //上邊界
            int WidLength = 2; //粗BarCode長度
            int NarrowLength = 1; //細BarCode長度
            int BarCodeHeight = 70; //BarCode高度
            int intSourceLength = strSource.Length;
            string strEncode = "010010100"; //編碼字串 初值為 起始符號 *

            string AlphaBet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"; //Code39的字母

            string[] Code39 = //Code39的各字母對應碼
           {
                 /**//* 0 */ "000110100",
                 /**//* 1 */ "100100001",
                 /**//* 2 */ "001100001",
                 /**//* 3 */ "101100000",
                 /**//* 4 */ "000110001",
                 /**//* 5 */ "100110000",
                 /**//* 6 */ "001110000",
                 /**//* 7 */ "000100101",
                 /**//* 8 */ "100100100",
                 /**//* 9 */ "001100100",
                 /**//* A */ "100001001",
                 /**//* B */ "001001001",
                 /**//* C */ "101001000",
                 /**//* D */ "000011001",
                 /**//* E */ "100011000",
                 /**//* F */ "001011000",
                 /**//* G */ "000001101",
                 /**//* H */ "100001100",
                 /**//* I */ "001001100",
                 /**//* J */ "000011100",
                 /**//* K */ "100000011",
                 /**//* L */ "001000011",
                 /**//* M */ "101000010",
                 /**//* N */ "000010011",
                 /**//* O */ "100010010",
                 /**//* P */ "001010010",
                 /**//* Q */ "000000111",
                 /**//* R */ "100000110",
                 /**//* S */ "001000110",
                 /**//* T */ "000010110",
                 /**//* U */ "110000001",
                 /**//* V */ "011000001",
                 /**//* W */ "111000000",
                 /**//* X */ "010010001",
                 /**//* Y */ "110010000",
                 /**//* Z */ "011010000",
                 /**//* - */ "010000101",
                 /**//* . */ "110000100",
                 /**//*' '*/ "011000100",
                 /**//* $ */ "010101000",
                 /**//* / */ "010100010",
                 /**//* + */ "010001010",
                 /**//* % */ "000101010",
                 /**//* * */ "010010100"
            };
            strSource = strSource.ToUpper();
            //實作圖片
            Bitmap objBitmap = new Bitmap(
              ((WidLength * 3 + NarrowLength * 7) * (intSourceLength + 2)) + (x * 2),
              BarCodeHeight + (y * 2));
            Graphics objGraphics = Graphics.FromImage(objBitmap); //宣告GDI+繪圖介面
                                                                  //填上底色
            objGraphics.FillRectangle(Brushes.White, 0, 0, objBitmap.Width, objBitmap.Height);

            for (int i = 0; i < intSourceLength; i++)
            {
                //檢查是否有非法字元
                if (AlphaBet.IndexOf(strSource[i]) == -1 || strSource[i] == '*')
                {
                    objGraphics.DrawString("含有非法字元",
                      SystemFonts.DefaultFont, Brushes.Red, x, y);
                    return objBitmap;
                }
                //查表編碼
                strEncode = string.Format("{0}0{1}", strEncode,
                 Code39[AlphaBet.IndexOf(strSource[i])]);
            }

            strEncode = string.Format("{0}0010010100", strEncode); //補上結束符號 *

            int intEncodeLength = strEncode.Length; //編碼後長度
            int intBarWidth;

            for (int i = 0; i < intEncodeLength; i++) //依碼畫出Code39 BarCode
            {
                intBarWidth = strEncode[i] == '1' ? WidLength : NarrowLength;
                objGraphics.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White,
                 x, y, intBarWidth, BarCodeHeight);
                x += intBarWidth;
            }
            return objBitmap;
        }
    }
}