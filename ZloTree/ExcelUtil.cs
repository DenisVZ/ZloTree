using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ZloTree
{
    public static class ExcelUtil
    {
        public static List<T> ReadCsv<T>(string path, string delimiter, bool hasHeaderRecord)
        {
            var listBad = new List<string>();

            var csv = new CsvReader(File.OpenText(
                Path.Combine(Directory.GetCurrentDirectory(), path)));

            csv.Configuration.HasHeaderRecord = hasHeaderRecord;
            csv.Configuration.HeaderValidated = null;
            csv.Configuration.Delimiter = delimiter;
            csv.Configuration.MissingFieldFound = null;
            csv.Configuration.AllowComments = true;

            csv.Configuration.BadDataFound =
                context => { listBad.Add(context.RawRecord); };

            var i = csv.GetRecords<T>();

            var items = i.ToList();

            return items;
        }
    }
}
