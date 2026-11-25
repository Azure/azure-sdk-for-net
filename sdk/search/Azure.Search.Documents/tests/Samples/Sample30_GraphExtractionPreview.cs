// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [Test]
        [LiveOnly]
        public async Task ManagedGraphExtractionCacheStatusAndRetrieval()
        {
            string folder = ApprovedPreviewFolder("SEARCH_GRAPH_SOURCE_APPROVED", "AZURE_STORAGE_FOLDER");
            KnowledgeBaseAzureOpenAIModel chat = PreviewChatModel();
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            SearchIndexerClient indexerClient = CreatePreviewIndexerClient(resources);
            string sourceName = PreviewName();
            string baseName = sourceName + "-kb";
            string graphName = "hotels";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;
            string openAIEndpoint = TestEnvironment.OpenAIEndpoint;
            string openAIKey = TestEnvironment.OpenAIKey;
            string embeddingDeployment = RequiredPreviewSetting("AZURE_OPENAI_EMBEDDING_DEPLOYMENT");
            string embeddingModel = RequiredPreviewSetting("AZURE_OPENAI_EMBEDDING_MODEL");
            #region Snippet:Azure_Search_Documents_Sample30_Ontology
            string ontology = """
                {
                  "@context": {
                    "owl": "http://www.w3.org/2002/07/owl#",
                    "rdfs": "http://www.w3.org/2000/01/rdf-schema#",
                    "ekg": "https://schema.search.azure.com/graph-extraction#"
                  },
                  "@graph": [
                    { "@id": "ekg:Hotel", "@type": "owl:Class",
                      "rdfs:comment": "A hotel property, distinct from its operating organization." },
                    { "@id": "ekg:Organization", "@type": "owl:Class",
                      "rdfs:comment": "An organization operating hotel properties." },
                    { "@id": "ekg:operatedBy", "@type": "owl:ObjectProperty",
                      "rdfs:domain": { "@id": "ekg:Hotel" }, "rdfs:range": { "@id": "ekg:Organization" },
                      "rdfs:comment": "The organization operating the hotel." }
                  ]
                }
                """;
            #endregion

            #region Snippet:Azure_Search_Documents_Sample30_GraphExtraction
            AzureBlobKnowledgeSource source = new AzureBlobKnowledgeSource(sourceName,
                new AzureBlobKnowledgeSourceParameters(
                    RequiredPreviewSetting("AZURE_STORAGE_CONNECTION_STRING"),
                    RequiredPreviewSetting("AZURE_STORAGE_CONTAINER"))
                {
                    FolderPath = folder,
                    IsADLSGen2 = false,
                    GraphExtraction = new KnowledgeSourceGraphExtractionParameters(graphName)
                    {
                        Ontology = new KnowledgeSourceGraphOntology("inline", ontology) { Name = "hotel-relationships" }
                    },
                    IngestionParameters = new KnowledgeSourceIngestionParameters
                    {
                        EmbeddingModel = new KnowledgeSourceAzureOpenAIVectorizer
                        {
                            AzureOpenAIParameters = new AzureOpenAIVectorizerParameters
                            {
                                ResourceUri = new Uri(openAIEndpoint),
                                ApiKey = openAIKey,
                                DeploymentName = embeddingDeployment,
                                ModelName = embeddingModel
                            }
                        },
                        ChatCompletionModel = chat,
                        ContentExtractionMode = KnowledgeSourceContentExtractionMode.Minimal,
                        DisableImageVerbalization = true,
                        Cache = new KnowledgeSourceCache(RequiredPreviewSetting("SEARCH_GRAPH_CACHE_CONNECTION_STRING"))
                        {
                            EnableReprocessing = true
                        }
                    }
                });
            await indexClient.CreateKnowledgeSourceAsync(source);
#if !SNIPPET
            resources.TrackSource(sourceName);
#endif
            await WaitForPreviewSourceAsync(indexClient, sourceName);
            AzureBlobKnowledgeSource stored = (AzureBlobKnowledgeSource)(await indexClient.GetKnowledgeSourceAsync(sourceName)).Value;
            // Read only generated names returned by this newly created source; never guess shared names.
            string indexerName = OwnedPreviewGeneratedResource(stored, "indexer");
            string graphIndexName = OwnedPreviewGeneratedResource(stored, "graphIndex");
            string chunksIndexName = OwnedPreviewGeneratedResource(stored, "index");
            string dataSourceName = OwnedPreviewGeneratedResource(stored, "datasource");
            SearchIndexerDataSourceConnection dataSource = await indexerClient.GetDataSourceConnectionAsync(dataSourceName);
            if (dataSource.Container.Query != folder)
            {
                throw new InvalidOperationException("The generated data source changed the approved Blob folder scope.");
            }
            CompletedSynchronizationState completed = await WaitForPreviewIngestionAsync(
                indexClient, indexerClient, sourceName, indexerName);
            Console.WriteLine($"Written graph triples in this synchronization: {completed.GraphStatistics?.TriplesWritten}");
            // A successful ingestion or unchanged chunk count does not establish a cache hit.
            #endregion
            Assert.That(string.IsNullOrEmpty(stored.AzureBlobParameters.IngestionParameters.Cache.StorageConnectionString), Is.True,
                "The cache connection string is write-only.");
            Assert.That(completed.GraphStatistics, Is.Not.Null);
            Assert.That(completed.GraphStatistics.TriplesWritten, Is.GreaterThan(0));
            Assert.That((await CreatePreviewSearchClient(resources, chunksIndexName).GetDocumentCountAsync()).Value, Is.GreaterThan(0));

            #region Snippet:Azure_Search_Documents_Sample30_GraphRetrieval
            SearchIndex graphIndex = await indexClient.GetIndexAsync(graphIndexName);
            string graphFilter = $"{graphIndex.GraphProfile.Fields.GraphNameField} eq '{graphName}'";
            SearchClient graphClient = new SearchClient(endpoint, graphIndexName, credential);
#if !SNIPPET
            graphClient = CreatePreviewSearchClient(resources, graphIndexName);
#endif
            GraphQueryResult relationships = await graphClient.GraphAsync(
                "MATCH (h:Hotel)-[r:operatedBy]->(o:Organization) RETURN h.name AS hotel, o.name AS organization LIMIT 10",
                filter: graphFilter,
                provenance: new GraphQueryProvenanceParameters(GraphQueryProvenanceKind.Ids) { MaxEvidencePerRow = 5 },
                includeDiagnostics: true, includeStatistics: true);
            foreach (GraphQueryRow row in relationships.Value)
            {
                Console.WriteLine($"{row.AdditionalProperties["hotel"]}: {row.AdditionalProperties["organization"]}");
            }
            await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName,
                new[] { new KnowledgeSourceReference(sourceName) })
            {
                Models = { chat },
                RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort(),
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
            });
#if !SNIPPET
            resources.TrackBase(baseName);
#endif
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
#if !SNIPPET
            retrievalClient = CreatePreviewRetrievalClient(resources, baseName);
#endif
            KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(
                new KnowledgeBaseRetrievalRequest
                {
                    Messages =
                    {
                        new KnowledgeBaseMessage(new[]
                        {
                            new KnowledgeBaseMessageTextContent("Using the knowledge graph, which organizations operate the hotels?")
                        }) { Role = "user" }
                    },
                    IncludeActivity = true,
                    KnowledgeSourceParams =
                    {
                        new AzureBlobKnowledgeSourceParams(sourceName)
                        {
                            IncludeReferences = true,
                            IncludeReferenceSourceData = true,
                            GraphParameters = new KnowledgeSourceGraphParams { IncludeQuery = true }
                        }
                    }
                });
            foreach (KnowledgeBaseGraphSearchActivityRecord activity in response.Activity.OfType<KnowledgeBaseGraphSearchActivityRecord>())
            {
                Console.WriteLine($"Generated GQL: {activity.GraphSearchArguments?.Gql}");
            }
            #endregion
            Assert.That(graphIndex.GraphProfile.ProvenanceIndexName, Is.EqualTo(chunksIndexName));
            Assert.That(relationships.Value.Any(row =>
                row.AdditionalProperties["hotel"].ToObjectFromJson<string>() == "Historic Harbor Hotel" &&
                row.AdditionalProperties["organization"].ToObjectFromJson<string>() == "Contoso Hospitality" &&
                row.Provenance?.Evidence.Count > 0), Is.True);
            Assert.That(response.References.OfType<KnowledgeBaseGraphSearchReference>(), Is.Not.Empty);
            Assert.That(response.Activity.OfType<KnowledgeBaseGraphSearchActivityRecord>().Any(activity =>
                !string.IsNullOrEmpty(activity.GraphSearchArguments?.Gql)), Is.True);
            Assert.That(response.Activity.All(activity => activity.Error == null), Is.True);
        }

        private static string ApprovedPreviewFolder(string approvalVariable, string folderVariable)
        {
            if (!string.Equals(Environment.GetEnvironmentVariable(approvalVariable), "true", StringComparison.OrdinalIgnoreCase))
            {
                Assert.Ignore($"Approve the dedicated synthetic Blob fixture with {approvalVariable}=true.");
            }
            string folder = RequiredPreviewSetting(folderVariable).Trim();
            if (folder.StartsWith("/", StringComparison.Ordinal) || folder.Contains("\\") ||
                !folder.EndsWith("/", StringComparison.Ordinal) || folder.Split('/').Any(part => part == ".." || part == ".") ||
                string.IsNullOrEmpty(folder.Trim('/')))
            {
                throw new InvalidOperationException("Use an approved nonempty Blob folder prefix ending in '/', not a container root.");
            }
            return folder;
        }

        #region Snippet:Azure_Search_Documents_Sample30_GeneratedResource
        private static string OwnedPreviewGeneratedResource(AzureBlobKnowledgeSource source, string kind)
        {
            if (source.AzureBlobParameters.CreatedResources?.AdditionalProperties.TryGetValue(kind, out string name) != true ||
                !name.StartsWith(source.Name + "-", StringComparison.Ordinal))
            {
                throw new InvalidOperationException("The newly created source did not return a run-owned generated resource.");
            }
            return name;
        }
        #endregion

        #region Snippet:Azure_Search_Documents_Sample30_WaitForIngestion
        private static async Task WaitForPreviewSourceAsync(SearchIndexClient indexes, string sourceName)
        {
            for (int attempt = 0; attempt < 60; attempt++)
            {
                KnowledgeSourceStatus status = await indexes.GetKnowledgeSourceStatusAsync(sourceName);
                if (status.SynchronizationStatus.ToString() == "active")
                {
                    return;
                }
                if (status.SynchronizationStatus.ToString().IndexOf("failed", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new InvalidOperationException("The run-owned knowledge source failed to initialize.");
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            throw new TimeoutException("The run-owned knowledge source did not become active within five minutes.");
        }

        private static async Task<CompletedSynchronizationState> WaitForPreviewIngestionAsync(
            SearchIndexClient indexes, SearchIndexerClient indexers, string sourceName, string indexerName)
        {
            for (int attempt = 0; attempt < 60; attempt++)
            {
                KnowledgeSourceStatus status = await indexes.GetKnowledgeSourceStatusAsync(sourceName);
                SearchIndexerStatus indexerStatus = await indexers.GetIndexerStatusAsync(indexerName);
                IndexerExecutionResult execution = indexerStatus.LastResult;
                if (indexerStatus.Status == IndexerStatus.Error ||
                    execution?.Status == IndexerExecutionStatus.TransientFailure)
                {
                    throw new InvalidOperationException("Run-owned ingestion failed; inspect dependency permissions and indexer errors.");
                }
                if (status.CurrentSynchronizationState == null && status.LastSynchronizationState != null &&
                    execution?.Status == IndexerExecutionStatus.Success)
                {
                    if (execution.FailedItemCount != 0 || status.LastSynchronizationState.ItemsUpdatesFailed != 0)
                    {
                        throw new InvalidOperationException("Ingestion completed with failed source documents.");
                    }
                    return status.LastSynchronizationState;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
            throw new TimeoutException("Run-owned ingestion did not complete successfully within five minutes.");
        }
        #endregion
    }
}
