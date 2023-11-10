namespace CommandLine;
public static class CommandLineParser
{
    public static string? FilePath { get; set; }
    public static string? Density { get; set; }
    public static int Contrast { get; set; }
    public static bool Invert { get; set; }
    public static bool AlternativeDensity { get; set; }

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
        if (flag == "-f" || flag == "--filepath")
        {
            FilePath = value;
        }
        else if (flag == "-d" || flag == "--density")
        {
            Density = value;
        }
        else if (flag == "-c" || flag == "--contrast")
        {
            if (int.TryParse(value, out int result))
            {
                Contrast = result;
            }
        }
    }

}