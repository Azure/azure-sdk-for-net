// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [Parallelizable]
    public class ResourceIdentifierTests
    {
        private const string TrackedResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm";
        private const string ChildResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/vortualNetworks/myNet/subnets/mySubnet";
        private const string ResourceGroupResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg";
        private const string LocationResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/locations/MyLocation";
        private const string SubscriptionResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575";
        private const string TenantResourceId = "/providers/Microsoft.Billing/billingAccounts/3984c6f4-2d2a-4b04-93ce-43cf4824b698%3Ae2f1492a-a492-468d-909f-bf7fe6662c01_2019-05-31";
        private const string LocationBaseResourceId = "/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2";
        private const string LocationInDifferentNamespace = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute/locations/westus2";

        private ResourceIdentifier GetResourceIdentifier(string id)
        {
            var fromCtor = new ResourceIdentifier(id);
            var fromParse = ResourceIdentifier.Parse(id);
            ResourceIdentifier fromTryParse;
            Assert.IsTrue(ResourceIdentifier.TryParse(id, out fromTryParse));
            Assert.AreEqual(fromCtor, fromParse);
            Assert.AreEqual(fromParse, fromTryParse);
            return fromCtor;
        }

        #region LocationResouceIdentifier
        [Test]
        public void LocationFromDiffNamespaceWithChildResource()
        {
            string resourceId = $"{LocationInDifferentNamespace}/publishers/128technology";
            var id = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location?.ToString());
            Assert.AreEqual("db1ab6f0-4769-4b27-930e-01e2ef9c123c", id.SubscriptionId);
            Assert.AreEqual("Microsoft.Compute/locations/publishers", id.ResourceType.ToString());
            Assert.AreEqual("128technology", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(false, id.IsProviderResource);
            ValidateLocationBaseResource(id.Parent, LocationInDifferentNamespace, true, "Microsoft.Compute/locations", "db1ab6f0-4769-4b27-930e-01e2ef9c123c");
        }

        [Test]
        public void LocationWithChildResource()
        {
            string resourceId = $"{LocationBaseResourceId}/myResourceType/myResourceName";
            var id = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location?.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/subscriptions/locations/myResourceType", id.ResourceType.ToString());
            Assert.AreEqual("myResourceName", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(false, id.IsProviderResource);
            ValidateLocationBaseResource(id.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithChildSingleton()
        {
            string resourceId = $"{LocationBaseResourceId}/myResourceType/myResourceName/mySingletonResource";
            var id = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location?.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/subscriptions/locations/myResourceType/mySingletonResource", id.ResourceType.ToString());
            Assert.AreEqual(string.Empty, id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(false, id.IsProviderResource);

            var parentId = id.Parent;
            Assert.AreEqual($"{LocationBaseResourceId}/myResourceType/myResourceName", parentId.ToString());
            Assert.AreEqual("westus2", parentId.Location?.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", parentId.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/subscriptions/locations/myResourceType", parentId.ResourceType.ToString());
            Assert.AreEqual("myResourceName", parentId.Name);
            Assert.IsNull(parentId.Provider);
            Assert.AreEqual(false, parentId.IsProviderResource);

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithProviderResource()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName";
            var id = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location?.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("myProvider/myResourceType", id.ResourceType.ToString());
            Assert.AreEqual("myResourceName", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(true, id.IsProviderResource);

            ValidateLocationBaseResource(id.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithProviderResourceWithChild()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName/myChildResource/myChildResourceName";
            var id = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location?.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("myProvider/myResourceType/myChildResource", id.ResourceType.ToString());
            Assert.AreEqual("myChildResourceName", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(false, id.IsProviderResource);

            var parentId = id.Parent;
            Assert.AreEqual($"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName", parentId.ToString());
            Assert.AreEqual("westus2", parentId.Location?.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", parentId.SubscriptionId);
            Assert.AreEqual("myProvider/myResourceType", parentId.ResourceType.ToString());
            Assert.AreEqual("myResourceName", parentId.Name);
            Assert.IsNull(parentId.Provider);
            Assert.AreEqual(true, parentId.IsProviderResource);

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithExtensionResource()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName/providers/mySecondNamespace/myChildResource/myChildResourceName";
            var id = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location?.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("mySecondNamespace/myChildResource", id.ResourceType.ToString());
            Assert.AreEqual("myChildResourceName", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(true, id.IsProviderResource);

            var parentId = id.Parent;
            Assert.AreEqual($"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName", parentId.ToString());
            Assert.AreEqual("westus2", parentId.Location?.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", parentId.SubscriptionId);
            Assert.AreEqual("myProvider/myResourceType", parentId.ResourceType.ToString());
            Assert.AreEqual("myResourceName", parentId.Name);
            Assert.IsNull(parentId.Provider);
            Assert.AreEqual(true, parentId.IsProviderResource);

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void TryGetPropertiesForLocationResource()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2/providers/Contoso.Widgets/widgets/myWidget");
            Assert.NotNull(id1.SubscriptionId);
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", id1.SubscriptionId);
            Assert.IsTrue(id1.Location.HasValue);
            Assert.AreEqual(AzureLocation.WestUS2, id1.Location);
            Assert.Null(id1.ResourceGroupName);
            ResourceIdentifier expectedId = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2");
            Assert.NotNull(id1.Parent);
            Assert.IsTrue(expectedId.Equals(id1.Parent));
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
            ResourceIdentifier resource = GetResourceIdentifier(resourceId);
            if (providerNamespace is null || resourceTypeName is null || resourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (string.IsNullOrWhiteSpace(providerNamespace) || string.IsNullOrWhiteSpace(resourceTypeName) || string.IsNullOrWhiteSpace(resourceName))
                Assert.Throws(typeof(ArgumentException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
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
            ResourceIdentifier resource = GetResourceIdentifier(resourceId);
            if (childTypeName is null || childResourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (string.IsNullOrWhiteSpace(childTypeName) || string.IsNullOrWhiteSpace(childResourceName))
                Assert.Throws(typeof(ArgumentException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (childTypeName.Contains("/") || childResourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else
            {
                var expected = $"{resourceId}/{childTypeName}/{childResourceName}";
                Assert.AreEqual(expected, resource.AppendChildResource(childTypeName, childResourceName).ToString());
            }
        }
        #endregion

        #region ResourceGroupResourceIdentifier
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Compute", "virtualMachines", "myVM")]
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "!@#$%^&*()-_+=;:'\",<.>/?", "Microsoft.Network", "virtualNetworks", "MvVM_vnet")]
        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Network", "publicIpAddresses", "!@#$%^&*()-_+=;:'\",<.>/?")]
        public void CanParseRPIds(string subscription, string resourceGroup, string provider, string type, string name)
        {
            var resourceId = $"/subscriptions/{subscription}/resourceGroups/{Uri.EscapeDataString(resourceGroup)}/providers/{provider}/{type}/{Uri.EscapeDataString(name)}";
            ResourceIdentifier subject = GetResourceIdentifier(resourceId);
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
            ResourceIdentifier subject = GetResourceIdentifier(id);
            Assert.AreEqual(id, subject.ToString());
            Assert.AreEqual(subscription, subject.SubscriptionId);
            Assert.AreEqual(resourceNamespace, subject.ResourceType.Namespace);
            Assert.AreEqual(type, subject.ResourceType.Type);
        }

        [Test]
        public void CanParseResourceGroups()
        {
            ResourceIdentifier subject = GetResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
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
            ResourceIdentifier subject = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, subject.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.SubscriptionId);
            Assert.AreEqual("myRg", Uri.UnescapeDataString(subject.ResourceGroupName));
            Assert.AreEqual("Microsoft.Network", subject.ResourceType.Namespace);
            Assert.AreEqual("virtualNetworks", subject.Parent.ResourceType.Type);
            Assert.AreEqual("virtualNetworks/subnets", subject.ResourceType.Type);
            Assert.AreEqual(name, Uri.UnescapeDataString(subject.Name));

            // check parent type parsing
            ResourceIdentifier parentResource = GetResourceIdentifier($"/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/{Uri.EscapeDataString(parentName)}");
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
            ResourceIdentifier resourceIdentifier1 = GetResourceIdentifier(resourceId1);
            ResourceIdentifier resourceIdentifier2 = GetResourceIdentifier(resourceId2);
            Assert.AreEqual(expected, resourceIdentifier1.GetHashCode() == resourceIdentifier2.GetHashCode());
        }

        [Test]
        public void EqualsObj()
        {
            object input = TrackedResourceId;
            ResourceIdentifier resource = GetResourceIdentifier(TrackedResourceId);
            Assert.AreEqual(true, resource.Equals(input));
            Assert.IsFalse(resource.Equals(new object()));
        }

        [Test]
        public void TryGetPropertiesForResourceGroupResource()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg/providers/Contoso.Widgets/widgets/myWidget");
            Assert.NotNull(id1.SubscriptionId);
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", id1.SubscriptionId);
            Assert.IsFalse(id1.Location.HasValue);
            Assert.NotNull(id1.ResourceGroupName);
            Assert.AreEqual("myRg", id1.ResourceGroupName);
            ResourceIdentifier expectedId = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg");
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
            ResourceIdentifier resource = GetResourceIdentifier(resourceId);
            if (providerNamespace is null || resourceTypeName is null || resourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (string.IsNullOrWhiteSpace(providerNamespace) || string.IsNullOrWhiteSpace(resourceTypeName) || string.IsNullOrWhiteSpace(resourceName))
                Assert.Throws(typeof(ArgumentException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
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
            ResourceIdentifier resource = GetResourceIdentifier(resourceId);
            if (childTypeName is null || childResourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (string.IsNullOrWhiteSpace(childTypeName) || string.IsNullOrWhiteSpace(childResourceName))
                Assert.Throws(typeof(ArgumentException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (childTypeName.Contains("/") || childResourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else
            {
                var expected = $"{resourceId}/{childTypeName}/{childResourceName}";
                Assert.AreEqual(expected, resource.AppendChildResource(childTypeName, childResourceName).ToString());
            }
        }
        #endregion

        #region TenantResourceIdentifier
        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/configuration", Description = "singleton homed in a tenant resource")]
        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/providers/Contoso.Extensions/extensions/myExtension", Description = "Extension over a subscription resource")]
        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/flanges/myFlange", Description = "Child of a subscription resource")]
        public void CanParseValidTenantResource(string resourceId)
        {
            ResourceIdentifier tenant = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, tenant.ToString());
        }

        [Test]
        public void TryGetPropertiesForTenantResource()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/providers/Contoso.Widgets/widgets/myWidget");
            Assert.Null(id1.SubscriptionId);
            Assert.Null(id1.Location);
            Assert.Null(id1.ResourceGroupName);
            Assert.NotNull(id1.Parent);
            ResourceIdentifier id2 = GetResourceIdentifier("/providers/Contoso.Widgets/widgets/myWidget/flages/myFlange");
            Assert.NotNull(id2.Parent);
            Assert.AreEqual(true, id1.Equals(id2.Parent));
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
            ResourceIdentifier resource = GetResourceIdentifier(resourceId);
            if (providerNamespace is null || resourceTypeName is null || resourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (string.IsNullOrWhiteSpace(providerNamespace) || string.IsNullOrWhiteSpace(resourceTypeName) || string.IsNullOrWhiteSpace(resourceName))
                Assert.Throws(typeof(ArgumentException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
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
            ResourceIdentifier resource = GetResourceIdentifier(resourceId);
            if (childTypeName is null || childResourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (string.IsNullOrWhiteSpace(childTypeName) || string.IsNullOrWhiteSpace(childResourceName))
                Assert.Throws(typeof(ArgumentException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (childTypeName.Contains("/") || childResourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else
            {
                var expected = $"{resourceId}/{childTypeName}/{childResourceName}";
                Assert.AreEqual(expected, resource.AppendChildResource(childTypeName, childResourceName).ToString());
            }
        }
        #endregion

        #region TenantProviderResourceIdentifier
        [TestCase("/providers/Microsoft.Insights")]
        public void ImplicitConstructorProviderOnly(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.IsNotNull(z.Parent);
            Assert.AreEqual("Microsoft.Insights", z.Provider);
            Assert.AreEqual("Microsoft.Resources/providers", z.ResourceType.ToString());
            Assert.AreEqual(string.Empty, z.Parent.Name);

            if (resourceProviderID is null)
            {
                Assert.IsNull(z);
                Assert.IsNull(y);
            }
            else
            {
                Assert.AreEqual(resourceProviderID, y);
                Assert.AreEqual(resourceProviderID, y);
            }
        }

        [TestCase("/providers/Microsoft.Insights/providers/Microsoft.Compute/virtualMachines/myVmName")]
        public void ImplicitConstructorVirtualMachine(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.AreEqual("myVmName", z.Name);
            Assert.AreEqual("Microsoft.Compute/virtualMachines", z.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Insights", z.Provider);
            Assert.AreEqual("Microsoft.Insights", z.Parent.Provider);
            Assert.AreEqual("Microsoft.Resources/providers", z.Parent.ResourceType.ToString());

            if (resourceProviderID is null)
            {
                Assert.IsNull(z);
                Assert.IsNull(y);
            }
            else
            {
                Assert.AreEqual(resourceProviderID, y);
                Assert.AreEqual(resourceProviderID, y);
            }
        }

        [TestCase("/providers/Microsoft.Insights/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/testsubnet")]
        public void ImplicitConstructorSubnet(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.AreEqual("testsubnet", z.Name);
            Assert.AreEqual("Microsoft.Network/virtualNetworks/subnets", z.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Insights", z.Provider);
            Assert.AreEqual("Microsoft.Insights", z.Parent.Provider);
            Assert.AreEqual("Microsoft.Insights", z.Parent.Parent.Provider);
            Assert.AreEqual("testvnet", z.Parent.Name);
            Assert.AreEqual("Microsoft.Network/virtualNetworks", z.Parent.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Insights", z.Parent.Parent.Name);
            Assert.AreEqual("Microsoft.Resources/providers", z.Parent.Parent.ResourceType.ToString());

            if (resourceProviderID is null)
            {
                Assert.IsNull(z);
                Assert.IsNull(y);
            }
            else
            {
                Assert.AreEqual(resourceProviderID, y);
                Assert.AreEqual(resourceProviderID, y);
            }
        }
        #endregion

        #region SubscriptionResourceIdentifier
        [Test]
        public void CanParseSubscriptions()
        {
            ResourceIdentifier subject = GetResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");
            Assert.AreEqual("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources", subject.ResourceType.Namespace);
            Assert.AreEqual("subscriptions", subject.ResourceType.Type);
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/configuration", Description = "singleton homed in a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/providers/Contoso.Extensions/extensions/myExtension", Description = "Extension over a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/flanges/myFlange", Description = "Child of a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Microsoft.CognitiveServices/locations/westus/resourceGroups/myResourceGroup/deletedAccounts/myDeletedAccount", Description = "Location before ResourceGroup")]
        public void CanParseValidSubscriptionResource(string resourceId)
        {
            ResourceIdentifier subscription = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, subscription.ToString());
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Microsoft.CognitiveServices/locations/westus/resourceGroups/myResourceGroup/deletedAccounts/myDeletedAccount", "Microsoft.CognitiveServices/locations/resourceGroups/deletedAccounts")]
        public void CanCalculateResourceType(string id, string resourceType)
        {
            ResourceIdentifier resourceId = GetResourceIdentifier(id);
            Assert.AreEqual(resourceType, resourceId.ResourceType.ToString());
            Assert.AreEqual("myResourceGroup", resourceId.ResourceGroupName);
            Assert.AreEqual(AzureLocation.WestUS, resourceId.Location);
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", resourceId.SubscriptionId);
            Assert.AreEqual("myDeletedAccount", resourceId.Name);

            resourceId = resourceId.Parent;
            Assert.AreEqual("Microsoft.CognitiveServices/locations/resourceGroups", resourceId.ResourceType.ToString());
            Assert.AreEqual("myResourceGroup", resourceId.ResourceGroupName);
            Assert.AreEqual(AzureLocation.WestUS, resourceId.Location);
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", resourceId.SubscriptionId);
            Assert.AreEqual("myResourceGroup", resourceId.Name);

            resourceId = resourceId.Parent;
            Assert.AreEqual("Microsoft.CognitiveServices/locations", resourceId.ResourceType.ToString());
            Assert.IsNull(resourceId.ResourceGroupName);
            Assert.AreEqual(AzureLocation.WestUS, resourceId.Location);
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", resourceId.SubscriptionId);
            Assert.AreEqual("westus", resourceId.Name);

            resourceId = resourceId.Parent;
            Assert.AreEqual("Microsoft.Resources/subscriptions", resourceId.ResourceType.ToString());
            Assert.IsNull(resourceId.ResourceGroupName);
            Assert.IsNull(resourceId.Location);
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", resourceId.SubscriptionId);
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", resourceId.Name);

            resourceId = resourceId.Parent;
            Assert.AreEqual("Microsoft.Resources/tenants", resourceId.ResourceType.ToString());
            Assert.IsNull(resourceId.ResourceGroupName);
            Assert.IsNull(resourceId.Location);
            Assert.IsNull(resourceId.SubscriptionId);
            Assert.AreEqual("", resourceId.Name);

            Assert.IsNull(resourceId.Parent);
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/tagNames/azsecpack", Description = "No provider tagname")]
        public void CanParseValidNoProviderResource(string resourceId)
        {
            ResourceIdentifier subscription = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, subscription.ToString());
        }

        [Test]
        public void TryGetPropertiesForSubscriptionResource()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/providers/Contoso.Widgets/widgets/myWidget");
            Assert.NotNull(id1.SubscriptionId);
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", id1.SubscriptionId);
            Assert.Null(id1.Location);
            Assert.Null(id1.ResourceGroupName);
            ResourceIdentifier expectedId = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101");
            Assert.NotNull(id1.Parent);
            Assert.IsTrue(expectedId.Equals(id1.Parent));
        }

        [Test]
        public void TryGetPropertiesForSubscriptionProvider()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute");
            Assert.NotNull(id1.SubscriptionId);
            Assert.AreEqual("db1ab6f0-4769-4b27-930e-01e2ef9c123c", id1.SubscriptionId);
            Assert.Null(id1.Location);
            Assert.Null(id1.ResourceGroupName);
            ResourceIdentifier expectedId = GetResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c");
            Assert.NotNull(id1.Parent);
            Assert.IsTrue(expectedId.Equals(id1.Parent));
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
            ResourceIdentifier resource = GetResourceIdentifier(resourceId);
            if (providerNamespace is null || resourceTypeName is null || resourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
            else if (string.IsNullOrWhiteSpace(providerNamespace) || string.IsNullOrWhiteSpace(resourceTypeName) || string.IsNullOrWhiteSpace(resourceName))
                Assert.Throws(typeof(ArgumentException), () => resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName));
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
            ResourceIdentifier resource = GetResourceIdentifier(resourceId);
            if (childTypeName is null || childResourceName is null)
                Assert.Throws(typeof(ArgumentNullException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (string.IsNullOrWhiteSpace(childTypeName) || string.IsNullOrWhiteSpace(childResourceName))
                Assert.Throws(typeof(ArgumentException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else if (childTypeName.Contains("/") || childResourceName.Contains("/"))
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => resource.AppendChildResource(childTypeName, childResourceName));
            else
            {
                var expected = $"{resourceId}/{childTypeName}/{childResourceName}";
                Assert.AreEqual(expected, resource.AppendChildResource(childTypeName, childResourceName).ToString());
            }
        }
        #endregion

        #region SubscriptionProviderResourceIdentifier
        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Insights")]
        public void ImplicitConstructorWithProvider(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.AreEqual("Microsoft.Insights", z.Provider);
            Assert.AreEqual("Microsoft.Resources/providers", z.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Resources/subscriptions", z.Parent.ResourceType.ToString());
            Assert.AreEqual("db1ab6f0-4769-4b27-930e-01e2ef9c123c", z.Parent.Name);

            if (resourceProviderID is null)
            {
                Assert.IsNull(z);
                Assert.IsNull(y);
            }
            else
            {
                Assert.AreEqual(resourceProviderID, y);
                Assert.AreEqual(resourceProviderID, y);
            }
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Insights/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/testsubnet")]
        public void ImplicitConstructorWithSubnet(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.AreEqual("Microsoft.Insights", z.Provider);
            Assert.AreEqual("Microsoft.Network/virtualNetworks/subnets", z.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Insights", z.Parent.Provider);
            Assert.AreEqual("Microsoft.Insights", z.Parent.Parent.Provider);
            Assert.AreEqual("Microsoft.Network/virtualNetworks/subnets", z.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Network/virtualNetworks", z.Parent.ResourceType.ToString());
            Assert.AreEqual("testvnet", z.Parent.Name);
            Assert.AreEqual("Microsoft.Resources/providers", z.Parent.Parent.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Resources/subscriptions", z.Parent.Parent.Parent.ResourceType.ToString());
            Assert.AreEqual("db1ab6f0-4769-4b27-930e-01e2ef9c123c", z.Parent.Parent.Parent.Name);

            if (resourceProviderID is null)
            {
                Assert.IsNull(z);
                Assert.IsNull(y);
            }
            else
            {
                Assert.AreEqual(resourceProviderID, y);
                Assert.AreEqual(resourceProviderID, y);
            }
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Insights/providers/Microsoft.Network/virtualNetworks/testvnet")]
        public void ImplicitConstructorWithVNet(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.AreEqual("Microsoft.Insights", z.Provider);
            Assert.AreEqual("Microsoft.Network/virtualNetworks", z.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Insights", z.Parent.Provider);
            Assert.AreEqual("Microsoft.Network/virtualNetworks", z.ResourceType.ToString());
            Assert.AreEqual("testvnet", z.Name);
            Assert.AreEqual("Microsoft.Insights", z.Parent.Provider);
            Assert.AreEqual("Microsoft.Resources/providers", z.Parent.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Insights", z.Parent.Name);
            Assert.AreEqual("Microsoft.Resources/subscriptions", z.Parent.Parent.ResourceType.ToString());
            Assert.AreEqual("db1ab6f0-4769-4b27-930e-01e2ef9c123c", z.Parent.Parent.Name);

            if (resourceProviderID is null)
            {
                Assert.IsNull(z);
                Assert.IsNull(y);
            }
            else
            {
                Assert.AreEqual(resourceProviderID, y);
                Assert.AreEqual(resourceProviderID, y);
            }
        }
        #endregion

        [Test]
        public void ThrowOnMistypedResource()
        {
            ResourceIdentifier tenant;
            Assert.DoesNotThrow(() => tenant = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101"));
            Assert.DoesNotThrow(() => tenant = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2"));
            Assert.DoesNotThrow(() => tenant = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg"));

            ResourceIdentifier subscription = GetResourceIdentifier("/providers/Contoso.Widgets/widgets/myWidget");
            Assert.IsNotNull(subscription);
            Assert.DoesNotThrow(() => subscription = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2"));
            Assert.DoesNotThrow(() => subscription = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg"));
        }

        [Test]
        public void VerifyRootResource()
        {
            var root = ResourceIdentifier.Root;
            Assert.IsNull(root.Parent);
            Assert.AreEqual(root.ResourceType, "Microsoft.Resources/tenants");
            Assert.AreEqual("/", root.ToString());
        }

        [Test]
        public void Sort()
        {
            List<ResourceIdentifier> list = new List<ResourceIdentifier>();
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
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
            ResourceIdentifier asIdentifier = GetResourceIdentifier(id);
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
            Assert.Throws<FormatException>(() => { _ = new ResourceIdentifier(id).Name; });
            Assert.Throws<FormatException>(() => ResourceIdentifier.Parse(id));
            Assert.IsFalse(ResourceIdentifier.TryParse(id, out var result));
        }

        [TestCase(null)]
        public void NullInput(string invalidID)
        {
            Assert.Throws<ArgumentNullException>(() => { _ = new ResourceIdentifier(invalidID).Name; });
            Assert.Throws<ArgumentNullException>(() => ResourceIdentifier.Parse(invalidID));
            Assert.IsFalse(ResourceIdentifier.TryParse(invalidID, out var result));
        }

        [TestCase("")]
        public void EmptyInput(string invalidID)
        {
            Assert.Throws<ArgumentException>(() => { _ = new ResourceIdentifier(invalidID).Name; });
            Assert.Throws<ArgumentException>(() => ResourceIdentifier.Parse(invalidID));
            Assert.IsFalse(ResourceIdentifier.TryParse(invalidID, out var result));
        }

        [TestCase(" ")]
        [TestCase("asdfghj")]
        [TestCase("123456")]
        [TestCase("!@#$%^&*/")]
        [TestCase("/subscriptions/")]
        [TestCase("/0c2f6471-1bf0-4dda-aec3-cb9272f09575/myRg/")]
        public void InvalidInput(string invalidID)
        {
            Assert.Throws<FormatException>(() => { _ = new ResourceIdentifier(invalidID).Name; });
            Assert.Throws<FormatException>(() => ResourceIdentifier.Parse(invalidID));
            Assert.IsFalse(ResourceIdentifier.TryParse(invalidID, out var result));
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

            z = GetResourceIdentifier(x);
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
                Assert.Throws<ArgumentNullException>(() => ResourceIdentifier.Parse(resourceProviderID));
                Assert.IsFalse(ResourceIdentifier.TryParse(resourceProviderID, out var result));
            }
            else
            {
                ResourceIdentifier myResource = GetResourceIdentifier(resourceProviderID);
                Assert.AreEqual(myResource.ToString(), resourceProviderID);
            }
        }

        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleAssignments", "myRa")]
        public void CanParseExtensionResourceIds(string baseId, string extensionNamespace, string extensionType, string extensionName)
        {
            ResourceIdentifier targetResourceId = GetResourceIdentifier(baseId);
            ResourceIdentifier subject = GetResourceIdentifier($"{baseId}/providers/{extensionNamespace}/{extensionType}/{extensionName}");
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
            ResourceIdentifier subject = GetResourceIdentifier(resourceId);
            Assert.AreEqual(expectedResourcetype, subject.ResourceType.ToString());
        }

        [TestCase("UnformattedString", Description = "Too Few Elements")]
        [TestCase("/subs/sub1/rgs/rg1/", Description = "No known parts")]
        [TestCase("/subscriptions/sub1/rgs/rg1/", Description = "Subscription not a Guid")]
        [TestCase("/subscriptions/sub1", Description = "Subscription not a Guid")]
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
            Assert.Throws<FormatException>(() => _ = new ResourceIdentifier(resourceId).Name);
            Assert.Throws<FormatException>(() => ResourceIdentifier.Parse(resourceId));
            Assert.IsFalse(ResourceIdentifier.TryParse(resourceId, out var result));
        }

        protected void ValidateLocationBaseResource(ResourceIdentifier locationResource, string expectedId, bool expectedChild, string expectedResourcetype, string expectedSubGuid)
        {
            Assert.AreEqual(expectedId, locationResource.ToString());
            Assert.AreEqual(expectedChild, locationResource.IsProviderResource);
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
            Assert.AreEqual(false, subscriptionResource.IsProviderResource);
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
            Assert.AreEqual(false, tenantResource.IsProviderResource);
            Assert.IsNull(tenantResource.Location);
            Assert.IsNull(tenantResource.Provider);
            Assert.AreEqual(string.Empty, tenantResource.Name);
            Assert.IsNull(tenantResource.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/tenants", tenantResource.ResourceType.ToString());
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
            ResourceIdentifier a = resourceProviderID1 == null ? null : GetResourceIdentifier(resourceProviderID1);
            ResourceIdentifier b = resourceProviderID2 == null ? null : GetResourceIdentifier(resourceProviderID2);
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
            ResourceIdentifier a = resourceProviderID1 == null ? null : GetResourceIdentifier(resourceProviderID1);
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
            ResourceIdentifier id1 = GetResourceIdentifier(resourceId);
            Assert.AreEqual(subscription is null, id1.SubscriptionId is null);
            if (!(subscription is null))
                Assert.AreEqual(subscription, id1.SubscriptionId);
            Assert.AreEqual(location is null, !id1.Location.HasValue);
            if (!(location is null))
                Assert.AreEqual(location, id1.Location?.Name);
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
            ResourceIdentifier id = GetResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
        }

        [TestCase(TrackedResourceId, TrackedResourceId, 0)]
        [TestCase(TrackedResourceId, ChildResourceId, -1)]
        [TestCase(ChildResourceId, TrackedResourceId, 1)]
        [TestCase(TrackedResourceId, null, 1)]
        public void CompareToResourceProvider(string resourceProviderID1, string resourceProviderID2, int expected)
        {
            ResourceIdentifier a = GetResourceIdentifier(resourceProviderID1);
            ResourceIdentifier b = resourceProviderID2 == null ? null : GetResourceIdentifier(resourceProviderID2);
            if (a != null)
            {
                int actual = a.CompareTo(b);
                Assert.AreEqual(expected < 0, actual < 0);
                Assert.AreEqual(expected > 0, actual > 0);
                Assert.AreEqual(expected == 0, actual == 0);
            }
        }

        [TestCase(TrackedResourceId, TrackedResourceId, 0)]
        [TestCase(TrackedResourceId, ChildResourceId, -1)]
        [TestCase(ChildResourceId, TrackedResourceId, 1)]
        [TestCase(TrackedResourceId, null, 1)]
        public void CompareToString(string resourceProviderID1, string resourceProviderID2, int expected)
        {
            ResourceIdentifier a = GetResourceIdentifier(resourceProviderID1);
            ResourceIdentifier b = resourceProviderID2 == null ? null : GetResourceIdentifier(resourceProviderID2);
            if (a != null)
            {
                int actual = a.CompareTo(b);
                Assert.AreEqual(expected < 0, actual < 0);
                Assert.AreEqual(expected > 0, actual > 0);
                Assert.AreEqual(expected == 0, actual == 0);
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
            ResourceIdentifier a = resourceProviderID1 == null ? null : GetResourceIdentifier(resourceProviderID1);
            if (comparisonType == "object")
            {
                ResourceIdentifier b = resourceProviderID2 == null ? null : GetResourceIdentifier(resourceProviderID2);
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
            ResourceIdentifier a = resourceProviderID1 == null ? null : GetResourceIdentifier(resourceProviderID1);
            if (comparisonType == "object")
            {
                ResourceIdentifier b = resourceProviderID2 == null ? null : GetResourceIdentifier(resourceProviderID2);
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
            ResourceIdentifier id1 = GetResourceIdentifier(string1);
            ResourceIdentifier id2 = GetResourceIdentifier(string2);
            Assert.AreEqual(expected, id1 < id2);
        }

        [TestCase(true, TrackedResourceId, TrackedResourceId)]
        [TestCase(true, TrackedResourceId, ChildResourceId)]
        [TestCase(false, ChildResourceId, TrackedResourceId)]
        public void LessThanOrEqualOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = GetResourceIdentifier(string1);
            ResourceIdentifier id2 = GetResourceIdentifier(string2);
            Assert.AreEqual(expected, id1 <= id2);
        }

        [TestCase(false, TrackedResourceId, TrackedResourceId)]
        [TestCase(false, TrackedResourceId, ChildResourceId)]
        [TestCase(true, ChildResourceId, TrackedResourceId)]
        public void GreaterThanOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = GetResourceIdentifier(string1);
            ResourceIdentifier id2 = GetResourceIdentifier(string2);
            Assert.AreEqual(expected, id1 > id2);
        }

        [TestCase(true, TrackedResourceId, TrackedResourceId)]
        [TestCase(false, TrackedResourceId, ChildResourceId)]
        [TestCase(true, ChildResourceId, TrackedResourceId)]
        public void GreaterThanOrEqualOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = GetResourceIdentifier(string1);
            ResourceIdentifier id2 = GetResourceIdentifier(string2);
            Assert.AreEqual(expected, id1 >= id2);
        }

        [Test]
        public void LessThanNull()
        {
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            Assert.IsTrue(null < id);
            Assert.IsFalse(id < null);
        }

        [Test]
        public void LessThanOrEqualNull()
        {
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            Assert.IsTrue(null <= id);
            Assert.IsFalse(id <= null);
        }

        [Test]
        public void GreaterThanNull()
        {
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            Assert.IsFalse(null > id);
            Assert.IsTrue(id > null);
        }

        [Test]
        public void GreaterThanOrEqualNull()
        {
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            Assert.IsFalse(null >= id);
            Assert.IsTrue(id >= null);
        }
    }
}
