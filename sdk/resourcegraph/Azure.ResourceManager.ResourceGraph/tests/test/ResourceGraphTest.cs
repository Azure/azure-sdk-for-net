// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ResourceGraph;
using Azure.ResourceManager.ResourceGraph.Models;
using Azure.ResourceManager.ResourceGraph.Tests;
using Azure.ResourceManager.Resources;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Management.ResourceGraph.Tests
{
    public class ResourceGraphTest : ResourceGraphManagementTestBase
    {
        public ResourceGraphTest(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task ResourcesAsyncTest()
        {
            var tenantsCollection = Client.GetTenants();
            var tenantList = await tenantsCollection.GetAllAsync().ToEnumerableAsync();
            var item = tenantList.FirstOrDefault();
            var query = new QueryContent("project id, tags, properties | limit 2") {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId }
            };

            var response = (await item.ResourcesAsync(query)).Value;
            Assert.IsNotNull(response);
            //top response
            Assert.AreEqual(2, response.Count);
            Assert.AreEqual(2, response.TotalRecords);
            Assert.IsNull(response.SkipToken);
            Assert.AreEqual(response.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Facets);
            //Data
            var list = response.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list[0].Count);
            Assert.AreEqual(3, list[1].Count);
            Assert.AreEqual(((JsonElement)list[0]["id"]).ValueKind, JsonValueKind.String);
            Assert.AreEqual(((JsonElement)list[0]["tags"]).ValueKind, JsonValueKind.Object);
            Assert.AreEqual(((JsonElement)list[0]["properties"]).ValueKind, JsonValueKind.Object);
        }

        [Test]
        public async Task ResourcesBasicQueryTableAsyncTest()
        {
            var tenantsCollection = Client.GetTenants();
            var tenantList = await tenantsCollection.GetAllAsync().ToEnumerableAsync();
            var item = tenantList.FirstOrDefault();
            var query = new QueryContent("project id, tags, properties | limit 2")
            {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId },
                Options = new QueryRequestOptions
                {
                    ResultFormat = ResultFormat.Table
                }
            };

            var response = (await item.ResourcesAsync(query)).Value;
            Assert.IsNotNull(response);
            //top response
            Assert.AreEqual(2, response.Count);
            Assert.AreEqual(2, response.TotalRecords);
            Assert.IsNull(response.SkipToken);
            Assert.AreEqual(response.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Facets);

            //data columns
            var table = response.Data.ToObjectFromJson<DataTable>();
            //errot convert to table
            Assert.NotNull(table);
        }
        [Test]
        public async Task ResourcesQueryOptionsTest()
        {
            var tenantsCollection = Client.GetTenants();
            var tenantList = await tenantsCollection.GetAllAsync().ToEnumerableAsync();
            var item = tenantList.FirstOrDefault();
            var query = new QueryContent("project id")
            {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId },
                Options = new QueryRequestOptions
                {
                    SkipToken = "ew0KICAiJGlkIjogIjEiLA0KICAiTWF4Um93cyI6IDQsDQogICJSb3dzVG9Ta2lwIjogNCwNCiAgIkt1c3RvQ2x1c3RlclVybCI6ICJodHRwczovL2FybXRvcG9sb2d5Lmt1c3RvLndpbmRvd3MubmV0Ig0KfQ==",
                    Top = 6,
                    Skip = 4
                }
            };

            var response = (await item.ResourcesAsync(query)).Value;
            Assert.IsNotNull(response);
            //top response
            Assert.AreEqual(6, response.Count);
            Assert.AreEqual(160, response.TotalRecords);
            Assert.NotNull(response.SkipToken);
            Assert.AreEqual(response.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Facets);
            //Data
            var list = response.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.IsNotNull(list);
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual(1, list[0].Count);
            Assert.AreEqual(((JsonElement)list[0]["id"]).ValueKind, JsonValueKind.String);
        }
        [Test]
        public async Task ResourcesFacetQueryAsyncTest()
        {
            var validExpression = "location";
            var invalidExpression = "nonExistingColumn";
            var tenantsCollection = Client.GetTenants();
            var tenantList = await tenantsCollection.GetAllAsync().ToEnumerableAsync();
            var item = tenantList.FirstOrDefault();
            var query = new QueryContent("project id, location | limit 8")
            {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId },
                Facets =
                {
                    new FacetRequest(validExpression)
                    {
                        Options = new FacetRequestOptions
                        {
                            SortOrder = FacetSortOrder.Desc,
                            Top = 2
                        }
                    },

                    new FacetRequest(invalidExpression)
                    {
                        Options = new FacetRequestOptions
                        {
                            SortOrder = FacetSortOrder.Desc,
                            Top = 2
                        }
                    }
                }
            };

            var response = (await item.ResourcesAsync(query)).Value;
            //top-level
            Assert.AreEqual(8, response.Count);
            Assert.AreEqual(8, response.TotalRecords);
            Assert.IsNull(response.SkipToken);
            Assert.AreEqual(response.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Facets);
            Assert.AreEqual(2, response.Facets.Count);
        }
        [Test]
        public async Task ResourceHistoryAsync()
        {
            var tenantsCollection = Client.GetTenants();
            var tenantList = await tenantsCollection.GetAllAsync().ToEnumerableAsync();
            var item = tenantList.FirstOrDefault();
            var content = new ResourcesHistoryContent()
            {
                Query = "project id, tags, properties | limit 2",
                ManagementGroups = { "91f5d6bc-f464-8343-5e53-3c3e3f99e5c4" },
                Options = new ResourcesHistoryRequestOptions
                {
                    Interval = new DateTimeInterval(Recording.Now.AddDays(-1), Recording.Now)
                }
            };
            var result = (await item.ResourcesHistoryAsync(content)).Value;
            var dict = result.ToObjectFromJson<Dictionary<string, object>>();
            Assert.AreEqual(dict.Count, 2);
            Assert.AreEqual(((JsonElement)dict["count"]).ValueKind,JsonValueKind.Number);
            Assert.AreEqual(((JsonElement)dict["snapshots"]).ValueKind, JsonValueKind.Array);
        }
    }
}
