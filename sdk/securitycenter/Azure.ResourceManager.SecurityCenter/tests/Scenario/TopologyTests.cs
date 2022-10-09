// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class TopologyTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private TopologyResourceCollection _TopologyCollection;

        public TopologyTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _TopologyCollection = _resourceGroup.GetTopologyResources();
        }

        [RecordedTest]
        [Ignore("The SDK does not support create Topology.")]
        public async Task TopologyE2EOperation()
        {
            string ascLocation = "";
            string topologyResourceName = "";

            // Exist
            bool flag = await _TopologyCollection.ExistsAsync(ascLocation, topologyResourceName);
            Assert.IsTrue(flag);

            // Get
            var topology = await _TopologyCollection.GetAsync(ascLocation, topologyResourceName);
            Assert.IsNotNull(topology);
        }
    }
}
