using System;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public class Wrapper<InnerT> : IWrapper<InnerT>
    {
        public Wrapper(InnerT inner)
        {
            Inner = inner;
        }

        public InnerT Inner
        {
            get; private set;
        }

        public void SetInner(InnerT inner)
        {
            this.Inner = inner;
        }
    }
}
