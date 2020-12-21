using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FullNameSplit
{
    public abstract class FullNamePart
    {
        public abstract IList<string> GetPart(string fullName);
        public abstract IList<string> GetPart(string fullName, IEnumerable<string> tokens);

        public static IEnumerable<string> Tokenize(string fullName)
        {

            var ti = new CultureInfo("it-IT", false).TextInfo;
            var full = ti.ToTitleCase(fullName.Trim().ToLowerInvariant());

            full = full.MultipleStrings2One();
            full = full.NormalizeSurnames();

            var tokens = full.Split(" ");

            return tokens;
        }

    }
}
