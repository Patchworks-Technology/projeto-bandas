using System.ComponentModel.DataAnnotations;

namespace ProjetoBandas.Entidades
{
    public class Banda
    {

        public int Id { get; set; }

        [MaxLength(30)]
        public string? Nome { get; set; }


        public DateTime? AnoFormacao { get; set; }

    }
}