// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

namespace Azure.Search.Documents.Tests.Samples
{
    #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_LegacyProduct
    public class Product
    {
        [SimpleField(IsKey = true)]
        public string Id { get; set; }

        [SearchableField(IsFilterable = true)]
        public string Name { get; set; }

        [SimpleField(IsSortable = true)]
        public double Price { get; set; }

        public override string ToString() =>
            $"{Id}: {Name} for {Price:C}";
    }
    #endregion

    public class IndexingDocuments : SearchTestBase
    {
        public IndexingDocuments(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_GenerateCatalog
        public IEnumerable<Product> GenerateCatalog(int count = 1000)
        {
            // Adapted from https://weblogs.asp.net/dfindley/Microsoft-Product-Name-Generator
            var prefixes = new[] { null, "Visual", "Compact", "Embedded", "Expression" };
            var products = new[] { null, "Windows", "Office", "SQL", "FoxPro", "BizTalk" };
            var terms = new[] { "Web", "Robotics", "Network", "Testing", "Project", "Small Business", "Team", "Management", "Graphic", "Presentation", "Communication", "Workflow", "Ajax", "XML", "Content", "Source Control" };
            var type = new[] { null, "Client", "Workstation", "Server", "System", "Console", "Shell", "Designer" };
            var suffix = new[] { null, "Express", "Standard", "Professional", "Enterprise", "Ultimate", "Foundation", ".NET", "Framework" };
            var components = new[] { prefixes, products, terms, type, suffix };

#if SNIPPET
            var random = new Random();
#else
            TestRandom random = Recording.Random;
#endif
            string RandomElement(string[] values) => values[(int)(random.NextDouble() * values.Length)];
            double RandomPrice() => (random.Next(2, 20) * 100.0) / 2.0 - .01;

            for (int i = 1; i <= count; i++)
            {
                yield return new Product
                {
                    Id = i.ToString(),
                    Name = string.Join(" ", components.Select(RandomElement).Where(n => n != null)),
                    Price = RandomPrice()
                };
            }
        }
        #endregion

        private async Task<SearchClient> CreateIndexAsync(SearchResources resources)
        {
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_CreateIndex_Connect
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

            // Create a client for manipulating search indexes
            AzureKeyCredential credential = new AzureKeyCredential(key);
            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
            #endregion

            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_CreateIndex_Create
            // Create the search index
            string indexName = "products";
#if !SNIPPET
            indexName = Recording.Random.GetName();
#endif
            await indexClient.CreateIndexAsync(
                new SearchIndex(indexName)
                {
                    Fields = new FieldBuilder().Build(typeof(Product))
                });
            #endregion

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_CreateIndex_Client
            SearchClient searchClient = indexClient.GetSearchClient(indexName);
            #endregion

            searchClient = InstrumentClient(searchClient);

            return searchClient;
        }

        [Test]
        [LiveOnly]
        public async Task SimpleIndexing()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchClient searchClient = null;
            try
            {
                searchClient = await CreateIndexAsync(resources);

                // Simple
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_SimpleIndexing1
                IEnumerable<Product> products = GenerateCatalog(count: 1000);
                await searchClient.UploadDocumentsAsync(products);
                #endregion

                await WaitForDocumentCountAsync(searchClient, 1000);

                // Check
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_SimpleIndexing2
                Assert.AreEqual(1000, (int)await searchClient.GetDocumentCountAsync());
                #endregion

                // Too many
                try
                {
                    #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_SimpleIndexing3
                    IEnumerable<Product> all = GenerateCatalog(count: 100000);
                    await searchClient.UploadDocumentsAsync(all);
                    #endregion

                    Assert.Fail("Expected too many documents failure.");
                }
                catch (RequestFailedException ex)
                {
                    Assert.AreEqual(400, ex.Status);
                }
            }
            finally
            {
                if (searchClient != null)
                {
                    await resources.GetIndexClient().DeleteIndexAsync(searchClient.IndexName);
                }
            }
        }

        [Test]
        [LiveOnly]
        public async Task BufferedSender()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);
            SearchClient searchClient = null;
            try
            {
                searchClient = await CreateIndexAsync(resources);

                // Simple
                {
                    searchClient = GetOriginal(searchClient);

                    #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_BufferedSender1
                    await using SearchIndexingBufferedSender<Product> indexer =
                        new SearchIndexingBufferedSender<Product>(searchClient);
                    await indexer.UploadDocumentsAsync(GenerateCatalog(count: 100000));
                    #endregion
#if SNIPPET
                    #region Snippet:Azure_Search_Documents_Tests_Samples_Sample05_IndexingDocuments_BufferedSender2
                    await indexer.FlushAsync();
                    Assert.AreEqual(100000, (int)await searchClient.GetDocumentCountAsync());
                    #endregion
#endif
                }

                await WaitForDocumentCountAsync(searchClient, 100000);

                // Check
                Assert.AreEqual(100000, (int)await searchClient.GetDocumentCountAsync());
            }
            finally
            {
                if (searchClient != null)
                {
                    await resources.GetIndexClient().DeleteIndexAsync(searchClient.IndexName);
                }
            }
        }
    }
}
