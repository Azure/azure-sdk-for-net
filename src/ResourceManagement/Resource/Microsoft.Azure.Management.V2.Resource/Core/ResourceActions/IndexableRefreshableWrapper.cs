namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT> : IndexableRefreshable<IFluentResourceT>, IWrapper<InnerResourceT>
    {
        protected IndexableRefreshableWrapper(string name, InnerResourceT innerObject) : base(name)
        {
            SetInner(innerObject);
        }

        public InnerResourceT Inner
        {
            get; private set;
        }

        public void SetInner(InnerResourceT innerObject)
        {
            Inner = innerObject;
        }
    }
}
