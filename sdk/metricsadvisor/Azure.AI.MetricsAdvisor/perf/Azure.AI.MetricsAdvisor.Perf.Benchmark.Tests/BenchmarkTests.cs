// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using BenchmarkDotNet.Attributes;

namespace Azure.AI.MetricsAdvisor.Perf.Benchmark.Tests
{
    [MemoryDiagnoser]
    public class BenchmarkTests
    {
        [Benchmark]
        public async Task<bool> GetDataFeed()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(_dataFeedJson);
            var endpoint = new Uri("http://example.metricsadvisor.com");
            var credential = new MetricsAdvisorKeyCredential("fake-subscription", "fake-key");

            MetricsAdvisorClientsOptions options = new MetricsAdvisorClientsOptions();
            options.Transport = new MockTransport(mockResponse);

            MetricsAdvisorAdministrationClient client = new MetricsAdvisorAdministrationClient(endpoint, credential, options);
            await client.GetDataFeedAsync(Guid.NewGuid().ToString()).ConfigureAwait(false);

            return true;
        }

        [Benchmark]
        public async Task<bool> CreateDataFeed()
        {
            var createMockResponse = new MockResponse(201);
            createMockResponse.SetContent(_dataFeedJson);
            createMockResponse.AddHeader(new HttpHeader("Location", _locationHeader));
            var getMockResponse = new MockResponse(200);
            getMockResponse.SetContent(_dataFeedJson);
            var endpoint = new Uri("http://example.metricsadvisor.com");
            var credential = new MetricsAdvisorKeyCredential("fake-subscription", "fake-key");

            MetricsAdvisorClientsOptions options = new MetricsAdvisorClientsOptions();
            options.Transport = new MockTransport(new[] { createMockResponse, getMockResponse });

            MetricsAdvisorAdministrationClient client = new MetricsAdvisorAdministrationClient(endpoint, credential, options);
            await client.CreateDataFeedAsync(GetDataFeedInstance()).ConfigureAwait(false);

            return true;
        }

        [Benchmark]
        public async Task<bool> UpdateDataFeed()
        {
            var getMockResponse = new MockResponse(200);
            getMockResponse.SetContent(_dataFeedJson);
            var updateMockResponse = new MockResponse(200);
            updateMockResponse.SetContent(_dataFeedJson);
            var endpoint = new Uri("http://example.metricsadvisor.com");
            var credential = new MetricsAdvisorKeyCredential("fake-subscription", "fake-key");

            MetricsAdvisorClientsOptions options = new MetricsAdvisorClientsOptions();
            options.Transport = new MockTransport(new[] { getMockResponse, updateMockResponse });

            MetricsAdvisorAdministrationClient client = new MetricsAdvisorAdministrationClient(endpoint, credential, options);
            var datafeed = await client.GetDataFeedAsync(Guid.NewGuid().ToString()).ConfigureAwait(false);
            await client.UpdateDataFeedAsync(datafeed).ConfigureAwait(false);

            return true;
        }

        [Benchmark]
        public async Task<bool> DeleteDataFeed()
        {
            var mockResponse = new MockResponse(204);
            var endpoint = new Uri("http://example.metricsadvisor.com");
            var credential = new MetricsAdvisorKeyCredential("fake-subscription", "fake-key");

            MetricsAdvisorClientsOptions options = new MetricsAdvisorClientsOptions();
            options.Transport = new MockTransport(mockResponse);

            MetricsAdvisorAdministrationClient client = new MetricsAdvisorAdministrationClient(endpoint, credential, options);
            await client.DeleteDataFeedAsync("8be0d927-818d-4106-afc0-fa474ed96aab").ConfigureAwait(false);

            return true;
        }

        [Benchmark]
        public async Task<bool> GetDataFeeds()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(_dataFeedsJson);
            var endpoint = new Uri("http://example.metricsadvisor.com");
            var credential = new MetricsAdvisorKeyCredential("fake-subscription", "fake-key");

            MetricsAdvisorClientsOptions clientOptions = new MetricsAdvisorClientsOptions();
            clientOptions.Transport = new MockTransport(mockResponse);

            MetricsAdvisorAdministrationClient client = new MetricsAdvisorAdministrationClient(endpoint, credential, clientOptions);
            var options = new GetDataFeedsOptions();
            int i = 0;
            int count = 3;
            await foreach (var _ in client.GetDataFeedsAsync(options).ConfigureAwait(false))
            {
                if (++i >= count)
                {
                    break;
                }
            }

            return true;
        }

        private static DataFeed GetDataFeedInstance()
        {
            var dataSource = new AzureBlobDataFeedSource("secret", "container", "template");
            var ingestionStartTime = DateTimeOffset.Parse("2020-08-01T00:00:00Z");

            return new DataFeed()
            {
                Name = "net-perf-" + Guid.NewGuid(),
                DataSource = dataSource,
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
                Schema = new DataFeedSchema() { MetricColumns = { new("cost") } },
                IngestionSettings = new DataFeedIngestionSettings(ingestionStartTime)
            };
        }

        private readonly string _dataFeedJson =
            "{" +
            "    \"dataFeedId\": \"8be0d927-818d-4106-afc0-fa474ed96aab\"," +
            "    \"dataFeedName\": \"js-test-postgreSqlFeed-162309304089009590\"," +
            "    \"metrics\": [" +
            "     {" +
            "          \"metricId\": \"1049161c-2e81-462b-b8e0-f1f5447db8cb\"," +
            "          \"metricName\": \"cost\"," +
            "          \"metricDisplayName\": \"cost\"," +
            "          \"metricDescription\": \"\"" +
            "      }" +
            "     ]," +
            "    \"fillMissingPointType\": \"CustomValue\"," +
            "    \"fillMissingPointValue\": 555.0" +
            "}";

        private readonly string _dataFeedsJson =
            "{" +
            "    \"value\": [" +
            "       {" +
            "           \"dataFeedId\": \"8be0d927-818d-4106-afc0-fa474ed96aab\"," +
            "           \"dataFeedName\": \"js-test-postgreSqlFeed-162309304089009590\"," +
            "           \"metrics\": [" +
            "               {" +
            "                   \"metricId\": \"1049161c-2e81-462b-b8e0-f1f5447db8cb\"," +
            "                   \"metricName\": \"cost\"," +
            "                   \"metricDisplayName\": \"cost\"," +
            "                   \"metricDescription\": \"\"" +
            "               }" +
            "          ]," +
            "          \"fillMissingPointType\": \"CustomValue\"," +
            "          \"fillMissingPointValue\": 555.0" +
            "       }," +
            "       {" +
            "           \"dataFeedId\": \"587e4bab-5c6f-4a46-b429-cfe4a3355845\"," +
            "           \"dataFeedName\": \"js-test-dataLakeGenFeed-162309300293600791\"," +
            "           \"metrics\": [" +
            "               {" +
            "                   \"metricId\": \"56ef3096-d727-482d-a931-9bbb9b1e31cf\"," +
            "                   \"metricName\": \"cost\"," +
            "                   \"metricDisplayName\": \"cost\"," +
            "                   \"metricDescription\": \"\"" +
            "               }" +
            "           ]," +
            "           \"fillMissingPointType\": \"CustomValue\"," +
            "           \"fillMissingPointValue\": 555.0" +
            "       }," +
            "       {" +
            "           \"dataFeedId\": \"8ac9a082-075a-415a-a51f-398ef5a1953f\"," +
            "           \"dataFeedName\": \"js-test-mySqlFeed-162309299257506851\"," +
            "           \"metrics\": [" +
            "               {" +
            "                   \"metricId\": \"9e8d8cfb-d4b3-44cc-b795-72d8e4e0b719\"," +
            "                   \"metricName\": \"cost\"," +
            "                   \"metricDisplayName\": \"cost\"," +
            "                   \"metricDescription\": \"\"" +
            "               }" +
            "           ]," +
            "           \"fillMissingPointType\": \"CustomValue\"," +
            "           \"fillMissingPointValue\": 555.0" +
            "       }" +
            "   ]" +
            "}";

        private readonly string _locationHeader = "https://js-metrics-advisor.cognitiveservices.azure.com/metricsadvisor/v1.0/dataFeeds/568f493f-cae8-4334-bfef-50725bf9303e";
    }
}
