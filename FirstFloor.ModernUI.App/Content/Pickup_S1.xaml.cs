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

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for ControlsStylesButton.xaml
    /// </summary>
    public partial class Pickup_S1 : UserControl
    {
        Brush colTheme;
        public Pickup_S1()
        {
            InitializeComponent();
            Loaded += Pickup_S1_Loaded;
        }

        private void Pickup_S1_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness th = new Thickness();
            th.Bottom = 30;
            th.Top = App.Current.MainWindow.ActualHeight / 5;
            HeaderBookS1.Margin = th;

            var converter = new System.Windows.Media.BrushConverter();
            string colH = AppearanceManager.Current.AccentColor.ToString();
            colTheme = (Brush)converter.ConvertFromString(colH);
            BtnBookS101.Foreground = BtnBookS102.Foreground = colTheme;
        }

        private void BtnBookS1_Click(object sender, RoutedEventArgs e)
        {           
            //NavigationCommands.GoToPage.Execute("/Content/SearchOrder.xaml", this);
            Button b = (Button)sender;
            if (b.Name == "BtnBookS101")
            {
                App.Current.Properties["OrderType"] = "PickUp";
                //NavigationCommands.GoToPage.Execute("/Content/Book_S2.xaml", this);

            }
            else if (b.Name == "BtnBookS102")
            {
                App.Current.Properties["OrderType"] = "Return";
                
            }
            NavigationCommands.GoToPage.Execute("/Content/SearchOrder.xaml", this);

        }
    }
}
