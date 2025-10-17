// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ResourceGraph;
using Azure.ResourceManager.ResourceGraph.Models;
using Azure.ResourceManager.ResourceGraph.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.Management.ResourceGraph.Tests
{
    public class ResourceGraphTest : ResourceGraphManagementTestBase
    {
        private TenantResource tenant;

        public ResourceGraphTest(bool isAsync)
            : base(isAsync) { }//, RecordedTestMode.Record)
        public async Task<TenantResource> GetTenantResourceAsync()
        {
            TenantCollection tenantsCollection = Client.GetTenants();
            var tenantList = await tenantsCollection.GetAllAsync().ToEnumerableAsync();
            var oneTenant = tenantList.FirstOrDefault();
            return oneTenant;
        }

        [SetUp]
        public async Task TestSetup()
        {
            tenant = await GetTenantResourceAsync();
        }

        [Test]
        public async Task ResourcesAsyncTest()
        {
            var queryContent = new ResourceQueryContent("project id, tags, properties | limit 2") {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId }
            };

            var resultResponse = (await tenant.GetResourcesAsync(queryContent)).Value;
            Assert.IsNotNull(resultResponse);
            //top response
            Assert.AreEqual(2, resultResponse.Count);
            Assert.AreEqual(2, resultResponse.TotalRecords);
            Assert.IsNull(resultResponse.SkipToken);
            Assert.AreEqual(resultResponse.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(resultResponse.Data);
            Assert.NotNull(resultResponse.Facets);
            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
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
            var queryContent = new ResourceQueryContent("project id, tags, properties | limit 2")
            {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId },
                Options = new ResourceQueryRequestOptions
                {
                    ResultFormat = ResultFormat.Table
                }
            };

            var resultResponse = (await tenant.GetResourcesAsync(queryContent)).Value;
            Assert.IsNotNull(resultResponse);
            //top response
            Assert.AreEqual(2, resultResponse.Count);
            Assert.AreEqual(2, resultResponse.TotalRecords);
            Assert.IsNull(resultResponse.SkipToken);
            Assert.AreEqual(resultResponse.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(resultResponse.Data);
            Assert.NotNull(resultResponse.Facets);

            //data columns
            StreamReader reader = new StreamReader(resultResponse.Data.ToStream());
            string content = reader.ReadToEnd();
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            var table = JsonSerializer.Deserialize<Table>(content, options);
            //Data columns
            Assert.NotNull(table.Columns);
            Assert.AreEqual(3, table.Columns.Count);
            Assert.NotNull(table.Columns[0].Name);
            Assert.NotNull(table.Columns[1].Name);
            Assert.NotNull(table.Columns[2].Name);
            Assert.AreEqual(ColumnDataType.String, table.Columns[0].Type);
            Assert.AreEqual(ColumnDataType.Object, table.Columns[1].Type);
            Assert.AreEqual(ColumnDataType.Object, table.Columns[2].Type);
            //Data rows
            Assert.NotNull(table.Rows);
            Assert.AreEqual(2, table.Rows.Count);
            Assert.AreEqual(3, table.Rows[0].Count);
            Assert.AreEqual(((JsonElement)table.Rows[0][0]).ValueKind, JsonValueKind.String);
            Assert.AreEqual(((JsonElement)table.Rows[0][1]).ValueKind, JsonValueKind.Object);
            Assert.AreEqual(((JsonElement)table.Rows[0][2]).ValueKind, JsonValueKind.Object);
        }

        [Test]
        public async Task ResourcesQueryOptionsTest()
        {
            var queryContent = new ResourceQueryContent("project id")
            {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId },
                Options = new ResourceQueryRequestOptions
                {
                    SkipToken = "ew0KICAiJGlkIjogIjEiLA0KICAiTWF4Um93cyI6IDQsDQogICJSb3dzVG9Ta2lwIjogNCwNCiAgIkt1c3RvQ2x1c3RlclVybCI6ICJodHRwczovL2FybXRvcG9sb2d5Lmt1c3RvLndpbmRvd3MubmV0Ig0KfQ==",
                    Top = 6,
                    Skip = 4
                }
            };

            var resultResponse = (await tenant.GetResourcesAsync(queryContent)).Value;
            Assert.IsNotNull(resultResponse);
            //top response
            Assert.AreEqual(6, resultResponse.Count);
            Assert.AreEqual(161, resultResponse.TotalRecords);
            Assert.NotNull(resultResponse.SkipToken);
            Assert.AreEqual(resultResponse.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(resultResponse.Data);
            Assert.NotNull(resultResponse.Facets);
            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
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
            var queryContent = new ResourceQueryContent("project id, location | limit 8")
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

            var resultResponse = (await tenant.GetResourcesAsync(queryContent)).Value;
            //top-level
            Assert.AreEqual(8, resultResponse.Count);
            Assert.AreEqual(8, resultResponse.TotalRecords);
            Assert.IsNull(resultResponse.SkipToken);
            Assert.AreEqual(resultResponse.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(resultResponse.Data);
            Assert.NotNull(resultResponse.Facets);
            Assert.AreEqual(2, resultResponse.Facets.Count);

            //Valid facet fields
            var result = (FacetResult)resultResponse.Facets[0];
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(4, result.TotalRecords);
            Assert.AreEqual(validExpression, result.Expression);

            // Valid facet data
            var result_data = result.Data.ToObjectFromJson<IList<IDictionary<string, object>>>();
            Assert.IsNotNull(result_data);
            Assert.AreEqual(2, result_data.Count);
            Assert.AreEqual(2, result_data[0].Count);
            Assert.AreEqual(((JsonElement)result_data[0]["location"]).ValueKind, JsonValueKind.String);
            Assert.AreEqual(((JsonElement)result_data[0]["count"]).ValueKind, JsonValueKind.Number);

            //invalid facet
            FacetError error = (FacetError)resultResponse.Facets[1];
            Assert.IsNotNull(error);
            Assert.AreEqual(invalidExpression, error.Expression);
            Assert.NotNull(error.Errors);
            Assert.IsTrue(error.Errors.Count >= 1 && error.Errors.Count <= int.MaxValue);
            Assert.NotNull(error.Errors[0].Code);
            Assert.NotNull(error.Errors[1].Code);
        }

        [Test]
        public Task ResourcesMalformedQueryAsyncTest()
        {
            var queryContent = new ResourceQueryContent("project id, location | where where")
            {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId }
            };
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await tenant.GetResourcesAsync(queryContent); });
            Assert.IsNotNull(exception);
            return Task.CompletedTask;
        }

        [Test]
        public async Task ResourcesTenantLevelQueryAsyncTest()
        {
            var queryContent = new ResourceQueryContent("project id, tags, properties | limit 2");

            var resultResponse = (await tenant.GetResourcesAsync(queryContent)).Value;
            // Top-level response fields
            Assert.AreEqual(2, resultResponse.Count);
            Assert.AreEqual(2, resultResponse.TotalRecords);
            Assert.IsNull(resultResponse.SkipToken);
            Assert.AreEqual(resultResponse.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(resultResponse.Data);
            Assert.NotNull(resultResponse.Facets);

            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list[0].Count);
            Assert.AreEqual(((JsonElement)list[0]["id"]).ValueKind, JsonValueKind.String);
            Assert.AreEqual(((JsonElement)list[0]["tags"]).ValueKind, JsonValueKind.Object);
            Assert.AreEqual(((JsonElement)list[0]["properties"]).ValueKind, JsonValueKind.Object);
        }

        [Test]
        public async Task ResourcesManagementGroupLevelQueryAsyncTest()
        {
            var queryContent = new ResourceQueryContent("project id, tags, properties | limit 2")
            {
                ManagementGroups = { "91f5d6bc-f464-8343-5e53-3c3e3f99e5c4" }
            };

            var resultResponse = (await tenant.GetResourcesAsync(queryContent)).Value;
            // Top-level response fields
            Assert.AreEqual(2, resultResponse.Count);
            Assert.AreEqual(2, resultResponse.TotalRecords);
            Assert.IsNull(resultResponse.SkipToken);
            Assert.AreEqual(resultResponse.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(resultResponse.Data);
            Assert.NotNull(resultResponse.Facets);

            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list[0].Count);
            Assert.AreEqual(((JsonElement)list[0]["id"]).ValueKind, JsonValueKind.String);
            Assert.AreEqual(((JsonElement)list[0]["tags"]).ValueKind, JsonValueKind.Object);
            Assert.AreEqual(((JsonElement)list[0]["properties"]).ValueKind, JsonValueKind.Object);
        }

        [Test]
        public async Task ResourcesMultiManagementGroupsLevelQueryTest()
        {
            var queryContent = new ResourceQueryContent("project id, tags, properties | limit 2")
            {
                ManagementGroups = { "91f5d6bc-f464-8343-5e53-3c3e3f99e5c4", "makharchMg" }
            };

            var resultResponse = (await tenant.GetResourcesAsync(queryContent)).Value;
            // Top-level response fields
            Assert.AreEqual(2, resultResponse.Count);
            Assert.AreEqual(2, resultResponse.TotalRecords);
            Assert.IsNull(resultResponse.SkipToken);
            Assert.AreEqual(resultResponse.ResultTruncated, ResultTruncated.False);
            Assert.NotNull(resultResponse.Data);
            Assert.NotNull(resultResponse.Facets);

            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(3, list[0].Count);
            Assert.AreEqual(((JsonElement)list[0]["id"]).ValueKind, JsonValueKind.String);
            Assert.AreEqual(((JsonElement)list[0]["tags"]).ValueKind, JsonValueKind.Object);
            Assert.AreEqual(((JsonElement)list[0]["properties"]).ValueKind, JsonValueKind.Object);
        }

        [Test]
        [Ignore("Resource history API is not enabled in stable version of SDK.")]
        public async Task ResourceHistoryAsync()
        {
            var historyContent = new ResourcesHistoryContent()
            {
                Query = "project id, tags, properties | limit 2",
                ManagementGroups = { "91f5d6bc-f464-8343-5e53-3c3e3f99e5c4" },
                Options = new ResourcesHistoryRequestOptions
                {
                    Interval = new DateTimeInterval(Recording.Now.AddDays(-1), Recording.Now)
                }
            };
            var result = (await tenant.GetResourceHistoryAsync(historyContent)).Value;
            var dict = result.ToObjectFromJson<Dictionary<string, object>>();
            Assert.AreEqual(dict.Count, 2);
            Assert.AreEqual(((JsonElement)dict["count"]).ValueKind,JsonValueKind.Number);
            Assert.AreEqual(((JsonElement)dict["snapshots"]).ValueKind, JsonValueKind.Array);
        }
    }
}
