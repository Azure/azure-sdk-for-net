using System;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceGroupResourceIdentifierTests : ResourceIdentifierTests
    {
        const string TrackedResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm";
        const string ResourceGroupResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg";

        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Compute", "virtualMachines", "myVM")]
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "!@#$%^&*()-_+=;:'\",<.>/?", "Microsoft.Network", "virtualNetworks", "MvVM_vnet")]
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Network", "publicIpAddresses", "!@#$%^&*()-_+=;:'\",<.>/?")]
        public void CanParseRPIds(string subscription, string resourceGroup, string provider, string type, string name)
        {
            var resourceId = $"/subscriptions/{subscription}/resourceGroups/{Uri.EscapeDataString(resourceGroup)}/providers/{provider}/{type}/{Uri.EscapeDataString(name)}";
            ResourceIdentifier subject = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, subject.ToString());
            Assert.AreEqual(subscription, subject.SubscriptionId);
            Assert.AreEqual(resourceGroup, Uri.UnescapeDataString(subject.ResourceGroupName));
            Assert.AreEqual(provider, subject.ResourceType.Namespace);
            Assert.AreEqual(type, subject.ResourceType.Type);
            Assert.AreEqual(name, Uri.UnescapeDataString(subject.Name));
        }

        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Web", "appServices/myApp/config", "appServices/config")]
        public void CanParseProxyResource(string subscription, string rg, string resourceNamespace, string resource, string type)
        {
            string id = $"/subscriptions/{subscription}/resourceGroups/{rg}/providers/{resourceNamespace}/{resource}";
            ResourceIdentifier subject = new ResourceIdentifier(id);
            Assert.AreEqual(id, subject.ToString());
            Assert.AreEqual(subscription, subject.SubscriptionId);
            Assert.AreEqual(resourceNamespace, subject.ResourceType.Namespace);
            Assert.AreEqual(type, subject.ResourceType.Type);
        }

        [Test]
        public void CanParseResourceGroups()
        {
            ResourceIdentifier subject = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
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
            ResourceIdentifier subject = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, subject.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.SubscriptionId);
            Assert.AreEqual("myRg", Uri.UnescapeDataString(subject.ResourceGroupName));
            Assert.AreEqual("Microsoft.Network", subject.ResourceType.Namespace);
            Assert.AreEqual("virtualNetworks", subject.Parent.ResourceType.Type);
            Assert.AreEqual("virtualNetworks/subnets", subject.ResourceType.Type);
            Assert.AreEqual(name, Uri.UnescapeDataString(subject.Name));

            // check parent type parsing
            ResourceIdentifier parentResource = new ResourceIdentifier($"/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/{Uri.EscapeDataString(parentName)}");
            Assert.AreEqual(parentResource, subject.Parent);
            Assert.AreEqual(parentResource.ToString(), subject.Parent.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", ((ResourceIdentifier)subject.Parent).SubscriptionId);
            Assert.AreEqual("myRg", Uri.UnescapeDataString(((ResourceIdentifier)subject.Parent).ResourceGroupName));
            Assert.AreEqual("Microsoft.Network", subject.Parent.ResourceType.Namespace);
            Assert.AreEqual("virtualNetworks", subject.Parent.ResourceType.Type);
            Assert.AreEqual(parentName, Uri.UnescapeDataString(subject.Parent.Name));
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

        [Test]
        public void EqualsObj()
        {
            object input = TrackedResourceId;
            ResourceIdentifier resource = new ResourceIdentifier(TrackedResourceId);
            Assert.AreEqual(true, resource.Equals(input));
            Assert.IsFalse(resource.Equals(new object()));
        }

        [Test]
        public void TryGetPropertiesForResourceGroupResource()
        {
            ResourceIdentifier id1 = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg/providers/Contoso.Widgets/widgets/myWidget");
            Assert.NotNull(id1.SubscriptionId);
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", id1.SubscriptionId);
            Assert.Null(id1.Location);
            Assert.NotNull(id1.ResourceGroupName);
            Assert.AreEqual("myRg", id1.ResourceGroupName);
            ResourceIdentifier expectedId = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg");
            Assert.NotNull(id1.Parent);
            Assert.IsTrue(expectedId.Equals(id1.Parent));
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
            ResourceIdentifier resource = new ResourceIdentifier(resourceId);
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
            ResourceIdentifier resource = new ResourceIdentifier(resourceId);
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
    }
}
