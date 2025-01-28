using Microsoft.IdentityModel.Tokens;
using miltecti_api.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace miltecti_api.Validators
{
    public class ProdutoValidator : AnuncioValidator
    {
        public override Dictionary<string, string>? Validate(AnuncioEntity anuncio)
        {        
            var errors = base.Validate(anuncio)?? new Dictionary<string, string>();

            var produto = anuncio as ProdutoEntity;

            if (string.IsNullOrWhiteSpace(produto.Categoria))
            {
                errors.Add("Categoria", "Selecione uma categoria válida.");
            }

            if (string.IsNullOrWhiteSpace(produto.Modelo))
            {
                errors.Add("Modelo", "Selecione um modelo válido.");
            }

            if (string.IsNullOrWhiteSpace(produto.Condicao))
            {
                errors.Add("Condicao", "Selecione uma condição válida para o produto.");
            }

            if (produto.Quantidade <= 1)
            {
                errors.Add("Quantidade", "A quantidade deve ser no mínimo 1 unidade.");
            }

            if (errors.IsNullOrEmpty()) return null;
            return errors;
        }
    }
}
