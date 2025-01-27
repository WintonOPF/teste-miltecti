using miltecti_api.Entities;

namespace miltecti_api.Validators
{
    public class ServicoValidator : IValidator<ServicoEntity>
    {
        public void Validate(ServicoEntity servico)
        {
            if (string.IsNullOrWhiteSpace(servico.TipoServico))
            {
                throw new ArgumentException("Selecione um tipo de serviço válido.");
            }
        }
    }
}
