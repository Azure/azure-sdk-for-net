// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedInstancePrivateEndpointConnectionTest : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstancePrivateEndpointConnectionTest(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [Ignore("Playback execution timeout")]
        [RecordedTest]
        public async Task ManagedInstancePrivateEndpointConnectioApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            var collection = managedInstance.GetManagedInstancePrivateEndpointConnections();

            // Create Private endpoint
            await CreateDefaultPrivateEndpoint(managedInstance, AzureLocation.WestUS2, _resourceGroup);

            // 1.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            string privateEndpointName = list.FirstOrDefault().Data.Name;

            // 2.CheckIfExist
            Assert.IsTrue(collection.Exists(privateEndpointName));

            // 3.Get
            var getprivateEndpoint= await collection.GetAsync(privateEndpointName);
            Assert.IsNotNull(getprivateEndpoint.Value.Data);

            // 4.GetAll
            Assert.IsTrue(await collection.ExistsAsync(privateEndpointName));
        }
    }
}
