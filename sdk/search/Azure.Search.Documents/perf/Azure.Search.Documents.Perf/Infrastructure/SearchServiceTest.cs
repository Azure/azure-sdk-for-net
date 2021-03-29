// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using Azure.Test.Perf;

namespace Azure.Search.Documents.Perf.Infrastructure
{
    /// <summary>
    /// Base class for performance tests for the Azure Search service.
    /// </summary>
    /// <typeparam name="TOptions">An instance of type <see cref="PerfOptions"/>.</typeparam>
    public abstract class SearchServiceTest<TOptions> : PerfTest<TOptions> where TOptions: PerfOptions
    {
        /// <summary>
        /// Name of the suggester.
        /// </summary>
        protected static string SuggesterName = "sg";

        /// <summary>
        /// Search client instance.
        /// </summary>
        protected SearchClient SearchClient { get; private set; }

        private readonly SearchIndexClient _searchIndexClient;
        private readonly string _indexName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchServiceTest{TOptions}"/> class.
        /// </summary>
        /// <param name="options"></param>
        public SearchServiceTest(TOptions options) : base(options)
        {
            _searchIndexClient = new SearchIndexClient(
                new Uri(PerfTestEnvironment.Instance.SearchEndPoint),
                new AzureKeyCredential(PerfTestEnvironment.Instance.SearchAccountKey));

            _indexName = Guid.NewGuid().ToString();
            SearchClient = _searchIndexClient.GetSearchClient(_indexName);
        }

        /// <inheritdoc/>
        public override async Task GlobalSetupAsync()
        {
            SearchIndex index = new(_indexName)
            {
                Fields = new FieldBuilder().Build(typeof(Hotel)),
                Suggesters = { new SearchSuggester(SuggesterName, new string[] { nameof(Hotel.Description), nameof(Hotel.HotelName) }) }
            };

            await _searchIndexClient.CreateIndexAsync(index);
        }

        /// <inheritdoc/>
        public override async Task GlobalCleanupAsync()
        {
            await _searchIndexClient.DeleteIndexAsync(_indexName);
        }

        /// <summary>
        /// Populates the Azure Search index with `<paramref name="documentCount"/>` number of documents, each of `<paramref name="documentSize"/>` size.
        /// </summary>
        /// <param name="documentCount">Number of documents to index.</param>
        /// <param name="documentSize">Size of each document being indexed.</param>
        /// <returns>Task representing the asynchronous work.</returns>
        protected async Task PopulateIndexAsync(int documentCount, DocumentSize documentSize)
        {
            List<Hotel> hotels = DocumentGenerator.GenerateHotels(documentCount, documentSize);

            await SearchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotels), new IndexDocumentsOptions() { ThrowOnAnyError = true });

            long uploadedDocumentCount = 0;

            while (uploadedDocumentCount != documentCount)
            {
                uploadedDocumentCount = (await SearchClient.GetDocumentCountAsync()).Value;

                Thread.Sleep(1000);
            }
        }
    }
}
