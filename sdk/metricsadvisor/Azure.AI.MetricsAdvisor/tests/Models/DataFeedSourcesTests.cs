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
        private static object[] DataSourceTestCases =
        {
            new object[] { new AzureApplicationInsightsDataFeedSource("mock", "secret", "mock", "mock"), "\"apiKey\":\"secret\"" },
            new object[] { new AzureBlobDataFeedSource("secret", "mock", "mock"), "\"connectionString\":\"secret\"" },
            new object[] { new AzureCosmosDbDataFeedSource("secret", "mock", "mock", "mock"), "\"connectionString\":\"secret\"" },
            new object[] { new AzureDataExplorerDataFeedSource("secret", "mock"), "\"connectionString\":\"secret\"" },
            new object[] { new AzureDataLakeStorageGen2DataFeedSource("mock", "secret", "mock", "mock", "mock"), "\"accountKey\":\"secret\"" },
            new object[] { new AzureTableDataFeedSource("secret", "mock", "mock"), "\"connectionString\":\"secret\"" },
            new object[] { new InfluxDbDataFeedSource("secret", "mock", "mock", "mock", "mock"), "\"connectionString\":\"secret\"" },
            new object[] { new InfluxDbDataFeedSource("mock", "mock", "mock", "secret", "mock"), "\"password\":\"secret\"" },
            new object[] { new MongoDbDataFeedSource("secret", "mock", "mock"), "\"connectionString\":\"secret\"" },
            new object[] { new MySqlDataFeedSource("secret", "mock"), "\"connectionString\":\"secret\"" },
            new object[] { new PostgreSqlDataFeedSource("secret", "mock"), "\"connectionString\":\"secret\"" },
            new object[] { new SqlServerDataFeedSource("secret", "mock"), "\"connectionString\":\"secret\"" }
        };

        public DataFeedSourcesTests(bool isAsync) : base(isAsync)
        {
        }

        private string DataFeedResponseContent => @"
        {
            ""dataSourceType"": ""SqlServer"",
            ""dataSourceParameter"": {},
            ""metrics"": []
        }
        ";

        [Test]
        [TestCaseSource(nameof(DataSourceTestCases))]
        public async Task DataFeedSourceSendsSecretDuringCreation(DataFeedSource dataSource, string expectedSubstring)
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
                IngestionSettings = new DataFeedIngestionSettings() { IngestionStartTime = DateTimeOffset.UtcNow }
            };

            dataFeed.Schema.MetricColumns.Add(new DataFeedMetric("metric"));

            await adminClient.CreateDataFeedAsync(dataFeed);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, Contains.Substring(expectedSubstring));
        }

        private string ReadContent(Request request)
        {
            using MemoryStream stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
