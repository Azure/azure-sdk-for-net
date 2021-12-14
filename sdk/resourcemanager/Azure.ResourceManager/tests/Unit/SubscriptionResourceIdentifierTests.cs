using System;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class SubscriptionResourceIdentifierTests : ResourceIdentifierTests
    {
        const string SubscriptionResourceId = "/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575";

        [Test]
        public void CanParseSubscriptions()
        {
            ResourceIdentifier subject = new ResourceIdentifier("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575");
            Assert.AreEqual("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.ToString());
            Assert.AreEqual("0c2f6471-1bf0-4dda-aec3-cb9272f09575", subject.SubscriptionId);
            Assert.AreEqual("Microsoft.Resources", subject.ResourceType.Namespace);
            Assert.AreEqual("subscriptions", subject.ResourceType.Type);
        }

        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/configuration", Description = "singleton homed in a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/providers/Contoso.Extensions/extensions/myExtension", Description = "Extension over a subscription resource")]
        [TestCase("/subscriptions/17fecd63-33d8-4e43-ac6f-0aafa111b38d/providers/Contoso.Widgets/widgets/myWidget/flanges/myFlange", Description = "Child of a subscription resource")]
        public void CanParseValidSubscriptionResource(string resourceId)
        {
            ResourceIdentifier subscription = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, subscription.ToString());
        }

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/tagNames/azsecpack", Description = "No provider tagname")]
        public void CanParseValidNoProviderResource(string resourceId)
        {
            ResourceIdentifier subscription = new ResourceIdentifier(resourceId);
            Assert.AreEqual(resourceId, subscription.ToString());
        }

        [Test]
        public void TryGetPropertiesForSubscriptionResource()
        {
            ResourceIdentifier id1 = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/providers/Contoso.Widgets/widgets/myWidget");
            Assert.NotNull(id1.SubscriptionId);
            Assert.AreEqual("6b085460-5f21-477e-ba44-1035046e9101", id1.SubscriptionId);
            Assert.Null(id1.Location);
            Assert.Null(id1.ResourceGroupName);
            ResourceIdentifier expectedId = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101");
            Assert.NotNull(id1.Parent);
            Assert.IsTrue(expectedId.Equals(id1.Parent));
        }

        [Test]
        public void TryGetPropertiesForSubscriptionProvider()
        {
            ResourceIdentifier id1 = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Compute");
            Assert.NotNull(id1.SubscriptionId);
            Assert.AreEqual("db1ab6f0-4769-4b27-930e-01e2ef9c123c", id1.SubscriptionId);
            Assert.Null(id1.Location);
            Assert.Null(id1.ResourceGroupName);
            ResourceIdentifier expectedId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c");
            Assert.NotNull(id1.Parent);
            Assert.IsTrue(expectedId.Equals(id1.Parent));
        }

        [Test]
        public void ThrowOnMistypedResource()
        {
            ResourceIdentifier subscription = new ResourceIdentifier("/providers/Contoso.Widgets/widgets/myWidget");
            Assert.IsNotNull(subscription);
            Assert.DoesNotThrow(() => subscription = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/locations/westus2"));
            Assert.DoesNotThrow(() => subscription = new ResourceIdentifier("/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/myRg"));
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

        [TestCase(SubscriptionResourceId, "wheels", "Wheel2")]
        [TestCase(SubscriptionResourceId, null, "wheel2")]
        [TestCase(SubscriptionResourceId, "wheels", null)]
        [TestCase(SubscriptionResourceId, "", "wheel2")]
        [TestCase(SubscriptionResourceId, "wheels", "  ")]
        [TestCase(SubscriptionResourceId, "wheels/spokes", "wheel2")]
        [TestCase(SubscriptionResourceId, "wheels", "wheel1/wheel2")]
        public void TestAppendSubscriptionChildResource(string resourceId, string childTypeName, string childResourceName)
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
