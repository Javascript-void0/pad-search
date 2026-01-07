using FFImageLoading.Forms;
using PAD_Search.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PAD_Search
{
    public partial class MainPage : ContentPage
    {

        private static int numCols = 5;
        private static int gridSize = 60;
        //private List<Frame> frames = new List<Frame>();
        //private List<bool> imageLoaded = new List<bool>();
        private static int totalMonsters = 600;
        private static int totalRows = (int)Math.Ceiling((double)totalMonsters / numCols);

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            LoadCards();

            for (var i = 0; i < totalMonsters; i++)
            //for (var i = 0; i < 0; i++)
            {
                var monster = monsters[i];

                Frame frame = new Frame()
                {
                    WidthRequest = gridSize,
                    HeightRequest = gridSize,
                    Padding = 0,
                    CornerRadius = 4
                };
                var gridY = (int)Math.Floor(i / (double)numCols);
                var gridX = i % numCols;
                Grid.SetRow(frame, gridY);
                Grid.SetColumn(frame, gridX);

                frame.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() => System.Diagnostics.Debug.WriteLine("ID " + monster.Id + ": " + gridY))
                });


                //if (i < 200)
                //{
                    

                var imageY = (int)Math.Floor(i%100 / (double)imageCols);
                var imageX = i % imageCols;

                AbsoluteLayout crop = new AbsoluteLayout() { BackgroundColor = new Color(0.2667, 0.2667, 0.2667) };
                var imageFileName = imageFilePre + ("" + (int)(Math.Floor(i / 100.0) + 1)).PadLeft(3, '0') + ".PNG";
                CachedImage image = new CachedImage()
                {
                    Aspect = Aspect.AspectFill,
                    Source = ImageSource.FromResource(imageFileName),
                    DownsampleToViewSize = true,
                    BitmapOptimizations = true,
                    IsOpaque = true,
                };
                AbsoluteLayout.SetLayoutBounds(image, new Rectangle(imageX / 9.0, imageY / 9.0, 10, 10));
                AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);

                frame.Content = crop;
                crop.Children.Add(image);


                if (i % numCols == 0)
                    grid.RowDefinitions.Add(new RowDefinition { Height = gridSize });




                // Frame
                var attrs = monster.Attrs;
                for (var j = 0; j < attrs.Count; j++)
                {
                    var attr = attrs[j];
                    CachedImage attrFrame = new CachedImage()
                    {
                        Aspect = Aspect.AspectFill,
                        Source = ImageSource.FromResource("PAD_Search.Images.CARDFRAME2.png"),
                        DownsampleToViewSize = true,
                        BitmapOptimizations = true,
                        IsOpaque = true
                    };

                    var frameImageX = attrs[j];
                    var frameImageY = j;

                    AbsoluteLayout.SetLayoutBounds(attrFrame, new Rectangle(frameImageX/6.0, frameImageY/3.0, 7, 4));
                    AbsoluteLayout.SetLayoutFlags(attrFrame, AbsoluteLayoutFlags.All);

                    crop.Children.Add(attrFrame);
                //}
                }

                //frames.Add(frame);
                //imageLoaded.Add(false);
                grid.Children.Add(frame);
            }
        }



        private string jsonMonFileName = "PAD_Search.Data.mon_en.json";
        private string jsonSkillFileName = "PAD_Search.Data.skill_en.json";
        private string imageFilePre = "PAD_Search.Images.CARDS_"; // CARDS_001.png
        private int imageCols = 10;

        private List<Monster> monsters = new List<Monster>();
        private List<Skill> skills = new List<Skill>();
        static List<T> ReadJsonFromFile<T>(string filePath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            List<T> list = new List<T>();

            using (Stream stream = assembly.GetManifestResourceStream(filePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                list = JsonSerializer.Deserialize<List<T>>(result);
            }
            return list;
        }

        private void LoadCards()
        {
            monsters = ReadJsonFromFile<Monster>(jsonMonFileName);
            skills= ReadJsonFromFile<Skill>(jsonSkillFileName);

            // clean up data
            monsters.RemoveAt(0);
            skills.RemoveAt(0);
            skills.RemoveAll(skill => skill.Name.Equals("無し"));
            skills.RemoveAll(skill => skill.Name.Equals(""));
        }
    }
}
