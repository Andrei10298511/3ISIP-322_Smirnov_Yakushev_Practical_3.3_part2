using System;
using System.Windows;
using System.Windows.Controls;

namespace OhmsLawCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Меняем подписи в зависимости от выбора
            if (CurrentRadio.IsChecked == true)
            {
                Label1.Content = "Напряжение (Вольт):";
                Label2.Content = "Сопротивление (Ом):";
            }
            else if (VoltageRadio.IsChecked == true)
            {
                Label1.Content = "Сила тока (Ампер):";
                Label2.Content = "Сопротивление (Ом):";
            }
            else if (ResistanceRadio.IsChecked == true)
            {
                Label1.Content = "Напряжение (Вольт):";
                Label2.Content = "Сила тока (Ампер):";
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка выбора переключателя
            if (CurrentRadio.IsChecked == false && VoltageRadio.IsChecked == false && ResistanceRadio.IsChecked == false)
            {
                MessageBox.Show("Выберите, какую величину вычислять!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка заполнения полей
            if (string.IsNullOrWhiteSpace(Input1TextBox.Text) || string.IsNullOrWhiteSpace(Input2TextBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка на ввод чисел
            if (!double.TryParse(Input1TextBox.Text, out double value1) || !double.TryParse(Input2TextBox.Text, out double value2))
            {
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result = 0;
            string unit = "";

            // Вычисления по закону Ома
            if (CurrentRadio.IsChecked == true)
            {
                result = value1 / value2;  // I = U / R
                unit = "А";
            }
            else if (VoltageRadio.IsChecked == true)
            {
                result = value1 * value2;  // U = I * R
                unit = "В";
            }
            else if (ResistanceRadio.IsChecked == true)
            {
                result = value1 / value2;  // R = U / I
                unit = "Ом";
            }

            // Вывод результата
            ResultLabel.Content = $"Результат = {result:F2} {unit}";
        }
    }
}
