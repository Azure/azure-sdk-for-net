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
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class OperationalInsightsSavedSearchTest: OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public OperationalInsightsSavedSearchTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task OperationalInsightsSavedSearchTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsSavedSearch-test", _location);

            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            var _collection = workSpace.GetOperationalInsightsSavedSearches();

            //OperationalInsightsSavedSearchCollection_Create
            string category = "Saved Search Test Category";
            string displayName = "Saved Search Test";
            string query = "Heartbeat | summarize Count() by Computer | take a";
            var savedName = Recording.GenerateAssetName("OpSavedSearchs");
            var savedData = new OperationalInsightsSavedSearchData(category,displayName,query)
            {
                Tags =
                {
                    new OperationalInsightsTag("key1","value1")
                }
            };
            var savedSearch = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, savedName, savedData)).Value;
            Assert.IsNotNull(savedSearch);
            Assert.AreEqual(displayName, savedSearch.Data.DisplayName);

            //OperationalInsightsSavedSearchCollection_Exist
            var exist = await _collection.ExistsAsync(savedName);
            Assert.IsTrue(exist);

            //OperationalInsightsSavedSearchCollection_Get
            var getResult = await _collection.GetAsync(savedName);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.DisplayName, savedSearch.Data.DisplayName);

            //OperationalInsightsSavedSearchCollection_GetAll
            var savedName2 = Recording.GenerateAssetName("OpSavedSearchs2nd");
            var savedData2 = new OperationalInsightsSavedSearchData("Saved Search Test Category", "Saved Search Test 2nd", "Heartbeat | summarize Count() by Computer | take a");
            var savedSearch2 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, savedName2, savedData2)).Value;
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.DisplayName == savedSearch.Data.DisplayName));
            Assert.IsTrue(list.Exists(item => item.Data.DisplayName == savedSearch2.Data.DisplayName));
            await savedSearch2.DeleteAsync(WaitUntil.Completed);

            //OperationalInsightsSavedSearchCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(savedName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(savedSearch.Data.DisplayName, getIfExists.Data.DisplayName);
            Assert.AreEqual(savedSearch.Data.Id, getIfExists.Data.Id);

            //OperationalInsightsSavedSearchResource_CreateResourceIdentifier and Get
            var resourceId = OperationalInsightsSavedSearchResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, workSpace.Data.Name, savedName);
            var identifierResource = Client.GetOperationalInsightsSavedSearchResource(resourceId);
            Assert.IsNotNull(identifierResource);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(savedSearch.Data.Id, verify.Data.Id);
            Assert.AreEqual(savedSearch.Data.DisplayName, verify.Data.DisplayName);

            //OperationalInsightsSavedSearchResource_Delete
            var delete = await savedSearch.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(savedName));
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [Ignore("Only verifying that the testcase builds")]
        public async Task OperationalInsightsSavedSearchResource_Update()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsSavedSearch-test", _location);

            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            string category = "Saved Search Test Category";
            string displayName = "Saved Search Test";
            string query = "Heartbeat | summarize Count() by Computer | take a";
            var savedName = Recording.GenerateAssetName("OpSavedSearchs");
            var savedData = new OperationalInsightsSavedSearchData(category, displayName, query)
            {
                Tags =
                {
                    new OperationalInsightsTag("key1","value1")
                }
            };
            var savedSearch = (await workSpace.GetOperationalInsightsSavedSearches().CreateOrUpdateAsync(WaitUntil.Completed, savedName, savedData)).Value;

            //OperationalInsightsSavedSearchResource_Update
            string updateCategory = "Saved Search Upate Test Category";
            string updateDisplayName = "Saved Search Update Test";
            string updateQuery = "Heartbeat | summarize Count() by Computer | take b";
            var updateData = new OperationalInsightsSavedSearchData(updateCategory, updateDisplayName, updateQuery)
            {
                Tags =
                {
                    new OperationalInsightsTag("Group", "Computer")
                }
            };
            var update = (await savedSearch.UpdateAsync(WaitUntil.Completed, updateData)).Value;
            Assert.IsNotNull(update);
            Assert.IsTrue(update.Data.DisplayName != displayName);
            await savedSearch.DeleteAsync(WaitUntil.Completed);
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
