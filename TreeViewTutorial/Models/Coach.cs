namespace TreeViewTutorial.Models
{
    public class Coach : Person
    {
        public string Title { get; set; }

        public string ProperName => $"{Title}: {Name}";
    }
}