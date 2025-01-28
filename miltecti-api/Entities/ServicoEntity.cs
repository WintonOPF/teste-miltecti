using Microsoft.IdentityModel.Tokens;
using miltecti_api.Models;

namespace miltecti_api.Entities
{
    public class ServicoEntity : AnuncioEntity
    {
        public string TipoServico { get; set; }
        public override Dictionary<string, string>? Validate()
        {
            var errors = base.Validate() ?? new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(TipoServico))
            {
                errors.Add("TipoServico", "Selecione o tipo de serviço.");
            }

            if (errors.IsNullOrEmpty()) return null;
            return errors;
        }
        public override AnuncioEntity ToType(AnuncioModel anuncio)
        {
            var servico = new ServicoEntity()
            {
                NomeAnuncio = anuncio.NomeAnuncio,
                DataPublicacao = anuncio.DataPublicacao,
                Valor = anuncio.Valor,
                Cidade = anuncio.Cidade,
                TipoServico = anuncio.TipoServico,
                TipoAnuncio = anuncio.TipoAnuncio
            };
            return servico;
        }
    }
}
