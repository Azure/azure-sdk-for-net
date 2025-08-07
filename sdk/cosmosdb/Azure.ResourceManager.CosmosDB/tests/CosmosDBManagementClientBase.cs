// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public abstract class CosmosDBManagementClientBase : ManagementRecordedTestBase<CosmosDBManagementTestEnvironment>
    {
        protected const int MaxStalenessPrefix = 300;
        protected const int MaxIntervalInSeconds = 1000;
        protected const int TestThroughput1 = 700;
        protected const int TestThroughput2 = 1000;
        protected const int DefaultMaxThroughput = 4000;

        protected ResourceIdentifier _resourceGroupIdentifier;
        protected ResourceGroupResource _resourceGroup;
        protected string _databaseAccountName;
        protected CosmosDBAccountCollection DatabaseAccountCollection { get => _resourceGroup.GetCosmosDBAccounts(); }
        public string SubscriptionId { get; set; }
        public ArmClient ArmClient { get; set; }

        [OneTimeSetUp]
        protected async Task CommonGlobalSetup()
        {
            SubscriptionResource sr = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await sr.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Started,
                CosmosDBTestUtilities.GenerateResourceGroupName(SessionRecording),
                new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
        }

        [SetUp]
        protected void InitializeClient()
        {
            ArmClient = GetArmClient();
        }

        protected CosmosDBManagementClientBase(bool isAsync, RecordedTestMode? mode = default)
            : base(isAsync, mode)
        {
            IgnoreNetworkDependencyVersions();
            JsonPathSanitizers.Add("$..primaryMasterKey");
            JsonPathSanitizers.Add("$..primaryReadonlyMasterKey");
            JsonPathSanitizers.Add("$..secondaryMasterKey");
            JsonPathSanitizers.Add("$..secondaryReadonlyMasterKey");
        }

        protected async Task<CosmosDBAccountResource> CreateDatabaseAccount(string name, CosmosDBAccountKind kind, bool enableContinuousModeBackup = false)
        {
            return await CreateDatabaseAccount(name, kind, null, enableContinuousModeBackup);
        }

        protected async Task<CosmosDBAccountResource> CreateDatabaseAccount(string name, CosmosDBAccountKind kind, List<CosmosDBAccountCapability> capabilities, bool enableContinuousModeBackup = false, bool enablePartitionMerge = false)
        {
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false, null)
            };

            var createParameters = enableContinuousModeBackup ?
                new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS2, locations)
                {
                    Kind = kind,
                    ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds,null),
                    IPRules = { new CosmosDBIPAddressOrRange("23.43.230.120",null) },
                    IsVirtualNetworkFilterEnabled = true,
                    EnableAutomaticFailover = false,
                    ConnectorOffer = ConnectorOffer.Small,
                    DisableKeyBasedMetadataWriteAccess = false,
                    BackupPolicy = new ContinuousModeBackupPolicy()
                }
                : new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS2, locations)
                {
                    Kind = kind,
                    ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds, null),
                    IPRules = { new CosmosDBIPAddressOrRange("23.43.230.120", null) },
                    IsVirtualNetworkFilterEnabled = true,
                    EnableAutomaticFailover = false,
                    ConnectorOffer = ConnectorOffer.Small,
                    DisableKeyBasedMetadataWriteAccess = false
                };

            if (capabilities != null)
            {
                capabilities.ForEach(x => createParameters.Capabilities.Add(x));
            }
            createParameters.EnablePartitionMerge = enablePartitionMerge;
            createParameters.Tags.Add("key1", "value1");
            createParameters.Tags.Add("key2", "value2");
            _databaseAccountName = name;
            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, _databaseAccountName, createParameters);
            return accountLro.Value;
        }

        internal static CosmosDBCreateUpdateConfig BuildDatabaseCreateUpdateOptions(int testThroughput1, AutoscaleSettings autoscale)
        {
            return new CosmosDBCreateUpdateConfig
            {
                Throughput = (autoscale == null ? testThroughput1 : null),
                AutoscaleSettings = autoscale,
            };
        }

        protected static void AssertAutoscale(ThroughputSettingData throughput)
        {
            Assert.NotNull(throughput.Resource.AutoscaleSettings);
            Assert.That(throughput.Resource.AutoscaleSettings.MaxThroughput, Is.GreaterThan(0));
        }

        protected static void AssertManualThroughput(ThroughputSettingData throughput)
        {
            Assert.That(throughput.Resource.Throughput, Is.GreaterThan(0));
            Assert.IsNull(throughput.Resource.AutoscaleSettings);
        }

        protected async Task<ResourceIdentifier> GetSubnetId(string vnetName, VirtualNetworkData vnet)
        {
            ResourceIdentifier subnetID;
            VirtualNetworkResource vnetResource = (await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;
            var subnetCollection = vnetResource.GetSubnets();
            subnetID = vnetResource.Data.Subnets[0].Id;
            return subnetID;
        }

        // This is used to skip the tests in Unix platform when the test records contains newline.
        protected void IgnoreTestInNonWindowsAgent()
        {
            if (Mode == RecordedTestMode.Playback && !RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.Ignore();
            }
        }
    }
}
