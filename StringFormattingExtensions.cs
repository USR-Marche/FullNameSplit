using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FullNameSplit
{
    public static class StringFormattingExtensions
    {
        public static string MultipleStrings2One(this string input)
        {
            string pattern = "\\s+";
            string replacement = " ";
            Regex rgx = new Regex(pattern);
            return rgx.Replace(input, replacement);
        }

        public static string NormalizeSurnames(this string full)
        {
            full = full.Replace("De ", "De#", StringComparison.InvariantCulture);
            full = full.Replace("D' ", "D'#", StringComparison.InvariantCulture);
            full = full.Replace("Del ", "Del#", StringComparison.InvariantCulture);
            full = full.Replace("Di ", "Di#", StringComparison.InvariantCulture);
            full = full.Replace("Da ", "Da#", StringComparison.InvariantCulture);
            full = full.Replace("El ", "El#", StringComparison.InvariantCulture);

            return full;
        }

    }
}
