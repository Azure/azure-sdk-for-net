using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceGroupBuilderTests : ResourceManagerTestBase
    {
        public ResourceGroupBuilderTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase(null)]
        [TestCase("  ")]
        [RecordedTest]
        public void CreateOrUpdate(string value)
        {
            Assert.ThrowsAsync<ArgumentException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(value));
        }

        [TestCase(null)]
        [TestCase("  ")]
        [RecordedTest]
        public void StartCreateOrUpdate(string value)
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var createOp = await Client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(value, false);
                _ = await createOp.WaitForCompletionAsync();
            });
        }

        [TestCase]
        [RecordedTest]
        public void Build()
        {
            var location = Location.WestUS2;
            var tags = new Dictionary<string, string>()
            {
                { "key", "value"}
            };
            var managedBy = "managedBy";
            var rgData = Client.DefaultSubscription.GetResourceGroups().Construct(location, tags, managedBy).Build();
            Assert.AreEqual(location, rgData.Location);
            Assert.AreEqual(tags, rgData.Tags);
            Assert.AreEqual(managedBy, rgData.ManagedBy);
        }
    }
}
