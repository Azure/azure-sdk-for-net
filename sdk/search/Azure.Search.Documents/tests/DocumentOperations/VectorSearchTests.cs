﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2023_07_01_Preview)]
    public partial class VectorSearchTests : SearchTestBase
    {
        public VectorSearchTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        private async Task AssertKeysEqual<T>(
            SearchResults<T> response,
            Func<SearchResult<T>, string> keyAccessor,
            params string[] expectedKeys)
        {
            List<SearchResult<T>> docs = await response.GetResultsAsync().ToListAsync();
            CollectionAssert.AreEquivalent(expectedKeys, docs.Select(keyAccessor));
        }

        [Test]
        public async Task SingleVectorSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
            await Task.Delay(TimeSpan.FromSeconds(1));

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                   null,
                   new SearchOptions
                   {
                       Vectors = { new SearchQueryVector { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "descriptionVector" } } },
                       Select = { "hotelId", "hotelName" }
                   });

            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "3", "5", "1");
        }

        [Test]
        public async Task SingleVectorSearchWithFilter()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                    null,
                    new SearchOptions
                    {
                        Vectors = { new SearchQueryVector { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "descriptionVector" } } },
                        Filter = "category eq 'Budget'",
                        Select = { "hotelId", "hotelName", "category" }
                    });

            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "3", "5", "4");
        }

        [Test]
        public async Task SimpleHybridSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                    "Top hotels in town",
                    new SearchOptions
                    {
                        Vectors = { new SearchQueryVector { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "descriptionVector" } } },
                        Select = { "hotelId", "hotelName" },
                    });

            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "3", "1", "2", "10", "4", "5", "9");
        }

        [Test]
        [PlaybackOnly("The availability of Semantic Search is limited to specific regions, as indicated in the list provided here: https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=search. Due to this limitation, the deployment of resources for weekly test pipeline for setting the \"semanticSearch\": \"free\" fails in the UsGov and China cloud regions.")]
        public async Task SemanticHybridSearch()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            var vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

            SearchResults<Hotel> response = await resources.GetSearchClient().SearchAsync<Hotel>(
                    "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
                    new SearchOptions
                    {
                        Vectors = { new SearchQueryVector { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "descriptionVector" } } },
                        Select = { "hotelId", "hotelName", "description", "category" },
                        QueryType = SearchQueryType.Semantic,
                        QueryLanguage = QueryLanguage.EnUs,
                        SemanticConfigurationName = "my-semantic-config",
                        QueryCaption = QueryCaptionType.Extractive,
                        QueryAnswer = QueryAnswerType.Extractive,
                    });

            Assert.NotNull(response.Answers);
            Assert.AreEqual(1, response.Answers.Count);
            Assert.AreEqual("9", response.Answers[0].Key);
            Assert.NotNull(response.Answers[0].Highlights);
            Assert.NotNull(response.Answers[0].Text);

            await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
            {
                Hotel doc = result.Document;

                Assert.NotNull(result.Captions);

                var caption = result.Captions.FirstOrDefault();
                Assert.NotNull(caption.Highlights, "Caption highlight is null");
                Assert.NotNull(caption.Text, "Caption text is null");
            }

            await AssertKeysEqual(
                response,
                h => h.Document.HotelId,
                "9", "3", "2", "5", "10", "1", "4");
        }

        [Test]
        public async Task UpdateExistingIndexToAddVectorFields()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            string indexName = Recording.Random.GetName();
            resources.IndexName = indexName;

            // Create Index
            SearchIndex index = new SearchIndex(indexName)
            {
                Fields =
                {
                    new SimpleField("id", SearchFieldDataType.String) { IsKey = true },
                    new SearchableField("name") { IsFilterable = true, IsSortable = false },
                },
            };

            SearchIndexClient indexClient = resources.GetIndexClient();
            await indexClient.CreateIndexAsync(index);

            // Upload data
            SearchDocument document = new SearchDocument
            {
                ["id"] = "1",
                ["name"] = "Countryside Hotel"
            };

            SearchClient searchClient = resources.GetSearchClient();
            await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(new[] { document }));
            await resources.WaitForIndexingAsync();

            // Get the document
            Response<SearchDocument> response = await searchClient.GetDocumentAsync<SearchDocument>((string)document["id"]);
            Assert.AreEqual(document["id"], response.Value["id"]);
            Assert.AreEqual(document["name"], response.Value["name"]);

            // Update created index to add vector field

            // Get created index
            SearchIndex createdIndex = await indexClient.GetIndexAsync(indexName);

            // Add vector
            var vectorField = new SearchField("descriptionVector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
            {
                IsSearchable = true,
                VectorSearchDimensions = 1536,
                VectorSearchConfiguration = "my-vector-config"
            };
            createdIndex.Fields.Add(vectorField);

            createdIndex.VectorSearch = new()
            {
                AlgorithmConfigurations =
                    {
                        new HnswVectorSearchAlgorithmConfiguration( "my-vector-config")
                    }
            };

            // Update index
            SearchIndex updatedIndex = await indexClient.CreateOrUpdateIndexAsync(createdIndex);
            Assert.AreEqual(indexName, updatedIndex.Name);
            Assert.AreEqual(3, updatedIndex.Fields.Count);

            // Update document to add vector field's data

            // Get the dcoument
            SearchDocument resultDoc = await searchClient.GetDocumentAsync<SearchDocument>((string)document["id"]);

            // Update document to add vector field data
            resultDoc.Add("descriptionVector", VectorSearchEmbeddings.DefaultVectorizeDescription);

            await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Merge(new[] { resultDoc }));
            await resources.WaitForIndexingAsync();

            // Get the document
            response = await searchClient.GetDocumentAsync<SearchDocument>((string)document["id"]);
            Assert.AreEqual(document["id"], response.Value["id"]);
            Assert.AreEqual(document["name"], response.Value["name"]);
            Assert.IsNotNull(response.Value["descriptionVector"]);

            Assert.AreEqual(updatedIndex.Name, createdIndex.Name);
        }

        [Test]
        public async Task CreateIndexUsingFieldBuilder()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            string indexName = Recording.Random.GetName();
            resources.IndexName = indexName;

            // Create Index
            SearchIndex index = new SearchIndex(indexName)
            {
                Fields = new FieldBuilder().Build(typeof(Model)),
                VectorSearch = new()
                {
                    AlgorithmConfigurations =
                    {
                        new HnswVectorSearchAlgorithmConfiguration( "my-vector-config")
                    }
                }
            };

            SearchIndexClient indexClient = resources.GetIndexClient();
            await indexClient.CreateIndexAsync(index);

            SearchIndex createdIndex = await indexClient.GetIndexAsync(indexName);
            Assert.AreEqual(indexName, createdIndex.Name);
            Assert.AreEqual(index.Fields.Count, createdIndex.Fields.Count);
        }

        private class Model
        {
            [SimpleField(IsKey = true, IsFilterable = true, IsSortable = true)]
            public string Id { get; set; }

            [SearchableField(IsFilterable = true, IsSortable = true)]
            public string Name { get; set; }

            [SearchableField(AnalyzerName = "en.microsoft")]
            public string Description { get; set; }

            [SearchableField(VectorSearchDimensions = "1536", VectorSearchConfiguration = "my-vector-config")]
            public IReadOnlyList<float> DescriptionVector { get; set; }
        }
    }
}
