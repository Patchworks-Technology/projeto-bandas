using System.Security.Cryptography.X509Certificates;

namespace ProjetoBandas.Entidades
{
    public class Album
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public Banda Artista { get; set; }
        public DateTime? AnoLancamento { get; set; }
        //public int Duracao => musicas.Sum(m => m.Duracao);
        public int NumeroFaixas { get; set; }


    }
}
