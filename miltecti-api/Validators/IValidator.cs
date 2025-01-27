namespace miltecti_api.Validators
{
    public interface IValidator<T>
    {
        Dictionary<string, string>? Validate(T entity);
    }
}
