// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
#endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Namespaces
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2026_04_01), ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_04_01)]
    public partial class SearchAliasOperations : SearchTestBase
    {
        public SearchAliasOperations(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task CreateAlias()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);

            string testAliasName = Recording.Random.GetName();
            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

                // Create an alias that maps to the given index
                string aliasName = "my-alias";
#if !SNIPPET
                aliasName = testAliasName;
#endif
                SearchAlias alias = new SearchAlias(aliasName, new[] { indexName });

                SearchAlias createdAlias = await indexClient.CreateAliasAsync(alias);
                Console.WriteLine($"Created alias '{createdAlias.Name}' pointing to index '{createdAlias.Indexes[0]}'");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Create

                Assert.AreEqual(testAliasName, createdAlias.Name);
                Assert.AreEqual(resources.IndexName, createdAlias.Indexes[0]);
            }
            finally
            {
                SearchIndexClient client = resources.GetIndexClient();
                try
                { await client.DeleteAliasAsync(testAliasName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }

        [Test]
        public async Task GetAlias()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            string testAliasName = Recording.Random.GetName();

            SearchIndexClient testClient = InstrumentClient(
                new SearchIndexClient(resources.Endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()));

            // Create an alias to retrieve
            SearchAlias alias = new SearchAlias(testAliasName, new[] { resources.IndexName });
            await testClient.CreateAliasAsync(alias);

            await DelayAsync(TimeSpan.FromSeconds(1));

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("ALIAS_NAME", testAliasName);

            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Get
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string aliasName = Environment.GetEnvironmentVariable("ALIAS_NAME");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = testClient;
#endif

                // Get a specific alias by name
                SearchAlias retrievedAlias = await indexClient.GetAliasAsync(aliasName);
                Console.WriteLine($"Alias '{retrievedAlias.Name}' points to index '{retrievedAlias.Indexes[0]}'");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Get

                Assert.AreEqual(testAliasName, retrievedAlias.Name);
            }
            finally
            {
                try
                { await testClient.DeleteAliasAsync(testAliasName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }

        [Test]
        public async Task ListAliases()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            string testAliasName = Recording.Random.GetName();

            SearchIndexClient testClient = InstrumentClient(
                new SearchIndexClient(resources.Endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()));

            // Create an alias to list
            SearchAlias alias = new SearchAlias(testAliasName, new[] { resources.IndexName });
            await testClient.CreateAliasAsync(alias);

            await DelayAsync(TimeSpan.FromSeconds(1));

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_List
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = testClient;
#endif

                // List all aliases in the search service
                await foreach (SearchAlias searchAlias in indexClient.GetAliasesAsync())
                {
                    Console.WriteLine($"Alias '{searchAlias.Name}' -> Index '{searchAlias.Indexes[0]}'");
                }
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_List
            }
            finally
            {
                try
                { await testClient.DeleteAliasAsync(testAliasName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }

        [Test]
        public async Task UpdateAlias()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            string testAliasName = Recording.Random.GetName();

            SearchIndexClient testClient = InstrumentClient(
                new SearchIndexClient(resources.Endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()));

            // Create an alias to update
            SearchAlias alias = new SearchAlias(testAliasName, new[] { resources.IndexName });
            await testClient.CreateAliasAsync(alias);

            await DelayAsync(TimeSpan.FromSeconds(1));

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("ALIAS_NAME", testAliasName);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);

            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Update
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string aliasName = Environment.GetEnvironmentVariable("ALIAS_NAME");
                string newIndexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = testClient;
#endif

                // Update the alias to point to a different index
                SearchAlias updatedAlias = new SearchAlias(aliasName, new[] { newIndexName });
                SearchAlias result = await indexClient.CreateOrUpdateAliasAsync(updatedAlias);
                Console.WriteLine($"Updated alias '{result.Name}' now points to '{result.Indexes[0]}'");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Update

                Assert.AreEqual(testAliasName, result.Name);
                Assert.AreEqual(resources.IndexName, result.Indexes[0]);
            }
            finally
            {
                try
                { await testClient.DeleteAliasAsync(testAliasName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }

        [Test]
        public async Task DeleteAlias()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            string testAliasName = Recording.Random.GetName();

            SearchIndexClient testClient = InstrumentClient(
                new SearchIndexClient(resources.Endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()));

            // Create an alias to delete
            SearchAlias alias = new SearchAlias(testAliasName, new[] { resources.IndexName });
            await testClient.CreateAliasAsync(alias);

            await DelayAsync(TimeSpan.FromSeconds(1));

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("ALIAS_NAME", testAliasName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Delete
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string aliasName = Environment.GetEnvironmentVariable("ALIAS_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = testClient;
#endif

            // Delete an alias by name
            await indexClient.DeleteAliasAsync(aliasName);
            Console.WriteLine($"Deleted alias '{aliasName}'");
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Delete

            // Verify it was deleted
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await testClient.GetAliasAsync(testAliasName);
            });
            Assert.AreEqual(404, ex.Status);
        }

        [Test]
        public async Task SearchUsingAlias()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            string testAliasName = Recording.Random.GetName();

            SearchIndexClient testClient = InstrumentClient(
                new SearchIndexClient(resources.Endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()));

            // Create an alias pointing to the hotels index
            SearchAlias alias = new SearchAlias(testAliasName, new[] { resources.IndexName });
            await testClient.CreateAliasAsync(alias);

            await DelayAsync(TimeSpan.FromSeconds(1));

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("ALIAS_NAME", testAliasName);

            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_SearchUsing
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string aliasName = Environment.GetEnvironmentVariable("ALIAS_NAME");

                // Use the alias name instead of the index name to search
                SearchClient searchClient = new SearchClient(endpoint, aliasName, credential);
#if !SNIPPET
                searchClient = InstrumentClient(new SearchClient(endpoint, aliasName, credential, GetSearchClientOptions()));
#endif

                SearchResults<SearchDocument> results = await searchClient.SearchAsync<SearchDocument>("luxury");
                await foreach (SearchResult<SearchDocument> result in results.GetResultsAsync())
                {
                    Console.WriteLine(result.Document["HotelName"]);
                }
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_SearchUsing
            }
            finally
            {
                try
                { await testClient.DeleteAliasAsync(testAliasName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }
    }
}
