// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.SqlVirtualMachine.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Network;

namespace Azure.ResourceManager.SqlVirtualMachine.Tests
{
    public class SqlVmTests : SqlVirtualMachineManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _vmIdentifier;
        public SqlVmTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            string rgName = Recording.GenerateAssetName("sqlvmtestrg");
            string vmName = Recording.GenerateAssetName("vm");
            Subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroupAsync(Subscription, rgName, AzureLocation.WestUS);
            if (Mode == RecordedTestMode.Playback)
            {
                _vmIdentifier = VirtualMachineResource.CreateResourceIdentifier(_resourceGroup.Id.SubscriptionId, _resourceGroup.Id.Name, vmName);
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    string nsgName = Recording.GenerateAssetName("nsg");
                    string subnetName = Recording.GenerateAssetName("subnet");
                    string vnetName = Recording.GenerateAssetName("vnet");
                    string publicIPAddressName = Recording.GenerateAssetName("publicip");
                    string domainName = Recording.GenerateAssetName("dnslabel");
                    string nicName = Recording.GenerateAssetName("nic");
                    string nicIPConfName = Recording.GenerateAssetName("ipconfig");
                    NetworkSecurityGroupResource nsg = await CreateNetworkSecurityGroupAsync(_resourceGroup, nsgName);
                    VirtualNetworkResource vnet = await CreateVirtualNetworkAsync(_resourceGroup, nsg, vnetName, subnetName);
                    NetworkInterfaceResource nic = await CreateNetworkInterfaceAsync(_resourceGroup, vnet, nsg, publicIPAddressName, domainName, nicName, nicIPConfName);
                    VirtualMachineResource vm = await CreateVmAsync(_resourceGroup, nsg, nic, vmName);
                    _vmIdentifier = vm.Id;
                }
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateGetUpdateDeleteListSqlVirtualMachine()
        {
            // Create SQL VM
            var sqlVmCollections = _resourceGroup.GetSqlVms();
            SqlVmResource sqlVm = await CreateSqlVmAsync(_resourceGroup, _vmIdentifier);
            Assert.NotNull(sqlVm.Data);

            // Get SQL VM
            SqlVmResource sqlVmFromGet = await sqlVmCollections.GetAsync(_vmIdentifier.Name);
            ValidateSqlVirtualMachine(sqlVmFromGet.Data, sqlVm.Data);
            // Update
            string key = "test", value = "updateTag";
            SqlVmResource sqlVmFromUpdate = (await sqlVm.UpdateAsync(WaitUntil.Completed, new SqlVmPatch(){
                Tags =
                {
                    { key, value }
                }
            })).Value;
            ValidateSqlVirtualMachine(sqlVmFromUpdate.Data, sqlVm.Data, sameTags: false);
            Assert.AreEqual(1, sqlVmFromUpdate.Data.Tags.Count);
            Assert.AreEqual(value, sqlVmFromUpdate.Data.Tags[key]);
            // List
            var count = 0;
            await foreach (var sqlVmFromList in sqlVmCollections)
            {
                Assert.NotNull(sqlVmFromList.Data);
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            // List by subscription
            count = 0;
            await foreach (var sqlVmFromList in Subscription.GetSqlVmsAsync())
            {
                Assert.NotNull(sqlVmFromList.Data);
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            // Delete
            await sqlVmFromUpdate.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            Dictionary<ResourceIdentifier, SqlVmResource> sqlVms = new Dictionary<ResourceIdentifier, SqlVmResource>();
            SqlVmResource sqlVm = await CreateSqlVmAsync(_resourceGroup, _vmIdentifier);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            SqlVmResource updatedSqlVm = await sqlVm.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedSqlVm.Data.Tags);
        }

        private static void ValidateSqlVirtualMachine(SqlVmData sqlVM1, SqlVmData sqlVM2, bool sameTags = true)
        {
            Assert.AreEqual(sqlVM1.Id, sqlVM2.Id);
            Assert.AreEqual(sqlVM1.Name, sqlVM2.Name);
            Assert.AreEqual(sqlVM1.Location, sqlVM2.Location);
            Assert.AreEqual(sqlVM1.SqlManagement, sqlVM2.SqlManagement);
            if (sameTags)
            {
                Assert.True(ValidateTags(sqlVM1, sqlVM2));
            }
        }

        private static bool ValidateTags(SqlVmData sqlVM1, SqlVmData sqlVM2)
        {
            return ValidateTags(sqlVM1.Tags, sqlVM2.Tags);
        }

        private static bool ValidateTags(IDictionary<string, string> tags1, IDictionary<string, string> tags2)
        {
            if (tags1 == null && tags2 == null)
            {
                return true;
            }

            if (tags1 == null || tags2 == null || tags1.Count != tags2.Count)
            {
                return false;
            }

            foreach (string s in tags1.Keys)
            {
                if (!tags2.ContainsKey(s) || !tags1[s].Equals(tags2[s]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
