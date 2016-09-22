using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public class IndexableWrapper<InnerT> :
        Indexable,
        IWrapper<InnerT>

    {
        protected IndexableWrapper(string key, InnerT innerObject) : base(key)
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
