using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FullNameSplit
{
    public static class FullNamesFileHandler
    {
        public async static System.Threading.Tasks.Task<IList<string>> LoadAsync(string path)
        {
            return await File.ReadAllLinesAsync(path);
        }

        public async static System.Threading.Tasks.Task WriteAsync(IList<Tuple<string, string, string>> data, string path)
        {
            using var f = new StreamWriter(path);
            //var merge = new List<Tuple<string, string, string>>();
            foreach (var r in data)
            {
                await f.WriteLineAsync($"{r.Item1},{r.Item2},{r.Item3}");
            }

            f.Flush();
            f.Close();
        }
    }
}
