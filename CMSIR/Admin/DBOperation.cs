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
            string sql = @"insert into Resumes(Name_,JobRole,Rusume_N,Paths) Values('" + model.Name_ + "','" + model.JobRole + "','" + model.Rusume_N + "','" + model.Paths + "')";
            using (var conn = new SqlConnection(conns))
            {
                var exec = await conn.ExecuteAsync(sql, model);

            }
        }

     public async Task Update(IService.DisplayModel model,int ID)
        {

            string conns = _config.GetConnectionString(ConnectionString);
            string sql = @"update Resumes  SET Name_ = '"+model.Name_+"',JobRole='"+model.JobRole+"' ,Rusume_N = '"+model.Rusume_N+"', Paths='"+model.Paths+"' where ID='"+ID+"'";
            using (var conn = new SqlConnection(conns))
            {
                var exec = await conn.ExecuteAsync(sql, model);

            }
        }



             public async Task Delete(int ID)
        {

            string conns = _config.GetConnectionString(ConnectionString);
              string sql = "Delete From Resumes Where ID = '"+ID+"'";
            using (var conn = new SqlConnection(conns))
            {
                var exec = await conn.ExecuteAsync(sql);

            }
        }


        public async Task<List<DisplayModel>> GetData()
        {
            string conns = _config.GetConnectionString(ConnectionString);


            using (var conn = new SqlConnection(conns))
            {

                string sql = "Select * From Resumes";
                var output = await conn.QueryAsync<DisplayModel>(sql);
                return output.ToList();

            }

        }

        

        public async Task<List<UserA>> GetDataR(string username = "", string pass = "")
        {
            string conns = _config.GetConnectionString(ConnectionString);


            using (var conn = new SqlConnection(conns))
            {
                string sql = $"select username , pass from User_S where username='{username}' AND pass='{pass}'";
                var output = await conn.QueryAsync<UserA>(sql);
                return output.ToList();

            }

        }

        public async Task<List<UserA>> GetDataAd(string username = "", string pass = "")
        {
            string conns = _config.GetConnectionString(ConnectionString);


            using (var conn = new SqlConnection(conns))
            {
                string sql = $"select username , pass from AdminD where username='{username}' AND pass='{pass}'";
                var output = await conn.QueryAsync<UserA>(sql);
                return output.ToList();

            }

        }


            


    

     



        public async Task<List<DisplayModel>> Search(string value)
        {
            string conns = _config.GetConnectionString(ConnectionString);


            using (var conn = new SqlConnection(conns))
            {

                string sql = $"Select * From Resumes where Name_ Like%'{value}'%";
                var output = await conn.QueryAsync<DisplayModel>(sql);
                return output.ToList();

            }

        }




      public async Task<List<DisplayModel>> EditView(int id)
        {
            string conns = _config.GetConnectionString(ConnectionString);


            using (var conn = new SqlConnection(conns))
            {

                string sql = $"Select * From Resumes where ID ='"+id+"'";
                var output = await conn.QueryAsync<DisplayModel>(sql);
                return output.ToList();

            }

        }








        public void  ReadU(string u = "")
        {
  string dic =  System.IO.Directory.GetCurrentDirectory()+"/Admin/_sec.txt"; 

            StreamWriter sw = new StreamWriter(dic);
            //Read the first line of text

            sw.WriteLine(u);
            sw.Close();




        }

        public void ReadP(string p = "")
        {
            
              string dic =  System.IO.Directory.GetCurrentDirectory()+"/Admin/pa.txt"; 
            StreamWriter sw = new StreamWriter(dic);

            //Read the first line of text
        
            sw.WriteLine(p);
            sw.Close();



        }


    }
}