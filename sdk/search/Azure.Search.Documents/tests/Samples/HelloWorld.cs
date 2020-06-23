// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_CreateClient
            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create a new SearchIndexClient
            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
            /*@@*/ indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));

            // Perform an operation
            Response<SearchServiceStatistics> stats = indexClient.GetServiceStatistics();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_CreateClient

            Assert.AreEqual(1, stats.Value.Counters.IndexCounter.Usage);
        }

        [Test]
        [AsyncOnly]
        public async Task CreateClientAsync()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_CreateClientAsync
            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create a new SearchIndexClient
            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
            /*@@*/ indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));

            // Perform an operation
            Response<SearchServiceStatistics> stats = await indexClient.GetServiceStatisticsAsync();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_CreateClientAsync

            Assert.AreEqual(1, stats.Value.Counters.IndexCounter.Usage);
        }

        [Test]
        [SyncOnly]
        public async Task HandleErrors()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_HandleErrors
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create an invalid SearchClient
            string fakeIndexName = "doesnotexist";
            SearchClient searchClient = new SearchClient(endpoint, fakeIndexName, credential);
            /*@@*/ searchClient = InstrumentClient(new SearchClient(endpoint, fakeIndexName, credential, GetSearchClientOptions()));
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
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_HandleErrorsAsync
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create an invalid SearchClient
            string fakeIndexName = "doesnotexist";
            SearchClient searchClient = new SearchClient(endpoint, fakeIndexName, credential);
            /*@@*/ searchClient = InstrumentClient(new SearchClient(endpoint, fakeIndexName, credential, GetSearchClientOptions()));
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
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
            // Create a new SearchIndexClient
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
            /*@@*/ indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));

            // Get and report the Search Service statistics
            Response<SearchServiceStatistics> stats = await indexClient.GetServiceStatisticsAsync();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} of {stats.Value.Counters.IndexCounter.Quota} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
        }

        [Test]
        [AsyncOnly]
        public async Task CreateIndexerAsync()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAsync(this, populate: true);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("STORAGE_CONNECTION_STRING", resources.StorageAccountConnectionString);
            Environment.SetEnvironmentVariable("STORAGE_CONTAINER", resources.BlobContainerName);

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
                /*@@*/ indexClient = resources.GetIndexClient();

                // Create a synonym map from a file containing country names and abbreviations
                // using the Solr format with entry on a new line using \n, for example:
                // United States of America,US,USA\n
                string synonymMapName = "countries";
                /*@@*/ synonymMapName = Recording.Random.GetName();
                string synonymMapPath = "countries.txt";
                /*@@*/ synonymMapPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "countries.txt");

                SynonymMap synonyms;
                //@@using (StreamReader file = File.OpenText(synonymMapPath))
                //@@{
                //@@    synonyms = new SynonymMap(synonymMapName, file);
                //@@}
                /*@@*/ synonyms = new SynonymMap(synonymMapName, CountriesSolrSynonymMap);

                await indexClient.CreateSynonymMapAsync(synonyms);
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateSynonymMap

                // Make sure our synonym map gets deleted, which is not deleted when our
                // index is deleted when our SearchResources goes out of scope.
                cleanUpTasks.Push(() => indexClient.DeleteSynonymMapAsync(synonymMapName));

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateIndex
                // Create the index
                string indexName = "hotels";
                /*@@*/ indexName = Recording.Random.GetName();
                SearchIndex index = new SearchIndex(indexName)
                {
                    Fields =
                    {
                        new SimpleField("hotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
                        new SearchableField("hotelName") { IsFilterable = true, IsSortable = true },
                        new SearchableField("description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
                        new SearchableField("descriptionFr") { AnalyzerName = LexicalAnalyzerName.FrLucene },
                        new SearchableField("tags", collection: true) { IsFilterable = true, IsFacetable = true },
                        new ComplexField("address")
                        {
                            Fields =
                            {
                                new SearchableField("streetAddress"),
                                new SearchableField("city") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                                new SearchableField("stateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                                new SearchableField("country") { SynonymMapNames = new[] { synonymMapName }, IsFilterable = true, IsSortable = true, IsFacetable = true },
                                new SearchableField("postalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true }
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
                /*@@*/ indexerClient = resources.GetIndexerClient();

                string dataSourceConnectionName = "hotels";
                /*@@*/ dataSourceConnectionName = Recording.Random.GetName();
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

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Skillset
                // Translate English descriptions to French.
                // See https://docs.microsoft.com/azure/search/cognitive-search-skill-text-translation for details of the Text Translation skill.
                TextTranslationSkill translationSkill = new TextTranslationSkill(
                    inputs: new[]
                    {
                        new InputFieldMappingEntry("text") { Source = "/document/description" }
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
                // See https://docs.microsoft.com/azure/search/cognitive-search-skill-conditional for details of the Conditional skill.
                ConditionalSkill conditionalSkill = new ConditionalSkill(
                    inputs: new[]
                    {
                        new InputFieldMappingEntry("condition") { Source = "= $(/document/descriptionFr) == null" },
                        new InputFieldMappingEntry("whenTrue") { Source = "/document/descriptionFrTranslated" },
                        new InputFieldMappingEntry("whenFalse") { Source = "/document/descriptionFr" }
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
                /*@@*/ skillsetName = Recording.Random.GetName();
                SearchIndexerSkillset skillset = new SearchIndexerSkillset(
                    skillsetName,
                    new SearchIndexerSkill[] { translationSkill, conditionalSkill })
                {
                    //@@CognitiveServicesAccount =  new CognitiveServicesAccountKey(Environment.GetEnvironmentVariable("COGNITIVE_KEY"))
                    /*@@*/ CognitiveServicesAccount = new DefaultCognitiveServicesAccount() // This works for our very small hotel data set.
                };

                await indexerClient.CreateSkillsetAsync(skillset);
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Skillset

                // Make sure our skillset gets deleted, which is not deleted when our
                // index is deleted when our SearchResources goes out of scope.
                cleanUpTasks.Push(() => indexerClient.DeleteSkillsetAsync(skillsetName));

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_CreateIndexer
                string indexerName = "hotels";
                /*@@*/ indexerName = Recording.Random.GetName();
                SearchIndexer indexer = new SearchIndexer(
                    indexerName,
                    dataSourceConnectionName,
                    indexName)
                {
                    // We only want to index fields defined in our index, excluding descriptionFr if defined.
                    FieldMappings =
                    {
                        new FieldMapping("hotelId"),
                        new FieldMapping("hotelName"),
                        new FieldMapping("description"),
                        new FieldMapping("tags"),
                        new FieldMapping("address")
                    },
                    OutputFieldMappings =
                    {
                        new FieldMapping("/document/descriptionFrFinal") { TargetFieldName = "descriptionFr" }
                    },
                    Parameters = new IndexingParameters
                    {
                        // Tell the indexer to parse each blob as a separate JSON document.
                        // See https://docs.microsoft.com/azure/search/search-howto-index-json-blobs for details.
                        Configuration =
                        {
                            ["parsingMode"] = "json"
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

                // Wait a bit to make sure documents are indexed.
                await DelayAsync(TimeSpan.FromSeconds(5));

                #region Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Query
                // Get a SearchClient from the SearchIndexClient to share its pipeline.
                SearchClient searchClient = indexClient.GetSearchClient(indexName);
                /*@@*/ searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));

                // Query for hotels with an ocean view.
                SearchResults<Hotel> results = await searchClient.SearchAsync<Hotel>("ocean view");
                /*@@*/
                bool found = false;
                await foreach (SearchResult<Hotel> result in results.GetResultsAsync())
                {
                    Hotel hotel = result.Document;
                    /*@@*/ if (hotel.HotelId == "6") { Assert.IsNotNull(hotel.DescriptionFr); found = true; }

                    Console.WriteLine($"{hotel.HotelName} ({hotel.HotelId})");
                    Console.WriteLine($"  Description (English): {hotel.Description}");
                    Console.WriteLine($"  Description (French):  {hotel.DescriptionFr}");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_CreateIndexerAsync_Query

                Assert.IsTrue(found, "Expected hotel #6 not found in search results");
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
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
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
            /*@@*/ searchClient = InstrumentClient(new SearchClient(endpoint, indexName, credential, GetSearchClientOptions()));

            // Get and report the number of documents in the index
            Response<long> count = await searchClient.GetDocumentCountAsync();
            Console.WriteLine($"Search index {indexName} has {count.Value} documents.");
            #endregion Snippet:Azure_Search_Tests_Samples_GetCountAsync
        }
    }
}
