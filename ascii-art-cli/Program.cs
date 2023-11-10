using SkiaSharp;

const string density = "        .:-=+*#%@";
const string filename = "../resources/baby.jpg";
int newHeight = 50;
int newWidth = (int) (newHeight * 2.5); 

var stream = File.OpenRead(filename);
var bitmap = SKBitmap.Decode(stream);
var resizedBitmap = new SKBitmap(new SKImageInfo(newWidth, newWidth));
var canvas = new SKCanvas(resizedBitmap);
var paint = new SKPaint();
canvas.DrawBitmap(bitmap, new SKRect(0, 0, newWidth, newHeight), paint);

for (int y = 0; y < newHeight; y++)
{
    string result = "";
    for (int x = 0; x < newWidth; x++)
    {
        SKColor pixelColor = resizedBitmap.GetPixel(x,y);

        byte red = pixelColor.Red;
        byte green = pixelColor.Green;
        byte blue = pixelColor.Blue;
        
        float average = (red + green + blue) / 3;
        int densityIndex = (int) Math.Floor(average.Remap((0, 255), (0, density.Length-1)));

        result += density[densityIndex];
        
    }
    
    Console.WriteLine(result);
}