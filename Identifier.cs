using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FullNameSplit
{
    public class Identifier
    {

        public IList<string> FullNames { get; set; }
        public NamePart NameDictionary { get; set; }
        public NamePart SurnameDictionary { get; set; }
        public Func<string[], string[], string[], string[], string, Tuple<string, string>> ChoosingStrategy { get; set; }
        public string Separator { get; set; }

        public List<Tuple<string, string, string>> Elaborate()
        {
            var result = new List<Tuple<string, string, string>>();

            foreach(var fn in FullNames)
            {
                var tokens = FullNamePart.Tokenize(fn).ToArray();
                var surnames = SurnameDictionary.GetPart(fn, tokens).ToArray();
                var names = NameDictionary.GetPart(fn, tokens).Except(surnames).ToArray();
                var unclassified = tokens.Except(names).Except(surnames).ToArray();

                var t = ChoosingStrategy(names, surnames, unclassified, tokens, Separator);

                result.Add(Tuple.Create(fn, t.Item1, t.Item2));
            }

            return result;
        }
    }
}