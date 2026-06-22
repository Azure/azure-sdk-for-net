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

        public AllowedConnectionsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            string interfaceName = Recording.GenerateAssetName("networkInterface");
            string vmName = Recording.GenerateAssetName("vm");
            var networkInterface = await CreateNetworkInterface(_resourceGroup, interfaceName);
            await CreateVirtualMachine(_resourceGroup, networkInterface.Id, vmName);
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(20 * 60 * 1000); // wait for VM auto connect, costs 20mins or more
            }
        }

        [RecordedTest]
        [Category("Manually")]
        public async Task Get()
        {
            var list = await DefaultSubscription.GetAllowedConnectionsAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAllowedConnections(list.FirstOrDefault());
        }

        [RecordedTest]
        [Category("Manually")]
        public async Task GetAll()
        {
            var list = await DefaultSubscription.GetAllowedConnectionsAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAllowedConnections(list.FirstOrDefault());
        }

        private void ValidateAllowedConnections(SecurityCenterAllowedConnection allowedConnections)
        {
            Assert.IsNotNull(allowedConnections);
            Assert.IsNotNull(allowedConnections.Id);
            Assert.AreEqual("Internal", allowedConnections.Name);
            Assert.AreEqual("centralus", allowedConnections.Location.ToString());
            Assert.AreEqual("Microsoft.Security/locations/allowedConnections", allowedConnections.ResourceType.ToString());
        }
    }
}
