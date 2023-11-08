using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ResourceListOperationsTest
    {
        private static ArmPlan GetPlan()
        {
            return new ArmPlan("name", "publisher", "product")
            {
                PromotionCode = "promo",
                Version = "version"
            };
        }

        private static ResourcesSku GetSku()
        {
            return new ResourcesSku()
            {
                Name = "name",
                Tier = ArmSkuTier.Basic.ToString(),
                Size = "size",
                Family = "family",
                Model = "model",
                Capacity = 10
            };
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
            ResourcesSku sku,
            ArmPlan plan,
            string kind,
            string managedBy,
            string location)
        {
            ResourceIdentifier id = new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/resourceGroups/myResourceGroup/providers/Microsoft.Widgets/widgets/myWidget");
            return ResourceManagerModelFactory.GenericResourceData(id, id.Name, id.ResourceType, null, tags, location, null, plan, null, kind, managedBy, sku, null, null, null, null);
        }
    }
}
