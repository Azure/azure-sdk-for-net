using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Storage
{
    internal class UsageImpl : Wrapper<UsageInner>, IStorageUsage
    {
        internal UsageImpl(UsageInner innerObject) : base(innerObject)
        {}

        public int? CurrentValue
        {
            get
            {
                return Inner.CurrentValue;
            }
        }

        public int? Limit
        {
            get
            {
                return Inner.Limit;
            }
        }

        public UsageName Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public UsageUnit? Unit
        {
            get
            {
                return Inner.Unit;
            }
        }
    }
}
