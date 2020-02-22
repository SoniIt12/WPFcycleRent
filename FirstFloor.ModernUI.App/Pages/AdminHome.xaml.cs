using FirstFloor.ModernUI.App.Content;
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

namespace FirstFloor.ModernUI.App.Pages
{
    /// <summary>
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : UserControl
    {
        Brush colTheme;
        public AdminHome()
        {
            InitializeComponent();
            Loaded += AdminHome_Loaded; 
        }

        private void AdminHome_Loaded(object sender, RoutedEventArgs e)
        {
            AdminPanel.Visibility = Visibility.Hidden;
            string colH = AppearanceManager.Current.AccentColor.ToString();
            var converter = new System.Windows.Media.BrushConverter();
            colTheme = (Brush)converter.ConvertFromString(colH);

            AdminBtn.Background = colTheme;
            AdminBtn.Foreground = Brushes.White;
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            var access = new AdminAccess();
            var dlg = new ModernDialog
            {
                Title = "Admin Access",
                Content = access
            };
            dlg.Buttons = new Button[] { dlg.CancelButton };
            dlg.ShowDialog();
            //this.dialogResult.Text = dlg.DialogResult.HasValue ? dlg.DialogResult.ToString() : "<null>";
            bool adminVerified = access.Access;
            if (adminVerified)
            {
                AdminPanel.Visibility = Visibility.Visible;
                SPAdminBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                NavigationCommands.GoToPage.Execute("/Pages/Home.xaml", this);
            }
        }
    }
}
