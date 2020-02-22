using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Presentation;
using System.Data;
using FirstFloor.ModernUI.App.Content.HttpApiCall;
using FirstFloor.ModernUI.App.Content.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for ControlsStylesButton.xaml
    /// </summary>
    public partial class HostRule : UserControl
    {
        //Brush colTheme;
        public HostRule()
        {
            InitializeComponent();
            Loaded += HostRule_Loaded;
        }

        private void HostRule_Loaded(object sender, RoutedEventArgs e)
        {
            //var converter = new System.Windows.Media.BrushConverter();
            //string colH = AppearanceManager.Current.AccentColor.ToString();
            //colTheme = (Brush)converter.ConvertFromString(colH);
            string URL = "http://testapi.s3d.space/index.php?option=com_api&app=vikrentitems&resource=getdata&format=raw";
            string postdata = string.Empty;

            postdata = "getdata=regulations";
            dynamic response = HttpReqquest.webApiRequest(postdata, URL);
            response = response.Replace(@"\", @"");
            response = (response.Trim(new Char[] { '"' }));
            var resData = JsonConvert.DeserializeObject (response);
            resData = resData["data"];
            var dataRowcount = resData.Count;

            String type = App.Current.Properties["OrderType"].ToString();
            DataTable tmpTbl = new DataTable();
            tmpTbl.Columns.Add("header", typeof(string));
            tmpTbl.Columns.Add("body", typeof(string));
            string typeName = "PKR";
            //if (type == "Return")
            //{
            //    typeName = "RTR";
            //}
            //else
            //{
            //    typeName = "PKR";
            //}
            for (int rowCOunt = 0 ; rowCOunt < dataRowcount; rowCOunt++){
                if (resData[rowCOunt]["typename"] == typeName && resData[rowCOunt]["enable"] == "1")
                {
                    DataRow dr = tmpTbl.NewRow();
                    dr["header"] = "Rule "+ (rowCOunt+1);
                    dr["body"] = resData[rowCOunt]["details"];
                    tmpTbl.Rows.Add(dr);
                }
            }
            RuleView.Children.Clear();
            RuleView.Children.Add(new showRule(tmpTbl));
        }
    }
}
