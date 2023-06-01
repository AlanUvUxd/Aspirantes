using Aspirantes.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Aspirantes.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AspirantesController : ControllerBase
    {
        private readonly string _connectionString;

        public AspirantesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aspirante>>> GetAnimales()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Aspirantes";
            var result = await db.QueryAsync<Aspirante>(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAspirante(Aspirante aspirante)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"INSERT INTO Aspirantes ([nombre], [apellido], [correoElectronico], [numTelefonico], [lugarNacimiento])
                            VALUES (@Nombre, @Apellido, @CorreoElectronico, @NumTelefonico, @LugarNacimiento)";
            var parameters = new
            {
                Nombre = aspirante.Nombre,
                Apellido = aspirante.Apellido,
                CorreoElectronico = aspirante.CorreoElectronico,
                NumTelefonico = aspirante.NumTelefonico,
                LugarNacimiento = aspirante.LugarNacimiento
            };
            await db.ExecuteAsync(query, parameters);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspirante(int id, Aspirante aspirante)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"UPDATE Aspirantes
                    SET [nombre] = @Nombre,
                        [apellido] = @Apellido,
                        [correoElectronico] = @CorreoElectronico,
                        [numTelefonico] = @NumTelefonico,
                        [lugarNacimiento] = @LugarNacimiento
                    WHERE [id] = @Id";
            var parameters = new
            {
                Id = id,
                Nombre = aspirante.Nombre,
                Apellido = aspirante.Apellido,
                CorreoElectronico = aspirante.CorreoElectronico,
                NumTelefonico = aspirante.NumTelefonico,
                LugarNacimiento = aspirante.LugarNacimiento
            };
            await db.ExecuteAsync(query, parameters);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspirante(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = "DELETE FROM Aspirantes WHERE [id] = @Id";
            var parameters = new { Id = id };
            await db.ExecuteAsync(query, parameters);
            return Ok();
        }
    }

}
