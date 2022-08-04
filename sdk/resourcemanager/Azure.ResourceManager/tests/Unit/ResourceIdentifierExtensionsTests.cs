using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    class ResourceIdentifierExtensionsTests
    {
        [TestCase("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm", "virtualMachines/myVm")]
        [TestCase("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm/extensions/ext", "virtualMachines/myVm/extensions/ext")]
        [TestCase("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg", "")]
        [TestCase("/providers/Microsoft.Management/managementGroups/group0/providers/Microsoft.Authorization/policyAssignments/assignment", "policyAssignments/assignment")]
        public void SubstringAfterProviderNamespaceTest(string resourceId, string expected)
        {
            ResourceIdentifier id = new ResourceIdentifier(resourceId);
            string result = id.SubstringAfterProviderNamespace();
            Assert.AreEqual(expected, result);
        }

        [TestCase("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm", false)]
        [TestCase("/providers/Microsoft.Compute/virtualMachines/myVm", true)]
        [TestCase("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575", false)]
        public void GetSubscriptionResourceIdentifier(string resourceId, bool shouldBeNull)
        {
            ResourceIdentifier id = new ResourceIdentifier(resourceId);
            ResourceIdentifier subId = id.GetSubscriptionResourceIdentifier();
            if (shouldBeNull)
            {
                Assert.IsNull(subId);
            }
            else
            {
                Assert.IsNotNull(subId);
            }
        }

        [Test]
        public void GetSubscriptionResourceIdentifierFromRoot()
        {
            ResourceIdentifier subId = ResourceIdentifier.Root.GetSubscriptionResourceIdentifier();
            Assert.IsNull(subId);
        }
    }
}
