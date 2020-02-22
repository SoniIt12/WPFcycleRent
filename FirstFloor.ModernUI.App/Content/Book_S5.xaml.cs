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
    public partial class Book_S5 : UserControl
    {
        Brush colTheme;
        public Book_S5()
        {
            InitializeComponent();
            Loaded += Book_S5_Loaded;
        }

        private void Book_S5_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness th = new Thickness();
            th.Bottom = 30;
            th.Top = App.Current.MainWindow.ActualHeight / 10;
            HeaderBookS1.Margin = th;

            //var converter = new System.Windows.Media.BrushConverter();
            //string colH = AppearanceManager.Current.AccentColor.ToString();
            //colTheme = (Brush)converter.ConvertFromString(colH);

            OrderView.Children.Clear();
            OrderView.Children.Add(new SearchOrder());
        }
    }
}
