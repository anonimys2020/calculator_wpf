using System;
using System.Data;
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

namespace SimpleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            foreach(UIElement el in MainRoot.Children)
            {
                if (el is Button) {
                    ((Button) el).Click += Button_Click;

                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (textLabel.Text == "Ошибка")
                if (str != "")
                    textLabel.Text = "";
                else
                    textLabel.Text = str;
            else if (textLabel.Text.Contains("/0") == true)
                textLabel.Text = "Ошибка";
            else if (str.Contains("AC") == true)
                textLabel.Text = "";
            else if (str == "Delete")
            {
                if (textLabel.Text != "")
                    textLabel.Text = textLabel.Text.Remove(textLabel.Text.Length - 1);
            }
            else if (str == "=")
            {
                string value = new DataTable().Compute(textLabel.Text, null).ToString();
                textLabel.Text = value;
            }
            
            else
            {
                /* textLabel.Text += str; */
                if (textLabel.Text == "0")
                {
                    if (Int32.TryParse(str, out int x) == true)
                        textLabel.Text = str;
                    else
                        textLabel.Text += str;
                }
                else if (Int32.TryParse(str, out int x) == false)
                {
                    if (textLabel.Text != "")
                    {
                        textLabel.Text += str;
                        if (textLabel.Text.Contains(str + str) == true & str + str != "((" & str + str != "))")
                        {
                            textLabel.Text = textLabel.Text.Remove(textLabel.Text.Length - 1);
                        }
                    }
                }
                else
                    textLabel.Text += str;
            }
        }
    }
}
