using System;
using System.Collections;
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
    /// Interaction logic for DropDownAdd.xaml
    /// </summary>
    public partial class DropDownAdd : UserControl
    {
        private int selectedPosition=0;
        public int selectedIndex
        {
            get { return selectedPosition; }
            set { ItemsComboBox.SelectedIndex = value; selectedPosition = value; }
        }



        private string test;
        public string Val {
            get { return test; }
            set 
            {
                test = value;
            } 
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          //  ItemsComboBox.Items.Add(Val);
        }

        public DropDownAdd()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(IEnumerable), typeof(DropDownAdd), new PropertyMetadata(null));

        public IEnumerable Source
        {
            get { return (IEnumerable)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // This is to send the occurred event, in this case button click, to the parent, along with the selected data.
        public class SelectedItemEventArgs : EventArgs
        {
            public string SelectedChoice { get; set; }
        }

        public event EventHandler<SelectedItemEventArgs> ItemHasBeenSelected;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = ItemsComboBox.SelectedValue;
            ItemHasBeenSelected?.Invoke(this, new SelectedItemEventArgs {});
        }

        private void ItemsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = sender as ComboBox;
            selectedIndex = c.SelectedIndex;
        }
    }
}
