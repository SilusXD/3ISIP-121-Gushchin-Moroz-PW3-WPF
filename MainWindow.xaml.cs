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

namespace _3ISIP_121_Gushchin_Moroz_PW3_WPF
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double Cm, Kg;
            if (txtBoxCm.Text != null && txtBoxKg.Text != null &&
                double.TryParse(txtBoxCm.Text, out Cm) == true && double.TryParse(txtBoxKg.Text, out Kg) == true)
            {
                if ((130 <= Cm && Cm <= 220) && (40 <= Kg && Kg <= 170))
                {
                    double result = 0;
                    if (rdbMan.IsChecked == true)
                    {
                        result = ((Cm - 100) + (Cm - 100) * 0.13);
                        lblWeight.Content = result.ToString();
                    }
                    else if (rdbWoman.IsChecked == true)
                    {
                        result = ((Cm - 100) - (Cm - 100) * 0.1);
                        lblWeight.Content = result.ToString();
                    }
                    else
                    {
                        lblWeight.Content = "Выберите пол";
                    }

                    if (result != 0)
                    {
                        if (Kg < result - 3)
                        {
                            lblCharacteristic.Content = "Ниже нормы";
                        }
                        else if (Kg > result + 3)
                        {
                            lblCharacteristic.Content = "Выше нормы";
                        }
                        else
                        {
                            lblCharacteristic.Content = "Норма";
                        }
                    }
                }
                else
                {
                    lblWeight.Content = "Данные некорректны";
                    lblCharacteristic.Content = "";
                }
            }
            else
            {
                lblWeight.Content = "Заполните все поля";
                lblCharacteristic.Content = "";
            }
        }
    }
}
