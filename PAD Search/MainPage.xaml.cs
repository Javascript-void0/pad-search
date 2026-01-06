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

        private int numCols = 5;
        private int gridSize = 75;

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            LoadCards();

            for (var i = 0; i < 100; i++)
            //for (var i = 0; i < 0; i++)
            {
                var monster = monsters[i];
                //Label test = new Label()
                //{
                //Text = "" + monster.Name + " " + monster.Id,
                //BackgroundColor = Color.Red
                //};
                //grid.Children.Add(test);

                //if (i % numCols == 0)
                //grid.RowDefinitions.Add(new RowDefinition { Height = 70 });

                Frame frame = new Frame()
                {
                    WidthRequest = gridSize,
                    HeightRequest = gridSize,
                    Padding = 0,
                    CornerRadius = 10
                };
                var gridY = (int)Math.Floor(i / (double)numCols);
                var gridX = i % numCols;
                Grid.SetRow(frame, gridY);
                Grid.SetColumn(frame, gridX);

                var imageY = (int)Math.Floor(i / (double)imageCols);
                var imageX = i % imageCols;

                AbsoluteLayout crop = new AbsoluteLayout() { BackgroundColor = new Color(0.2667, 0.2667, 0.2667) };
                Image image = new Image()
                {
                    Aspect = Aspect.AspectFill
                };
                image.Source = ImageSource.FromResource("PAD_Search.Images.CARDS_001.PNG", typeof(MainPage).GetTypeInfo().Assembly);
                AbsoluteLayout.SetLayoutBounds(image, new Rectangle(imageX / 9.0, imageY / 9.0, 10.0, 10.0));
                AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);

                frame.Content = crop;
                crop.Children.Add(image);

                grid.Children.Add(frame);

                if (i % numCols == 0)
                    grid.RowDefinitions.Add(new RowDefinition { Height = gridSize });

                frame.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() => System.Diagnostics.Debug.WriteLine("EFOIEJF"))
                });



                // Frame
            }
        }

        private string jsonMonFileName = "PAD_Search.Data.mon_en.json";
        private string jsonSkillFileName = "PAD_Search.Data.skill_en.json";
        private string imageFileName = "PAD_Search.Images.CARDS_"; // CARDS_001.png
        private int imageCols = 10;

        private List<Monster> monsters = new List<Monster>();
        private List<Skill> skills = new List<Skill>();
        static List<T> ReadJsonFromFile<T>(string filePath)
        {
            //string json = await File.ReadAllTextAsync(filePath);
            //string json = File.ReadAllText(filePath);
            //return JsonSerializer.Deserialize<List<Monster>>(json);

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

            //System.Diagnostics.Debug.WriteLine(monsterJson.Count);
            //System.Diagnostics.Debug.WriteLine(skillJson.Count);
        }
    }
}
