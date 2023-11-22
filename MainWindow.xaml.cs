using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string tekst = txt.Text;
            string sciezka = "C:/tmp/plik.txt";
            try
            {
                
                using (StreamWriter sw = new StreamWriter(sciezka))
                {
                    sw.Write(tekst);
                }
                MessageBox.Show("Dane zapisane");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd" + ex.Message);
            }

        }

        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            string text = "";
            using (StreamReader sr = new("C:/tmp/plik.txt")) 
            {
                try
                {
                    string a = sr.ReadLine();
                    do
                    {
                        text += a;
                        a = sr.ReadLine();
                    } while (!sr.EndOfStream);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Nie może byc puste" + ex.Message);
                }
            }
            txt.Text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txt.FontWeight == FontWeights.Bold)
            {
                txt.FontWeight = FontWeights.Normal;
            }
            else
            {
                txt.FontWeight= FontWeights.Bold;
            }
        }
    }
}
