using Ascii;
using CommandLine;
using Webcam;

string filePath = "../resources/baby.jpg";
string density = " .:-=+*#%@";
string alternativeDensity = """`.-':_,^=;><+!rc*/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@""";

bool hasArgs = CommandLineParser.Parse(args);

if (hasArgs)
{
    if (CommandLineParser.FilePath is not null) filePath = CommandLineParser.FilePath;
    if (CommandLineParser.Density is not null) density = CommandLineParser.Density;
    if (CommandLineParser.AlternativeDensity)
    {
        density = alternativeDensity;
    }
    if (CommandLineParser.Invert)
    {
        density = density.Reverse();
    }
    if (CommandLineParser.Contrast != 0)
    {
        for (int i = 0; i < CommandLineParser.Contrast; i++)
        {
            density = " " + density;
        }
    }
}

if (!CommandLineParser.WebcamMode)
{
    Image originalImage = AsciiConverter.FileToImage(filePath);
    Image resizedImage = AsciiConverter.RescaleImage(originalImage, Console.WindowWidth, Console.WindowHeight - 1);
    AsciiImage asciiImage = AsciiConverter.ImageToAscii(resizedImage.Bitmap, density, (resizedImage.Width, resizedImage.Height));
    Console.WriteLine(asciiImage.ToString());
    return;
}


WebcamAcces webcamAcces = new(CommandLineParser.WebcamIndex);
while (true)
{
    Image originalImage = webcamAcces.GetSnapshot();
    Image resizedImage = AsciiConverter.RescaleImage(originalImage, Console.WindowWidth, Console.WindowHeight - 1);
    AsciiImage asciiImage = AsciiConverter.ImageToAscii(resizedImage.Bitmap, density, (resizedImage.Width, resizedImage.Height));
    Console.WriteLine(asciiImage.ToString());
    Thread.Sleep(1000 / CommandLineParser.FrameRate);
}