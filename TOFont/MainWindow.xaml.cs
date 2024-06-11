using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TOFont.ViewModel;

namespace TOFont
{

    public partial class MainWindow : Window
    {
        public static List<string> AdjustContrast(Bitmap Image)
        {
            List<string> COLORS__ = new List<string>();
            Color color;
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            for (int x = 0; x < NewBitmap.Width; x++)
            {
                for (int y = 0; y < NewBitmap.Height; y++)
                {
                    color = Image.GetPixel(x, y);


                    COLORS__.Add($"Data[{x}][{y}] = Color" + "{" + $"{color.R},  {color.G},  {color.B}" + "};");
                }
            }

            return COLORS__;
        }
        static byte[] GetBytesFromBitmapSource(BitmapSource bmp)
        {
            int width = bmp.PixelWidth;
            int height = bmp.PixelHeight;
            int stride = width * ((bmp.Format.BitsPerPixel + 7) / 8);

            byte[] pixels = new byte[height * stride];

            bmp.CopyPixels(pixels, stride, 0);

            return pixels;
        }

        CharsModel charsModel = new CharsModel();
        public MainWindow()
        {
            InitializeComponent();


            this.DataContext = charsModel;





            this.Loaded += MainWindow_Loaded;
        }
        int i = 0;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            foreach (var item in charsModel.CharItems)
            {
                var grid = new Grid()
                {

                };

                var textBlock = new Label()
                {
                    Content = item.Char,
                    FontSize = 9,
                    Foreground = System.Windows.Media.Brushes.Red,
                    // Background = Brushes.Teal,
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 0, 0, 0),
                    Padding = new Thickness()
                };
                grid.Height = textBlock.FontSize + 2;
                grid.Width = (textBlock.FontSize / 2 + 4);

                grid.Children.Add(textBlock);
                grid.Loaded += Grid_Loaded;
                _wrap.Children.Add(grid);




            }


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            var image = (sender as FrameworkElement).Render();
            if (image != null)
            {
                using (var fileStream = new FileStream($"char_{i}.png", FileMode.Create))
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(image);

                    string data = "";


                    encoder.Save(fileStream);
                }
                File.WriteAllText($"char_{i}.txt", string.Join(
                    " ",
                    AdjustContrast(new Bitmap($"char_{i}.png"))
                    ));

                i++;
            }
        }
    }
}
