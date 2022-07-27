using System.Data.SqlClient;
using Dapper;
namespace CMSIR.IService
{
    public class AuthUser
    {
        private readonly IConfiguration _config;

        public AuthUser(IConfiguration conf)
        {
            _config = conf;

        }
     

        public string ConnectionString { get; set; } = "Default";



        public async Task<List<UserA>> GetData(string username="",string pass="")
        {
            string conns = _config.GetConnectionString(ConnectionString);


            using (var conn = new SqlConnection(conns))
            {
                string sql = $"select username Resumes, pass from User_S where username='{username}' AND pass='{pass}'";
                var output = await conn.QueryAsync<UserA>(sql);
                return output.ToList();

            }

        }
        
             






        }


    }
    

