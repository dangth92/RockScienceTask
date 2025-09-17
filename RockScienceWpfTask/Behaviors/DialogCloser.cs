using Microsoft.Xaml.Behaviors;
using RockScienceWpfTask.Models;
using RockScienceWpfTask.ViewModels;
using System.Windows;

namespace RockScienceWpfTask.Behaviors;

public class DialogCloser : Behavior<Window>
{
    public static readonly DependencyProperty DialogResultProperty =
        DependencyProperty.Register(nameof(DialogResult), typeof(bool?), typeof(DialogCloser),
            new PropertyMetadata(null, OnDialogResultChanged));

    public bool? DialogResult
    {
        get => (bool?)GetValue(DialogResultProperty);
        set => SetValue(DialogResultProperty, value);
    }

    private static void OnDialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DialogCloser closer && closer.AssociatedObject != null)
        {
            closer.AssociatedObject.DialogResult = e.NewValue as bool?;
        }
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        if (AssociatedObject.DataContext is DialogViewModel viewModel)
        {
            viewModel.RequestClose += OnRequestClose;
        }
    }

    protected override void OnDetaching()
    {
        if (AssociatedObject.DataContext is DialogViewModel viewModel)
        {
            viewModel.RequestClose -= OnRequestClose;
        }

        base.OnDetaching();
    }

    private void OnRequestClose(object sender, DialogResultEventArgs e)
    {
        DialogResult = e.DialogResult;
    }
}