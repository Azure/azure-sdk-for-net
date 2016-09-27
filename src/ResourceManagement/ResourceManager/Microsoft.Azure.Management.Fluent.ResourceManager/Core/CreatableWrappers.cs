// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public abstract class CreatableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT> :
        ReadableWrappers<IFluentResourceT, FluentResourceT, InnerResourceT>
        where FluentResourceT : IFluentResourceT
    {
        protected CreatableWrappers() { }

        protected abstract FluentResourceT WrapModel(string name);
    }
}
