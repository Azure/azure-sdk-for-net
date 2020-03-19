// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
#region Snippet:Azure_Search_Tests_Samples_Namespaces
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public class HelloWorld : SearchTestBase
    {
        public HelloWorld(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
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

            // Create a new SearchServiceClient
            SearchServiceClient search = new SearchServiceClient(endpoint, credential);
            /*@@*/ search = InstrumentClient(new SearchServiceClient(endpoint, credential, GetSearchClientOptions()));

            // Perform an operation
            //@@ Response<SearchServiceStatistics> stats = search.GetStatistics();
            /*@@*/ Response<SearchServiceStatistics> stats = await search.GetStatisticsAsync();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_CreateClient

            Assert.AreEqual(1, stats.Value.Counters.IndexCounter.Usage);
        }

        [Test]
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

            // Create a new SearchServiceClient
            SearchServiceClient search = new SearchServiceClient(endpoint, credential);
            /*@@*/ search = InstrumentClient(new SearchServiceClient(endpoint, credential, GetSearchClientOptions()));

            // Perform an operation
            Response<SearchServiceStatistics> stats = await search.GetStatisticsAsync();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_CreateClientAsync

            Assert.AreEqual(1, stats.Value.Counters.IndexCounter.Usage);
        }

        [Test]
        public async Task HandleErrors()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_HandleErrors
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create an invalid SearchIndexClientClient
            string fakeIndexName = "doesnotexist";
            SearchIndexClient index = new SearchIndexClient(endpoint, fakeIndexName, credential);
            /*@@*/ index = InstrumentClient(new SearchIndexClient(endpoint, fakeIndexName, credential, GetSearchClientOptions()));
            try
            {
                //@@ index.GetCount();
                /*@@*/ await index.GetDocumentCountAsync();
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine("Index wasn't found.");
            }
            #endregion Snippet:Azure_Search_Tests_Samples_HandleErrors
        }

        [Test]
        public async Task HandleErrorsAsync()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_HandleErrorsAsync
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            // Create an invalid SearchIndexClientClient
            string fakeIndexName = "doesnotexist";
            SearchIndexClient index = new SearchIndexClient(endpoint, fakeIndexName, credential);
            /*@@*/ index = InstrumentClient(new SearchIndexClient(endpoint, fakeIndexName, credential, GetSearchClientOptions()));
            try
            {
                await index.GetDocumentCountAsync();
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
            // Create a new SearchServiceClient
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            SearchServiceClient search = new SearchServiceClient(endpoint, credential);
            /*@@*/ search = InstrumentClient(new SearchServiceClient(endpoint, credential, GetSearchClientOptions()));

            // Get and report the Search Service statistics
            Response<SearchServiceStatistics> stats = await search.GetStatisticsAsync();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} of {stats.Value.Counters.IndexCounter.Quota} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
        }

        [Test]
        public async Task GetCountAsync()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);

            #region Snippet:Azure_Search_Tests_Samples_GetCountAsync
            // Create a SearchIndexClient
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");
            SearchIndexClient index = new SearchIndexClient(endpoint, indexName, credential);
            /*@@*/ index = InstrumentClient(new SearchIndexClient(endpoint, indexName, credential, GetSearchClientOptions()));

            // Get and report the number of documents in the index
            Response<long> count = await index.GetDocumentCountAsync();
            Console.WriteLine($"Search index {indexName} has {count.Value} documents.");
            #endregion Snippet:Azure_Search_Tests_Samples_GetCountAsync
        }
    }
}
