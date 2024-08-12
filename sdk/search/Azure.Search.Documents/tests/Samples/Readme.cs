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
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Core.GeoJson;
#endregion Snippet:Azure_Search_Tests_Samples_Readme_Namespace

#region Snippet:Azure_Search_Readme_Identity_Namespace
using Azure.Identity;
#endregion

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
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
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

        [Test]
        [SyncOnly]
        public async Task AuthenticateWithAAD()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);

            #region Snippet:Azure_Search_Readme_CreateWithDefaultAzureCredential
            string indexName = "nycjobs";

            // Get the service endpoint from the environment
#if SNIPPET
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
#else
            Uri endpoint = resources.Endpoint;
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();

            // Create a client
            SearchClient client = new SearchClient(endpoint, indexName, credential);
            #endregion
        }

#if EXPERIMENTAL_DYNAMIC
        [Test]
#endif
        [SyncOnly]
        public async Task CreateAndQuery()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_Readme_Client
            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
            string indexName = "hotels";
#if !SNIPPET
            indexName = resources.IndexName;
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
                string id = (string)doc["HotelId"];
                string name = (string)doc["HotelName"];
                Console.WriteLine($"{id}: {name}");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_Readme_Dict

            foreach (SearchResult<SearchDocument> result in response.GetResults())
            {
                dynamic doc = result.Document;
                string id = doc.HotelId;
                string name = doc.HotelName;
                Console.WriteLine($"{id}: {name}");
            }
        }

        #region Snippet:Azure_Search_Tests_Samples_Readme_StaticType
        public class Hotel
        {
            [JsonPropertyName("HotelId")]
            [SimpleField(IsKey = true, IsFilterable = true, IsSortable = true)]
            public string Id { get; set; }

            [JsonPropertyName("HotelName")]
            [SearchableField(IsFilterable = true, IsSortable = true)]
            public string Name { get; set; }

            [SimpleField(IsFilterable = true, IsSortable = true)]
            public GeoPoint GeoLocation { get; set; }

            // Complex fields are included automatically in an index if not ignored.
            public HotelAddress Address { get; set; }
        }

        public class HotelAddress
        {
            public string StreetAddress { get; set; }

            [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
            public string City { get; set; }

            [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
            public string StateProvince { get; set; }

            [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
            public string Country { get; set; }

            [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
            public string PostalCode { get; set; }
        }
        #endregion Snippet:Azure_Search_Tests_Samples_Readme_StaticType

        [Test]
        [SyncOnly]
        public async Task QueryStatic()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
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
            SearchResults<Hotel> searchResponse = await client.SearchAsync<Hotel>("luxury");
            await foreach (SearchResult<Hotel> result in searchResponse.GetResultsAsync())
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
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
            SearchClient client = resources.GetQueryClient();

            #region Snippet:Azure_Search_Tests_Samples_Readme_Options
            int stars = 4;
            SearchOptions options = new SearchOptions
            {
                // Filter to only Rating greater than or equal our preference
                Filter = SearchFilter.Create($"Rating ge {stars}"),
                Size = 5, // Take only 5 results
                OrderBy = { "Rating desc" } // Sort by Rating from high to low
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
                    // Suggest query terms from the HotelName field.
                    new SearchSuggester("sg", "HotelName")
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
                    new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
                    new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
                    new SearchableField("Description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
                    new SearchableField("Tags", collection: true) { IsFilterable = true, IsFacetable = true },
                    new ComplexField("Address")
                    {
                        Fields =
                        {
                            new SearchableField("StreetAddress"),
                            new SearchableField("City") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("StateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("Country") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                            new SearchableField("PostalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true }
                        }
                    }
                },
                Suggesters =
                {
                    // Suggest query terms from the hotelName field.
                    new SearchSuggester("sg", "HotelName")
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
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
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
            await using SearchResources resources = await SearchResources.CreateWithEmptyHotelsIndexAsync(this, true);
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
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
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
