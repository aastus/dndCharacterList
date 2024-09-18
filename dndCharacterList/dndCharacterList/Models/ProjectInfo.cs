namespace dndCharacterList.Models
{
    public class ProjectInfo
    {
        public ProjectInfo(){
        
        }
        public ProjectInfo(string name, string group, string theme, string themeDescription) {

            Name = name;
            Group = group;
            Theme = theme;
            ThemeDescription = themeDescription;
        }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Theme { get; set; }
        public string ThemeDescription { get; set; }
       

    }
}
