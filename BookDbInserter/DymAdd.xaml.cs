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

        public List<string> elements
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
            //FillView(elements.Select(s => (string)s).ToList());
            FillView(elements);
            Height = (elements.Count*40)+40;
            Width = 250;
        }

        private void FillView(List<string> elements)
        {

            for (int i=0;i<elements.Count();i++)
            {
                Main_DymWindow.RowDefinitions.Add(new RowDefinition());
            }
            Main_DymWindow.RowDefinitions.Add(new RowDefinition());
            Main_DymWindow.ColumnDefinitions.Add(new ColumnDefinition());
            Main_DymWindow.ColumnDefinitions.Add(new ColumnDefinition());

            for (int j=0;j<elements.Count() ;j++)
            {
                Label lb = new Label();
                lb.Content=elements[j];
                Main_DymWindow.Children.Add(lb);
                Grid.SetRow(lb, j);

                TextBox tb = new TextBox();
                tb.Name = "tb_"+elements[j];
                Main_DymWindow.Children.Add(tb);
                Grid.SetRow(tb,j);
                Grid.SetColumn(tb,1);
            }

            Button bt_Add = new Button();
            bt_Add.Click += AddBT;
            bt_Add.Content = "ADD";
            Main_DymWindow.Children.Add(bt_Add);
            Grid.SetRow(bt_Add,elements.Count+1);
            Grid.SetColumn(bt_Add,1); 
        }

        void AddBT(object sender, RoutedEventArgs e)
        {
           var children=Main_DymWindow.Children;
            for (int i=0; i<elements.Count()*2;i++)
            {
                if (children[i] is TextBox )
                {
                    TextBox lb = children[i] as TextBox;
                    var test=lb.Name;
                }
            }
        }
    }
}
