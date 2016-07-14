using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class ReadableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>
    {
        // TODO

        protected abstract FluentResourceT wrapModel(InnerResourceT inner);
    }
}
