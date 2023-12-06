// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class LogAnalyticsQueryTest:OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public LogAnalyticsQueryTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task LogAnalyticsQueryTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "AnalyticsQuery-test", _location);

            //LogAnalyticsQueryCollection_Create
            var queryId = Guid.NewGuid().ToString();
            var DisplayName = "1st resource of LogAnalyticsQuery test";
            var queryPackResource = await CreateLogAnalyticsQueryPack();
            var _collection = queryPackResource.GetLogAnalyticsQueries();
            var queryResource = await CreateLogAnalyticsQuery(queryPackResource, _collection, queryId, DisplayName);
            Assert.IsNotNull(queryResource);
            Assert.AreEqual(queryId, queryResource.Data.Name);

            //LogAnalyticsQueryCollection_Exist
            var exist = await _collection.ExistsAsync(queryId);
            Assert.IsTrue(exist.Value);

            //LogAnalyticsQueryCollection_Get
            var getResult =(await _collection.GetAsync(queryId)).Value;
            Assert.IsNotEmpty(getResult.Data.Id);
            Assert.AreEqual(getResult.Data.Name,queryResource.Data.Name);

            //LogAnalyticsQueryCollection_GetAll
            var queryId2nd = Guid.NewGuid().ToString();
            var DisplayName2 = "2nd resource of LogAnalyticsQuery test";
            var queryResource2 = await CreateLogAnalyticsQuery(queryPackResource, _collection, queryId2nd, DisplayName2);
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == queryResource.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == queryResource2.Data.Name));
            await queryResource2.DeleteAsync(WaitUntil.Completed);

            //LogAnalyticsQueryCollection_GetIfExistsAsync
            var getIfExists = (await _collection.GetIfExistsAsync(queryId)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(queryResource.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(queryResource.Data.Body, getIfExists.Data.Body);

            //LogAnalyticsQueryResource_CreateResourceIdentifier and Get
            var resourceId = LogAnalyticsQueryResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId,_resourceGroup.Data.Name,queryPackResource.Data.Name,queryId);
            var identifierResource = Client.GetLogAnalyticsQueryResource(resourceId);
            Assert.IsNotNull(identifierResource);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(queryResource.Data.Id, verify.Data.Id);
            Assert.AreEqual(queryResource.Data.Name, verify.Data.Name);

            //LogAnalyticsQueryResource_Update
            var updatelist = new List<string>() { "LogAnalyticsQueryTest","updateTest","updateTags" };
            var updateData = new LogAnalyticsQueryData()
            {
                Description = "update Test",
                Tags =
                {
                    ["update"] = updatelist
                },
                DisplayName = "LogAnalyticsQuery Test"
            };
            var updateResult = (await queryResource.UpdateAsync(updateData)).Value;
            Assert.IsNotNull(updateResult);
            var resultList = updateResult.Data.Tags.Values.ToList();
            foreach (var item in resultList[0])
            {
                Assert.IsTrue(updatelist.Contains(item));
            }
            Assert.AreEqual(updateResult.Data.Tags.Keys.ToList()[0].ToString(), "update");

            //LogAnalyticsQueryResource_Delete
            var delete = await queryResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(queryId));
            await queryPackResource.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        public async Task<LogAnalyticsQueryResource> CreateLogAnalyticsQuery(LogAnalyticsQueryPackResource queryPackResource, LogAnalyticsQueryCollection _collection, string queryId, string DisplayName)
        {
            var data = new LogAnalyticsQueryData()
            {
                Tags =
                {
                    ["key1"] = new string[]
                    {
                        "value"
                    }
                },
                DisplayName = DisplayName,
                Body = "let newExceptionsTimeRange = 1d;\nlet timeRangeToCheckBefore = 7d;\nexceptions\n| where timestamp < ago(timeRangeToCheckBefore)\n| summarize count() by problemId\n| join kind= rightanti (\nexceptions\n| where timestamp >= ago(newExceptionsTimeRange)\n| extend stack = tostring(details[0].rawStack)\n| summarize count(), dcount(user_AuthenticatedId), min(timestamp), max(timestamp), any(stack) by problemId  \n) on problemId \n| order by  count_ desc\n"
            };
            return (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, queryId, data)).Value;
        }

        public async Task<LogAnalyticsQueryPackResource> CreateLogAnalyticsQueryPack()
        {
            var queryPackName = Recording.GenerateAssetName("analyticsQueryPack");
            var data = new LogAnalyticsQueryPackData(_location)
            {
                Tags =
                {
                    ["Key1"] = "value"
                }
            };
            return (await _resourceGroup.GetLogAnalyticsQueryPacks().CreateOrUpdateAsync(WaitUntil.Completed, queryPackName, data)).Value;
        }
    }
}
