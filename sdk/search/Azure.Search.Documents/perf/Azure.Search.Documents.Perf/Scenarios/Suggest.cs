// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Azure.Search.Documents.Perf.Infrastructure;
using NUnit.Framework;

namespace Azure.Search.Documents.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on getting suggestions for suggester-aware fields.
    /// </summary>
    /// <seealso cref="SearchServiceTest{SearchPerfOptions}" />
    public class Suggest : SearchServiceTest<SearchPerfOptions>
    {
        private const string SearchText = "his";

        /// <summary>
        /// Initializes a new instance of the <see cref="Suggest"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public Suggest(SearchPerfOptions options) : base(options)
        {
        }

        /// <inheritdoc/>
        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            await PopulateIndexAsync(Options.Count, Options.DocumentSize);
        }

        /// <summary>
        /// Gets suggestion results by calling <see cref="SearchClient.Suggest{T}(string, string, SuggestOptions, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            SuggestResults<Hotel> suggestResults = SearchClient.Suggest<Hotel>(SearchText, SuggesterName, cancellationToken: cancellationToken).Value;

#if DEBUG
            CollectionAssert.IsNotEmpty(suggestResults.Results);
#endif
        }

        /// <summary>
        /// Gets suggestion results by calling <see cref="SearchClient.SuggestAsync{T}(string, string, SuggestOptions, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            SuggestResults<Hotel> suggestResults = (await SearchClient.SuggestAsync<Hotel>(SearchText, SuggesterName, cancellationToken: cancellationToken)).Value;

#if DEBUG
            CollectionAssert.IsNotEmpty(suggestResults.Results);
#endif
        }
    }
}
