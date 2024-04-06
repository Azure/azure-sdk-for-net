// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using NUnit.Framework;
using System.Linq;
using Azure.Core.TestFramework;

namespace Azure.Search.Documents.Tests.Samples.VectorSearch
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2024_03_01_Preview), ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2024_03_01_Preview)]
    public partial class VectorSemanticHybridSearch : SearchTestBase
    {
        public VectorSemanticHybridSearch(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
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

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Semantic_Hybrid_Search
#if !SNIPPET
                ReadOnlyMemory<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"
#else
                ReadOnlyMemory<float> vectorizedResult = GetEmbeddings("Top hotels in town");
#endif
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif

                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
                     new SearchOptions
                     {
                         VectorSearch = new()
                         {
                             Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } }
                         },
                         SemanticSearch = new()
                         {
                             SemanticConfigurationName = "my-semantic-config",
                             QueryCaption = new(QueryCaptionType.Extractive),
                             QueryAnswer = new(QueryAnswerType.Extractive)
                         },
                         QueryLanguage = QueryLanguage.EnUs,
                         QueryType = SearchQueryType.Semantic,
                     });

                int count = 0;
                Console.WriteLine($"Semantic Hybrid Search Results:");

                Console.WriteLine($"\nQuery Answer:");
                foreach (QueryAnswerResult result in response.SemanticSearch.Answers)
                {
                    Console.WriteLine($"Answer Highlights: {result.Highlights}");
                    Console.WriteLine($"Answer Text: {result.Text}");
                }

                await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
                {
                    count++;
                    Hotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");

                    if (result.SemanticSearch.Captions != null)
                    {
                        var caption = result.SemanticSearch.Captions.FirstOrDefault();
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

        private async Task<SearchIndexClient> CreateIndex(SearchResources resources, string name)
        {
            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Semantic_Hybrid_Search_Index
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
                SemanticSearch = new()
                {
                    Configurations =
                    {
                        new SemanticConfiguration("my-semantic-config", new()
                        {
                            TitleField = new SemanticField("HotelName"),
                            ContentFields =
                            {
                                new SemanticField("Description")
                            },
                            KeywordsFields =
                            {
                                new SemanticField("Category")
                            }
                        })
                    }
                }
            };
            #endregion

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Semantic_Hybrid_Search_Create_Index
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

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Semantic_Hybrid_Search_Upload_Documents
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

        public static ReadOnlyMemory<float> GetEmbeddings(string input)
        {
            return VectorSearchCommons.GetEmbeddings(input);
        }
    }
}
