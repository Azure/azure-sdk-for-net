// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.AI.OpenAI;

namespace Azure.Search.Documents.Tests.Samples.VectorSearch
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2024_05_01_Preview), ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2024_05_01_Preview)]
    public partial class VectorSearchUsingReducedEmbeddings : SearchTestBase
    {
        public VectorSearchUsingReducedEmbeddings(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task VectorSearch()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Reduced_Vector_Search
#if !SNIPPET
                await Task.Delay(TimeSpan.FromSeconds(1));
#endif
                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    new SearchOptions
                    {
                        VectorSearch = new()
                        {
                            Queries = { new VectorizableTextQuery("Luxury hotels in town") {
                            KNearestNeighborsCount = 3,
                            Fields = { "DescriptionVector" } } },
                        }
                    });

                int count = 0;
                Console.WriteLine($"Vector Search Results:");
                await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
                {
                    count++;
                    Hotel doc = result.Document;
                    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
                }
                Console.WriteLine($"Total number of search results:{count}");
                #endregion
                Assert.GreaterOrEqual(count, 3);
            }
            finally
            {
                await indexClient.DeleteIndexAsync(indexName);
            }
        }

        private async Task<SearchIndexClient> CreateIndex(SearchResources resources, string name)
        {
            string openAIEndpoint = TestEnvironment.OpenAIEndpoint;
            string openAIKey = TestEnvironment.OpenAIKey;
            if (string.IsNullOrEmpty(openAIEndpoint) || string.IsNullOrEmpty(openAIKey))
            {
                Assert.Ignore("OpenAI was not deployed");
            }

            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", openAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", openAIKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Reduced_Vector_Search_Index
            string vectorSearchProfileName = "my-vector-profile";
            string vectorSearchHnswConfig = "my-hsnw-vector-config";
            string deploymentId = "my-text-embedding-3-small";
            int modelDimensions = 256; // Here's the reduced model dimensions

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
                        {
                            Vectorizer = "openai"
                        }
                    },
                    Algorithms =
                    {
                        new HnswAlgorithmConfiguration(vectorSearchHnswConfig)
                    },
                    Vectorizers =
                    {
                        new AzureOpenAIVectorizer("openai")
                        {
                            AzureOpenAIParameters  = new AzureOpenAIParameters()
                            {
                                ResourceUri = new Uri(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT")),
                                ApiKey = Environment.GetEnvironmentVariable("OPENAI_KEY"),
                                DeploymentId = deploymentId,
                                ModelName = AzureOpenAIModelName.TextEmbedding3Small
                            }
                        }
                    }
                },
            };
            #endregion

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Reduced_Vector_Search_Create_Index
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

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Reduced_Vector_Search_Upload_Documents
            SearchClient searchClient = new(endpoint, indexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif
            Hotel[] hotelDocuments = GetHotelDocuments();
            await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
            #endregion

            return searchClient;
        }

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_GetEmbeddings_WithDimensions
        public static ReadOnlyMemory<float> GetEmbeddings(string input)
        {
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("OpenAI_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("OpenAI_API_KEY");
            AzureKeyCredential credential = new AzureKeyCredential(key);

            OpenAIClient openAIClient = new OpenAIClient(endpoint, credential);
            EmbeddingsOptions embeddingsOptions = new("my-text-embedding-3-small", new string[] { input })
            {
                Dimensions = 256
            };

            Embeddings embeddings = openAIClient.GetEmbeddings(embeddingsOptions);
            return embeddings.Data[0].Embedding;
        }
        #endregion

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Documents
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
                    DescriptionVector = GetEmbeddings(
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel."),
                    Category = "Luxury",
                    CategoryVector = GetEmbeddings("Luxury")
                },
                new Hotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
                    DescriptionVector = GetEmbeddings("Cheapest hotel in town. Infact, a motel."),
                    Category = "Budget",
                    CategoryVector = GetEmbeddings("Budget")
                },
#if !SNIPPET
                new Hotel()
                {
                    HotelId = "3",
                    HotelName = "EconoStay",
                    Description = "Very popular hotel in town.",
                    DescriptionVector = GetEmbeddings("Very popular hotel in town."),
                    Category = "Budget",
                    CategoryVector = GetEmbeddings("Budget")
                },
                new Hotel()
                {
                    HotelId = "4",
                    HotelName = "Modern Stay",
                    Description = "Modern architecture, very polite staff and very clean. Also very affordable.",
                    DescriptionVector = GetEmbeddings("Modern architecture, very polite staff and very clean. Also very affordable."),
                    Category = "Luxury",
                    CategoryVector = GetEmbeddings("Luxury")
                },
                new Hotel()
                {
                    HotelId = "5",
                    HotelName = "Secret Point",
                     Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                    DescriptionVector = GetEmbeddings("The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities."),
                    Category = "Boutique",
                    CategoryVector = GetEmbeddings("Boutique")
                }
#endif
                // Add more hotel documents here...
            };
        }
        #endregion
    }
}
