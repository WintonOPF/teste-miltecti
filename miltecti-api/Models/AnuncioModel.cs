using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace miltecti_api.Models
{
    public class AnuncioModel
    {
        public int Id { get; set; }
        public string NomeAnuncio { get; set; }
        public DateTime DataPublicacao { get; set; }
        public decimal Valor { get; set; }
        public string Cidade { get; set; }
        public string? Categoria { get; set; }
        public string? Modelo { get; set; }
        public string? Condicao { get; set; }
        public int? Quantidade { get; set; }
        public string? TipoServico { get; set; }
        public string TipoAnuncio { get; set; } // "Produto" ou "Serviço"
    }
}
