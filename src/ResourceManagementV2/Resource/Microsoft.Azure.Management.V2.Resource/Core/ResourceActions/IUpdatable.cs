namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public interface IUpdatable<IFluentResourceT>
    {
        IFluentResourceT Update();
    }
}
