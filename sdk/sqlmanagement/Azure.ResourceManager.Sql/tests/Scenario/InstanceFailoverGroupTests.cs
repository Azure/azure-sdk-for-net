// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class InstanceFailoverGroupTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public InstanceFailoverGroupTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource resourceGroup = rgLro.Value;
            _resourceGroupIdentifier = resourceGroup.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        private async Task<InstanceFailoverGroupResource> CreateInstanceFailoverGroup(string locationName, string instanceFailoverGroupName)
        {
            // create PrimaryManagedInstance(WestUS2) and PartnerManagedInstance(NorthEurope)
            string primaryManagedInstanceName = Recording.GenerateAssetName("managed-instance-primary-");
            string partnerManagedInstanceName = Recording.GenerateAssetName("managed-instance-partner-");
            string managedInstanceName1 = Recording.GenerateAssetName("managed-instance-");
            string managedInstanceName2 = Recording.GenerateAssetName("managed-instance-");
            string vnetName1 = Recording.GenerateAssetName("vnet-");
            string vnetName2 = Recording.GenerateAssetName("vnet-");
            Task[] tasks = new Task[]
            {
                CreateDefaultManagedInstance(managedInstanceName1, vnetName1, AzureLocation.WestUS2, _resourceGroup),
                CreateDefaultManagedInstance(managedInstanceName2, vnetName2, AzureLocation.WestUS2, _resourceGroup),
            };
            Task.WaitAll(tasks);
            ResourceIdentifier primaryManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(primaryManagedInstanceName)).Value.Data.Id;
            ResourceIdentifier partnerManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(partnerManagedInstanceName)).Value.Data.Id;

            // create InstanceFailoverGroup
            InstanceFailoverGroupReadWriteEndpoint instanceFailoverGroupReadWriteEndpoint = new InstanceFailoverGroupReadWriteEndpoint(ReadWriteEndpointFailoverPolicy.Automatic);
            instanceFailoverGroupReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = 60;
            InstanceFailoverGroupData data = new InstanceFailoverGroupData()
            {
                ReadWriteEndpoint = instanceFailoverGroupReadWriteEndpoint,
                ManagedInstancePairs =
                {
                    new ManagedInstancePairInfo(primaryManagedInstanceId, partnerManagedInstanceId, null),
                },
            };
            var instanceFailoverGroupLro = await _resourceGroup.GetInstanceFailoverGroups(locationName).CreateOrUpdateAsync(WaitUntil.Completed, instanceFailoverGroupName, data);
            return instanceFailoverGroupLro.Value;
        }

        [Test]
        [Ignore("need to research how to create a FailoverGroup")]
        [RecordedTest]
        public async Task InstanceFailoverGroupApiTests()
        {
            // 1.CreateOrUpdate
            string instanceFailoverGroupName = Recording.GenerateAssetName("InstanceFailoverGroup-");
            string locationName = AzureLocation.WestUS2.ToString();
            var instanceFailoverGroup = await CreateInstanceFailoverGroup(locationName, instanceFailoverGroupName);
            Assert.That(instanceFailoverGroup.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(instanceFailoverGroup.Data.Name, Is.EqualTo(instanceFailoverGroupName));

                // 2.CheckIfExist
                Assert.That((bool)_resourceGroup.GetInstanceFailoverGroups(locationName).Exists(instanceFailoverGroupName), Is.True);
                Assert.That((bool)_resourceGroup.GetInstanceFailoverGroups(locationName).Exists(instanceFailoverGroupName + "0"), Is.True);
            });

            // 3.Get
            var getInstanceFailoverGroup = await _resourceGroup.GetInstanceFailoverGroups(locationName).GetAsync(instanceFailoverGroupName);
            Assert.That(instanceFailoverGroup.Data, Is.Not.Null);
            Assert.That(instanceFailoverGroup.Data.Name, Is.EqualTo(instanceFailoverGroupName));

            // 4.GetAll
            var list = await _resourceGroup.GetInstanceFailoverGroups(locationName).GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.FirstOrDefault().Data.Name, Is.EqualTo(instanceFailoverGroupName));

            // 5.Delete
            var deleteInstanceFailoverGroup = (await _resourceGroup.GetInstanceFailoverGroups(locationName).GetAsync(instanceFailoverGroupName)).Value;
            await deleteInstanceFailoverGroup.DeleteAsync(WaitUntil.Completed);
            list = await _resourceGroup.GetInstanceFailoverGroups(locationName).GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Empty);
        }

        //[Test]
        //public async Task Create()
        //{
        //    string locationName = Location.WestUS2;
        //    string instanceFailoverGroupName = "instancfailovergroup-2548115";
        //    string primaryManagedInstanceName = "managed-instance-primary-2000";
        //    string backupManagedInstanceName = "managed-instance-2000-partner";
        //    string primaryManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(primaryManagedInstanceName)).Value.Data.Id.ToString();
        //    string partnerManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(backupManagedInstanceName)).Value.Data.Id.ToString();

        //    // create InstanceFailoverGroup
        //    InstanceFailoverGroupReadWriteEndpoint instanceFailoverGroupReadWriteEndpoint = new InstanceFailoverGroupReadWriteEndpoint(ReadWriteEndpointFailoverPolicy.Automatic);
        //    instanceFailoverGroupReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = 60;
        //    InstanceFailoverGroupData data = new InstanceFailoverGroupData()
        //    {
        //        ReadWriteEndpoint = instanceFailoverGroupReadWriteEndpoint,
        //        ManagedInstancePairs =
        //        {
        //            new ManagedInstancePairInfo(primaryManagedInstanceId, partnerManagedInstanceId),
        //        },
        //        PartnerRegions = { new PartnerRegionInfo() { Location = Location.NorthEurope } },
        //        ReadOnlyEndpoint = new InstanceFailoverGroupReadOnlyEndpoint(ReadOnlyEndpointFailoverPolicy.Disabled),
        //        //ReplicationState  = "CATCH_UP",
        //    };
        //    var instanceFailoverGroupLro = await _resourceGroup.GetInstanceFailoverGroups().CreateOrUpdateAsync(locationName, instanceFailoverGroupName, data);
        //}
    }
}
