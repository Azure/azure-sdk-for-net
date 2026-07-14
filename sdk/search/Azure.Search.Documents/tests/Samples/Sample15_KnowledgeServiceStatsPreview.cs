// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample15_ServiceStats_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample15_ServiceStats_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public partial class KnowledgeServiceStatsPreview : SearchTestBase
    {
        public KnowledgeServiceStatsPreview(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task GetServiceStatsWithKnowledgeCounts()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Tests_Samples_Sample15_ServiceStats_KnowledgeCounts
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Get service statistics including knowledge retrieval counters
            SearchServiceStatistics stats = await indexClient.GetServiceStatisticsAsync();
            SearchServiceCounters counters = stats.Counters;

            // Display the new knowledge retrieval counters
            Console.WriteLine("=== Knowledge Retrieval Service Statistics ===");
            Console.WriteLine($"Knowledge Bases: {counters.KnowledgeBaseCounter.Usage} / {counters.KnowledgeBaseCounter.Quota}");
            Console.WriteLine($"Knowledge Sources: {counters.KnowledgeSourceCounter.Usage} / {counters.KnowledgeSourceCounter.Quota}");

            // Display other service counters for context
            Console.WriteLine($"\nIndexes: {counters.IndexCounter.Usage} / {counters.IndexCounter.Quota}");
            Console.WriteLine($"Documents: {counters.DocumentCounter.Usage}");
            Console.WriteLine($"Storage size (bytes): {counters.StorageSizeCounter.Usage}");
            #endregion Snippet:Azure_Search_Tests_Samples_Sample15_ServiceStats_KnowledgeCounts

            Assert.IsNotNull(counters.KnowledgeBaseCounter);
            Assert.IsNotNull(counters.KnowledgeSourceCounter);
        }
    }
}
