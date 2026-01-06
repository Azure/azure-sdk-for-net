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
using Azure.Monitor.Query.Logs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Monitor.Query.Logs.Tests
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
                Assert.That(message.Request.Headers.TryGetValue("prefer", out preferHeader), Is.True);
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

            Assert.Multiple(() =>
            {
                Assert.That(preferHeader, Is.EqualTo("wait=600"));
                // The network timeout is adjusted with 15 sec buffer
                Assert.That(networkOverride, Is.EqualTo(TimeSpan.FromMinutes(10).Add(TimeSpan.FromSeconds(15))));
            });
        }

        [Test]
        public void CanSetServiceTimeoutForBatch_Mocked()
        {
            string preferHeader = null;
            TimeSpan? networkOverride = default;

            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                Assert.That(message.Request.Headers.TryGetValue("prefer", out preferHeader), Is.True);
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

            Assert.Multiple(() =>
            {
                // 3 minutes (180 sec) is the max out of all individual queries
                Assert.That(preferHeader, Is.EqualTo("wait=180"));
                // The network timeout is adjusted with 15 sec buffer
                Assert.That(networkOverride, Is.EqualTo(TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(15))));
            });
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
            batch.AddWorkspaceQuery("wid", "query", LogsQueryTimeRange.All);

            LogsBatchQueryResultCollection batchResults = await client.QueryBatchAsync(batch);
            Assert.That(batchResults.GetResult("0"), Is.Not.Null);
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

            await client.QueryWorkspaceAsync("", "", LogsQueryTimeRange.All);
            Assert.That(mockTransport.SingleRequest.Uri.ToString(), Does.StartWith("https://api.loganalytics.io"));
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        private static IEnumerable<object[]> GetAudience()
        {
            yield return new object[] { null, "https://api.loganalytics.io/.default" };
            yield return new object[] { LogsQueryAudience.AzurePublicCloud, "https://api.loganalytics.io/.default" };
            yield return new object[] { LogsQueryAudience.AzureGovernment, "https://api.loganalytics.us/.default" };
            yield return new object[] { LogsQueryAudience.AzureChina, "https://api.loganalytics.azure.cn/.default" };
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

            await client.QueryWorkspaceAsync("", "", LogsQueryTimeRange.All);
            Assert.That(scopes, Is.EqualTo(new[] { expectedScope }));
        }

        [Test]
        public void ExposesPublicEndpoint()
        {
            var client = new LogsQueryClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsQueryClientOptions());
            Assert.That(client.Endpoint, Is.EqualTo(new Uri("https://api.loganalytics.io")));
        }

        [Test]
        public void LogsQueryModelFactory_LogsQueryResult_ConvertBinaryDataToJsonElement()
        {
            var errorJson = @"{
                                ""code"": ""PartialError"",
                                ""message"": ""There were some errors when processing your query.""
                           }";
            var result = LogsQueryModelFactory.LogsQueryResult(new List<LogsTable>(), new BinaryData(errorJson), new BinaryData("{}"), new BinaryData("42"));
            Assert.Multiple(() =>
            {
                Assert.That(result.GetStatistics().ToString(), Is.EqualTo("{}"));
                Assert.That(result.GetVisualization().ToString(), Is.EqualTo("42"));
                Assert.That(result.Error.Code, Is.EqualTo("PartialError"));
                Assert.That(result.Error.Message, Is.EqualTo("There were some errors when processing your query."));
            });
        }

        [Test]
        public void ValidateMonitorModelFactoryTableCreation()
        {
            LogsTableColumn logsTableColumn0 = LogsQueryModelFactory.LogsTableColumn("column0", LogsColumnType.Datetime);
            LogsTableColumn logsTableColumn1 = LogsQueryModelFactory.LogsTableColumn("column1", LogsColumnType.Guid);
            LogsTableColumn logsTableColumn2 = LogsQueryModelFactory.LogsTableColumn("column2", LogsColumnType.Int);
            LogsTableColumn logsTableColumn3 = LogsQueryModelFactory.LogsTableColumn("column3", LogsColumnType.Long);
            LogsTableColumn logsTableColumn4 = LogsQueryModelFactory.LogsTableColumn("column4", LogsColumnType.Real);
            LogsTableColumn logsTableColumn5 = LogsQueryModelFactory.LogsTableColumn("column5", LogsColumnType.String);
            LogsTableColumn logsTableColumn6 = LogsQueryModelFactory.LogsTableColumn("column6", LogsColumnType.Timespan);
            LogsTableColumn logsTableColumn7 = LogsQueryModelFactory.LogsTableColumn("column7", LogsColumnType.Decimal);
            LogsTableColumn logsTableColumn8 = LogsQueryModelFactory.LogsTableColumn("column8", LogsColumnType.Bool);
            LogsTableColumn logsTableColumn9 = LogsQueryModelFactory.LogsTableColumn("column9", LogsColumnType.Dynamic);
            LogsTableColumn[] logsTableColumns = new LogsTableColumn[] { logsTableColumn0, logsTableColumn1, logsTableColumn2, logsTableColumn3, logsTableColumn4, logsTableColumn5, logsTableColumn6, logsTableColumn7, logsTableColumn8, logsTableColumn9};
            Object[] rowValues = new Object[] { "2015-12-31T23:59:59.9Z", "74be27de-1e4e-49d9-b579-fe0b331d3642", 12345, 1234567890123, 12345.6789, "string value", "00:00:10", "0.10101", false, "{\u0022a\u0022:123,\u0022b\u0022:\u0022hello\u0022,\u0022c\u0022:[1,2,3],\u0022d\u0022:{}}" };

            LogsTableRow logsTableRow = LogsQueryModelFactory.LogsTableRow(logsTableColumns, rowValues);
            LogsTableRow[] rowArray = new LogsTableRow[] { logsTableRow };
            LogsTable logsTable = LogsQueryModelFactory.LogsTable("tester", logsTableColumns.AsEnumerable(), rowArray.AsEnumerable());

            Assert.Multiple(() =>
            {
                Assert.That(logsTable.Name, Is.EqualTo("tester"));
                Assert.That(logsTable.Rows, Has.Count.EqualTo(1));
                Assert.That(logsTable.Columns, Has.Count.EqualTo(10));
            });

            Assert.Multiple(() =>
            {
                Assert.That(logsTable.Columns[0].Name, Is.EqualTo("column0"));
                Assert.That(logsTable.Columns[0].Type.ToString(), Is.EqualTo("datetime"));
                Assert.That(logsTable.Columns[1].Name, Is.EqualTo("column1"));
                Assert.That(logsTable.Columns[1].Type.ToString(), Is.EqualTo("guid"));
                Assert.That(logsTable.Columns[2].Name, Is.EqualTo("column2"));
                Assert.That(logsTable.Columns[2].Type.ToString(), Is.EqualTo("int"));
                Assert.That(logsTable.Columns[3].Name, Is.EqualTo("column3"));
                Assert.That(logsTable.Columns[3].Type.ToString(), Is.EqualTo("long"));
                Assert.That(logsTable.Columns[4].Name, Is.EqualTo("column4"));
                Assert.That(logsTable.Columns[4].Type.ToString(), Is.EqualTo("real"));
                Assert.That(logsTable.Columns[5].Name, Is.EqualTo("column5"));
                Assert.That(logsTable.Columns[5].Type.ToString(), Is.EqualTo("string"));
                Assert.That(logsTable.Columns[6].Name, Is.EqualTo("column6"));
                Assert.That(logsTable.Columns[6].Type.ToString(), Is.EqualTo("timespan"));
                Assert.That(logsTable.Columns[7].Name, Is.EqualTo("column7"));
                Assert.That(logsTable.Columns[7].Type.ToString(), Is.EqualTo("decimal"));
                Assert.That(logsTable.Columns[8].Name, Is.EqualTo("column8"));
                Assert.That(logsTable.Columns[8].Type.ToString(), Is.EqualTo("bool"));
                Assert.That(logsTable.Columns[9].Name, Is.EqualTo("column9"));
                Assert.That(logsTable.Columns[9].Type.ToString(), Is.EqualTo("dynamic"));
            });

            var expectedDate = DateTimeOffset.Parse("2015-12-31 23:59:59.9+00:00");

            Assert.That(logsTable.Rows[0].GetDateTimeOffset(0), Is.EqualTo(expectedDate));
            Assert.That(logsTable.Rows[0].GetObject("column0"), Is.EqualTo(expectedDate));
            Assert.That(logsTable.Rows[0].GetBoolean("column8"), Is.EqualTo(false));
            Assert.That(logsTable.Rows[0].GetBoolean(8), Is.EqualTo(false));
            Assert.That(logsTable.Rows[0].GetObject("column8"), Is.EqualTo(false));
            Assert.That(logsTable.Rows[0].GetGuid("column1"), Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
            Assert.That(logsTable.Rows[0].GetGuid(1), Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
            Assert.That(logsTable.Rows[0].GetObject("column1"), Is.EqualTo(Guid.Parse("74be27de-1e4e-49d9-b579-fe0b331d3642")));
            Assert.That(logsTable.Rows[0].GetInt32("column2"), Is.EqualTo(12345));
            Assert.That(logsTable.Rows[0].GetInt32(2), Is.EqualTo(12345));
            Assert.That(logsTable.Rows[0].GetObject("column2"), Is.EqualTo(12345));
            Assert.That(logsTable.Rows[0].GetInt64("column3"), Is.EqualTo(1234567890123));
            Assert.That(logsTable.Rows[0].GetInt64(3), Is.EqualTo(1234567890123));
            Assert.That(logsTable.Rows[0].GetObject("column3"), Is.EqualTo(1234567890123));
            Assert.That(logsTable.Rows[0].GetDouble("column4"), Is.EqualTo(12345.6789d));
            Assert.That(logsTable.Rows[0].GetDouble(4), Is.EqualTo(12345.6789d));
            Assert.That(logsTable.Rows[0].GetObject("column4"), Is.EqualTo(12345.6789d));
            Assert.That(logsTable.Rows[0].GetString("column5"), Is.EqualTo("string value"));
            Assert.That(logsTable.Rows[0].GetString(5), Is.EqualTo("string value"));
            Assert.That(logsTable.Rows[0].GetObject("column5"), Is.EqualTo("string value"));
            Assert.That(logsTable.Rows[0].GetTimeSpan("column6"), Is.EqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(logsTable.Rows[0].GetTimeSpan(6), Is.EqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(logsTable.Rows[0].GetObject("column6"), Is.EqualTo(TimeSpan.FromSeconds(10)));
            Assert.That(logsTable.Rows[0].GetDecimal("column7"), Is.EqualTo(0.10101m));
            Assert.That(logsTable.Rows[0].GetDecimal(7), Is.EqualTo(0.10101m));
            Assert.That(logsTable.Rows[0].GetObject("column7"), Is.EqualTo(0.10101m));
            Assert.That(logsTable.Rows[0].GetBoolean("column8"), Is.False);
            Assert.That(logsTable.Rows[0].GetBoolean(8), Is.False);
            Assert.That(logsTable.Rows[0].GetObject("column8"), Is.EqualTo(false));
            Assert.That(logsTable.Rows[0].GetDynamic(9).ToString(), Is.EqualTo("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}"));
            Assert.That(logsTable.Rows[0].GetDynamic("column9").ToString(), Is.EqualTo("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}"));
            Assert.That(logsTable.Rows[0].GetObject("column9").ToString(), Is.EqualTo("{\"a\":123,\"b\":\"hello\",\"c\":[1,2,3],\"d\":{}}"));
        }

        [Test]
        public void Constructor_WhenOptionsAndEndpointIsNull_UsesDefaultEndpoint()
        {
            var credential = new DefaultAzureCredential();
            var client = new LogsQueryClient(credential);
            Assert.That(client.Endpoint.OriginalString, Is.EqualTo(LogsQueryAudience.AzurePublicCloud.ToString()));
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
            Assert.That(client.Endpoint.OriginalString, Is.EqualTo("https://custom.audience"));
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

            Assert.That(client.Endpoint, Is.EqualTo(new Uri("https://custom.audience")));
        }

        [Test]
        public void Constructor_WhenOptionsIsNull_UsesEndpointSlash()
        {
            var endpoint = new Uri("https://custom.audience//");
            var credential = new DefaultAzureCredential();

            var client = new LogsQueryClient(endpoint, credential);

            Assert.That(client.Endpoint.AbsoluteUri, Is.EqualTo("https://custom.audience//"));
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

            Assert.That(client.Endpoint, Is.EqualTo(new Uri(LogsQueryAudience.AzureGovernment.ToString())));
        }

        [Test]
        public void Constructor_WhenOptionsIsNull_EndpointIsNull()
        {
            var credential = new DefaultAzureCredential();
            var client = new LogsQueryClient(credential);

            Assert.That(client.Endpoint, Is.EqualTo(new Uri(LogsQueryAudience.AzurePublicCloud.ToString())));
        }
    }
}
