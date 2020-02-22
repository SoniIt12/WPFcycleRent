using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.App.Content.HttpApiCall
{
    public static class HttpReqquest
    {


        public static string webApiRequest(string postData, string URL)
        {
            string Result = "";
            try
            {
                // string URL = "http://testapi.s3d.space/index.php?option=com_api&app=vikrentitems&resource=orders&format=raw";
                System.Net.WebRequest webRequest = System.Net.WebRequest.Create(URL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Headers.Add("Authorization", "Bearer 4736cd7a5661e211ee3ba4b4be5441f3");
                Stream reqStream = webRequest.GetRequestStream();
                // string postData = "orderid=2&changestatus=0&newstatus=v";
                byte[] postArray = Encoding.ASCII.GetBytes(postData);
                reqStream.Write(postArray, 0, postArray.Length);
                reqStream.Close();
                StreamReader sr = new StreamReader(webRequest.GetResponse().GetResponseStream());
                Result  = sr.ReadToEnd();
                

            }
            catch(Exception ex)
            {
                Result = ex.InnerException.Message.ToString();
            }
            return Result = JsonConvert.SerializeObject(Result);

        }
    }
}
