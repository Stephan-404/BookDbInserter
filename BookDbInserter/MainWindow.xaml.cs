using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookDbLib;
using BookDbUserControlsLib;
using Microsoft.EntityFrameworkCore;

namespace BookDbInserter
{

    //TODO add remove Obtion
    //TODO add Authoren,Owner,etc... manualy
    //TODO set Titel for windows
    //TODO add icon

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        MyBooksContext db = new MyBooksContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            tb_ISBN.Text = "123";
            tb_Titel.Text = "Test";
            cb_Author.selectedIndex = 0;
            cb_Publishing.selectedIndex = 0;
            tb_pages.Text = "199";
            tb_purchaseDate.Text = "2020";
            tb_price.Text = "18,9";
            tb_rating.Text = "10";
            cb_Owner.SelectedIndex = 0;
            cb_Place.SelectedIndex = 0;
            cb_Language.SelectedIndex = 0;
            tb_weight.Text = "0";
            tb_width.Text = "0";
            tb_lenght.Text = "0";
            tb_height.Text = "0";
            loadBookList();
            fillComboBoxes();
        }

        private void loadBookList()
        {
            List<Book> books;
            books = db.Books.ToList();
            lb_books.ItemsSource = books;
            bookCount.Count = books.Count;
        }

        private void fillComboBoxes()
        {
            List<Author> authors;
            authors = db.Authors.OrderBy(x => x.AuthorId).ToList();
            cb_Author.Source = authors;
            cb_Author.ItemHasBeenSelected += DropDownAddClicked;

            List<Language> languages;
            languages = db.Languages.OrderBy(x => x.LanguageId).ToList();
            cb_Language.ItemsSource = languages;
            List<Owner> owners;
            owners = db.Owners.OrderBy(x => x.OwnerId).ToList();
            cb_Owner.ItemsSource = owners;
            List<Place> places;
            places = db.Places.OrderBy(x => x.PlaceId).ToList();
            cb_Place.ItemsSource = places;

            List<PublishingCompany> publishers;
            publishers = db.PublishingCompanies.OrderBy(x => x.CompanyId).ToList();
            cb_Publishing.Source = publishers;
            cb_Publishing.ItemHasBeenSelected += DropDownAddClickedDym;
        }

        void DropDownAddClicked(object sender, DropDownAdd.SelectedItemEventArgs e)
        {
            var value = e.SelectedChoice;
            Add_Window add_Window = new Add_Window();
            add_Window.Title="adfad";
            add_Window.Show();
            fillComboBoxes();
        }

        void DropDownAddClickedDym(object sender, DropDownAdd.SelectedItemEventArgs e)
        {
            List<object> s = new List<object> { "a","b","c"};

            var value = e.SelectedChoice;
            DymAdd add_Window = new DymAdd();
            add_Window.elements = s;
            add_Window.Title = "adfad";
            add_Window.Show();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            int ISBN = Convert.ToInt32(tb_ISBN.Text.ToString());
            string Titel = tb_Titel.Text.ToString();
            int Author_ID = cb_Author.selectedIndex;
            int Verlage_ID = cb_Publishing.selectedIndex;
            int Pages = Convert.ToInt32(tb_pages.Text.ToString());
            string purchaseDate = tb_purchaseDate.Text.ToString(); ;
            decimal price = Convert.ToDecimal(tb_price.Text.ToString());
            int rating = Convert.ToInt32(tb_rating.Text.ToString());
            int Owner_ID = cb_Owner.SelectedIndex;
            int Place_ID = cb_Place.SelectedIndex;
            int Language_ID = cb_Language.SelectedIndex;
            decimal weight;
            decimal width;
            decimal lenght;
            decimal height;
            weight = Convert.ToDecimal(tb_weight.Text.ToString());
            width = Convert.ToDecimal(tb_width.Text.ToString());
            lenght = Convert.ToDecimal(tb_lenght.Text.ToString());
            height = Convert.ToDecimal(tb_height.Text.ToString());

            Book b = new Book()
            {
                Isbn = ISBN,
                Titel = Titel,
                AuthorId = Author_ID,
                VerlagId = Verlage_ID,
                Pages = Pages,
                PurchaseDate = purchaseDate,
                Price = price,
                Rating = rating,
                OwnerId = Owner_ID,
                PlaceId = Place_ID,
                LanguageId = Language_ID,
                Weight = weight,
                Width = width,
                Lenght = lenght,
                Height = height
            };
            try
            {
                db.Books.Add(b);
                db.SaveChanges();
                loadBookList();
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show("A book with this ISBN already exists in this Database, please check the ISBN again");
            }

        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            Book book = lb_books.SelectedItem as Book;
            if (book==null)
            {
                book = (lb_books.ItemsSource as List<Book>)[0];
            }
            if (lb_books.ItemsSource != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                loadBookList();
            }
            
        }

    }
}
