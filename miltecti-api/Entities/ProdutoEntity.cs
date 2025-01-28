using Microsoft.IdentityModel.Tokens;
using miltecti_api.Models;

namespace miltecti_api.Entities
{
    public class ProdutoEntity : AnuncioEntity
    {
        public string Categoria { get; set; }
        public string Modelo { get; set; }
        public string Condicao { get; set; }
        public int Quantidade { get; set; }
        public override Dictionary<string, string>? Validate()
        {
            var errors = base.Validate() ?? new Dictionary<string, string>();

            

            if (string.IsNullOrWhiteSpace(Categoria))
            {
                errors.Add("Categoria", "Selecione uma categoria válida.");
            }

            if (string.IsNullOrWhiteSpace(Modelo))
            {
                errors.Add("Modelo", "Selecione um modelo válido.");
            }

            if (string.IsNullOrWhiteSpace(Condicao))
            {
                errors.Add("Condicao", "Selecione uma condição válida para o produto.");
            }

            if (Quantidade <= 1)
            {
                errors.Add("Quantidade", "A quantidade deve ser no mínimo 1 unidade.");
            }

            if (errors.IsNullOrEmpty()) return null;
            return errors;
        }
        public override AnuncioEntity ToType(AnuncioModel anuncio)
        {
            
            var produto = new ProdutoEntity()
            {
                NomeAnuncio = anuncio.NomeAnuncio,
                DataPublicacao = anuncio.DataPublicacao,
                Valor = anuncio.Valor,
                Cidade = anuncio.Cidade,
                Categoria = anuncio.Categoria,
                Modelo = anuncio.Modelo,
                Condicao = anuncio.Condicao,
                Quantidade = anuncio.Quantidade ?? 0,
                TipoAnuncio = anuncio.TipoAnuncio
            };

            return produto;
            
        }
    }
}
