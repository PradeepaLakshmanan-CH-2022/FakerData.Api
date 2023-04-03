using MySql.Data.MySqlClient;
using System.Data;

namespace FakerData.Api.Models
{
    public class ConnectionStringConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public ConnectionStringConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DataBaseConnectionString");
        }

        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
    }
}
