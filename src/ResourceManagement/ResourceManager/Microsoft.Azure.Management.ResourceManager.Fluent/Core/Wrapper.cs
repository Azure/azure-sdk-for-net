// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public class Wrapper<InnerT> : IHasInner<InnerT>
    {
        public Wrapper(InnerT inner)
        {
            Inner = inner;
        }

        public virtual InnerT Inner
        {
            get; private set;
        }

        public void SetInner(InnerT inner)
        {
            Inner = inner;
        }
    }
}
