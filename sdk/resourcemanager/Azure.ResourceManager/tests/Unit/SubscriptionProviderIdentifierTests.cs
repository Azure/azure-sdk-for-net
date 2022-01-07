using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class SubscriptionProviderIdentifierTests : ResourceIdentifierTests
    {
        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Insights")]
        public void ImplicitConstructorWithProvider(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            ResourceIdentifier z = new ResourceIdentifier(x);
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
            ResourceIdentifier z = new ResourceIdentifier(x);
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
            ResourceIdentifier z = new ResourceIdentifier(x);
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
    }
}
