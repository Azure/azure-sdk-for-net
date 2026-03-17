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
using OpenAI.Embeddings;

namespace Azure.Search.Documents.Tests.Samples.VectorSearch
{
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
            string deploymentName = "my-text-embedding-3-small";
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
                            VectorizerName = "openai"
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
                            Parameters  = new AzureOpenAIVectorizerParameters()
                            {
                                ResourceUri = new Uri(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT")),
                                ApiKey = Environment.GetEnvironmentVariable("OPENAI_KEY"),
                                DeploymentName = deploymentName,
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

            AzureOpenAIClient openAIClient = new AzureOpenAIClient(endpoint, credential);
            EmbeddingClient embeddingClient = openAIClient.GetEmbeddingClient("my-text-embedding-3-small");

            EmbeddingGenerationOptions embeddingsOptions = new EmbeddingGenerationOptions()
            {
                Dimensions = 256
            };
            OpenAIEmbedding embedding = embeddingClient.GenerateEmbedding(input, embeddingsOptions);
            return embedding.ToFloats();
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
#if !SNIPPET
                    DescriptionVector = VectorSearchEmbeddings.Hotel1ReducedVectorizeDescription,
#else
                    DescriptionVector = GetEmbeddings(
                        "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                        "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                        "the tourist attractions. We highly recommend this hotel."),
#endif
                    Category = "Luxury",
#if !SNIPPET
                    CategoryVector = VectorSearchEmbeddings.LuxuryReducedVectorizeCategory
#else
                    CategoryVector = GetEmbeddings("Luxury")
#endif
                },
                new Hotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
#if !SNIPPET
                    DescriptionVector = VectorSearchEmbeddings.Hotel2ReducedVectorizeDescription,
#else
                    DescriptionVector = GetEmbeddings("Cheapest hotel in town. Infact, a motel."),
#endif
                    Category = "Budget",
#if !SNIPPET
                    CategoryVector = VectorSearchEmbeddings.BudgetReducedVectorizeCategory
#else
                    CategoryVector = GetEmbeddings("Budget")
#endif
                },
#if !SNIPPET
                new Hotel()
                {
                    HotelId = "3",
                    HotelName = "EconoStay",
                    Description = "Very popular hotel in town.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel3ReducedVectorizeDescription,
                    Category = "Budget",
                    CategoryVector = VectorSearchEmbeddings.BudgetReducedVectorizeCategory
                },
                new Hotel()
                {
                    HotelId = "4",
                    HotelName = "Modern Stay",
                    Description = "Modern architecture, very polite staff and very clean. Also very affordable.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel4ReducedVectorizeDescription,
                    Category = "Luxury",
                    CategoryVector = VectorSearchEmbeddings.LuxuryReducedVectorizeCategory
                },
                new Hotel()
                {
                    HotelId = "5",
                    HotelName = "Secret Point",
                     Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                    DescriptionVector = VectorSearchEmbeddings.Hotel5ReducedVectorizeDescription,
                    Category = "Boutique",
                    CategoryVector = VectorSearchEmbeddings.BoutiqueReducedVectorizeCategory
                }
#endif
                // Add more hotel documents here...
            };
        }
        #endregion
    }
}
