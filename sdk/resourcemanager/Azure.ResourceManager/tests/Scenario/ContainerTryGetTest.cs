// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ContainerTryGetTest : ResourceManagerTestBase
    {
        private ArmClient _client;
        private ResourceGroupContainer _container;
        private ResourceGroup _resourceGroup;
        private string _rgName;

        public ContainerTryGetTest(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _rgName = Recording.GenerateAssetName("CoreRg");
            _client = GetArmClient();
            _container = _client.DefaultSubscription.GetResourceGroups();
            var rgOp = await _container.Construct(Location.WestUS2).CreateOrUpdateAsync(_rgName);
            _resourceGroup = rgOp.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGetTest()
        {
            ResourceGroup result = await _container.GetIfExistsAsync(_rgName);
            Assert.NotNull(result);
            Assert.IsTrue(result.Data.Name == _rgName);
            result = await _container.GetIfExistsAsync("FakeName");
            Assert.IsNull(result);
        }
    }
}
