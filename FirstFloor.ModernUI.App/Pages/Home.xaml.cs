using FirstFloor.ModernUI.Presentation;
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

namespace FirstFloor.ModernUI.App.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        Brush colWhite, colTheme;

        
        public Home()
        {
            InitializeComponent();
            Loaded += Home_Loaded;
        }

        private void Home_Loaded(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            string colH = AppearanceManager.Current.AccentColor.ToString();
            colTheme = (Brush)converter.ConvertFromString(colH);
            colWhite = (Brush)converter.ConvertFromString(Colors.White.ToString());
            BtnTxt1.Foreground = BtnIcn1.Foreground = colTheme;
            BtnTxt2.Foreground = BtnIcn2.Foreground = colTheme;
            BtnTxt3.Foreground = BtnIcn3.Foreground = colTheme;
            BtnTxt4.Foreground = BtnIcn4.Foreground = colTheme;
        }

        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name == "btn1Main")
                BtnTxt1.Foreground = BtnIcn1.Foreground = colTheme;
            else if (b.Name == "btn2Main")
                BtnTxt2.Foreground = BtnIcn2.Foreground = colTheme;
            else if (b.Name == "btn3Main")
                BtnTxt3.Foreground = BtnIcn3.Foreground = colTheme;
            else if (b.Name == "btn4Main")
                BtnTxt4.Foreground = BtnIcn4.Foreground = colTheme;
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name == "btn1Main")
                BtnTxt1.Foreground = BtnIcn1.Foreground = colWhite;
            else if (b.Name == "btn2Main")
                BtnTxt2.Foreground = BtnIcn2.Foreground = colWhite;
            else if (b.Name == "btn3Main")
                BtnTxt3.Foreground = BtnIcn3.Foreground = colWhite;
            else if (b.Name == "btn4Main")
                BtnTxt4.Foreground = BtnIcn4.Foreground = colWhite;
        }
    }
}
