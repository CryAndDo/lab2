using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1
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
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => Presence_of_a_line_in_the_text());
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => Symbol_replacement());
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = uri.Text;
            try
            {
                await Task.Run(() => LoadPage(url));
            }
            catch (Exception ex)
            {
                text.Dispatcher.Invoke(() => text.Text = "Произошла ошибка: " + ex.Message);
            }
        }

        private void LoadPage(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    text.Dispatcher.Invoke(() => text.Text = responseBody);
                }
                else
                {
                    text.Dispatcher.Invoke(() => text.Text = "Ошибка при загрузке страницы");
                }
            }
        }

        private void Presence_of_a_line_in_the_text()
        {
            text.Dispatcher.Invoke(() => text.SelectedText);
            bool containsDigit = false;

            foreach (char c in text.SelectedText)
            {
                if (Char.IsDigit(c))
                {
                    containsDigit = true;
                    break;
                }
            }

            if (containsDigit)
            {
                string message = "В строке есть цифра";
                MessageBox.Show(message);
            }
            else
            {
                string message = "В строке нет цифры";
                MessageBox.Show(message);
            }
        }

        private void Symbol_replacement()
        {
            string selectedText = text.Dispatcher.Invoke(() => text.SelectedText);
            selectedText = selectedText.Replace("!", ",!");
            text.Dispatcher.Invoke(() => text.SelectedText = selectedText);
        }
    }
}