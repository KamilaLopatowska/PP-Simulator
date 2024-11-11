using System.Xml.Linq;

namespace Simulator;

internal class Validator
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

    public static string
        Shortener(string value, int min, int max, char placeholder){
        {
            value = value?.Trim() ?? "Unknown";

            if (value.Length < min)
            {
                // wypełnia także puste string przez warunek value.Length < min
                return value.PadRight(min, placeholder);
            }
            else if (value.Length > max)
            {
                // // Skracamy do `max` znaków od początku, ponieważ `value.Length > max`, nie powinien być za krótki
                return value.Substring(0, max).TrimEnd();
            }

            if (char.IsLower(value[0]))
            {
                return char.ToUpper(value[0]) + value[1..];
            }

            return value;
        }
    }
}
