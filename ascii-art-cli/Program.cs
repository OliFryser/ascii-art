using Ascii;
using CommandLine;

string filePath = "../resources/baby.jpg";
string density = " .:-=+*#%@";
string alternativeDensity = """`.-':_,^=;><+!rc*/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@""";

bool hasArgs = CommandLineParser.Parse(args);

if (hasArgs)
{
    if (CommandLineParser.FilePath is not null) filePath = CommandLineParser.FilePath;
    if (CommandLineParser.Density is not null) density = CommandLineParser.Density;
    if (CommandLineParser.Invert)
    {
        density = density.Reverse();
    }
    if (CommandLineParser.AlternativeDensity)
    {
        density = alternativeDensity;
    }
    if (CommandLineParser.Contrast != 0)
    {
        for (int i = 0; i < CommandLineParser.Contrast; i++)
        {
            density = " " + density;
        }
    }
}

Image image = AsciiConverter.RescaleImage(filePath, Console.WindowWidth, Console.WindowHeight - 1);
AsciiImage asciiImage = AsciiConverter.ImageToAscii(image.Bitmap, density, (image.Width, image.Height));

for (int i = 0; i < asciiImage.Height; i++)
{
    string line = asciiImage.GetRow(i);
    Console.WriteLine(line);
}