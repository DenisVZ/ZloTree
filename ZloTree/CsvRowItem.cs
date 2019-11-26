using CsvHelper.Configuration.Attributes;
using System;

namespace ZloTree
{
    public class CsvRowItem
    {
        [Index(0)]
        public string A { get; set; }
        [Index(1)]
        public string B { get; set; }
        [Index(2)]
        public string C { get; set; }
        [Index(3)]
        public string D { get; set; }
        
    }
}
