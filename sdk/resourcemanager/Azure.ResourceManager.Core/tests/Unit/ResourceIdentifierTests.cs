using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
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

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(TenantResourceId)]
        public void CanParseTenant(string id)
        {
            ResourceIdentifier asIdentifier = id;
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
            Assert.Throws<ArgumentOutOfRangeException>(() => { ResourceIdentifier subject = id; });
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
            Assert.Throws<ArgumentOutOfRangeException>(() => { ResourceIdentifier subject = ResourceIdentifier.Create(invalidID); });
        }

        [TestCase(null)]
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
                Assert.Throws<ArgumentNullException>(() => { ResourceIdentifier myResource = ResourceIdentifier.Create(resourceProviderID); });
            }
            else
            {
                ResourceIdentifier myResource = ResourceIdentifier.Create(resourceProviderID);
                Assert.AreEqual(myResource.ToString(), resourceProviderID);
            }
        }

        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Compute", "virtualMachines", "myVM")]
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "!@#$%^&*()-_+=;:'\",<.>/?", "Microsoft.Network", "virtualNetworks", "MvVM_vnet")]
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Network", "publicIpAddresses", "!@#$%^&*()-_+=;:'\",<.>/?")]
        public void CanParseRPIds(string subscription, string resourceGroup, string provider, string type, string name)
        {
            var resourceId = $"/subscriptions/{subscription}/resourceGroups/{Uri.EscapeDataString(resourceGroup)}/providers/{provider}/{type}/{Uri.EscapeDataString(name)}";
            ResourceGroupResourceIdentifier subject = resourceId;
            Assert.AreEqual(resourceId, subject.ToString());
            Assert.AreEqual(subscription, subject.SubscriptionId);
            Assert.AreEqual(resourceGroup, Uri.UnescapeDataString(subject.ResourceGroupName));
            Assert.AreEqual(provider, subject.ResourceType.Namespace);
            Assert.AreEqual(type, subject.ResourceType.Type);
            Assert.AreEqual(name, Uri.UnescapeDataString(subject.Name));
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
            Assert.AreNotEqual(targetResourceId.ResourceType, subject.ResourceType);
            Assert.AreEqual(expectedType, subject.ResourceType);
            Assert.NotNull(subject.Parent);
            Assert.AreEqual(targetResourceId, subject.Parent);
        }

        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Web", "appServices/myApp/config", "appServices/config")]
        public void CanParseProxyResource(string subscription, string rg, string resourceNamespace, string resource, string type)
        {
            string id = $"/subscriptions/{subscription}/resourceGroups/{rg}/providers/{resourceNamespace}/{resource}";
            ResourceGroupResourceIdentifier subject = id;
            Assert.AreEqual(id, subject.ToString());
            Assert.AreEqual(subscription, subject.SubscriptionId);
            Assert.AreEqual(resourceNamespace, subject.ResourceType.Namespace);
            Assert.AreEqual(type, subject.ResourceType.Type);
        }

        [Test]
        public void CanParseSubscriptions()
        {
            SubscriptionResourceIdentifier subject = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575";
            Assert.AreEqual("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources", subject.ResourceType.Namespace);
            Assert.AreEqual("subscriptions", subject.ResourceType.Type);
        }

        [Test]
        public void CanParseResourceGroups()
        {
            ResourceGroupResourceIdentifier subject = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg";
            Assert.AreEqual("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg", subject.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.SubscriptionId);
            Assert.AreEqual("myRg", subject.ResourceGroupName);
            Assert.AreEqual("Microsoft.Resources", subject.ResourceType.Namespace);
            Assert.AreEqual("resourceGroups", subject.ResourceType.Type);
        }

        [TestCase("MyVnet", "MySubnet")]
        [TestCase("!@#$%^&*()-_+=;:'\",<.>/?", "MySubnet")]
        [TestCase("MyVnet", "!@#$%^&*()-_+=;:'\",<.>/?")]
        public void CanParseChildResources(string parentName, string name)
        {
            var resourceId = $"/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/{Uri.EscapeDataString(parentName)}/subnets/{Uri.EscapeDataString(name)}";
            ResourceGroupResourceIdentifier subject = resourceId;
            Assert.AreEqual(resourceId, subject.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.SubscriptionId);
            Assert.AreEqual("myRg", Uri.UnescapeDataString(subject.ResourceGroupName));
            Assert.AreEqual("Microsoft.Network", subject.ResourceType.Namespace);
            Assert.AreEqual("virtualNetworks", subject.Parent.ResourceType.Type);
            Assert.AreEqual("virtualNetworks/subnets", subject.ResourceType.Type);
            Assert.AreEqual(name, Uri.UnescapeDataString(subject.Name));

            // check parent type parsing
            ResourceGroupResourceIdentifier parentResource = $"/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/{Uri.EscapeDataString(parentName)}";
            Assert.AreEqual(parentResource, subject.Parent);
            Assert.AreEqual(parentResource.ToString(), subject.Parent.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", ((ResourceGroupResourceIdentifier)subject.Parent).SubscriptionId);
            Assert.AreEqual("myRg", Uri.UnescapeDataString(((ResourceGroupResourceIdentifier)subject.Parent).ResourceGroupName));
            Assert.AreEqual("Microsoft.Network", subject.Parent.ResourceType.Namespace);
            Assert.AreEqual("virtualNetworks", subject.Parent.ResourceType.Type);
            Assert.AreEqual(parentName, Uri.UnescapeDataString(subject.Parent.Name));
        }

        [TestCase("UnformattedString", Description = "Too Few Elements")]
        [TestCase("/subs/sub1/rgs/rg1/", Description = "No known parts")]
        [TestCase("/subscriptions/sub1/rgs/rg1/", Description = "Subscription not a Guid")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups", Description = "Too few parts")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets", Description = "Subscription resource with too few parts")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/widgets/myWidget", Description = "Subscription resource with invalid child")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/widgets", Description = "ResourceGroup ID with Too few parts")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/widgets/myWidget", Description = "ResourceGroup ID with invalid child")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/providers/Microsoft.Widgets/widgets", Description = "ResourceGroup provider ID with Too few parts")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/incomplete", Description = "Too few parts for location resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/providers/incomplete", Description = "Too few parts for location resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/providers/myProvider/myResource/myResourceName/providers/incomplete", Description = "Too few parts for location resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/providers/Company.MyProvider/myResources/myResourceName/providers/incomplete", Description = "Too few parts for resource group resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Company.MyProvider/myResources/myResourceName/providers/incomplete", Description = "Too few parts for subscription resource")]
        [TestCase("/providers/Company.MyProvider/myResources/myResourceName/providers/incomplete", Description = "Too few parts for tenant resource")]
        public void ThrowsOnInvalidUri(string resourceId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(() => ConvertToResourceId(resourceId)));
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/myResourceType/myResourceName", Description = "location child resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/myResourceType/myResourceName/mySingletonResource", Description = "location child singleton resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/providers/myProvider/myResourceType/myResourceName", Description = "location provider resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/providers/myProvider/myResourceType/myResourceName/myChildResource/myChildResourceName", Description = "location provider child resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2/providers/myProvider/myResourceType/myResourceName/providers/mySecondNamespace/myChildResource/myChildResourceName", Description = "location extension resource")]
        public void CanParseValidLocationResource(string resourceId)
        {
            var id = ConvertToResourceId(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/configuration", Description = "singleton homed in a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/providers/Contoso.Extensions/extensions/myExtension", Description = "Extension over a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/flanges/myFlange", Description = "Child of a subscription resource")]
        public void CanParseValidSubscriptionResource(string resourceId)
        {
            SubscriptionResourceIdentifier subscription = resourceId;
            Assert.AreEqual(resourceId, subscription.ToString());
        }

        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/configuration", Description = "singleton homed in a tenant resource")]
        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/providers/Contoso.Extensions/extensions/myExtension", Description = "Extension over a subscription resource")]
        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/flanges/myFlange", Description = "Child of a subscription resource")]
        public void CanParseValidTenantResource(string resourceId)
        {
            TenantResourceIdentifier tenant = resourceId;
            Assert.AreEqual(resourceId, tenant.ToString());
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/tagNames/azsecpack", Description = "No provider tagname")]
        public void CanParseValidNoProviderResource(string resourceId)
        {
            SubscriptionResourceIdentifier subscription = resourceId;
            Assert.AreEqual(resourceId, subscription.ToString());
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
            ResourceIdentifier resourceIdentifier1 = new ResourceGroupResourceIdentifier(resourceId1);
            ResourceIdentifier resourceIdentifier2 = new ResourceGroupResourceIdentifier(resourceId2);
            Assert.AreEqual(expected, resourceIdentifier1.GetHashCode() == resourceIdentifier2.GetHashCode());
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
            ResourceIdentifier a = resourceProviderID1;
            ResourceIdentifier b = resourceProviderID2;
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
            ResourceIdentifier a = resourceProviderID1;
            if (a != null)
                Assert.AreEqual(expected, a.Equals(resourceProviderID2));

            Assert.AreEqual(expected, ResourceIdentifier.Equals(a, resourceProviderID2));
        }

        [Test]
        public void EqualsObj()
        {
            object input = TrackedResourceId;
            ResourceIdentifier resource = new ResourceGroupResourceIdentifier(TrackedResourceId);
            Assert.AreEqual(true, resource.Equals(input));
            Assert.IsFalse(resource.Equals(new object()));
        }

        [Test]
        public void TryGetPropertiesForTenantResource()
        {
            TenantResourceIdentifier id1 = "/providers/Contoso.Widgets/widgets/myWidget";
            Assert.AreEqual(false, id1.TryGetSubscriptionId(out _));
            Assert.AreEqual(false, id1.TryGetLocation(out _));
            Assert.AreEqual(false, id1.TryGetResourceGroupName(out _));
            Assert.AreEqual(false, id1.TryGetParent(out _));
            TenantResourceIdentifier id2 = "/providers/Contoso.Widgets/widgets/myWidget/flages/myFlange";
            ResourceIdentifier parent;
            Assert.AreEqual(true, id2.TryGetParent(out parent));
            Assert.AreEqual(true, id1.Equals(parent));
        }

        [Test]
        public void TryGetPropertiesForSubscriptionResource()
        {
            SubscriptionResourceIdentifier id1 = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/providers/Contoso.Widgets/widgets/myWidget";
            string subscription;
            Assert.AreEqual(true, id1.TryGetSubscriptionId(out subscription));
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", subscription);
            Assert.AreEqual(false, id1.TryGetLocation(out _));
            Assert.AreEqual(false, id1.TryGetResourceGroupName(out _));
            ResourceIdentifier expectedId = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101";
            ResourceIdentifier parentId;
            Assert.AreEqual(true, id1.TryGetParent(out parentId));
            Assert.IsTrue(expectedId.Equals(parentId));
        }

        [Test]
        public void TryGetPropertiesForSubscriptionProvider()
        {
            SubscriptionResourceIdentifier id1 = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute";
            string subscription;
            Assert.AreEqual(true, id1.TryGetSubscriptionId(out subscription));
            Assert.AreEqual("db1ab6f0-4769-4b27-930e-01e2ef9c123c", subscription);
            Assert.AreEqual(false, id1.TryGetLocation(out _));
            Assert.AreEqual(false, id1.TryGetResourceGroupName(out _));
            ResourceIdentifier expectedId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            ResourceIdentifier parentId;
            Assert.AreEqual(true, id1.TryGetParent(out parentId));
            Assert.IsTrue(expectedId.Equals(parentId));
        }

        [Test]
        public void TryGetPropertiesForLocationResource()
        {
            LocationResourceIdentifier id1 = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2/providers/Contoso.Widgets/widgets/myWidget";
            string subscription;
            Assert.AreEqual(true, id1.TryGetSubscriptionId(out subscription));
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", subscription);
            LocationData location;
            Assert.AreEqual(true, id1.TryGetLocation(out location));
            Assert.AreEqual(LocationData.WestUS2, location);
            Assert.AreEqual(false, id1.TryGetResourceGroupName(out _));
            ResourceIdentifier expectedId = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2";
            ResourceIdentifier parentId;
            Assert.AreEqual(true, id1.TryGetParent(out parentId));
            Assert.IsTrue(expectedId.Equals(parentId));
        }

        [Test]
        public void TryGetPropertiesForResourceGroupResource()
        {
            ResourceGroupResourceIdentifier id1 = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg/providers/Contoso.Widgets/widgets/myWidget";
            string subscription;
            Assert.AreEqual(true, id1.TryGetSubscriptionId(out subscription));
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", subscription);
            Assert.AreEqual(false, id1.TryGetLocation(out _));
            string resourceGroupName;
            Assert.AreEqual(true, id1.TryGetResourceGroupName(out resourceGroupName));
            Assert.AreEqual("myRg", resourceGroupName);
            ResourceIdentifier expectedId = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg";
            ResourceIdentifier parentId;
            Assert.AreEqual(true, id1.TryGetParent(out parentId));
            Assert.IsTrue(expectedId.Equals(parentId));
        }

        [TestCase("/providers/Contoso.Widgets/widgets/myWidget", null, null, null, null, Description = "TenantResourceIdentifier")]
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
            ResourceIdentifier id1 = resourceId;
            string outputSubscription;
            Assert.AreEqual(!(subscription is null), id1.TryGetSubscriptionId(out outputSubscription));
            if (!(subscription is null))
                Assert.AreEqual(subscription, outputSubscription);
            LocationData outputLocation;
            Assert.AreEqual(!(location is null), id1.TryGetLocation(out outputLocation));
            if (!(location is null))
                Assert.AreEqual(location, outputLocation.Name);
            string outputResourceGroup;
            Assert.AreEqual(!(resourceGroup is null), id1.TryGetResourceGroupName(out outputResourceGroup));
            if (!(resourceGroup is null))
                Assert.AreEqual(resourceGroup, outputResourceGroup);
            ResourceIdentifier outputParent;
            Assert.AreEqual(!(parent is null), id1.TryGetParent(out outputParent));
            if (!(parent is null))
                Assert.AreEqual(parent, outputParent.ToString());
        }

        [TestCase("/providers/Contoso.Widgets//widgets/myWidget", Description = "TenantResourceIdentifier")]
        [TestCase("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/providers//Contoso.Widgets/widgets/myWidget",
            Description = "SubscriptionResourceIdentifier")]
        [TestCase("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101//locations/westus2/providers/Contoso.Widgets/widgets/myWidget",
            Description = "LocationResourceIdentifier")]
        [TestCase("/subscriptions//6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg/providers/Contoso.Widgets/widgets/myWidget",
            Description = "ResourceGroupResourceIdentifier")]
        public void ResourceIdRetainsOriginalInput(string resourceId)
        {
            ResourceIdentifier id = resourceId;
            Assert.AreEqual(resourceId, id.ToString());
        }

        [Test]
        public void ThrowOnMistypedResource()
        {
            TenantResourceIdentifier tenant;
            Assert.Throws<ArgumentException>(() => tenant = new TenantResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101"));
            Assert.Throws<ArgumentException>(() => tenant = new TenantResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2"));
            Assert.Throws<ArgumentException>(() => tenant = new TenantResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg"));
            Assert.DoesNotThrow(() => tenant = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101");
            Assert.DoesNotThrow(() => tenant = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2");
            Assert.DoesNotThrow(() => tenant = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg");
            SubscriptionResourceIdentifier subscription = "/providers/Contoso.Widgets/widgets/myWidget";
            Assert.IsNull(subscription);
            Assert.Throws<ArgumentException>(() => subscription = new SubscriptionResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2"));
            Assert.Throws<ArgumentException>(() => subscription = new SubscriptionResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg"));
            Assert.DoesNotThrow(() => subscription = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2");
            Assert.DoesNotThrow(() => subscription = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg");
            ResourceGroupResourceIdentifier group = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101";
            Assert.IsNull(group);
            LocationResourceIdentifier location = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101";
            Assert.IsNull(location);
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
            ResourceIdentifier b = (ResourceIdentifier)resourceProviderID2;
            if (a != null)
                Assert.AreEqual(expected, a.CompareTo(b));

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
        }

        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget", "Microsoft.Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "Microsoft.Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", null, "roleAssignments", "MyRoleAssignemnt")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "Microsoft.Authorization", null, "MyRoleAssignemnt")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "Microsoft.Authorization", "roleAssignments", null)]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "Microsoft.Authorization", "   ", "MyRoleAssignemnt")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "Microsoft.Authorization", "roleAssignments", "")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "Microsoft/Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "Microsoft.Authorization", "roleA/ssignments", "MyRoleAssignemnt")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "Microsoft.Authorization", "roleAssignments", "MyRole/Assignemnt")]
        public void TestAppendTenantProviderResource(string resourceId, string providerNamespace, string resourceTypeName, string resourceName)
        {
            TenantResourceIdentifier resource = resourceId;
            if (providerNamespace is null || resourceTypeName is null || resourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (string.IsNullOrWhiteSpace(providerNamespace) || string.IsNullOrWhiteSpace(resourceTypeName) || string.IsNullOrWhiteSpace(resourceName))
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (providerNamespace.Contains("/") || resourceTypeName.Contains("/") || resourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else
            {
                var expected = $"{resourceId}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}";
                Assert.AreEqual(expected, resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName).ToString());
            }
        }

        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget", "wheels", "Wheel1")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "wheels", "Wheel2")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", null, "wheel2")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "wheels", null)]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "", "wheel2")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "wheels", "  ")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "wheels/spokes", "wheel2")]
        [TestCase("/providers/Microsoft.Widgets/widgets/MyWidget/things/MyThing", "wheels", "wheel1/wheel2")]
        public void TestAppendTenantChildResource(string resourceId, string childTypeName, string childResourceName)
        {
            TenantResourceIdentifier resource = resourceId;
            if (childTypeName is null || childResourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (string.IsNullOrWhiteSpace(childTypeName) || string.IsNullOrWhiteSpace(childResourceName))
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (childTypeName.Contains("/") || childResourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else
            {
                var expected = $"{resourceId}/{childTypeName}/{childResourceName}";
                Assert.AreEqual(expected, resource.AppendChildResource(childTypeName, childResourceName).ToString());
            }
        }

        [TestCase(SubscriptionResourceId, "Microsoft.Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(SubscriptionResourceId, null, "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(SubscriptionResourceId, "Microsoft.Authorization", null, "MyRoleAssignemnt")]
        [TestCase(SubscriptionResourceId, "Microsoft.Authorization", "roleAssignments", null)]
        [TestCase(SubscriptionResourceId, "", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(SubscriptionResourceId, "Microsoft.Authorization", "   ", "MyRoleAssignemnt")]
        [TestCase(SubscriptionResourceId, "Microsoft.Authorization", "roleAssignments", "")]
        [TestCase(SubscriptionResourceId, "Microsoft/Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(SubscriptionResourceId, "Microsoft.Authorization", "roleA/ssignments", "MyRoleAssignemnt")]
        [TestCase(SubscriptionResourceId, "Microsoft.Authorization", "roleAssignments", "MyRole/Assignemnt")]

        public void TestAppendSubscriptionProviderResource(string resourceId, string providerNamespace, string resourceTypeName, string resourceName)
        {
            SubscriptionResourceIdentifier resource = resourceId;
            if (providerNamespace is null || resourceTypeName is null || resourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (string.IsNullOrWhiteSpace(providerNamespace) || string.IsNullOrWhiteSpace(resourceTypeName) || string.IsNullOrWhiteSpace(resourceName))
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (providerNamespace.Contains("/") || resourceTypeName.Contains("/") || resourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else
            {
                var expected = $"{resourceId}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}";
                Assert.AreEqual(expected, resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName).ToString());
            }
        }

        [TestCase(SubscriptionResourceId, "wheels", "Wheel2")]
        [TestCase(SubscriptionResourceId, null, "wheel2")]
        [TestCase(SubscriptionResourceId, "wheels", null)]
        [TestCase(SubscriptionResourceId, "", "wheel2")]
        [TestCase(SubscriptionResourceId, "wheels", "  ")]
        [TestCase(SubscriptionResourceId, "wheels/spokes", "wheel2")]
        [TestCase(SubscriptionResourceId, "wheels", "wheel1/wheel2")]
        public void TestAppendSubscriptionChildResource(string resourceId, string childTypeName, string childResourceName)
        {
            SubscriptionResourceIdentifier resource = resourceId;
            if (childTypeName is null || childResourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (string.IsNullOrWhiteSpace(childTypeName) || string.IsNullOrWhiteSpace(childResourceName))
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (childTypeName.Contains("/") || childResourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else
            {
                var expected = $"{resourceId}/{childTypeName}/{childResourceName}";
                Assert.AreEqual(expected, resource.AppendChildResource(childTypeName, childResourceName).ToString());
            }
        }

        [TestCase(ResourceGroupResourceId, "Microsoft.Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(ResourceGroupResourceId, null, "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(ResourceGroupResourceId, "Microsoft.Authorization", null, "MyRoleAssignemnt")]
        [TestCase(ResourceGroupResourceId, "Microsoft.Authorization", "roleAssignments", null)]
        [TestCase(ResourceGroupResourceId, "", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(ResourceGroupResourceId, "Microsoft.Authorization", "   ", "MyRoleAssignemnt")]
        [TestCase(ResourceGroupResourceId, "Microsoft.Authorization", "roleAssignments", "")]
        [TestCase(ResourceGroupResourceId, "Microsoft/Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(ResourceGroupResourceId, "Microsoft.Authorization", "roleA/ssignments", "MyRoleAssignemnt")]
        [TestCase(ResourceGroupResourceId, "Microsoft.Authorization", "roleAssignments", "MyRole/Assignemnt")]

        public void TestAppendResourceGroupProviderResource(string resourceId, string providerNamespace, string resourceTypeName, string resourceName)
        {
            ResourceGroupResourceIdentifier resource = resourceId;
            if (providerNamespace is null || resourceTypeName is null || resourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (string.IsNullOrWhiteSpace(providerNamespace) || string.IsNullOrWhiteSpace(resourceTypeName) || string.IsNullOrWhiteSpace(resourceName))
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (providerNamespace.Contains("/") || resourceTypeName.Contains("/") || resourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else
            {
                var expected = $"{resourceId}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}";
                Assert.AreEqual(expected, resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName).ToString());
            }
        }

        [TestCase(ResourceGroupResourceId, "wheels", "Wheel1")]
        [TestCase(ResourceGroupResourceId, "wheels", "Wheel2")]
        [TestCase(ResourceGroupResourceId, null, "wheel2")]
        [TestCase(ResourceGroupResourceId, "wheels", null)]
        [TestCase(ResourceGroupResourceId, "", "wheel2")]
        [TestCase(ResourceGroupResourceId, "wheels", "  ")]
        [TestCase(ResourceGroupResourceId, "wheels/spokes", "wheel2")]
        [TestCase(ResourceGroupResourceId, "wheels", "wheel1/wheel2")]
        public void TestAppendResourceGroupChildResource(string resourceId, string childTypeName, string childResourceName)
        {
            ResourceGroupResourceIdentifier resource = resourceId;
            if (childTypeName is null || childResourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (string.IsNullOrWhiteSpace(childTypeName) || string.IsNullOrWhiteSpace(childResourceName))
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (childTypeName.Contains("/") || childResourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else
            {
                var expected = $"{resourceId}/{childTypeName}/{childResourceName}";
                Assert.AreEqual(expected, resource.AppendChildResource(childTypeName, childResourceName).ToString());
            }
        }

        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(LocationResourceId, null, "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(LocationResourceId, "Microsoft.Authorization", null, "MyRoleAssignemnt")]
        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleAssignments", null)]
        [TestCase(LocationResourceId, "", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(LocationResourceId, "Microsoft.Authorization", "   ", "MyRoleAssignemnt")]
        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleAssignments", "")]
        [TestCase(LocationResourceId, "Microsoft/Authorization", "roleAssignments", "MyRoleAssignemnt")]
        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleA/ssignments", "MyRoleAssignemnt")]
        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleAssignments", "MyRole/Assignemnt")]

        public void TestAppendLocationProviderResource(string resourceId, string providerNamespace, string resourceTypeName, string resourceName)
        {
            LocationResourceIdentifier resource = resourceId;
            if (providerNamespace is null || resourceTypeName is null || resourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (string.IsNullOrWhiteSpace(providerNamespace) || string.IsNullOrWhiteSpace(resourceTypeName) || string.IsNullOrWhiteSpace(resourceName))
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (providerNamespace.Contains("/") || resourceTypeName.Contains("/") || resourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else
            {
                var expected = $"{resourceId}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}";
                Assert.AreEqual(expected, resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName).ToString());
            }
        }

        [TestCase(LocationResourceId, "wheels", "Wheel1")]
        [TestCase(LocationResourceId, null, "wheel2")]
        [TestCase(LocationResourceId, "wheels", null)]
        [TestCase(LocationResourceId, "", "wheel2")]
        [TestCase(LocationResourceId, "wheels", "  ")]
        [TestCase(LocationResourceId, "wheels/spokes", "wheel2")]
        [TestCase(LocationResourceId, "wheels", "wheel1/wheel2")]
        public void TestAppendLocationChildResource(string resourceId, string childTypeName, string childResourceName)
        {
            LocationResourceIdentifier resource = resourceId;
            if (childTypeName is null || childResourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (string.IsNullOrWhiteSpace(childTypeName) || string.IsNullOrWhiteSpace(childResourceName))
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (childTypeName.Contains("/") || childResourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else
            {
                var expected = $"{resourceId}/{childTypeName}/{childResourceName}";
                Assert.AreEqual(expected, resource.AppendChildResource(childTypeName, childResourceName).ToString());
            }
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
            ResourceIdentifier a = resourceProviderID1;
            if (comparisonType == "object")
            {
                ResourceIdentifier b = resourceProviderID2;
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
            ResourceIdentifier a = resourceProviderID1;
            if (comparisonType == "object")
            {
                ResourceIdentifier b = resourceProviderID2;
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
            ResourceIdentifier id1 = string1;
            ResourceIdentifier id2 = string2;
            Assert.AreEqual(expected, id1 < id2);
        }

        [TestCase(true, TrackedResourceId, TrackedResourceId)]
        [TestCase(true, TrackedResourceId, ChildResourceId)]
        [TestCase(false, ChildResourceId, TrackedResourceId)]
        public void LessThanOrEqualOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = string1;
            ResourceIdentifier id2 = string2;
            Assert.AreEqual(expected, id1 <= id2);
        }

        [TestCase(false, TrackedResourceId, TrackedResourceId)]
        [TestCase(false, TrackedResourceId, ChildResourceId)]
        [TestCase(true, ChildResourceId, TrackedResourceId)]
        public void GreaterThanOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = string1;
            ResourceIdentifier id2 = string2;
            Assert.AreEqual(expected, id1 > id2);
        }

        [TestCase(true, TrackedResourceId, TrackedResourceId)]
        [TestCase(false, TrackedResourceId, ChildResourceId)]
        [TestCase(true, ChildResourceId, TrackedResourceId)]
        public void GreaterThanOrEqualOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = string1;
            ResourceIdentifier id2 = string2;
            Assert.AreEqual(expected, id1 >= id2);
        }

        [Test]
        public void LessThanNull()
        {
            ResourceIdentifier id = TrackedResourceId;
            Assert.IsTrue(null < id);
            Assert.IsFalse(id < null);
        }

        [Test]
        public void LessThanOrEqualNull()
        {
            ResourceIdentifier id = TrackedResourceId;
            Assert.IsTrue(null <= id);
            Assert.IsFalse(id <= null);
        }

        [Test]
        public void GreaterThanNull()
        {
            ResourceIdentifier id = TrackedResourceId;
            Assert.IsFalse(null > id);
            Assert.IsTrue(id > null);
        }

        [Test]
        public void GreaterThanOrEqualNull()
        {
            ResourceIdentifier id = TrackedResourceId;
            Assert.IsFalse(null >= id);
            Assert.IsTrue(id >= null);
        }
    }
}
