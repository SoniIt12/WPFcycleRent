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
    public partial class Book_S1 : UserControl
    {
        Brush colTheme;
        public Book_S1()
        {
            InitializeComponent();
            Loaded += Book_S1_Loaded;
        }

        private void Book_S1_Loaded(object sender, RoutedEventArgs e)
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
            Button b = (Button)sender;
            if(b.Name == "BtnBookS101")
            {
                NavigationCommands.GoToPage.Execute("/Content/Book_S2.xaml", this);
            }
            else if (b.Name == "BtnBookS102")
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
                    NavigationCommands.GoToPage.Execute("/Content/Book_S5.xaml", this);
                }
            }
        }
    }
}
