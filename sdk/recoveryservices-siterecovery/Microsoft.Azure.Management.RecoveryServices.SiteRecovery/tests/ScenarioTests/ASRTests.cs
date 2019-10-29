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
using Microsoft.Rest.Azure.OData;

namespace RecoveryServices.SiteRecovery.Tests
{
    public class ASRTests : SiteRecoveryTestsBase
    {
        private const string targetResourceGroup = "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/siterecoveryprod1";
        private const string storageAccountId = "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/siterecoveryprod1/providers/Microsoft.Storage/storageAccounts/storavrai";
        private const string azureNetworkId = "/subscriptions/c183865e-6077-46f2-a3b1-deb0f4f4650a/resourceGroups/siterecoveryProd1/providers/Microsoft.Network/virtualNetworks/vnetavrai";
        private const string siteName = "SiteRecoveryTestSite1";
        private const string vmmFabric = "d188dc378a78c819bfb8b1f07eba2c15511e1788c41ba27792d9433fc6a4e087";
        private const string location = "westus";
        private const string providerName = "ba2a2d25-377f-4f4b-94a4-2981c79b0998";
        private const string policyName = "protectionprofile1";
        private const string recoveryCloud = "Microsoft Azure";
        private const string protectionContainerMappingName = "PCMapping";
        private const string networkMappingName = "NWMapping";
        private const string vmName = "vm1";
        private const string vmId = "f8491e4f-817a-40dd-a90c-af773978c75b";
        private const string vmName2 = "vm2";
        private const string rpName = "rpTest1";
        private const string emailAddress = "ronehr@microsoft.com";
        private const string alertSettingName = "defaultAlertSetting";
        private const string vmNetworkName = "c41eda86-96d5-4541-a6f8-c47d4b75a24a";

        private const string a2aPrimaryLocation = "westeurope";
        private const string a2aRecoveryLocation = "northeurope";
        private const string a2aPrimaryFabricName = "primaryFabric";
        private const string a2aRecoveryFabricName = "recoveryFabric";
        private const string a2aPrimaryContainerName = "primaryContainer";
        private const string a2aRecoveryContainerName = "recoveryContainer";
        private const string a2aPolicyName = "a2aPolicy";
        private const string a2aPrimaryRecoveryContainerMappingName = "primaryToRecovery";
        private const string a2aRecoveryPrimaryContainerMappingName = "recoveryToPrimary";
        private const string a2aVirtualMachineToProtect =
            "/subscriptions/a7d8f9d0-930c-4dc8-9c14-1526ba255c20/resourceGroups/sdkTestVmRG/providers/Microsoft.Compute/virtualMachines/sdkTestVm1";
        private const string a2aVirtualMachineDiskToProtect =
            "/subscriptions/a7d8f9d0-930c-4dc8-9c14-1526ba255c20/resourceGroups/SDKTESTVMRG/providers/Microsoft.Compute/disks/sdkTestVm1_OsDisk_1_3b1dd430d52044f18fb996d34617f609";
        private const string a2aStagingStorageAccount =
            "/subscriptions/a7d8f9d0-930c-4dc8-9c14-1526ba255c20/resourceGroups/siterecoveryprod1/providers/Microsoft.Storage/storageAccounts/do00nssdkvaultasrcache";
        private const string a2aRecoveryResourceGroup =
            "/subscriptions/a7d8f9d0-930c-4dc8-9c14-1526ba255c20/resourceGroups/sdkTestVmRG-asr";
        private const string a2aReplicationProtectedItemName = "sdkTestVm1";

        TestHelper testHelper { get; set; }

        public ASRTests()
        {
            testHelper = new TestHelper();
        }

        [Fact]
        public void CreateA2APolicy()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var a2aPolicyCreationInput = new A2APolicyCreationInput
                {
                    AppConsistentFrequencyInMinutes = 60,
                    RecoveryPointHistory = 720,
                    MultiVmSyncStatus = "Enable"
                };

                var createPolicyInput =
                    new CreatePolicyInput
                    {
                        Properties = new CreatePolicyInputProperties()
                    };
                createPolicyInput.Properties.ProviderSpecificInput = a2aPolicyCreationInput;

                var policy =
                    client.ReplicationPolicies.Create(a2aPolicyName, createPolicyInput);
                Assert.True(
                    policy.Name == a2aPolicyName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public void CreateA2AFabrics()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabricCreationInput = new FabricCreationInput();
                fabricCreationInput.Properties = new FabricCreationInputProperties();
                var azureFabricCreationInput = new AzureFabricCreationInput();

                // Create primary fabric.
                azureFabricCreationInput.Location = a2aPrimaryLocation;
                fabricCreationInput.Properties.CustomDetails = azureFabricCreationInput;

                var primaryFabric =
                    client.ReplicationFabrics.Create(a2aPrimaryFabricName, fabricCreationInput);
                // var response = client.ReplicationFabrics.Get(a2aPrimaryFabricName);
                Assert.True(
                    primaryFabric.Name == a2aPrimaryFabricName,
                    "Resource name can not be different.");

                // Create recovery fabric.
                azureFabricCreationInput.Location = a2aRecoveryLocation;
                fabricCreationInput.Properties.CustomDetails = azureFabricCreationInput;

                var recoveryFabric =
                    client.ReplicationFabrics.Create(a2aRecoveryFabricName, fabricCreationInput);
                // response = client.ReplicationFabrics.Get(a2aRecoveryFabricName);
                Assert.True(
                    recoveryFabric.Name == a2aRecoveryFabricName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public void CreateA2AContainers()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var createProtectionContainerInput =
                    new CreateProtectionContainerInput
                    {
                        Properties = new CreateProtectionContainerInputProperties()
                    };

                var primaryContainer =
                    client.ReplicationProtectionContainers.Create(
                        a2aPrimaryFabricName,
                        a2aPrimaryContainerName,
                        createProtectionContainerInput);
                Assert.True(
                    primaryContainer.Name == a2aPrimaryContainerName,
                    "Resource name can not be different.");

                var recoveryContainer =
                    client.ReplicationProtectionContainers.Create(
                        a2aRecoveryFabricName,
                        a2aRecoveryContainerName,
                        createProtectionContainerInput);
                Assert.True(
                    recoveryContainer.Name == a2aRecoveryContainerName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public void CreateA2AContainerMappings()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var createProtectionContainerMappingInput =
                    new CreateProtectionContainerMappingInput
                    {
                        Properties = new CreateProtectionContainerMappingInputProperties()
                    };

                var policy = client.ReplicationPolicies.Get(a2aPolicyName);
                var primaryContainer =
                    client.ReplicationProtectionContainers.Get(
                        a2aPrimaryFabricName,
                        a2aPrimaryContainerName);
                var recoveryContainer =
                    client.ReplicationProtectionContainers.Get(
                        a2aRecoveryFabricName,
                        a2aRecoveryContainerName);

                // Create primary to recovery container mapping
                createProtectionContainerMappingInput.Properties.PolicyId = policy.Id;
                createProtectionContainerMappingInput.Properties.TargetProtectionContainerId =
                    recoveryContainer.Id;
                createProtectionContainerMappingInput.Properties.ProviderSpecificInput =
                    new ReplicationProviderSpecificContainerMappingInput();

                var primaryRecoveryContainerMapping =
                    client.ReplicationProtectionContainerMappings.Create(
                        a2aPrimaryFabricName,
                        a2aPrimaryContainerName,
                        a2aPrimaryRecoveryContainerMappingName,
                        createProtectionContainerMappingInput);
                Assert.True(
                    primaryRecoveryContainerMapping.Name == a2aPrimaryRecoveryContainerMappingName,
                    "Resource name can not be different.");

                // Create primary to recovery container mapping
                createProtectionContainerMappingInput.Properties.TargetProtectionContainerId =
                    primaryContainer.Id;
                var recoveryPrimaryContainerMapping =
                    client.ReplicationProtectionContainerMappings.Create(
                        a2aRecoveryFabricName,
                        a2aRecoveryContainerName,
                        a2aRecoveryPrimaryContainerMappingName,
                        createProtectionContainerMappingInput);
                Assert.True(
                    recoveryPrimaryContainerMapping.Name == a2aRecoveryPrimaryContainerMappingName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public void CreateA2AReplicationProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var policy = client.ReplicationPolicies.Get(a2aPolicyName);
                var recoveryContainer =
                    client.ReplicationProtectionContainers.Get(
                        a2aRecoveryFabricName,
                        a2aRecoveryContainerName);

                var a2aEnableProtectionInput = new A2AEnableProtectionInput();
                a2aEnableProtectionInput.FabricObjectId = a2aVirtualMachineToProtect;
                a2aEnableProtectionInput.RecoveryContainerId = recoveryContainer.Id;
                a2aEnableProtectionInput.RecoveryResourceGroupId = a2aRecoveryResourceGroup;
                a2aEnableProtectionInput.VmManagedDisks = new List<A2AVmManagedDiskInputDetails>();
                var a2aVmManagedDiskInputDetails = new A2AVmManagedDiskInputDetails
                {
                    DiskId = a2aVirtualMachineDiskToProtect,
                    PrimaryStagingAzureStorageAccountId = a2aStagingStorageAccount,
                    RecoveryResourceGroupId = a2aRecoveryResourceGroup,
                    RecoveryTargetDiskAccountType = "Standard_LRS",
                    RecoveryReplicaDiskAccountType = "Standard_LRS"
                };
                a2aEnableProtectionInput.VmManagedDisks.Add(a2aVmManagedDiskInputDetails);

                var enableProtectionInput = new EnableProtectionInput
                {
                    Properties = new EnableProtectionInputProperties()
                };
                enableProtectionInput.Properties.PolicyId = policy.Id;
                enableProtectionInput.Properties.ProviderSpecificDetails = a2aEnableProtectionInput;

                var replicationProtectedItem =
                    client.ReplicationProtectedItems.Create(
                        a2aPrimaryFabricName,
                        a2aPrimaryContainerName,
                        a2aReplicationProtectedItemName,
                        enableProtectionInput);
                Assert.True(
                    replicationProtectedItem.Name == a2aReplicationProtectedItemName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public void GetA2AResources()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var policy = client.ReplicationPolicies.Get(a2aPolicyName);
                Assert.True(policy.Name == a2aPolicyName, "Resource name can not be different.");

                var primaryFabric = client.ReplicationFabrics.Get(a2aPrimaryFabricName);
                Assert.True(
                    primaryFabric.Name == a2aPrimaryFabricName,
                    "Resource name can not be different.");

                var recoveryFabric = client.ReplicationFabrics.Get(a2aRecoveryFabricName);
                Assert.True(
                    recoveryFabric.Name == a2aRecoveryFabricName,
                    "Resource name can not be different.");

                var primaryContainer =
                    client.ReplicationProtectionContainers.Get(
                        a2aPrimaryFabricName,
                        a2aPrimaryContainerName);
                Assert.True(
                    primaryContainer.Name == a2aPrimaryContainerName,
                    "Resource name can not be different.");

                var recoveryContainer =
                    client.ReplicationProtectionContainers.Get(
                        a2aRecoveryFabricName,
                        a2aRecoveryContainerName);
                Assert.True(
                    recoveryContainer.Name == a2aRecoveryContainerName,
                    "Resource name can not be different.");

                var primaryRecoveryContainerMapping =
                    client.ReplicationProtectionContainerMappings.Get(
                        a2aPrimaryFabricName,
                        a2aPrimaryContainerName,
                        a2aPrimaryRecoveryContainerMappingName);
                Assert.True(
                    primaryRecoveryContainerMapping.Name == a2aPrimaryRecoveryContainerMappingName,
                    "Resource name can not be different.");

                var recoveryPrimaryContainerMapping =
                    client.ReplicationProtectionContainerMappings.Get(
                        a2aRecoveryFabricName,
                        a2aRecoveryContainerName,
                        a2aRecoveryPrimaryContainerMappingName);
                Assert.True(
                    recoveryPrimaryContainerMapping.Name == a2aRecoveryPrimaryContainerMappingName,
                    "Resource name can not be different.");

                var replicationProtectedItem =
                    client.ReplicationProtectedItems.Get(
                        a2aPrimaryFabricName,
                        a2aPrimaryContainerName,
                        a2aReplicationProtectedItemName);
                Assert.True(
                    replicationProtectedItem.Name == a2aReplicationProtectedItemName,
                    "Resource name can not be different.");
            }
        }

        [Fact]
        public void ListA2AResources()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var policies= client.ReplicationPolicies.List();
                Assert.True(policies.Count() == 1, "Only 1 policy got created via test.");

                var fabrics = client.ReplicationFabrics.List();
                Assert.True(fabrics.Count() == 2, "Only 2 fabrics got created via test.");

                var containers = client.ReplicationProtectionContainers.List();
                Assert.True(containers.Count() == 2, "Only 2 containers got created via test.");

                var containerMappings =
                    client.ReplicationProtectionContainerMappings.List();
                Assert.True(
                    containerMappings.Count() == 2,
                    "Only 2 container mappings got created via test.");

                var replicationProtectedItems = client.ReplicationProtectedItems.List();
                Assert.True(
                    replicationProtectedItems.Count() == 1,
                    "Only 1 replicationProtectedItem got created via test.");
            }
        }

        [Fact]
        public void DeleteA2AReplicationProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var disableProtectionInput = new DisableProtectionInput
                {
                    Properties = new DisableProtectionInputProperties()
                };
                disableProtectionInput.Properties.ReplicationProviderInput =
                    new DisableProtectionProviderSpecificInput();

                client.ReplicationProtectedItems.Delete(
                    a2aPrimaryFabricName,
                    a2aPrimaryContainerName,
                    a2aReplicationProtectedItemName,
                    disableProtectionInput);

                var replicationProtectedItems = client.ReplicationProtectedItems.List();
                Assert.True(
                    replicationProtectedItems.Count() == 0,
                    "Delted the replicationProtectedItem that got created via test.");
            }
        }

        [Fact]
        public void DeleteA2AContainerMappings()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var removeProtectionContainerMappingInput =
                    new RemoveProtectionContainerMappingInput
                    {
                        Properties = new RemoveProtectionContainerMappingInputProperties()
                    };
                removeProtectionContainerMappingInput.Properties.ProviderSpecificInput =
                    new ReplicationProviderContainerUnmappingInput();

                client.ReplicationProtectionContainerMappings.Delete(
                    a2aPrimaryFabricName,
                    a2aPrimaryContainerName,
                    a2aPrimaryRecoveryContainerMappingName,
                    removeProtectionContainerMappingInput);
                client.ReplicationProtectionContainerMappings.Delete(
                    a2aRecoveryFabricName,
                    a2aRecoveryContainerName,
                    a2aRecoveryPrimaryContainerMappingName,
                    removeProtectionContainerMappingInput);

                var containerMappings = client.ReplicationProtectionContainerMappings.List();
                Assert.True(
                    containerMappings.Count() == 0,
                    "Delted 2 container mappings that got created via test.");
            }
        }

        [Fact]
        public void DeleteA2AContainers()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationProtectionContainers.Delete(
                    a2aPrimaryFabricName,
                    a2aPrimaryContainerName);
                client.ReplicationProtectionContainers.Delete(
                    a2aRecoveryFabricName,
                    a2aRecoveryContainerName);

                var containers = client.ReplicationProtectionContainers.List();
                Assert.True(
                    containers.Count() == 0,
                    "Delted 2 containers that got created via test.");
            }
        }

        [Fact]
        public void DeleteA2AFabrics()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationFabrics.Delete(a2aPrimaryFabricName);
                client.ReplicationFabrics.Delete(a2aRecoveryFabricName);

                var fabrics = client.ReplicationFabrics.List();
                Assert.True(fabrics.Count() == 0, "Delted 2 fabrics that got created via test.");
            }
        }

        [Fact]
        public void DeleteA2APolicy()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationPolicies.Delete(a2aPolicyName);

                var policies = client.ReplicationPolicies.List();
                Assert.True(policies.Count() == 0, "Delted the policy that got created via test.");
            }
        }

        [Fact]
        public void CreateSite()
        {
            using (var context = MockContext.Start(this.GetType()))
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
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                Assert.NotNull(fabric.Id);
            }
        }

        [Fact]
        public void ListSite()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabricList = client.ReplicationFabrics.List();
                Assert.True(fabricList.Count() > 0, "Atleast one fabric should be present");
            }
        }

        [Fact]
        public void DeleteSite()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationFabrics.Delete(siteName);
            }
        }

        [Fact]
        public void PurgeSite()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationFabrics.Purge(siteName);
            }
        }

        [Fact]
        public void CheckConsistency()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationFabrics.CheckConsistency(siteName);
                var fabric = client.ReplicationFabrics.Get(siteName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        [Trait("ReRecord", "CR Changes")]
        public void RenewCertificate()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                RenewCertificateInputProperties inputProperties = new RenewCertificateInputProperties()
                {
                    RenewCertificateType = "Cloud"
                };

                RenewCertificateInput input = new RenewCertificateInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationFabrics.RenewCertificate(siteName, input);
                var fabric = client.ReplicationFabrics.Get(siteName);
            }
        }

        [Fact]
        public void GetRSP()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var recoveryServivesProviderResponse =
                    client.ReplicationRecoveryServicesProviders.Get(fabric.Name, providerName);

                Assert.NotNull(recoveryServivesProviderResponse.Properties.FriendlyName);
                Assert.NotNull(recoveryServivesProviderResponse.Name);
                Assert.NotNull(recoveryServivesProviderResponse.Id);
            }
        }

        [Fact]
        public void ListRspByFabric()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var rspList = client.ReplicationRecoveryServicesProviders.ListByReplicationFabrics(fabric.Name);

                Assert.True(rspList.Count() > 0, "Atleast one replication recovery services provider should be present");
            }
        }

        [Fact]
        public void ListRsp()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var rspList = client.ReplicationRecoveryServicesProviders.List();

                Assert.True(rspList.Count() > 0, "Atleast one replication recovery services provider should be present");
            }
        }

        [Fact]
        public void DeleteRsp()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                client.ReplicationRecoveryServicesProviders.Delete(fabric.Name, providerName);
            }
        }

        [Fact]
        public void PurgeRsp()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                string rspName = "74ef040f-fa15-4f71-9652-c27d5d19d575";
                var fabric = client.ReplicationFabrics.Get(siteName);
                client.ReplicationRecoveryServicesProviders.Purge(fabric.Name, rspName);
            }
        }

        [Fact]
        public void RefreshRsp()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                client.ReplicationRecoveryServicesProviders.RefreshProvider(fabric.Name, providerName);
                var rsp = client.ReplicationRecoveryServicesProviders.Get(fabric.Name, providerName);
                Assert.NotNull(rsp.Id);
            }
        }

        [Fact]
        public void GetContainer()
        {
            using (var context = MockContext.Start(this.GetType()))
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
            using (var context = MockContext.Start(this.GetType()))
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
        public void ListAllContainers()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabricResponse = client.ReplicationFabrics.Get(siteName);

                var protectionContainerList = 
                    client.ReplicationProtectionContainers.List().ToList();

                Assert.True(protectionContainerList.Count > 0, "Atleast one container should be present.");
            }
        }

        [Fact]
        public void CreatePolicy()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                HyperVReplicaAzurePolicyInput h2ASpecificInput = new HyperVReplicaAzurePolicyInput()
                {
                    RecoveryPointHistoryDuration = 4,
                    ApplicationConsistentSnapshotFrequencyInHours = 2,
                    ReplicationInterval = 300,
                    OnlineReplicationStartTime = null,
                    StorageAccounts = new List<string>() { storageAccountId }
                };

                CreatePolicyInputProperties inputProperties = new CreatePolicyInputProperties()
                {
                    ProviderSpecificInput = h2ASpecificInput
                };

                CreatePolicyInput input = new CreatePolicyInput()
                {
                    Properties = inputProperties
                };

                var response = client.ReplicationPolicies.Create(policyName, input);

                var policy = client.ReplicationPolicies.Get(policyName);
            }
        }

        [Fact]
        public void GetPolicy()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var policy = client.ReplicationPolicies.Get(policyName);
                Assert.NotNull(policy.Id);
                Assert.NotNull(policy.Name);
            }
        }

        [Fact]
        public void ListPolicy()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var policyList = client.ReplicationPolicies.List();
            }
        }

        [Fact]
        public void UpdatePolicy()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                HyperVReplicaAzurePolicyInput h2ASpecificInput = new HyperVReplicaAzurePolicyInput()
                {
                    RecoveryPointHistoryDuration = 3,
                    ApplicationConsistentSnapshotFrequencyInHours = 2,
                    ReplicationInterval = 300,
                    OnlineReplicationStartTime = null,
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
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;
                client.ReplicationPolicies.Delete(policyName);
            }
        }

        [Fact]
        public void CreatePCMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
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
            using (var context = MockContext.Start(this.GetType()))
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
        public void EnumeratePCMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabric.Name).FirstOrDefault();

                var protectionContainerMapping = client.ReplicationProtectionContainerMappings.ListByReplicationProtectionContainers(fabric.Name, protectionContainer.Name);
            }
        }

        [Fact]
        public void ListAllPCMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainerMapping = client.ReplicationProtectionContainerMappings.List();
            }
        }

        [Fact]
        public void DeletePCMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
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
        public void PurgePCMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabric.Name).FirstOrDefault();

                client.ReplicationProtectionContainerMappings.Purge(fabric.Name, protectionContainer.Name, protectionContainerMappingName);
            }
        }

        [Fact]
        public void GetProtectableItem()
        {
            using (var context = MockContext.Start(this.GetType()))
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
            using (var context = MockContext.Start(this.GetType()))
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

        [Fact]
        public void CreateProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var policy = client.ReplicationPolicies.Get(policyName);
                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(fabric.Name).FirstOrDefault();

                var protectableItemList = client.ReplicationProtectableItems.ListByReplicationProtectionContainers(
                    fabric.Name, protectionContainer.Name).ToList();
                var protectableItem = protectableItemList.First(item =>
                item.Properties.FriendlyName.Equals(vmName2, StringComparison.OrdinalIgnoreCase));

                var vhdId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetails[0].VhdId;
                DiskDetails osDisk = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetails
                            .FirstOrDefault(item => item.VhdType == "OperatingSystem");
                if (osDisk != null)
                {
                    vhdId = osDisk.VhdId;
                }

                HyperVReplicaAzureEnableProtectionInput h2AEnableDRInput =
                    new HyperVReplicaAzureEnableProtectionInput()
                    {
                        HvHostVmId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).SourceItemId,
                        OsType = "Windows",
                        VhdId = vhdId,
                        VmName = protectableItem.Properties.FriendlyName,
                        TargetStorageAccountId = (policy.Properties.ProviderSpecificDetails as HyperVReplicaAzurePolicyDetails)
                            .ActiveStorageAccountId,
                        TargetAzureV2ResourceGroupId = targetResourceGroup,
                        TargetAzureVmName = protectableItem.Properties.FriendlyName
                    };

                EnableProtectionInputProperties enableDRInputProperties = new EnableProtectionInputProperties()
                {
                    PolicyId = policy.Id,
                    ProtectableItemId = protectableItem.Id,
                    ProviderSpecificDetails = h2AEnableDRInput
                };

                EnableProtectionInput enableDRInput = new EnableProtectionInput()
                {
                    Properties = enableDRInputProperties
                };

                client.ReplicationProtectedItems.Create(fabric.Name, protectionContainer.Name, protectableItem.Properties.FriendlyName, enableDRInput);
                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);
            }
        }

        [Fact]
        public void GetProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainerList =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).ToList();
                var protectionContainer = client.ReplicationProtectionContainers.Get(siteName,
                    protectionContainerList.FirstOrDefault().Name);

                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName);
                Assert.NotNull(protectedItem.Id);
            }
        }

        [Fact]
        public void EnumerateProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                var protectedItemsList = client.ReplicationProtectedItems.ListByReplicationProtectionContainers(siteName, protectionContainer.Name);
                Assert.NotNull(protectedItemsList);
            }
        }

        [Fact]
        public void ListAllProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectedItemsList = client.ReplicationProtectedItems.List();
                Assert.NotNull(protectedItemsList);
            }
        }

        [Fact]
        public void UpdateProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();
                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);

                VMNicInputDetails nicInput = new VMNicInputDetails()
                {
                    NicId = (protectedItem.Properties.ProviderSpecificDetails as HyperVReplicaAzureReplicationDetails).VmNics[0].NicId,
                    RecoveryVMSubnetName = "Subnet1",
                    SelectionType = "SelectedByUser"
                };

                UpdateReplicationProtectedItemInputProperties updateInputProperties = new UpdateReplicationProtectedItemInputProperties()
                {
                    RecoveryAzureVMName = protectedItem.Properties.FriendlyName,
                    RecoveryAzureVMSize = "Basic_A0",
                    SelectedRecoveryAzureNetworkId = azureNetworkId,
                    VmNics = new List<VMNicInputDetails>() { nicInput },
                    LicenseType = LicenseType.WindowsServer,
                    ProviderSpecificDetails = new HyperVReplicaAzureUpdateReplicationProtectedItemInput()
                    {
                        RecoveryAzureV2ResourceGroupId = targetResourceGroup
                    }
                };

                UpdateReplicationProtectedItemInput updateInput = new UpdateReplicationProtectedItemInput()
                {
                    Properties = updateInputProperties
                };

                var response = client.ReplicationProtectedItems.Update(siteName, protectionContainer.Name, vmName2, updateInput);

                var updatedProtecteditem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);
            }
        }

        [Fact]
        public void DeleteProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                DisableProtectionInputProperties inputProperties = new DisableProtectionInputProperties()
                {
                    DisableProtectionReason = DisableProtectionReason.NotSpecified,
                    ReplicationProviderInput = new DisableProtectionProviderSpecificInput()
                };

                DisableProtectionInput input = new DisableProtectionInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationProtectedItems.Delete(siteName, protectionContainer.Name, vmName2, input);
            }
        }

        [Fact]
        public void PurgeProtectedItem()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                client.ReplicationProtectedItems.Purge(siteName, protectionContainer.Name, vmName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void RepairReplication()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                client.ReplicationProtectedItems.RepairReplication(siteName, protectionContainer.Name, vmName2);

                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);
                Assert.NotNull(protectedItem.Id);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void TestFailover()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();
                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName);

                string networkId = (protectedItem.Properties.ProviderSpecificDetails as HyperVReplicaAzureReplicationDetails)
                        .SelectedRecoveryAzureNetworkId;
                HyperVReplicaAzureFailoverProviderInput h2AFOInput = new HyperVReplicaAzureFailoverProviderInput()
                {
                    VaultLocation = "West US",
                };

                TestFailoverInputProperties tfoInputProperties = new TestFailoverInputProperties()
                {
                    NetworkId = networkId,
                    NetworkType = string.IsNullOrEmpty(networkId) ? null : "VmNetworkAsInput",
                    SkipTestFailoverCleanup = true.ToString(),
                    ProviderSpecificDetails = h2AFOInput
                };

                TestFailoverInput tfoInput = new TestFailoverInput()
                {
                    Properties = tfoInputProperties
                };

                var response = client.ReplicationProtectedItems.TestFailover(siteName, protectionContainer.Name, vmName, tfoInput);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void TestFailoverCleanup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();
                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName);

                TestFailoverCleanupInputProperties inputProperties = new TestFailoverCleanupInputProperties()
                {
                    Comments = "Cleaning up"
                };

                TestFailoverCleanupInput input = new TestFailoverCleanupInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationProtectedItems.TestFailoverCleanup(
                    siteName, protectionContainer.Name, vmName, input);
            }
        }

        [Fact]
        public void PlannedFailover()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);

                PlannedFailoverInputProperties inputProperties = new PlannedFailoverInputProperties();
                if (protectedItem.Properties.ActiveLocation == "Recovery")
                {
                    HyperVReplicaAzureFailbackProviderInput h2AFailbackInput = new HyperVReplicaAzureFailbackProviderInput()
                    {
                        RecoveryVmCreationOption = "NoAction",
                        DataSyncOption = "ForSynchronization"
                    };

                    inputProperties.ProviderSpecificDetails = h2AFailbackInput;
                }
                else
                {
                    HyperVReplicaAzureFailoverProviderInput h2AFailoverInput = new HyperVReplicaAzureFailoverProviderInput()
                    {
                        VaultLocation = "West US"
                    };

                    inputProperties.ProviderSpecificDetails = h2AFailoverInput;
                }

                PlannedFailoverInput input = new PlannedFailoverInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationProtectedItems.PlannedFailover(siteName, protectionContainer.Name, vmName2, input);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void UnplannedFailover()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);

                HyperVReplicaAzureFailoverProviderInput h2AFailoverInput = new HyperVReplicaAzureFailoverProviderInput()
                {
                    VaultLocation = "West US"
                };

                UnplannedFailoverInputProperties inputProperties = new UnplannedFailoverInputProperties()
                {
                    FailoverDirection = "PrimaryToRecovery",
                    SourceSiteOperations = "NotRequired",
                    ProviderSpecificDetails = h2AFailoverInput
                };

                UnplannedFailoverInput input = new UnplannedFailoverInput()
                {
                    Properties = inputProperties
                };

                var response = client.ReplicationProtectedItems.UnplannedFailover(siteName, protectionContainer.Name, vmName2, input);

                var updatedProtectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);
            }
        }

        [Fact]
        public void CommitFailover()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                client.ReplicationProtectedItems.FailoverCommit(siteName, protectionContainer.Name, vmName2);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void Reprotect()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                var protectableItem = client.ReplicationProtectableItems.ListByReplicationProtectionContainers(
                    siteName, protectionContainer.Name).FirstOrDefault(item =>
                        item.Properties.FriendlyName.Equals(vmName2, StringComparison.OrdinalIgnoreCase));
                var protectedItem = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);

                var vhdId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetails[0].VhdId;
                DiskDetails osDisk = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).DiskDetails
                            .FirstOrDefault(item => item.VhdType == "OperatingSystem");
                if (osDisk != null)
                {
                    vhdId = osDisk.VhdId;
                }

                HyperVReplicaAzureReprotectInput h2AInput = new HyperVReplicaAzureReprotectInput()
                {
                    HvHostVmId = (protectableItem.Properties.CustomDetails as HyperVVirtualMachineDetails).SourceItemId,
                    OsType = "Windows",
                    VHDId = vhdId,
                    VmName = protectableItem.Properties.FriendlyName,
                    StorageAccountId = (protectedItem.Properties.ProviderSpecificDetails as HyperVReplicaAzureReplicationDetails).RecoveryAzureStorageAccount
                };

                ReverseReplicationInputProperties inputProperties = new ReverseReplicationInputProperties()
                {
                    FailoverDirection = "PrimaryToRecovery",
                    ProviderSpecificDetails = h2AInput
                };

                ReverseReplicationInput input = new ReverseReplicationInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationProtectedItems.Reprotect(siteName, protectionContainer.Name, vmName2, input);
            }
        }

        [Fact]
        public void GetRecoveryPoints()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                var rps = client.RecoveryPoints.ListByReplicationProtectedItems(siteName, protectionContainer.Name, vmName2).ToList();
                var recoveryPoint = client.RecoveryPoints.Get(siteName, protectionContainer.Name, vmName2, rps[rps.Count() / 2].Name);
            }
        }

        [Fact]
        public void ListRecoveryPoints()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                var rps = client.RecoveryPoints.ListByReplicationProtectedItems(siteName, protectionContainer.Name, vmName);
            }
        }

        [Fact]
        public void ApplyRecoveryPoint()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var protectionContainer =
                    client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();

                var rps = client.RecoveryPoints.ListByReplicationProtectedItems(siteName, protectionContainer.Name, vmName2).ToList();
                HyperVReplicaAzureApplyRecoveryPointInput h2APitInput = new HyperVReplicaAzureApplyRecoveryPointInput()
                {
                    VaultLocation = "West US"
                };

                ApplyRecoveryPointInputProperties inputProperties = new ApplyRecoveryPointInputProperties()
                {
                    RecoveryPointId = rps[rps.Count()/2].Id,
                    ProviderSpecificDetails = h2APitInput
                };

                ApplyRecoveryPointInput input = new ApplyRecoveryPointInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationProtectedItems.ApplyRecoveryPoint(siteName, protectionContainer.Name, vmName2, input);
            }
        }

        [Fact]
        public void CreateRecoveryPlan()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainer = client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();
                var protectedItem1 = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName);

                RecoveryPlanProtectedItem rpVm1 = new RecoveryPlanProtectedItem()
                {
                    Id = protectedItem1.Id,
                    VirtualMachineId = protectedItem1.Name
                };

                RecoveryPlanGroup rpGroup = new RecoveryPlanGroup()
                {
                    GroupType = RecoveryPlanGroupType.Boot,
                    ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>() { rpVm1},
                    StartGroupActions = new List<RecoveryPlanAction>(),
                    EndGroupActions = new List<RecoveryPlanAction>()
                };

                CreateRecoveryPlanInputProperties inputProperties = new CreateRecoveryPlanInputProperties()
                {
                    PrimaryFabricId = fabric.Id,
                    RecoveryFabricId = recoveryCloud,
                    FailoverDeploymentModel = FailoverDeploymentModel.ResourceManager,
                    Groups = new List<RecoveryPlanGroup>() { rpGroup }
                };

                CreateRecoveryPlanInput input = new CreateRecoveryPlanInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationRecoveryPlans.Create(rpName, input);

                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact]
        public void GetRecoveryPlan()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact]
        public void UpdateRecoveryPlan()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var fabric = client.ReplicationFabrics.Get(siteName);
                var protectionContainer = client.ReplicationProtectionContainers.ListByReplicationFabrics(siteName).FirstOrDefault();
                var protectedItem2 = client.ReplicationProtectedItems.Get(siteName, protectionContainer.Name, vmName2);

                RecoveryPlanProtectedItem rpVm2 = new RecoveryPlanProtectedItem()
                {
                    Id = protectedItem2.Id,
                    VirtualMachineId = protectedItem2.Name
                };

                RecoveryPlanGroup rpGroup = new RecoveryPlanGroup()
                {
                    GroupType = RecoveryPlanGroupType.Boot,
                    ReplicationProtectedItems = new List<RecoveryPlanProtectedItem>() { rpVm2 },
                    StartGroupActions = new List<RecoveryPlanAction>(),
                    EndGroupActions = new List<RecoveryPlanAction>()
                };

                UpdateRecoveryPlanInputProperties inputProperties = new UpdateRecoveryPlanInputProperties()
                {
                    Groups = new List<RecoveryPlanGroup>() { rpGroup }
                };

                UpdateRecoveryPlanInput input = new UpdateRecoveryPlanInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationRecoveryPlans.Update(rpName, input);

                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact]
        public void DeleteRecoveryPlan()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationRecoveryPlans.Delete(rpName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void RPTestFailover()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                RecoveryPlanHyperVReplicaAzureFailoverInput h2AInput = new RecoveryPlanHyperVReplicaAzureFailoverInput()
                {
                    VaultLocation = "West US"
                };

                RecoveryPlanTestFailoverInputProperties inputProperties = new RecoveryPlanTestFailoverInputProperties()
                {
                    NetworkId = azureNetworkId,
                    NetworkType = string.IsNullOrEmpty(azureNetworkId) ? null : "VmNetworkAsInput",
                    SkipTestFailoverCleanup = true.ToString(),
                    ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>() { h2AInput }
                };

                RecoveryPlanTestFailoverInput input = new RecoveryPlanTestFailoverInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationRecoveryPlans.TestFailover(rpName, input);

                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void RPTestFailoverCleanup()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                RecoveryPlanTestFailoverCleanupInputProperties inputProperties = new RecoveryPlanTestFailoverCleanupInputProperties()
                {
                    Comments = "Cleaning up"
                };

                RecoveryPlanTestFailoverCleanupInput input = new RecoveryPlanTestFailoverCleanupInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationRecoveryPlans.TestFailoverCleanup(rpName, input);
                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void RPPlannedFailover()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                RecoveryPlanHyperVReplicaAzureFailoverInput h2AInput = new RecoveryPlanHyperVReplicaAzureFailoverInput()
                {
                    VaultLocation = "West US"
                };

                RecoveryPlanPlannedFailoverInputProperties inputProperties = new RecoveryPlanPlannedFailoverInputProperties()
                {
                    FailoverDirection = PossibleOperationsDirections.PrimaryToRecovery,
                    ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>() { h2AInput }
                };

                RecoveryPlanPlannedFailoverInput input = new RecoveryPlanPlannedFailoverInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationRecoveryPlans.PlannedFailover(rpName, input);
                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void RPUnplannedFailover()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                RecoveryPlanHyperVReplicaAzureFailoverInput h2AInput = new RecoveryPlanHyperVReplicaAzureFailoverInput()
                {
                    VaultLocation = "West US"
                };

                RecoveryPlanUnplannedFailoverInputProperties inputProperties = new RecoveryPlanUnplannedFailoverInputProperties()
                {
                    FailoverDirection = PossibleOperationsDirections.PrimaryToRecovery,
                    SourceSiteOperations = SourceSiteOperations.NotRequired,
                    ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>() { h2AInput }
                };

                RecoveryPlanUnplannedFailoverInput input = new RecoveryPlanUnplannedFailoverInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationRecoveryPlans.UnplannedFailover(rpName, input);
                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void RPFailoverCommit()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationRecoveryPlans.FailoverCommit(rpName);
                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void RPFailback()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                RecoveryPlanHyperVReplicaAzureFailbackInput h2AInput = new RecoveryPlanHyperVReplicaAzureFailbackInput()
                {
                    DataSyncOption = DataSyncStatus.ForSynchronization,
                    RecoveryVmCreationOption = AlternateLocationRecoveryOption.NoAction
                };

                RecoveryPlanPlannedFailoverInputProperties inputProperties = new RecoveryPlanPlannedFailoverInputProperties()
                {
                    FailoverDirection = PossibleOperationsDirections.RecoveryToPrimary,
                    ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>() { h2AInput }
                };

                RecoveryPlanPlannedFailoverInput input = new RecoveryPlanPlannedFailoverInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationRecoveryPlans.PlannedFailover(rpName, input);
                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void RPReprotect()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationRecoveryPlans.Reprotect(rpName);

                var rp = client.ReplicationRecoveryPlans.Get(rpName);
            }
        }

        [Fact]
        public void CreateAlertSettings()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                ConfigureAlertRequestProperties properties = new ConfigureAlertRequestProperties()
                {
                    SendToOwners = false.ToString(),
                    CustomEmailAddresses = new List<string>() { emailAddress },
                    Locale = "en-US"
                };

                ConfigureAlertRequest request = new ConfigureAlertRequest()
                {
                    Properties = properties
                };

                client.ReplicationAlertSettings.Create(alertSettingName, request);
                var alertSetting = client.ReplicationAlertSettings.Get(alertSettingName);
            }
        }

        [Fact]
        public void GetAlertSettings()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var alertSetting = client.ReplicationAlertSettings.Get(alertSettingName);
            }
        }

        [Fact]
        public void ListAlertSettings()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var alertSetting = client.ReplicationAlertSettings.List();
            }
        }

        [Fact]
        public void GetReplicationEvent()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var events = client.ReplicationEvents.List().ToList();
                var replicationEvent = client.ReplicationEvents.Get(events[0].Name);
            }
        }

        [Fact]
        public void ListReplicationEvent()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var events = client.ReplicationEvents.List();
            }
        }

        [Fact]
        public void GetNetworks()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var network = client.ReplicationNetworks.Get(vmmFabric, vmNetworkName);
            }
        }

        [Fact]
        public void ListNetworks()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var networkList = client.ReplicationNetworks.List();
            }
        }

        [Fact]
        public void EnumerateNetworks()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var networkList = client.ReplicationNetworks.ListByReplicationFabrics(vmmFabric);
            }
        }

        [Fact]
        public void CreateNetworkMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var network = client.ReplicationNetworks.Get(vmmFabric, vmNetworkName);

                CreateNetworkMappingInputProperties inputProperties = new CreateNetworkMappingInputProperties()
                {
                    RecoveryFabricName = recoveryCloud,
                    RecoveryNetworkId = azureNetworkId,
                    FabricSpecificDetails = new VmmToAzureCreateNetworkMappingInput()
                };

                CreateNetworkMappingInput input = new CreateNetworkMappingInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationNetworkMappings.Create(vmmFabric, vmNetworkName, networkMappingName, input);
                var networkMapping = client.ReplicationNetworkMappings.Get(vmmFabric, vmNetworkName, networkMappingName);
            }
        }

        [Fact]
        public void GetNetworkMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var networkMapping = client.ReplicationNetworkMappings.Get(vmmFabric, vmNetworkName, networkMappingName);
            }
        }

        [Fact]
        public void ListNetworkMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var networkMappingList = client.ReplicationNetworkMappings.List();
            }
        }

        [Fact]
        public void EnumerateNetworkMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                var networkMappingList = client.ReplicationNetworkMappings.ListByReplicationNetworks(vmmFabric, vmNetworkName);
            }
        }

        [Fact]
        public void UpdateNetworkMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                UpdateNetworkMappingInputProperties inputProperties = new UpdateNetworkMappingInputProperties()
                {
                    RecoveryFabricName = recoveryCloud,
                    RecoveryNetworkId = azureNetworkId,
                    FabricSpecificDetails = new VmmToAzureUpdateNetworkMappingInput()
                };

                UpdateNetworkMappingInput input = new UpdateNetworkMappingInput()
                {
                    Properties = inputProperties
                };

                client.ReplicationNetworkMappings.Update(vmmFabric, vmNetworkName, networkMappingName, input);
                var networkMapping = client.ReplicationNetworkMappings.Get(vmmFabric, vmNetworkName, networkMappingName);
            }
        }

        [Fact]
        public void DeleteNetworkMapping()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context);
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationNetworkMappings.Delete(vmmFabric, vmNetworkName, networkMappingName);
            }
        }
        
       
        [Fact]
        public void MigrateToAad()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context, "canaryexproute", "IbizaV2ATest");
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationFabrics.MigrateToAad("38de67c62c2b231fb647b060df06a8a69da7e305c44db6646693b7470d709c87");
            }
        }

        [Fact]
        public void ListEventByQuery()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context, "canaryexproute", "IbizaV2ATest");
                var client = testHelper.SiteRecoveryClient;

                var querydata = new ODataQuery<EventQueryParameter>("Severity  eq 'Critical'");
                client.ReplicationEvents.List(querydata);
            }
        }

        [Fact]
        public void GetHealthDetails()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                testHelper.Initialize(context, "canaryexproute", "IbizaV2ATest");
                var client = testHelper.SiteRecoveryClient;

                client.ReplicationVaultHealth.Get();
            }
        }
    }
}
