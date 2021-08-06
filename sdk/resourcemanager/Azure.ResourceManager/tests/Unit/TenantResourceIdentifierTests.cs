using System;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class TenantResourceIdentifierTests : ResourceIdentifierTests
    {
        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/configuration", Description = "singleton homed in a tenant resource")]
        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/providers/Contoso.Extensions/extensions/myExtension", Description = "Extension over a subscription resource")]
        [TestCase("/providers/Contoso.Widgets/widgets/myWidget/flanges/myFlange", Description = "Child of a subscription resource")]
        public void CanParseValidTenantResource(string resourceId)
        {
            ResourceIdentifier tenant = resourceId;
            Assert.AreEqual(resourceId, tenant.ToString());
        }

        [Test]
        public void TryGetPropertiesForTenantResource()
        {
            ResourceIdentifier id1 = "/providers/Contoso.Widgets/widgets/myWidget";
            Assert.AreEqual(false, id1.TryGetSubscriptionId(out _));
            Assert.AreEqual(false, id1.TryGetLocation(out _));
            Assert.AreEqual(false, id1.TryGetResourceGroupName(out _));
            Assert.AreEqual(true, id1.TryGetParent(out _));
            ResourceIdentifier id2 = "/providers/Contoso.Widgets/widgets/myWidget/flages/myFlange";
            ResourceIdentifier parent;
            Assert.AreEqual(true, id2.TryGetParent(out parent));
            Assert.AreEqual(true, id1.Equals(parent));
        }

        [Test]
        public void ThrowOnMistypedResource()
        {
            ResourceIdentifier tenant;
            Assert.DoesNotThrow(() => tenant = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101"));
            Assert.DoesNotThrow(() => tenant = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2"));
            Assert.DoesNotThrow(() => tenant = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg"));
            Assert.DoesNotThrow(() => tenant = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101");
            Assert.DoesNotThrow(() => tenant = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2");
            Assert.DoesNotThrow(() => tenant = "/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg");
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
            ResourceIdentifier resource = resourceId;
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
            ResourceIdentifier resource = resourceId;
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
