using RockScienceWpfTask.Commands;
using RockScienceWpfTask.Models;
using RockScienceWpfTask.Services;
using RockScienceWpfTask.ViewModels.Base;
using System.Windows.Input;

namespace RockScienceWpfTask.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IDialogService _dialogService;
    private string _groundWaterMethod = "Not Selected";
    private string _thermalMethod = "Not Selected";

    public MainWindowViewModel() : this(new DialogService()) { }

    public MainWindowViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        OpenGroundWaterDialogCommand = new RelayCommand(OpenGroundWaterDialog);
        OpenThermalDialogCommand = new RelayCommand(OpenThermalDialog);
    }

    public string GroundWaterMethod
    {
        get => _groundWaterMethod;
        set => SetProperty(ref _groundWaterMethod, value);
    }

    public string ThermalMethod
    {
        get => _thermalMethod;
        set => SetProperty(ref _thermalMethod, value);
    }

    public ICommand OpenGroundWaterDialogCommand { get; }
    public ICommand OpenThermalDialogCommand { get; }

    private void OpenGroundWaterDialog(object parameter)
    {
        var dialogModel = new DialogModel
        {
            Title = "Ground Water Method Selection",
            LabelText = "Ground Water Method:",
            Options = new List<string> { "Static Water", "Steady FEA", "Transient FEA" },
            SelectedOption = GroundWaterMethod == "Not Selected" ? null : GroundWaterMethod
        };

        var dialogViewModel = new DialogViewModel(dialogModel);
        _dialogService.ShowDialog(dialogViewModel);

        if (!string.IsNullOrEmpty(dialogViewModel?.SelectedOption))
        {
            GroundWaterMethod = dialogModel.SelectedOption;
        }
    }

    private void OpenThermalDialog(object parameter)
    {
        var dialogModel = new DialogModel
        {
            Title = "Thermal Method Selection",
            LabelText = "Thermal Method:",
            Options = new List<string> { "Static Temperature", "Steady Thermal FEA", "Transient Thermal FEA" },
            SelectedOption = ThermalMethod == "Not Selected" ? null : ThermalMethod
        };

        var dialogViewModel = new DialogViewModel(dialogModel);
        _dialogService.ShowDialog(dialogViewModel);

        if (!string.IsNullOrEmpty(dialogViewModel?.SelectedOption))
        {
            ThermalMethod = dialogViewModel.SelectedOption;
        }
    }
}

