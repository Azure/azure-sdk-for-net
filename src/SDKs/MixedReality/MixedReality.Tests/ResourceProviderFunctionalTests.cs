using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Azure.Management.MixedReality
{
    using Models;
    using Properties;
    using System;
    using System.Linq;

    [TestClass]
    public class ResourceProviderFunctionalTests
    {
        [TestMethod]
        public void TestGetOperations()
        {
            using (var client = new MixedRealityTestClient())
            {
                client.Operations.Enumerate();
            }
        }

        [TestMethod]
        public void TestResourceCRUD()
        {
            const string ResourceType = "Microsoft.MixedReality/SpatialAnchorsAccounts";

            const string AlphaNumeric = "abcdefghijklmnopqrstuvwxyz0123456789";

            var random = new Random();

            var name = new string(Enumerable.Repeat(AlphaNumeric, 8).Select(s => s[random.Next(s.Length)]).ToArray());

            using (var client = new MixedRealityTestClient())
            {
                // Check Name Availability
                var check = new CheckNameAvailabilityRequest()
                {
                    Name = name,
                    Type = ResourceType
                };

                var availability = client.CheckNameAvailabilityLocal(Settings.Default.Location, check);

                var available = bool.Parse(availability.NameAvailable);

                Assert.IsTrue(available);

                var account = new SpatialAnchorsAccount(Settings.Default.Location, name, ResourceType);

                // Create
                account = client.SpatialAnchorsAccounts.Create(Settings.Default.ResourceGroup, name, account);

                // Read
                account = client.SpatialAnchorsAccounts.Get(Settings.Default.ResourceGroup, name);

                // Update
                account.Tags["foo"] = "bar";

                account = client.SpatialAnchorsAccounts.Update(Settings.Default.ResourceGroup, name, new SpatialAnchorsAccount { Tags = account.Tags });

                // Delete
                client.SpatialAnchorsAccounts.Delete(Settings.Default.ResourceGroup, name);
            }
        }
    }
}
