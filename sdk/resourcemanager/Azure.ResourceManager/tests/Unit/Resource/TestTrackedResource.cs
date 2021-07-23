using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Tests
{
    public class TestTrackedResource<TIdentifier> : TrackedResource<TIdentifier> where TIdentifier : TenantResourceIdentifier
    {
        public TestTrackedResource(TIdentifier id) : this(id, Location.Default)
        {
        }

        public TestTrackedResource(TIdentifier id, string location)
            :base(id, id.Name, id.ResourceType, location, null)
        {
        }
    }
}
