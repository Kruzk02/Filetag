using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace Filetag.Services;

public class FilePickerService(Window window) : IFilePickerService
{
    public async Task<IReadOnlyList<IStorageFile>> PickFileAsync()
    {
        var options = new FilePickerOpenOptions
        {
            Title = "Select a file",
            AllowMultiple = false,
            FileTypeFilter =
            [
                new FilePickerFileType("Text Files") { Patterns = ["*.txt"] },
                new FilePickerFileType("All Files") { Patterns = ["*"] }
            ]
        };

        return await window.StorageProvider.OpenFilePickerAsync(options);
    }
}