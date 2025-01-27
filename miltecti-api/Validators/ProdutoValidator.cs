using miltecti_api.Entities;

namespace miltecti_api.Validators
{
    public class ProdutoValidator : AnuncioValidator
    {
        public override void Validate(AnuncioEntity anuncio)
        {
            base.Validate(anuncio);

            var produto = anuncio as ProdutoEntity;
            if (string.IsNullOrWhiteSpace(produto.Categoria))
            {
                throw new ArgumentException("Selecione uma categoria válida.");
            }

            if (string.IsNullOrWhiteSpace(produto.Modelo))
            {
                throw new ArgumentException("Selecione um modelo válido.");
            }

            if (string.IsNullOrWhiteSpace(produto.Condicao))
            {
                throw new ArgumentException("Selecione uma condição válida para o produto.");
            }

            if (produto.Quantidade < 1)
            {
                throw new ArgumentException("A quantidade deve ser no mínimo 1 unidade.");
            }
        }
    }
}
