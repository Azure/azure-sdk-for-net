// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class PrivateLinkResourceTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private DatabaseAccount _databaseAccount;

        public PrivateLinkResourceTests(bool isAsync) : base(isAsync)
        {
        }

        protected PrivateLinkResourceCollection PrivateLinkResourceCollection { get => _databaseAccount.GetPrivateLinkResources(); }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(SessionRecording.GenerateAssetName("dbaccount-"), DatabaseAccountKind.MongoDB)).Id;
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public virtual void GlobalTeardown()
        {
            if (_databaseAccountIdentifier != null)
            {
                ArmClient.GetDatabaseAccount(_databaseAccountIdentifier).Delete();
            }
        }

        [SetUp]
        public async Task SetUp()
        {
            _databaseAccount = await ArmClient.GetDatabaseAccount(_databaseAccountIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        public async Task PrivateLinkResourceListAndGet()
        {
            var privateLinkResources = await PrivateLinkResourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(privateLinkResources);

            var privateLinkResource = await PrivateLinkResourceCollection.GetAsync(privateLinkResources[0].Data.Name);

            VerifyPrivateLinkResources(privateLinkResources[0], privateLinkResource);
        }

        private void VerifyPrivateLinkResources(PrivateLinkResource expectedValue, PrivateLinkResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Data.Name, actualValue.Data.Name);
            Assert.AreEqual(expectedValue.Data.RequiredMembers, actualValue.Data.RequiredMembers);
            Assert.AreEqual(expectedValue.Data.RequiredZoneNames, actualValue.Data.RequiredZoneNames);
        }
    }
}
