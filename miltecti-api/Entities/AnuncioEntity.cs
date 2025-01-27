namespace miltecti_api.Entities
{
    public class AnuncioEntity
    {
        public int Id { get; set; }
        public string NomeAnuncio { get; set; }
        public DateTime DataPublicacao { get; set; }
        public decimal Valor { get; set; }
        public string Cidade { get; set; }
        public string TipoAnuncio { get; set; } // "Produto" ou "Serviço"
    }
}
