using FFImageLoading.Transformations;
using FFImageLoading.Work;
using PAD_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Xamarin.Forms;

namespace PAD_Search.Models
{
    public class Monster
    {
        private int imageCols = 10;
        public static List<Skill> skills = new List<Skill>();
        private Rectangle frameDefaultBounds = new Rectangle(1, 1, 7, 4);
        // OLD
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

        public List<ITransformation> ImageTransform
        {
            get
            {
                var i = Id - 1;
                var row = (int)Math.Floor(i%100 / (double)imageCols);
                var col = i % imageCols;
                var centeredRow = -(5 - row);
                var centeredCol = -(5 - col);

                var relativeCellSize = 0.099609375; // (96 + 6) / 1024
                var relativeCenterOffset = 0.046875; // (1024 / 2) / 96
                var yOffset = relativeCellSize * centeredRow + relativeCenterOffset;
                var xOffset = relativeCellSize * centeredCol + relativeCenterOffset;

                var zoom = 10.666667; // 1024 / 96
                return new List<ITransformation>
                {
                    new CropTransformation(zoom, xOffset, yOffset, 1f, 1f)
                };
            }
        }

        public Rectangle FrameBounds1 { get { return FrameBounds(1); } }
        public Rectangle FrameBounds2 { get { return FrameBounds(2); } }
        public Rectangle FrameBounds3 { get { return FrameBounds(3); } }
        private Rectangle FrameBounds(int i)
        {
            if (Attrs.Count < i) return frameDefaultBounds;
            var frameImageX = Attrs[i - 1];
            var frameImageY = i - 1;
            return new Rectangle(frameImageX / 6.0, frameImageY / 3.0, 7, 4);
        }

        private string imageFilePre = "PAD_Search.PADDashFormation.images.cards_en.CARDS_"; // CARDS_001.png
        public Xamarin.Forms.ImageSource ImageFile 
        {
            get
            {
                var i = Id - 1;
                var imageFileName = imageFilePre + ("" + (int)(Math.Floor(i / 100.0) + 1)).PadLeft(3, '0') + ".PNG";
                return Xamarin.Forms.ImageSource.FromResource(imageFileName);
            }
        }

        public bool HasSub2 { get { return Attrs.Count >= 2; } }
        public bool HasSub3 { get { return Attrs.Count >= 3; } }

        public bool HasActiveSkill { get { return ActiveSkillId != 0; } }
        public Skill ActiveSkill { get { return skills[ActiveSkillId]; } }
        public List<Skill> ActiveSkillLine
        {
            get
            {
                int skillType = ActiveSkill.Type;
                if (skillType != 232 && skillType != 233)
                    return new List<Skill>() { ActiveSkill };

                List<Skill> line = new List<Skill>();
                foreach (int skillId in ActiveSkill.Params)
                    line.Add(skills[skillId]);

                if (skillType == 233) // loop skill
                    line.Last().IsLoopSkill = true;
                        
                return line;
            }
        }

        public bool HasLeaderSkill { get { return LeaderSkillId != 0; } }
        public Skill LeaderSkill { get { return skills[LeaderSkillId]; } }
        public Color LeaderSkillAttrColor
        {
            get
            {
                switch (Attrs[0])
                {
                    case 0:
                        return Color.FromRgb(235, 131, 143);
                    case 1:
                        return Color.FromRgb(171, 209, 197);
                    case 2:
                        return Color.FromRgb(179, 165, 85);
                    case 3:
                        return Color.FromRgb(253, 209, 121);
                    case 4:
                        return Color.FromRgb(201, 165, 190);
                    default:
                        return Color.White;
                }
            }
        }


        [JsonPropertyName("attrs")]
        public List<int> Attrs { get; set; }

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

        public List<int> DecompressedAwakenings
        {
            get
            {
                List<int> awakenings = new List<int>();
                awakenings.AddRange(Awakenings);
                awakenings.AddRange(SuperAwakenings);
                return AwokenIdConverter.DecompressedAwakenings(awakenings);
            }
        }

        [JsonPropertyName("awakenings")]
        public List<int> Awakenings { get; set; }

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

        //[JsonPropertyName("searchFlags")]
        //public List<uint> SearchFlags { get; set; }

        //"gachaGroupsFlag": 0,
        //"badgeId": 0,

        [JsonPropertyName("syncAwakening")]
        public int? SyncAwakening { get; set; }

        [JsonPropertyName("syncAwakeningConditions")]
        public List<SyncAwakeningCondition> SyncAwakeningConditions { get; set; }

        public bool HasSyncAwoken { get { return SyncAwakening != null; } }
        public Rectangle SyncAwokenBounds
        {
            get
            {
                if (SyncAwakening == null) return new Rectangle(0, 0, 1, 1);
                var x = 0;
                var y = SyncAwakening;
                if (y == 40 || y == 46 || y == 47 || y == 48 || y == 109) x = 1;
                return new Rectangle(x / 2.0, (double)(y / 141.0), 3, 142);
            }
        }

        public int HideSyncAwoken { get { return SyncAwakening == null ? 0 : 40 + 2; } }


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
