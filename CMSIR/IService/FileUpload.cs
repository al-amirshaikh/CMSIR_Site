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
            try{

            
            var path = Path.Combine(_envirment.WebRootPath, "ResumeFiles", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);

            using (FileStream file = new FileStream(path,FileMode.Create,FileAccess.Write))
            {

                ms.WriteTo(file);

            }
            }catch(Exception ex)
            {

                 error.Er = ex.Message;

            }

        }


    }
}
