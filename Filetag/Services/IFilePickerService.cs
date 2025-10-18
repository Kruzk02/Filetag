using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace Filetag.Services;

public interface IFilePickerService
{
    Task<IReadOnlyList<IStorageFile>> PickFileAsync();
}