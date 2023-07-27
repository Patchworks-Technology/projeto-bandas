using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBandas.Entidades;

namespace ProjetoBandas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbunsController : ControllerBase
    {
        [HttpGet]
        public List<Album> Get()
        {
            return AlbunsContext.Albuns;
        }

        [HttpGet("ByName")]
        public Album GetByName(string nome)
        {
            return AlbunsContext.Albuns.FirstOrDefault(a => a.Nome == nome);
        }

        [HttpPost]
        public void Post([FromBody] Album album)
        {

            //TODO: CRIAR VALIDACAO
            // RESULT ERROR

            var lastId = AlbunsContext.Albuns.OrderByDescending(a => a.Id).Take(1).First().Id;
            album.Id = lastId + 1;
            AlbunsContext.Albuns.Add(album);
        }

        [HttpPut]
        public void Put(int id, [FromBody] Album album)
        {
            var a = AlbunsContext.Albuns.FirstOrDefault(a => a.Id == id);

            if (a == null)
                throw new Exception("Id de banda invalido");

            if (!string.IsNullOrEmpty(album.Nome))
                a.Nome = album.Nome;

            if (album.AnoLancamento != null)
                a.AnoLancamento = album.AnoLancamento;
        }

        [HttpDelete()]
        public void Delete(int id)
        {
            var a = AlbunsContext.Albuns.FirstOrDefault(a => a.Id == id);

            if (a == null)
                throw new Exception("Id do album invalido");

            AlbunsContext.Albuns.Remove(a);
        }

    }
}