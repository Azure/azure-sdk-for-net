using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class ReadableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>
        where FluentResourceT : IFluentResourceT
    {
        protected abstract IFluentResourceT WrapModel(InnerResourceT inner);

        protected PagedList<IFluentResourceT> WrapList(PagedList<InnerResourceT> innerList)
        {
            return new PagedList<IFluentResourceT>(new WrappedPage<InnerResourceT, IFluentResourceT>(innerList.CurrentPage, WrapModel),
                (string nextPageLink) =>
                {
                    innerList.LoadNextPage();
                    return new WrappedPage<InnerResourceT, IFluentResourceT>(innerList.CurrentPage, WrapModel);
                });
        }
    }
}
