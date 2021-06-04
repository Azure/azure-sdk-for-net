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
            Assert.AreEqual(null, z.Parent.Name);

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

            Assert.AreEqual(z.Name, "myVmName");
            Assert.AreEqual(z.ResourceType, "Microsoft.Compute/virtualMachines");

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

            Assert.AreEqual(z.Name, "testsubnet");
            Assert.AreEqual(z.ResourceType, "Microsoft.Resources/subnets");

            Assert.AreEqual(z.Parent.Name, "testvnet");
            Assert.AreEqual(z.Parent.ResourceType, "Microsoft.Network/virtualNetworks");

            Assert.AreEqual(z.Parent.Parent.Name, null);

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
