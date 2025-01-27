namespace miltecti_api.Entities
{
    public class ProdutoEntity : AnuncioEntity
    {
        public string Categoria { get; set; }
        public string Modelo { get; set; }
        public string Condicao { get; set; }
        public int Quantidade { get; set; }
    }
}
