using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ArmBuilderTests : ResourceManagerTestBase
    {
        private ArmClient _client;

        public ArmBuilderTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _client = GetArmClient();
        }

        [TestCase(null)]
        [TestCase("  ")]
        [RecordedTest]
        public void TestCreateOrUpdate(string value)
        {
            Assert.ThrowsAsync<ArgumentException>(async delegate { await _client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(value); });
        }

        [TestCase(null)]
        [TestCase("    ")]
        [RecordedTest]
        public void TestStartCreateOrUpdate(string value)
        {
            Assert.ThrowsAsync<ArgumentException>(async delegate { await _client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(value); });
        }
    }
}
