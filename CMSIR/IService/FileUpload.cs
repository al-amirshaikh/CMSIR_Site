using BlazorInputFile;

namespace CMSIR.IService
{
    public class FileUpload:IFileUpload
    {
        private readonly IWebHostEnvironment _envirment;


        public FileUpload(IWebHostEnvironment envirment)
        {
            _envirment = envirment; 
        }

        public async Task UploadAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_envirment.ContentRootPath, "ResumeFiles", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);

            using (FileStream file = new FileStream(path,FileMode.Create,FileAccess.Write))
            {

                ms.WriteTo(file);

            }

        }


    }
}
