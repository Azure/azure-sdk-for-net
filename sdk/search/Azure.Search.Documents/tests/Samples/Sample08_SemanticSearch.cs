// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using NUnit.Framework;
using System.Linq;
using Azure.Core.TestFramework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2025_08_01_Preview), ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_08_01_Preview)]
    public partial class SemanticSearch : SearchTestBase
    {
        public SemanticSearch(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("The availability of Semantic Search is limited to specific regions, as indicated in the list provided here: https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=search. Due to this limitation, the deployment of resources for weekly test pipeline for setting the \"semanticSearch\": \"free\" fails in the UsGov and China cloud regions.")]
        public async Task SemanticSearchTest()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);
                await Task.Delay(TimeSpan.FromSeconds(1));

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Query
                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
                    new SearchOptions
                    {
                        SemanticSearch = new()
                        {
                            SemanticConfigurationName = "my-semantic-config",
                            QueryCaption = new(QueryCaptionType.Extractive),
                            QueryAnswer = new(QueryAnswerType.Extractive)
                        },
                        QueryLanguage = QueryLanguage.EnUs,
                        QueryType = SearchQueryType.Semantic
                    });

                int count = 0;
                Console.WriteLine($"Semantic Search Results:");

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

        [Test]
        [PlaybackOnly("The availability of Semantic Search is limited to specific regions, as indicated in the list provided here: https://azure.microsoft.com/explore/global-infrastructure/products-by-region/?products=search. Due to this limitation, the deployment of resources for weekly test pipeline for setting the \"semanticSearch\": \"free\" fails in the UsGov and China cloud regions.")]
        public async Task SearchUsingSemanticQuery()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient indexClient = null;
            string indexName = Recording.Random.GetName();
            try
            {
                indexClient = await CreateIndex(resources, indexName);

                SearchClient searchClient = await UploadDocuments(resources, indexName);
                await Task.Delay(TimeSpan.FromSeconds(1));

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Query
                SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    "Luxury hotel",
                    new SearchOptions
                    {
                        SemanticSearch = new()
                        {
                            SemanticConfigurationName = "my-semantic-config",
                            QueryCaption = new(QueryCaptionType.Extractive),
                            QueryAnswer = new(QueryAnswerType.Extractive),
                            SemanticQuery = "Is there any hotel located on the main commercial artery of the city in the heart of New York?"
                        },
                        QueryLanguage = QueryLanguage.EnUs,
                    });

                int count = 0;
                Console.WriteLine($"Semantic Search Results:");

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
            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Index
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
                    new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
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

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Create_Index
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

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Upload_Documents
            SearchClient searchClient = new(endpoint, indexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif
            Hotel[] hotelDocuments = GetHotelDocuments();
            await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
            #endregion

            return searchClient;
        }

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Hotel_Document
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
                    Category = "Luxury",
                },
                new Hotel()
                {
                    HotelId = "2",
                    HotelName = "Roach Motel",
                    Description = "Cheapest hotel in town. Infact, a motel.",
                    Category = "Budget",
                },
 #if !SNIPPET
                new Hotel()
                {
                    HotelId = "3",
                    HotelName = "EconoStay",
                    Description = "Very popular hotel in town.",
                    Category = "Budget",
                },
                new Hotel()
                {
                    HotelId = "4",
                    HotelName = "Modern Stay",
                    Description = "Modern architecture, very polite staff and very clean. Also very affordable.",
                    Category = "Luxury",
                },
                new Hotel()
                {
                    HotelId = "5",
                    HotelName = "Secret Point",
                     Description = "The hotel is ideally located on the main commercial artery of the city in the heart of New York. " +
                     "A few minutes away is Time's Square and the historic centre of the city, " +
                     "as well as other places of interest that make New York one of America's most attractive and cosmopolitan cities.",
                    Category = "Boutique",
                }
#endif
                // Add more hotel documents here...
            };
        }
        #endregion

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Model
        public class Hotel
        {
            public string HotelId { get; set; }
            public string HotelName { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
        }
        #endregion
    }
}
