// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DataFeedSourcesTests : MockClientTestBase
    {
        private static object[] CreateDataSourceTestCases =
        {
            new object[] { new AzureApplicationInsightsDataFeedSource("mock", "secret", "mock", "mock"), "apiKey" },
            new object[] { new AzureBlobDataFeedSource("secret", "mock", "mock"), "connectionString" },
            new object[] { new AzureCosmosDbDataFeedSource("secret", "mock", "mock", "mock"), "connectionString" },
            new object[] { new AzureDataExplorerDataFeedSource("secret", "mock"), "connectionString" },
            new object[] { new AzureDataLakeStorageGen2DataFeedSource("mock", "secret", "mock", "mock", "mock"), "accountKey" },
            new object[] { new AzureEventHubsDataFeedSource("secret", "mock"), "connectionString" },
            new object[] { new AzureTableDataFeedSource("secret", "mock", "mock"), "connectionString" },
            new object[] { new InfluxDbDataFeedSource("secret", "mock", "mock", "mock", "mock"), "connectionString" },
            new object[] { new InfluxDbDataFeedSource("mock", "mock", "mock", "secret", "mock"), "password" },
            new object[] { new LogAnalyticsDataFeedSource("mock", "mock", "mock", "secret", "mock"), "clientSecret" },
            new object[] { new MongoDbDataFeedSource("secret", "mock", "mock"), "connectionString" },
            new object[] { new MySqlDataFeedSource("secret", "mock"), "connectionString" },
            new object[] { new PostgreSqlDataFeedSource("secret", "mock"), "connectionString" },
            new object[] { new SqlServerDataFeedSource("secret", "mock"), "connectionString" }
        };

        private static object[] UpdateDataSourceTestCases =
        {
            new object[] { new AzureApplicationInsightsDataFeedSource("mock", "mock", "mock", "mock"), "apiKey" },
            new object[] { new AzureBlobDataFeedSource("mock", "mock", "mock"), "connectionString" },
            new object[] { new AzureCosmosDbDataFeedSource("mock", "mock", "mock", "mock"), "connectionString" },
            new object[] { new AzureDataExplorerDataFeedSource("mock", "mock"), "connectionString" },
            new object[] { new AzureDataLakeStorageGen2DataFeedSource("mock", "mock", "mock", "mock", "mock"), "accountKey" },
            new object[] { new AzureEventHubsDataFeedSource("mock", "mock"), "connectionString" },
            new object[] { new AzureTableDataFeedSource("mock", "mock", "mock"), "connectionString" },
            new object[] { new InfluxDbDataFeedSource("mock", "mock", "mock", "mock", "mock"), "connectionString" },
            new object[] { new InfluxDbDataFeedSource("mock", "mock", "mock", "mock", "mock"), "password" },
            new object[] { new LogAnalyticsDataFeedSource("mock", "mock", "mock", "mock", "mock"), "clientSecret" },
            new object[] { new MongoDbDataFeedSource("mock", "mock", "mock"), "connectionString" },
            new object[] { new MySqlDataFeedSource("mock", "mock"), "connectionString" },
            new object[] { new PostgreSqlDataFeedSource("mock", "mock"), "connectionString" },
            new object[] { new SqlServerDataFeedSource("mock", "mock"), "connectionString" }
        };

        public DataFeedSourcesTests(bool isAsync) : base(isAsync)
        {
        }

        private string DataFeedResponseContent => @"
        {
            ""dataSourceType"": ""SqlServer"",
            ""dataSourceParameter"": {},
            ""metrics"": [],
            ""fillMissingPointType"": ""NoFilling""
        }
        ";

        [Test]
        [TestCaseSource(nameof(CreateDataSourceTestCases))]
        public async Task DataFeedSourceSendsSecretDuringCreation(DataFeedSource dataSource, string secretPropertyName)
        {
            MockResponse createResponse = new MockResponse(201);
            createResponse.AddHeader(new HttpHeader("Location", $"https://fakeresource.cognitiveservices.azure.com/metricsadvisor/v1.0/dataFeeds/{FakeGuid}"));

            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(DataFeedResponseContent);

            MockTransport mockTransport = new MockTransport(createResponse, getResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);
            DataFeed dataFeed = new DataFeed()
            {
                Name = "name",
                DataSource = dataSource,
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
                Schema = new DataFeedSchema(),
                IngestionSettings = new DataFeedIngestionSettings(DateTimeOffset.UtcNow)
            };

            dataFeed.Schema.MetricColumns.Add(new DataFeedMetric("metric"));

            await adminClient.CreateDataFeedAsync(dataFeed);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);
            string expectedSubstring = $"\"{secretPropertyName}\":\"secret\"";

            Assert.That(content, Contains.Substring(expectedSubstring));
        }

        [Test]
        [TestCaseSource(nameof(UpdateDataSourceTestCases))]
        public async Task DataFeedSourceSendsSecretDuringUpdate(DataFeedSource dataSource, string secretPropertyName)
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataFeedResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            UpdateSecret(dataSource, secretPropertyName);

            DataFeed dataFeed = new DataFeed()
            {
                Id = FakeGuid,
                Name = "name",
                DataSource = dataSource,
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
                Schema = new DataFeedSchema(),
                IngestionSettings = new DataFeedIngestionSettings(DateTimeOffset.UtcNow)
            };

            await adminClient.UpdateDataFeedAsync(dataFeed);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, Contains.Substring($"\"{secretPropertyName}\":\"new_secret\""));
        }

        private void UpdateSecret(DataFeedSource dataSource, string secretPropertyName)
        {
            switch (dataSource)
            {
                case AzureApplicationInsightsDataFeedSource d:
                    d.UpdateApiKey("new_secret");
                    break;
                case AzureBlobDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                case AzureCosmosDbDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                case AzureDataExplorerDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                case AzureDataLakeStorageGen2DataFeedSource d:
                    d.UpdateAccountKey("new_secret");
                    break;
                case AzureEventHubsDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                case AzureTableDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                case InfluxDbDataFeedSource d:
                    if (secretPropertyName == "connectionString") d.UpdateConnectionString("new_secret");
                    else d.UpdatePassword("new_secret");
                    break;
                case LogAnalyticsDataFeedSource d:
                    d.UpdateClientSecret("new_secret");
                    break;
                case MongoDbDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                case MySqlDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                case PostgreSqlDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                case SqlServerDataFeedSource d:
                    d.UpdateConnectionString("new_secret");
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown data source type: {dataSource.GetType()}");
            };
        }

        private string ReadContent(Request request)
        {
            using MemoryStream stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
