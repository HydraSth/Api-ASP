using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListadoController : ControllerBase
    {
        private readonly TokenGenerator tokenGenerated;
        private readonly ItesDbContext itesDbContext;

        public ListadoController(TokenGenerator _tokenGenerated, ItesDbContext _itesDbContext)
        {
            tokenGenerated = _tokenGenerated;
            itesDbContext = _itesDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> Get([FromHeader] string token)
        {
            if (tokenGenerated.TokenAuthentication(token))
            {
                return await itesDbContext.Empleados.ToListAsync();
            }
            else
            {
                return Unauthorized();
            }
        }

        // POST api/<ListadoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ListadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}