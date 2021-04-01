using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core.Tests
{
    public class TestResource<TIdentifier> : Resource<TIdentifier> where TIdentifier : TenantResourceIdentifier
    {
        public TestResource(string id)
        {
            Id = ResourceIdentifier.Create(id) as TIdentifier;
        }

        public override TIdentifier Id { get; protected set; }
    }
}
