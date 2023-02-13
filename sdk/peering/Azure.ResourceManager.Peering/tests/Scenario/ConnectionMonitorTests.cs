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
    internal class ConnectionMonitorTests : PeeringManagementTestBase
    {
        private PeeringServiceResource _peeringService;
        private ConnectionMonitorTestCollection _connectionMonitorTestCollection => _peeringService.GetConnectionMonitorTests();

        public ConnectionMonitorTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _peeringService = await CreateAtmanPeeringService(resourceGroup, Recording.GenerateAssetName("peeringService"));
        }

        [RecordedTest]
        [Ignore("No actual ISP provider to create a connection")]
        public async Task ConnectionMonitorE2EOperation()
        {
            // Create
            string connectionMonitorTestName = Recording.GenerateAssetName("connect");
            var data = new ConnectionMonitorTestData();
            var connect = await _connectionMonitorTestCollection.CreateOrUpdateAsync(WaitUntil.Completed, connectionMonitorTestName, data);
            Assert.IsNotNull(connect);
            Assert.AreEqual(connectionMonitorTestName, connect.Value.Data.Name);

            // Exist
            bool flag = await _connectionMonitorTestCollection.ExistsAsync(connectionMonitorTestName);
            Assert.IsTrue(flag);

            // Get
            var getResponse = await _connectionMonitorTestCollection.GetAsync(connectionMonitorTestName);
            Assert.IsNotNull(getResponse);
            Assert.AreEqual(connectionMonitorTestName, getResponse.Value.Data.Name);

            // GetAll
            var list = await _connectionMonitorTestCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
            Assert.IsNotNull(list.First(item => item.Data.Name == connectionMonitorTestName));

            // Delete
            await connect.Value.DeleteAsync(WaitUntil.Completed);
            flag = await _connectionMonitorTestCollection.ExistsAsync(connectionMonitorTestName);
            Assert.IsFalse(flag);
        }
    }
}
