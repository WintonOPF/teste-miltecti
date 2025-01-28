using miltecti_api.Models;
using System.Data;

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
        public virtual Dictionary<string, string>? Validate()
        {
            return ValidateBaseFields();
        }
        public Dictionary<string, string>? ValidateBaseFields()
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(NomeAnuncio))
            {
                errors.Add("nomeAnuncio", "O nome do anúncio é obrigatório.");
            }
            if (NomeAnuncio.Length < 5 || NomeAnuncio.Length > 100)
            {
                errors.Add("nomeAnuncio", "O nome do anúncio deve ter entre 5 e 100 caracteres.");
            }

            if (DataPublicacao < DateTime.Now.Date)
            {
                errors.Add("dataPublicacao", "A data de publicação não pode ser anterior à data de hoje.");
            }

            if (Valor < 1)
            {
                errors.Add("valor", "O valor deve ser maior ou igual a R$ 1,00.");
            }

            if (string.IsNullOrWhiteSpace(Cidade) ||
                !new[] { "São Paulo", "Rio de Janeiro", "Belo Horizonte" }.Contains(Cidade))
            {
                errors.Add("cidade", "Selecione uma cidade válida.");
            }


            return errors;
        }
        public virtual AnuncioEntity ToType(AnuncioModel anuncio) => new AnuncioEntity(); 
    }
}
