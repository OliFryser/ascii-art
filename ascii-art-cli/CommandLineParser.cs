namespace CommandLine;
public static class CommandLineParser
{
    public static string? FilePath { get; set; }
    public static string? Density { get; set; }
    public static int Contrast { get; set; }
    public static bool Invert { get; set; }
    public static bool AlternativeDensity { get; set; }
    public static bool WebcamMode {get; private set; }
    public static int WebcamIndex { get; private set; }

    public static bool Parse(string[] args)
    {
        if (args.Length == 0) return false;
        for (int i = 0; i < args.Length; i++)
        {
            // Parse flags
            if (args[i].StartsWith("-"))
            {
                if (args[i] == "-i" || args[i] == "--invert")
                {
                    Invert = true;
                    continue;
                }
                else if (args[i] == "-a" || args[i] == "--alternative")
                {
                    AlternativeDensity = true;
                    continue;
                }
                if (i + 1 >= args.Length) throw new ArgumentException($"No value for flag: {args[i]}");
                ParseFlag(args[i++], args[i]);
                continue;
            }
            // Parse non flagged arguments
            else if (FilePath is null)
            {
                FilePath = args[i];
            }
            else if (Density is null)
            {
                Density = args[i];
            }

        }
        return true;
    }
    private static void ParseFlag(string flag, string value)
    {
        switch (flag)
        {
            case "-f":
            case "--filepath":
                FilePath = value;
                break;
            case "-d":
            case "--density":
                Density = value;
                break;
            case "-c":
            case "--contrast":
                {
                    if (int.TryParse(value, out int result))
                    {
                        Contrast = result;
                    }

                    break;
                }
            case "-w":
            case "--webcam":
                {
                    if (int.TryParse(value, out int result))
                    {
                        WebcamIndex = result;
                        WebcamMode = true;
                    }
                    break;
                }
        }
    }

}