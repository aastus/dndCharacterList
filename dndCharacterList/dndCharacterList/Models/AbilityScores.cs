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
            // Initialize all scores to 10 by default
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
    public enum CharacterClass
    {
        Fighter,
        Wizard,
        Rogue,
        Cleric,
        Ranger,
        Barbarian,
        Druid,
        Bard,
        Paladin,
        Sorcerer,
        Warlock
    }

    public enum Race
    {
        Human,
        Elf,
        Dwarf,
        Halfling,
        Dragonborn,
        Tiefling,
        Gnome
    }

    public class Character
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public CharacterClass Class { get; set; }
        public AbilityScores Abilities { get; set; }
        public List<Skill> Skills { get; set; }
        public int Level { get; set; }
        public List<string> Equipment { get; set; }

        public Character(string name, Race race, CharacterClass characterClass)
        {
            Name = name;
            Race = race;
            Class = characterClass;
            Abilities = new AbilityScores();
            Skills = new List<Skill>();
            Equipment = new List<string>();
            Level = 1; // Default starting level
        }

        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }

        public void EquipItem(string item)
        {
            Equipment.Add(item);
        }

        public override string ToString()
        {
            return $"{Name}, Level {Level} {Race} {Class}\n" +
                   $"Abilities: STR {Abilities.Strength}, DEX {Abilities.Dexterity}, CON {Abilities.Constitution}, " +
                   $"INT {Abilities.Intelligence}, WIS {Abilities.Wisdom}, CHA {Abilities.Charisma}\n" +
                   $"Skills: {string.Join(", ", Skills.Select(s => s.Name))}\n" +
                   $"Equipment: {string.Join(", ", Equipment)}";
        }
    }
}
