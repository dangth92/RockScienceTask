using RockScienceWpfTask.Commands;
using RockScienceWpfTask.Models;
using RockScienceWpfTask.ViewModels.Base;
using System.Windows.Input;

namespace RockScienceWpfTask.ViewModels;

public class DialogViewModel : ViewModelBase
{
    private readonly DialogModel _model;
    private string _selectedOption;

    public DialogViewModel(DialogModel model)
    {
        _model = model ?? throw new ArgumentNullException(nameof(model));
        _selectedOption = model.SelectedOption;

        //OKCommand = new RelayCommand(ExecuteOK, CanExecuteOK);
        //CancelCommand = new RelayCommand(ExecuteCancel);
    }

    public string Title => _model.Title;
    public string LabelText => _model.LabelText;
    public List<string> Options => _model.Options;

    public string SelectedOption
    {
        get => _selectedOption;
        set
        {
            if (SetProperty(ref _selectedOption, value))
            {
                _model.SelectedOption = value;
            }
        }
    }

    public ICommand OKCommand { get; }
    public ICommand CancelCommand { get; }

    // For closing dialog from ViewModel
    public event EventHandler<DialogResultEventArgs> RequestClose;

    private bool CanExecuteOK(object parameter) => !string.IsNullOrEmpty(SelectedOption);

    private void ExecuteOK(object parameter)
    {
        RequestClose?.Invoke(this, new DialogResultEventArgs(true));
    }

    private void ExecuteCancel(object parameter)
    {
        RequestClose?.Invoke(this, new DialogResultEventArgs(false));
    }
}

