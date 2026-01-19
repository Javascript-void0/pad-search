using PAD_Search.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PAD_Search.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        private static List<Monster> monsters = new List<Monster>(); // list of everything
        private static List<Monster> matched = new List<Monster>(); // for everything that matches search query
        private static List<Monster> defaultLoaded = new List<Monster>();
        private const byte maxLoaded = 50;
        private static string lastSearch = "";

        private ObservableCollection<Monster> _loadedMonsters; // for subset of matches that are loaded (first 50)
        public ObservableCollection<Monster> LoadedMonsters
        {
            get { return _loadedMonsters; }
            set
            {
                if (_loadedMonsters != value)
                {
                    _loadedMonsters = value;
                    if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("LoadedMonsters"));
                }
            }
        }

        private string jsonMonFileName = "PAD_Search.PADDashFormation.monsters_info.mon_en.json";
        private string jsonSkillFileName = "PAD_Search.PADDashFormation.monsters_info.skill_en.json";

        public ViewModel()
        {
            // Load Cards
            monsters = JsonData.ReadJsonFromFile<Monster>(jsonMonFileName);
            Monster.skills = JsonData.ReadJsonFromFile<Skill>(jsonSkillFileName);

            // clean up data
            monsters.RemoveAt(0);
            //skills.RemoveAt(0);
            //skills.RemoveAll(skill => skill.Name.Equals("無し"));
            //skills.RemoveAll(skill => skill.Name.Equals(""));


            for (int i = 0; i < maxLoaded; i++)
                defaultLoaded.Add(monsters[i]);
            //defaultLoaded = monsters;

            LoadedMonsters = new ObservableCollection<Monster>(defaultLoaded);
        }

        public List<Monster> matchInput(List<Monster> set, string input)
        {
            return new List<Monster>(
                set.Where(x => x.Name.ToLower().Contains(input.ToLower()) || 
                    ("" + x.Id).Equals(input))
            );
        }

        public void SearchForMonsters(string input)
        {
            if (input.Contains(lastSearch) && !lastSearch.Equals(""))
                matched = matchInput(matched, input);
            else
                matched = matchInput(monsters, input);

            LoadedMonsters = new ObservableCollection<Monster>( // take first 50
                matched.Take(maxLoaded).ToList()
                //matched.ToList()
            );

            lastSearch = input;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

        public void LoadDefaultMonsters()
        {
            LoadedMonsters = new ObservableCollection<Monster>(defaultLoaded);
        }

        public static Monster GetMonster(int id)
        {
            return monsters[id];
        }
    }
}
