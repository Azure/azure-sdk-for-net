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
            Assert.That(connect, Is.Not.Null);
            Assert.That(connect.Value.Data.Name, Is.EqualTo(connectionMonitorTestName));

            // Exist
            bool flag = await _connectionMonitorTestCollection.ExistsAsync(connectionMonitorTestName);
            Assert.That(flag, Is.True);

            // Get
            var getResponse = await _connectionMonitorTestCollection.GetAsync(connectionMonitorTestName);
            Assert.That(getResponse, Is.Not.Null);
            Assert.That(getResponse.Value.Data.Name, Is.EqualTo(connectionMonitorTestName));

            // GetAll
            var list = await _connectionMonitorTestCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Empty);
            Assert.That(list.First(item => item.Data.Name == connectionMonitorTestName), Is.Not.Null);

            // Delete
            await connect.Value.DeleteAsync(WaitUntil.Completed);
            flag = await _connectionMonitorTestCollection.ExistsAsync(connectionMonitorTestName);
            Assert.That(flag, Is.False);
        }
    }
}
