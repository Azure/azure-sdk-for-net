using System;
using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
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
            return new Sku("name", SkuTier.Basic, "family", "size", 10);
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
            ResourceIdentifier id = new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/resourceGroups/myResourceGroup/providers/Microsoft.Widgets/widgets/myWidget");
            return new GenericResourceData(id, id.Name, id.ResourceType, location, tags, plan, null, kind, managedBy, sku, null, null, null, null);
        }
    }
}
