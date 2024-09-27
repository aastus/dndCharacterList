using System.ComponentModel.DataAnnotations;

namespace dndCharacterList.Models
{
    public class AbilityScores
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public AbilityScores()
        {
            Strength = 10;
            Dexterity = 10;
            Constitution = 10;
            Intelligence = 10;
            Wisdom = 10;
            Charisma = 10;
        }
    }
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Modifier { get; set; }
    }
    public class CharacterClassInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PrimaryAbility { get; set; }
        public string SavingThrowProficiencies { get; set; }
        public string ArmorAndWeaponProficiencies { get; set; }
        public string PossibleHintName { get; set; }
        public Dictionary<string, int> StatBonuses { get; set; }
        public List<string> AvailableAbilities { get; set; }
        public List<string> AvailableSpells { get; set; }
        public int Level { get; set; }  // Додали рівень для кожного класу

        public CharacterClassInfo(
                string name,
                string description,
                string picture,
                string primaryAbility,
                string savingThrowProficiencies,
                string armorAndWeaponProficiencies,
                string possibleHintName,
                Dictionary<string, int> statBonuses,
                List<string> availableAbilities,
                List<string> availableSpells,
                int level = 1)  // За замовчуванням рівень 1
            {
                Name = name;
                Description = description;
                Picture = picture;
                PrimaryAbility = primaryAbility;
                SavingThrowProficiencies = savingThrowProficiencies;
                ArmorAndWeaponProficiencies = armorAndWeaponProficiencies;
                PossibleHintName = possibleHintName;
                StatBonuses = statBonuses;
                AvailableAbilities = availableAbilities;
                AvailableSpells = availableSpells;
                Level = level;
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public CharacterClassInfo Classes { get; set; }

        public List<CharacterClassInfo> Languages { get; set; }  // Множина класів
        public RaceInfo Race { get; set; }
        public int HitPoints { get; set; }

        public int Spead { get; set; }

        public Character(string name, CharacterClassInfo classes, RaceInfo race)
        {
            Name = name;
            Classes = classes;
            Race = race;
        }

        // Метод для підрахунку загальних бонусів від усіх класів
        public Dictionary<string, int> GetTotalStatBonuses()
        {
            Dictionary<string, int> totalBonuses = new Dictionary<string, int>();

            
            foreach (var bonus in Classes.StatBonuses)
            {
                if (totalBonuses.ContainsKey(bonus.Key))
                {
                    totalBonuses[bonus.Key] += bonus.Value;
                }
                else
                {
                    totalBonuses[bonus.Key] = bonus.Value;
                }
            }
           

            return totalBonuses;
        }

        // Метод для об'єднання всіх здібностей
        public List<string> GetAllAbilities()
        {
            List<string> allAbilities = new List<string>();

  
                allAbilities.AddRange(Classes.AvailableAbilities);
         

            return allAbilities;
        }

        // Метод для підрахунку загального рівня персонажа
        public int GetTotalLevel()
        {
            int totalLevel = 0;
            
                totalLevel += Classes.Level;
            
            return totalLevel;
        }
    }


    public class RaceInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public string Size { get; set; }
        public Dictionary<string, int> StatBonuses { get; set; }
        public List<string> AvailableAbilities { get; set; }

        public RaceInfo(
            string name,
            string description,
            string picture,
            Dictionary<string, int> statBonuses,
            List<string> availableAbilities)
        {
            Name = name;
            Description = description;
            Picture = picture;
            StatBonuses = statBonuses;
            AvailableAbilities = availableAbilities;
        }
    }


    //public class Character
    //{
    //    public string Name { get; set; }
    //    public Race Race { get; set; }
    //    public CharacterClass Class { get; set; }
    //    public AbilityScores Abilities { get; set; }
    //    public List<Skill> Skills { get; set; }
    //    public int Level { get; set; }
    //    public List<string> Equipment { get; set; }

    //    public Character(string name, Race race, CharacterClass characterClass)
    //    {
    //        Name = name;
    //        Race = race;
    //        Class = characterClass;
    //        Abilities = new AbilityScores();
    //        Skills = new List<Skill>();
    //        Equipment = new List<string>();
    //        Level = 1; // Default starting level
    //    }

    //    public void AddSkill(Skill skill)
    //    {
    //        Skills.Add(skill);
    //    }

    //    public void EquipItem(string item)
    //    {
    //        Equipment.Add(item);
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Name}, Level {Level} {Race} {Class}\n" +
    //               $"Abilities: STR {Abilities.Strength}, DEX {Abilities.Dexterity}, CON {Abilities.Constitution}, " +
    //               $"INT {Abilities.Intelligence}, WIS {Abilities.Wisdom}, CHA {Abilities.Charisma}\n" +
    //               $"Skills: {string.Join(", ", Skills.Select(s => s.Name))}\n" +
    //               $"Equipment: {string.Join(", ", Equipment)}";
    //    }
    //}
    }

