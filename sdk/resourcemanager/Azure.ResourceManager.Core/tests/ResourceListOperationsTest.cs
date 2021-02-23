using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.ResourceManager.Core.Tests
{
    public class ResourceListOperationsTest
    {
        [TestCase]
        public void TestArmResponseArmResource()
        {
            var expected = GetGenericResource();
            var asArmOp = (GenericResource)TestListActivator(expected);

            Assert.IsNotNull(asArmOp.Data.Sku);
            Assert.AreEqual(expected.Sku.Capacity, asArmOp.Data.Sku.Capacity);
            Assert.AreEqual(expected.Sku.Family, asArmOp.Data.Sku.Family);
            Assert.AreEqual(expected.Sku.Name, asArmOp.Data.Sku.Name);
            Assert.AreEqual(expected.Sku.Size, asArmOp.Data.Sku.Size);
            Assert.AreEqual(expected.Sku.Tier, asArmOp.Data.Sku.Tier);

            Assert.IsNotNull(asArmOp.Data.Plan);
            Assert.AreEqual(expected.Plan.Name, asArmOp.Data.Plan.Name);
            Assert.AreEqual(expected.Plan.Product, asArmOp.Data.Plan.Product);
            Assert.AreEqual(expected.Plan.PromotionCode, asArmOp.Data.Plan.PromotionCode);
            Assert.AreEqual(expected.Plan.Publisher, asArmOp.Data.Plan.Publisher);
            Assert.AreEqual(expected.Plan.Version, asArmOp.Data.Plan.Version);

            Assert.IsTrue(expected.Location == asArmOp.Data.Location);
            Assert.AreEqual(expected.Kind, asArmOp.Data.Kind);
            Assert.AreEqual(expected.ManagedBy, asArmOp.Data.ManagedBy);
        }

        private static ResourceManager.Resources.Models.Plan GetPlan()
        {
            var plan = new ResourceManager.Resources.Models.Plan();
            plan.Name = "name";
            plan.Product = "product";
            plan.Publisher = "publisher";
            plan.PromotionCode = "promo";
            plan.Version = "version";
            return plan;
        }

        private static ResourceManager.Resources.Models.Sku GetSku()
        {
            var sku = new ResourceManager.Resources.Models.Sku();
            sku.Capacity = 10;
            sku.Family = "family";
            sku.Name = "name";
            sku.Size = "size";
            sku.Tier = "tier";
            return sku;
        }

        [TestCase]
        public void TestArmResourceActivator()
        {
            var expected = GetGenericResource();
            var actual = Activator.CreateInstance(typeof(GenericResourceData), expected as ResourceManager.Resources.Models.GenericResource) as GenericResourceData;

            Assert.IsNotNull(actual.Sku);
            Assert.AreEqual(expected.Sku.Capacity, actual.Sku.Capacity);
            Assert.AreEqual(expected.Sku.Family, actual.Sku.Family);
            Assert.AreEqual(expected.Sku.Name, actual.Sku.Name);
            Assert.AreEqual(expected.Sku.Size, actual.Sku.Size);
            Assert.AreEqual(expected.Sku.Tier, actual.Sku.Tier);

            Assert.IsNotNull(actual.Plan);
            Assert.AreEqual(expected.Plan.Name, actual.Plan.Name);
            Assert.AreEqual(expected.Plan.Product, actual.Plan.Product);
            Assert.AreEqual(expected.Plan.PromotionCode, actual.Plan.PromotionCode);
            Assert.AreEqual(expected.Plan.Publisher, actual.Plan.Publisher);
            Assert.AreEqual(expected.Plan.Version, actual.Plan.Version);

            Assert.IsTrue(expected.Location == actual.Location);
            Assert.AreEqual(expected.Kind, actual.Kind);
            Assert.AreEqual(expected.ManagedBy, actual.ManagedBy);

        }

        private static object TestListActivator(GenericResourceExpanded genericResource)
        {
            var createResourceConverterMethod = typeof(ResourceListOperations).GetMethod("CreateResourceConverter", BindingFlags.Static | BindingFlags.NonPublic);
            ResourceGroupOperations rgOp = GetResourceGroupOperations();
            var activatorFunction = (Func<GenericResourceExpanded, GenericResource>)createResourceConverterMethod.Invoke(null, new object[] { rgOp });
            return activatorFunction.DynamicInvoke(new object[] { genericResource });
        }

        private static ResourceGroupOperations GetResourceGroupOperations()
        {
            var rgOp = new ResourceGroupOperations(
                            new SubscriptionOperations(
                                new AzureResourceManagerClientOptions(),
                                Guid.Empty.ToString(),
                                new DefaultAzureCredential(), //should make a fake credential creation
                                new Uri("http://foo.com")),
                            "rgName");
            return rgOp;
        }

        private static GenericResourceExpanded GetGenericResource()
        {
            return GetGenereicResource(
                new Dictionary<string, string> { { "tag1", "value1" } },
                GetSku(),
                GetPlan(),
                "UserAssigned",
                "test",
                "Japan East");
        }

        private static GenericResourceExpanded GetGenereicResource(
            Dictionary<string, string> tags,
            ResourceManager.Resources.Models.Sku sku,
            ResourceManager.Resources.Models.Plan plan,
            string kind,
            string managedBy,
            string location)
        {
            var resource = new GenericResourceExpanded();
            resource.Location = location;
            resource.Tags = tags ?? new Dictionary<string, string>();
            resource.Sku = sku;
            resource.Plan = plan;
            resource.Kind = kind;
            resource.ManagedBy = managedBy;
            return resource;
        }
    }
}
