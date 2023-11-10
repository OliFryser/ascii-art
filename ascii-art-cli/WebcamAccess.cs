using Ascii;
using OpenCvSharp;
using SkiaSharp;

namespace Webcam;
public class WebcamAcces
{
    private VideoCapture _videoCapture;
    private Mat _frame;

    public WebcamAcces(int index)
    {
        _frame = new();
        _videoCapture = new(index);
        if (_videoCapture is null) throw new Exception("Webcam Not Found");
        _videoCapture.Open(index);
    }

    public Image GetSnapshot()
    {
        _videoCapture.Read(_frame);
        SKBitmap bitmap = SKBitmap.Decode(_frame.ToMemoryStream());
        return new Image()
        {
            Bitmap = bitmap,
            Width = _videoCapture.FrameWidth,
            Height = _videoCapture.FrameHeight
        };
    }
}