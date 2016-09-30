// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions
{
    public abstract class IndexableRefreshable<IFluentResourceT> : 
        Indexable,
        IRefreshable<IFluentResourceT>
    {
        protected IndexableRefreshable(string name) : base(name) {}

        public abstract IFluentResourceT Refresh();
    }
}
