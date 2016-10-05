// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    public class IndexableWrapper<InnerT> :
        Indexable,
        IWrapper<InnerT>

    {
        protected IndexableWrapper(InnerT innerObject)
        {
            Inner = innerObject;
        }

        public InnerT Inner
        {
            get; private set;
            
        }

        public void SetInner(InnerT innerObject)
        {
            this.Inner = innerObject;
        }
    }
}
