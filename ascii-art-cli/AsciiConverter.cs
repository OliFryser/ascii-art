using SkiaSharp;

namespace Ascii;
public static class AsciiConverter
{
    public static AsciiImage ImageToAscii(SKBitmap image, string densityString, (int width, int height) dimensions)
    {
        var width = dimensions.width;
        var height = dimensions.height;
        var asciiImage = new AsciiImage { Width = width, Height = height };
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                SKColor pixelColor = image.GetPixel(x, y);

                byte red = pixelColor.Red;
                byte green = pixelColor.Green;
                byte blue = pixelColor.Blue;

                float average = (red + green + blue) / 3;
                int densityIndex = (int)Math.Floor(average.Remap((0, 255), (0, densityString.Length - 1)));
                char asciiChar = densityString[densityIndex];

                asciiImage.SetPixel(x, y, asciiChar);

            }
        }
        return asciiImage;
    }

    public static Image FileToImage(string filePath)
    {
        SKBitmap bitmap = SKBitmap.Decode(filePath);
        return new Image { Width = bitmap.Width, Height = bitmap.Height, Bitmap = bitmap };
    }

    public static Image RescaleImage(Image image, int terminalWidth, int terminalHeight)
    {
        (int newWidth, int newHeight) = GetScaledDimensions((terminalWidth, terminalHeight), (image.Width, image.Height));
        var resizedBitmap = new SKBitmap(new SKImageInfo(newWidth, newWidth));
        using var canvas = new SKCanvas(resizedBitmap);
        using var paint = new SKPaint();
        canvas.DrawBitmap(image.Bitmap, new SKRect(0, 0, newWidth, newHeight), paint);
        return new Image { Width = newWidth, Height = newHeight, Bitmap = resizedBitmap };
    }

    // The primary decides the scaling factor, the secondary scales according to that
    private static (int, int) GetScaledDimensions((int width, int height) terminal, (int width, int height) original)
    {
        // Console.WriteLine($"Terminal: {terminal.width} x {terminal.height}, Original: {original.width} x {original.height}");
        if (terminal.height < terminal.width * 2)
        {
            int newWidth = GetVerticalScaling(terminal.height, original);
            if (newWidth > terminal.width)
            {
                int newHeight = GetHorizontalScaling(terminal.width, original);
                return (terminal.width, newHeight);
            }
            return (newWidth, terminal.height);
        }
        else
        {
            int newHeight = GetHorizontalScaling(terminal.width, original);
            if (newHeight > terminal.height)
            {
                int newWidth = GetVerticalScaling(terminal.height, original);
                return (newWidth, terminal.height);
            }
            return (terminal.width, newHeight);
        }
    }

    private static int GetHorizontalScaling(int terminalWidth, (int width, int height) original)
    {
        float scale = (float)terminalWidth / original.width;
        int newHeight = (int)(original.height * scale) / 2;
        return newHeight;
    }

    private static int GetVerticalScaling(int terminalHeight, (int width, int height) original)
    {
        float scale = (float)terminalHeight / original.height;
        int newWidth = (int)(original.width * 2 * scale);
        return newWidth;
    }

}

