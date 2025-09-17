using System.ComponentModel;

namespace RockScienceWpfTask.ViewModels.Base;

public abstract class ValidatableViewModelBase : ViewModelBase, IDataErrorInfo
{
    private readonly Dictionary<string, string> _errors = new Dictionary<string, string>();

    public string Error => null;

    public string this[string columnName]
    {
        get
        {
            _errors.TryGetValue(columnName, out string error);
            return error;
        }
    }

    protected void SetError(string propertyName, string error)
    {
        if (string.IsNullOrEmpty(error))
        {
            _errors.Remove(propertyName);
        }
        else
        {
            _errors[propertyName] = error;
        }
        OnPropertyChanged(propertyName);
    }

    protected void ClearError(string propertyName)
    {
        _errors.Remove(propertyName);
        OnPropertyChanged(propertyName);
    }

    public bool HasErrors => _errors.Count > 0;
}
