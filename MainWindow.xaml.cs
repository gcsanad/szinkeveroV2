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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SzinKeverese()
        {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value)));
        }
        private void sliPiros_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeverese();
            labPiros_Value.Content =Convert.ToInt32(sliPiros.Value);
        }

        private void sliZold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeverese();
            labZold_Value.Content =Convert.ToInt32(sliZold.Value);
        }

        private void sliKek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeverese();
            labKek_Value.Content =Convert.ToInt32(sliKek.Value);
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            string szinAdatok = $"{Convert.ToByte(sliPiros.Value)};{Convert.ToByte(sliZold.Value)};{Convert.ToByte(sliKek.Value)}";
            if (lbSzinek.Items.Contains(szinAdatok))
            {
                MessageBox.Show("Már van ilyen érték a listában!");
            }
            else
            {
                lbSzinek.Items.Add(szinAdatok);
            }



        }
        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            string[] tomb = lbSzinek.SelectedItem.ToString().Split(';');
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(tomb[0]), Convert.ToByte(tomb[1]), Convert.ToByte(tomb[2])));
        }
        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex>=0)
            {
                lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva elem!");
            }
        }

        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            lbSzinek.Items.Clear();
        }
    }
}
