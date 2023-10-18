using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly TokenGenerator tokenGenerated;
        private readonly ItesDbContext itesDbContext;

        public EmpleadoController(TokenGenerator _tokenGenerated, ItesDbContext _itesDbContext)
        {
            tokenGenerated = _tokenGenerated;
            itesDbContext = _itesDbContext;
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public async Task<ActionResult<String>> Post([FromBody] Empleado empleado, [FromHeader] string token)
        {
            if (tokenGenerated.TokenAuthentication(token))
            {
                try
                {
                    itesDbContext.Empleados.Add(empleado);
                    await itesDbContext.SaveChangesAsync();
                    return Ok("El empleado ha sido almacenado existosamente");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}