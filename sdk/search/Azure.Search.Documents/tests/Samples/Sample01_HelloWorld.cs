// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Namespaces
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class HelloWorld : SearchTestBase
    {
        public HelloWorld(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [SyncOnly]
        public async Task CreateClient()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_CreateClient
            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create a new SearchIndexClient
            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Perform an operation
            Response<SearchServiceStatistics> stats = indexClient.GetServiceStatistics();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_CreateClient

            Assert.GreaterOrEqual(stats.Value.Counters.IndexCounter.Usage, 1);
        }

        [Test]
        [AsyncOnly]
        public async Task CreateClientAsync()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_CreateClientAsync
            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create a new SearchIndexClient
            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Perform an operation
            Response<SearchServiceStatistics> stats = await indexClient.GetServiceStatisticsAsync();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_CreateClientAsync

            Assert.GreaterOrEqual(stats.Value.Counters.IndexCounter.Usage, 1);
        }

        [Test]
        [SyncOnly]
        public async Task HandleErrors()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_HandleErrors
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create an invalid SearchClient
            string fakeIndexName = "doesnotexist";
            SearchClient searchClient = new SearchClient(endpoint, fakeIndexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, fakeIndexName, credential, GetSearchClientOptions()));
#endif
            try
            {
                searchClient.GetDocumentCount();
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine("Index wasn't found.");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_HandleErrors
        }

        [Test]
        [AsyncOnly]
        public async Task HandleErrorsAsync()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_HandleErrorsAsync
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create an invalid SearchClient
            string fakeIndexName = "doesnotexist";
            SearchClient searchClient = new SearchClient(endpoint, fakeIndexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, fakeIndexName, credential, GetSearchClientOptions()));
#endif
            try
            {
                await searchClient.GetDocumentCountAsync();
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine("Index wasn't found.");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_HandleErrorsAsync
        }

        [Test]
        public async Task GetStatisticsAsync()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
            // Create a new SearchIndexClient
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Get and report the Search Service statistics
            Response<SearchServiceStatistics> stats = await indexClient.GetServiceStatisticsAsync();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} of {stats.Value.Counters.IndexCounter.Quota} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
        }

        [Test]
        [AsyncOnly]
        public async Task CreateIndexerAsync()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAsync(this, populate: true, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("STORAGE_CONNECTION_STRING", resources.StorageAccountConnectionString);
            Environment.SetEnvironmentVariable("STORAGE_CONTAINER", resources.BlobContainerName);
            Environment.SetEnvironmentVariable("COGNITIVE_SERVICES_KEY", resources.CognitiveServicesKey);

            // Define clean up tasks to be invoked in reverse order added.
            Stack<Func<Task>> cleanUpTasks = new Stack<Func<Task>>();
            try
            {
                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateSynonymMap
                // Create a new SearchIndexClient
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = resources.GetIndexClient(new SearchClientOptions(ServiceVersion));
#endif

                // Create a synonym map from a file containing country names and abbreviations
                // using the Solr format with entry on a new line using \n, for example:
                // United States of America,US,USA\n
                string synonymMapName = "countries";
#if !SNIPPET
                synonymMapName = Recording.Random.GetName();
#endif
                string synonymMapPath = "countries.txt";
#if !SNIPPET
                synonymMapPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "countries.txt");
#endif

                SynonymMap synonyms;
#if SNIPPET
                using (StreamReader file = File.OpenText(synonymMapPath))
                {
                    synonyms = new SynonymMap(synonymMapName, file);
                }
#else
                synonyms = new SynonymMap(synonymMapName, HelloWorldData.CountriesSolrSynonymMap);
#endif

                await indexClient.CreateSynonymMapAsync(synonyms);
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateSynonymMap

                // Make sure our synonym map gets deleted, which is not deleted when our
                // index is deleted when our SearchResources goes out of scope.
                cleanUpTasks.Push(() => indexClient.DeleteSynonymMapAsync(synonymMapName));

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateIndex
                // Create the index
                string indexName = "hotels";
#if !SNIPPET
                indexName = Recording.Random.GetName();
#endif
                SearchIndex index = new SearchIndex(indexName)
                {
                    Fields =
                    {
                        new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
                        new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
                        new SearchableField("Description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
                        new SearchableField("DescriptionFr") { AnalyzerName = LexicalAnalyzerName.FrLucene },
                        new SearchableField("Tags", collection: true) { IsFilterable = true, IsFacetable = true },
                        new ComplexField("Address")
                        {
                            Fields =
                            {
                                new SearchableField("StreetAddress"),
                                new SearchableField("City") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                                new SearchableField("StateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                                new SearchableField("Country") { SynonymMapNames = { synonymMapName }, IsFilterable = true, IsSortable = true, IsFacetable = true },
                                new SearchableField("PostalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true }
                            }
                        }
                    }
                };

                await indexClient.CreateIndexAsync(index);
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateIndex

                // Make sure our synonym map gets deleted, which is not deleted when our
                // index is deleted when our SearchResources goes out of scope.
                cleanUpTasks.Push(() => indexClient.DeleteIndexAsync(indexName));

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateDataSourceConnection
                // Create a new SearchIndexerClient
                SearchIndexerClient indexerClient = new SearchIndexerClient(endpoint, credential);
#if !SNIPPET
                indexerClient = resources.GetIndexerClient();
#endif

                string dataSourceConnectionName = "hotels";
#if !SNIPPET
                dataSourceConnectionName = Recording.Random.GetName();
#endif
                SearchIndexerDataSourceConnection dataSourceConnection = new SearchIndexerDataSourceConnection(
                    dataSourceConnectionName,
                    SearchIndexerDataSourceType.AzureBlob,
                    Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING"),
                    new SearchIndexerDataContainer(Environment.GetEnvironmentVariable("STORAGE_CONTAINER")));

                await indexerClient.CreateDataSourceConnectionAsync(dataSourceConnection);
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateDataSourceConnection

                // Make sure our data source gets deleted, which is not deleted when our
                // index is deleted when our SearchResources goes out of scope.
                cleanUpTasks.Push(() => indexerClient.DeleteDataSourceConnectionAsync(dataSourceConnectionName));

#if SNIPPET
                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_SearchClientOptions
                // Create SearchIndexerClient options
                SearchClientOptions options = new SearchClientOptions()
                {
                    Transport = new HttpClientTransport(new HttpClient()
                    {
                        // Increase timeout for each request to 5 minutes
                        Timeout = TimeSpan.FromMinutes(5)
                    })
                };

                // Increase retry attempts to 6
                options.Retry.MaxRetries = 6;

                // Create a new SearchIndexerClient with options
                indexerClient = new SearchIndexerClient(endpoint, credential, options);
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_SearchClientOptions
#endif

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Skillset
                // Translate English descriptions to French.
                // See https://learn.microsoft.com/azure/search/cognitive-search-skill-text-translation for details of the Text Translation skill.
                TextTranslationSkill translationSkill = new TextTranslationSkill(
                    inputs: new[]
                    {
                        new InputFieldMappingEntry("text") { Source = "/document/Description" }
                    },
                    outputs: new[]
                    {
                        new OutputFieldMappingEntry("translatedText") { TargetName = "descriptionFrTranslated" }
                    },
                    TextTranslationSkillLanguage.Fr)
                {
                    Name = "descriptionFrTranslation",
                    Context = "/document",
                    DefaultFromLanguageCode = TextTranslationSkillLanguage.En
                };

                // Use the human-translated French description if available; otherwise, use the translated description.
                // See https://learn.microsoft.com/azure/search/cognitive-search-skill-conditional for details of the Conditional skill.
                ConditionalSkill conditionalSkill = new ConditionalSkill(
                    inputs: new[]
                    {
                        new InputFieldMappingEntry("condition") { Source = "= $(/document/DescriptionFr) == null" },
                        new InputFieldMappingEntry("whenTrue") { Source = "/document/descriptionFrTranslated" },
                        new InputFieldMappingEntry("whenFalse") { Source = "/document/DescriptionFr" }
                    },
                    outputs: new[]
                    {
                        new OutputFieldMappingEntry("output") { TargetName = "descriptionFrFinal"}
                    })
                {
                    Name = "descriptionFrConditional",
                    Context = "/document",
                };

                // Create a SearchIndexerSkillset that processes those skills in the order given below.
                string skillsetName = "translations";
#if !SNIPPET
                skillsetName = Recording.Random.GetName();
#endif
                SearchIndexerSkillset skillset = new SearchIndexerSkillset(
                    skillsetName,
                    new SearchIndexerSkill[] { translationSkill, conditionalSkill })
                {
                    CognitiveServicesAccount =  new CognitiveServicesAccountKey(
                        Environment.GetEnvironmentVariable("COGNITIVE_SERVICES_KEY")),
                    KnowledgeStore = new KnowledgeStore(
                        Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING"),
                        new List<KnowledgeStoreProjection>()),
                };

                await indexerClient.CreateSkillsetAsync(skillset);
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Skillset

                // Make sure our skillset gets deleted, which is not deleted when our
                // index is deleted when our SearchResources goes out of scope.
                cleanUpTasks.Push(() => indexerClient.DeleteSkillsetAsync(skillsetName));

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateIndexer
                string indexerName = "hotels";
#if !SNIPPET
                indexerName = Recording.Random.GetName();
#endif
                SearchIndexer indexer = new SearchIndexer(
                    indexerName,
                    dataSourceConnectionName,
                    indexName)
                {
                    // We only want to index fields defined in our index, excluding descriptionFr if defined.
                    FieldMappings =
                    {
                        new FieldMapping("HotelId"),
                        new FieldMapping("HotelName"),
                        new FieldMapping("Description"),
                        new FieldMapping("Tags"),
                        new FieldMapping("Address")
                    },
                    OutputFieldMappings =
                    {
                        new FieldMapping("/document/descriptionFrFinal") { TargetFieldName = "DescriptionFr" }
                    },
                    Parameters = new IndexingParameters
                    {
                        // Tell the indexer to parse each blob as a separate JSON document.
                        IndexingParametersConfiguration = new IndexingParametersConfiguration
                        {
                            ParsingMode = BlobIndexerParsingMode.Json
                        }
                    },
                    SkillsetName = skillsetName
                };

                // Create the indexer which, upon successful creation, also runs the indexer.
                await indexerClient.CreateIndexerAsync(indexer);
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateIndexer

                // Make sure our indexer gets deleted, which is not deleted when our
                // index is deleted when our SearchResources goes out of scope.
                cleanUpTasks.Push(() => indexerClient.DeleteIndexerAsync(indexerName));

                // Wait till the indexer is done.
                await WaitForIndexingAsync(indexerClient, indexerName);

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Query
                // Get a SearchClient from the SearchIndexClient to share its pipeline.
                SearchClient searchClient = indexClient.GetSearchClient(indexName);
#if !SNIPPET
                searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif

                // Query for hotels with an ocean view.
                SearchResults<Hotel> results = await searchClient.SearchAsync<Hotel>("ocean view");
#if !SNIPPET
                bool found = false;
#endif
                await foreach (SearchResult<Hotel> result in results.GetResultsAsync())
                {
                    Hotel hotel = result.Document;
#if !SNIPPET
                    if (hotel.HotelId == "6") { Assert.IsNotNull(hotel.DescriptionFr); found = true; }
#endif

                    Console.WriteLine($"{hotel.HotelName} ({hotel.HotelId})");
                    Console.WriteLine($"  Description (English): {hotel.Description}");
                    Console.WriteLine($"  Description (French):  {hotel.DescriptionFr}");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Query
#if !SNIPPET
                Assert.IsTrue(found, "Expected hotel #6 not found in search results");
#endif
            }
            finally
            {
                // We want to await these individual to create a deterministic order for playing back tests.
                foreach (Func<Task> cleanUpTask in cleanUpTasks)
                {
                    await cleanUpTask();
                }
            }
        }

        [Test]
        public async Task GetCountAsync()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);

            #region Snippet:Azure_Search_Tests_Samples_GetCountAsync
            // Create a SearchClient
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");
            SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif

            // Get and report the number of documents in the index
            Response<long> count = await searchClient.GetDocumentCountAsync();
            Console.WriteLine($"Search index {indexName} has {count.Value} documents.");
            #endregion Snippet:Azure_Search_Tests_Samples_GetCountAsync
        }

        [Test]
        public async Task QuerySession()
        {
            const int size = 150;
            await using SearchResources resources = await SearchResources.CreateLargeHotelsIndexAsync(this, size, false, true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);

            HashSet<string> uniqueDocuments = new HashSet<string>();
            bool hasDuplicates = false;

            #region Snippet:Azure_Search_Tests_Samples_QuerySession
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

            SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
#if !SNIPPET
            searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));
#endif
            SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
                    new SearchOptions
                    {
                        Filter = "Rating gt 2",
                        SessionId = "Session-1"
                    });

            await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
            {
                Hotel hotel = result.Document;
#if !SNIPPET
                if (!uniqueDocuments.Add(hotel.HotelId))
                {
                    hasDuplicates = true;
                }
#endif
                Console.WriteLine($"{hotel.HotelName} ({hotel.HotelId})");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_QuerySession

            Assert.False(hasDuplicates, "Duplicate documents found.");
        }
    }
}
