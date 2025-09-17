using RockScienceWpfTask.Views;

namespace RockScienceWpfTask.Services;

class DialogService : IDialogService
{
    public bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : class
    {
        var dialog = new SelectionDialog();
        dialog.DataContext = viewModel;
        return dialog.ShowDialog();
    }
}
