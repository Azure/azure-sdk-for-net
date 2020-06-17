// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ContainerServiceOperationalTests : ContainerServiceTestsBase
    {
        public ContainerServiceOperationalTests(bool isAsync)
           : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        [Ignore("TRACK2: compute team will help to record because of ex 'Address prefix string for resource /subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/crptestar12191/providers/Microsoft.Network/virtualNetworks/dcos-vnet-35162761 cannot be null or empty' when record in track2")]
        public async Task TestDCOSOperations()
        {
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var csName = Recording.GenerateAssetName(ContainerServiceNamePrefix);
            var masterDnsPrefixName = Recording.GenerateAssetName(MasterProfileDnsPrefix);
            var agentPoolDnsPrefixName = Recording.GenerateAssetName(AgentPoolProfileDnsPrefix);
            EnsureClientsInitialized(LocationAustraliaSouthEast);

            ContainerService inputContainerService;
            var getTwocontainerService = await CreateContainerService_NoAsyncTracking(
                    rgName,
                    csName,
                    masterDnsPrefixName,
                    agentPoolDnsPrefixName,
                    //out inputContainerService,
                    cs => cs.OrchestratorProfile.OrchestratorType = ContainerServiceOrchestratorTypes.Dcos);
            var containerService = getTwocontainerService.Item1;
            inputContainerService = getTwocontainerService.Item2;
            await WaitForCompletionAsync(await ContainerServicesOperations.StartDeleteAsync(rgName, containerService.Name));
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Container Service
        /// Get Container Service
        /// Delete Container Service
        /// Delete RG
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task TestSwarmOperations()
        {
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix) + 1;
            var csName = Recording.GenerateAssetName(ContainerServiceNamePrefix);
            var masterDnsPrefixName = Recording.GenerateAssetName(MasterProfileDnsPrefix);
            var agentPoolDnsPrefixName = Recording.GenerateAssetName(AgentPoolProfileDnsPrefix);
            EnsureClientsInitialized(LocationAustraliaSouthEast);
            ContainerService inputContainerService;
            var getTwocontainerService = await CreateContainerService_NoAsyncTracking(
                rgName,
                csName,
                masterDnsPrefixName,
                agentPoolDnsPrefixName,
                //out inputContainerService,
                cs => cs.OrchestratorProfile.OrchestratorType = ContainerServiceOrchestratorTypes.Swarm);
            var containerService = getTwocontainerService.Item1;
            inputContainerService = getTwocontainerService.Item2;
            await WaitForCompletionAsync(await ContainerServicesOperations.StartDeleteAsync(rgName, containerService.Name));
        }
    }
}
