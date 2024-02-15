using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Kootenpv.Contractions
{
    public class Contractions
    {
        static Dictionary<string, string> contractions = new Dictionary<string, string>();
        static Dictionary<string, string> leftovers = new Dictionary<string, string>();
        static Dictionary<string, string> slang = new Dictionary<string, string>();
        public static void Convert(string text)
        {
            contraction = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "contractions_dict.json")));
            leftovers = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "leftovers_dict.json")));
            slang = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "slang_dict.json")));

            string[] months = new string[]
            {
                "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december"
            }

            for (int i = 0; i < months.Length; i++)
            {
                contractions.Add(months[i].Substring(0, 3) + ".", months[i]);
            }
            contractions = contractions.Concat(contractions.Select(kvp => new KeyValuePair<string, string>(kvp.Key.Replace("'", "’"), kvp.Value))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            leftovers = leftovers.Concat(leftovers.Select(kvp => new KeyValuePair<string, string>(kvp.Key.Replace("'", "’"), kvp.Value))).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (contractions.ContainsKey(words[i]))
                {
                    words[i] = contractions[words[i]];
                }
                else if (leftovers.ContainsKey(words[i]))
                {
                    words[i] = leftovers[words[i]];
                }
                else if (slang.ContainsKey(words[i]))
                {
                    words[i] = slang[words[i]];
                }
            }
            return string.Join(" ", words);
        }
    }
}
 