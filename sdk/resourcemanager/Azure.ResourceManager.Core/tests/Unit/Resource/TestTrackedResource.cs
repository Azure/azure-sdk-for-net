using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Tests
{
    public class TestTrackedResource : TrackedResource
    {
        public TestTrackedResource(string id)
        {
            Id = id;
        }

        public override ResourceIdentifier Id { get; protected set; }
    }
}
