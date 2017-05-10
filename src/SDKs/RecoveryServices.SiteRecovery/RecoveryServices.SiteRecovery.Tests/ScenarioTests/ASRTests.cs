// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Linq;
using SiteRecovery.Tests;

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Tests.ScenarioTests
{
    public class ASRTests : SiteRecoveryTestsBase
    {
        private const string siteName = "cloud1";
        private const string location = "southeastasia";
        private const string azureSiteName = "azureSite1";
        private const string providerName = "d5856310-ae3f-4329-8644-1349014fd0fd";
        private const string policyName = "protectionprofile11";
        private const string recoveryCloud = "Microsoft Azure";
        private const string protectionContainerMappingName = "PCMapping";
        private const string vmName = "vm11";

        TestHelper testHelper { get; set; }

        public ASRTests()
        {
            testHelper = new TestHelper();
        }

        /// <summary>
        /// Returns an unprotected item.
        /// </summary>
        /// <param name="client">Site Recovery management client.</param>
        /// <param name="fabricId">Fabric Id.</param>
        /// <param name="containerId">Container Id.</param>
        /// <returns>Unprotected VM.</returns>
        private ProtectableItem GetUnprotectedItem(SiteRecoveryManagementClient client, string fabricId, string containerId)
        {
            List<ProtectableItem> protectableItemList = new List<ProtectableItem>();
            protectableItemList.AddRange(
                client.ReplicationProtectableItems.ListByReplicationProtectionContainers(fabricId, containerId).ToList());

            return protectableItemList[0];
        }


        [Fact]
        public void CreateSite()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);

                FabricCreationInput siteInput = new FabricCreationInput();
                siteInput.Properties = new FabricCreationInputProperties();

                var client = testHelper.SiteRecoveryClient;

                var site = client.ReplicationFabrics.Create(siteName, siteInput);
                var response = client.ReplicationFabrics.Get(siteName);
                Assert.True(response.Name == siteName, "Site Name can not be different");
            }
        }

        [Fact]
        public void GetSite()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                Assert.NotNull(fabric.Id);
            }
        }

        public void DeleteSite()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationFabrics.Delete(siteName);
            }
        }

        [Fact]
        public void GetRSP()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabricResponse = client.ReplicationFabrics.Get(siteName);
                var recoveryServivesProviderResponse =
                    client.ReplicationRecoveryServicesProviders.Get(fabricResponse.Name, providerName);

                Assert.NotNull(recoveryServivesProviderResponse.Properties.FriendlyName);
                Assert.NotNull(recoveryServivesProviderResponse.Name);
                Assert.NotNull(recoveryServivesProviderResponse.Id);
            }
        }

        [Fact]
        public void GetContainer()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabricResponse = client.ReplicationFabrics.Get(siteName);

                var protectionContainerList =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabricResponse.Name).ToList();
                var protectionContainer = client.ReplicationProtectionContainers.Get(fabricResponse.Name,
                    protectionContainerList.FirstOrDefault().Name);

                Assert.NotNull(protectionContainer.Properties.FriendlyName);
                Assert.NotNull(protectionContainer.Name);
                Assert.NotNull(protectionContainer.Id);
            }
        }

        [Fact]
        public void EnumerateContainer()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabricResponse = client.ReplicationFabrics.Get(siteName);

                var protectionContainerList =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabricResponse.Name).ToList();

                Assert.True(protectionContainerList.Count > 0, "Atleast one container should be present.");
            }
        }

        [Fact]
        public void CreatePolicy()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                HyperVReplicaAzurePolicyInput h2ASpecificInput = new HyperVReplicaAzurePolicyInput()
                {
                    RecoveryPointHistoryDuration = 4,
                    ApplicationConsistentSnapshotFrequencyInHours = 2,
                    ReplicationInterval = 300,
                    OnlineReplicationStartTime = null,
                    Encryption = "Disable",
                    StorageAccounts = new List<string>() { "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/siterecoveryprod1/providers/Microsoft.Storage/storageAccounts/storavrai" }
                };

                CreatePolicyInputProperties inputProperties = new CreatePolicyInputProperties()
                {
                    ProviderSpecificInput = h2ASpecificInput
                };

                CreatePolicyInput input = new CreatePolicyInput()
                {
                    Properties = inputProperties
                };

                var policy = client.ReplicationPolicies.Create(policyName, input);

                var response = client.ReplicationPolicies.Get(policyName);
                Assert.NotNull(response.Id);
                Assert.NotNull(response.Name);
            }
        }

        [Fact]
        public void GetPolicy()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var policy = client.ReplicationPolicies.Get(policyName);
                Assert.NotNull(policy.Id);
                Assert.NotNull(policy.Name);
            }
        }

        [Fact]
        public void UpdatePolicy()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                HyperVReplicaAzurePolicyInput h2ASpecificInput = new HyperVReplicaAzurePolicyInput()
                {
                    RecoveryPointHistoryDuration = 3,
                    ApplicationConsistentSnapshotFrequencyInHours = 2,
                    ReplicationInterval = 300,
                    OnlineReplicationStartTime = null,
                    Encryption = "Disable",
                    StorageAccounts = new List<string>() { "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/siterecoveryprod1/providers/Microsoft.Storage/storageAccounts/storavrai" }
                };

                UpdatePolicyInputProperties inputProperties = new UpdatePolicyInputProperties()
                {

                    ReplicationProviderSettings = h2ASpecificInput
                };

                UpdatePolicyInput input = new UpdatePolicyInput()
                {
                    Properties = inputProperties
                };

                var policy = client.ReplicationPolicies.Update(policyName, input);
                var response = client.ReplicationPolicies.Get(policyName);
                Assert.NotNull(response.Id);
                Assert.NotNull(response.Name);
            }
        }

        [Fact]
        public void DeletePolicy()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;
                client.ReplicationPolicies.Delete(policyName);
            }
        }

        [Fact]
        public void CreatePCMapping()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainerList =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabric.Name).ToList();
                var protectionContainer = client.ReplicationProtectionContainers.Get(fabric.Name,
                    protectionContainerList.FirstOrDefault().Name);

                var policy = client.ReplicationPolicies.Get(policyName);

                CreateProtectionContainerMappingInputProperties containerMappingInputProperties =
                    new CreateProtectionContainerMappingInputProperties()
                    {
                        PolicyId = policy.Id,
                        ProviderSpecificInput = new ReplicationProviderSpecificContainerMappingInput(),
                        TargetProtectionContainerId = recoveryCloud
                    };

                CreateProtectionContainerMappingInput containerMappingInput = new CreateProtectionContainerMappingInput()
                {
                    Properties = containerMappingInputProperties
                };

                var response = client.ReplicationProtectionContainerMappings.Create(
                    fabric.Name, protectionContainer.Name, protectionContainerMappingName, containerMappingInput);

                var protectionContainerMapping = client.ReplicationProtectionContainerMappings.Get(
                    fabric.Name, protectionContainer.Name, protectionContainerMappingName);

                Assert.NotNull(protectionContainerMapping.Id);
            }
        }

        [Fact]
        public void GetPCMapping()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainerList =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabric.Name).ToList();
                var protectionContainer = client.ReplicationProtectionContainers.Get(fabric.Name,
                    protectionContainerList.FirstOrDefault().Name);

                var protectionContainerMapping = client.ReplicationProtectionContainerMappings.Get(
                    fabric.Name, protectionContainer.Name, protectionContainerMappingName);

                Assert.NotNull(protectionContainerMapping.Id);
            }
        }

        [Fact]
        public void DeletePCMapping()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainerList =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabric.Name).ToList();
                var protectionContainer = client.ReplicationProtectionContainers.Get(fabric.Name,
                    protectionContainerList.FirstOrDefault().Name);

                client.ReplicationProtectionContainerMappings.Delete(
                    fabric.Name, protectionContainer.Name, protectionContainerMappingName, new RemoveProtectionContainerMappingInput());
            }
        }

        [Fact]
        public void GetProtectableItem()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainerList =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabric.Name).ToList();
                var protectionContainer = client.ReplicationProtectionContainers.Get(fabric.Name,
                    protectionContainerList.FirstOrDefault().Name);

                var protectableItemList = client.ReplicationProtectableItems.ListByReplicationProtectionContainers(
                    fabric.Name, protectionContainer.Name);

                var protectableItem = protectableItemList.First(item =>
                item.Properties.FriendlyName.Equals(vmName, StringComparison.OrdinalIgnoreCase));

                Assert.NotNull(protectableItem.Id);
            }
        }

        [Fact]
        public void EnumerateProtectableItem()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainerList =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabric.Name).ToList();
                var protectionContainer = client.ReplicationProtectionContainers.Get(fabric.Name,
                    protectionContainerList.FirstOrDefault().Name);

                var protectableItemList = client.ReplicationProtectableItems.ListByReplicationProtectionContainers(
                    fabric.Name, protectionContainer.Name).ToList();

                Assert.True(protectableItemList.Count > 0, "Atleast one protectable item should be present.");
            }
        }
    }
}