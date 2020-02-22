using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
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
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Threading;
using System.IO;
using FirstFloor.ModernUI.App.Content.HttpApiCall;
using Newtonsoft.Json;
using FirstFloor.ModernUI.App.Content.DTO;
using FirstFloor.ModernUI.App.Pages;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for LoremIpsum.xaml
    /// </summary>
    public partial class SearchOrder : UserControl
    {
        FilterInfoCollection filterInfoCollection;//device
        VideoCaptureDevice videoCaptureDevice;//current
        private System.Drawing.Bitmap picCamera;
        String NavigateFrom = "";
        bool searchBtnCheck = false;
        ComboBox cboCamera;
        DispatcherTimer timer = new DispatcherTimer();
        public SearchOrder()
        {
            InitializeComponent();
            if (!searchBtnCheck)
            {
                Loaded += SearchOrder_Loaded;
            }
        }
        ~SearchOrder()
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.SignalToStop();

            //var w = Application.Current.Windows[0];
            //w.Hide();
        }

        private void SearchOrder_Loaded(object sender, RoutedEventArgs e)
        {
            if (!searchBtnCheck)
            {
                cboCamera = new ComboBox();
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo Device in filterInfoCollection)
                    cboCamera.Items.Add(Device.Name);
                cboCamera.SelectedIndex = 0;
                // videoCaptureDevice = new VideoCaptureDevice();


                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
                videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                videoCaptureDevice.Start();

                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();

                var converter = new System.Windows.Media.BrushConverter();
                string colH = AppearanceManager.Current.AccentColor.ToString();
                Brush colTheme = (Brush)converter.ConvertFromString(colH);
                btnSearch.Background = colTheme;
                btnSearch.Foreground = Brushes.White;
                textorder.Foreground = colTheme;
                textorder.TextAlignment = TextAlignment.Center;
                textorder.Focus();
                // Search();
            }
        }


        //c# webcam capture picture
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                if (!searchBtnCheck)
                {
                    //if (picCamera == null)
                    // {
                    picCamera = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
                    //  }
                    //else
                    //{
                    //    ImageSourceConverter c = new ImageSourceConverter();
                    //    this.img1.Source = (ImageSource)c.ConvertFrom(picCamera);
                    //}
                    this.Dispatcher.Invoke(new Action(() => { ShowFrame(picCamera); }));
                    //Invoke(new Action<System.Drawing.Bitmap>(ShowFrame), eventArgs.Frame.Clone());
                }


            }
            catch (ObjectDisposedException)
            {
                // not sure, why....
            }

            //  System.Drawing.Bitmap picCamera  = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
        }

        private void ShowFrame(System.Drawing.Bitmap frame)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)frame).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            // ImageSourceConverter c = new ImageSourceConverter();
            this.img1.Source = image;

        }
        private void Search()
        {
            // create a barcode reader instance
            IBarcodeReader reader = new BarcodeReader();
            // load a bitmap
            // var barcodeBitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile("D:\\chart.png");
            var barcodeBitmap = (System.Drawing.Bitmap)picCamera;
            // detect and decode the barcode inside the bitmap
            var result = reader.Decode(barcodeBitmap);
            // do something with the result
            if (result != null)
            {
                //txtDecoderType.Text = result.BarcodeFormat.ToString();
                //txtDecoderContent.Text = result.Text;

                string ttt = result.BarcodeFormat.ToString();
                string rr = result.Text;
                // {"orderID": "12345"}
                // Json decode
                // Find object value
                // if(object val != "")
                timer.Stop();
                if (videoCaptureDevice.IsRunning == true)
                    videoCaptureDevice.SignalToStop();

                NavigationCommands.GoToPage.Execute("/Content/OrderView.xaml?id=1", this);
            }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            if (picCamera != null)
                Search();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //String type = App.Current.Properties["OrderType"].ToString();
            App.Current.Properties["OrderNo"] = textorder.Text.Trim();
            string URL = "http://testapi.s3d.space/index.php?option=com_api&app=vikrentitems&resource=orders&format=raw";
            string postdata = string.Empty;
            string orderno = textorder.Text.Trim();
            string date = string.Empty;
            if (orderno != null)
            {
                postdata = "orderid=" + orderno;
                string response = HttpReqquest.webApiRequest(postdata, URL);
                response = response.Replace(@"\", @"");
                response = (response.Trim(new Char[] { '"' }));
                searchBtnCheck = true;
                timer.Stop();
                if (videoCaptureDevice.IsRunning == true)
                    // videoCaptureDevice.Stop();
                    videoCaptureDevice.SignalToStop();

                NavigationCommands.GoToPage.Execute("/Content/OrderView.xaml#" + response, this);
            }
            //if (type != "Return")
            //{
               
            //}
            //else
            //{
            //    string URL = "http://testapi.s3d.space/index.php?option=com_api&app=vikrentitems&resource=orders&format=raw";
            //    string postdata = string.Empty;
            //    string orderno = textorder.Text.Trim();
            //    string date = string.Empty;
            //    if (orderno != null)
            //    {
            //        postdata = "orderid=" + orderno;
            //        string response = HttpReqquest.webApiRequest(postdata, URL);
            //        response = response.Replace(@"\", @"");
            //        response = (response.Trim(new Char[] { '"' }));
            //        searchBtnCheck = true;
            //        timer.Stop();
            //        if (videoCaptureDevice.IsRunning == true)
            //            // videoCaptureDevice.Stop();
            //            videoCaptureDevice.SignalToStop();

            //        NavigationCommands.GoToPage.Execute("/Content/OrderView.xaml#" + response, this);
            //    }
            //}
            

        }




        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
        }

    }
}
