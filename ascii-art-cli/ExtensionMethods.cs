public static class ExtensionMethods
{
    public static float Remap(this float value, (float start, float end) from, (float start, float end) to)
        => to.start + (value - from.start) * (to.end - to.start) / (from.end - from.start);

    public static string Reverse(this string value)
    {
        // reverses the string
        var charArray = value.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}