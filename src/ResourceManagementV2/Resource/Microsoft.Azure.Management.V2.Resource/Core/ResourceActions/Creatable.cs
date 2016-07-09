using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core.ResourceActions
{
    public abstract class Creatable<IFluentResourceT, InnerResourceT, FluentResourceT> : IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT>
    {
        protected Creatable(string name, InnerResourceT innerObject) : base(name, innerObject)
        {}
    }
}
