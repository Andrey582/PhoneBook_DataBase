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
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.Data;

namespace DataBase_PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Phone_Book_Context db;
        private ObservableCollection<Phone_Book> source;

        public MainWindow()
        {
            db = new Phone_Book_Context();
            InitializeComponent();
            Update();
        }

        private void Add_Data_Click(object sender, RoutedEventArgs e)
        {
            Add_data window = new Add_data();
            window.ShowDialog();
            Update();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            Find window = new Find();
            window.ShowDialog();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Change window = new Change();
            window.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var book = (Phone_Book)Abonent_Info.Items.GetItemAt(Abonent_Info.SelectedIndex);
            var abonent = db.Abonents.Where(t => t.Id == book.Id).FirstOrDefault();
            db.Abonents.Remove(abonent);
            db.SaveChanges();
            Update();
        }

        public void Update()
        {
            db.Abonents.Load();
            source = new ObservableCollection<Phone_Book>();
            foreach(var abonent in db.Abonents)
            {
                source.Add(abonent);
            }
            Abonent_Info.ItemsSource = source;
        }
    }
}
