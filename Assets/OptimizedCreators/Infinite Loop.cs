using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteLoop {

	private static readonly string[] wordList = { "ANCHOR", "AXIONS", "BRUTAL", "BUNKER", "CEASED", "CYPHER", "DEMOTE", "DEVOID", "EJECTS", "EXPEND", "FIXATE", "FONDLY", "GEYSER", "GUITAR", "HEXING", "HYBRID", "INCITE", "INJECT", "JACKED", "JIGSAW", "KAYAKS", "KOMODO", "LAZULI", "LOGJAM", "MAIMED", "MUSKET", "NEBULA", "NUKING", "OBLONG", "OVERDO", "PHOTON", "PROBED", "QUARTZ", "QUEBEC", "REFUTE", "REGIME", "SIERRA", "SWERVE", "TENACY", "THYMES", "ULTIMA", "UTOPIA", "VALVED", "VIABLE", "WITHER", "WRENCH", "XENONS", "XYLOSE", "YANKED", "YELLOW", "ZIGGED", "ZODIAC" };
	public static Dictionary<string, string> answers;

	private string GenerateAnswer(string input)
    {
		string morseTranslation = input.Select(x => MorseData.MorseTranslation[x]).Join("");
		morseTranslation += morseTranslation;
		return morseTranslation;
    }
    public void GenerateAllAnswers()
    {
        answers = new Dictionary<string, string>();
        foreach (string word in wordList)
            answers.Add(word, GenerateAnswer(word));
    }
    public string FormatTable(int columnCount)
    {
        KeyValuePair<string, string>[] answersArr = answers.ToArray();
        string output = "";
        for (int tableIx = 0; tableIx < columnCount; tableIx++)
        {
            output += "<table>\n";
            for (int i = tableIx; i < answers.Count; i += columnCount)
                output += string.Format("\t<tr>\n\t\t<td>{0}</td> <td>{1}</td>\n\t</tr>\n", answersArr[i].Key, answersArr[i].Value);
            output += "</table>\n\n";
        }
        return output;
    }
}
