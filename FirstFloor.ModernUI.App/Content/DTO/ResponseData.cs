using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.App.Content.DTO
{
  
    public class Data
    {
        public string id { get; set; }
        public string nominative { get; set; }
        public string phone { get; set; }
        public string custmail { get; set; }
        public string custdata { get; set; }
        public string ts { get; set; }
        public string ritiro { get; set; }
        public string consegna { get; set; }
        public string status { get; set; }
        public string order_total { get; set; }
        public string sid { get; set; }
        public string idplace { get; set; }
        public string adminnotes { get; set; }
        public object country { get; set; }
        public string lang { get; set; }
        public string days { get; set; }
        public string hourly { get; set; }
        public string idreturnplace { get; set; }
        public string totpaid { get; set; }
        public string idpayment { get; set; }
        public string ujid { get; set; }
        public string coupon { get; set; }
        public object locationvat { get; set; }
        public string deliverycost { get; set; }
        public string paymentlog { get; set; }
        public List<string> items { get; set; }
    }

    public class ResponseData
    {
        public string err_msg { get; set; }
        public string err_code { get; set; }
        public string response_id { get; set; }
        public string api { get; set; }
        public string version { get; set; }
        public Data data { get; set; }
    }
}
