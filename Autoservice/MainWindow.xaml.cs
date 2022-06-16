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

namespace Autoservice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          user_user connection = new user_user();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var patientObj = user_user.Сотрудники.FirstOrDefault(x => x.НомерСотрудника == Number_Empl.Text);
                if (patientObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (patientObj.Должность == "Администратор")
                    {
                        Service service = new Service();
                        service.Show();
                        Close();
                        MessageBox.Show("Здравствуйте !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Войти может только администратор !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая работа приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
