using FFImageLoading.Transformations;
using FFImageLoading.Work;
using PAD_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;
using Xamarin.Forms;

namespace PAD_Search.Models
{
    internal class Monster
    {
        public HtmlWebViewSource Test
        {
            get
            {
                var html = @"
<html>
    <body>
        <style>
            :root { --size: 15 }
            body { background-color: #1d1d1d }
            span { font-size: var(--size); color: white }
            .icon {
                width: var(--size);
                height: var(--size);
                background-image: url('icon-orbs.png');
                background-size: 200% 1000%;
                background-position: 0% 22.222222%;
                background-repeat: none;
                aspect-ratio: 50 / 50;
                display: inline-block;
                color: transparent;
            }
        </style>
        <span>" + new Random().Next(1, 100) + @"Removes {locks},\nchanges </span>
        <span class=""icon"">.</span>
        <span>{Jammers}{Poison}{Lethal Poison}{Bombs} to {Water}</span>
    </body>
</html>";
                var source = new HtmlWebViewSource();
                source.BaseUrl = "file:///android_asset/";
                source.Html = html;
                return source;
            }
        }

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
        public string ActiveSkillName { get { return skills[ActiveSkillId].Name; } }
        public string ActiveSkillDescription { get { return skills[ActiveSkillId].Description; } }
        public int ActiveSkillMaxLevel { get { return skills[ActiveSkillId].MaxLevel; } }
        public int ActiveSkillCooldown { get { return skills[ActiveSkillId].InitialCooldown - ActiveSkillMaxLevel + 1; } }

        public bool HasLeaderSkill { get { return LeaderSkillId != 0; } }
        public string LeaderSkillName { get { return skills[LeaderSkillId].Name; } }
        public string LeaderSkillDescription { get { return skills[LeaderSkillId].Description; } }
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

        public bool HasType2 { get { return Types.Count >= 2; } }

        public bool HasType3 { get { return Types.Count >= 3; } }

        private Rectangle typeDefaultBounds = new Rectangle(1, 1, 2, 16);
        public Rectangle Type1Bounds { get { return TypeBounds(1); } }
        public Rectangle Type2Bounds { get { return TypeBounds(2); } }
        public Rectangle Type3Bounds { get { return TypeBounds(3); } }
        private Rectangle TypeBounds(int i)
        {
            if (Types.Count < i) return typeDefaultBounds;
            var x = 0;
            var y = Types[i - 1];
            if (y == 12 || y == 9) x = 1;
            return new Rectangle(x, y / 15.0, 2, 16);

        }


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

        [JsonPropertyName("awakenings")]
        public List<int> Awakenings { get; set; }
        public bool HasAwoken1 { get { return Awakenings.Count >= 1; } }
        public bool HasAwoken2 { get { return Awakenings.Count >= 2; } }
        public bool HasAwoken3 { get { return Awakenings.Count >= 3; } }
        public bool HasAwoken4 { get { return Awakenings.Count >= 4; } }
        public bool HasAwoken5 { get { return Awakenings.Count >= 5; } }
        public bool HasAwoken6 { get { return Awakenings.Count >= 6; } }
        public bool HasAwoken7 { get { return Awakenings.Count >= 7; } }
        public bool HasAwoken8 { get { return Awakenings.Count >= 8; } }
        public bool HasAwoken9 { get { return Awakenings.Count >= 9; } }
        private Rectangle awokenDefault = new Rectangle(1, 1, 3, 142);
        public Rectangle Awoken1Bounds { get { return AwokenBounds(1); } }
        public Rectangle Awoken2Bounds { get { return AwokenBounds(2); } }
        public Rectangle Awoken3Bounds { get { return AwokenBounds(3); } }
        public Rectangle Awoken4Bounds { get { return AwokenBounds(4); } }
        public Rectangle Awoken5Bounds { get { return AwokenBounds(5); } }
        public Rectangle Awoken6Bounds { get { return AwokenBounds(6); } }
        public Rectangle Awoken7Bounds { get { return AwokenBounds(7); } }
        public Rectangle Awoken8Bounds { get { return AwokenBounds(8); } }
        public Rectangle Awoken9Bounds { get { return AwokenBounds(9); } }

        private Rectangle AwokenBounds(int i)
        {
            if (Awakenings.Count < i) return awokenDefault;
            var x = 0;
            var y = Awakenings[i - 1];
            if (AwokenIdConverter.HasNAVersion(y)) x = 1;
            return new Rectangle(x / 2.0, y / 141.0, 3, 142);
        }

        [JsonPropertyName("superAwakenings")]
        public List<int> SuperAwakenings { get; set; }
        public bool HasSuperAwoken1 { get { return SuperAwakenings.Count >= 1; } }
        public bool HasSuperAwoken2 { get { return SuperAwakenings.Count >= 2; } }
        public bool HasSuperAwoken3 { get { return SuperAwakenings.Count >= 3; } }
        public bool HasSuperAwoken4 { get { return SuperAwakenings.Count >= 4; } }
        public bool HasSuperAwoken5 { get { return SuperAwakenings.Count >= 5; } }
        public bool HasSuperAwoken6 { get { return SuperAwakenings.Count >= 6; } }
        public bool HasSuperAwoken7 { get { return SuperAwakenings.Count >= 7; } }
        public bool HasSuperAwoken8 { get { return SuperAwakenings.Count >= 8; } }
        public bool HasSuperAwoken9 { get { return SuperAwakenings.Count >= 9; } }
        public bool HasSuperAwoken10 { get { return SuperAwakenings.Count >= 10; } }
        public Rectangle SuperAwoken1Bounds { get { return SuperAwokenBounds(1); } }
        public Rectangle SuperAwoken2Bounds { get { return SuperAwokenBounds(2); } }
        public Rectangle SuperAwoken3Bounds { get { return SuperAwokenBounds(3); } }
        public Rectangle SuperAwoken4Bounds { get { return SuperAwokenBounds(4); } }
        public Rectangle SuperAwoken5Bounds { get { return SuperAwokenBounds(5); } }
        public Rectangle SuperAwoken6Bounds { get { return SuperAwokenBounds(6); } }
        public Rectangle SuperAwoken7Bounds { get { return SuperAwokenBounds(7); } }
        public Rectangle SuperAwoken8Bounds { get { return SuperAwokenBounds(8); } }
        public Rectangle SuperAwoken9Bounds { get { return SuperAwokenBounds(9); } }
        public Rectangle SuperAwoken10Bounds { get { return SuperAwokenBounds(10); } }

        private Rectangle SuperAwokenBounds(int i)
        {
            if (SuperAwakenings.Count < i) return awokenDefault;
            var x = 0;
            var y = SuperAwakenings[i - 1];
            if (y == 40 || y == 46 || y == 47 || y == 48 || y == 109) x = 1;
            return new Rectangle(x / 2.0, y / 141.0, 3, 142);
        }

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

        [JsonPropertyName("syncAwakening")]
        public int? SyncAwakening { get; set; }

        [JsonPropertyName("syncAwakeningConditions")]
        public List<SyncAwakeningCondition> SyncAwakeningConditions { get; set; }

        public bool HasSyncAwoken { get { return SyncAwakening != null; } }
        public Rectangle SyncAwokenBounds
        {
            get
            {
                if (SyncAwakening == null) return awokenDefault;
                var x = 0;
                var y = SyncAwakening;
                if (y == 40 || y == 46 || y == 47 || y == 48 || y == 109) x = 1;
                return new Rectangle(x / 2.0, (double)(y / 141.0), 3, 142);
            }
        }

        public int HideSuperAwoken { get { return SuperAwakenings.Count == 0 ? 0 : 200 + 10; } }
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
