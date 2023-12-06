// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.OperationalInsights.Models;
using System.Text.Json;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class OperationalInsightsWorkspaceTest : OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public OperationalInsightsWorkspaceTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task OperationalInsightsWorkspaceTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsWorkspace-test", _location);
            var _collection = _resourceGroup.GetOperationalInsightsWorkspaces();

            //OperationalInsightsWorkspaceCollection_Create
            var workSpaceName = Recording.GenerateAssetName("OpWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location)
            {
                Tags =
                {
                    ["key1"] = "value"
                }
            };
            var workSpace = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            Assert.IsNotNull(workSpace);
            Assert.AreEqual(workSpaceName, workSpace.Data.Name);

            //OperationalInsightsWorkspaceCollection_Exist
            var exist = await _collection.ExistsAsync(workSpaceName);
            Assert.IsTrue(exist);

            //OperationalInsightsWorkspaceCollection_Get
            var getResult = await _collection.GetAsync(workSpaceName);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.Name, workSpace.Data.Name);

            //OperationalInsightsWorkspaceCollection_GetAll
            var workSpaceName2 = Recording.GenerateAssetName("OpWorkspace2nd");
            var workSpaceData2 = new OperationalInsightsWorkspaceData(_location);
            var workSpace2 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName2, workSpaceData2)).Value;
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == workSpace.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == workSpace2.Data.Name));

            //OperationalInsightsWorkspaceCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(workSpaceName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(workSpace.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(workSpace.Data.Id, getIfExists.Data.Id);

            //OperationalInsightsWorkspaceResource_CreateResourceIdentifier and Get
            var resourceId = OperationalInsightsWorkspaceResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, workSpace.Data.Name);
            var identifierResource = Client.GetOperationalInsightsWorkspaceResource(resourceId);
            Assert.IsNotNull(identifierResource);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(workSpace.Data.Id, verify.Data.Id);
            Assert.AreEqual(workSpace.Data.Name, verify.Data.Name);

            //OperationalInsightsWorkspaceResource_TagsOperation
            var addTag = (await workSpace.AddTagAsync("key2", "AddTags")).Value; //AddTags
            Assert.IsNotEmpty(addTag.Data.Tags);
            Assert.IsTrue(addTag.Data.Tags.ContainsKey("key2"));
            var setDic = new Dictionary<string, string>() //SetTags
            {
                ["key1"] = "OperationalInsightsWorkspaceTest",
                ["key2"] = "TagOperation",
                ["key3"] = "SetTagsTest"
            };
            var setTag = (await workSpace.SetTagsAsync(setDic)).Value;
            Assert.AreEqual(setTag.Data.Tags["key1"], setDic["key1"]);
            Assert.IsTrue(setTag.Data.Tags["key2"] != "AddTags");
            string removeKey = "key3";
            var removeTag = await workSpace.RemoveTagAsync(removeKey); //RemoveTags
            Assert.IsFalse(removeTag.Value.Data.Tags.ContainsKey(removeKey));

            //OperationalInsightsWorkspaceResource_Update
            var updateData = new OperationalInsightsWorkspacePatch()
            {
                Tags =
                {
                    ["key4"] = "updateTest",
                    ["key5"] = "testdata"
                }
            };
            var update = (await workSpace.UpdateAsync(updateData)).Value;
            Assert.IsNotNull(update);
            var verifyDic = new Dictionary<string, string>();
            foreach (var item in update.Data.Tags)
            {
                verifyDic.Add(item.Key, item.Value);
            }
            foreach (var item in updateData.Tags)
            {
                Assert.IsTrue(verifyDic.ContainsKey(item.Key));
                Assert.IsTrue(verifyDic.ContainsValue(item.Value));
            }

            //OperationalInsightsWorkspaceResource_IntelligencePacksOperation
            var listPacks = workSpace.GetIntelligencePacksAsync().ToEnumerableAsync().Result.ToList();
            Assert.IsNotNull(listPacks);
            Assert.IsTrue(listPacks.Count > 0);
            Console.WriteLine($"Get intelligence packs count {listPacks.Count}");
            foreach (var item in listPacks) //GetIntelligencePacks
            {
                Assert.IsNotNull(item);
                Console.WriteLine($"Intelligence packs {item.Name}");
            }
            int index = 0;
            while (index <= Math.Min(listPacks.Count,4)) //test part of the intelligence packs
            {
                if (!(bool)listPacks[index].IsEnabled)
                {
                    await workSpace.EnableIntelligencePackAsync(listPacks[index].Name); //EnableIntelligencePack
                    Assert.IsTrue(((await workSpace.GetIntelligencePacksAsync().ToEnumerableAsync()).ToList()[index]).IsEnabled);
                }
                await workSpace.DisableIntelligencePackAsync(listPacks[index].Name);   //DisableIntelligencePack
                Assert.IsFalse(((await workSpace.GetIntelligencePacksAsync().ToEnumerableAsync()).ToList()[index]).IsEnabled);
                index++; //Some already enabled intelligence packs cannot be disabled
            }

            //OperationalInsightsWorkspaceResource_SharedKeysOperation
            var getKey = (await workSpace.GetSharedKeysAsync()).Value; //GetSharedKeys
            if (getKey==null) await workSpace.RegenerateSharedKeyAsync(); //RegenerateSharedKey
            var result = (await workSpace.GetSharedKeysAsync()).Value;
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.PrimarySharedKey);
            Assert.IsNotEmpty(result.SecondarySharedKey);

            //OperationalInsightsWorkspaceResource_GetSchemas
            var listSchemas = workSpace.GetSchemasAsync().ToEnumerableAsync().Result.ToList();
            Assert.IsNotNull(listSchemas);
            Assert.IsTrue(listSchemas.Count > 0);
            Console.WriteLine($"Get schema for a given workspace count {listSchemas.Count}");
            foreach (var item in listSchemas)
            {
                Assert.IsNotNull(item);
                Console.WriteLine($"Get schemas name:{item.Name} ,displayname:{item.DisplayName}");
            }

            //OperationalInsightsWorkspaceResource_GetManagementGroups
            var listMgmtGroups = workSpace.GetManagementGroupsAsync().ToEnumerableAsync().Result.ToList();
            Assert.IsNotNull(listMgmtGroups);
            Console.WriteLine($"Gets management groups connected to a workspace count {listMgmtGroups.Count}");
            foreach (var item in listMgmtGroups)
            {
                Assert.IsNotNull(item);
                Console.WriteLine($"Get managementgroups name: {item.Name}, Id: {item.Id}");
            }

            //OperationalInsightsWorkspaceResource_GetUsages
            var listUsages = workSpace.GetUsagesAsync().ToEnumerableAsync().Result.ToList();
            Assert.IsNotNull(listUsages);
            Console.WriteLine($"Gets usage metrics for a workspace count {listMgmtGroups.Count}");
            foreach (var item in listUsages)
            {
                Assert.IsNotNull(item);
                Console.WriteLine($"Get usages name: {item.Name.Value}, unit: {item.Unit}");
            }

            //OperationalInsightsWorkspaceResource_GetAvailableServiceTiers
            var listServiceTiers = workSpace.GetAvailableServiceTiersAsync().ToEnumerableAsync().Result.ToList();
            Assert.IsNotNull(listServiceTiers);
            Console.WriteLine($"Gets the available service tiers for the workspace count {listServiceTiers.Count}");
            foreach (var item in listServiceTiers)
            {
                Assert.IsNotNull(item);
                Console.WriteLine($"Get servicetier: {item.ServiceTier}, whether the service tier is enabled: {item.IsEnabled}");
            }

            //OperationalInsightsWorkspaceResource_Delete
            var delete = await workSpace.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(workSpaceName));
            await workSpace2.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [Ignore("Only verifying that the testcase builds")]
        public async Task OperationalInsightsWorkspaceTestIgnore()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsWorkspace-test", _location);
            var _collection = _resourceGroup.GetOperationalInsightsWorkspaces();

            //OperationalInsightsWorkspaceCollection_Create
            var workSpaceName = Recording.GenerateAssetName("OpWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location)
            {
                Tags =
                {
                    ["key1"] = "value"
                }
            };
            var workSpace = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            Assert.IsNotNull(workSpace);
            Assert.AreEqual(workSpaceName, workSpace.Data.Name);
            var purgeTableData = new OperationalInsightsTableData()
            {
                RetentionInDays = 45,
                TotalRetentionInDays = 70,
                Schema = new OperationalInsightsSchema()
                {
                    Name = "AzureNetworkFlow",
                    Columns =
                    {
                        new OperationalInsightsColumn()
                        {
                        Name = "MyNewColumn",
                        ColumnType = OperationalInsightsColumnType.Guid,
                        }
                    },
                }
            };
            var purgeTable = (await workSpace.GetOperationalInsightsTables().CreateOrUpdateAsync(WaitUntil.Completed, "AzureNetworkFlow", purgeTableData)).Value;
            var purgeContent = new OperationalInsightsWorkspacePurgeContent(purgeTable.Data.Name, new OperationalInsightsWorkspacePurgeFilter[]
            {
                new OperationalInsightsWorkspacePurgeFilter()
                {
                    Column = "MyNewColumn",
                    Operator = ">",
                    Value = BinaryData.FromString($"\"{DateTime.Now}\"")
                }
            });
            var purge = (await workSpace.PurgeAsync(purgeContent)).Value; //Purge
            Console.WriteLine($"Purge Id {purge.OperationStringId}");
            var purgeStatus = (await workSpace.GetPurgeStatusAsync(purge.OperationStringId)).Value; //GetPurgeStatus
            Assert.IsNotNull(purgeStatus.Status);
            Console.WriteLine($"PurgeStatus: {purgeStatus.Status}");
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await purgeTable.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
