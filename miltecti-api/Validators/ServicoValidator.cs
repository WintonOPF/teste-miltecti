using miltecti_api.Entities;

namespace miltecti_api.Validators
{
    public class ServicoValidator : AnuncioValidator
    {
        public override void Validate(AnuncioEntity anuncio)
        {
            base.Validate(anuncio);

            var servico = anuncio as ServicoEntity;
            if (string.IsNullOrWhiteSpace(servico.TipoServico))
            {
                throw new ArgumentException("Selecione um tipo de serviço válido.");
            }
        }
    }
}
