using System;
using System.Linq;
using System.Collections.Generic;

public static class MorseData
{

    public static readonly Dictionary<char, string> MorseTranslation = new Dictionary<char, string>()
    {
        { 'A', ".-"   },
        { 'B', "-..." },
        { 'C', "-.-." },
        { 'D', "-.."  },
        { 'E', "."    },
        { 'F', "..-." },
        { 'G', "--."  },
        { 'H', "...." },
        { 'I', ".."   },
        { 'J', ".---" },
        { 'K', "-.-"  },
        { 'L', ".-.." },
        { 'M', "--"   },
        { 'N', "-."   },
        { 'O', "---"  },
        { 'P', ".--." },
        { 'Q', "--.-" },
        { 'R', ".-."  },
        { 'S', "..."  },
        { 'T', "-"    },
        { 'U', "..-"  },
        { 'V', "...-" },
        { 'W', ".--"  },
        { 'X', "-..-" },
        { 'Y', "-.--" },
        { 'Z', "--.." },
    };
    public static string GenerateSequence(char ch)
    {
        string output = "";
        foreach (char unit in MorseTranslation[ch])
        {
            if (unit == '-')
                output += "xxx";
            else output += "x";
            output += ".";
        }
        return output + "..";
    }
    public static string GenerateSequence(string str)
    {
        string output = "";
        foreach (char ch in str)
            output += GenerateSequence(ch);
        output += "....";
        return output;
    }
}