// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions
{
    public abstract class IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT> : IndexableRefreshable<IFluentResourceT>, IHasInner<InnerResourceT>
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
    }
}
