using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class TenantProviderIdentifierTests
    {
        [TestCase("/providers/Microsoft.Insights")]
        [TestCase("/providers/Microsoft.Insights/providers/Microsoft.Compute/virtualMachines/myVmName")]
        [TestCase("/providers/Microsoft.Insights/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/testsubnet")]
        public void ImplicitConstructor(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            TenantProviderIdentifier z = x;
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
    }
}
