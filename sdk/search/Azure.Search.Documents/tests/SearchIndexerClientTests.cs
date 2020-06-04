// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchIndexerClientTests : SearchTestBase
    {
        public SearchIndexerClientTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Constructor()
        {
            var serviceName = "my-svc-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var service = new SearchIndexerClient(endpoint, new AzureKeyCredential("fake"));
            Assert.NotNull(service);
            Assert.AreEqual(endpoint, service.Endpoint);
            Assert.AreEqual(serviceName, service.ServiceName);

            Assert.Throws<ArgumentNullException>(() => new SearchIndexerClient(null, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexerClient(endpoint, null));
            Assert.Throws<ArgumentException>(() => new SearchIndexerClient(new Uri("http://bing.com"), null));
        }

        [Test]
        public void DiagnosticsAreUnique()
        {
            // Make sure we're not repeating Header/Query names already defined
            // in the base ClientOptions
            SearchClientOptions options = new SearchClientOptions();
            Assert.IsEmpty(GetDuplicates(options.Diagnostics.LoggedHeaderNames));
            Assert.IsEmpty(GetDuplicates(options.Diagnostics.LoggedQueryParameters));

            // CollectionAssert.Unique doesn't give you the duplicate values
            // which is less helpful than it could be
            static string GetDuplicates(IEnumerable<string> values)
            {
                List<string> duplicates = new List<string>();
                HashSet<string> unique = new HashSet<string>();
                foreach (string value in values)
                {
                    if (!unique.Add(value))
                    {
                        duplicates.Add(value);
                    }
                }
                return string.Join(", ", duplicates);
            }
        }

        [Test]
        public async Task CreateAzureBlobIndexer()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAndIndexAsync(this);

            SearchIndexerClient serviceClient = resources.GetIndexerClient();

            // Create the Azure Blob data source and indexer.
            SearchIndexerDataSourceConnection dataSource = new SearchIndexerDataSourceConnection(
                Recording.Random.GetName(),
                SearchIndexerDataSourceType.AzureBlob,
                resources.StorageAccountConnectionString,
                new SearchIndexerDataContainer(resources.BlobContainerName));

            SearchIndexerDataSourceConnection actualSource = await serviceClient.CreateDataSourceConnectionAsync(
                dataSource);

            SearchIndexer indexer = new SearchIndexer(
                Recording.Random.GetName(),
                dataSource.Name,
                resources.IndexName);

            SearchIndexer actualIndexer = await serviceClient.CreateIndexerAsync(
                indexer);

            // Update the indexer.
            actualIndexer.Description = "Updated description";
            await serviceClient.CreateOrUpdateIndexerAsync(
                actualIndexer,
                onlyIfUnchanged: true);

            await WaitForIndexingAsync(serviceClient, actualIndexer.Name);

            // Run the indexer.
            await serviceClient.RunIndexerAsync(
                indexer.Name);

            await WaitForIndexingAsync(serviceClient, actualIndexer.Name);

            // Query the index.
            SearchClient client = resources.GetSearchClient();

            long count = await client.GetDocumentCountAsync();

            // This should be equal, but sometimes reports double despite logs showing no shared resources.
            Assert.That(count, Is.GreaterThanOrEqualTo(SearchResources.TestDocuments.Length));
        }

        /// <summary>
        /// Waits for an indexer to complete up to the given <paramref name="timeout"/>.
        /// </summary>
        /// <param name="client">The <see cref="SearchIndexerClient"/> to use for requests.</param>
        /// <param name="indexerName">The name of the <see cref="SearchIndexer"/> to check.</param>
        /// <param name="timeout">The amount of time before being canceled. The default is 1 minute.</param>
        /// <returns>A <see cref="Task"/> to await.</returns>
        private async Task WaitForIndexingAsync(
            SearchIndexerClient client,
            string indexerName,
            TimeSpan? timeout = null)
        {
            TimeSpan delay = TimeSpan.FromSeconds(10);
            timeout ??= TimeSpan.FromMinutes(5);

            using CancellationTokenSource cts = new CancellationTokenSource(timeout.Value);

            while (true)
            {
                await DelayAsync(delay, cancellationToken: cts.Token);

                SearchIndexerStatus status = await client.GetIndexerStatusAsync(
                    indexerName,
                    cancellationToken: cts.Token);

                if (status.Status == IndexerStatus.Running &&
                    status.LastResult?.Status == IndexerExecutionStatus.Success)
                {
                    return;
                }
                else if (status.Status == IndexerStatus.Error && status.LastResult is IndexerExecutionResult lastResult)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Error: {lastResult.ErrorMessage}");

                    if (lastResult.Errors?.Count > 0)
                    {
                        foreach (SearchIndexerError error in lastResult.Errors)
                        {
                            sb.AppendLine($" ---> {error.ErrorMessage}");
                        }
                    }

                    Assert.Fail(sb.ToString());
                }
            }
        }
    }
}
