using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Kootenpv.Contractions
{
    public class Contractions
    {
        public static Dictionary<string, string> contractions = new Dictionary<string, string>();
        public static Dictionary<string, string> leftovers = new Dictionary<string, string>();
        public static Dictionary<string, string> slang = new Dictionary<string, string>();
        public static string Convert(string text)
        {
            contractions = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "contractions_dict.json")));
            leftovers = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "leftovers_dict.json")));
            slang = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "slang_dict.json")));

            contractions = contractions.ToDictionary(entry => entry.Key.ToLower(), entry => entry.Value.ToLower());
            leftovers = leftovers.ToDictionary(entry => entry.Key.ToLower(), entry => entry.Value.ToLower());
            slang = slang.ToDictionary(entry => entry.Key.ToLower(), entry => entry.Value.ToLower());

            string[] months = new string[]
            {
                "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december"
            };

            for (int i = 0; i < months.Length; i++)
            {
                contractions.Add(months[i].Substring(0, 3) + ".", months[i]);
            }

            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (contractions.ContainsKey(words[i].ToLower()))
                {
                    words[i] = contractions[words[i].ToLower()];
                }
                else if (leftovers.ContainsKey(words[i].ToLower()))
                {
                    words[i] = leftovers[words[i].ToLower()];
                }
                else if (slang.ContainsKey(words[i].ToLower()))
                {
                    words[i] = slang[words[i].ToLower()];
                }
            }
            return string.Join(" ", words);
        }
    }
}
 