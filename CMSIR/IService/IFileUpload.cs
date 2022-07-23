using BlazorInputFile;

namespace CMSIR.IService
{
    public interface IFileUpload
    {
        Task UploadAsync(IFileListEntry file);
    }
}
