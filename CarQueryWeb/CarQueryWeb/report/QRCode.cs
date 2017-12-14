using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThoughtWorks.QRCode.Codec;

namespace CarQueryWeb.report
{
    /// <summary>
    /// 生成二维码
    /// </summary>
    public static class QRCode
    {
        public static string CreateCode(string strData,string filepath)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 2;
            qrCodeEncoder.QRCodeVersion = 8;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

            string filename = strData + ".jpg";
            //string filename = strData + ".jpg";
            filepath += "/Image/TDCode/";
            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }
            filepath += filename;
            if (!System.IO.File.Exists(filepath))
            {
                System.Drawing.Image image = qrCodeEncoder.Encode(strData);
                System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();
                image.Dispose();
            }
            
            return "~/Image/TDCode/" + filename;
        }
    }
}