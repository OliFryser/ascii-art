using Ascii;
using CommandLine;
using Webcam;

Params par = CommandLineParser.Parse(args);

string density = par.Density;
if (par.Invert)
{
    density = density.Reverse();
}
for (int i = 0; i < par.Contrast; i++)
{
    density = " " + density;
}

if (!par.WebcamMode)
{
    Image originalImage = AsciiConverter.FileToImage(par.FilePath);
    Image resizedImage = AsciiConverter.RescaleImage(originalImage, Console.WindowWidth, Console.WindowHeight - 1);
    AsciiImage asciiImage = AsciiConverter.ImageToAscii(resizedImage.Bitmap, density, (resizedImage.Width, resizedImage.Height));
    Console.WriteLine(asciiImage.ToString());
    return;
}


WebcamAcces webcamAcces = new(par.WebcamIndex);
while (true)
{
    Image originalImage = webcamAcces.GetSnapshot();
    Image resizedImage = AsciiConverter.RescaleImage(originalImage, Console.WindowWidth, Console.WindowHeight - 1);
    AsciiImage asciiImage = AsciiConverter.ImageToAscii(resizedImage.Bitmap, density, (resizedImage.Width, resizedImage.Height));
    Console.WriteLine(asciiImage.ToString());
    Thread.Sleep(1000 / par.FrameRate);
}