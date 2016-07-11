namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{
    public interface ISupportsCreating<T>
    {
        T Define(string name);
    }
}
