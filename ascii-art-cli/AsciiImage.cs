using System.Text;

namespace Ascii;
public class AsciiImage
{
    private char[,]? _image;
    public int Width { get; init; }
    public int Height { get; init; }

    public char[,] Image => (_image is null) ? (_image = new char[Width, Height]) : _image;

    public void SetPixel(int x, int y, char asciiChar)
    {
        Image[x, y] = asciiChar;
    }

    public string GetRow(int i)
    {
        StringBuilder stringBuilder = new();
        for (int x = 0; x < Width; x++)
        {
            char c = Image[x, i];
            stringBuilder = stringBuilder.Append(c);
        }
        return stringBuilder.ToString();
    }
}