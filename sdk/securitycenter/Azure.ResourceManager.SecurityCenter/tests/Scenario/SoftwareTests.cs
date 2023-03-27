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
    internal class SoftwareTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private SoftwareInventoryCollection _softwareCollection;
        public SoftwareTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            var nsg = await CreateNetworkSecurityGroup(_resourceGroup, Recording.GenerateAssetName("nsg"));
            var network = await CreateNetwork(_resourceGroup, nsg, Recording.GenerateAssetName("vnet"));
            var networkInterface = await CreateNetworkInterface(_resourceGroup, network, Recording.GenerateAssetName("networkInterface"));
            var vm = await CreateVirtualMachine(_resourceGroup, networkInterface.Id, Recording.GenerateAssetName("vm"));
            _softwareCollection = _resourceGroup.GetSoftwareInventories("Microsoft.Compute", "virtualMachines", vm.Id.Name);
        }

        [RecordedTest]
        [Ignore("RequestFailedException: No registered resource provider found for API VERSION 2021-05-01-preview")]
        public async Task GetAll()
        {
            var list = await _softwareCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
