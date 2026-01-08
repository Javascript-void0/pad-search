using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PAD_Search.Models
{
    class SyncAwakeningCondition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("skillLevel")]
        public int SkillLevel { get; set; }
    }
}
