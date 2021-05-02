using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Find.xaml
    /// </summary>
    public partial class Find : Window
    {
        public Find()
        {
            InitializeComponent();
        }

        private void Find_Button_Click(object sender, RoutedEventArgs e)
        {
            Phone_Book_Context db = new Phone_Book_Context();
            var Surname = from t in db.Abonents where t.Surname == textBox_Surname.Text select t;
            var source = new ObservableCollection<Phone_Book>();
            foreach (var abonent in Surname)
            {
                source.Add(abonent);
            }
            Abonent_Info.ItemsSource = source;
        }
    }
}
