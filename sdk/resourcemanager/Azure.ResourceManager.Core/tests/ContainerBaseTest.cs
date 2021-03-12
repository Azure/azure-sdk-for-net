// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ContainerBaseTest
    {
        private ResourceGroupContainer _container;
        private ResourceGroup _resourceGroup;
        private readonly string _rgName = $"{Environment.UserName}-rg-{Environment.TickCount}";

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            _container = new AzureResourceManagerClient(new DefaultAzureCredential()).DefaultSubscription.GetResourceGroupContainer();
            _resourceGroup = _container.Construct(LocationData.WestUS2).CreateOrUpdate(_rgName);
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            _resourceGroup.StartDelete();
        }

        [TestCase]
        public void TryGetTest() 
        {
            ResourceGroup result = _container.TryGet(_rgName);
            Assert.NotNull(result);
            Assert.IsTrue(result.Data.Name == _rgName);
            result = _container.TryGet("FakeName"+ new Random().Next(1,100));
            Assert.IsNull(result);
        }

        [TestCase]
        public async Task TryGetAsyncTest()
        {
            ResourceGroup result = await _container.TryGetAsync(_rgName);
            Assert.NotNull(result);
            Assert.IsTrue(result.Data.Name == _rgName);
            result = await _container.TryGetAsync("FakeName" + new Random().Next(1, 100));
            Assert.IsNull(result);
        }

        [TestCase]
        public void DoesExistTest()
        {
            Assert.IsTrue(_container.DoesExist(_rgName));
            Assert.IsFalse(_container.DoesExist("FakeName" + new Random().Next(1, 100)));
        }
    }
}
