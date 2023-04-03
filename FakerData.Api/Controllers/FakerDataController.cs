using Dapper;
using FakerData.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace FakerData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakerDataController : ControllerBase
    {
        private readonly ConnectionStringConfiguration _connectionStringConfiguration;
      

        public FakerDataController(ConnectionStringConfiguration connectionStringConfiguration)
        {

            _connectionStringConfiguration = connectionStringConfiguration;
          

        }

        [HttpPost]

        public async Task<ActionResult> CreateData(FakerJson fakerJson)

        {
            var query = "INSERT INTO fakerdatajson (fakerdatas) VALUES (@fakerdatas)";

            var parameters = new DynamicParameters();
            parameters.Add("@fakerdatas", fakerJson.Fakerdatas, DbType.String);


            using (var connection = _connectionStringConfiguration.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
            return Ok();
        }

    }
}
