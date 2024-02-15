using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Contraction
{
    class Program
    {
        static Dictionary<string, string> contractions = new Dictionary<string, string>();
        static Dictionary<string, string> leftovers = new Dictionary<string, string>();
        static Dictionary<string, string> slang = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            contraction = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "contractions_dict.json")));
            leftovers = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "leftovers_dict.json")));
            slang = JsonConvert.DeserializeObject<Dictionary<string, string>>(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data", "slang_dict.json")));

            string[] months = new string[]
            {
                "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december"
            }
        }
    }
}
 