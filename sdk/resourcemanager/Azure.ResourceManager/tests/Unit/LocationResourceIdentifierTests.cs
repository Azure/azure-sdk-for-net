using System;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class LocationResourceIdentifierTests : ResourceIdentifierTests
    {
        private const string LocationResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/locations/MyLocation";
        private const string LocationBaseResourceId = "/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/locations/westus2";
        private const string LocationInDifferentNamespace = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute/locations/westus2";

        [Test]
        public void LocationFromDiffNamespaceWithChildResouce()
        {
            string resourceId = $"{LocationInDifferentNamespace}/publishers/128technology";
            var id = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location.ToString());
            Assert.AreEqual("db1ab6f0-4769-4b27-930e-01e2ef9c123c", id.SubscriptionId);
            Assert.AreEqual("Microsoft.Compute/locations/publishers", id.ResourceType.ToString());
            Assert.AreEqual("128technology", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(true, id.IsChild);
            ValidateLocationBaseResource(id.Parent, LocationInDifferentNamespace, false, "Microsoft.Compute/locations", "db1ab6f0-4769-4b27-930e-01e2ef9c123c");
        }

        [Test]
        public void LocationWithChildResouce()
        {
            string resourceId = $"{LocationBaseResourceId}/myResourceType/myResourceName";
            var id = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/subscriptions/locations/myResourceType", id.ResourceType.ToString());
            Assert.AreEqual("myResourceName", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(true, id.IsChild);
            ValidateLocationBaseResource(id.Parent, LocationBaseResourceId, true, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithChildSingleton()
        {
            string resourceId = $"{LocationBaseResourceId}/myResourceType/myResourceName/mySingletonResource";
            var id = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/subscriptions/locations/myResourceType/mySingletonResource", id.ResourceType.ToString());
            Assert.AreEqual(string.Empty, id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(true, id.IsChild);

            var parentId = id.Parent;
            Assert.AreEqual($"{LocationBaseResourceId}/myResourceType/myResourceName", parentId.ToString());
            Assert.AreEqual("westus2", parentId.Location.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", parentId.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources/subscriptions/locations/myResourceType", parentId.ResourceType.ToString());
            Assert.AreEqual("myResourceName", parentId.Name);
            Assert.IsNull(parentId.Provider);
            Assert.AreEqual(true, parentId.IsChild);

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, true, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithProviderResource()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName";
            var id = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("myProvider/myResourceType", id.ResourceType.ToString());
            Assert.AreEqual("myResourceName", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(false, id.IsChild);

            ValidateLocationBaseResource(id.Parent, LocationBaseResourceId, true, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithProviderResourceWithChild()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName/myChildResource/myChildResourceName";
            var id = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("myProvider/myResourceType/myChildResource", id.ResourceType.ToString());
            Assert.AreEqual("myChildResourceName", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(true, id.IsChild);

            var parentId = id.Parent;
            Assert.AreEqual($"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName", parentId.ToString());
            Assert.AreEqual("westus2", parentId.Location.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", parentId.SubscriptionId);
            Assert.AreEqual("myProvider/myResourceType", parentId.ResourceType.ToString());
            Assert.AreEqual("myResourceName", parentId.Name);
            Assert.IsNull(parentId.Provider);
            Assert.AreEqual(false, parentId.IsChild);

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, true, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void LocationWithExtensionResource()
        {
            string resourceId = $"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName/providers/mySecondNamespace/myChildResource/myChildResourceName";
            var id = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, id.ToString());
            Assert.AreEqual("westus2", id.Location.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", id.SubscriptionId);
            Assert.AreEqual("mySecondNamespace/myChildResource", id.ResourceType.ToString());
            Assert.AreEqual("myChildResourceName", id.Name);
            Assert.IsNull(id.Provider);
            Assert.AreEqual(false, id.IsChild);

            var parentId = id.Parent;
            Assert.AreEqual($"{LocationBaseResourceId}/providers/myProvider/myResourceType/myResourceName", parentId.ToString());
            Assert.AreEqual("westus2", parentId.Location.ToString());
            Assert.AreEqual("17fecd63-33d8-4e43-ac6f-0aafa111b38d", parentId.SubscriptionId);
            Assert.AreEqual("myProvider/myResourceType", parentId.ResourceType.ToString());
            Assert.AreEqual("myResourceName", parentId.Name);
            Assert.IsNull(parentId.Provider);
            Assert.AreEqual(false, parentId.IsChild);

            ValidateLocationBaseResource(parentId.Parent, LocationBaseResourceId, true, "Microsoft.Resources/subscriptions/locations", "17fecd63-33d8-4e43-ac6f-0aafa111b38d");
        }

        [Test]
        public void TryGetPropertiesForLocationResource()
        {
            ResourceIdentifier id1 = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2/providers/Contoso.Widgets/widgets/myWidget");
            Assert.NotNull(id1.SubscriptionId);
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", id1.SubscriptionId);
            Assert.NotNull(id1.Location);
            Assert.AreEqual(Location.WestUS2, id1.Location);
            Assert.Null(id1.ResourceGroupName);
            ResourceIdentifier expectedId = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2");
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

        [TestCase(LocationResourceId, "wheels", "Wheel1")]
        [TestCase(LocationResourceId, null, "wheel2")]
        [TestCase(LocationResourceId, "wheels", null)]
        [TestCase(LocationResourceId, "", "wheel2")]
        [TestCase(LocationResourceId, "wheels", "  ")]
        [TestCase(LocationResourceId, "wheels/spokes", "wheel2")]
        [TestCase(LocationResourceId, "wheels", "wheel1/wheel2")]
        public void TestAppendLocationChildResource(string resourceId, string childTypeName, string childResourceName)
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
