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
using System.Windows.Threading;
using VIN_LIB;

namespace WSR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (WSR_GAIEntities1 gAI_Entities = new WSR_GAIEntities1())
            {
                var query = gAI_Entities.Users;
                foreach( var i in query)
                {
                   if (login.Text == i.login)
                    {
                        if (i.count_of_login.Value < 3)
                        {
                            if (password.Password == i.password)
                            {
                                Dashboard dashboard = new Dashboard();
                                dashboard.Show();
                                this.Close();
                                break;
                            }
                            else
                            {
                                i.count_of_login++;
                                if (i.count_of_login == 3)
                                {
                                    i.time = DateTime.Now.AddMinutes(1);
                                    MessageBox.Show("Подожите минуту");
                                }
                            }
                        }
                        else
                        {
                            if (i.time < DateTime.Now)
                            {
                                i.time = null;
                                i.count_of_login = 0;
                            }
                            else
                            {
                                MessageBox.Show("Подожите минуту");
                            }
                        }
                        
                    }
                }
                gAI_Entities.SaveChanges();
                
            }
        }
    }
}
