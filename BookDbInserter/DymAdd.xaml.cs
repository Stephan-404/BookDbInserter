using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace BookDbInserter
{
    /// <summary>
    /// Interaction logic for DymAdd.xaml
    /// </summary>
    /// //TODO is des legit <T>-> changed original calss, not partial
    public partial class DymAdd: Window
    {

        public List<object> elements
        {
            get;
            set;
        }
        public DymAdd()
        {
            InitializeComponent();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillView(elements.Select(s => (string)s).ToList());
        }

        private void FillView(List<string> elements)
        {

            for (int i=0;i<elements.Count();i++)
            {
                Main_DymWindow.RowDefinitions.Add(new RowDefinition());
            }
            Main_DymWindow.ColumnDefinitions.Add(new ColumnDefinition());
            Main_DymWindow.ColumnDefinitions.Add(new ColumnDefinition());


            Label lb = new Label();
            lb.Background = Brushes.Black;
            Main_DymWindow.Children.Add(lb);
            Grid.SetRow(lb, 1);
        }
    }
}
