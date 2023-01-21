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

namespace StartC_OOP_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttonAdd.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;
            surname.IsReadOnly = true;
            name.IsReadOnly = true;
            patronymic.IsReadOnly = true;
            numberPassport.IsReadOnly = true;
            numberPassport.Binding = new Binding("numberPassportHidden");
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (managerBox.IsSelected == true)
            {
                textblock.Text = "Менеджер";
                buttonAdd.Visibility = Visibility.Visible;
                buttonDelete.Visibility = Visibility.Visible;
                surname.IsReadOnly = false;
                name.IsReadOnly = false;
                patronymic.IsReadOnly = false;
                numberPassport.IsReadOnly = false;
                numberPassport.Binding = new Binding("numberPassport");
            }
            else
            {
                textblock.Text = "Консультант";
                buttonAdd.Visibility = Visibility.Hidden;
                buttonDelete.Visibility = Visibility.Hidden;
                surname.IsReadOnly = true;
                name.IsReadOnly = true;
                patronymic.IsReadOnly = true;
                numberPassport.IsReadOnly = true;
                numberPassport.Binding = new Binding("numberPassportHidden");
            }
        }
    }
}
