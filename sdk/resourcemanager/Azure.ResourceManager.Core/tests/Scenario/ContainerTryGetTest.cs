// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
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
            _resourceGroup = await _container.Construct(LocationData.WestUS2).CreateOrUpdateAsync(_rgName);
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGetTest()
        {
            ResourceGroup result = await _container.TryGetAsync(_rgName);
            Assert.NotNull(result);
            Assert.IsTrue(result.Data.Name == _rgName);
            result = await _container.TryGetAsync("FakeName");
            Assert.IsNull(result);
        }

        [TestCase]
        [RecordedTest]
        [SyncOnly]
        public void DoesExistTest()
        {
            Assert.IsTrue(_container.DoesExist(_rgName));
            Assert.IsFalse(_container.DoesExist("FakeName"));
        }
    }
}
