using PAD_Search.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PAD_Search.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private static List<Monster> monsters = new List<Monster>(); // list of everything
        private static List<Monster> searchMatched = new List<Monster>(); // for everything that matches search query
        private static List<Monster> filterMatched = new List<Monster>(); // for everything that matches search query
        private static List<Monster> defaultLoaded = new List<Monster>();
        private const byte maxLoaded = 50;
        private static string lastSearch = "";
        private static Filter lastFilter = new Filter();

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
            filterMatched = monsters;
            searchMatched = monsters;
        }

        public void FilterMonsters(Filter filter)
        {
            List<Monster> set = filterMatched;
            if (!filter.Equals(lastFilter)) // filter changed
            {
                set = monsters;
                if (filter.Attr1 != null) set = set.Where(x => x.Attrs[0] == filter.Attr1).ToList();
                if (filter.Attr2 != null) set = set.Where(x => x.Attrs.Count > 1 && x.Attrs[1] == filter.Attr2).ToList();
                if (filter.Attr3 != null) set = set.Where(x => x.Attrs.Count > 2 && x.Attrs[2] == filter.Attr3).ToList();
                if (filter.Type != null)  set = set.Where(x => x.Types.Contains((int)filter.Type)).ToList();
                filterMatched = set;
            }

            Debug.WriteLine(set.Count);
            lastFilter = filter;

            // apply search
            LoadedMonsters = new ObservableCollection<Monster>
                (
                    set.Where(x => searchMatched.Contains(x))
                       .Take(maxLoaded)
                       .ToList()
                );
        }

        public void ResetSearch()
        {
            LoadedMonsters = new ObservableCollection<Monster>(
                filterMatched);
        }

        public void SearchMonsters(string search)
        {
            List<Monster> set = search.Contains(lastSearch) ? searchMatched : monsters;

            if (!search.Equals(lastSearch))
            {
                set = set.Where(x => x.Name.ToLower().Contains(search.ToLower()) ||
                                         ("" + x.Id).Equals(search))
                                   .ToList();
                searchMatched = set;
            }

            Debug.WriteLine(set.Count);
            lastSearch = search;

            // apply filters
            LoadedMonsters = new ObservableCollection<Monster>(
                set.Where(x => filterMatched.Contains(x))
                   .Take(maxLoaded)
                   .ToList()
                );

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
