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
    public partial class Book_S3 : UserControl
    {
        Brush colWhite, colTheme;
        public Book_S3()
        {
            InitializeComponent();
            Loaded += Book_S3_Loaded;
        }

        private void Book_S3_Loaded(object sender, RoutedEventArgs e)
        {
            Thickness th = new Thickness();
            th.Bottom = 30;
            th.Top = App.Current.MainWindow.ActualHeight / 250;
            HeaderBookS3.Margin = th;
            string colH = AppearanceManager.Current.AccentColor.ToString();
            var converter = new System.Windows.Media.BrushConverter();
            colTheme = (Brush)converter.ConvertFromString(colH);
            colWhite = (Brush)converter.ConvertFromString(Colors.White.ToString());

            btnNext.Background = colTheme;
            btnNext.Foreground = colWhite;




            RowDefinition newRow;
            TextBlock tbProductDesc, tbProductPrice;
            Image tbImage;
            BitmapImage bitmapImage;
            Thickness th1 = new Thickness(5);
            //gvItems.DataContext=
            //Grid gvItems = new Grid();
            //gvItems.Width = 800;
            Random r = new Random();
            //spItems.Children.Clear();
            //spItems.Children.Add(gvItems);

            StackPanel pnlGrid = new StackPanel();
            pnlGrid.Orientation = Orientation.Vertical;
            pnlGrid.MinWidth = 600;

            #region gridAdd
            //for (int rowIndex = 0; rowIndex < 2; rowIndex++)
            //{
            //    //add a new row to the grid
            //    newRow = new RowDefinition();
            //    newRow.Height = new GridLength(0, GridUnitType.Auto);
            //    gvItems.RowDefinitions.Add(newRow);

            //    //initialize textblock controls and populate them with product attributes

            //    bitmapImage = new BitmapImage();
            //    bitmapImage.BeginInit();
            //    bitmapImage.UriSource = new Uri("https://pinion.eu/wp-content/uploads/2018/07/pinion-trekking-urban.jpg");
            //    bitmapImage.EndInit();
            //    tbImage = new Image();
            //    tbImage.Source = bitmapImage;
            //    tbImage.Height = 150;
            //    tbImage.Stretch = Stretch.Uniform;
            //    tbImage.Margin = th1;

            //    tbProductDesc = new TextBlock();
            //    tbProductDesc.Text = "Item Detauils " + r.Next(100);
            //    tbProductDesc.FontSize = 15;
            //    tbProductDesc.Margin = th1;

            //    tbProductPrice = new TextBlock();
            //    tbProductPrice.Text = r.Next(100).ToString();
            //    tbProductDesc.FontSize = 15;
            //    //tbProductDesc.FontWeight = 
            //    tbProductPrice.Margin = th1;

            //    //set the row and column positions for all the 3 controls
            //    Grid.SetRow(tbImage, rowIndex);
            //    Grid.SetColumn(tbImage, 0);

            //    Grid.SetRow(tbProductDesc, rowIndex);
            //    Grid.SetColumn(tbProductDesc, 1);

            //    Grid.SetRow(tbProductPrice, rowIndex);
            //    Grid.SetColumn(tbProductPrice, 2);

            //    //add the controls to the grid controls colelction
            //    gvItems.Children.Add(tbImage);
            //    gvItems.Children.Add(tbProductDesc);
            //    gvItems.Children.Add(tbProductPrice);
            //}
            #endregion

            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri("https://pinion.eu/wp-content/uploads/2018/07/pinion-trekking-urban.jpg");
                bitmapImage.EndInit();
                tbImage = new Image();
                tbImage.Source = bitmapImage;
                tbImage.Height = 150;
                tbImage.Stretch = Stretch.Uniform;
                tbImage.Margin = th1;

                tbProductDesc = new TextBlock();
                tbProductDesc.Text = "Item Detauils " + r.Next(100);
                tbProductDesc.FontSize = 15;
                tbProductDesc.Width = 300;
                tbProductDesc.TextWrapping = TextWrapping.Wrap;
                tbProductDesc.Margin = th1;

                tbProductPrice = new TextBlock();
                tbProductPrice.Text = r.Next(100).ToString();
                tbProductPrice.FontSize = 30;
                tbProductPrice.Width = 50;
                //tbProductPrice.FontWeight =
                tbProductPrice.Margin = th1;

                StackPanel rowStack = new StackPanel();
                rowStack.Orientation = Orientation.Horizontal;
                rowStack.MinWidth = 600;
                rowStack.Name = "StackRow" + rowIndex;
                rowStack.MouseDown += RowStack_MouseDown;

                //add the controls to the grid controls colelction
                rowStack.Children.Add(tbImage);
                rowStack.Children.Add(tbProductDesc);
                rowStack.Children.Add(tbProductPrice);

                pnlGrid.Children.Add(rowStack);
            }
            spItems.Children.Clear();
            spItems.Children.Add(pnlGrid);
        }

        private void RowStack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel rowStack = (StackPanel)sender;
            if(rowStack.Background != colTheme)
            rowStack.Background = colTheme;
            else
                rowStack.Background = Brushes.Transparent;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NavigationCommands.GoToPage.Execute("/Content/Book_S4.xaml", this);
        }
    }
}
