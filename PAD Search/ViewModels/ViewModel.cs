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
    public class ViewModel : INotifyPropertyChanged
    {
        private static List<Monster> monsters = new List<Monster>(); // list of everything
        private static List<Monster> matched = new List<Monster>(); // for everything that matches search query
        private static List<Monster> defaultLoaded = new List<Monster>();
        private const byte maxLoaded = 50;
        private static string lastSearch = "";

        public Filter filter;

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
            filter = new Filter();
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
            matched = monsters;
        }

        public List<Monster> FilterSet(List<Monster> set)
        {
            if (!lastSearch.Equals(""))
                set = set.Where(x => x.Name.ToLower().Contains(filter.Search.ToLower()) ||
                               ("" + x.Id).Equals(filter.Search))
                         .ToList();

            Debug.WriteLine(set.Count);

            if (filter.Attr1 != null) set = set.Where(x => x.Attrs[0] == filter.Attr1).ToList();
            if (filter.Attr2 != null) set = set.Where(x => x.Attrs.Count > 1 && x.Attrs[1] == filter.Attr2).ToList();
            if (filter.Attr3 != null) set = set.Where(x => x.Attrs.Count > 2 && x.Attrs[2] == filter.Attr3).ToList();
            if (filter.Type != null)  set = set.Where(x => x.Types.Contains((int)filter.Type)).ToList();

            Debug.WriteLine(set.Count);
            return set;
        }

        public void FilterMonsters(int? attr1, int? attr2, int? attr3, int? type, List<int> awakenings)
        {
            filter.Attr1 = attr1;
            filter.Attr2 = attr2;
            filter.Attr3 = attr3;
            filter.Type = type;
            filter.Awawkenings = awakenings;

            matched = FilterSet(monsters);
            LoadedMonsters = new ObservableCollection<Monster>(matched.Take(maxLoaded).ToList());
        }

        public void SearchMonsters(string input)
        {
            if (input.Contains(lastSearch))
                matched = FilterSet(matched);
            else
                matched = FilterSet(monsters);

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
