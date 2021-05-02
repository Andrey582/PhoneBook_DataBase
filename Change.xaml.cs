using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace DataBase_PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {

        Phone_Book_Context db = new Phone_Book_Context();
        private int Id_user;

        public Change()
        {
            InitializeComponent();
        }

        private void Button_Find_Click(object sender, RoutedEventArgs e)
        {
            var Surname = from t in db.Abonents where t.Surname == textBox_Find.Text select t;
            var Number = from t in db.Abonents where t.Phone_Number == textBox_Find.Text select t;
            var source = new ObservableCollection<Phone_Book>();
            foreach (var abonent in Surname)
                source.Add(abonent);
            Abonent_Info.ItemsSource = source;
            if (Abonent_Info.Items.Count == 0)
                foreach (var number in Number)
                    source.Add(number);
            Abonent_Info.ItemsSource = source;
            if (Abonent_Info.Items.Count > 0)
            {
                Select.IsEnabled = true;
                Abonent_Info.SelectedIndex = 0;
            }
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            Phone_Book book = new Phone_Book();
            var index = Abonent_Info.SelectedIndex;
            book = (Phone_Book)Abonent_Info.Items.GetItemAt(index);
            textBox_Name.Text = book.Name;
            textBox_Surname.Text = book.Surname;
            textBox_Number.Text = book.Phone_Number;
            Id_user = book.Id;
            textBox_Name.IsEnabled = true;
            textBox_Surname.IsEnabled = true;
            textBox_Number.IsEnabled = true;
            Button_Change.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var abonent = db.Abonents.Where(t => t.Id == Id_user).FirstOrDefault();
            abonent.Name = textBox_Name.Text;
            abonent.Surname = textBox_Surname.Text;
            abonent.Phone_Number = textBox_Number.Text;
            textBox_Name.IsEnabled = false;
            textBox_Surname.IsEnabled = false;
            textBox_Number.IsEnabled = false;
            Button_Change.IsEnabled = false;
            Button_Find_Click(null, null);
        }
    }
}

