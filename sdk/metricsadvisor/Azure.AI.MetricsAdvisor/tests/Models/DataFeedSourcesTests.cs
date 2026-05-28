// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
        private const string NewSecret = "new_secret";

        private static object[] CreateDataSourceTestCases =
        {
            new object[] { new AzureApplicationInsightsDataFeedSource("mock", "secret", "mock", "mock"), "apiKey" },
            new object[] { new AzureBlobDataFeedSource("secret", "mock", "mock"), "connectionString" },
            new object[] { new AzureCosmosDbDataFeedSource("secret", "mock", "mock", "mock"), "connectionString" },
            new object[] { new AzureDataExplorerDataFeedSource("secret", "mock"), "connectionString" },
            new object[] { new AzureDataLakeStorageDataFeedSource("mock", "secret", "mock", "mock", "mock"), "accountKey" },
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
            new object[] { new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", "mock"), "accountKey" },
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

        private string UnknownDataFeedContent => $@"
        {{
            ""dataFeedId"": ""{FakeGuid}"",
            ""dataFeedName"": ""unknownDataFeedName"",
            ""dataSourceType"": ""unknownType"",
            ""fillMissingPointType"": ""NoFilling"",
            ""dataFeedDescription"": ""unknown data feed description"",
            ""metrics"": [
                {{
                    ""metricId"": ""{FakeGuid}"",
                    ""metricName"": ""cost""
                }}
            ]
        }}
        ";

        [Test]
        public void AzureDataLakeStorageDataFeedSourceConstructorValidatesArguments()
        {
            Assert.That(() => new AzureDataLakeStorageDataFeedSource(null, "mock", "mock", "mock"), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("", "mock", "mock", "mock"), Throws.ArgumentException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", null, "mock", "mock"), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "", "mock", "mock"), Throws.ArgumentException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", null, "mock"), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", "", "mock"), Throws.ArgumentException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", null), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", ""), Throws.ArgumentException);

            Assert.That(() => new AzureDataLakeStorageDataFeedSource(null, "mock", "mock", "mock", "mock"), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("", "mock", "mock", "mock", "mock"), Throws.ArgumentException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", null, "mock", "mock", "mock"), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "", "mock", "mock", "mock"), Throws.ArgumentException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", null, "mock", "mock"), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", "", "mock", "mock"), Throws.ArgumentException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", null, "mock"), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "", "mock"), Throws.ArgumentException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", null), Throws.ArgumentNullException);
            Assert.That(() => new AzureDataLakeStorageDataFeedSource("mock", "mock", "mock", "mock", ""), Throws.ArgumentException);
        }

        [Test]
        public void SqlServerDataFeedSourceConstructorValidatesArguments()
        {
            Assert.That(() => new SqlServerDataFeedSource(null), Throws.ArgumentNullException);
            Assert.That(() => new SqlServerDataFeedSource(""), Throws.ArgumentException);

            Assert.That(() => new SqlServerDataFeedSource(null, "mock"), Throws.ArgumentNullException);
            Assert.That(() => new SqlServerDataFeedSource("", "mock"), Throws.ArgumentException);
            Assert.That(() => new SqlServerDataFeedSource("mock", null), Throws.ArgumentNullException);
            Assert.That(() => new SqlServerDataFeedSource("mock", ""), Throws.ArgumentException);
        }

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

            Assert.That(content, ContainsJsonString(secretPropertyName, "secret"));
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

            Assert.That(content, ContainsJsonString(secretPropertyName, NewSecret));
        }

        [Test]
        public async Task DataFeedSourceGetsUnknownDataFeed()
        {
            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(UnknownDataFeedContent);

            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(getResponse);
            DataFeed dataFeed = await adminClient.GetDataFeedAsync(FakeGuid);

            Assert.That(dataFeed.Id, Is.EqualTo(FakeGuid));
            Assert.That(dataFeed.Name, Is.EqualTo("unknownDataFeedName"));
            Assert.That(dataFeed.MissingDataPointFillSettings.FillType, Is.EqualTo(DataFeedMissingDataPointFillType.NoFilling));
            Assert.That(dataFeed.Description, Is.EqualTo("unknown data feed description"));

            DataFeedMetric metric = dataFeed.Schema.MetricColumns.Single();

            Assert.That(metric.Id, Is.EqualTo(FakeGuid));
            Assert.That(metric.Name, Is.EqualTo("cost"));
        }

        [Test]
        public async Task DataFeedSourceUpdatesUnknownDataFeed()
        {
            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(UnknownDataFeedContent);

            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(UnknownDataFeedContent);

            MockTransport mockTransport = new MockTransport(getResponse, updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);
            DataFeed dataFeed = await adminClient.GetDataFeedAsync(FakeGuid);

            dataFeed.Name = "newDataFeedName";
            dataFeed.MissingDataPointFillSettings = new DataFeedMissingDataPointFillSettings(DataFeedMissingDataPointFillType.PreviousValue);
            dataFeed.Description = "new description";

            await adminClient.UpdateDataFeedAsync(dataFeed);

            MockRequest request = mockTransport.Requests.Last();
            string content = ReadContent(request);

            Assert.That(request.Uri.Path, Contains.Substring(FakeGuid));
            Assert.That(content, ContainsJsonString("dataFeedName", "newDataFeedName"));
            Assert.That(content, ContainsJsonString("dataSourceType", "unknownType"));
            Assert.That(content, ContainsJsonString("fillMissingPointType", "PreviousValue"));
            Assert.That(content, ContainsJsonString("dataFeedDescription", "new description"));
        }

        private void UpdateSecret(DataFeedSource dataSource, string secretPropertyName)
        {
            switch (dataSource)
            {
                case AzureApplicationInsightsDataFeedSource d:
                    d.UpdateApiKey(NewSecret);
                    break;
                case AzureBlobDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                case AzureCosmosDbDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                case AzureDataExplorerDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                case AzureDataLakeStorageDataFeedSource d:
                    d.UpdateAccountKey(NewSecret);
                    break;
                case AzureEventHubsDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                case AzureTableDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                case InfluxDbDataFeedSource d:
                    if (secretPropertyName == "connectionString") d.UpdateConnectionString(NewSecret);
                    else d.UpdatePassword(NewSecret);
                    break;
                case LogAnalyticsDataFeedSource d:
                    d.UpdateClientSecret(NewSecret);
                    break;
                case MongoDbDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                case MySqlDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                case PostgreSqlDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                case SqlServerDataFeedSource d:
                    d.UpdateConnectionString(NewSecret);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown data source type: {dataSource.GetType()}");
            };
        }
    }
}
