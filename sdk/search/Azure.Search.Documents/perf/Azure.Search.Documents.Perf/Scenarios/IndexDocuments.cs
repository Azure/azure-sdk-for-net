// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Azure.Search.Documents.Perf.Infrastructure;

namespace Azure.Search.Documents.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on indexing documents in an Azure Search service.
    /// </summary>
    /// <seealso cref="SearchServiceTest{SearchPerfOptions}" />
    public class IndexDocuments : SearchServiceTest<SearchPerfOptions>
    {
        private readonly List<Hotel> _hotels;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexDocuments"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public IndexDocuments(SearchPerfOptions options) : base(options)
        {
            _hotels = DocumentGenerator.GenerateHotels(options.Count, options.DocumentSize);
        }

        /// <summary>
        /// Indexes documents by calling <see cref="SearchClient.IndexDocuments{T}(IndexDocumentsBatch{T}, IndexDocumentsOptions, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            SearchClient.IndexDocuments(
                IndexDocumentsBatch.Upload(_hotels),
                new IndexDocumentsOptions() { ThrowOnAnyError = true },
                cancellationToken);
        }

        /// <summary>
        /// Indexes documents by calling <see cref="SearchClient.IndexDocumentsAsync{T}(IndexDocumentsBatch{T}, IndexDocumentsOptions, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await SearchClient.IndexDocumentsAsync(
                IndexDocumentsBatch.Upload(_hotels),
                new IndexDocumentsOptions() { ThrowOnAnyError = true },
                cancellationToken);
        }
    }
}
