using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class TenantProviderIdentifierTests
    {
        [TestCase("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/microsoft.insights")]
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
