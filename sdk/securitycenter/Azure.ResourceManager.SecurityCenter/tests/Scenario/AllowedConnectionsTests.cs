// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class AllowedConnectionsTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private AllowedConnectionsResourceCollection _allowedConnectionsResourceCollection;

        public AllowedConnectionsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            var nsg = await CreateNetworkSecurityGroup(_resourceGroup, Recording.GenerateAssetName("nsg"));
            var network = await CreateNetwork(_resourceGroup, nsg, Recording.GenerateAssetName("vnet"));
            var networkInterface = await CreateNetworkInterface(_resourceGroup, network, Recording.GenerateAssetName("networkInterface"));
            await CreateVirtualMachine(_resourceGroup, networkInterface.Data.Id, Recording.GenerateAssetName("vm"));
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(20 * 60 * 1000); // wait for VM auto connect, costs 20mins or more
            }
            _allowedConnectionsResourceCollection = _resourceGroup.GetAllowedConnectionsResources();
        }

        [RecordedTest]
        public async Task Exist()
        {
            bool flag = await _allowedConnectionsResourceCollection.ExistsAsync(AzureLocation.CentralUS, ConnectionType.Internal);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var allowedConnections = await _allowedConnectionsResourceCollection.GetAsync(AzureLocation.CentralUS, ConnectionType.Internal);
            ValidateAllowedConnections(allowedConnections);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await DefaultSubscription.GetAllowedConnectionsResourcesAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAllowedConnections(list.FirstOrDefault());
        }

        private void ValidateAllowedConnections(AllowedConnectionsResource allowedConnections)
        {
            Assert.IsNotNull(allowedConnections);
            Assert.IsNotNull(allowedConnections.Data.Id);
            Assert.AreEqual("Internal", allowedConnections.Data.Name);
            Assert.AreEqual("centralus", allowedConnections.Data.Location.ToString());
            Assert.AreEqual("Microsoft.Security/locations/allowedConnections", allowedConnections.Data.ResourceType.ToString());
        }
    }
}
