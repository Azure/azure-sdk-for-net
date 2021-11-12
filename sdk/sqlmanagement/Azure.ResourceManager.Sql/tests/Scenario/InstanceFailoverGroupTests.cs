// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class InstanceFailoverGroupTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public InstanceFailoverGroupTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup resourceGroup = rgLro.Value;
            _resourceGroupIdentifier = resourceGroup.Id;
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        private async Task<InstanceFailoverGroup> CreateInstanceFailoverGroup(string locationName, string instanceFailoverGroupName)
        {
            // create PrimaryManagedInstance(WestUS2) and PartnerManagedInstance(NorthEurope)
            string primaryManagedInstanceName = Recording.GenerateAssetName("managed-instance-primary-");
            string partnerManagedInstanceName = Recording.GenerateAssetName("managed-instance-partner-");
            Task[] tasks = new Task[]
            {
                CreateDefaultManagedInstance(primaryManagedInstanceName,Location.WestUS2, _resourceGroup),
                CreateDefaultManagedInstance(partnerManagedInstanceName,Location.NorthEurope, _resourceGroup)
            };
            Task.WaitAll(tasks);
            string primaryManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(primaryManagedInstanceName)).Value.Data.Id.ToString();
            string partnerManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(partnerManagedInstanceName)).Value.Data.Id.ToString();

            // create InstanceFailoverGroup
            InstanceFailoverGroupReadWriteEndpoint instanceFailoverGroupReadWriteEndpoint = new InstanceFailoverGroupReadWriteEndpoint(ReadWriteEndpointFailoverPolicy.Automatic);
            instanceFailoverGroupReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = 60;
            InstanceFailoverGroupData data = new InstanceFailoverGroupData()
            {
                ReadWriteEndpoint = instanceFailoverGroupReadWriteEndpoint,
                ManagedInstancePairs =
                {
                    new ManagedInstancePairInfo(primaryManagedInstanceId,partnerManagedInstanceId),
                },
            };
            var instanceFailoverGroupLro = await _resourceGroup.GetInstanceFailoverGroups().CreateOrUpdateAsync(locationName, instanceFailoverGroupName, data);
            return instanceFailoverGroupLro.Value;
        }

        [Test]
        [Ignore("need to research how to create a FailoverGroup")]
        [RecordedTest]
        public async Task InstanceFailoverGroupApiTests()
        {
            // 1.CreateOrUpdate
            string instanceFailoverGroupName = Recording.GenerateAssetName("InstanceFailoverGroup-");
            string locationName = Location.WestUS2.ToString();
            var instanceFailoverGroup = await CreateInstanceFailoverGroup(locationName, instanceFailoverGroupName);
            Assert.IsNotNull(instanceFailoverGroup.Data);
            Assert.AreEqual(instanceFailoverGroupName, instanceFailoverGroup.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(_resourceGroup.GetInstanceFailoverGroups().CheckIfExists(locationName, instanceFailoverGroupName));
            Assert.IsTrue(_resourceGroup.GetInstanceFailoverGroups().CheckIfExists(locationName, instanceFailoverGroupName + "0"));

            // 3.Get
            var getInstanceFailoverGroup = await _resourceGroup.GetInstanceFailoverGroups().GetAsync(locationName, instanceFailoverGroupName);
            Assert.IsNotNull(instanceFailoverGroup.Data);
            Assert.AreEqual(instanceFailoverGroupName, instanceFailoverGroup.Data.Name);

            // 4.GetAll
            var list = await _resourceGroup.GetInstanceFailoverGroups().GetAllAsync(locationName).ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(instanceFailoverGroupName, list.FirstOrDefault().Data.Name);

            // 5.Delete
            var deleteInstanceFailoverGroup = (await _resourceGroup.GetInstanceFailoverGroups().GetAsync(locationName, instanceFailoverGroupName)).Value;
            await deleteInstanceFailoverGroup.DeleteAsync();
            list = await _resourceGroup.GetInstanceFailoverGroups().GetAllAsync(locationName).ToEnumerableAsync();
            Assert.IsEmpty(list);
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
