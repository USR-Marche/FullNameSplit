using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace FullNameSplit
{
    public static class DictionaryBuilder
    {
        public static async System.Threading.Tasks.Task<IList<string>> FromFileAsync(string path)
        {
            var lines = await File.ReadAllLinesAsync(path);
            var lineList = lines.Select(s => s.MultipleStrings2One()).ToList();

            return lineList;
        }
    }
}
