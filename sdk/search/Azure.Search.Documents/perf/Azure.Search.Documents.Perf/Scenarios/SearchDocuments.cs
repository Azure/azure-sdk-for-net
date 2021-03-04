// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Perf.Infrastructure;
using NUnit.Framework;

namespace Azure.Search.Documents.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on searching documents using an Azure Search service.
    /// </summary>
    /// <seealso cref="SearchServiceTest{SearchPerfOptions}" />
    public class SearchDocuments : SearchServiceTest<SearchPerfOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchDocuments"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public SearchDocuments(SearchPerfOptions options) : base(options)
        {
        }

        /// <inheritdoc/>
        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            await PopulateIndexAsync(Options.Count, Options.DocumentSize);
        }

        /// <summary>
        /// Searches documents by calling <see cref="SearchClient.Search{T}(string, SearchOptions, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            Models.SearchResults<Hotel> searchResults = SearchClient.Search<Hotel>(string.Empty, new SearchOptions() { IncludeTotalCount = true }, cancellationToken: cancellationToken).Value;

            int resultCount = 0;

            foreach (Models.SearchResult<Hotel> _ in searchResults.GetResults())
            {
                resultCount++;
            }

#if DEBUG
            Assert.AreEqual(Options.Count, searchResults.TotalCount);
#endif
        }

        /// <summary>
        /// Searches documents by calling <see cref="SearchClient.SearchAsync{T}(string, SearchOptions, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            Models.SearchResults<Hotel> searchResults = (await SearchClient.SearchAsync<Hotel>(string.Empty, new SearchOptions() { IncludeTotalCount = true }, cancellationToken: cancellationToken)).Value;

            int resultCount = 0;

            await foreach (Models.SearchResult<Hotel> _ in searchResults.GetResultsAsync())
            {
                resultCount++;
            }

#if DEBUG
            Assert.AreEqual(Options.Count, searchResults.TotalCount);
#endif
        }
    }
}
