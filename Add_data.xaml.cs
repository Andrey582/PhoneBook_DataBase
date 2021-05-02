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
using System.Windows.Shapes;

namespace DataBase_PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для Add_data.xaml
    /// </summary>
    public partial class Add_data : Window
    {
        public Add_data()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Phone_Book_Context db = new Phone_Book_Context();
            Phone_Book abonent = new Phone_Book();
            abonent.Name = textBox_Name.Text;
            abonent.Surname = textBox_Surname.Text;
            abonent.Phone_Number = textBox_PhoneNumber.Text;
            db.Abonents.Add(abonent);
            db.SaveChanges();
            MessageBox.Show("Пользователь добавлен");
        }
    }
}
