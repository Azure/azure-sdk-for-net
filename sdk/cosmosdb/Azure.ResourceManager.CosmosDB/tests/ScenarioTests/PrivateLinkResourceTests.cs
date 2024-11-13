// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class PrivateLinkResourceTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        public PrivateLinkResourceTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBPrivateLinkResourceCollection CosmosDBPrivateLinkResourceCollection => _databaseAccount.GetCosmosDBPrivateLinkResources();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), CosmosDBAccountKind.MongoDB)).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (_databaseAccountIdentifier != null)
                {
                    await ArmClient.GetCosmosDBAccountResource(_databaseAccountIdentifier).DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _databaseAccount = await ArmClient.GetCosmosDBAccountResource(_databaseAccountIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task PrivateLinkResourceListAndGet()
        {
            var privateLinkResources = await CosmosDBPrivateLinkResourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(privateLinkResources);

            var privateLinkResource = await CosmosDBPrivateLinkResourceCollection.GetAsync(privateLinkResources[0].Data.Name);

            VerifyPrivateLinkResources(privateLinkResources[0], privateLinkResource);
        }

        private void VerifyPrivateLinkResources(CosmosDBPrivateLinkResource expectedValue, CosmosDBPrivateLinkResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.RequiredMembers, actualValue.Data.RequiredMembers);
            Assert.AreEqual(expectedValue.Data.RequiredZoneNames, actualValue.Data.RequiredZoneNames);
        }
    }
}
