// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions
{
    public abstract class IndexableRefreshable<IFluentResourceT> : 
        Indexable,
        IRefreshable<IFluentResourceT>
    {
        protected IndexableRefreshable() {}

        public abstract IFluentResourceT Refresh();

        public abstract Task<IFluentResourceT> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
