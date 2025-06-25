// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Avs.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests.Scenario
{
    public class AvsProvisionedNetworksTest : AvsManagementTestBase
    {
        public AvsProvisionedNetworksTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task Get_Resource()
        {
            AvsProvisionedNetworkResource result = await getAvsProvisionedNetworksResource().GetAsync();
            Assert.AreEqual(result.Data.Name, PROVISIONED_NETWORK_NAME);
        }
        [TestCase, Order(2)]
        [RecordedTest]
        public async Task Get_Collection()
        {
            AvsProvisionedNetworkResource result = await getAvsProvisionedNetworksCollection().GetAsync(PROVISIONED_NETWORK_NAME);
            Assert.AreEqual(result.Data.Name, PROVISIONED_NETWORK_NAME);
        }
        [TestCase, Order(3)]
        [RecordedTest]
        public async Task List()
        {
            AvsProvisionedNetworkCollection collection = getAvsProvisionedNetworksCollection();
            var provisionedNetworks = new List<AvsProvisionedNetworkResource>();

            await foreach (AvsProvisionedNetworkResource item in collection.GetAllAsync())
            {
                AvsProvisionedNetworkData resourceData = item.Data;
                provisionedNetworks.Add(item);
            }
            Assert.IsTrue(provisionedNetworks.Any());
            Assert.IsTrue(provisionedNetworks.Any(c => c.Data.Name == PROVISIONED_NETWORK_NAME));
        }
        [TestCase, Order(4)]
        [RecordedTest]
        public async Task GetIfExists()
        {
            bool exists = await getAvsProvisionedNetworksCollection().ExistsAsync(PROVISIONED_NETWORK_NAME);
            Assert.True(exists);
        }
    }
}