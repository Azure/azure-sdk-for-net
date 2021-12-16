using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ResourceIdentifierTests
    {
        const string TrackedResourceId =
            "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm";
        const string ChildResourceId =
            "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/vortualNetworks/myNet/subnets/mySubnet";
        const string ResourceGroupResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg";
        const string LocationResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/locations/MyLocation";
        const string SubscriptionResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575";
        const string TenantResourceId = "/providers/Microsoft.Billing/billingAccounts/3984c6f4-2d2a-4b04-93ce-43cf4824b698%3Ae2f1492a-a492-468d-909f-bf7fe6662c01_2019-05-31";

        [Test]
        public void Sort()
        {
            List<ResourceIdentifier> list = new List<ResourceIdentifier>();
            ResourceIdentifier id = new ResourceIdentifier(TrackedResourceId);
            ResourceIdentifier childId = id.AppendChildResource("myChild", "myChildName");
            list.Add(childId);
            list.Add(id);
            Assert.AreEqual(childId.Name, list[0].Name);
            list.Sort();
            Assert.AreEqual(id.Name, list[0].Name);
        }

        [TestCase(TenantResourceId)]
        public void CanParseTenant(string id)
        {
            ResourceIdentifier asIdentifier = new ResourceIdentifier(id);
            Assert.AreEqual(asIdentifier.ResourceType.Namespace, "Microsoft.Billing");
            Assert.AreEqual(asIdentifier.ResourceType.Type, "billingAccounts");
            Assert.AreEqual(asIdentifier.Name, "3984c6f4-2d2a-4b04-93ce-43cf4824b698%3Ae2f1492a-a492-468d-909f-bf7fe6662c01_2019-05-31");
        }

        [TestCase("/providers/MicrosoftSomething/billingAccounts/")]
        [TestCase("/MicrosoftSomething/billingAccounts/")]
        [TestCase("providers/subscription/MicrosoftSomething/billingAccounts/")]
        [TestCase("/subscription/providersSomething")]
        [TestCase("/providers")]
        public void InvalidTenantID(string id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { ResourceIdentifier subject = new ResourceIdentifier(id); });
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("asdfghj")]
        [TestCase("123456")]
        [TestCase("!@#$%^&*/")]
        [TestCase("/subscriptions/")]
        [TestCase("/0c2f6471-1bf0-4dda-aec3-cb9272f09575/myRg/")]
        public void InvalidRPIds(string invalidID)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { ResourceIdentifier subject = new ResourceIdentifier(invalidID); });
        }

        [TestCase(TrackedResourceId)]
        [TestCase(ChildResourceId)]
        [TestCase(ResourceGroupResourceId)]
        [TestCase(LocationResourceId)]
        [TestCase(SubscriptionResourceId)]
        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/microsoft.insights")]
        public void ImplicitConstructor(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z;

            z = new ResourceIdentifier(x);
            y = z;

            if (resourceProviderID is null)
            {
                Assert.IsNull(z);
                Assert.IsNull(y);
            }
            else
            {
                Assert.AreEqual(resourceProviderID, y);
            }
        }

        [TestCase(TrackedResourceId)]
        [TestCase(ChildResourceId)]
        [TestCase(ResourceGroupResourceId)]
        [TestCase(LocationResourceId)]
        [TestCase(SubscriptionResourceId)]
        [TestCase(null)]
        public void PublicConstructor(string resourceProviderID)
        {
            if (resourceProviderID is null)
            {
                Assert.Throws<ArgumentNullException>(() => { ResourceIdentifier myResource = new ResourceIdentifier(resourceProviderID); });
            }
            else
            {
                ResourceIdentifier myResource = new ResourceIdentifier(resourceProviderID);
                Assert.AreEqual(myResource.ToString(), resourceProviderID);
            }
        }

        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleAssignments", "myRa")]
        public void CanParseExtensionResourceIds(string baseId, string extensionNamespace, string extensionType, string extensionName)
        {
            ResourceIdentifier targetResourceId = new ResourceIdentifier(baseId);
            ResourceIdentifier subject = new ResourceIdentifier($"{baseId}/providers/{extensionNamespace}/{extensionType}/{extensionName}");
            ResourceType expectedType = $"{extensionNamespace}/{extensionType}";
            Assert.AreNotEqual(targetResourceId.ResourceType, subject.ResourceType);
            Assert.AreEqual(expectedType, subject.ResourceType);
            Assert.NotNull(subject.Parent);
            Assert.AreEqual(targetResourceId, subject.Parent);
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/providers/Microsoft.ApiManagement/service/myservicename/subscriptions/mysubscription", "Microsoft.ApiManagement/service/subscriptions",
            Description = "From ApiManagement")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/providers/Microsoft.ServiceBus/namespaces/mynamespace/topics/mytopic/subscriptions/mysubscription", "Microsoft.ServiceBus/namespaces/topics/subscriptions",
            Description = "From ServiceBus")]
        public void CanParseResourceIdsWithSubscriptionsOfOtherResourceTypes(string resourceId, string expectedResourcetype)
        {
            ResourceIdentifier subject = new ResourceIdentifier(resourceId);
            Assert.AreEqual(expectedResourcetype, subject.ResourceType.ToString());
        }

        [TestCase("UnformattedString", Description = "Too Few Elements")]
        [TestCase("/subs/sub1/rgs/rg1/", Description = "No known parts")]
        [TestCase("/subscriptions/sub1/rgs/rg1/", Description = "Subscription not a Guid")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups", Description = "Too few parts")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets", Description = "Subscription resource with too few parts")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/widgets", Description = "ResourceGroup ID with Too few parts")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/providers/Microsoft.Widgets/widgets", Description = "ResourceGroup provider ID with Too few parts")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/providers/incomplete", Description = "Too few parts for location resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/providers/myProvider/myResource/myResourceName/providers/incomplete", Description = "Too few parts for location resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/providers/Company.MyProvider/myResources/myResourceName/providers/incomplete", Description = "Too few parts for resource group resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Company.MyProvider/myResources/myResourceName/providers/incomplete", Description = "Too few parts for subscription resource")]
        [TestCase("/providers/Company.MyProvider/myResources/myResourceName/providers/incomplete", Description = "Too few parts for tenant resource")]
        public void ThrowsOnInvalidUri(string resourceId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(() => ConvertToResourceId(resourceId)));
        }

        protected void ValidateLocationBaseResource(ResourceIdentifier locationResource, string expectedId, bool expectedChild, string expectedResourcetype, string expectedSubGuid)
        {
            Assert.AreEqual(expectedId, locationResource.ToString());
            Assert.AreEqual(expectedChild, locationResource.IsChild);
            Assert.AreEqual("westus2", locationResource.Location.ToString());
            Assert.AreEqual("westus2", locationResource.Name);
            Assert.IsNull(locationResource.Provider);
            Assert.AreEqual(expectedResourcetype, locationResource.ResourceType.ToString());
            Assert.AreEqual(expectedSubGuid, locationResource.SubscriptionId);
            ValidateSubscriptionResource(locationResource.Parent, locationResource.SubscriptionId);
        }

        protected void ValidateSubscriptionResource(ResourceIdentifier subscriptionResource, string subscriptionId)
        {
            Assert.AreEqual($"/subscriptions/{subscriptionId}", subscriptionResource.ToString());
            Assert.AreEqual(true, subscriptionResource.IsChild);
            Assert.IsNull(subscriptionResource.Location);
            Assert.IsNull(subscriptionResource.Provider);
            Assert.AreEqual(subscriptionId, subscriptionResource.Name);
            Assert.AreEqual(subscriptionId, subscriptionResource.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/subscriptions", subscriptionResource.ResourceType.ToString());
            ValidateTenantResource(subscriptionResource.Parent);
        }

        protected void ValidateTenantResource(ResourceIdentifier tenantResource)
        {
            Assert.AreEqual("/", tenantResource.ToString());
            Assert.AreEqual(true, tenantResource.IsChild);
            Assert.IsNull(tenantResource.Location);
            Assert.IsNull(tenantResource.Provider);
            Assert.AreEqual(string.Empty, tenantResource.Name);
            Assert.IsNull(tenantResource.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/tenants", tenantResource.ResourceType.ToString());
        }

        public ResourceIdentifier ConvertToResourceId(string resourceId)
        {
            ResourceIdentifier subject = new ResourceIdentifier(resourceId);
            return subject;
        }

        [TestCase(TrackedResourceId, TrackedResourceId, true)]
        [TestCase(ChildResourceId, ChildResourceId, true)]
        [TestCase(null, null, true)]
        [TestCase(TrackedResourceId, ChildResourceId, false)]
        [TestCase(ChildResourceId, TrackedResourceId, false)]
        [TestCase(TrackedResourceId, null, false)]
        [TestCase(null, TrackedResourceId, false)]
        public void EqualsToResourceIdentifier(string resourceProviderID1, string resourceProviderID2, bool expected)
        {
            ResourceIdentifier a = resourceProviderID1 == null ? null : new ResourceIdentifier(resourceProviderID1);
            ResourceIdentifier b = resourceProviderID2 == null ? null : new ResourceIdentifier(resourceProviderID2);
            if (a != null)
                Assert.AreEqual(expected, a.Equals(b));

            Assert.AreEqual(expected, ResourceIdentifier.Equals(a, b));
        }

        [TestCase(TrackedResourceId, TrackedResourceId, true)]
        [TestCase(ChildResourceId, ChildResourceId, true)]
        [TestCase(null, null, true)]
        [TestCase(TrackedResourceId, ChildResourceId, false)]
        [TestCase(ChildResourceId, TrackedResourceId, false)]
        [TestCase(TrackedResourceId, null, false)]
        [TestCase(null, TrackedResourceId, false)]
        public void EqualsToString(string resourceProviderID1, string resourceProviderID2, bool expected)
        {
            ResourceIdentifier a = resourceProviderID1 == null ? null : new ResourceIdentifier(resourceProviderID1);
            if (a != null)
                Assert.AreEqual(expected, a.Equals(resourceProviderID2));

            Assert.AreEqual(expected, ResourceIdentifier.Equals(a, resourceProviderID2));
        }

        [TestCase("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/providers/Contoso.Widgets/widgets/myWidget",
            "6b085460-5f21-477e-ba44-1035046e9101", null, null, "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101",
            Description = "SubscriptionResourceIdentifier")]
        [TestCase("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2/providers/Contoso.Widgets/widgets/myWidget",
            "6b085460-5f21-477e-ba44-1035046e9101", "westus2", null, "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2",
            Description = "LocationResourceIdentifier")]
        [TestCase("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg/providers/Contoso.Widgets/widgets/myWidget",
            "6b085460-5f21-477e-ba44-1035046e9101", null, "myRg", "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg",
            Description = "ResourceGroupResourceIdentifier")]
        public void TryGetPropertiesForGenericResource(string resourceId, string subscription, string location, string resourceGroup, string parent)
        {
            ResourceIdentifier id1 = new ResourceIdentifier(resourceId);
            Assert.AreEqual(subscription is null, id1.SubscriptionId is null);
            if (!(subscription is null))
                Assert.AreEqual(subscription, id1.SubscriptionId);
            Assert.AreEqual(location is null, id1.Location is null);
            if (!(location is null))
                Assert.AreEqual(location, id1.Location.Name);
            Assert.AreEqual(resourceGroup is null, id1.ResourceGroupName is null);
            if (!(resourceGroup is null))
                Assert.AreEqual(resourceGroup, id1.ResourceGroupName);
            Assert.AreEqual(parent is null, id1.Parent is null);
            if (!(parent is null))
                Assert.AreEqual(parent, id1.Parent.ToString());
        }

        [TestCase("/providers/Contoso.Widgets/widgets/myWidget", Description = "TenantResourceIdentifier")]
        [TestCase("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/providers/Contoso.Widgets/widgets/myWidget",
            Description = "SubscriptionResourceIdentifier")]
        [TestCase("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2/providers/Contoso.Widgets/widgets/myWidget",
            Description = "LocationResourceIdentifier")]
        [TestCase("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg/providers/Contoso.Widgets/widgets/myWidget",
            Description = "ResourceGroupResourceIdentifier")]
        public void ResourceIdRetainsOriginalInput(string resourceId)
        {
            ResourceIdentifier id = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
        }

        [TestCase(TrackedResourceId, TrackedResourceId, 0)]
        [TestCase(TrackedResourceId, ChildResourceId, -1)]
        [TestCase(ChildResourceId, TrackedResourceId, 1)]
        [TestCase(TrackedResourceId, null, 1)]
        public void CompareToResourceProvider(string resourceProviderID1, string resourceProviderID2, int expected)
        {
            ResourceIdentifier a = new ResourceIdentifier(resourceProviderID1);
            ResourceIdentifier b = resourceProviderID2 == null ? null : new ResourceIdentifier(resourceProviderID2);
            if (a != null)
                Assert.AreEqual(expected, a.CompareTo(b));

        }

        [TestCase(TrackedResourceId, TrackedResourceId, 0)]
        [TestCase(TrackedResourceId, ChildResourceId, -1)]
        [TestCase(ChildResourceId, TrackedResourceId, 1)]
        [TestCase(TrackedResourceId, null, 1)]
        public void CompareToString(string resourceProviderID1, string resourceProviderID2, int expected)
        {
            ResourceIdentifier a = new ResourceIdentifier(resourceProviderID1);
            string b = resourceProviderID2;
            if (a != null)
                Assert.AreEqual(expected, a.CompareTo(resourceProviderID2 == null ? null : new ResourceIdentifier(b)));
        }

        [TestCase(TrackedResourceId, TrackedResourceId, true, "object")]
        [TestCase(ChildResourceId, ChildResourceId, true, "object")]
        [TestCase(null, null, true, "object")]
        [TestCase(TrackedResourceId, ChildResourceId, false, "object")]
        [TestCase(ChildResourceId, TrackedResourceId, false, "object")]
        [TestCase(TrackedResourceId, null, false, "object")]
        [TestCase(null, TrackedResourceId, false, "object")]
        [TestCase(TrackedResourceId, TrackedResourceId, true, "string")]
        [TestCase(ChildResourceId, ChildResourceId, true, "string")]
        [TestCase(null, null, true, "string")]
        [TestCase(TrackedResourceId, ChildResourceId, false, "string")]
        [TestCase(ChildResourceId, TrackedResourceId, false, "string")]
        [TestCase(TrackedResourceId, null, false, "string")]
        [TestCase(null, TrackedResourceId, false, "string")]
        public void EqualsOperator(string resourceProviderID1, string resourceProviderID2, bool expected, string comparisonType)
        {
            ResourceIdentifier a = resourceProviderID1 == null ? null : new ResourceIdentifier(resourceProviderID1);
            if (comparisonType == "object")
            {
                ResourceIdentifier b = resourceProviderID2 == null ? null : new ResourceIdentifier(resourceProviderID2);
                Assert.AreEqual(expected, a == b);
            }
            else
            {
                Assert.AreEqual(expected, a == resourceProviderID2);
            }
        }

        [TestCase(TrackedResourceId, TrackedResourceId, false, "object")]
        [TestCase(ChildResourceId, ChildResourceId, false, "object")]
        [TestCase(null, null, false, "object")]
        [TestCase(TrackedResourceId, ChildResourceId, true, "object")]
        [TestCase(ChildResourceId, TrackedResourceId, true, "object")]
        [TestCase(TrackedResourceId, null, true, "object")]
        [TestCase(null, TrackedResourceId, true, "object")]
        [TestCase(TrackedResourceId, TrackedResourceId, false, "string")]
        [TestCase(ChildResourceId, ChildResourceId, false, "string")]
        [TestCase(null, null, false, "string")]
        [TestCase(TrackedResourceId, ChildResourceId, true, "string")]
        [TestCase(ChildResourceId, TrackedResourceId, true, "string")]
        [TestCase(TrackedResourceId, null, true, "string")]
        [TestCase(null, TrackedResourceId, true, "string")]
        public void NotEqualsOperator(string resourceProviderID1, string resourceProviderID2, bool expected, string comparisonType)
        {
            ResourceIdentifier a = resourceProviderID1 == null ? null : new ResourceIdentifier(resourceProviderID1);
            if (comparisonType == "object")
            {
                ResourceIdentifier b = resourceProviderID2 == null ? null : new ResourceIdentifier(resourceProviderID2);
                Assert.AreEqual(expected, a != b);
            }
            else
            {
                Assert.AreEqual(expected, a != resourceProviderID2);
            }
        }

        [TestCase(false, TrackedResourceId, TrackedResourceId)]
        [TestCase(true, TrackedResourceId, ChildResourceId)]
        [TestCase(false, ChildResourceId, TrackedResourceId)]
        public void LessThanOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = new ResourceIdentifier(string1);
            ResourceIdentifier id2 = new ResourceIdentifier(string2);
            Assert.AreEqual(expected, id1 < id2);
        }

        [TestCase(true, TrackedResourceId, TrackedResourceId)]
        [TestCase(true, TrackedResourceId, ChildResourceId)]
        [TestCase(false, ChildResourceId, TrackedResourceId)]
        public void LessThanOrEqualOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = new ResourceIdentifier(string1);
            ResourceIdentifier id2 = new ResourceIdentifier(string2);
            Assert.AreEqual(expected, id1 <= id2);
        }

        [TestCase(false, TrackedResourceId, TrackedResourceId)]
        [TestCase(false, TrackedResourceId, ChildResourceId)]
        [TestCase(true, ChildResourceId, TrackedResourceId)]
        public void GreaterThanOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = new ResourceIdentifier(string1);
            ResourceIdentifier id2 = new ResourceIdentifier(string2);
            Assert.AreEqual(expected, id1 > id2);
        }

        [TestCase(true, TrackedResourceId, TrackedResourceId)]
        [TestCase(false, TrackedResourceId, ChildResourceId)]
        [TestCase(true, ChildResourceId, TrackedResourceId)]
        public void GreaterThanOrEqualOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = new ResourceIdentifier(string1);
            ResourceIdentifier id2 = new ResourceIdentifier(string2);
            Assert.AreEqual(expected, id1 >= id2);
        }

        [Test]
        public void LessThanNull()
        {
            ResourceIdentifier id = new ResourceIdentifier(TrackedResourceId);
            Assert.IsTrue(null < id);
            Assert.IsFalse(id < null);
        }

        [Test]
        public void LessThanOrEqualNull()
        {
            ResourceIdentifier id = new ResourceIdentifier(TrackedResourceId);
            Assert.IsTrue(null <= id);
            Assert.IsFalse(id <= null);
        }

        [Test]
        public void GreaterThanNull()
        {
            ResourceIdentifier id = new ResourceIdentifier(TrackedResourceId);
            Assert.IsFalse(null > id);
            Assert.IsTrue(id > null);
        }

        [Test]
        public void GreaterThanOrEqualNull()
        {
            ResourceIdentifier id = new ResourceIdentifier(TrackedResourceId);
            Assert.IsFalse(null >= id);
            Assert.IsTrue(id >= null);
        }
    }
}
