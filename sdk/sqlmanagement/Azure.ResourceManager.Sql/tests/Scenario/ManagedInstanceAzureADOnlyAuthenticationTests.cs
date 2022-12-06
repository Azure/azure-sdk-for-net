// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedInstanceAzureADOnlyAuthenticationTests : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstanceAzureADOnlyAuthenticationTests(bool isAsync)
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
        [Ignore("AAD Admin must be set before enabling/disabling AAD Only Authentication.Must be configured manually.")]
        [RecordedTest]
        public async Task ManagedInstanceAzureADOnlyAuthenticationApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string networkSecurityGroupName = Recording.GenerateAssetName("network-security-group-");
            string routeTableName = Recording.GenerateAssetName("route-table-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, networkSecurityGroupName, routeTableName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            string adoAuthName = AuthenticationName.Default.ToString();
            var collection = managedInstance.GetManagedInstanceAzureADOnlyAuthentications();

            // 1.CreateOrUpdate
            ManagedInstanceAzureADOnlyAuthenticationData data = new ManagedInstanceAzureADOnlyAuthenticationData()
            {
                IsAzureADOnlyAuthenticationEnabled = true,
            };
            var adoAuth = await collection.CreateOrUpdateAsync(WaitUntil.Completed, AuthenticationName.Default, data);

            // 2.CheckIfExist
            Assert.IsTrue(collection.Exists(adoAuthName));

            // 3.Get
            var getadoAuth = await collection.GetAsync(adoAuthName);
            Assert.IsNotNull(getadoAuth.Value.Data);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // 5.GetIfExist
            Assert.IsTrue(await collection.ExistsAsync(adoAuthName));
        }
    }
}
