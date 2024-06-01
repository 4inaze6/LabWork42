using Microsoft.Win32;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task1
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

        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                Filter = "растровые|*.png; *.jpg; *.jpeg; *.bmp",
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Выбор изображения",
            };

            if (dialog.ShowDialog() != true)
                return;

            BitmapImage image = new BitmapImage(new Uri(dialog.FileName));
            if (image != null)
            {
                Image img = new Image();
                img.Source = image;
                img.Width = image.Width;
                img.Height = image.Height;

                WorkingFieldInkCanvas.Children.Add(img);
            }
        }

        private void SliderValueChanged(object sender, RoutedEventArgs e)
        {
            byte red = (byte)RedSlider.Value;
            byte green = (byte)GreenSlider.Value;
            byte blue = (byte)BlueSlider.Value;
            Color color = Color.FromArgb(255, red, green, blue);
            Brush brush = new SolidColorBrush(color);

            ExampleEllipse.Width = SizeSlider.Value;
            ExampleEllipse.Height = SizeSlider.Value;
            ExampleEllipse.Fill = brush;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            byte red = (byte)RedSlider.Value;
            byte green = (byte)GreenSlider.Value;
            byte blue = (byte)BlueSlider.Value;

            if (WorkingFieldInkCanvas != null)
            {
                WorkingFieldInkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(red, green, blue);
                WorkingFieldInkCanvas.DefaultDrawingAttributes.Width = SizeSlider.Value;
                WorkingFieldInkCanvas.DefaultDrawingAttributes.Height = SizeSlider.Value;
            }
        }
    }
}