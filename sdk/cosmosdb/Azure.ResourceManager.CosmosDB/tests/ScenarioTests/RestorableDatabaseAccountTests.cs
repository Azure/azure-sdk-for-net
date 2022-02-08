// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class RestorableDatabaseAccountTests : CosmosDBManagementClientBase
    {
        private DatabaseAccount _restorableDatabaseAccount;

        public RestorableDatabaseAccountTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetup()
        {
            _resourceGroup = await ArmClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (_restorableDatabaseAccount != null)
            {
                await _restorableDatabaseAccount.DeleteAsync(true);
            }
        }

        [Test]
        [RecordedTest]
        public async Task RestorableDatabaseAccountList()
        {
            _restorableDatabaseAccount = await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"));
            var restorableAccounts = await (await ArmClient.GetDefaultSubscriptionAsync()).GetRestorableDatabaseAccountsAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
        }

        [Test]
        [RecordedTest]
        [Ignore("Not recorded")]
        public async Task RestorableDatabaseAccountListByLocation()
        {
            _restorableDatabaseAccount = await CreateRestorableDatabaseAccount(Recording.GenerateAssetName("r-database-account-"));
            CosmosDBLocation location = await (await ArmClient.GetDefaultSubscriptionAsync()).GetCosmosDBLocations().GetAsync(AzureLocation.WestUS);
            var restorableAccounts = await location.GetRestorableDatabaseAccounts().GetAllAsync().ToEnumerableAsync();
            Assert.That(restorableAccounts.Any(account => account.Data.AccountName == _restorableDatabaseAccount.Data.Name));
        }

        // TODO: more tests after fixing the code generation issue

        protected async Task<DatabaseAccount> CreateRestorableDatabaseAccount(string name)
        {
            var locations = new List<DatabaseAccountLocation>()
            {
                new DatabaseAccountLocation(id: null, locationName: AzureLocation.WestUS, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: false)
            };

            var createOptions = new DatabaseAccountCreateUpdateOptions(AzureLocation.WestUS, locations)
            {
                Kind = DatabaseAccountKind.GlobalDocumentDB,
                ConsistencyPolicy = new ConsistencyPolicy(DefaultConsistencyLevel.BoundedStaleness, MaxStalenessPrefix, MaxIntervalInSeconds),
                IpRules = { new IpAddressOrRange("23.43.231.120") },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                ConnectorOffer = ConnectorOffer.Small,
                DisableKeyBasedMetadataWriteAccess = false,
                BackupPolicy = new ContinuousModeBackupPolicy(),
            };
            _databaseAccountName = name;
            var accountLro = await DatabaseAccountCollection.CreateOrUpdateAsync(true, _databaseAccountName, createOptions);
            return accountLro.Value;
        }
    }
}
