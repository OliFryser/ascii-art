using SkiaSharp;

const string DENSITY = "        .:-=+*#%@";
const string FILENAME = "../resources/baby.jpg";
const int NEW_HEIGHT = 50;
const int NEW_WIDTH = (int)(NEW_HEIGHT * 2.5);

var stream = File.OpenRead(FILENAME);
var bitmap = SKBitmap.Decode(stream);
var resizedBitmap = new SKBitmap(new SKImageInfo(NEW_WIDTH, NEW_WIDTH));
var canvas = new SKCanvas(resizedBitmap);
var paint = new SKPaint();
canvas.DrawBitmap(bitmap, new SKRect(0, 0, NEW_WIDTH, NEW_HEIGHT), paint);

for (int y = 0; y < NEW_HEIGHT; y++)
{
    string line = "";
    for (int x = 0; x < NEW_WIDTH; x++)
    {
        SKColor pixelColor = resizedBitmap.GetPixel(x, y);

        byte red = pixelColor.Red;
        byte green = pixelColor.Green;
        byte blue = pixelColor.Blue;

        float average = (red + green + blue) / 3;
        int densityIndex = (int)Math.Floor(average.Remap((0, 255), (0, DENSITY.Length - 1)));

        line += DENSITY[densityIndex];

    }

    Console.WriteLine(line);
}