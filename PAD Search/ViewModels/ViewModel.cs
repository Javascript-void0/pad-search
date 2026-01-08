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
        private List<Monster> monsters = new List<Monster>();
        private List<Monster> defaultLoaded = new List<Monster>();

        private ObservableCollection<Monster> _loadedMonsters;
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

        private string jsonMonFileName = "PAD_Search.Data.mon_en.json";
        private string jsonSkillFileName = "PAD_Search.Data.skill_en.json";

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

            for (int i = 0; i < 50; i++)
                defaultLoaded.Add(monsters[i]);
            LoadedMonsters = new ObservableCollection<Monster>(defaultLoaded);
        }

        public void SearchForMonsters(string input)
        {
            LoadedMonsters = new ObservableCollection<Monster>(
                monsters.Where( x => 
                            x.Name.ToLower().Contains(input.ToLower()) || 
                            ("" + x.Id).Equals(input))
                        .Take(50) // limit to first 50
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
    }
}
