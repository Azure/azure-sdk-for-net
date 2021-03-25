using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

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
