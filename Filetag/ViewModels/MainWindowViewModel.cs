using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Filetag.Services;

namespace Filetag.ViewModels;

public class MainWindowViewModel() : ViewModelBase
{
    public ReactiveViewModel ReactiveViewModel { get; } = new();
}