using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core.Tests
{
    public class TestResource : Resource
    {
        public TestResource(string id)
        {
            Id = id;
        }

        public override ResourceIdentifier Id { get; protected set; }
    }
}
