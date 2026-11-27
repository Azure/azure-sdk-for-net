// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [Test]
        [LiveOnly]
        public async Task ChatCompletionSkillIndexesGroundedHotelFacts()
        {
            string folder = ApprovedPreviewFolder("AZURE_SEARCH_COMPATIBLE_BLOB_SOURCE_APPROVED", "AZURE_SEARCH_COMPATIBLE_BLOB_FOLDER");
            Uri uri = new Uri(RequiredPreviewSetting("SEARCH_SKILL_CHAT_URI"));
            if (uri.Scheme != Uri.UriSchemeHttps || !uri.AbsolutePath.EndsWith("/chat/completions", StringComparison.Ordinal))
            {
                throw new InvalidOperationException("The chat skill requires a complete HTTPS Chat Completions endpoint.");
            }
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            SearchIndexerClient indexers = CreatePreviewIndexerClient(resources);
            string name = PreviewName();
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;

            #region Snippet:Azure_Search_Documents_Sample32_ChatCompletionSkill
            ChatCompletionSkill skill = new ChatCompletionSkill(
                new[]
                {
                    new InputFieldMappingEntry("systemMessage") { Source = "='Extract only hotel facts explicitly in the text.'" },
                    new InputFieldMappingEntry("userMessage") { Source = "='List each hotel with its city, founding year, operator and amenities, if given.'" },
                    new InputFieldMappingEntry("text") { Source = "/document/content" }
                },
                new[] { new OutputFieldMappingEntry("response") { TargetName = "hotelFacts" } }, uri)
            {
                Name = "hotel-facts",
                Context = "/document",
                ApiKey = RequiredPreviewSetting("SEARCH_SKILL_CHAT_API_KEY")
            };
            await indexClient.CreateIndexAsync(new SearchIndex(name)
            {
                Fields =
                {
                    new SimpleField("id", SearchFieldDataType.String) { IsKey = true },
                    new SearchableField("content"),
                    new SearchableField("hotelFacts")
                }
            });
#if !SNIPPET
            resources.TrackIndex(name);
#endif
            await indexers.CreateDataSourceConnectionAsync(new SearchIndexerDataSourceConnection(
                name, SearchIndexerDataSourceType.AzureBlob,
                RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_BLOB_CONNECTION_STRING"),
                new SearchIndexerDataContainer(RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_BLOB_CONTAINER")) { Query = folder }));
#if !SNIPPET
            resources.TrackCleanup(() => indexers.DeleteDataSourceConnectionAsync(name, cancellationToken: CancellationToken.None));
#endif
            await indexers.CreateSkillsetAsync(new SearchIndexerSkillset(name, new[] { skill }));
#if !SNIPPET
            resources.TrackCleanup(() => indexers.DeleteSkillsetAsync(name, cancellationToken: CancellationToken.None));
#endif
            await indexers.CreateIndexerAsync(new SearchIndexer(name, name, name)
            {
                SkillsetName = name,
                Parameters = new IndexingParameters
                {
                    BatchSize = 1,
                    MaxFailedItems = 0,
                    MaxFailedItemsPerBatch = 0,
                    IndexingParametersConfiguration = new IndexingParametersConfiguration
                    {
                        IndexedFileNameExtensions = ".txt",
                        FailOnUnsupportedContentType = true,
                        FailOnUnprocessableDocument = true
                    }
                },
                FieldMappings =
                {
                    new FieldMapping("metadata_storage_path")
                    {
                        TargetFieldName = "id",
                        MappingFunction = new FieldMappingFunction("base64Encode")
                    }
                },
                OutputFieldMappings = { new FieldMapping("/document/hotelFacts") { TargetFieldName = "hotelFacts" } }
            });
#if !SNIPPET
            resources.TrackCleanup(() => indexers.DeleteIndexerAsync(name, cancellationToken: CancellationToken.None));
#endif
            await WaitForPreviewSkillAsync(indexers, name);
            SearchClient searchClient = new SearchClient(endpoint, name, credential);
#if !SNIPPET
            searchClient = CreatePreviewSearchClient(resources, name);
#endif
            await WaitForPreviewDocumentCountAsync(searchClient, 1);
            SearchResults<SearchDocument> results = await searchClient.SearchAsync<SearchDocument>("*",
                new SearchOptions { Select = { "id", "content", "hotelFacts" } });
            #endregion
            var documents = await ReadPreviewResultsAsync(results);
            Assert.That(documents.Count, Is.EqualTo(1));
            string content = (string)documents.Single().Document["content"];
            string facts = ((string)documents.Single().Document["hotelFacts"]).ToLowerInvariant();
            foreach (string term in new[] { "historic harbor", "seattle", "1984", "spa", "contoso", "mountain view", "denver", "2002", "alpine" })
            {
                Assert.That(content.ToLowerInvariant(), Does.Contain(term));
                Assert.That(facts, Does.Contain(term));
            }
        }

        #region Snippet:Azure_Search_Documents_Sample32_WaitForSkill
        private static async Task WaitForPreviewSkillAsync(SearchIndexerClient indexers, string name)
        {
            for (int attempt = 0; attempt < 120; attempt++)
            {
                SearchIndexerStatus status = await indexers.GetIndexerStatusAsync(name);
                IndexerExecutionResult result = status.LastResult;
                if (status.Status == IndexerStatus.Error || result?.Status == IndexerExecutionStatus.TransientFailure)
                {
                    throw new InvalidOperationException("Run-owned skill execution failed; inspect indexer errors and provider access.");
                }
                if (result?.Status == IndexerExecutionStatus.Success)
                {
                    if (result.ItemCount != 1 || result.FailedItemCount != 0 || result.Errors.Count != 0 || result.Warnings.Count != 0)
                    {
                        throw new InvalidOperationException("Skill execution must process exactly one fixture without errors or warnings.");
                    }
                    return;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            throw new TimeoutException("Run-owned chat skill execution did not complete within ten minutes.");
        }
        #endregion
    }
}
