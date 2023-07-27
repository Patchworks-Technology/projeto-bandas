using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBandas.Entidades;

namespace ProjetoBandas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandasController : ControllerBase
    {
        [HttpGet]
        public List<Banda> Get()
        {
            return BandasContext.Bandas;
        }

        [HttpGet("ByName")]
        public Banda GetByName(string nome)
        {
            return BandasContext.Bandas.FirstOrDefault(b => b.Nome == nome);
        }

        [HttpPost]
        public void Post([FromBody] Banda banda)
        {

            //TODO: CRIAR VALIDACAO
            //// RESULT ERROR

            var lastId = BandasContext.Bandas.OrderByDescending(b => b.Id).Take(1).First().Id;
            banda.Id = lastId + 1;
            BandasContext.Bandas.Add(banda);
        }

        [HttpPut]
        public void Put(int id, [FromBody] Banda banda)
        {
            var b = BandasContext.Bandas.FirstOrDefault(b => b.Id == id);

            if (b == null)
                throw new Exception("Id de banda invalido");

            if (!string.IsNullOrEmpty(banda.Nome))
                b.Nome = banda.Nome;

            if (banda.AnoFormacao != null)
                b.AnoFormacao = banda.AnoFormacao;
        }

        [HttpDelete()]
        public void Delete(int id)
        {
            var b = BandasContext.Bandas.FirstOrDefault(b => b.Id == id);

            if (b == null)
                throw new Exception("Id de banda invalido");

            BandasContext.Bandas.Remove(b);
        }

    }


}
