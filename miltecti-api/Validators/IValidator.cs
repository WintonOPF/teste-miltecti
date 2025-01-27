namespace miltecti_api.Validators
{
    public interface IValidator<T>
    {
        void Validate(T entity);
    }
}
