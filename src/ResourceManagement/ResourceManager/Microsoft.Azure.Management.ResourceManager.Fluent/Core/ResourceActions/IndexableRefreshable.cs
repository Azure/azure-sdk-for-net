// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions
{
    public abstract class IndexableRefreshable<IFluentResourceT> : 
        Indexable,
        IRefreshable<IFluentResourceT>
    {
        protected IndexableRefreshable() {}

        public abstract IFluentResourceT Refresh();
    }
}
