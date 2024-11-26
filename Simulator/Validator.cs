using System.Xml.Linq;

namespace Simulator;

public class Validator
{
    public static int Limiter(int value, int min, int max) {
        if (value < min)
        {
            return value = min;
        }
        else if (value > max)
        {
            return value = max;
        }
        return value;     
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        value = value?.Trim() ?? "Unknown";

        if (value.Length == 0 || value.Length < min)
        {
            value = value.PadRight(min, placeholder);
        }
        if (value.Length > max)
        {
            value = value.Substring(0, max).TrimEnd();
        }
        if (value.Length < min)
        {
            value = value.PadRight(min, placeholder);
        }
        if (!string.IsNullOrEmpty(value) && char.IsLower(value[0]))
        {
            value = char.ToUpper(value[0]) + value[1..];
        }

        return value;
    }

}



