using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullNameSplit
{
    public class NamePart : FullNamePart
    {
        private IEnumerable<string> dictionary;

        public NamePart(IList<string> dictionary)
        {
            this.dictionary = dictionary.Select(s => s.ToUpperInvariant());
        }

        public override IList<string> GetPart(string fullName)
        {
            
            //split
            var parts = Tokenize(fullName);
            
            return GetPart(fullName, parts);
        }

        public override IList<string> GetPart(string fullName, IEnumerable<string> tokens)
        {

            IList<string> Names = new List<string>();

            //check each part
            foreach (var p in tokens)
            {
                if (IsName(p))
                {
                    Names.Add(p);
                }
            }

            return Names;
        }


        private bool IsName(string namePart)
        {
            var upperInvariantPart = namePart.ToUpperInvariant();

            foreach (var name in dictionary)
            {
                if(upperInvariantPart == name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
