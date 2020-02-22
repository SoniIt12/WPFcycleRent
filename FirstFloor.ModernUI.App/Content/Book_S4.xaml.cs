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
using FontAwesome.WPF;
using FirstFloor.ModernUI.App.Content.HttpApiCall;
using Newtonsoft.Json;

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for ControlsStylesButton.xaml
    /// </summary>
    public partial class Book_S4 : UserControl
    {
        Brush colWhite, colTheme;
        public Book_S4()
        {
            InitializeComponent();
            Loaded += Book_S4_Loaded;
        }

        private void Book_S4_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness th = new Thickness();
            th.Bottom = 30;
            th.Top = 30; // App.Current.MainWindow.ActualHeight / 10;
            HeaderBookS3.Margin = th;
            string colH = AppearanceManager.Current.AccentColor.ToString();
            var converter = new System.Windows.Media.BrushConverter();
            colTheme = (Brush)converter.ConvertFromString(colH);
            colWhite = (Brush)converter.ConvertFromString(Colors.White.ToString());

            btnNext.Background = colTheme;
            btnNext.Foreground = colWhite;


            Thickness th1 = new Thickness(7);
            StackPanel pnlGrid = new StackPanel();
            pnlGrid.Orientation = Orientation.Vertical;
            pnlGrid.MinWidth = 600;

            string URL = "http://testapi.s3d.space/index.php?option=com_api&app=vikrentitems&resource=getdata&format=raw";
            string postdata = string.Empty;
            postdata = "getdata=regulations";
            dynamic response = HttpReqquest.webApiRequest(postdata, URL);
            response = response.Replace(@"\", @"");
            response = (response.Trim(new Char[] { '"' }));
            var resData = JsonConvert.DeserializeObject(response);
            resData = resData["data"];
            var dataRowcount = resData.Count;
            String type = App.Current.Properties["OrderType"].ToString();
            string typeName = "PKA";
            //if (type == "Return")
            //{
            //    typeName = "RTA";
            //}
            //else
            //{
            //    typeName = "PKA";
            //}
            for (int rowIndex = 0; rowIndex < dataRowcount; rowIndex++)
            {
                if (resData[rowIndex]["typename"] == typeName && resData[rowIndex]["enable"] == "1")
                {
                    Image tbImage = new Image();
                    tbImage.Source = ImageAwesome.CreateImageSource(FontAwesomeIcon.ArrowCircleRight, colTheme);
                    tbImage.Height = 15;
                    tbImage.Stretch = Stretch.Uniform;
                    Thickness th2 = new Thickness(40, 5, 5, 5);
                    tbImage.Margin = th2;

                    TextBlock tbProductDesc = new TextBlock();
                    tbProductDesc.Text = resData[rowIndex]["details"];
                    tbProductDesc.FontSize = 25;
                    tbProductDesc.Width = 300;
                    tbProductDesc.TextWrapping = TextWrapping.Wrap;
                    tbProductDesc.Margin = th1;

                    TextBlock tbBtn = new TextBlock();
                    tbBtn.Text = "Yes I understand";
                    tbBtn.FontSize = 25;
                    tbBtn.Width = 200;
                    tbBtn.Foreground = colTheme;
                    tbBtn.TextDecorations = TextDecorations.Underline;
                    tbBtn.FontWeight = FontWeights.Bold;
                    tbBtn.Margin = th1;

                    StackPanel rowStack = new StackPanel();
                    rowStack.Orientation = Orientation.Horizontal;
                    rowStack.MinWidth = 600;
                    try { UnregisterName("StackRow" + rowIndex); } catch { }
                    rowStack.Name = "StackRow" + rowIndex;
                    RegisterName(rowStack.Name, rowStack);
                    rowStack.MouseDown += RowStack_MouseDown;

                    //add the controls to the grid controls colelction
                    rowStack.Children.Add(tbImage);
                    rowStack.Children.Add(tbProductDesc);
                    rowStack.Children.Add(tbBtn);

                    pnlGrid.Children.Add(rowStack);
                }
            }
            spItems.Children.Clear();
            spItems.Children.Add(pnlGrid);
        }

        private void RowStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel rowStack = (StackPanel)sender;
            if(rowStack.Background != Brushes.GreenYellow)
                rowStack.Background = Brushes.GreenYellow;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            string URL = "http://testapi.s3d.space/index.php?option=com_api&app=vikrentitems&resource=orders&format=raw";
            string postdata = string.Empty;
            String type = App.Current.Properties["OrderType"].ToString();
            string orderno = App.Current.Properties["OrderNo"].ToString();
            string orderstatus = "";
            if (type == "Return")
                orderstatus = "Returned";
            else
                orderstatus = "Picked";
            if (orderno != null)
            {
                postdata = "orderid=" + orderno + "&orderstatus=" + orderstatus;
                string response = HttpReqquest.webApiRequest(postdata, URL);
                response = response.Replace(@"\", @"");
                response = (response.Trim(new Char[] { '"' }));
                NavigationCommands.GoToPage.Execute("/Content/OrderPrint.xaml#" + response, this);
            }
            //for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            //{
            //    try
            //    {
            //        StackPanel rowStack = (StackPanel)FindName("StackRow" + rowIndex);
            //        if (rowStack.Background != Brushes.GreenYellow)
            //        {
            //            rowStack.Background = Brushes.IndianRed;
            //        }
            //    }
            //    catch { }
            //}
        }
    }
}
