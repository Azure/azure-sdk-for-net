using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    internal class WrappedPage<InnerT, WrappedT> : IPage<WrappedT>
    {
        private string nextPageLink;
        private List<WrappedT> wrappedPageItems;

        public WrappedPage(IPage<InnerT> innerPage, Func<InnerT, WrappedT> doWrap)
        {
            wrappedPageItems = innerPage.Select(doWrap).ToList();
            nextPageLink = innerPage.NextPageLink;
        }

        public string NextPageLink
        {
            get
            {
                return nextPageLink;
            }
        }

        public IEnumerator<WrappedT> GetEnumerator()
        {
            return wrappedPageItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
