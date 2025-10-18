using System;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using Filetag.Services;

namespace Filetag.ViewModels;

public class MainViewModel(IFilePickerService filePickerService) : ViewModelBase
{
    public async Task<IStorageFile> SelectFileCommand()
    {
        var files = await filePickerService.PickFileAsync();
        return files.Count == 0 ? throw new Exception("No file selected") : files[0];
    }
}