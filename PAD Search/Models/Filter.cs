using System;
using System.Collections.Generic;
using System.Text;

namespace PAD_Search.Models
{
    public class Filter
    {
        public string Search { get; set; }
        public int? Attr1 { get; set; }
        public int? Attr2 { get; set; }
        public int? Attr3 { get; set; }
        public int? Type {  get; set; }
        public List<int> Awawkenings { get; set; }
    }
}
