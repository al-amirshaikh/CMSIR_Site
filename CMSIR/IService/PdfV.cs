using Microsoft.JSInterop;
namespace CMSIR.IService
{
    public static class PdfV
    {

       public static void DownloadPdf(IJSRuntime js ,string filename="",string name = "")
       {
               js.InvokeVoidAsync("DownloadPdf",filename,name);

       }


  

        
       public static void NewTab(IJSRuntime js ,string filename="")
       {
              js.InvokeVoidAsync("OpenNewTab",filename);        

        }


 

    }
}
