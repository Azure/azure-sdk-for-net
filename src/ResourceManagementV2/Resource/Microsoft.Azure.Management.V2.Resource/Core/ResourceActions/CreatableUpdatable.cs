namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class CreatableUpdatable<IFluentResourceT,InnerResourceT, FluentResourceT> 
        : Creatable<IFluentResourceT, InnerResourceT, FluentResourceT> 
            where IFluentResourceT: class
            where FluentResourceT: class
    {
        protected CreatableUpdatable(string name, InnerResourceT innerObject) : base(name, innerObject) { }

        /*public IFluentResourceT Update()
        {
            return this as IFluentResourceT;
        }*/
    }
}
