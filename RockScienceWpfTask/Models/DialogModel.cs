namespace RockScienceWpfTask.Models
{
    public class DialogModel
    {
        public string Title { get; set; }
        public string LabelText { get; set; }
        public List<string> Options { get; set; }
        public string SelectedOption { get; set; }

        public DialogModel()
        {
            Options = new List<string>();
        }
    }
}
