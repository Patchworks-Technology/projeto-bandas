using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBandas.Entidades;
using ProjetoBandas.Response;

namespace ProjetoBandas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbunsController : ControllerBase
    {

        private readonly BandasContext _context;

        public AlbunsController(BandasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new JsonBaseResponse<List<Album>>
            {
                Data = _context.Albuns.ToList()
            };

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("BuscarAlbum")]
        public async Task<IActionResult> GetByName(string nome)
        {
            var response = new JsonBaseResponse<List<Album>>
            {
                Data = _context.Albuns.Where(a => a.Nome == nome).ToList(),
            };

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Album album)
        {
            var lastId = _context.Albuns.OrderByDescending(a => a.Id).Take(1).First().Id;
            album.Id = lastId + 1;
            _context.Albuns.Add(album);

            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Album album)
        {
            var a = _context.Albuns.FirstOrDefault(a => a.Id == id);

            if (a == null)
                throw new Exception("Id do album invalido");

            if (!string.IsNullOrEmpty(album.Nome))
                a.Nome = album.Nome;

            if (album.AnoLancamento != null)
                a.AnoLancamento = album.AnoLancamento;

            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);

        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            var a = _context.Albuns.FirstOrDefault(a => a.Id == id);

            if (a == null)
                throw new Exception("Id de album invalido");

            _context.Albuns.Remove(a);

            _context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}