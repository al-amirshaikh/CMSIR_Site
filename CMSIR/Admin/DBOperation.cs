using System.Data.SqlClient;
using CMSIR.IService;
using Dapper;
using System.Linq;
namespace CMSIR.Admin
{
    public class DBOperation : IDBOperation
    {
        private readonly IConfiguration _config;


        public DBOperation(IConfiguration configuration)
        {
            _config = configuration;

        }

        public string ConnectionString { get; set; } = "Default";
        public async Task InData(IService.DisplayModel model)
        {

            string conns = _config.GetConnectionString(ConnectionString);
            string sql = @"insert into Resumes(Name_,JobRole,Rusume_N,Paths) Values('"+model.Name+"','"+model.JobRol+"','"+model.Rusume+ "','"+model.Paths+"')";
            using (var conn = new SqlConnection(conns))
            {
                var exec = await conn.ExecuteAsync(sql, model);

            }
        }


        public async Task<List<T>> ReadData<T,U>(string sql, U paramerters )
        {
            string conns = _config.GetConnectionString(ConnectionString);

            
            using (var conn = new SqlConnection(conns))
            {

                var output = await conn.QueryAsync<T>(sql,paramerters);
                return output.ToList();

            }

        }


        public Task<List<DisplayModel>> GetData()
        {
            string sql = "Select ID,Name_,JobRole,Rusume_N from Resumes";
            return ReadData<DisplayModel, dynamic>(sql, new { });

        }

        public Task<List<DisplayModel>> ReadData()
        {
            throw new NotImplementedException();
        }
    }
}
