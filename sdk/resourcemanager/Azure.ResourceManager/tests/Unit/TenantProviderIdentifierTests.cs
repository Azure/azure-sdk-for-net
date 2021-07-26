using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class TenantProviderIdentifierTests
    {
        [TestCase("/providers/Microsoft.Insights")]
        public void ImplicitConstructorProviderOnly(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            TenantProviderIdentifier z = x;
            y = z;

            Assert.IsNotNull(z.Parent);
            Assert.AreEqual("Microsoft.Insights", z.Provider);
            Assert.AreEqual("Microsoft.Resources/providers", z.ResourceType.ToString());
            Assert.IsNull(z.Parent.Name);

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
            TenantProviderIdentifier z = x;
            y = z;

            Assert.AreEqual("myVmName", z.Name);
            Assert.AreEqual("Microsoft.Compute/virtualMachines", z.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Insights" ,z.Provider);
            Assert.AreEqual("Microsoft.Insights", (z.Parent as TenantProviderIdentifier).Provider);
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
            TenantProviderIdentifier z = x;
            y = z;

            Assert.AreEqual("testsubnet", z.Name);
            Assert.AreEqual("Microsoft.Network/virtualNetworks/subnets", z.ResourceType.ToString());
            Assert.AreEqual("Microsoft.Insights", z.Provider);
            Assert.AreEqual("Microsoft.Insights", (z.Parent as TenantProviderIdentifier).Provider);
            Assert.AreEqual("Microsoft.Insights", (z.Parent.Parent as TenantProviderIdentifier).Provider);
            Assert.AreEqual("testvnet", z.Parent.Name);
            Assert.AreEqual("Microsoft.Network/virtualNetworks", z.Parent.ResourceType.ToString());
            Assert.IsNull(z.Parent.Parent.Name);
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
    }
}
