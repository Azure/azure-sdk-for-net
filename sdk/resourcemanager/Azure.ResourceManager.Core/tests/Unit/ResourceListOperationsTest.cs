using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class ResourceListOperationsTest
    {
        private static Plan GetPlan()
        {
            return new Plan("name", "publisher", "product", "promo", "version");
        }

        private static Sku GetSku()
        {
            return new Sku("name", "tier", "family", "size", "model", 10);
        }

        private static GenericResourceData GetGenericResource()
        {
            return GetGenericResource(
                new Dictionary<string, string> { { "tag1", "value1" } },
                GetSku(),
                GetPlan(),
                "UserAssigned",
                "test",
                "Japan East");
        }

        private static GenericResourceData GetGenericResource(
            Dictionary<string, string> tags,
            Sku sku,
            Plan plan,
            string kind,
            string managedBy,
            string location)
        {
            TenantResourceIdentifier id = $"/subscriptions/{Guid.NewGuid().ToString()}/resourceGroups/myResourceGroup/providers/Microsoft.Widgets/widgets/myWidget";
            return new GenericResourceData(id, id.Name, id.ResourceType, location, tags, plan, null, kind, managedBy, sku, null);
        }
    }
}
