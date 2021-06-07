using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class SubscriptionProviderIdentifierTests
    {
        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Insights")]
        public void ImplicitConstructorWithProvider(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            SubscriptionProviderIdentifier z = x;
            y = z;

            Assert.AreEqual(z.Provider, "Microsoft.Insights");
            Assert.AreEqual(z.ResourceType, null);
            Assert.AreEqual(z.Parent.ResourceType, "Microsoft.Resources/subscriptions");
            Assert.AreEqual(z.Parent.Name, "db1ab6f0-4769-4b27-930e-01e2ef9c123c");

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
            SubscriptionProviderIdentifier z = x;
            y = z;

            Assert.AreEqual(z.Provider, null);
            Assert.AreEqual(z.ResourceType, "Microsoft.Network/virtualNetworks/subnets");
            Assert.AreEqual(z.Parent.ResourceType, "Microsoft.Network/virtualNetworks");
            Assert.AreEqual(z.Parent.Name, "testvnet");
            Assert.AreEqual(z.Parent.Parent.ResourceType, null);
            Assert.AreEqual(z.Parent.Parent.Parent.ResourceType, "Microsoft.Resources/subscriptions");
            Assert.AreEqual(z.Parent.Parent.Parent.Name, "db1ab6f0-4769-4b27-930e-01e2ef9c123c");

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

        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Insights/providers/Microsoft.Network/virtualNetworks/testvnet/")]
        public void ImplicitConstructorWithVNet(string resourceProviderID)
        {
            string x = resourceProviderID;
            string y;
            SubscriptionProviderIdentifier z = x;
            y = z;

            Assert.AreEqual(z.Provider, null);
            Assert.AreEqual(z.ResourceType, "Microsoft.Network/virtualNetworks");
            Assert.AreEqual(z.Name, "testvnet");
            //Assert.AreEqual(z.Parent.Provider, "Microsoft.Insights");
            Assert.IsNull(z.Parent.ResourceType);
            Assert.IsNull(z.Parent.Name);
            Assert.AreEqual(z.Parent.Parent.ResourceType, "Microsoft.Resources/subscriptions");
            Assert.AreEqual(z.Parent.Parent.Name, "db1ab6f0-4769-4b27-930e-01e2ef9c123c");

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
