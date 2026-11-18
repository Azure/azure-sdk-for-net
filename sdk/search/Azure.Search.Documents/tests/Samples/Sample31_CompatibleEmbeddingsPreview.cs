// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;
using OpenAI.Embeddings;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [Test]
        [LiveOnly]
        public async Task CompatibleIndexVectorizerMatchesRealEmbeddingControl()
        {
            OpenAICompatibleVectorizerParameters parameters = PreviewCompatibleEmbeddingParameters();
            Assert.That(parameters.ModelName.ToString(), Is.EqualTo(RequiredPreviewSetting("AZURE_OPENAI_EMBEDDING_MODEL")),
                "The control deployment and configured provider must use the same embedding model.");
            await using PreviewResources resources = CreatePreviewResources();
            string indexName = PreviewName();
            SearchIndexClient indexClient = resources.Indexes;
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;
            string openAIEndpoint = TestEnvironment.OpenAIEndpoint;
            string openAIKey = TestEnvironment.OpenAIKey;
            string embeddingDeployment = RequiredPreviewSetting("AZURE_OPENAI_EMBEDDING_DEPLOYMENT");
            SearchIndex index = PreviewHotelIndex(indexName);
            index.Fields.Add(new SearchField("content_vector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
            {
                IsSearchable = true,
                VectorSearchDimensions = parameters.Dimensions,
                VectorSearchProfileName = "compatible"
            });

            #region Snippet:Azure_Search_Documents_Sample31_CompatibleIndexVectorizer
            index.VectorSearch = new Azure.Search.Documents.Indexes.Models.VectorSearch
            {
                Algorithms = { new ExhaustiveKnnAlgorithmConfiguration("exact") },
                Profiles = { new VectorSearchProfile("compatible", "exact") { VectorizerName = "provider" } },
                Vectorizers = { new OpenAICompatibleVectorizer("provider", parameters) }
            };
            await indexClient.CreateIndexAsync(index);
#if !SNIPPET
            resources.TrackIndex(indexName);
#endif
            // Generate real control vectors using the existing native deployment behind the compatible route.
            string[] texts =
            {
                "Relaxing hotel with a pool and spa treatments.",
                "Airport hotel with shuttle buses for early flights.",
                "Downtown business hotel with meeting rooms and conference facilities."
            };
            EmbeddingClient embeddingClient = new AzureOpenAIClient(
                new Uri(openAIEndpoint), new AzureKeyCredential(openAIKey))
                .GetEmbeddingClient(embeddingDeployment);
            var embeddings = (await embeddingClient.GenerateEmbeddingsAsync(texts,
                new EmbeddingGenerationOptions { Dimensions = parameters.Dimensions })).Value;
            string[] keys = { "spa", "airport", "business" };
            SearchDocument[] documents = texts.Select((text, position) => new SearchDocument
            {
                ["id"] = keys[position],
                ["title"] = keys[position],
                ["content"] = text,
                ["content_vector"] = embeddings[position].ToFloats().ToArray()
            }).ToArray();
            SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
#if !SNIPPET
            searchClient = CreatePreviewSearchClient(resources, indexName);
#endif
            await UploadPreviewDocumentsAsync(searchClient, documents);
            SearchResults<SearchDocument> control = await searchClient.SearchAsync<SearchDocument>(null,
                new SearchOptions
                {
                    VectorSearch = new VectorSearchOptions
                    {
                        Queries = { new VectorizedQuery(embeddings[0].ToFloats())
                            { Fields = { "content_vector" }, KNearestNeighborsCount = 3, Exhaustive = true } }
                    },
                    Select = { "id", "content" }
                });
            SearchResults<SearchDocument> generated = await searchClient.SearchAsync<SearchDocument>(null,
                new SearchOptions
                {
                    VectorSearch = new VectorSearchOptions
                    {
                        Queries = { new VectorizableTextQuery(texts[0])
                            { Fields = { "content_vector" }, KNearestNeighborsCount = 3, Exhaustive = true } }
                    },
                    Select = { "id", "content" }
                });
            #endregion
            Assert.That((await ReadPreviewResultsAsync(control)).First().Document["id"], Is.EqualTo("spa"));
            Assert.That((await ReadPreviewResultsAsync(generated)).First().Document["id"], Is.EqualTo("spa"));
            SearchIndex stored = await resources.Indexes.GetIndexAsync(indexName);
            Assert.That(((OpenAICompatibleVectorizer)stored.VectorSearch.Vectorizers.Single()).OpenAICompatibleParameters.Headers.Count,
                Is.Zero);
        }

        [Test]
        [LiveOnly]
        public async Task CompatibleManagedBlobIngestionAndRetrieval()
        {
            string folder = ApprovedPreviewFolder("AZURE_SEARCH_COMPATIBLE_BLOB_SOURCE_APPROVED", "AZURE_SEARCH_COMPATIBLE_BLOB_FOLDER");
            OpenAICompatibleVectorizerParameters parameters = PreviewCompatibleEmbeddingParameters();
            KnowledgeBaseOpenAICompatibleModel chat = PreviewCompatibleChatModel();
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            SearchIndexerClient indexerClient = CreatePreviewIndexerClient(resources);
            string sourceName = PreviewName();
            string baseName = sourceName + "-kb";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;

            #region Snippet:Azure_Search_Documents_Sample31_CompatibleManagedIngestion
            await indexClient.CreateKnowledgeSourceAsync(new AzureBlobKnowledgeSource(sourceName,
                new AzureBlobKnowledgeSourceParameters(
                    RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_BLOB_CONNECTION_STRING"),
                    RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_BLOB_CONTAINER"))
                {
                    FolderPath = folder,
                    IngestionParameters = new KnowledgeSourceIngestionParameters
                    {
                        EmbeddingModel = new KnowledgeSourceOpenAICompatibleVectorizer(parameters),
                        ChatCompletionModel = chat,
                        ContentExtractionMode = KnowledgeSourceContentExtractionMode.Minimal,
                        DisableImageVerbalization = false
                    }
                }));
#if !SNIPPET
            resources.TrackCleanup(() => DeletePreviewCompatibleSourceAsync(resources, indexerClient, sourceName, folder));
#endif
            await WaitForPreviewSourceAsync(indexClient, sourceName);
            var stored = (AzureBlobKnowledgeSource)(await indexClient.GetKnowledgeSourceAsync(sourceName)).Value;
            string generatedIndexName = OwnedPreviewGeneratedResource(stored, "index");
            string indexerName = OwnedPreviewGeneratedResource(stored, "indexer");
            SearchIndexerDataSourceConnection dataSource = await indexerClient.GetDataSourceConnectionAsync(
                OwnedPreviewGeneratedResource(stored, "datasource"));
            if (dataSource.Container.Query != folder)
            {
                throw new InvalidOperationException("The generated data source changed the approved Blob folder scope.");
            }
            await WaitForPreviewIngestionAsync(indexClient, indexerClient, sourceName, indexerName);
            SearchIndex generatedIndex = await indexClient.GetIndexAsync(generatedIndexName);
            string vectorField = generatedIndex.Fields.First(field => field.VectorSearchDimensions != null).Name;
            SearchClient searchClient = new SearchClient(endpoint, generatedIndexName, credential);
#if !SNIPPET
            searchClient = CreatePreviewSearchClient(resources, generatedIndexName);
#endif
            SearchResults<SearchDocument> matches = await searchClient.SearchAsync<SearchDocument>(null, new SearchOptions
            {
                VectorSearch = new VectorSearchOptions
                {
                    Queries = { new VectorizableTextQuery("Which organizations operate the hotels?")
                            { Fields = { vectorField }, KNearestNeighborsCount = 3 } }
                }
            });
            await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName,
                new[] { new KnowledgeSourceReference(sourceName) })
            {
                Models = { chat },
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
                RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
            });
#if !SNIPPET
            resources.TrackBase(baseName);
#endif
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
#if !SNIPPET
            retrievalClient = CreatePreviewRetrievalClient(resources, baseName);
#endif
            KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(new KnowledgeBaseRetrievalRequest
            {
                Messages =
                {
                    new KnowledgeBaseMessage(new[]
                    {
                        new KnowledgeBaseMessageTextContent("Which organizations operate the hotels?")
                    }) { Role = "user" }
                },
                IncludeActivity = true
            });
            #endregion
            Assert.That(await ReadPreviewResultsAsync(matches), Is.Not.Empty);
            Assert.That(generatedIndex.VectorSearch.Vectorizers.OfType<OpenAICompatibleVectorizer>(), Is.Not.Empty);
            Assert.That(response.References, Is.Not.Empty);
            Assert.That(response.References.OfType<KnowledgeBaseAzureBlobReference>().Any(reference =>
                reference.BlobUrl?.AbsolutePath.Contains(folder) == true), Is.True);
            Assert.That(response.Activity.All(activity => activity.Error == null), Is.True);
        }

        private static async Task DeletePreviewCompatibleSourceAsync(
            PreviewResources resources, SearchIndexerClient indexers, string sourceName, string expectedFolder)
        {
            var source = (AzureBlobKnowledgeSource)(await resources.Indexes.GetKnowledgeSourceAsync(sourceName)).Value;
            if (source.Name != sourceName || source.AzureBlobParameters.FolderPath != expectedFolder)
            {
                throw new InvalidOperationException("The run-owned source binding changed before cleanup.");
            }
            string skillsetName = OwnedPreviewGeneratedResource(source, "skillset");
            try
            {
                await resources.Indexes.DeleteKnowledgeSourceAsync(sourceName, cancellationToken: CancellationToken.None);
            }
            catch (RequestFailedException exception) when (exception.Status == 400 &&
                exception.Message.StartsWith($"Failed to delete skillset '{skillsetName}' during cleanup", StringComparison.Ordinal))
            {
                // Recover only this known partial-delete failure. Never bypass a managed resource's ownership lock.
                try
                {
                    await indexers.DeleteSkillsetAsync(skillsetName, cancellationToken: CancellationToken.None);
                }
                catch (RequestFailedException missing) when (missing.Status == 404)
                {
                }
                await resources.Indexes.DeleteKnowledgeSourceAsync(sourceName, cancellationToken: CancellationToken.None);
            }
        }

        #region Snippet:Azure_Search_Documents_Sample31_EmbeddingParameters
        private static OpenAICompatibleVectorizerParameters PreviewCompatibleEmbeddingParameters()
        {
            OpenAICompatibleVectorizerParameters parameters = new OpenAICompatibleVectorizerParameters(
                new Uri(RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_EMBEDDING_URI")),
                RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_EMBEDDING_MODEL"))
            {
                Dimensions = int.Parse(RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_EMBEDDING_DIMENSIONS"), CultureInfo.InvariantCulture)
            };
            string headers = Environment.GetEnvironmentVariable("AZURE_SEARCH_COMPATIBLE_EMBEDDING_HEADERS_JSON");
            string audience = Environment.GetEnvironmentVariable("AZURE_SEARCH_COMPATIBLE_EMBEDDING_MI_AUDIENCE");
            if (!string.IsNullOrWhiteSpace(headers) == !string.IsNullOrWhiteSpace(audience))
            {
                throw new InvalidOperationException("Configure exactly one compatible embeddings authentication method.");
            }
            if (!string.IsNullOrWhiteSpace(audience))
            {
                parameters.ManagedIdentityAudience = audience;
            }
            else
            {
                foreach (KeyValuePair<string, string> header in JsonSerializer.Deserialize<Dictionary<string, string>>(headers))
                {
                    parameters.Headers.Add(header.Key, header.Value);
                }
            }
            return parameters;
        }
        #endregion
    }
}
