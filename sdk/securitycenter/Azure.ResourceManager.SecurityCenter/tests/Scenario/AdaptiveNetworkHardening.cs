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
    internal class AdaptiveNetworkHardening : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private AdaptiveNetworkHardeningCollection _adaptiveNetworkHardeningCollection;
        private ResourceIdentifier _nsgId;

        public AdaptiveNetworkHardening(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            var nsg = await CreateNetworkSecurityGroup(_resourceGroup, Recording.GenerateAssetName("nsg"));
            var network = await CreateNetwork(_resourceGroup, nsg, Recording.GenerateAssetName("vnet"));
            var networkInterface = await CreateNetworkInterface(_resourceGroup, network, Recording.GenerateAssetName("networkInterface"));
            string vmName = Recording.GenerateAssetName("vm");
            var vm = await CreateVirtualMachine(_resourceGroup, networkInterface.Data.Id, vmName);
            _nsgId = nsg.Id;
            _adaptiveNetworkHardeningCollection = _resourceGroup.GetAdaptiveNetworkHardenings("Microsoft.Compute", "virtualMachines", vmName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _adaptiveNetworkHardeningCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }

        [RecordedTest]
        [Ignore("SDK does not support create adaptiveNetworkHardenings")]
        public async Task Enforce()
        {
            var list = await _adaptiveNetworkHardeningCollection.GetAllAsync().ToEnumerableAsync();
            var adaptiveNetworkHardening = list.FirstOrDefault();

            List<RecommendedSecurityRule> rules = new List<RecommendedSecurityRule>()
            {
                new RecommendedSecurityRule()
                {
                    Name = "SystemGenerated",
                    Direction = SecurityTrafficDirection.Inbound,
                    DestinationPort = 3389,
                    Protocols =
                    {
                        "TCP"
                    },
                }
            };
            List<string> networkSecurityGroups = new List<string>()
            {
                _nsgId
            };
            AdaptiveNetworkHardeningEnforceContent content = new AdaptiveNetworkHardeningEnforceContent(rules, networkSecurityGroups) { };
            await adaptiveNetworkHardening.EnforceAsync(WaitUntil.Completed, content);
        }
    }
}
