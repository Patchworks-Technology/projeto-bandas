using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBandas.Entidades;
using ProjetoBandas.Response;

namespace ProjetoBandas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandasController : ControllerBase
    {
        private readonly BandasContext _context;

        public BandasController(BandasContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new JsonBaseResponse<List<Banda>>
            {
                Data = _context.Bandas.ToList()
            };

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Banda banda)
        {
            var lastId = _context.Bandas.OrderByDescending(b => b.Id).Take(1).First().Id;
            banda.Id = lastId + 1;
            _context.Bandas.Add(banda);

            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("BuscarBanda")]
        public async Task<IActionResult> GetByName(string nome)
        {
            var response = new JsonBaseResponse<List<Banda>>
            {
                Data = _context.Bandas.Where(b => b.Nome == nome).ToList(),
            };

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Banda banda)
        {
            var b = _context.Bandas.FirstOrDefault(b => b.Id == id);

            if (b == null)
                throw new Exception("Id de banda invalido");

            if (!string.IsNullOrEmpty(banda.Nome))
                b.Nome = banda.Nome;

            if (banda.AnoFormacao != null)
                b.AnoFormacao = banda.AnoFormacao;

            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            var b = _context.Bandas.FirstOrDefault(b => b.Id == id);

            if (b == null)
                throw new Exception("Id de banda invalido");

            _context.Bandas.Remove(b);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }

    }


}
