using Microsoft.IdentityModel.Tokens;
using miltecti_api.Entities;

namespace miltecti_api.Validators
{
    public class AnuncioValidator : IValidator<AnuncioEntity>
    {
        public virtual Dictionary<string, string>? Validate(AnuncioEntity entity)
        {
            return ValidateBaseFields(entity);
        }

        public Dictionary<string, string>? ValidateBaseFields(AnuncioEntity entity)
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(entity.NomeAnuncio))
            {
                errors.Add("NomeAnuncio", "O nome do anúncio é obrigatório.");
            }
            if (entity.NomeAnuncio.Length < 5 || entity.NomeAnuncio.Length > 100)
            {
                errors.Add("NomeAnuncio", "O nome do anúncio deve ter entre 5 e 100 caracteres.");
            }

            if (entity.DataPublicacao < DateTime.Now.Date)
            {
                errors.Add("DataPublicacao", "A data de publicação não pode ser anterior à data de hoje.");
            }

            if (entity.Valor <= 1)
            {
                errors.Add("Valor", "O valor deve ser maior ou igual a R$ 1,00.");
            }

            if (string.IsNullOrWhiteSpace(entity.Cidade) ||
                !new[] { "São Paulo", "Rio de Janeiro", "Belo Horizonte" }.Contains(entity.Cidade))
            {
                errors.Add("Cidade", "Selecione uma cidade válida.");
            }

            
            return errors;
        }

    }
}
