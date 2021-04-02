using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Tests
{
    public class TestTrackedResource<TIdentifier> : TrackedResource<TIdentifier> where TIdentifier : TenantResourceIdentifier
    {
        public TestTrackedResource(string id) : this(id, LocationData.Default)
        {
            Id = ResourceIdentifier.Create(id) as TIdentifier;
        }

        public TestTrackedResource(string id, string location)
        {
            Id = ResourceIdentifier.Create(id) as TIdentifier;
            Location = location;
        }

        public override TIdentifier Id { get; protected set; }
    }
}
