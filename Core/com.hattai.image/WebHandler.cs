using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace com.hattai.image
{
    public static class WebHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UrlImage"></param>
        /// <returns></returns>
        public static string GetStreamImageFromWebRequest(string UrlImage)
        {
            try
            {
                // create a web request to the url of the image
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(UrlImage);
                // set the method to GET to get the image
                myRequest.Method = "GET";
                // get the response from the webpage
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                // create a bitmap from the stream of the response
                Bitmap bmp = new Bitmap(myResponse.GetResponseStream());
                // close off the stream and the response
                myResponse.Close();
                /// Memory stream to get the packages
                MemoryStream imageStream = new MemoryStream();
                /// save the stream
                bmp.Save(imageStream, ImageFormat.Jpeg);
                /// data array in 64bits
                string data = Convert.ToBase64String(imageStream.ToArray());
                /// return to the data
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
