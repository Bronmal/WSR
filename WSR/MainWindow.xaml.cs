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
                        if (password.Password == i.password)
                        {
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            this.Close();
                        }
                        else
                        {
                            i.count_of_login++;
                        }
                    }
                }
                gAI_Entities.SaveChanges();
            }
        }
    }
}
