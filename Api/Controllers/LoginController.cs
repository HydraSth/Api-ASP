using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenGenerator tokenGenerated;
        private List<Usuario> Users;

        public LoginController(TokenGenerator tokenGenerated)
        {
            Users = new List<Usuario>()
            {
               new Usuario("Felipe","1234"),
               new Usuario("Juan", "1234")
            };
            this.tokenGenerated = tokenGenerated;
        }

        // GET: api/<Login>
        [HttpGet]
        public ActionResult<string> Get([FromHeader] string nombre, [FromHeader] string password)
        {
            var usuarioSeleccionado = Users.Find(x => x.Nome == nombre && x.Password == password);
            if (usuarioSeleccionado == null)
            {
                return NotFound("No se encontro el usuario");
            }
            return Ok(tokenGenerated.CrearToken());
        }

        // GET api/<Login>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Login>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Login>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Login>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}