using FFImageLoading.Work;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Xamarin.Forms;

namespace PAD_Search.Models
{
    internal class Monster
    {
        private int imageCols = 10;
        public static List<Skill> skills = new List<Skill>();
        public Rectangle ImageBounds
        {
            get
            {
                var i = Id - 1;
                var imageY = (int)Math.Floor(i%100 / (double)imageCols);
                var imageX = i % imageCols;
                return new Rectangle(imageX / 9.0, imageY / 9.0, imageCols, imageCols);
            }
        }

        public Rectangle FrameBounds
        {
            get
            {
                var frameImageX = Attrs[0];
                var frameImageY = 0;
                return new Rectangle(frameImageX / 6.0, frameImageY / 3.0, 7, 4);
            }
        }

        public Rectangle FrameBounds1
        {
            get
            {
                if (Attrs.Count < 2) return new Rectangle(1, 1, 7, 4);
                var frameImageX = Attrs[1];
                var frameImageY = 1;
                return new Rectangle(frameImageX / 6.0, frameImageY / 3.0, 7, 4);
            }
        }

        public Rectangle FrameBounds2
        {
            get
            {
                if (Attrs.Count < 3) return new Rectangle(1, 1, 7, 4);
                var frameImageX = Attrs[2];
                var frameImageY = 2;
                return new Rectangle(frameImageX / 6.0, frameImageY / 3.0, 7, 4);
            }
        }

        private string imageFilePre = "PAD_Search.Images.CARDS_"; // CARDS_001.png
        public Xamarin.Forms.ImageSource ImageFile 
        {
            get
            {
                var i = Id - 1;
                var imageFileName = imageFilePre + ("" + (int)(Math.Floor(i / 100.0) + 1)).PadLeft(3, '0') + ".PNG";
                return Xamarin.Forms.ImageSource.FromResource(imageFileName);
            }
        }

        public bool HasSub
        {
            get { return Attrs.Count >= 2; }
        }

        public bool HasSub2
        {
            get { return Attrs.Count >= 3; }
        }

        public bool HasActiveSkill
        {
            get
            {
                return ActiveSkillId != 0;
            }
        }

        public bool HasLeaderSkill
        {
            get
            {
                return LeaderSkillId != 0;
            }
        }

        public string ActiveSkillName
        {
            get
            {
                return skills[ActiveSkillId].Name;
            }
        }

        public string ActiveSkillDescription
        {
            get
            {
                return skills[ActiveSkillId].Description;
            }
        }

        public string LeaderSkillName
        {
            get
            {
                return skills[LeaderSkillId].Name;
            }
        }

        public string LeaderSkillDescription
        {
            get
            {
                return skills[LeaderSkillId].Description;
            }
        }


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
