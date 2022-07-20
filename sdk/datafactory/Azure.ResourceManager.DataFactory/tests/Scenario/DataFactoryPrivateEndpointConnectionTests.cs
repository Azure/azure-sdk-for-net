// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.DataFactory.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class DataFactoryPrivateEndpointConnectionTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        public DataFactoryPrivateEndpointConnectionTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = SessionRecording.GenerateAssetName("DataFactory-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            var dataFactoryLro = await CreateDataFactory(rgLro.Value, dataFactoryName);
            _dataFactoryIdentifier = dataFactoryLro.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _dataFactory = await Client.GetDataFactoryResource(_dataFactoryIdentifier).GetAsync();
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to reference additional mgmt package, ignore it for now")]
        public async Task CreateOrUpdate()
        {
            string connectionName = Recording.GenerateAssetName("connection-");
            connectionName = "datafactory-0000.7f9d436d-11ad-4077-b91e-89d26e2f160c";
            DataFactoryPrivateEndpointConnectionCreateOrUpdateContent data = new DataFactoryPrivateEndpointConnectionCreateOrUpdateContent()
            {
                Properties = new PrivateLinkConnectionApprovalRequest()
                {
                    PrivateEndpointId = new ResourceIdentifier("/subscriptions/***/resourceGroups/***/providers/Microsoft.Network/privateEndpoints/***"),
                    PrivateLinkServiceConnectionState = new PrivateLinkConnectionState("Approved", "Approved by admin.",""),
                }
            };
            var connection = await _dataFactory.GetDataFactoryPrivateEndpointConnections().CreateOrUpdateAsync(WaitUntil.Completed, connectionName, data);
            Assert.IsNotNull(connection);
        }

        [Test]
        [RecordedTest]
        [Ignore("Need to reference additional mgmt package, ignore it for now")]
        public async Task Get()
        {
            var connection = await _dataFactory.GetDataFactoryPrivateEndpointConnections().GetAsync("datafactory-0000.7f9d436d-11ad-4077-b91e-89d26e2f160c");
            Assert.IsNull(connection);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _dataFactory.GetDataFactoryPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
