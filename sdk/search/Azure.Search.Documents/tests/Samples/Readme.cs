// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

#region Snippet:Azure_Search_Tests_Samples_Readme_Namespace
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Core.GeoJson;
#endregion Snippet:Azure_Search_Tests_Samples_Readme_Namespace

namespace Azure.Search.Documents.Tests.Samples
{
    /// <summary>
    /// Samples used to generate the README.md snippets.
    /// </summary>
    public class Readme : SearchTestBase
    {
        public Readme(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [SyncOnly]
        public async Task Authenticate()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_Readme_Authenticate
            string indexName = "nycjobs";

            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

            // Create a client
            AzureKeyCredential credential = new AzureKeyCredential(key);
            SearchClient client = new SearchClient(endpoint, indexName, credential);
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_Authenticate
        }

#if EXPERIMENTAL_DYNAMIC
        [Test]
#endif
        [SyncOnly]
        public async Task CreateAndQuery()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            string indexName = resources.IndexName;

            #region Snippet:Azure_Search_Tests_Samples_Readme_Client
            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
#if SNIPPET
            string indexName = "hotels";
#endif

            // Create a client
            AzureKeyCredential credential = new AzureKeyCredential(key);
            SearchClient client = new SearchClient(endpoint, indexName, credential);
#if !SNIPPET
            client = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_Client

            #region Snippet:Azure_Search_Tests_Samples_Readme_Dict
            SearchResults<SearchDocument> response = client.Search<SearchDocument>("luxury");
            foreach (SearchResult<SearchDocument> result in response.GetResults())
            {
                SearchDocument doc = result.Document;
#if SNIPPET
                string id = (string)doc["HotelId"];
                string name = (string)doc["HotelName"];
#else
                string id = (string)doc["hotelId"];
                string name = (string)doc["hotelName"];
#endif
                Console.WriteLine("{id}: {name}");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_Dict

#if SNIPPET
            SearchResults<SearchDocument> response = client.Search<SearchDocument>("luxury");
#else
            response = client.Search<SearchDocument>("luxury");
#endif
            foreach (SearchResult<SearchDocument> result in response.GetResults())
            {
                dynamic doc = result.Document;
                string id = doc.hotelId;
                string name = doc.hotelName;
                Console.WriteLine("{id}: {name}");
            }
        }

        #region Snippet:Azure_Search_Tests_Samples_Readme_StaticType
        public class Hotel
        {
#if SNIPPET
            [JsonPropertyName("HotelId")]
#else
            [JsonPropertyName("hotelId")]
#endif
            [SimpleField(IsKey = true, IsFilterable = true, IsSortable = true)]
            public string Id { get; set; }

#if SNIPPET
            [JsonPropertyName("HotelName")]
#else
            [JsonPropertyName("hotelName")]
#endif
            [SearchableField(IsFilterable = true, IsSortable = true)]
            public string Name { get; set; }

#if !SNIPPET
            [JsonPropertyName("geoLocation")]
#endif
            [SimpleField(IsFilterable = true, IsSortable = true)]
            public GeoPoint GeoLocation { get; set; }

#if !SNIPPET
            [JsonPropertyName("address")]
#endif
            // Complex fields are included automatically in an index if not ignored.
            public HotelAddress Address { get; set; }
        }

        public class HotelAddress
        {
#if !SNIPPET
            [JsonPropertyName("streetAddress")]
#endif
            public string StreetAddress { get; set; }

#if !SNIPPET
            [JsonPropertyName("city")]
#endif
            [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
            public string City { get; set; }

#if !SNIPPET
            [JsonPropertyName("stateProvince")]
#endif
            [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
            public string StateProvince { get; set; }

#if !SNIPPET
            [JsonPropertyName("country")]
#endif
            [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
            public string Country { get; set; }

#if !SNIPPET
            [JsonPropertyName("postalCode")]
#endif
            [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
            public string PostalCode { get; set; }
        }
        #endregion Snippet:Azure_Search_Tests_Samples_Readme_StaticType

            [Test]
        [SyncOnly]
        public async Task QueryStatic()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchClient client = resources.GetQueryClient();

            #region Snippet:Azure_Search_Tests_Samples_Readme_StaticQuery
            SearchResults<Hotel> response = client.Search<Hotel>("luxury");
            foreach (SearchResult<Hotel> result in response.GetResults())
            {
                Hotel doc = result.Document;
                Console.WriteLine($"{doc.Id}: {doc.Name}");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_StaticQuery

            #region Snippet:Azure_Search_Tests_Samples_Readme_StaticQueryAsync
#if SNIPPET
            SearchResults<Hotel> response = await client.SearchAsync<Hotel>("luxury");
#else
            response = await client.SearchAsync<Hotel>("luxury");
#endif
            await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
            {
                Hotel doc = result.Document;
                Console.WriteLine($"{doc.Id}: {doc.Name}");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_StaticQueryAsync
        }

        [Test]
        [SyncOnly]
        public async Task Options()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchClient client = resources.GetQueryClient();

            #region Snippet:Azure_Search_Tests_Samples_Readme_Options
            int stars = 4;
            SearchOptions options = new SearchOptions
            {
                // Filter to only Rating greater than or equal our preference
#if SNIPPET
                Filter = SearchFilter.Create($"Rating ge {stars}"),
#else
                Filter = SearchFilter.Create($"rating ge {stars}"),
#endif
                Size = 5, // Take only 5 results
#if SNIPPET
                OrderBy = { "Rating desc" } // Sort by Rating from high to low
#else
                OrderBy = { "rating desc" } // Sort by rating from high to low
#endif
            };
            SearchResults<Hotel> response = client.Search<Hotel>("luxury", options);
            // ...
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_Options
        }

        [Test]
        [SyncOnly]
        public async Task CreateIndex()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_Readme_CreateIndex
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

            // Create a service client
            AzureKeyCredential credential = new AzureKeyCredential(key);
            SearchIndexClient client = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            client = resources.GetIndexClient();
#endif

            // Create the index using FieldBuilder.
            #region Snippet:Azure_Search_Tests_Samples_Readme_CreateIndex_New_SearchIndex
#if SNIPPET
            SearchIndex index = new SearchIndex("hotels")
#else
            SearchIndex index = new SearchIndex(Recording.Random.GetName())
#endif
            {
                Fields = new FieldBuilder().Build(typeof(Hotel)),
                Suggesters =
                {
                    // Suggest query terms from the hotelName field.
                    new SearchSuggester("sg", "hotelName")
                }
            };
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_CreateIndex_New_SearchIndex

            client.CreateIndex(index);
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_CreateIndex

            resources.IndexName = index.Name;
        }

        [Test]
        [SyncOnly]
        public async Task CreateManualIndex()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchIndexClient client = resources.GetIndexClient();

            #region Snippet:Azure_Search_Tests_Samples_Readme_CreateManualIndex
            // Create the index using field definitions.
            #region Snippet:Azure_Search_Tests_Samples_Readme_CreateManualIndex_New_SearchIndex
#if SNIPPET
            SearchIndex index = new SearchIndex("hotels")
#else
            SearchIndex index = new SearchIndex(Recording.Random.GetName())
#endif
            {
                Fields =
                {
                    new SimpleField("hotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
                    new SearchableField("hotelName") { IsFilterable = true, IsSortable = true },
                    new SearchableField("description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
                    new SearchableField("tags", collection: true) { IsFilterable = true, IsFacetable = true },
                    new ComplexField("address")
                    {
                        Fields =
                        {
                            new SearchableField("streetAddress"),
                            new SearchableField("city") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("stateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("country") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("postalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true }
                        }
                    }
                },
                Suggesters =
                {
                    // Suggest query terms from the hotelName field.
                    new SearchSuggester("sg", "hotelName")
                }
            };
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_CreateManualIndex_New_SearchIndex

            client.CreateIndex(index);
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_CreateManualIndex

            resources.IndexName = index.Name;
        }

        [Test]
        [SyncOnly]
        public async Task GetDocument()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchClient client = resources.GetQueryClient();

            #region Snippet:Azure_Search_Tests_Samples_Readme_GetDocument
            Hotel doc = client.GetDocument<Hotel>("1");
            Console.WriteLine($"{doc.Id}: {doc.Name}");
            #endregion
        }

        [Test]
        [SyncOnly]
        public async Task Index()
        {
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);
            SearchClient client = resources.GetQueryClient();
            try
            {
                #region Snippet:Azure_Search_Tests_Samples_Readme_Index
                IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Create(
                    IndexDocumentsAction.Upload(new Hotel { Id = "783", Name = "Upload Inn" }),
                    IndexDocumentsAction.Merge(new Hotel { Id = "12", Name = "Renovated Ranch" }));

                IndexDocumentsOptions options = new IndexDocumentsOptions { ThrowOnAnyError = true };
                client.IndexDocuments(batch, options);
                #endregion Snippet:Azure_Search_Tests_Samples_Readme_Index
            }
            catch (RequestFailedException)
            {
                // Ignore the non-existent merge failure
            }
        }

        [Test]
        [SyncOnly]
        public async Task Troubleshooting()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchClient client = resources.GetQueryClient();
            LookupHotel();

            // We want the sample to have a return but the unit test doesn't
            // like that so we move it into a block scoped function
            Response<Hotel> LookupHotel()
            {
                #region Snippet:Azure_Search_Tests_Samples_Readme_Troubleshooting
                try
                {
                    return client.GetDocument<Hotel>("12345");
                }
                catch (RequestFailedException ex) when (ex.Status == 404)
                {
                    Console.WriteLine("We couldn't find the hotel you are looking for!");
                    Console.WriteLine("Please try selecting another.");
                    return null;
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Readme_Troubleshooting
            }
        }
    }
}
