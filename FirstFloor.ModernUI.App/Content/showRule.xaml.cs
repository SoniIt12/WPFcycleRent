using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class showRule : UserControl
    {
        int ruleIndex = 0;
        DataTable RuleTable;
        public showRule()
        {
            InitializeComponent();
            Loaded += showRule_Loaded;
        }

        public showRule(DataTable table)
        {
            InitializeComponent();
            Loaded += showRule_Loaded;
            RuleTable = table;
        }

        private void showRule_Loaded(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            string colH = AppearanceManager.Current.AccentColor.ToString();
            Brush colTheme = (Brush)converter.ConvertFromString(colH);
            btnNext.Background = colTheme;
            btnNext.Foreground = Brushes.White;
            header.Foreground = colTheme;
            body.Foreground = colTheme;

            RuleDisplay();
        }

        private void RuleDisplay()
        {
            try
            {
                if (RuleTable.Rows.Count >= ruleIndex)
                {
                    
                    header.Text = RuleTable.Rows[ruleIndex]["header"].ToString();
                    body.Text = RuleTable.Rows[ruleIndex]["body"].ToString();
                    ruleIndex++;
                }
                else
                {
                    NavigationCommands.GoToPage.Execute("/Content/Book_S4.xaml", this);
                    //Finish
                }
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RuleDisplay();
        }
    }
}
