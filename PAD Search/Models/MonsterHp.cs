using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PAD_Search.Models
{
    public class MonsterHp
    {
        [JsonPropertyName("min")]
        public int Min { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        [JsonPropertyName("scale")]
        public float Scale { get; set; }
    }
}
