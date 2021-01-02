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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookDbUserControlsLib
{
    /// <summary>
    /// Interaction logic for ShowNumberColoure.xaml
    /// </summary>
    public partial class ShowNumberColoure : UserControl
    {
        public string NameSpace
        {
            get { return lb_Text.Content.ToString(); }
            set { lb_Text.Content = value; }
        }
        public int Count {
            get { return Convert.ToInt32(lb_Number.Content); }
            set { lb_Number.Content = value; setColour(); }
        }
        double maxValue;
        public double maximum {
            get { return maxValue; }
            set { maxValue = value; } 
        }
        public ShowNumberColoure()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            setColour();
        }

        private void setColour()
        {
            if (1*(maxValue/3)>Count)
            {
                lb_Text.Background = Brushes.Green;
            }
            else if(2*(maxValue / 3) < Count)
            {
                lb_Text.Background = Brushes.Red;
            }
            else
            {
                lb_Text.Background = Brushes.Orange;
            }
            
        }
    }
}
