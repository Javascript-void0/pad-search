using System;
using System.Collections.Generic;
using System.Text;

namespace PAD_Search.Models
{
    public class Filter
    {
        public int? Attr1 { get; set; }
        public int? Attr2 { get; set; }
        public int? Attr3 { get; set; }
        public int? Type {  get; set; }
        public List<int> Awakenings { get; set; }
        public Filter(int? attr1 = null, int? attr2 = null, int? attr3 = null, int? type = null, List<int> awakenings = null)
        {
            Attr1 = attr1;
            Attr2 = attr2;
            Attr3 = attr3;
            Type = type;
            Awakenings = awakenings;
        }
    }
}
