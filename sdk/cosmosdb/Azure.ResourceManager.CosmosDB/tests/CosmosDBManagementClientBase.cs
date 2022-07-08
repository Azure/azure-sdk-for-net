// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
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
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName($"dbaccount-"),
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
            JsonPathSanitizers.Add("$..primaryMasterKey");
            JsonPathSanitizers.Add("$..primaryReadonlyMasterKey");
            JsonPathSanitizers.Add("$..secondaryMasterKey");
            JsonPathSanitizers.Add("$..secondaryReadonlyMasterKey");
        }

        protected async Task<CosmosDBAccountResource> CreateDatabaseAccount(string name, CosmosDBAccountKind kind)
        {
            return await CreateDatabaseAccount(name, kind, null);
        }

        protected async Task<CosmosDBAccountResource> CreateDatabaseAccount(string name, CosmosDBAccountKind kind, CosmosDBAccountCapability capability)
        {
            var locations = new List<CosmosDBAccountLocation>()
            {
                new CosmosDBAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var createParameters = new CosmosDBAccountCreateOrUpdateContent(AzureLocation.WestUS2, locations)
            {
                Kind = kind,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds),
                IPRules = { new CosmosDBIPAddressOrRange("23.43.230.120") },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                ConnectorOffer = ConnectorOffer.Small,
                DisableKeyBasedMetadataWriteAccess = false,
            };
            if (capability != null)
            {
                createParameters.Capabilities.Add(capability);
            }
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

        protected static void AssertAutoscale(ThroughputSettingsData throughput)
        {
            Assert.NotNull(throughput.Resource.AutoscaleSettings);
            Assert.That(throughput.Resource.AutoscaleSettings.MaxThroughput, Is.GreaterThan(0));
        }

        protected static void AssertManualThroughput(ThroughputSettingsData throughput)
        {
            Assert.That(throughput.Resource.Throughput, Is.GreaterThan(0));
            Assert.IsNull(throughput.Resource.AutoscaleSettings);
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
