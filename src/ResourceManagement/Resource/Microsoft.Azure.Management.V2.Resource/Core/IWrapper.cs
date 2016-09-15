namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public interface IWrapper<T>
    {
        T Inner { get; }
    }
}
