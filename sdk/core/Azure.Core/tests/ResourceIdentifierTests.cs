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
            Assert.That(ResourceIdentifier.TryParse(id, out fromTryParse), Is.True);
            Assert.That(fromParse, Is.EqualTo(fromCtor));
            Assert.That(fromTryParse, Is.EqualTo(fromParse));
            return fromCtor;
        }

        #region LocationResouceIdentifier
        [Test]
        public void LocationFromDiffNamespaceWithChildResource()
        {
            string resourceId = $"{LocationInDifferentNamespace}/publishers/128technology";
            var id = GetResourceIdentifier(resourceId);
            Assert.That(id.ToString(), Is.EqualTo(resourceId));
            Assert.That(id.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(id.SubscriptionId, Is.EqualTo("db1ab6f0-4769-4b27-930e-01e2ef9c123c"));
            Assert.That(id.ResourceType.ToString(), Is.EqualTo("Microsoft.Compute/locations/publishers"));
            Assert.That(id.Name, Is.EqualTo("128technology"));
            Assert.That(id.Provider, Is.Null);
            Assert.That(id.IsProviderResource, Is.EqualTo(false));
            ValidateLocationBaseResource(id.Parent, LocationInDifferentNamespace, true, "Microsoft.Compute/locations", "db1ab6f0-4769-4b27-930e-01e2ef9c123c");
        }

        [Test]
        public void LocationWithChildResource()
        {
            string resourceId = $"{LocationBaseResourceId}/myResourceType/myResourceName";
            var id = GetResourceIdentifier(resourceId);
            Assert.That(id.ToString(), Is.EqualTo(resourceId));
            Assert.That(id.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(id.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(id.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/subscriptions/locations/myResourceType"));
            Assert.That(id.Name, Is.EqualTo("myResourceName"));
            Assert.That(id.Provider, Is.Null);
            Assert.That(id.IsProviderResource, Is.EqualTo(false));
            ValidateLocationBaseResource(id.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithChildSingleton()
        {
            string resourceId = $"{LocationBaseResourceId}/myResourceType/myResourceName/mySingletonResource";
            var id = GetResourceIdentifier(resourceId);
            Assert.That(id.ToString(), Is.EqualTo(resourceId));
            Assert.That(id.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(id.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(id.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/subscriptions/locations/myResourceType/mySingletonResource"));
            Assert.That(id.Name, Is.Empty);
            Assert.That(id.Provider, Is.Null);
            Assert.That(id.IsProviderResource, Is.EqualTo(false));

            var parentId = id.Parent;
            Assert.That(parentId.ToString(), Is.EqualTo($"{LocationBaseResourceId}/myResourceType/myResourceName"));
            Assert.That(parentId.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(parentId.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(parentId.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/subscriptions/locations/myResourceType"));
            Assert.That(parentId.Name, Is.EqualTo("myResourceName"));
            Assert.That(parentId.Provider, Is.Null);
            Assert.That(parentId.IsProviderResource, Is.EqualTo(false));

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithProviderResource()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName";
            var id = GetResourceIdentifier(resourceId);
            Assert.That(id.ToString(), Is.EqualTo(resourceId));
            Assert.That(id.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(id.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(id.ResourceType.ToString(), Is.EqualTo("myProvider/myResourceType"));
            Assert.That(id.Name, Is.EqualTo("myResourceName"));
            Assert.That(id.Provider, Is.Null);
            Assert.That(id.IsProviderResource, Is.EqualTo(true));

            ValidateLocationBaseResource(id.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithProviderResourceWithChild()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName/myChildResource/myChildResourceName";
            var id = GetResourceIdentifier(resourceId);
            Assert.That(id.ToString(), Is.EqualTo(resourceId));
            Assert.That(id.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(id.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(id.ResourceType.ToString(), Is.EqualTo("myProvider/myResourceType/myChildResource"));
            Assert.That(id.Name, Is.EqualTo("myChildResourceName"));
            Assert.That(id.Provider, Is.Null);
            Assert.That(id.IsProviderResource, Is.EqualTo(false));

            var parentId = id.Parent;
            Assert.That(parentId.ToString(), Is.EqualTo($"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName"));
            Assert.That(parentId.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(parentId.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(parentId.ResourceType.ToString(), Is.EqualTo("myProvider/myResourceType"));
            Assert.That(parentId.Name, Is.EqualTo("myResourceName"));
            Assert.That(parentId.Provider, Is.Null);
            Assert.That(parentId.IsProviderResource, Is.EqualTo(true));

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithExtensionResource()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName/providers/mySecondNamespace/myChildResource/myChildResourceName";
            var id = GetResourceIdentifier(resourceId);
            Assert.That(id.ToString(), Is.EqualTo(resourceId));
            Assert.That(id.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(id.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(id.ResourceType.ToString(), Is.EqualTo("mySecondNamespace/myChildResource"));
            Assert.That(id.Name, Is.EqualTo("myChildResourceName"));
            Assert.That(id.Provider, Is.Null);
            Assert.That(id.IsProviderResource, Is.EqualTo(true));

            var parentId = id.Parent;
            Assert.That(parentId.ToString(), Is.EqualTo($"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName"));
            Assert.That(parentId.Location?.ToString(), Is.EqualTo("westus2"));
            Assert.That(parentId.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(parentId.ResourceType.ToString(), Is.EqualTo("myProvider/myResourceType"));
            Assert.That(parentId.Name, Is.EqualTo("myResourceName"));
            Assert.That(parentId.Provider, Is.Null);
            Assert.That(parentId.IsProviderResource, Is.EqualTo(true));

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, false, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void TryGetPropertiesForLocationResource()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2/providers/Contoso.Widgets/widgets/myWidget");
            Assert.That(id1.SubscriptionId, Is.Not.Null);
            Assert.That(id1.SubscriptionId, Is.EqualTo("6b085460-5f21-477e-ba44-1035046e9101"));
            Assert.That(id1.Location.HasValue, Is.True);
            Assert.That(id1.Location, Is.EqualTo(AzureLocation.WestUS2));
            Assert.That(id1.ResourceGroupName, Is.Null);
            ResourceIdentifier expectedId = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2");
            Assert.That(id1.Parent, Is.Not.Null);
            Assert.That(expectedId, Is.EqualTo(id1.Parent));
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
                Assert.That(resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName).ToString(), Is.EqualTo(expected));
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
                Assert.That(resource.AppendChildResource(childTypeName, childResourceName).ToString(), Is.EqualTo(expected));
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
            Assert.That(subject.ToString(), Is.EqualTo(resourceId));
            Assert.That(subject.SubscriptionId, Is.EqualTo(subscription));
            Assert.That(Uri.UnescapeDataString(subject.ResourceGroupName), Is.EqualTo(resourceGroup));
            Assert.That(subject.ResourceType.Namespace, Is.EqualTo(provider));
            Assert.That(subject.ResourceType.Type, Is.EqualTo(type));
            Assert.That(Uri.UnescapeDataString(subject.Name), Is.EqualTo(name));
        }

        [TestCase("0c2f6471-1bf0-4dda-aec3-cb9272f09575", "myRg", "Microsoft.Web", "appServices/myApp/config", "appServices/config")]
        public void CanParseProxyResource(string subscription, string rg, string resourceNamespace, string resource, string type)
        {
            string id = $"/subscriptions/{subscription}/resourceGroups/{rg}/providers/{resourceNamespace}/{resource}";
            ResourceIdentifier subject = GetResourceIdentifier(id);
            Assert.That(subject.ToString(), Is.EqualTo(id));
            Assert.That(subject.SubscriptionId, Is.EqualTo(subscription));
            Assert.That(subject.ResourceType.Namespace, Is.EqualTo(resourceNamespace));
            Assert.That(subject.ResourceType.Type, Is.EqualTo(type));
        }

        [Test]
        public void CanParseResourceGroups()
        {
            ResourceIdentifier subject = GetResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg");
            Assert.That(subject.ToString(), Is.EqualTo("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg"));
            Assert.That(subject.SubscriptionId, Is.EqualTo("0c2f6471-1bf0-4dda-aec3-cb9272f09575"));
            Assert.That(subject.ResourceGroupName, Is.EqualTo("myRg"));
            Assert.That(subject.ResourceType.Namespace, Is.EqualTo("Microsoft.Resources"));
            Assert.That(subject.ResourceType.Type, Is.EqualTo("resourceGroups"));
        }

        [TestCase("MyVnet", "MySubnet")]
        [TestCase("!@#$%^&*()-_+=;:'\",<.>/?", "MySubnet")]
        [TestCase("MyVnet", "!@#$%^&*()-_+=;:'\",<.>/?")]
        public void CanParseChildResources(string parentName, string name)
        {
            var resourceId = $"/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/{Uri.EscapeDataString(parentName)}/subnets/{Uri.EscapeDataString(name)}";
            ResourceIdentifier subject = GetResourceIdentifier(resourceId);
            Assert.That(subject.ToString(), Is.EqualTo(resourceId));
            Assert.That(subject.SubscriptionId, Is.EqualTo("0c2f6471-1bf0-4dda-aec3-cb9272f09575"));
            Assert.That(Uri.UnescapeDataString(subject.ResourceGroupName), Is.EqualTo("myRg"));
            Assert.That(subject.ResourceType.Namespace, Is.EqualTo("Microsoft.Network"));
            Assert.That(subject.Parent.ResourceType.Type, Is.EqualTo("virtualNetworks"));
            Assert.That(subject.ResourceType.Type, Is.EqualTo("virtualNetworks/subnets"));
            Assert.That(Uri.UnescapeDataString(subject.Name), Is.EqualTo(name));

            // check parent type parsing
            ResourceIdentifier parentResource = GetResourceIdentifier($"/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Network/virtualNetworks/{Uri.EscapeDataString(parentName)}");
            Assert.That(subject.Parent, Is.EqualTo(parentResource));
            Assert.That(subject.Parent.ToString(), Is.EqualTo(parentResource.ToString()));
            Assert.That(((ResourceIdentifier)subject.Parent).SubscriptionId, Is.EqualTo("0c2f6471-1bf0-4dda-aec3-cb9272f09575"));
            Assert.That(Uri.UnescapeDataString(((ResourceIdentifier)subject.Parent).ResourceGroupName), Is.EqualTo("myRg"));
            Assert.That(subject.Parent.ResourceType.Namespace, Is.EqualTo("Microsoft.Network"));
            Assert.That(subject.Parent.ResourceType.Type, Is.EqualTo("virtualNetworks"));
            Assert.That(Uri.UnescapeDataString(subject.Parent.Name), Is.EqualTo(parentName));
        }

        [TestCase(true, "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport", "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport")]
        [TestCase(false, "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport2", "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport")]
        [TestCase(false, "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport", "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test")]
        public void CheckHashCode(bool expected, string resourceId1, string resourceId2)
        {
            ResourceIdentifier resourceIdentifier1 = GetResourceIdentifier(resourceId1);
            ResourceIdentifier resourceIdentifier2 = GetResourceIdentifier(resourceId2);
            Assert.That(resourceIdentifier1.GetHashCode() == resourceIdentifier2.GetHashCode(), Is.EqualTo(expected));
        }

        [Test]
        public void EqualsObj()
        {
            object input = TrackedResourceId;
            ResourceIdentifier resource = GetResourceIdentifier(TrackedResourceId);
            Assert.That(resource.Equals(input), Is.EqualTo(true));
            Assert.That(resource.Equals(new object()), Is.False);
        }

        [Test]
        public void TryGetPropertiesForResourceGroupResource()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg/providers/Contoso.Widgets/widgets/myWidget");
            Assert.That(id1.SubscriptionId, Is.Not.Null);
            Assert.That(id1.SubscriptionId, Is.EqualTo("6b085460-5f21-477e-ba44-1035046e9101"));
            Assert.That(id1.Location.HasValue, Is.False);
            Assert.That(id1.ResourceGroupName, Is.Not.Null);
            Assert.That(id1.ResourceGroupName, Is.EqualTo("myRg"));
            ResourceIdentifier expectedId = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg");
            Assert.That(id1.Parent, Is.Not.Null);
            Assert.That(expectedId, Is.EqualTo(id1.Parent));
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
                Assert.That(resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName).ToString(), Is.EqualTo(expected));
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
                Assert.That(resource.AppendChildResource(childTypeName, childResourceName).ToString(), Is.EqualTo(expected));
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
            Assert.That(tenant.ToString(), Is.EqualTo(resourceId));
        }

        [Test]
        public void TryGetPropertiesForTenantResource()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/providers/Contoso.Widgets/widgets/myWidget");
            Assert.That(id1.SubscriptionId, Is.Null);
            Assert.That(id1.Location, Is.Null);
            Assert.That(id1.ResourceGroupName, Is.Null);
            Assert.That(id1.Parent, Is.Not.Null);
            ResourceIdentifier id2 = GetResourceIdentifier("/providers/Contoso.Widgets/widgets/myWidget/flages/myFlange");
            Assert.That(id2.Parent, Is.Not.Null);
            Assert.That(id1.Equals(id2.Parent), Is.EqualTo(true));
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
                Assert.That(resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName).ToString(), Is.EqualTo(expected));
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
                Assert.That(resource.AppendChildResource(childTypeName, childResourceName).ToString(), Is.EqualTo(expected));
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

            Assert.That(z.Parent, Is.Not.Null);
            Assert.That(z.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/providers"));
            Assert.That(z.Parent.Name, Is.Empty);

            if (resourceProviderID is null)
            {
                Assert.That(z, Is.Null);
                Assert.That(y, Is.Null);
            }
            else
            {
                Assert.That(y, Is.EqualTo(resourceProviderID));
                Assert.That(y, Is.EqualTo(resourceProviderID));
            }
        }

        [TestCase("/providers/Microsoft.Insights/providers/Microsoft.Compute/virtualMachines/myVmName")]
        public void ImplicitConstructorVirtualMachine(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.That(z.Name, Is.EqualTo("myVmName"));
            Assert.That(z.ResourceType.ToString(), Is.EqualTo("Microsoft.Compute/virtualMachines"));
            Assert.That(z.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/providers"));

            if (resourceProviderID is null)
            {
                Assert.That(z, Is.Null);
                Assert.That(y, Is.Null);
            }
            else
            {
                Assert.That(y, Is.EqualTo(resourceProviderID));
                Assert.That(y, Is.EqualTo(resourceProviderID));
            }
        }

        [TestCase("/providers/Microsoft.Insights/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/testsubnet")]
        public void ImplicitConstructorSubnet(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.That(z.Name, Is.EqualTo("testsubnet"));
            Assert.That(z.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/virtualNetworks/subnets"));
            Assert.That(z.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.Parent.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.Name, Is.EqualTo("testvnet"));
            Assert.That(z.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/virtualNetworks"));
            Assert.That(z.Parent.Parent.Name, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/providers"));

            if (resourceProviderID is null)
            {
                Assert.That(z, Is.Null);
                Assert.That(y, Is.Null);
            }
            else
            {
                Assert.That(y, Is.EqualTo(resourceProviderID));
                Assert.That(y, Is.EqualTo(resourceProviderID));
            }
        }
        #endregion

        #region SubscriptionResourceIdentifier
        [Test]
        public void CanParseSubscriptions()
        {
            ResourceIdentifier subject = GetResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");
            Assert.That(subject.ToString(), Is.EqualTo("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575"));
            Assert.That(subject.SubscriptionId, Is.EqualTo("0c2f6471-1bf0-4dda-aec3-cb9272f09575"));
            Assert.That(subject.ResourceType.Namespace, Is.EqualTo("Microsoft.Resources"));
            Assert.That(subject.ResourceType.Type, Is.EqualTo("subscriptions"));
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/configuration", Description = "singleton homed in a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/providers/Contoso.Extensions/extensions/myExtension", Description = "Extension over a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/flanges/myFlange", Description = "Child of a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Microsoft.CognitiveServices/locations/westus/resourceGroups/myResourceGroup/deletedAccounts/myDeletedAccount", Description = "Location before ResourceGroup")]
        public void CanParseValidSubscriptionResource(string resourceId)
        {
            ResourceIdentifier subscription = GetResourceIdentifier(resourceId);
            Assert.That(subscription.ToString(), Is.EqualTo(resourceId));
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Microsoft.CognitiveServices/locations/westus/resourceGroups/myResourceGroup/deletedAccounts/myDeletedAccount", "Microsoft.CognitiveServices/locations/resourceGroups/deletedAccounts")]
        public void CanCalculateResourceType(string id, string resourceType)
        {
            ResourceIdentifier resourceId = GetResourceIdentifier(id);
            Assert.That(resourceId.ResourceType.ToString(), Is.EqualTo(resourceType));
            Assert.That(resourceId.ResourceGroupName, Is.EqualTo("myResourceGroup"));
            Assert.That(resourceId.Location, Is.EqualTo(AzureLocation.WestUS));
            Assert.That(resourceId.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(resourceId.Name, Is.EqualTo("myDeletedAccount"));

            resourceId = resourceId.Parent;
            Assert.That(resourceId.ResourceType.ToString(), Is.EqualTo("Microsoft.CognitiveServices/locations/resourceGroups"));
            Assert.That(resourceId.ResourceGroupName, Is.EqualTo("myResourceGroup"));
            Assert.That(resourceId.Location, Is.EqualTo(AzureLocation.WestUS));
            Assert.That(resourceId.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(resourceId.Name, Is.EqualTo("myResourceGroup"));

            resourceId = resourceId.Parent;
            Assert.That(resourceId.ResourceType.ToString(), Is.EqualTo("Microsoft.CognitiveServices/locations"));
            Assert.That(resourceId.ResourceGroupName, Is.Null);
            Assert.That(resourceId.Location, Is.EqualTo(AzureLocation.WestUS));
            Assert.That(resourceId.SubscriptionId, Is.EqualTo("17fecd63-33d8-4e43-ac6f-0aafa111b38d"));
            Assert.That(resourceId.Name, Is.EqualTo("westus"));

            resourceId = resourceId.Parent;
            Assert.That(resourceId.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/subscriptions"));
            Assert.That(resourceId.ResourceGroupName, Is.Null);
            Assert.That(resourceId.Location, Is.Null);
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", resourceId.SubscriptionId);
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", resourceId.Name);

            resourceId = resourceId.Parent;
            Assert.AreEqual("Microsoft.Resources/tenants", resourceId.ResourceType.ToString());
            Assert.That(resourceId.ResourceGroupName, Is.Null);
            Assert.That(resourceId.Location, Is.Null);
            Assert.That(resourceId.SubscriptionId, Is.Null);
            Assert.That(resourceId.Name, Is.Empty);

            Assert.That(resourceId.Parent, Is.Null);
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/tagNames/azsecpack", Description = "No provider tagname")]
        public void CanParseValidNoProviderResource(string resourceId)
        {
            ResourceIdentifier subscription = GetResourceIdentifier(resourceId);
            Assert.That(subscription.ToString(), Is.EqualTo(resourceId));
        }

        [Test]
        public void TryGetPropertiesForSubscriptionResource()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/providers/Contoso.Widgets/widgets/myWidget");
            Assert.That(id1.SubscriptionId, Is.Not.Null);
            Assert.That(id1.SubscriptionId, Is.EqualTo("6b085460-5f21-477e-ba44-1035046e9101"));
            Assert.That(id1.Location, Is.Null);
            Assert.That(id1.ResourceGroupName, Is.Null);
            ResourceIdentifier expectedId = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101");
            Assert.That(id1.Parent, Is.Not.Null);
            Assert.That(expectedId, Is.EqualTo(id1.Parent));
        }

        [Test]
        public void TryGetPropertiesForSubscriptionProvider()
        {
            ResourceIdentifier id1 = GetResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute");
            Assert.That(id1.SubscriptionId, Is.Not.Null);
            Assert.That(id1.SubscriptionId, Is.EqualTo("db1ab6f0-4769-4b27-930e-01e2ef9c123c"));
            Assert.That(id1.Location, Is.Null);
            Assert.That(id1.ResourceGroupName, Is.Null);
            ResourceIdentifier expectedId = GetResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c");
            Assert.That(id1.Parent, Is.Not.Null);
            Assert.That(expectedId, Is.EqualTo(id1.Parent));
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
                Assert.That(resource.AppendProviderResource(providerNamespace, resourceTypeName, resourceName).ToString(), Is.EqualTo(expected));
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
                Assert.That(resource.AppendChildResource(childTypeName, childResourceName).ToString(), Is.EqualTo(expected));
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

            Assert.That(z.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/providers"));
            Assert.That(z.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/subscriptions"));
            Assert.That(z.Parent.Name, Is.EqualTo("db1ab6f0-4769-4b27-930e-01e2ef9c123c"));

            if (resourceProviderID is null)
            {
                Assert.That(z, Is.Null);
                Assert.That(y, Is.Null);
            }
            else
            {
                Assert.That(y, Is.EqualTo(resourceProviderID));
                Assert.That(y, Is.EqualTo(resourceProviderID));
            }
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Insights/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/testsubnet")]
        public void ImplicitConstructorWithSubnet(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.That(z.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/virtualNetworks/subnets"));
            Assert.That(z.Parent.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.Parent.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/virtualNetworks/subnets"));
            Assert.That(z.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/virtualNetworks"));
            Assert.That(z.Parent.Name, Is.EqualTo("testvnet"));
            Assert.That(z.Parent.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/providers"));
            Assert.That(z.Parent.Parent.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/subscriptions"));
            Assert.That(z.Parent.Parent.Parent.Name, Is.EqualTo("db1ab6f0-4769-4b27-930e-01e2ef9c123c"));

            if (resourceProviderID is null)
            {
                Assert.That(z, Is.Null);
                Assert.That(y, Is.Null);
            }
            else
            {
                Assert.That(y, Is.EqualTo(resourceProviderID));
                Assert.That(y, Is.EqualTo(resourceProviderID));
            }
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Insights/providers/Microsoft.Network/virtualNetworks/testvnet")]
        public void ImplicitConstructorWithVNet(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = GetResourceIdentifier(x);
            y = z;

            Assert.That(z.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/virtualNetworks"));
            Assert.That(z.Parent.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.ResourceType.ToString(), Is.EqualTo("Microsoft.Network/virtualNetworks"));
            Assert.That(z.Name, Is.EqualTo("testvnet"));
            Assert.That(z.Parent.Provider, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/providers"));
            Assert.That(z.Parent.Name, Is.EqualTo("Microsoft.Insights"));
            Assert.That(z.Parent.Parent.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/subscriptions"));
            Assert.That(z.Parent.Parent.Name, Is.EqualTo("db1ab6f0-4769-4b27-930e-01e2ef9c123c"));

            if (resourceProviderID is null)
            {
                Assert.That(z, Is.Null);
                Assert.That(y, Is.Null);
            }
            else
            {
                Assert.That(y, Is.EqualTo(resourceProviderID));
                Assert.That(y, Is.EqualTo(resourceProviderID));
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
            Assert.That(subscription, Is.Not.Null);
            Assert.DoesNotThrow(() => subscription = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2"));
            Assert.DoesNotThrow(() => subscription = GetResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg"));
        }

        [Test]
        public void VerifyRootResource()
        {
            var root = ResourceIdentifier.Root;
            Assert.That(root.Parent, Is.Null);
            Assert.That(root.ResourceType, Is.EqualTo("Microsoft.Resources/tenants"));
            Assert.That(root.ToString(), Is.EqualTo("/"));
        }

        [Test]
        public void Sort()
        {
            List<ResourceIdentifier> list = new List<ResourceIdentifier>();
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            ResourceIdentifier childId = id.AppendChildResource("myChild", "myChildName");
            list.Add(childId);
            list.Add(id);
            Assert.That(list[0].Name, Is.EqualTo(childId.Name));
            list.Sort();
            Assert.That(list[0].Name, Is.EqualTo(id.Name));
        }

        [TestCase(TenantResourceId)]
        public void CanParseTenant(string id)
        {
            ResourceIdentifier asIdentifier = GetResourceIdentifier(id);
            Assert.That(asIdentifier.ResourceType.Namespace, Is.EqualTo("Microsoft.Billing"));
            Assert.That(asIdentifier.ResourceType.Type, Is.EqualTo("billingAccounts"));
            Assert.That(asIdentifier.Name, Is.EqualTo("3984c6f4-2d2a-4b04-93ce-43cf4824b698%3Ae2f1492a-a492-468d-909f-bf7fe6662c01_2019-05-31"));
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
            Assert.That(ResourceIdentifier.TryParse(id, out var result), Is.False);
        }

        [TestCase(null)]
        public void NullInput(string invalidID)
        {
            Assert.Throws<ArgumentNullException>(() => { _ = new ResourceIdentifier(invalidID).Name; });
            Assert.Throws<ArgumentNullException>(() => ResourceIdentifier.Parse(invalidID));
            Assert.That(ResourceIdentifier.TryParse(invalidID, out var result), Is.False);
        }

        [TestCase("")]
        public void EmptyInput(string invalidID)
        {
            Assert.Throws<ArgumentException>(() => { _ = new ResourceIdentifier(invalidID).Name; });
            Assert.Throws<ArgumentException>(() => ResourceIdentifier.Parse(invalidID));
            Assert.That(ResourceIdentifier.TryParse(invalidID, out var result), Is.False);
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
            Assert.That(ResourceIdentifier.TryParse(invalidID, out var result), Is.False);
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
                Assert.That(z, Is.Null);
                Assert.That(y, Is.Null);
            }
            else
            {
                Assert.That(y, Is.EqualTo(resourceProviderID));
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
                Assert.That(ResourceIdentifier.TryParse(resourceProviderID, out var result), Is.False);
            }
            else
            {
                ResourceIdentifier myResource = GetResourceIdentifier(resourceProviderID);
                Assert.That(resourceProviderID, Is.EqualTo(myResource.ToString()));
            }
        }

        [TestCase(LocationResourceId, "Microsoft.Authorization", "roleAssignments", "myRa")]
        public void CanParseExtensionResourceIds(string baseId, string extensionNamespace, string extensionType, string extensionName)
        {
            ResourceIdentifier targetResourceId = GetResourceIdentifier(baseId);
            ResourceIdentifier subject = GetResourceIdentifier($"{baseId}/providers/{extensionNamespace}/{extensionType}/{extensionName}");
            ResourceType expectedType = $"{extensionNamespace}/{extensionType}";
            Assert.That(subject.ResourceType, Is.Not.EqualTo(targetResourceId.ResourceType));
            Assert.That(subject.ResourceType, Is.EqualTo(expectedType));
            Assert.That(subject.Parent, Is.Not.Null);
            Assert.That(subject.Parent, Is.EqualTo(targetResourceId));
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/providers/Microsoft.ApiManagement/service/myservicename/subscriptions/mysubscription", "Microsoft.ApiManagement/service/subscriptions",
            Description = "From ApiManagement")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/resourceGroups/myRg/providers/Microsoft.ServiceBus/namespaces/mynamespace/topics/mytopic/subscriptions/mysubscription", "Microsoft.ServiceBus/namespaces/topics/subscriptions",
            Description = "From ServiceBus")]
        public void CanParseResourceIdsWithSubscriptionsOfOtherResourceTypes(string resourceId, string expectedResourcetype)
        {
            ResourceIdentifier subject = GetResourceIdentifier(resourceId);
            Assert.That(subject.ResourceType.ToString(), Is.EqualTo(expectedResourcetype));
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
            Assert.That(ResourceIdentifier.TryParse(resourceId, out var result), Is.False);
        }

        protected void ValidateLocationBaseResource(ResourceIdentifier locationResource, string expectedId, bool expectedChild, string expectedResourcetype, string expectedSubGuid)
        {
            Assert.That(locationResource.ToString(), Is.EqualTo(expectedId));
            Assert.That(locationResource.IsProviderResource, Is.EqualTo(expectedChild));
            Assert.That(locationResource.Location.ToString(), Is.EqualTo("westus2"));
            Assert.That(locationResource.Name, Is.EqualTo("westus2"));
            Assert.That(locationResource.Provider, Is.Null);
            Assert.That(locationResource.ResourceType.ToString(), Is.EqualTo(expectedResourcetype));
            Assert.That(locationResource.SubscriptionId, Is.EqualTo(expectedSubGuid));
            ValidateSubscriptionResource(locationResource.Parent, locationResource.SubscriptionId);
        }

        protected void ValidateSubscriptionResource(ResourceIdentifier subscriptionResource, string subscriptionId)
        {
            Assert.That(subscriptionResource.ToString(), Is.EqualTo($"/subscriptions/{subscriptionId}"));
            Assert.That(subscriptionResource.IsProviderResource, Is.EqualTo(false));
            Assert.That(subscriptionResource.Location, Is.Null);
            Assert.That(subscriptionResource.Provider, Is.Null);
            Assert.That(subscriptionResource.Name, Is.EqualTo(subscriptionId));
            Assert.That(subscriptionResource.SubscriptionId, Is.EqualTo(subscriptionId));
            Assert.That(subscriptionResource.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/subscriptions"));
            ValidateTenantResource(subscriptionResource.Parent);
        }

        protected void ValidateTenantResource(ResourceIdentifier tenantResource)
        {
            Assert.That(tenantResource.ToString(), Is.EqualTo("/"));
            Assert.That(tenantResource.IsProviderResource, Is.EqualTo(false));
            Assert.That(tenantResource.Location, Is.Null);
            Assert.That(tenantResource.Provider, Is.Null);
            Assert.That(tenantResource.Name, Is.Empty);
            Assert.That(tenantResource.SubscriptionId, Is.Null);
            Assert.That(tenantResource.ResourceType.ToString(), Is.EqualTo("Microsoft.Resources/tenants"));
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
                Assert.That(a.Equals(b), Is.EqualTo(expected));

            Assert.That(ResourceIdentifier.Equals(a, b), Is.EqualTo(expected));
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
                Assert.That(a.Equals(resourceProviderID2), Is.EqualTo(expected));

            Assert.That(ResourceIdentifier.Equals(a, resourceProviderID2), Is.EqualTo(expected));
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
            Assert.That(id1.SubscriptionId is null, Is.EqualTo(subscription is null));
            if (!(subscription is null))
                Assert.That(id1.SubscriptionId, Is.EqualTo(subscription));
            Assert.That(!id1.Location.HasValue, Is.EqualTo(location is null));
            if (!(location is null))
                Assert.That(id1.Location?.Name, Is.EqualTo(location));
            Assert.That(id1.ResourceGroupName is null, Is.EqualTo(resourceGroup is null));
            if (!(resourceGroup is null))
                Assert.That(id1.ResourceGroupName, Is.EqualTo(resourceGroup));
            Assert.That(id1.Parent is null, Is.EqualTo(parent is null));
            if (!(parent is null))
                Assert.That(id1.Parent.ToString(), Is.EqualTo(parent));
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
            Assert.That(id.ToString(), Is.EqualTo(resourceId));
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
                Assert.That(actual < 0, Is.EqualTo(expected < 0));
                Assert.That(actual > 0, Is.EqualTo(expected > 0));
                Assert.That(actual == 0, Is.EqualTo(expected == 0));
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
                Assert.That(actual < 0, Is.EqualTo(expected < 0));
                Assert.That(actual > 0, Is.EqualTo(expected > 0));
                Assert.That(actual == 0, Is.EqualTo(expected == 0));
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
                Assert.That(a == b, Is.EqualTo(expected));
            }
            else
            {
                Assert.That(a == resourceProviderID2, Is.EqualTo(expected));
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
                Assert.That(a != b, Is.EqualTo(expected));
            }
            else
            {
                Assert.That(a != resourceProviderID2, Is.EqualTo(expected));
            }
        }

        [TestCase(false, TrackedResourceId, TrackedResourceId)]
        [TestCase(true, TrackedResourceId, ChildResourceId)]
        [TestCase(false, ChildResourceId, TrackedResourceId)]
        public void LessThanOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = GetResourceIdentifier(string1);
            ResourceIdentifier id2 = GetResourceIdentifier(string2);
            Assert.That(id1 < id2, Is.EqualTo(expected));
        }

        [TestCase(true, TrackedResourceId, TrackedResourceId)]
        [TestCase(true, TrackedResourceId, ChildResourceId)]
        [TestCase(false, ChildResourceId, TrackedResourceId)]
        public void LessThanOrEqualOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = GetResourceIdentifier(string1);
            ResourceIdentifier id2 = GetResourceIdentifier(string2);
            Assert.That(id1 <= id2, Is.EqualTo(expected));
        }

        [TestCase(false, TrackedResourceId, TrackedResourceId)]
        [TestCase(false, TrackedResourceId, ChildResourceId)]
        [TestCase(true, ChildResourceId, TrackedResourceId)]
        public void GreaterThanOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = GetResourceIdentifier(string1);
            ResourceIdentifier id2 = GetResourceIdentifier(string2);
            Assert.That(id1 > id2, Is.EqualTo(expected));
        }

        [TestCase(true, TrackedResourceId, TrackedResourceId)]
        [TestCase(false, TrackedResourceId, ChildResourceId)]
        [TestCase(true, ChildResourceId, TrackedResourceId)]
        public void GreaterThanOrEqualOperator(bool expected, string string1, string string2)
        {
            ResourceIdentifier id1 = GetResourceIdentifier(string1);
            ResourceIdentifier id2 = GetResourceIdentifier(string2);
            Assert.That(id1 >= id2, Is.EqualTo(expected));
        }

        [Test]
        public void LessThanNull()
        {
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            Assert.That(null < id, Is.True);
            Assert.That(id < null, Is.False);
        }

        [Test]
        public void LessThanOrEqualNull()
        {
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            Assert.That(null <= id, Is.True);
            Assert.That(id <= null, Is.False);
        }

        [Test]
        public void GreaterThanNull()
        {
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            Assert.That(null > id, Is.False);
            Assert.That(id > null, Is.True);
        }

        [Test]
        public void GreaterThanOrEqualNull()
        {
            ResourceIdentifier id = GetResourceIdentifier(TrackedResourceId);
            Assert.That(null >= id, Is.False);
            Assert.That(id >= null, Is.True);
        }
    }
}
