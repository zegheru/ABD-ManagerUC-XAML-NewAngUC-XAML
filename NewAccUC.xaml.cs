using AutoWash.Models;
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

namespace AutoWash
{
    /// <summary>
    /// Interaction logic for NewAccUC.xaml
    /// </summary>
    public partial class NewAccUC : UserControl
    {
        private void AddUser()
        {
            Clienti client = new Clienti()
            {
                Nume = NumeTextBox.Text,
                Prenume = PrenumeTextBox.Text,
                AdresaEMAIL = EmailTextBox.Text,
                Parola = ParolaTextBox.SecurePassword.ToString()

            };

            if (ParolaTextBox.SecurePassword.ToString() != ConfPassTextBox.SecurePassword.ToString())
            {
                MessageBox.Show("Confirmation password do not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
                if (ClientPermanentRadioButton.IsChecked == true)
                {
                    client.TipClient = "permanent";
                    client.NumarInmatriculare = NumarInmatriculareTextBox.Text;
                    client.NumarTelefon = NumarTelefonTextBox.Text;
                }

                else
                    client.TipClient = "simplu";

            
            using (var data = new SpalatorieEntities())
            {
                data.Clienti.Add(client);
            }
        }

        public NewAccUC()
        {

            InitializeComponent();
            DataContext = new NewAccModel();
            NumarInmaticulareSP.Visibility = Visibility.Hidden;
            NumarTelefonSP.Visibility = Visibility.Hidden;
             
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void ClientPermanentRadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientPermanentRadioButton.IsChecked == true)
            {
                NumarTelefonSP.Visibility = Visibility.Visible;
                NumarInmaticulareSP.Visibility = Visibility.Visible;

            }
        }
    }
}
