using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
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
            Assert.ThrowsAsync<ArgumentException>(async delegate { await _client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(value); });
        }

        [TestCase(null)]
        [TestCase("    ")]
        [RecordedTest]
        public void TestStartCreateOrUpdate(string value)
        {
            Assert.ThrowsAsync<ArgumentException>(async delegate { await _client.DefaultSubscription.GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(value, false); });
        }
    }
}
