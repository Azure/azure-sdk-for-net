using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class IndexableRefreshable<IFluentResourceT> : 
        Indexable,
        IRefreshable<IFluentResourceT>
    {
        protected IndexableRefreshable(string name) : base(name) {}

        public abstract Task<IFluentResourceT> Refresh();

        IFluentResourceT IRefreshable<IFluentResourceT>.Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
