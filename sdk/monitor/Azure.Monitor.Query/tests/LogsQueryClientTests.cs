// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Monitor.Query.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class LogsQueryClientTests
    {
        [Test]
        public void CanSetServiceTimeout_Mocked()
        {
            string preferHeader = null;
            TimeSpan? networkOverride = default;

            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                Assert.True(message.Request.Headers.TryGetValue("prefer", out preferHeader));
                networkOverride = message.NetworkTimeout;

                return new MockResponse(403);
            });

            var client = new LogsQueryClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsQueryClientOptions()
            {
                Transport = mockTransport
            });

            Assert.ThrowsAsync<RequestFailedException>(() => client.QueryWorkspaceAsync("wid", "tid", TimeSpan.FromDays(1), options: new LogsQueryOptions()
            {
                ServerTimeout = TimeSpan.FromMinutes(10)
            }));

            Assert.AreEqual("wait=600", preferHeader);
            // The network timeout is adjusted with 15 sec buffer
            Assert.AreEqual(TimeSpan.FromMinutes(10).Add(TimeSpan.FromSeconds(15)), networkOverride);
        }

        [Test]
        public void CanSetServiceTimeoutForBatch_Mocked()
        {
            string preferHeader = null;
            TimeSpan? networkOverride = default;

            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                Assert.True(message.Request.Headers.TryGetValue("prefer", out preferHeader));
                networkOverride = message.NetworkTimeout;

                return new MockResponse(403);
            });

            var client = new LogsQueryClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsQueryClientOptions()
            {
                Transport = mockTransport
            });

            var batch = new LogsBatchQuery();
            batch.AddWorkspaceQuery("wid", "tid", TimeSpan.FromDays(1), options: new LogsQueryOptions()
            {
                ServerTimeout = TimeSpan.FromMinutes(1)
            });
            batch.AddWorkspaceQuery("wid", "tid", TimeSpan.FromDays(1), options: new LogsQueryOptions()
            {
                ServerTimeout = TimeSpan.FromMinutes(2)
            });
            batch.AddWorkspaceQuery("wid", "tid", TimeSpan.FromDays(1), options: new LogsQueryOptions()
            {
                ServerTimeout = TimeSpan.FromMinutes(3)
            });

            Assert.ThrowsAsync<RequestFailedException>(() => client.QueryBatchAsync(batch));

            // 3 minutes (180 sec) is the max out of all individual queries
            Assert.AreEqual("wait=180", preferHeader);
            // The network timeout is adjusted with 15 sec buffer
            Assert.AreEqual(TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(15)), networkOverride);
        }

        [Test]
        public async Task QueryBatchHandledInvalidResponse()
        {
            var badResponse = @"{
    ""responses"": [
        {
            ""id"": ""0"",
            ""status"": 200,
            ""headers"": {
                ""Age"": ""3"",
                ""request-context"": ""appId=cid-v1:70941e4f-7e8f-40b7-b730-183893db0297""
            },
            ""body"": {""tables"":[{""name"":""PrimaryResult"",""columns"":[{""name"":""TenantId"",""type"":""string""},{""name"":""SourceSystem"",""type"":""string""},{""name"":""MG"",""type"":""string""},{""name"":""ManagementGroupName"",""type"":""string""},{""name"":""TimeGenerated"",""type"":""datetime""},{""name"":""Computer"",""type"":""string""},{""name"":""RawData"",""type"":""string""},{""name"":""IntColumn_d"",""type"":""real""},{""name"":""StringColumn_s"",""type"":""string""},{""name"":""BoolColumn_b"",""type"":""bool""},{""name"":""FloatColumn_d"",""type"":""real""},{""name"":""Type"",""type"":""string""},{""name"":""_ResourceId"",""type"":""string""}],""rows"":[[""e7bf7412-576d-4978-b47c-2edf669e3e2a"",""RestAPI"","""","""",""2021-05-31T00:00:00Z"","""","""",1,""a"",false,0,""TableA1_151_CL"",""""],[""e7bf7412-576d-4978-b47c-2edf669e3e2a"",""RestAPI"","""","""",""2021-06-02T00:00:00Z"","""","""",3,""b"",true,1.20000005,""TableA1_151_CL"",""""],[""e7bf7412-576d-4978-b47c-2edf669e3e2a"",""RestAPI"","""","""",""2021-06-05T00:00:00Z"","""","""",1,""c"",false,1.10000002,""TableA1_151_CL"",""""]]}]}
        }
    ]
}
";
            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                var mockResponse = new MockResponse(200);
                mockResponse.SetContent(badResponse);
                return mockResponse;
            });

            var client = new LogsQueryClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsQueryClientOptions()
            {
                Transport = mockTransport
            });

            LogsBatchQuery batch = new LogsBatchQuery();
            batch.AddWorkspaceQuery("wid", "query", QueryTimeRange.All);

            LogsBatchQueryResultCollection batchResults = await client.QueryBatchAsync(batch);
            Assert.NotNull(batchResults.GetResult("0"));
        }

        [Test]
        public async Task UsesDefaultEndpoint()
        {
            var mockTransport = MockTransport.FromMessageCallback(_ =>
            {
                var mockResponse = new MockResponse(200);
                mockResponse.SetContent("{\"tables\":[]}");
                return mockResponse;
            });

            var client = new LogsQueryClient(new MockCredential(), new LogsQueryClientOptions()
            {
                Transport = mockTransport
            });

            await client.QueryWorkspaceAsync("", "", QueryTimeRange.All);
            StringAssert.StartsWith("https://api.loganalytics.io", mockTransport.SingleRequest.Uri.ToString());
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        private static IEnumerable<object[]> GetAudience()
        {
            yield return new object[] { null, "https://api.loganalytics.io//.default" };
            yield return new object[] { LogsQueryAudience.AzurePublicCloud, "https://api.loganalytics.io//.default" };
            yield return new object[] { LogsQueryAudience.AzureGovernment, "https://api.loganalytics.us//.default" };
            yield return new object[] { LogsQueryAudience.AzureChina, "https://api.loganalytics.azure.cn//.default" };
        }

        [Test]
        [TestCaseSource(nameof(GetAudience))]
        public async Task UsesDefaultAuthScope(LogsQueryAudience audience, string expectedScope)
        {
            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                var mockResponse = new MockResponse(200);
                mockResponse.SetContent("{\"tables\":[]}");
                return mockResponse;
            });

            Mock<MockCredential> mock = new() { CallBase = true };

            string[] scopes = null;
            mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Callback<TokenRequestContext, CancellationToken>((c, _) => scopes = c.Scopes)
                .CallBase();

            var options = new LogsQueryClientOptions()
            {
                Transport = mockTransport,
                Audience = audience
            };

            var client = new LogsQueryClient(mock.Object, options);

            await client.QueryWorkspaceAsync("", "", QueryTimeRange.All);
            Assert.AreEqual(new[] { expectedScope }, scopes);
        }

        [Test]
        public void ExposesPublicEndpoint()
        {
            var client = new LogsQueryClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsQueryClientOptions());
            Assert.AreEqual(new Uri("https://api.loganalytics.io"), client.Endpoint);
        }

        [Test]
        public void MonitorQueryModelFactory_LogsQueryResult_ConvertBinaryDataToJsonElement()
        {
            var errorJson = @"{
                                ""code"": ""PartialError"",
                                ""message"": ""There were some errors when processing your query.""
                           }";
            var result = MonitorQueryModelFactory.LogsQueryResult(new List<LogsTable>(), new BinaryData("{}"), new BinaryData("42"), new BinaryData(errorJson));
            Assert.AreEqual(result.GetStatistics().ToString(), "{}");
            Assert.AreEqual(result.GetVisualization().ToString(), "42");
            Assert.AreEqual("PartialError", result.Error.Code);
            Assert.AreEqual("There were some errors when processing your query.", result.Error.Message);
        }

        [Test]
        public void ValidateMonitorModelFactoryTableCreation()
        {
            LogsTableColumn logsTableColumn0 = MonitorQueryModelFactory.LogsTableColumn("column0", LogsColumnType.Datetime);
            LogsTableColumn logsTableColumn1 = MonitorQueryModelFactory.LogsTableColumn("column1", LogsColumnType.Guid);
            LogsTableColumn logsTableColumn2 = MonitorQueryModelFactory.LogsTableColumn("column2", LogsColumnType.Int);
            LogsTableColumn logsTableColumn3 = MonitorQueryModelFactory.LogsTableColumn("column3", LogsColumnType.Long);
            LogsTableColumn logsTableColumn4 = MonitorQueryModelFactory.LogsTableColumn("column4", LogsColumnType.Real);
            LogsTableColumn logsTableColumn5 = MonitorQueryModelFactory.LogsTableColumn("column5", LogsColumnType.String);
            LogsTableColumn logsTableColumn6 = MonitorQueryModelFactory.LogsTableColumn("column6", LogsColumnType.Timespan);
            LogsTableColumn logsTableColumn7 = MonitorQueryModelFactory.LogsTableColumn("column7", LogsColumnType.Decimal);
            LogsTableColumn logsTableColumn8 = MonitorQueryModelFactory.LogsTableColumn("column8", LogsColumnType.Bool);
            LogsTableColumn logsTableColumn9 = MonitorQueryModelFactory.LogsTableColumn("column9", LogsColumnType.Dynamic);
            LogsTableColumn[] logsTableColumns = new LogsTableColumn[] { logsTableColumn0, logsTableColumn1, logsTableColumn2, logsTableColumn3, logsTableColumn4, logsTableColumn5, logsTableColumn6, logsTableColumn7, logsTableColumn8, logsTableColumn9};
            Object[] rowValues = new Object[] { "2015-12-31T23:59:59.9Z", "74be27de-1e4e-49d9-b579-fe0b331d3642", 12345, 1234567890123, 12345.6789, "string value", "00:00:10", "0.10101", false, "{\u0022a\u0022:123,\u0022b\u0022:\u0022hello\u0022,\u0022c\u0022:[1,2,3],\u0022d\u0022:{}}" };

            LogsTableRow logsTableRow = MonitorQueryModelFactory.LogsTableRow(logsTableColumns, rowValues);
            LogsTableRow[] rowArray = new LogsTableRow[] { logsTableRow };
            LogsTable logsTable = MonitorQueryModelFactory.LogsTable("tester", logsTableColumns.AsEnumerable(), rowArray.AsEnumerable());

            Assert.AreEqual("tester", logsTable.Name);
            Assert.AreEqual(1, logsTable.Rows.Count);
            Assert.AreEqual(10, logsTable.Columns.Count);

            Assert.AreEqual("column0", logsTable.Columns[0].Name);
            Assert.AreEqual("datetime", logsTable.Columns[0].Type.ToString());
            Assert.AreEqual("column1", logsTable.Columns[1].Name);
            Assert.AreEqual("guid", logsTable.Columns[1].Type.ToString());
            Assert.AreEqual("column2", logsTable.Columns[2].Name);
            Assert.AreEqual("int", logsTable.Columns[2].Type.ToString());
            Assert.AreEqual("column3", logsTable.Columns[3].Name);
            Assert.AreEqual("long", logsTable.Columns[3].Type.ToString());
            Assert.AreEqual("column4", logsTable.Columns[4].Name);
            Assert.AreEqual("real", logsTable.Columns[4].Type.ToString());
            Assert.AreEqual("column5", logsTable.Columns[5].Name);
            Assert.AreEqual("string", logsTable.Columns[5].Type.ToString());
            Assert.AreEqual("column6", logsTable.Columns[6].Name);
            Assert.AreEqual("timespan", logsTable.Columns[6].Type.ToString());
            Assert.AreEqual("column7", logsTable.Columns[7].Name);
            Assert.AreEqual("decimal", logsTable.Columns[7].Type.ToString());
            Assert.AreEqual("column8", logsTable.Columns[8].Name);
            Assert.AreEqual("bool", logsTable.Columns[8].Type.ToString());
            Assert.AreEqual("column9", logsTable.Columns[9].Name);
            Assert.AreEqual("dynamic", logsTable.Columns[9].Type.ToString());

            var expectedDate = DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00");

            Assert.AreEqual(expectedDate, logsTable.Rows[0].GetDateTimeOffset(0));
            Assert.AreEqual(expectedDate, logsTable.Rows[0].GetObject("column0"));
            Assert.AreEqual(false, logsTable.Rows[0].GetBoolean("column8"));
            Assert.AreEqual(false, logsTable.Rows[0].GetBoolean(8));
            Assert.AreEqual(false, logsTable.Rows[0].GetObject("column8"));
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), logsTable.Rows[0].GetGuid("column1"));
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), logsTable.Rows[0].GetGuid(1));
            Assert.AreEqual(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642"), logsTable.Rows[0].GetObject("column1"));
            Assert.AreEqual(12345, logsTable.Rows[0].GetInt32("column2"));
            Assert.AreEqual(12345, logsTable.Rows[0].GetInt32(2));
            Assert.AreEqual(12345, logsTable.Rows[0].GetObject("column2"));
            Assert.AreEqual(1234567890123, logsTable.Rows[0].GetInt64("column3"));
            Assert.AreEqual(1234567890123, logsTable.Rows[0].GetInt64(3));
            Assert.AreEqual(1234567890123, logsTable.Rows[0].GetObject("column3"));
            Assert.AreEqual(12345.6789d, logsTable.Rows[0].GetDouble("column4"));
            Assert.AreEqual(12345.6789d, logsTable.Rows[0].GetDouble(4));
            Assert.AreEqual(12345.6789d, logsTable.Rows[0].GetObject("column4"));
            Assert.AreEqual("string value", logsTable.Rows[0].GetString("column5"));
            Assert.AreEqual("string value", logsTable.Rows[0].GetString(5));
            Assert.AreEqual("string value", logsTable.Rows[0].GetObject("column5"));
            Assert.AreEqual(TimeSpan.FromSeconds(10), logsTable.Rows[0].GetTimeSpan("column6"));
            Assert.AreEqual(TimeSpan.FromSeconds(10), logsTable.Rows[0].GetTimeSpan(6));
            Assert.AreEqual(TimeSpan.FromSeconds(10), logsTable.Rows[0].GetObject("column6"));
            Assert.AreEqual(0.10101m, logsTable.Rows[0].GetDecimal("column7"));
            Assert.AreEqual(0.10101m, logsTable.Rows[0].GetDecimal(7));
            Assert.AreEqual(0.10101m, logsTable.Rows[0].GetObject("column7"));
            Assert.IsFalse(logsTable.Rows[0].GetBoolean("column8"));
            Assert.IsFalse(logsTable.Rows[0].GetBoolean(8));
            Assert.AreEqual(false, logsTable.Rows[0].GetObject("column8"));
            Assert.AreEqual("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}", logsTable.Rows[0].GetDynamic(9).ToString());
            Assert.AreEqual("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}", logsTable.Rows[0].GetDynamic("column9").ToString());
            Assert.AreEqual("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}", logsTable.Rows[0].GetObject("column9").ToString());
        }

        [Test]
        public void Constructor_WhenOptionsAndEndpointIsNull_UsesDefaultEndpoint()
        {
            var credential = new DefaultAzureCredential();
            var client = new LogsQueryClient(credential);
            Assert.AreEqual(LogsQueryAudience.AzurePublicCloud.ToString(), client.Endpoint.OriginalString);
        }

        [Test]
        public void Constructor_WhenEndpointIsNull_UsesOptionsAudience()
        {
            var credential = new DefaultAzureCredential();
            var options = new LogsQueryClientOptions
            {
                Audience = "https://custom.audience"
            };

            var client = new LogsQueryClient(credential, options);

            // When endpoint is not passed in, use Audience to contstruct the endpoint
            Assert.AreEqual("https://custom.audience", client.Endpoint.OriginalString);
        }

        [Test]
        public void Constructor_WhenOptionsDoesNotMatchAudience()
        {
            var endpoint = new Uri("https://custom.audience");
            var credential = new DefaultAzureCredential();
            var options = new LogsQueryClientOptions
            {
                Audience = "https://customs.audience"
            };

            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => new LogsQueryClient(endpoint, credential, options)));
        }

        [Test]
        public void Constructor_WhenOptionsIsNull_UsesEndpoint()
        {
            var endpoint = new Uri("https://custom.audience");
            var credential = new DefaultAzureCredential();

            var client = new LogsQueryClient(endpoint, credential);

            Assert.AreEqual(new Uri("https://custom.audience"), client.Endpoint);
        }

        [Test]
        public void Constructor_WhenOptionsIsNull_UsesEndpointSlash()
        {
            var endpoint = new Uri("https://custom.audience//");
            var credential = new DefaultAzureCredential();

            var client = new LogsQueryClient(endpoint, credential);

            Assert.AreEqual("https://custom.audience//", client.Endpoint.AbsoluteUri);
        }

        [Test]
        public void Constructor_WhenOptionsIsValid_UsesOptionsAsUri()
        {
            var credential = new DefaultAzureCredential();
            var options = new LogsQueryClientOptions
            {
                Audience = LogsQueryAudience.AzureGovernment
            };

            var client = new LogsQueryClient(credential, options);

            Assert.AreEqual(new Uri(LogsQueryAudience.AzureGovernment.ToString()), client.Endpoint);
        }

        [Test]
        public void Constructor_WhenOptionsIsNull_EndpointIsNull()
        {
            var credential = new DefaultAzureCredential();
            var client = new LogsQueryClient(credential);

            Assert.AreEqual(new Uri(LogsQueryAudience.AzurePublicCloud.ToString()), client.Endpoint);
        }
    }
}
