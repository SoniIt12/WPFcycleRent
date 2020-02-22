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

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for OrderPrint.xaml
    /// </summary>
    public partial class OrderPrint : UserControl
    {
        Brush colWhite, colTheme;
        public OrderPrint()
        {
            InitializeComponent();
            Loaded += OrderPrint_Loaded;
        }

        private void OrderPrint_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness th = new Thickness();
            th.Bottom = 30;
            th.Top = 30; // App.Current.MainWindow.ActualHeight / 10;
            Header.Margin = th;
            string colH = AppearanceManager.Current.AccentColor.ToString();
            var converter = new System.Windows.Media.BrushConverter();
            colTheme = (Brush)converter.ConvertFromString(colH);
            colWhite = (Brush)converter.ConvertFromString(Colors.White.ToString());

            //btnNext.Background = colTheme;
            //btnNext.Foreground = colWhite;
            //odrID.Foreground = colTheme;
            //odrDate.Foreground = colTheme;
            //cName.Foreground = colTheme;
            //oItems.Foreground = colTheme;
            //rentalDay.Foreground = colTheme;
            //odrPick.Foreground = colTheme;
            //odrDrop.Foreground = colTheme;
            //oStatus.Foreground = colTheme;

            StackPanel pnlGrid = new StackPanel();
            pnlGrid.Orientation = Orientation.Vertical;
            pnlGrid.MinWidth = 500;



            for (int rowIndex = 1; rowIndex < 5; rowIndex++)
            {
                pnlGrid.Children.Add(formItemTable(rowIndex.ToString(), "Item Name", "10"));
            }
            //odrItems.Children.Clear();
            //odrItems.Children.Add(pnlGrid);

        }

        private StackPanel formItemTable(string number, string itmName, string amount)
        {
            Thickness th1 = new Thickness(7);

            TextBlock tbProductDesc = new TextBlock();
            tbProductDesc.Text = "Item " + number;
            tbProductDesc.FontSize = 20;
            tbProductDesc.Width = 100;
            tbProductDesc.Foreground = colTheme;
            tbProductDesc.Margin = th1;

            TextBlock tbBtn = new TextBlock();
            tbBtn.Text = itmName;
            tbBtn.FontSize = 20;
            tbBtn.Width = 300;
            tbBtn.Foreground = colTheme;
            tbBtn.TextWrapping = TextWrapping.Wrap;
            tbBtn.FontWeight = FontWeights.Bold;
            tbBtn.Margin = th1;

            TextBlock tbProductprice = new TextBlock();
            tbProductprice.Text = "EUR " + amount;
            tbProductprice.FontSize = 20;
            tbProductprice.Width = 200;
            tbProductprice.Foreground = colTheme;
            tbProductprice.Margin = th1;

            StackPanel rowStack = new StackPanel();
            rowStack.Orientation = Orientation.Horizontal;
            rowStack.MinWidth = 600;

            rowStack.Children.Add(tbProductDesc);
            rowStack.Children.Add(tbBtn);
            rowStack.Children.Add(tbProductprice);
            return rowStack;
        }

        private void RowStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel rowStack = (StackPanel)sender;
            if (rowStack.Background != Brushes.GreenYellow)
                rowStack.Background = Brushes.GreenYellow;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                try
                {
                    StackPanel rowStack = (StackPanel)FindName("StackRow" + rowIndex);
                    if (rowStack.Background != Brushes.GreenYellow)
                    {
                        rowStack.Background = Brushes.IndianRed;
                    }
                }
                catch { }
            }
        }
    }
}
