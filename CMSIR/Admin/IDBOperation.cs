using CMSIR.IService;

namespace CMSIR.Admin
{
    public interface IDBOperation
    {
        string ConnectionString { get; set; }

        Task InData(DisplayModel model);
        Task<List<DisplayModel>> ReadData();
       Task<List<DisplayModel>> GetData();
    }
}