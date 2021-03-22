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
using System.Windows.Shapes;
using HandsClothes.EFData;

namespace HandsClothes.Windows
{
    public partial class MinimalChangeModalWindow : Window
    {
        public MinimalChangeModalWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NewMinimalValTXT.Text = DataFrame.Context.Material.Max(i => i.MinimalAmount).ToString();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            string TextBoxVal = NewMinimalValTXT.Text.Trim();
            int NewVal;

            if (string.IsNullOrEmpty(TextBoxVal))
            {
                MessageBox.Show("Введите значение", "Ошибка!", MessageBoxButton.OK);
            }
            else
            {
                if (int.TryParse(TextBoxVal, out NewVal))
                {
                    //Нажатие на кнопку "изменить" возвращает тру как dialogResult, если последний получает значение, то окно, открытое через ShowDialog закрывается
                    if (MessageBox.Show("Вы уверены, что хотите применить эти значения", "Уверены?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                    {
                        this.DialogResult = true;
                    }
                }
                else
                {
                    MessageBox.Show("Введите числовое значение", "Ошибка!", MessageBoxButton.OK);
                }
            }
        }

        public int NewMinimalVal
        {
            get { return int.Parse(NewMinimalValTXT.Text.Trim()); }
        }
    }
}
