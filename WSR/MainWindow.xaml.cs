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
            VIN_LIB.VIN_LIB vIN_LIB = new VIN_LIB.VIN_LIB();
            REG_MARK_LIB.REG_MARK_LIB rEG_MARK_LIB = new REG_MARK_LIB.REG_MARK_LIB();
            // MessageBox.Show(vIN_LIB.CheckVIN(enter_vin.Text).ToString());
            MessageBox.Show(vIN_LIB.GetVINCountry(enter_vin.Text).ToString());
            // MessageBox.Show(vIN_LIB.GetTransportYear(enter_vin.Text).ToString());
            // MessageBox.Show(rEG_MARK_LIB.CheckMark(enter_vin.Text).ToString());

        }
    }
}
