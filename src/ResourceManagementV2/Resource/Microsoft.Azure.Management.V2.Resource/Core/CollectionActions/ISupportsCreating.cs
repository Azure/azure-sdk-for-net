namespace Microsoft.Azure.Management.V2.Resource.Core.Collections
{
    public interface ISupportsCreating<T>
    {
        T Define(string name);
    }
}
