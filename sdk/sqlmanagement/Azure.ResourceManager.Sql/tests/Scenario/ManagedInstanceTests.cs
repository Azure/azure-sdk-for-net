// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedInstanceTests : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _subnetId;

        public ManagedInstanceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource resourceGroup = rgLro.Value;
            _resourceGroupIdentifier = resourceGroup.Id;

            // create Virtual network
            string vnetName = SessionRecording.GenerateAssetName("vnet-");
            var vnet = await CreateVirtualNetwork(vnetName, resourceGroup);
            _subnetId = SubnetResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, vnetName, "ManagedInstance");
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<ManagedInstanceResource> CreateOrUpdateManagedInstance(string managedInstanceName)
        {
            ManagedInstanceData data = new ManagedInstanceData(AzureLocation.WestUS2)
            {
                AdministratorLogin = $"admin-{managedInstanceName}",
                AdministratorLoginPassword = CreateGeneralPassword(),
                SubnetId = new ResourceIdentifier(_subnetId),
                IsPublicDataEndpointEnabled = false,
                MaintenanceConfigurationId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_Default"),
                ProxyOverride = new ManagedInstanceProxyOverride("Proxy") { },
                TimezoneId = "UTC",
                IsZoneRedundant = false,
            };
            var managedInstanceLro = await _resourceGroup.GetManagedInstances().CreateOrUpdateAsync(WaitUntil.Completed, managedInstanceName, data);
            var managedInstance = managedInstanceLro.Value;
            return managedInstance;
        }

        [Test]
        [RecordedTest]
        public async Task ManagedInstanceApiTests()
        {
            //Because MangedInstance deployment takes a lot of time(more than 4.5 hours), the test cases are not separated separately
            // 1.CreateOrUpdate
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            var managedInstance = await CreateOrUpdateManagedInstance(managedInstanceName);
            Assert.IsNotNull(managedInstance.Data);
            Assert.AreEqual(managedInstanceName, managedInstance.Data.Name);
            Assert.AreEqual("westus2", managedInstance.Data.Location.ToString());

            // 2.CheckIfExist
            Assert.IsTrue(await _resourceGroup.GetManagedInstances().ExistsAsync(managedInstanceName));
            Assert.IsFalse(await _resourceGroup.GetManagedInstances().ExistsAsync(managedInstanceName + "0"));

            // 3.Get
            var getManagedInstance = await _resourceGroup.GetManagedInstances().GetAsync(managedInstanceName);
            Assert.IsNotNull(getManagedInstance.Value.Data);
            Assert.AreEqual(managedInstanceName, getManagedInstance.Value.Data.Name);
            Assert.AreEqual("westus2", getManagedInstance.Value.Data.Location.ToString());

            // 4.GetAll
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(managedInstanceName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual("westus2", list.FirstOrDefault().Data.Location.ToString());

            // 5.Delte
            await managedInstance.DeleteAsync(WaitUntil.Completed);
            list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
