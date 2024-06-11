using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TOFont
{
    public static class ui_Render
    {
        public static BitmapFrame Render(this ContentControl element)
        {
            double w = element.ActualWidth;
            double h = element.ActualHeight;


            if (w == 0 || h == 0)
            {
                w = element.Width;
                h = element.Height;

            }
            if (w == 0 || h == 0)
            {
                return null;

            }
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)w, (int)h, 96, 96, PixelFormats.Pbgra32);


            VisualBrush sourceBrush = new VisualBrush(element);
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            using (drawingContext)
            {
                drawingContext.DrawRectangle(sourceBrush, null,
                    new Rect(
                        new System.Windows.Point(0, 0),
                        new System.Windows.Point(w, h)));
            }
            rtb.Render(drawingVisual);



            //PngBitmapEncoder png = new PngBitmapEncoder();
            return BitmapFrame.Create(rtb);
        }
        public static BitmapFrame Render(this FrameworkElement element)
        {
            double w = element.ActualWidth;
            double h = element.ActualHeight;


            if (w == 0 || h == 0)
            {
                w = element.Width;
                h = element.Height;

            }
            if (w == 0 || h == 0)
            {
                return null;

            }
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)w, (int)h, 96, 96, PixelFormats.Pbgra32);


            VisualBrush sourceBrush = new VisualBrush(element);
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            using (drawingContext)
            {
                drawingContext.DrawRectangle(sourceBrush, null,
                    new Rect(
                        new System.Windows.Point(0, 0),
                        new System.Windows.Point(w, h)));
            }
            rtb.Render(drawingVisual);



            //PngBitmapEncoder png = new PngBitmapEncoder();
            return BitmapFrame.Create(rtb);
        }
    }
}

