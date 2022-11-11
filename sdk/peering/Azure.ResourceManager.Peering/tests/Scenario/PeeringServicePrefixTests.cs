// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Peering.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Peering.Tests
{
    internal class PeeringServicePrefixTests : PeeringManagementTestBase
    {
        private PeeringServiceResource _peeringService;
        private PeeringServicePrefixCollection _peeringServicePrefixCollection => _peeringService.GetPeeringServicePrefixes();

        public PeeringServicePrefixTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _peeringService = await CreateAtmanPeeringService(resourceGroup, Recording.GenerateAssetName("peeringService"));
        }

        [RecordedTest]
        [Ignore("cannot get Prefix key provided by ISP")]
        public async Task PrefixE2EOperation()
        {
            // Create
            string prefixName = Recording.GenerateAssetName("prefix");
            var data = new PeeringServicePrefixData()
            {
                Prefix = "34.56.10.0/24",
                PeeringServicePrefixKey = "6bfe26da-8159-41c9-aa2a-243b39952148",
            };
            var prefix = await _peeringServicePrefixCollection.CreateOrUpdateAsync(WaitUntil.Completed, prefixName, data);
            Assert.IsNotNull(prefix);
            Assert.AreEqual(prefixName, prefix.Value.Data.Name);

            // Exist
            bool flag = await _peeringServicePrefixCollection.ExistsAsync(prefixName);
            Assert.IsTrue(flag);

            // Get
            var getResponse = await _peeringServicePrefixCollection.GetAsync(prefixName);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(prefixName, getResponse.Value.Data.Name);

            // GetAll
            var list = await _peeringServicePrefixCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsNotNull(list.First(item => item.Data.Name == prefixName));

            // Delete
            await prefix.Value.DeleteAsync(WaitUntil.Completed);
            flag = await _peeringServicePrefixCollection.ExistsAsync(prefixName);
            Assert.IsFalse(flag);
        }
    }
}
