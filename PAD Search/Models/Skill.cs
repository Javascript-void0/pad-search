using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PAD_Search.Models
{
    public class Skill
    {
        [JsonPropertyName("id")]
        private int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        // TODO: Enum?
        // 233 -> skill evolves stage 1 -> stage 2 -> stage 1
        // 232 -> skill evolves stage 1 -> stage 2
        // 202 -> changes form
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("maxLevel")]
        public int MaxLevel { get; set; }

        [JsonPropertyName("initialCooldown")]
        public int InitialCooldown { get; set; }

        //"unk": "",
        //"params": [
        //    1,
        //    1000
        //]

    }
}
