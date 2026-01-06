using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PAD_Search.Models
{
    internal class Monster
    {
        // TODO: Enum?
        [JsonPropertyName("attrs")]
        public List<int> Attrs { get; set; }

        // TODO: Enum?
        [JsonPropertyName("types")]
        public List<int> Types { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isUltEvo")]
        public bool IsUltEvo { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("maxLevel")]
        public int MaxLevel { get; set; }

        //[JsonPropertyName("feedExp")]

        [JsonPropertyName("isEmpty")]
        public bool IsEmpty { get; set; }
        //"sellPrice": 700,
        [JsonPropertyName("hp")]
        public MonsterHp Hp { get; set; }

        [JsonPropertyName("atk")]
        public MonsterAtk Atk { get; set; }

        [JsonPropertyName("rcv")]
        public MonsterRcv Rcv { get; set; }

        //"exp": {
        //    "min": 0,
        //    "max": 1500000,
        //    "scale": 2.5
        //},

        [JsonPropertyName("activeSkillId")]
        public int ActiveSkillId { get; set; }

        [JsonPropertyName("leaderSkillId")]
        public int LeaderSkillId { get; set; }

        [JsonPropertyName("evoBaseId")]
        public int EvoBaseId { get; set; }

        [JsonPropertyName("evoMaterials")]
        public List<int> EvoMaterials{ get; set; }

        [JsonPropertyName("unevoMaterials")]
        public List<int> UnevoMaterials{ get; set; }

        // TODO: Enum?
        [JsonPropertyName("awakenings")]
        public List<int> Awakenings { get; set; }

        // TODO: Enum?
        [JsonPropertyName("superAwakenings")]
        public List<int> SuperAwakenings { get; set; }

        [JsonPropertyName("evoRootId")]
        public int EvoRootId { get; set; }

        // TODO: Enum?
        [JsonPropertyName("seriesId")]
        public int SeriesID { get; set; }

        //"sellMP": 1,

        [JsonPropertyName("latentAwakeningId")]
        public int LatentAwakeningId { get; set; }

        [JsonPropertyName("collabId")]
        public int CollabID { get; set; }

        //"flags": 2,

        [JsonPropertyName("canAssist")]
        public bool CanAssist { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        //"stackable": false,

        [JsonPropertyName("is8Latent")]
        public bool Is8Latent { get; set; }

        //"skillBanner": false,

        [JsonPropertyName("altName")]
        public List<string> AltName { get; set; }

        //"limitBreakIncr": 0,
        //"voiceId": 0,
        //"orbSkinOrBgmId": 0,

        //"specialAttribute": "",

        [JsonPropertyName("searchFlags")]
        public List<uint> SearchFlags { get; set; }

        //"gachaGroupsFlag": 0,
        //"badgeId": 0,
        //"otLangName": {
        //    "ja": "ティラ",
        //    "cht": "提拉",
        //    "chs": "提拉",
        //    "ko": "티라"
        //},
        //"otTags": [
        //    "御三家"
        //]

    }
}
