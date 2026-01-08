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
    public class CosmosDBServiceTests : CosmosDBManagementClientBase
    {
        private ResourceIdentifier _databaseAccountIdentifier;
        private CosmosDBAccountResource _databaseAccount;

        private string _serviceName;

        public CosmosDBServiceTests(bool isAsync) : base(isAsync)
        {
        }

        protected CosmosDBServiceCollection CosmosDBServiceCollection => _databaseAccount.GetCosmosDBServices();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _resourceGroup = await GlobalClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();

            _databaseAccountIdentifier = (await CreateDatabaseAccount(
                CosmosDBTestUtilities.GenerateDatabaseAccountName(SessionRecording),
                CosmosDBAccountKind.GlobalDocumentDB,
                null)).Id;

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

        [TearDown]
        public async Task TearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (await CosmosDBServiceCollection.ExistsAsync(_serviceName))
                {
                    var id = CosmosDBServiceCollection.Id;
                    id = CosmosDBServiceResource.CreateResourceIdentifier(id.SubscriptionId, id.ResourceGroupName, id.Name, _serviceName);
                    CosmosDBServiceResource service = ArmClient.GetCosmosDBServiceResource(id);
                    await service.DeleteAsync(WaitUntil.Completed);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task CosmosDBServiceCreateAndUpdate()
        {
            var service = await CreateCosmosDBService();
            Assert.That(service.Data.Name, Is.EqualTo(_serviceName));

            bool ifExists = await CosmosDBServiceCollection.ExistsAsync(_serviceName);
            Assert.That(ifExists, Is.True);

            CosmosDBServiceResource service2 = await CosmosDBServiceCollection.GetAsync(_serviceName);
            Assert.That(service2.Data.Name, Is.EqualTo(_serviceName));

            VerifyCosmosDBService(service, service2);
        }

        [Test]
        [RecordedTest]
        public async Task CosmosDBServiceDelete()
        {
            var service = await CreateCosmosDBService();
            bool exists = await CosmosDBServiceCollection.ExistsAsync(_serviceName);
            Assert.That(exists, Is.True);
            await service.DeleteAsync(WaitUntil.Completed);

            exists = await CosmosDBServiceCollection.ExistsAsync(_serviceName);
            Assert.That(exists, Is.False);
        }

        internal async Task<CosmosDBServiceResource> CreateCosmosDBService()
        {
            _serviceName = CosmosDBServiceType.SqlDedicatedGateway.ToString();
            var properties = new SqlDedicatedGatewayServiceResourceCreateUpdateProperties()
            {
                InstanceSize = CosmosDBServiceSize.CosmosD4S,
                InstanceCount = 1,
                DedicatedGatewayType = DedicatedGatewayType.IntegratedCache
            };

            var content = new CosmosDBServiceCreateOrUpdateContent()
            {
                Properties = properties
            };

            return (await CosmosDBServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, _serviceName, content)).Value;
        }

        private void VerifyCosmosDBService(CosmosDBServiceResource expectedValue, CosmosDBServiceResource actualValue)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actualValue.Id, Is.EqualTo(expectedValue.Id));
                Assert.That(actualValue.Data.Name, Is.EqualTo(expectedValue.Data.Name));
                Assert.That(actualValue.Data.ResourceType, Is.EqualTo(expectedValue.Data.ResourceType));

                Assert.That(actualValue.Data.Properties.InstanceCount, Is.EqualTo(expectedValue.Data.Properties.InstanceCount));

                Assert.That(actualValue.Data.Properties.InstanceSize, Is.EqualTo(expectedValue.Data.Properties.InstanceSize));
                Assert.That(actualValue.Data.Properties.ServiceType, Is.EqualTo(expectedValue.Data.Properties.ServiceType));
                Assert.That(actualValue.Data.Properties.Status, Is.EqualTo(expectedValue.Data.Properties.Status));
                Assert.That(actualValue.Data.Properties.CreatedOn, Is.EqualTo(expectedValue.Data.Properties.CreatedOn));
            });
        }
    }
}
