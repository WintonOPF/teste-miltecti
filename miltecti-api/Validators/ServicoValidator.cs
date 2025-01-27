using Microsoft.IdentityModel.Tokens;
using miltecti_api.Entities;

namespace miltecti_api.Validators
{
    public class ServicoValidator : AnuncioValidator
    {
        public override Dictionary<string, string>? Validate(AnuncioEntity anuncio)
        {
            var errors = base.Validate(anuncio) ?? new Dictionary<string, string>();

            var servico = anuncio as ServicoEntity;
            if (string.IsNullOrWhiteSpace(servico.TipoServico))
            {
                errors.Add("TipoServico","Selecione o tipo de serviço.");
            }

            if (errors.IsNullOrEmpty()) return null;
            return errors;
        }
    }
}
