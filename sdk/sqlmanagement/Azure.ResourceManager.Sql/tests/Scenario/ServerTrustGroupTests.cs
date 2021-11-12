// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ServerTrustGroupTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ServerTrustGroupTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().GetAsync("Sql-RG-1100");
            //var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            StopSessionRecording();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        private async Task<ServerTrustGroup> CreateServerTrustGroup(string locationName, string serverTrustGroupName)
        {
            // create two ManagedInstanceName
            string primaryManagedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string backupManagedInstanceName = Recording.GenerateAssetName("managed-instance-backup-");
            Task[] tasks = new Task[]
            {
                CreateDefaultManagedInstance(primaryManagedInstanceName,Location.WestUS2, _resourceGroup),
                CreateDefaultManagedInstance(backupManagedInstanceName,Location.WestUS2, _resourceGroup)
            };
            Task.WaitAll(tasks);
            string primaryManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(primaryManagedInstanceName)).Value.Data.Id.ToString();
            string backupManagedInstanceId = (await _resourceGroup.GetManagedInstances().GetAsync(backupManagedInstanceName)).Value.Data.Id.ToString();

            // create ServerTrustGroup
            ServerTrustGroupData data = new ServerTrustGroupData()
            {
                GroupMembers =
                {
                    new ServerInfo(primaryManagedInstanceId),
                    new ServerInfo(backupManagedInstanceId),
                },
                TrustScopes = { ServerTrustGroupPropertiesTrustScopesItem.GlobalTransactions},
            };
            var serverTrustGroup = await _resourceGroup.GetServerTrustGroups().CreateOrUpdateAsync(locationName, serverTrustGroupName, data);
            return serverTrustGroup.Value;
        }

        [Test]
        [RecordedTest]
        public async Task ServerTrustGroupsApiTests()
        {
            // 1.CreateOrUpdate
            string locationName = Location.WestUS2.ToString();
            string serverTrustGroupName = Recording.GenerateAssetName("trust-group-");
            var serverTrustGroup = await CreateServerTrustGroup(locationName, serverTrustGroupName);
            Assert.IsNotNull(serverTrustGroup.Data);
            Assert.AreEqual(serverTrustGroupName, serverTrustGroup.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(_resourceGroup.GetServerTrustGroups().CheckIfExists(locationName, serverTrustGroupName));
            Assert.IsFalse(_resourceGroup.GetServerTrustGroups().CheckIfExists(locationName, serverTrustGroupName + "0"));

            // 3.Get
            var getServerTrustGroup =await _resourceGroup.GetServerTrustGroups().GetAsync(locationName, serverTrustGroupName);
            Assert.IsNotNull(getServerTrustGroup.Value.Data);
            Assert.AreEqual(serverTrustGroupName, getServerTrustGroup.Value.Data.Name);

            // 4.GetAll
            var list = await _resourceGroup.GetServerTrustGroups().GetAllAsync(locationName).ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1,list.Count);

            // 5.Delete
            var deleteServerTrustGroup = await _resourceGroup.GetServerTrustGroups().GetAsync(locationName, serverTrustGroupName);
            await deleteServerTrustGroup.Value.DeleteAsync();
            list = await _resourceGroup.GetServerTrustGroups().GetAllAsync(locationName).ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
