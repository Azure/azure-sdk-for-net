// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public abstract class CreatableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT> :
        ReadableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>,
        ISupportsDeletingById   // Assumption: Anything creatable is deletable
        where FluentResourceT : IFluentResourceT
    {
        protected CreatableWrappers() { }

        public abstract void DeleteById(string id);

        public abstract Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        protected abstract FluentResourceT WrapModel(string name);
    }
}
