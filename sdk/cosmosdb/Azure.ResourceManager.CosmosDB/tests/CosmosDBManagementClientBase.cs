// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class CosmosDBManagementClientBase : ManagementRecordedTestBase<CosmosDBManagementTestEnvironment>
    {
        protected const int MaxStalenessPrefix = 300;
        protected const int MaxIntervalInSeconds = 1000;
        protected const int TestThroughput1 = 700;
        protected const int TestThroughput2 = 1000;
        protected const int DefaultMaxThroughput = 4000;

        protected ResourceIdentifier _resourceGroupIdentifier;
        protected ResourceGroup _resourceGroup;
        protected string _databaseAccountName;
        protected DatabaseAccountCollection DatabaseAccountCollection { get => _resourceGroup.GetDatabaseAccounts(); }
        public string SubscriptionId { get; set; }
        public ArmClient ArmClient { get; set; }

        [OneTimeSetUp]
        protected async Task CommonGlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName($"dbaccount-"),
                new ResourceGroupData(Resources.Models.Location.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
        }

        [SetUp]
        protected void InitializeClient()
        {
            ArmClient = GetArmClient();
        }

        protected CosmosDBManagementClientBase(bool isAsync)
            : base(isAsync)
        {
            Sanitizer = new CosmosDBManagementRecordedTestSanitizer();
        }
        protected async Task<DatabaseAccount> CreateDatabaseAccount(string name, DatabaseAccountKind kind)
        {
            return await CreateDatabaseAccount(name, kind, null);
        }

        protected async Task<DatabaseAccount> CreateDatabaseAccount(string name, DatabaseAccountKind kind, DatabaseAccountCapability capability)
        {
            var locations = new List<DatabaseAccountLocation>()
            {
                new DatabaseAccountLocation(id: null, locationName: Resources.Models.Location.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var createParameters = new DatabaseAccountCreateUpdateOptions(Resources.Models.Location.WestUS2, locations)
            {
                Kind = kind,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds),
                IpRules = { new IpAddressOrRange("23.43.230.120") },
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
            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(_databaseAccountName, createParameters);
            return accountLro.Value;
        }

        protected static CreateUpdateOptions BuildDatabaseCreateUpdateOptions(int testThroughput1, AutoscaleSettings autoscale)
        {
            return new CreateUpdateOptions
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
    }
}
