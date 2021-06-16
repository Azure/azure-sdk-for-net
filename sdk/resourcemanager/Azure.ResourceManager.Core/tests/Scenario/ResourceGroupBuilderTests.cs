using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
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
            Assert.ThrowsAsync<ArgumentException>(async () => _ = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(value));
        }

        [TestCase(null)]
        [TestCase("  ")]
        [RecordedTest]
        public void StartCreateOrUpdate(string value)
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var createOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(value);
                _ = await createOp.WaitForCompletionAsync();
            });
        }
    }
}
