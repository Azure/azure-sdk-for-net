using NUnit.Framework;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Tests.Unit
{
    [Parallelizable]
    class ResourceIdentifierExtensionsTests
    {
        [TestCase("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm", "providers/Microsoft.Compute/virtualMachines/myVm", 0)]
        [TestCase("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm", "Microsoft.Compute/virtualMachines/myVm", 1)]
        [TestCase("/subscriptions/0c2f6471-1bf0-4dda-aec3-cb9272f09575/resourceGroups/myRg/providers/Microsoft.Compute/virtualMachines/myVm", "virtualMachines/myVm", 2)]
        public void GetPartsTest(string resourceId, string expected, int start)
        {
            ResourceIdentifier id = resourceId;
            string result = id.GetParts(start);
            Assert.AreEqual(expected, result);
        }
    }
}
