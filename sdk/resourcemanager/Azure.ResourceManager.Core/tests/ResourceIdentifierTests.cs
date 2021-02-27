using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
{
    public class ResourceIdentifierTests
    {
        const string TrackedResourceId =
            "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm";
        const string ChildResourceId =
            "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/vortualNetworks/myNet/subnets/mySubnet";
        const string ResourceGroupResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg";
        const string LocationResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/locations/MyLocation";
        const string SubscriptionResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575";

        [SetUp]
        public void Setup()
        {
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
            Assert.Throws<ArgumentOutOfRangeException>(() => { ResourceIdentifier subject = invalidID; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { ResourceIdentifier subject = new ResourceIdentifier(invalidID); });
        }

        [TestCase (null)]
        [TestCase (TrackedResourceId)]
        [TestCase(ChildResourceId)]
        [TestCase(ResourceGroupResourceId)]
        [TestCase(LocationResourceId)]
        [TestCase(SubscriptionResourceId)]
        public void ImplicitConstructor(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z;

            z = x;
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

        [TestCase (TrackedResourceId)]
        [TestCase (ChildResourceId)]
        [TestCase (ResourceGroupResourceId)]
        [TestCase (LocationResourceId)]
        [TestCase (SubscriptionResourceId)]
        [TestCase(null)]
        public void PublicConstructor(string resourceProviderID)
        {
            if (resourceProviderID is null)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => { ResourceIdentifier myResource = new ResourceIdentifier(resourceProviderID); });
            }
            else
            {
                ResourceIdentifier myResource = new ResourceIdentifier(resourceProviderID);
                Assert.AreEqual(myResource.ToString(), resourceProviderID);
            }
        }

        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Compute", "virtualMachines", "myVM")]
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "!@#$%^&*()-_+=;:'\",<.>/?", "Microsoft.Network", "virtualNetworks", "MvVM_vnet")]
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Network", "publicIpAddresses", "!@#$%^&*()-_+=;:'\",<.>/?")]
        public void CanParseRPIds(string subscription, string resourceGroup, string provider, string type, string name)
        {
            var resourceId = $"/subscriptions/{subscription}/resourceGroups/{Uri.EscapeDataString(resourceGroup)}/providers/{provider}/{type}/{Uri.EscapeDataString(name)}";
            ResourceIdentifier subject = resourceId;
            Assert.AreEqual(subject.ToString(), resourceId);
            Assert.AreEqual(subject.Subscription, subscription);
            Assert.AreEqual(Uri.UnescapeDataString(subject.ResourceGroup), resourceGroup);
            Assert.AreEqual(subject.Type.Namespace, provider);
            Assert.AreEqual(subject.Type.Type, type);
            Assert.AreEqual(Uri.UnescapeDataString(subject.Name), name);
        }

        [TestCase(TrackedResourceId, "Microsoft.Authorization", "roleAssignments", "myRa")]
        [TestCase(ChildResourceId, "Microsoft.Authorization", "roleAssignments", "myRa")]
        [TestCase(ResourceGroupResourceId, "Microsoft.Authorization", "roleAssignments", "myRa")]
        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleAssignments", "myRa")]
        [TestCase(SubscriptionResourceId, "Microsoft.Authorization", "roleAssignments", "myRa")]
        public void CanParseExtensionResourceIds(string baseId, string extensionNamespace, string extensionType, string extensionName)
        {
            ResourceIdentifier targetResourceId = baseId;
            ResourceIdentifier subject = $"{baseId}/providers/{extensionNamespace}/{extensionType}/{extensionName}";
            ResourceType expectedType = $"{extensionNamespace}/{extensionType}";
            Assert.AreNotEqual(targetResourceId.Type, subject.Type);
            Assert.AreEqual(expectedType, subject.Type);
            Assert.NotNull(subject.Parent);
            Assert.AreEqual(targetResourceId, subject.Parent);
        }

        [TestCase ("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Web","appServices/myApp/config", "appServices/config")]
        public void CanParseProxyResource(string subscription, string rg, string resourceNamespace, string resource, string type)
        {
            string id = $"/subscriptions/{subscription}/resourceGroups/{rg}/providers/{resourceNamespace}/{resource}";
            ResourceIdentifier subject = id;
            Assert.AreEqual(subject.ToString(), id);
            Assert.AreEqual(subject.Subscription, subscription);
            Assert.AreEqual(subject.Type.Namespace, resourceNamespace);
            Assert.AreEqual(subject.Type.Type, type);
        }

        [Test]
        public void CanParseSubscriptions()
        {
            ResourceIdentifier subject = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575";
            Assert.AreEqual(subject.ToString(), "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");
            Assert.AreEqual(subject.Subscription, "0c2f6471-1bf0-4dda-aec3-cb9272f09575");
            Assert.AreEqual(subject.Type.Namespace, "Microsoft.Resources");
            Assert.AreEqual(subject.Type.Type, "subscriptions");
        }

        [Test]
        public void CanParseResourceGroups()
        {
            ResourceIdentifier subject = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg";
            Assert.AreEqual(subject.ToString(), "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
            Assert.AreEqual(subject.Subscription, "0c2f6471-1bf0-4dda-aec3-cb9272f09575");
            Assert.AreEqual(subject.ResourceGroup, "myRg");
            Assert.AreEqual(subject.Type.Namespace, "Microsoft.Resources");
            Assert.AreEqual(subject.Type.Type, "resourceGroups");
        }

        [TestCase("MyVnet", "MySubnet")]
        [TestCase("!@#$%^&*()-_+=;:'\",<.>/?", "MySubnet")]
        [TestCase("MyVnet", "!@#$%^&*()-_+=;:'\",<.>/?")]
        public void CanParseChildResources(string parentName, string name)
        {
            var resourceId = $"/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/{Uri.EscapeDataString(parentName)}/subnets/{Uri.EscapeDataString(name)}";
            ResourceIdentifier subject = resourceId;
            Assert.AreEqual(subject.ToString(), resourceId);
            Assert.AreEqual(subject.Subscription, "0c2f6471-1bf0-4dda-aec3-cb9272f09575");
            Assert.AreEqual(Uri.UnescapeDataString(subject.ResourceGroup), "myRg");
            Assert.AreEqual(subject.Type.Namespace, "Microsoft.Network");
            Assert.AreEqual(subject.Type.Parent.Type, "virtualNetworks");
            Assert.AreEqual(subject.Type.Type, "virtualNetworks/subnets");
            Assert.AreEqual(Uri.UnescapeDataString(subject.Name), name);

            // check parent type parsing
            var parentResource = $"/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/{Uri.EscapeDataString(parentName)}";
            Assert.AreEqual(subject.Parent, parentResource);
            Assert.AreEqual(subject.Parent.ToString(), parentResource);
            Assert.AreEqual(subject.Parent.Subscription, "0c2f6471-1bf0-4dda-aec3-cb9272f09575");
            Assert.AreEqual(Uri.UnescapeDataString(subject.Parent.ResourceGroup), "myRg");
            Assert.AreEqual(subject.Parent.Type.Namespace, "Microsoft.Network");
            Assert.AreEqual(subject.Parent.Type.Type, "virtualNetworks");
            Assert.AreEqual(Uri.UnescapeDataString(subject.Parent.Name), parentName);
        }

        [TestCase("UnformattedString", Description ="Too Few Elements")]
        [TestCase("/subs/sub1/rgs/rg1/", Description =  "No known parts")]
        [TestCase("/subscriptions/sub1/resourceGroups", Description = "Too few parts")]
        public void ThrowsOnInvalidUri(string resourceId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(() => ConvertToResourceId(resourceId)));
        }

        public ResourceIdentifier ConvertToResourceId(string resourceId)
        {
            ResourceIdentifier subject = resourceId;
            return subject;
        }

        [TestCase(true, "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport", "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport")]
        [TestCase(false, "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport2", "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport")]
        [TestCase(false, "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport", "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test")]        
        public void CheckHashCode(bool expected, string resourceId1, string resourceId2)
        {
            ResourceIdentifier resourceIdentifier1 = new ResourceIdentifier(resourceId1);
            ResourceIdentifier resourceIdentifier2 = new ResourceIdentifier(resourceId2);
            Assert.AreEqual(expected, resourceIdentifier1.GetHashCode() == resourceIdentifier2.GetHashCode());
        }

        [TestCase(TrackedResourceId, TrackedResourceId, true)]
        [TestCase(ChildResourceId, ChildResourceId, true)]
        [TestCase(null, null, true)]
        [TestCase(TrackedResourceId, ChildResourceId, false)]
        [TestCase(ChildResourceId, TrackedResourceId, false)]
        [TestCase(null, TrackedResourceId, false)]
        public void Equals(string resourceProviderID1, string resourceProviderID2, bool expected)
        {
            ResourceIdentifier a = resourceProviderID1;
            ResourceIdentifier b = resourceProviderID2;
            if(a != null)
                Assert.AreEqual(expected, a.Equals(b));

            Assert.AreEqual(expected, ResourceIdentifier.Equals(a,b));
        }

        [TestCase(TrackedResourceId, TrackedResourceId, 0)]
        [TestCase(TrackedResourceId, ChildResourceId, -1)]
        [TestCase(ChildResourceId, TrackedResourceId, 1)]
        [TestCase(TrackedResourceId, null, 1)]
        [TestCase(null, TrackedResourceId, -1)]
        [TestCase(null, null, 0)]
        public void CompareToResourceProvider(string resourceProviderID1, string resourceProviderID2, int expected)
        {
            ResourceIdentifier a = resourceProviderID1;
            ResourceIdentifier b = resourceProviderID2;
            if (a != null)
                Assert.AreEqual(expected, a.CompareTo(b));

            Assert.AreEqual(expected, ResourceIdentifier.CompareTo(a, b));
        }

        [TestCase(TrackedResourceId, TrackedResourceId, 0)]
        [TestCase(TrackedResourceId, ChildResourceId, -1)]
        [TestCase(ChildResourceId, TrackedResourceId, 1)]
        [TestCase(TrackedResourceId, null, 1)]
        [TestCase(null, TrackedResourceId, -1)]
        [TestCase(null, null, 0)]
        public void CompareToString(string resourceProviderID1, string resourceProviderID2, int expected)
        {
            ResourceIdentifier a = resourceProviderID1;
            string b = resourceProviderID2;
            if (a != null)
                Assert.AreEqual(expected, a.CompareTo(b));

            Assert.AreEqual(expected, ResourceIdentifier.CompareTo(a, b));
        }
    }
}
