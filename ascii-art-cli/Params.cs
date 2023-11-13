namespace CommandLine;
public class Params
{
    public string FilePath { get; set; } = "../resources/baby.jpg";
    public bool CustomFilePathSet { get; set; }
    public string Density { get; set; } = " .:-=+*#%@";
    public bool CustomDensitySet { get; set; }
    public int Contrast { get; set; }
    public bool Invert { get; set; }
    public string AlternativeDensity { get; set; } = """`.-':_,^=;><+!rc*/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@""";
    public bool WebcamMode { get; set; }
    public int WebcamIndex { get; set; }
    public int FrameRate { get; set; } = 10;
}