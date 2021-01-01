using BookDbLib;
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

namespace BookDbInserter
{
    /// <summary>
    /// Interaction logic for Add_Window.xaml
    /// </summary>
    public partial class Add_Window : Window
    {
        MyBooksContext db = new MyBooksContext();
        public Add_Window()
        {
            InitializeComponent();
            setVariablen();
        }

        private void setVariablen()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = tb_firstName.Text.ToString();
            string lastName = tb_lastName.Text.ToString();

            db.Authors.Add(new Author {FirstName = firstName, LastName = lastName });
            db.SaveChanges();
            this.Close();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
