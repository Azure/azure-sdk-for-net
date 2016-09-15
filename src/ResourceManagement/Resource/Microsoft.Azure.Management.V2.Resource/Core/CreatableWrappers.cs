namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class CreatableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT> :
        ReadableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>
        where FluentResourceT : IFluentResourceT
    {
        protected CreatableWrappers() { }

        protected abstract FluentResourceT WrapModel(string name);
    }
}
