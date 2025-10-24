using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Filetag.Services;
using ReactiveUI;

namespace Filetag.ViewModels;

public class ReactiveViewModel : ReactiveObject
{
    public ReactiveCommand<Window, Unit> OpenFileCommand { get; }
    
    public ReactiveViewModel()
    {
        OpenFileCommand = ReactiveCommand.CreateFromTask<Window>(OpenFileDialogAsync);
        
        this.WhenAnyValue(o => o.SelectedFile)
            .Subscribe(_ => this.RaisePropertyChanged(nameof(ShowSelectedFile)));
    }
    
    private IStorageFile? _selectedFile;

    public ObservableCollection<IStorageFile> Items { get; } = [];

    private IStorageFile? SelectedFile
    {
        get => _selectedFile;
        set => this.RaiseAndSetIfChanged(ref _selectedFile, value);
    }

    public string ShowSelectedFile => 
        SelectedFile == null ? 
            "No file selected" :
            $"Selected File {SelectedFile}";

    private async Task OpenFileDialogAsync(Window window)
    {
        var filePickerService = new FilePickerService(window);
        var files = await filePickerService.PickFileAsync();
        if (files.Count > 0)
        {
            SelectedFile = files[0];
            Items.Add(files[0]);
        }
    }
}