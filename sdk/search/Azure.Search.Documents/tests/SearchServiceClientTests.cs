// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchServiceClientTests : SearchTestBase
    {
        public SearchServiceClientTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Constructor()
        {
            var serviceName = "my-svc-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var service = new SearchServiceClient(endpoint, new AzureKeyCredential("fake"));
            Assert.NotNull(service);
            Assert.AreEqual(endpoint, service.Endpoint);
            Assert.AreEqual(serviceName, service.ServiceName);

            Assert.Throws<ArgumentNullException>(() => new SearchServiceClient(null, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchServiceClient(endpoint, null));
            Assert.Throws<ArgumentException>(() => new SearchServiceClient(new Uri("http://bing.com"), null));
        }

        [Test]
        public void GetSearchIndexClient()
        {
            var serviceName = "my-svc-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var service = new SearchServiceClient(endpoint, new AzureKeyCredential("fake"));

            var indexName = "my-index-name";
            var index = service.GetSearchIndexClient(indexName);
            Assert.NotNull(index);
            Assert.AreEqual(endpoint, index.Endpoint);
            Assert.AreEqual(serviceName, index.ServiceName);
            Assert.AreEqual(indexName, index.IndexName);

            Assert.Throws<ArgumentNullException>(() => service.GetSearchIndexClient(null));
            Assert.Throws<ArgumentException>(() => service.GetSearchIndexClient(string.Empty));
        }

        private class TestPipelinePolicy : HttpPipelineSynchronousPolicy
        {
            public int RequestCount { get; private set; }
            public override void OnSendingRequest(HttpMessage message) => RequestCount++;
        }

        [Test]
        public async Task IndexSharesPipeline()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            TestPipelinePolicy custom = new TestPipelinePolicy();
            Assert.AreEqual(0, custom.RequestCount);

            SearchClientOptions options = new SearchClientOptions(ServiceVersion);
            options.AddPolicy(custom, HttpPipelinePosition.PerCall);
            SearchServiceClient client = resources.GetServiceClient(options);

            SearchIndexClient index = client.GetSearchIndexClient(resources.IndexName);
            _ = await index.GetDocumentCountAsync();

            Assert.AreEqual(1, custom.RequestCount);
        }

        [Test]
        public async Task ClientRequestIdRountrips()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchServiceClient client = resources.GetServiceClient();
            Guid id = Recording.Random.NewGuid();
            Response<SearchServiceStatistics> response =
                await client.GetServiceStatisticsAsync(
                    new SearchRequestOptions { ClientRequestId = id });

            // TODO: #10604 - C# generator doesn't properly support ClientRequestId yet
            // (Assertion is here to remind us to fix this when we do - just
            // change to AreEqual and re-record)
            Assert.AreNotEqual(id.ToString(), response.GetRawResponse().ClientRequestId);
        }

        [Test]
        public void DiagnosticsAreUnique()
        {
            // Make sure we're not repeating Header/Query names already defined
            // in the base ClientOptions
            SearchClientOptions options = new SearchClientOptions();
            Assert.IsEmpty(GetDuplicates(options.Diagnostics.LoggedHeaderNames));
            Assert.IsEmpty(GetDuplicates(options.Diagnostics.LoggedQueryParameters));

            // CollectionAssert.Unique doesn't give you the duplicate values
            // which is less helpful than it could be
            static string GetDuplicates(IEnumerable<string> values)
            {
                List<string> duplicates = new List<string>();
                HashSet<string> unique = new HashSet<string>();
                foreach (string value in values)
                {
                    if (!unique.Add(value))
                    {
                        duplicates.Add(value);
                    }
                }
                return string.Join(", ", duplicates);
            }
        }

        [Test]
        public async Task GetServiceStatistics()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchServiceClient client = resources.GetServiceClient();
            Response<SearchServiceStatistics> response = await client.GetServiceStatisticsAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Counters);
            Assert.IsNotNull(response.Value.Counters.DataSourceCounter);
            Assert.IsNotNull(response.Value.Counters.DocumentCounter);
            Assert.IsNotNull(response.Value.Counters.IndexCounter);
            Assert.IsNotNull(response.Value.Counters.IndexerCounter);
            Assert.IsNotNull(response.Value.Counters.StorageSizeCounter);
            Assert.IsNotNull(response.Value.Counters.SynonymMapCounter);
            Assert.IsNotNull(response.Value.Limits);

            Assert.NotZero(response.Value.Counters.IndexCounter.Quota ?? 0L);
            Assert.AreEqual(1, response.Value.Counters.IndexCounter.Usage);
        }

        [Test]
        public void CreateIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchServiceClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateIndex(null));
            Assert.AreEqual("index", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateIndexAsync(null));
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        public async Task CreateIndex()
        {
            await using SearchResources resources = await SearchResources.CreateWithNoIndexesAsync(this);

            string indexName = Recording.Random.GetName(8);
            var expectedIndex = new SearchIndex(indexName)
            {
                Fields =
                {
                    new SimpleField("hotelId", DataType.String) { IsKey = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SearchableField("hotelName") { IsFilterable = true, IsSortable = true },
                    new SearchableField("description") { Analyzer = AnalyzerName.EnLucene },
                    new SearchableField("descriptionFr") { Analyzer = AnalyzerName.FrLucene },
                    new SearchableField("category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SearchableField("tags", collection: true) { IsFilterable = true, IsFacetable = true },
                    new SimpleField("parkingIncluded", DataType.Boolean) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SimpleField("smokingAllowed", DataType.Boolean) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SimpleField("lastRenovationDate", DataType.DateTimeOffset) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SimpleField("rating", DataType.Int32) { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SimpleField("location", DataType.GeographyPoint) { IsFilterable = true, IsSortable = true },
                    new ComplexField("address")
                    {
                        Fields =
                        {
                            new SearchableField("streetAddress"),
                            new SearchableField("city") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("stateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("country") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("postalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                        },
                    },
                    new ComplexField("rooms", collection: true)
                    {
                        Fields =
                        {
                            new SearchableField("description") { Analyzer = AnalyzerName.EnLucene },
                            new SearchableField("descriptionFr") { Analyzer = AnalyzerName.FrLucene },
                            new SearchableField("type") { IsFilterable = true, IsFacetable = true },
                            new SimpleField("baseRate", DataType.Double) { IsFilterable = true, IsFacetable = true },
                            new SearchableField("bedOptions") { IsFilterable = true, IsFacetable = true },
                            new SimpleField("sleepsCount", DataType.Int32) { IsFilterable = true, IsFacetable = true },
                            new SimpleField("smokingAllowed", DataType.Boolean) { IsFilterable = true, IsFacetable = true },
                            new SearchableField("tags", collection: true) { IsFilterable = true, IsFacetable = true },
                        },
                    },
                },
                Suggesters = new[]
                {
                    new Suggester("sg", "description", "hotelName"),
                },
                ScoringProfiles = new[]
                {
                    new ScoringProfile("nearest")
                    {
                        FunctionAggregation = ScoringFunctionAggregation.Sum,
                        Functions = new[]
                        {
                            new DistanceScoringFunction("location", 2, new DistanceScoringParameters("myloc", 100)),
                        },
                    },
                },
            };

            SearchServiceClient client = resources.GetServiceClient();
            SearchIndex actualIndex = await client.CreateIndexAsync(expectedIndex);

            Assert.AreEqual(expectedIndex.Name, actualIndex.Name);
            Assert.That(actualIndex.Fields, Is.EqualTo(expectedIndex.Fields).Using(SearchFieldComparer.Shared));
            Assert.AreEqual(expectedIndex.Suggesters.Count, actualIndex.Suggesters.Count);
            Assert.AreEqual(expectedIndex.Suggesters[0].Name, actualIndex.Suggesters[0].Name);
            Assert.AreEqual(expectedIndex.ScoringProfiles.Count, actualIndex.ScoringProfiles.Count);
            Assert.AreEqual(expectedIndex.ScoringProfiles[0].Name, actualIndex.ScoringProfiles[0].Name);
        }

        [Test]
        public void GetIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchServiceClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetIndex(null));
            Assert.AreEqual("indexName", ex.ParamName);

            ex = Assert.Throws<ArgumentException>(() => service.GetIndex(string.Empty));
            Assert.AreEqual("indexName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetIndexAsync(null));
            Assert.AreEqual("indexName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentException>(() => service.GetIndexAsync(string.Empty));
            Assert.AreEqual("indexName", ex.ParamName);
        }

        [Test]
        public async Task GetIndex()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            SearchServiceClient client = resources.GetServiceClient();
            SearchIndex index = await client.GetIndexAsync(resources.IndexName);

            // TODO: Replace with comparison of actual SearchIndex once test framework uses Azure.Search.Documents instead.
            Assert.AreEqual(resources.IndexName, index.Name);
            Assert.AreEqual(13, index.Fields.Count);
        }
    }
}
