namespace miltecti_api.Models
{
    public class ProdutoModel
    {
        public string Categoria { get; set; }
        public string Modelo { get; set; }
        public string Condicao { get; set; }
        public int Quantidade { get; set; }
        public string TipoServico { get; set; }
        public string TipoAnuncio { get; set; } // "Produto" ou "Serviço"
    }
}
