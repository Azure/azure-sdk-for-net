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
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

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
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Perform an operation
            Response<SearchServiceStatistics> stats = await indexClient.GetServiceStatisticsAsync();
            Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
            #endregion Snippet:Azure_Search_Tests_Samples_CreateClientAsync

            Assert.AreEqual(1, stats.Value.Counters.IndexCounter.Usage);
        }
    }
}
