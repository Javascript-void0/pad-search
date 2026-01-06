using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PAD_Search.Models
{
    internal class Skill
    {
        [JsonPropertyName("id")]
        private int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        private string Description { get; set; }

        // TODO: Enum?
        [JsonPropertyName("type")]
        private int Type { get; set; }

        [JsonPropertyName("maxLevel")]
        private int MaxLevel { get; set; }

        [JsonPropertyName("initialCooldown")]
        private int InitialCooldown { get; set; }

        //"unk": "",
        //"params": [
        //    1,
        //    1000
        //]

    }
}
