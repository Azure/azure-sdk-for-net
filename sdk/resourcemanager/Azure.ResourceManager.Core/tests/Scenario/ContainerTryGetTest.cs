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
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _rgName = Recording.GenerateAssetName("CoreRg");
            _client = GetArmClient();
            _container = _client.DefaultSubscription.GetResourceGroups();
            _resourceGroup = _container.Construct(LocationData.WestUS2).CreateOrUpdate(_rgName);
        }

        [TestCase]
        [RecordedTest]
        public void TryGetTest() 
        {
            ResourceGroup result = _container.TryGet(_rgName);
            Assert.NotNull(result);
            Assert.IsTrue(result.Data.Name == _rgName);
            result = _container.TryGet("FakeName");
            Assert.IsNull(result);
        }

        [TestCase]
        [RecordedTest]
        public async Task TryGetAsyncTest()
        {
            ResourceGroup result = await _container.TryGetAsync(_rgName);
            Assert.NotNull(result);
            Assert.IsTrue(result.Data.Name == _rgName);
            result = await _container.TryGetAsync("FakeName");
            Assert.IsNull(result);
        }

        [TestCase]
        public void DoesExistTest()
        {
            Assert.IsTrue(_container.DoesExist(_rgName));
            Assert.IsFalse(_container.DoesExist("FakeName"));
        }
    }
}
