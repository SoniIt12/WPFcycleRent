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

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for ControlsStylesButton.xaml
    /// </summary>
    public partial class Book_S2 : UserControl
    {
        Brush colWhite, colTheme;
        public Book_S2()
        {
            InitializeComponent();
            Loaded += Book_S2_Loaded;
        }

        private void Book_S2_Loaded(object sender, RoutedEventArgs e)
        {
            Btype1.IsChecked = Btype2.IsChecked = Bsize1.IsChecked = Bsize2.IsChecked = Bsize3.IsChecked = false;
            Thickness th = new Thickness();
            th.Bottom = 30;
            th.Top = App.Current.MainWindow.ActualHeight / 12;
            HeaderBookS2.Margin = th;
            Calender1.SelectedDate = DateTime.Today;

            var converter = new System.Windows.Media.BrushConverter();
            string colH = AppearanceManager.Current.AccentColor.ToString();
            colTheme = (Brush)converter.ConvertFromString(colH);
            colWhite = (Brush)converter.ConvertFromString(Colors.White.ToString());

            btnNext.Background = colTheme;
            btnNext.Foreground = colWhite;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            DateTime? date = Calender1.SelectedDate;
            int Btype, Bsize;
            if (!(bool)Btype1.IsChecked && !(bool)Btype2.IsChecked)
            {
                spType.Background = Brushes.IndianRed;
                return;
            }
            if (!(bool)Bsize1.IsChecked && !(bool)Bsize2.IsChecked && !(bool)Bsize3.IsChecked)
            {
                spSize.Background = Brushes.IndianRed;
                return;
            }

            if ((bool)Btype1.IsChecked)
                Btype = 1;
            else if ((bool)Btype2.IsChecked)
                Btype = 2;

            if ((bool)Bsize1.IsChecked)
                Bsize = 1;
            else if ((bool)Bsize2.IsChecked)
                Bsize = 2;
            else if ((bool)Bsize3.IsChecked)
                Bsize = 3;

            spType.Background = Brushes.Transparent;
            spSize.Background = Brushes.Transparent;
            NavigationCommands.GoToPage.Execute("/Content/Book_S3.xaml", this);

        }
    }
}
