﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using NUnit.Framework;
using Azure.Core.TestFramework;

namespace Azure.Search.Documents.Tests.Samples.VectorSearch
{
    public partial class VectorSearchUsingVectorizedQuery : SearchTestBase
    {
        public VectorSearchUsingVectorizedQuery(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task SingleVectorSearch()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Single_Vector_Search_UsingVectorizedQuery
                ReadOnlyMemory<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    new SearchOptions
                    {
                        VectorSearch = new()
                        {
                            Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } }
                        }
                    });

                int count = 0;
                Console.WriteLine($"Single Vector Search Results:");
                await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
                {
                    count++;
                    Hotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
                }
                Console.WriteLine($"Total number of search results:{count}");
                #endregion
                Assert.GreaterOrEqual(count, 1);
            }
            finally
            {
                await indexClient.DeleteIndexAsync(indexName);
            }
        }

        [Test]
        public async Task SingleVectorSearchWithFilter()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Filter_UsingVectorizedQuery
                ReadOnlyMemory<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    new SearchOptions
                    {
                        VectorSearch = new()
                        {
                            Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } }
                        },
                        Filter = "Category eq 'Luxury'"
                    });

                int count = 0;
                Console.WriteLine($"Single Vector Search With Filter Results:");
                await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
                {
                    count++;
                    Hotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
                }
                Console.WriteLine($"Total number of search results:{count}");
                #endregion
                Assert.GreaterOrEqual(count, 1);
            }
            finally
            {
                await indexClient.DeleteIndexAsync(indexName);
            }
        }

        [Test]
        public async Task SimpleHybridSearch()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Simple_Hybrid_Search_UsingVectorizedQuery
                ReadOnlyMemory<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                        "Top hotels in town",
                        new SearchOptions
                        {
                            VectorSearch = new()
                            {
                                Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } }
                            },
                        });

                int count = 0;
                Console.WriteLine($"Simple Hybrid Search Results:");
                await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
                {
                    count++;
                    Hotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
                }
                Console.WriteLine($"Total number of search results:{count}");
                #endregion
                Assert.GreaterOrEqual(count, 1);
            }
            finally
            {
                await indexClient.DeleteIndexAsync(indexName);
            }
        }

        [Test]
        public async Task MultiVectorQuerySearch()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Multi_Vector_Search_UsingVectorizedQuery
                ReadOnlyMemory<float> vectorizedDescriptionQuery = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
                ReadOnlyMemory<float> vectorizedCategoryQuery = VectorSearchEmbeddings.SearchVectorizeCategory; // "Luxury hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    new SearchOptions
                    {
                        VectorSearch = new()
                        {
                            Queries = {
                                new VectorizedQuery(vectorizedDescriptionQuery) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } },
                                new VectorizedQuery(vectorizedCategoryQuery) { KNearestNeighborsCount = 3, Fields = { "CategoryVector" } } }
                        },
                    });

                int count = 0;
                Console.WriteLine($"Multi Vector Search Results:");
                await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
                {
                    count++;
                    Hotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
                }
                Console.WriteLine($"Total number of search results:{count}");
                #endregion
                Assert.GreaterOrEqual(count, 1);
            }
            finally
            {
                await indexClient.DeleteIndexAsync(indexName);
            }
        }

        [Test]
        public async Task MultiFieldVectorQuerySearch()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Multi_Fields_Vector_Search_UsingVectorizedQuery
                ReadOnlyMemory<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    new SearchOptions
                    {
                        VectorSearch = new()
                        {
                            Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector", "CategoryVector" } } }
                        }
                    });

                int count = 0;
                Console.WriteLine($"Multi Fields Vector Search Results:");
                await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
                {
                    count++;
                    Hotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
                }
                Console.WriteLine($"Total number of search results:{count}");
                #endregion
                Assert.GreaterOrEqual(count, 1);
            }
            finally
            {
                await indexClient.DeleteIndexAsync(indexName);
            }
        }

        private async Task<SearchIndexClient> CreateIndex(SearchResources resources, string name)
        {
            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Index_UsingVectorizedQuery
            string vectorSearchProfileName = "my-vector-profile";
            string vectorSearchHnswConfig = "my-hsnw-vector-config";
            int modelDimensions = 1536;

            string indexName = "hotel";
#if !SNIPPET
            indexName = name;
#endif
            SearchIndex searchIndex = new(indexName)
            {
                Fields =
                {
                    new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
                    new SearchableField("Description") { IsFilterable = true },
                    new VectorSearchField("DescriptionVector", modelDimensions, vectorSearchProfileName),
                    new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new VectorSearchField("CategoryVector", modelDimensions, vectorSearchProfileName),
                },
                VectorSearch = new()
                {
                    Profiles =
                    {
                        new VectorSearchProfile(vectorSearchProfileName, vectorSearchHnswConfig)
                    },
                    Algorithms =
                    {
                        new HnswAlgorithmConfiguration(vectorSearchHnswConfig)
                    }
                },
            };
            #endregion

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Create_Index_UsingVectorizedQuery
            Uri endpoint = new(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
            AzureKeyCredential credential = new(key);

            SearchIndexClient indexClient = new(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif
            await indexClient.CreateIndexAsync(searchIndex);
            #endregion

            return indexClient;
        }

        private async Task<SearchClient> UploadDocuments(SearchResources resources, string indexName)
        {
            Uri endpoint = resources.Endpoint;
            string key = resources.PrimaryApiKey;
            AzureKeyCredential credential = new AzureKeyCredential(key);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Upload_Documents_UsingVectorizedQuery
            SearchClient searchClient = new(endpoint, indexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif
            Hotel[] hotelDocuments = GetHotelDocuments();
            await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
            #endregion

            return searchClient;
        }

        public static Hotel[] GetHotelDocuments()
        {
            return VectorSearchCommons.GetHotelDocuments();
        }
    }
}
