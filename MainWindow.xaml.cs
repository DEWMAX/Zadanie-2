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

namespace Zadanie2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dane dane = new Dane();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = dane;
        }

        private void Liczba(object sender, RoutedEventArgs e)
        {
            dane.PobierzLiczba(
                (string)((Button)sender).Content
                );

        }

        private void Przecinek(object sender, RoutedEventArgs e)
        {
            dane.PobierzPrzecinek(
                (string)((Button)sender).Content
                );
        }

        private void Znak(object sender, RoutedEventArgs e)
        {
            dane.PrzelaczZnak();
        }

        private void DajWynik(object sender, RoutedEventArgs e)
        {
            dane.DwaArgumenty();
        }

        private void Procent(object sender, RoutedEventArgs e)
        {
            dane.Procenty();
        }

        private void Operator(object sender, RoutedEventArgs e)
        {
            dane.PrzelaczOperator(
                (string)((Button)sender).Content
                );
            dane.PobierzOperator(
                (string)((Button)sender).Content
                );
        }

        private void Jednoargumentowe(object sender, RoutedEventArgs e)
        {
            dane.PobierzJednoargumentowe(
                (string)((Button)sender).Content
                );
        }

        private void Wstecz(object sender, RoutedEventArgs e)
        {
            dane.WsteczZnak();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            dane.Skasuj();
        }

        private void Skasuj(object sender, RoutedEventArgs e)
        {
            dane.Skasuj();
        }
    }
}
