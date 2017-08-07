// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions
{
    public abstract class IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT>
        : IndexableRefreshable<IFluentResourceT>, IHasInner<InnerResourceT>
        where IFluentResourceT : class
    {
        protected IndexableRefreshableWrapper(string name, InnerResourceT innerObject)
        {
            SetInner(innerObject);
        }

        public InnerResourceT Inner
        {
            get; private set;
        }

        public virtual void SetInner(InnerResourceT innerObject)
        {
            Inner = innerObject;
        }

        protected abstract Task<InnerResourceT> GetInnerAsync(CancellationToken cancellationToken);

        public override IFluentResourceT Refresh()
        {
            return Extensions.Synchronize(() => RefreshAsync(CancellationToken.None));
        }

        public override async Task<IFluentResourceT> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerAsync(cancellationToken);
            this.SetInner(inner);
            return this as IFluentResourceT;
        }
    }
}
