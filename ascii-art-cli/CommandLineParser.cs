namespace CommandLine;
public static class CommandLineParser
{


    public static Params Parse(string[] args)
    {
        Params par = new();

        for (int i = 0; i < args.Length; i++)
        {
            // Parse flags
            if (args[i].StartsWith("-"))
            {
                if (args[i] == "-i" || args[i] == "--invert")
                {
                    par.Invert = true;
                    continue;
                }
                else if (args[i] == "-a" || args[i] == "--alternative")
                {
                    if (par.CustomDensitySet) break;
                    par.Density = par.AlternativeDensity;
                    par.CustomDensitySet = true;
                    continue;
                }
                if (i + 1 >= args.Length) throw new ArgumentException($"No value for flag: {args[i]}");
                ParseFlag(args[i++], args[i], par);
                continue;
            }
            // Parse non flagged arguments
            else if (!par.CustomFilePathSet)
            {
                par.FilePath = args[i];
            }
            else if (!par.CustomDensitySet)
            {
                par.Density = args[i];
            }

        }
        return par;
    }

    private static void ParseFlag(string flag, string value, Params par)
    {
        switch (flag)
        {
            case "-p":
            case "--path":
                par.FilePath = value;
                par.CustomFilePathSet = true;
                break;
            case "-d":
            case "--density":
                if (par.CustomDensitySet) break;
                par.Density = value;
                par.CustomDensitySet = true;
                break;
            case "-c":
            case "--contrast":
                {
                    if (int.TryParse(value, out int result))
                    {
                        par.Contrast = result;
                    }

                    break;
                }
            case "-w":
            case "--webcam":
                {
                    if (int.TryParse(value, out int result))
                    {
                        par.WebcamIndex = result;
                        par.WebcamMode = true;
                    }
                    break;
                }
            case "-f":
            case "--framerate":
                {
                    if (int.TryParse(value, out int result))
                    {
                        if (result > 0 && result <= 60)
                            par.FrameRate = result;
                    }
                    break;
                }
        }
    }

}