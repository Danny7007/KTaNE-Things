using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CruelBinary {

	private static readonly string[] wordList = { "ABORT", "ABOUT", "ALPHA", "BLACK", "BRAVO", "CLOCK", "CLOSE", "COULD", "CRASH", "DELTA", "DIGIT", "EIGHT", "GAMMA", "GLASS", "GREEN", "GUESS", "HOTEL", "INDIA", "KAPPA", "LATER", "LEAST", "LEMON", "MONTH", "MORSE", "NORTH", "OMEGA", "OSCAR", "PANIC", "PRESS", "ROMEO", "SEVEN", "SIGMA", "SMASH", "SOUTH", "TANGO", "TIMER", "VOICE", "WHILE", "WHITE", "WORLD", "WORRY", "WOULD", "BINARY", "DEFUSE", "DISARM", "EXPERT", "FINISH", "FORGET", "LAMBDA", "MANUAL", "MODULE", "NUMBER", "ORANGE", "PERIOD", "PURPLE", "QUEBEC", "SHOULD", "SIERRA", "SOURCE", "STRIKE", "SUBMIT", "TWITCH", "VICTOR", "VIOLET", "WINDOW", "YELLOW", "YANKEE" };
	public static Dictionary<string, string> answers;

	public string GenerateAnswer(string inputWord)
    {
        char[] morse = inputWord.SelectMany(x => MorseData.MorseTranslation[x]).ToArray();
        string binary = morse.Select(x => x == '.' ? '0' : '1').Join("");
        while (binary.Length % 8 != 0)
            binary += 0;
        Stack<int> values = new Stack<int>();
        for (int i = 0; i < binary.Length; i += 8)
            values.Push(Convert.ToInt32(binary.Substring(i, 8), 2));
        return Convert.ToString(values.Sum(), 2).PadLeft(8, '0').TakeLast(8).Join("");
    }
	public void GenerateAllAnswers()
    {
        answers = new Dictionary<string, string>();
        foreach (string word in wordList)
            answers.Add(word, GenerateAnswer(word));
    }
    public string FormatTable(int width)
    {
        string output = "<table>\n\t<tr>\n";
        for (int i = 0; i < answers.Count; i++)
        {
            output += string.Format("\t\t<th>{0}</th> <td>{1}</td>\n", answers.ElementAt(i).Key, answers.ElementAt(i).Value);
            if ((i + 1) % width == 0)
                output += "\t</tr>\n\t<tr>\n";
        }
        int span = 2 * (width - (answers.Count % width));
        if (span != 0)
            output += string.Format("\t\t<td colspan=\"{0}\" class=\"brCell\"></td>", span);
        if (!output.EndsWith("</tr>"))
            output += "\n\t</tr>\n";
        output += "</table>";
        return output;
    }

/*    public void Check(string[] given)
    {
        GenerateAllAnswers();
        Dictionary<string, string> givenDict = new Dictionary<string, string>();
        foreach (string entry in given)
        {
            Match m = Regex.Match(entry, @"^\s*(\w+)\s*=\s*([01]+)\s*$");
            if (!givenDict.ContainsKey(m.Groups[1].Value))
                givenDict.Add(m.Groups[1].Value, m.Groups[2].Value);
        }
        foreach (string key in givenDict.Keys)
        {
            if (!answers.ContainsKey(key))
                Debug.LogFormat("Found absent key {0}", key);
            else if (givenDict[key] != answers[key])
                Debug.LogFormat("Found discrepancy with key {0} ({1} vs {2})", key, givenDict[key], answers[key]);
        }
    }*/
}
