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

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for LoremIpsum.xaml
    /// </summary>
    public partial class AdminAccess : UserControl
    {
        public bool Access = false;
        public AdminAccess()
        {
            InitializeComponent();
            Loaded += AdminAccess_Loaded;
        }

        private void AdminAccess_Loaded(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            string colH = AppearanceManager.Current.AccentColor.ToString();
            Brush colTheme = (Brush)converter.ConvertFromString(colH);
            btnLogin.Background = colTheme;
            btnLogin.Foreground = Brushes.White;
            textPass.Foreground = colTheme;
            textPass.HorizontalContentAlignment = HorizontalAlignment.Center;
            textPass.Focus();
        }

        private void login()
        {
            if (textPass.Password == "1234")
            {
                Access = true;
                Window.GetWindow(this).Close();
            }
            else
            {
                textPass.BorderBrush = Brushes.Red;
                textPass.Background = Brushes.Red;
                textPass.Password = "";
                textPass.Focus();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void textPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (textPass.Password.Length == 10)
                login();
        }
    }
}
