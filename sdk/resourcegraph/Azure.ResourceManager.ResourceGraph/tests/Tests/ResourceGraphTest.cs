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
            Assert.That(resultResponse, Is.Not.Null);
            //top response
            Assert.That(resultResponse.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(resultResponse.TotalRecords, Is.EqualTo(2));
                Assert.That(resultResponse.SkipToken, Is.Null);
                Assert.That(resultResponse.ResultTruncated, Is.EqualTo(ResultTruncated.False));
                Assert.That(resultResponse.Data, Is.Not.Null);
                Assert.That(resultResponse.Facets, Is.Not.Null);
            });
            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(list[0], Has.Count.EqualTo(3));
                Assert.That(list[1], Has.Count.EqualTo(3));
                Assert.That(((JsonElement)list[0]["id"]).ValueKind, Is.EqualTo(JsonValueKind.String));
                Assert.That(((JsonElement)list[0]["tags"]).ValueKind, Is.EqualTo(JsonValueKind.Object));
                Assert.That(((JsonElement)list[0]["properties"]).ValueKind, Is.EqualTo(JsonValueKind.Object));
            });
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
            Assert.That(resultResponse, Is.Not.Null);
            //top response
            Assert.That(resultResponse.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(resultResponse.TotalRecords, Is.EqualTo(2));
                Assert.That(resultResponse.SkipToken, Is.Null);
                Assert.That(resultResponse.ResultTruncated, Is.EqualTo(ResultTruncated.False));
                Assert.That(resultResponse.Data, Is.Not.Null);
                Assert.That(resultResponse.Facets, Is.Not.Null);
            });

            //data columns
            StreamReader reader = new StreamReader(resultResponse.Data.ToStream());
            string content = reader.ReadToEnd();
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            var table = JsonSerializer.Deserialize<Table>(content, options);
            //Data columns
            Assert.That(table.Columns, Is.Not.Null);
            Assert.That(table.Columns, Has.Count.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(table.Columns[0].Name, Is.Not.Null);
                Assert.That(table.Columns[1].Name, Is.Not.Null);
                Assert.That(table.Columns[2].Name, Is.Not.Null);
                Assert.That(table.Columns[0].Type, Is.EqualTo(ColumnDataType.String));
                Assert.That(table.Columns[1].Type, Is.EqualTo(ColumnDataType.Object));
                Assert.That(table.Columns[2].Type, Is.EqualTo(ColumnDataType.Object));
                //Data rows
                Assert.That(table.Rows, Is.Not.Null);
            });
            Assert.That(table.Rows, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(table.Rows[0], Has.Count.EqualTo(3));
                Assert.That(((JsonElement)table.Rows[0][0]).ValueKind, Is.EqualTo(JsonValueKind.String));
                Assert.That(((JsonElement)table.Rows[0][1]).ValueKind, Is.EqualTo(JsonValueKind.Object));
                Assert.That(((JsonElement)table.Rows[0][2]).ValueKind, Is.EqualTo(JsonValueKind.Object));
            });
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
            Assert.That(resultResponse, Is.Not.Null);
            //top response
            Assert.That(resultResponse.Count, Is.EqualTo(6));
            Assert.Multiple(() =>
            {
                Assert.That(resultResponse.TotalRecords, Is.EqualTo(161));
                Assert.That(resultResponse.SkipToken, Is.Not.Null);
                Assert.That(resultResponse.ResultTruncated, Is.EqualTo(ResultTruncated.False));
                Assert.That(resultResponse.Data, Is.Not.Null);
                Assert.That(resultResponse.Facets, Is.Not.Null);
            });
            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Has.Count.EqualTo(6));
            Assert.Multiple(() =>
            {
                Assert.That(list[0], Has.Count.EqualTo(1));
                Assert.That(((JsonElement)list[0]["id"]).ValueKind, Is.EqualTo(JsonValueKind.String));
            });
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
            Assert.That(resultResponse.Count, Is.EqualTo(8));
            Assert.Multiple(() =>
            {
                Assert.That(resultResponse.TotalRecords, Is.EqualTo(8));
                Assert.That(resultResponse.SkipToken, Is.Null);
                Assert.That(resultResponse.ResultTruncated, Is.EqualTo(ResultTruncated.False));
                Assert.That(resultResponse.Data, Is.Not.Null);
                Assert.That(resultResponse.Facets, Is.Not.Null);
            });
            Assert.That(resultResponse.Facets, Has.Count.EqualTo(2));

            //Valid facet fields
            var result = (FacetResult)resultResponse.Facets[0];
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(result.TotalRecords, Is.EqualTo(4));
                Assert.That(result.Expression, Is.EqualTo(validExpression));
            });

            // Valid facet data
            var result_data = result.Data.ToObjectFromJson<IList<IDictionary<string, object>>>();
            Assert.That(result_data, Is.Not.Null);
            Assert.That(result_data, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(result_data[0], Has.Count.EqualTo(2));
                Assert.That(((JsonElement)result_data[0]["location"]).ValueKind, Is.EqualTo(JsonValueKind.String));
                Assert.That(((JsonElement)result_data[0]["count"]).ValueKind, Is.EqualTo(JsonValueKind.Number));
            });

            //invalid facet
            FacetError error = (FacetError)resultResponse.Facets[1];
            Assert.That(error, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(error.Expression, Is.EqualTo(invalidExpression));
                Assert.That(error.Errors, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(error.Errors.Count >= 1 && error.Errors.Count <= int.MaxValue, Is.True);
                Assert.That(error.Errors[0].Code, Is.Not.Null);
                Assert.That(error.Errors[1].Code, Is.Not.Null);
            });
        }

        [Test]
        public Task ResourcesMalformedQueryAsyncTest()
        {
            var queryContent = new ResourceQueryContent("project id, location | where where")
            {
                Subscriptions = { DefaultSubscription.Data.SubscriptionId }
            };
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await tenant.GetResourcesAsync(queryContent); });
            Assert.That(exception, Is.Not.Null);
            return Task.CompletedTask;
        }

        [Test]
        public async Task ResourcesTenantLevelQueryAsyncTest()
        {
            var queryContent = new ResourceQueryContent("project id, tags, properties | limit 2");

            var resultResponse = (await tenant.GetResourcesAsync(queryContent)).Value;
            // Top-level response fields
            Assert.That(resultResponse.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(resultResponse.TotalRecords, Is.EqualTo(2));
                Assert.That(resultResponse.SkipToken, Is.Null);
                Assert.That(resultResponse.ResultTruncated, Is.EqualTo(ResultTruncated.False));
                Assert.That(resultResponse.Data, Is.Not.Null);
                Assert.That(resultResponse.Facets, Is.Not.Null);
            });

            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(list[0], Has.Count.EqualTo(3));
                Assert.That(((JsonElement)list[0]["id"]).ValueKind, Is.EqualTo(JsonValueKind.String));
                Assert.That(((JsonElement)list[0]["tags"]).ValueKind, Is.EqualTo(JsonValueKind.Object));
                Assert.That(((JsonElement)list[0]["properties"]).ValueKind, Is.EqualTo(JsonValueKind.Object));
            });
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
            Assert.That(resultResponse.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(resultResponse.TotalRecords, Is.EqualTo(2));
                Assert.That(resultResponse.SkipToken, Is.Null);
                Assert.That(resultResponse.ResultTruncated, Is.EqualTo(ResultTruncated.False));
                Assert.That(resultResponse.Data, Is.Not.Null);
                Assert.That(resultResponse.Facets, Is.Not.Null);
            });

            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(list[0], Has.Count.EqualTo(3));
                Assert.That(((JsonElement)list[0]["id"]).ValueKind, Is.EqualTo(JsonValueKind.String));
                Assert.That(((JsonElement)list[0]["tags"]).ValueKind, Is.EqualTo(JsonValueKind.Object));
                Assert.That(((JsonElement)list[0]["properties"]).ValueKind, Is.EqualTo(JsonValueKind.Object));
            });
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
            Assert.That(resultResponse.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(resultResponse.TotalRecords, Is.EqualTo(2));
                Assert.That(resultResponse.SkipToken, Is.Null);
                Assert.That(resultResponse.ResultTruncated, Is.EqualTo(ResultTruncated.False));
                Assert.That(resultResponse.Data, Is.Not.Null);
                Assert.That(resultResponse.Facets, Is.Not.Null);
            });

            //Data
            var list = resultResponse.Data.ToObjectFromJson<List<IDictionary<string, object>>>();
            Assert.That(list, Is.Not.Null);
            Assert.That(list, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(list[0], Has.Count.EqualTo(3));
                Assert.That(((JsonElement)list[0]["id"]).ValueKind, Is.EqualTo(JsonValueKind.String));
                Assert.That(((JsonElement)list[0]["tags"]).ValueKind, Is.EqualTo(JsonValueKind.Object));
                Assert.That(((JsonElement)list[0]["properties"]).ValueKind, Is.EqualTo(JsonValueKind.Object));
            });
        }
    }
}
