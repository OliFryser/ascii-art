using SkiaSharp;

namespace Ascii;
public class Image
{
    public SKBitmap Bitmap { get; init; } = null!;
    public int Width { get; init; }
    public int Height { get; init; }
}