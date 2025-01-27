using miltecti_api.Entities;

namespace miltecti_api.Validators
{
    public class AnuncioValidator : IValidator<AnuncioEntity>
    {
        public virtual void Validate(AnuncioEntity entity)
        {
            ValidateBaseFields(entity);
        }

        protected void ValidateBaseFields(AnuncioEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.NomeAnuncio))
            {
                throw new ArgumentException("O nome do anúncio é obrigatório.");
            }

            if (entity.NomeAnuncio.Length < 5 || entity.NomeAnuncio.Length > 100)
            {
                throw new ArgumentException("O nome do anúncio deve ter entre 5 e 100 caracteres.");
            }

            if (entity.DataPublicacao < DateTime.Now.Date)
            {
                throw new ArgumentException("A data de publicação não pode ser anterior à data de hoje.");
            }

            if (entity.Valor < 1)
            {
                throw new ArgumentException("O valor deve ser maior ou igual a R$ 1,00.");
            }

            if (string.IsNullOrWhiteSpace(entity.Cidade) ||
                !new[] { "São Paulo", "Rio de Janeiro", "Belo Horizonte" }.Contains(entity.Cidade))
            {
                throw new ArgumentException("Selecione uma cidade válida.");
            }
        }
    }
}
