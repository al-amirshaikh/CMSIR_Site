using CMSIR.IService;

namespace CMSIR.Admin
{
    public interface IDBOperation
    {
        string ConnectionString { get; set; }

        Task<List<DisplayModel>> GetData();
        Task<List<UserA>> GetDataR(string username = "", string pass = "");
        Task InData(DisplayModel model);
        Task<List<DisplayModel>> Search(string value);
        Task<List<UserA>> GetDataAd(string username = "", string pass = "");
        void ReadU(string u = "");
        void ReadP(string p = "");
        Task Update(IService.DisplayModel model,int ID);
       Task Delete(int ID);
       Task<List<DisplayModel>> EditView(int id);

    }
}