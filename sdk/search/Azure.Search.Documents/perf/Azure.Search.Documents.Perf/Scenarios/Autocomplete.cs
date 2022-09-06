//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Azure.Search.Documents.Perf.Infrastructure;
using NUnit.Framework;

namespace Azure.Search.Documents.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on getting auto-completion results from an Azure Search service.
    /// </summary>
    /// <seealso cref="SearchServiceTest{SearchPerfOptions}" />
    public class Autocomplete : SearchServiceTest<SearchPerfOptions>
    {
        private const string SearchText = "his";

        /// <summary>
        /// Initializes a new instance of the <see cref="Autocomplete"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public Autocomplete(SearchPerfOptions options) : base(options)
        {
        }

        /// <inheritdoc/>
        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            await PopulateIndexAsync(Options.Count, Options.DocumentSize);
        }

        /// <summary>
        /// Gets suggested query terms by calling <see cref="SearchClient.Autocomplete(string, string, AutocompleteOptions, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            AutocompleteResults autocompleteResults = SearchClient.Autocomplete(SearchText, SuggesterName, cancellationToken: cancellationToken).Value;

#if DEBUG
            Assert.AreEqual(1, autocompleteResults.Results.Count);
            Assert.AreEqual("historic", autocompleteResults.Results[0].Text);
#endif
        }

        /// <summary>
        /// Gets suggested query terms by calling <see cref="SearchClient.AutocompleteAsync(string, string, AutocompleteOptions, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            AutocompleteResults autocompleteResults = (await SearchClient.AutocompleteAsync(SearchText, SuggesterName, cancellationToken: cancellationToken)).Value;

#if DEBUG
            Assert.AreEqual(1, autocompleteResults.Results.Count);
            Assert.AreEqual("historic", autocompleteResults.Results[0].Text);
#endif
        }
    }
}
