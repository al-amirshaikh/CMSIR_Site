function DownloadPdf(uri,name) {
    let link = document.createElement("a");
    link.download = name;
    link.href = uri;
    link.click();
}




function OpenNewTab(filename)
{

      
      window.open(filename);

}

