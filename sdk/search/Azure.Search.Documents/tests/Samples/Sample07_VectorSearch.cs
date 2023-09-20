﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using NUnit.Framework;
using System.Linq;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class VectorSearch : SearchTestBase
    {
        public VectorSearch(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, SearchClientOptions.ServiceVersion.V2023_07_01_Preview, null /* RecordedTestMode.Record /* to re-record */)
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

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Single_Vector_Search
                IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(null,
                    new SearchOptions
                    {
                        Vectors = { new() { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } },
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

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Filter
                IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(null,
                    new SearchOptions
                    {
                        Vectors = { new() { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } },
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

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Simple_Hybrid_Search
                IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                        "Top hotels in town",
                        new SearchOptions
                        {
                            Vectors = { new() { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } },
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
        [PlaybackOnly("The availability of Semantic Search is limited to specific regions, as indicated in the list provided here: https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=search. Due to this limitation, the deployment of resources for weekly test pipeline for setting the \"semanticSearch\": \"free\" fails in the UsGov and China cloud regions.")]
        public async Task SemanticHybridSearch()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                await AddSemanticSettingsToIndex(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Semantic_Hybrid_Search
                IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
                    new SearchOptions
                    {
                        Vectors = { new() { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "descriptionVector" } } },
                        QueryType = SearchQueryType.Semantic,
                        QueryLanguage = QueryLanguage.EnUs,
                        SemanticConfigurationName = "my-semantic-config",
                        QueryCaption = QueryCaptionType.Extractive,
                        QueryAnswer = QueryAnswerType.Extractive,
                    });

                int count = 0;
                Console.WriteLine($"Semantic Hybrid Search Results:");

                Console.WriteLine($"\nQuery Answer:");
                foreach (AnswerResult result in response.Answers)
                {
                    Console.WriteLine($"Answer Highlights: {result.Highlights}");
                    Console.WriteLine($"Answer Text: {result.Text}");
                }

                await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
                {
                    count++;
                    Hotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");

                    if (result.Captions != null)
                    {
                        var caption = result.Captions.FirstOrDefault();
                        if (caption.Highlights != null && caption.Highlights != "")
                        {
                            Console.WriteLine($"Caption Highlights: {caption.Highlights}");
                        }
                        else
                        {
                            Console.WriteLine($"Caption Text: {caption.Text}");
                        }
                    }
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

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Multi_Vector_Search
                IReadOnlyList<float> vectorizedDescriptionQuery = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
                IReadOnlyList<float> vectorizedCategoryQuery = VectorSearchEmbeddings.SearchVectorizeCategory; // "Luxury hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(null,
                    new SearchOptions
                    {
                        Vectors = {
                            new() { Value = vectorizedDescriptionQuery, KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } },
                            new() { Value = vectorizedCategoryQuery, KNearestNeighborsCount = 3, Fields = { "CategoryVector" } }
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

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Multi_Fields_Vector_Search
                IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(null,
                    new SearchOptions
                    {
                        Vectors = { new() {
                            Value = vectorizedResult,
                            KNearestNeighborsCount = 3,
                            Fields = { "DescriptionVector", "CategoryVector" } } }
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
            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Index
            string vectorSearchConfigName = "my-vector-config";
            int modelDimensions = 1536;

            string indexName = "Hotel";
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
                    new SearchField("DescriptionVector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
                    {
                        IsSearchable = true,
                        VectorSearchDimensions = modelDimensions,
                        VectorSearchConfiguration = vectorSearchConfigName
                    },
                    new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    new SearchField("CategoryVector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
                    {
                        IsSearchable = true,
                        VectorSearchDimensions = modelDimensions,
                        VectorSearchConfiguration = vectorSearchConfigName
                    },
                },
                VectorSearch = new()
                {
                    AlgorithmConfigurations =
                    {
                        new HnswVectorSearchAlgorithmConfiguration(vectorSearchConfigName)
                    }
                }
            };
            #endregion

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Create_Index
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

        private static async Task AddSemanticSettingsToIndex(SearchResources resources, string name)
        {
            SearchIndexClient indexClient = resources.GetIndexClient();

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Semantic_Index
            string indexName = "Hotel";
#if !SNIPPET
            indexName = name;
#endif
            SearchIndex createdIndex = await indexClient.GetIndexAsync(indexName);

            createdIndex.SemanticSettings = new()
            {
                Configurations =
                {
                       new SemanticConfiguration("my-semantic-config", new()
                       {
                           TitleField = new(){ FieldName = "HotelName" },
                           ContentFields =
                           {
                               new() { FieldName = "Description" }
                           },
                           KeywordFields =
                           {
                               new() { FieldName = "Category" }
                           }
                       })
                }
            };

            // Update index
            await indexClient.CreateOrUpdateIndexAsync(createdIndex);
            #endregion
        }

        private async Task<SearchClient> UploadDocuments(SearchResources resources, string indexName)
        {
            Uri endpoint = resources.Endpoint;
            string key = resources.PrimaryApiKey;
            AzureKeyCredential credential = new AzureKeyCredential(key);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Upload_Documents
            SearchClient searchClient = new(endpoint, indexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif
            Hotel[] hotelDocuments = GetHotelDocuments();
            await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
            #endregion

            return searchClient;
        }

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Model
        public class Hotel
        {
            public string HotelId { get; set; }
            public string HotelName { get; set; }
            public string Description { get; set; }
            public IReadOnlyList<float> DescriptionVector { get; set; }
            public string Category { get; set; }
            public IReadOnlyList<float> CategoryVector { get; set; }
        }
        #endregion

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Hotel_Document
        public static Hotel[] GetHotelDocuments()
        {
            return new[]
            {
                new Hotel()
                {
                    HotelId = "1",
                    HotelName = "Fancy Stay",
                    Description =
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel1VectorizeDescription,
                    Category = "Luxury",
                    CategoryVector = VectorSearchEmbeddings.LuxuryVectorizeCategory
                },
                new Hotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel2VectorizeDescription,
                    Category = "Budget",
                    CategoryVector = VectorSearchEmbeddings.BudgetVectorizeCategory
                },
 #if !SNIPPET
                new Hotel()
                {
                    HotelId = "3",
                    HotelName = "EconoStay",
                    Description = "Very popular hotel in town.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel3VectorizeDescription,
                    Category = "Budget",
                    CategoryVector = VectorSearchEmbeddings.BudgetVectorizeCategory
                },
                new Hotel()
                {
                    HotelId = "4",
                    HotelName = "Modern Stay",
                    Description = "Modern architecture, very polite staff and very clean. Also very affordable.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel7VectorizeDescription,
                    Category = "Luxury",
                    CategoryVector = VectorSearchEmbeddings.LuxuryVectorizeCategory
                },
                new Hotel()
                {
                    HotelId = "5",
                    HotelName = "Secret Point",
                     Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel9VectorizeDescription,
                    Category = "Boutique",
                    CategoryVector = VectorSearchEmbeddings.BoutiqueVectorizeCategory
                }
#endif
                // Add more hotel documents here...
            };
        }
        #endregion
    }
}
