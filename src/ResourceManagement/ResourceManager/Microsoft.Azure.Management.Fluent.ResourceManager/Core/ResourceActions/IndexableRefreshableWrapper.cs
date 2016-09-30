// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions
{
    public abstract class IndexableRefreshableWrapper<IFluentResourceT, InnerResourceT> : IndexableRefreshable<IFluentResourceT>, IWrapper<InnerResourceT>
    {
        protected IndexableRefreshableWrapper(string name, InnerResourceT innerObject) : base(name)
        {
            SetInner(innerObject);
        }

        public InnerResourceT Inner
        {
            get; private set;
        }

        public void SetInner(InnerResourceT innerObject)
        {
            Inner = innerObject;
        }
    }
}
