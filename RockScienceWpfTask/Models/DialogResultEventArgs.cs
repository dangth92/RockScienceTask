namespace RockScienceWpfTask.Models;

public class DialogResultEventArgs : EventArgs
{
    public bool? DialogResult { get; }

    public DialogResultEventArgs(bool? result)
    {
        DialogResult = result;
    }
}
