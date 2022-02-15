using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
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

        private static Resources.Models.Sku GetSku()
        {
            return new Resources.Models.Sku("name", SkuTier.Basic.ToString(), "size", "family", "model", 10);
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
            Resources.Models.Sku sku,
            Plan plan,
            string kind,
            string managedBy,
            string location)
        {
            ResourceIdentifier id = new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/resourceGroups/myResourceGroup/providers/Microsoft.Widgets/widgets/myWidget");
            return new GenericResourceData(id, id.Name, id.ResourceType, null, tags, location, null, plan, null, kind, managedBy, sku, null, null, null, null);
        }
    }
}
