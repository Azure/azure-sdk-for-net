namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    interface IUpdatable<IFluentResourceT>
    {
        IFluentResourceT Update();
    }
}
