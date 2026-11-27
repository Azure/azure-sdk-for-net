// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [Test]
        [LiveOnly]
        public async Task FileIngestionLroUploadReplaceAndRetrieve()
        {
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            string sourceName = PreviewName();
            string baseName = sourceName + "-kb";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;
            string openAIEndpoint = TestEnvironment.OpenAIEndpoint;
            string openAIKey = TestEnvironment.OpenAIKey;
            string embeddingDeployment = RequiredPreviewSetting("SEARCH_OPENAI_EMBEDDING_DEPLOYMENT_NAME");
            string embeddingModel = RequiredPreviewSetting("SEARCH_OPENAI_EMBEDDING_MODEL_NAME");
            using CancellationTokenSource timeout = new CancellationTokenSource(TimeSpan.FromMinutes(10));

            #region Snippet:Azure_Search_Documents_Sample28_FileIngestion_Create
            await indexClient.CreateKnowledgeSourceAsync(new FileKnowledgeSource(sourceName,
                new FileKnowledgeSourceParameters
                {
                    IngestionParameters = new KnowledgeSourceIngestionParameters
                    {
                        ContentExtractionMode = KnowledgeSourceContentExtractionMode.Minimal,
                        EmbeddingModel = new KnowledgeSourceAzureOpenAIVectorizer
                        {
                            AzureOpenAIParameters = new AzureOpenAIVectorizerParameters
                            {
                                ResourceUri = new Uri(openAIEndpoint),
                                ApiKey = openAIKey,
                                DeploymentName = embeddingDeployment,
                                ModelName = embeddingModel
                            }
                        }
                    }
                }));
            #endregion
            resources.TrackSource(sourceName);

            #region Snippet:Azure_Search_Documents_Sample28_FileIngestion_Ingest
#pragma warning disable SCME0004 // Multipart request models are experimental.
            UploadKnowledgeSourceFileMultipartContent upload = new UploadKnowledgeSourceFileMultipartContent(
                new FileUploadMetadata { FileName = "manuals/availability.txt", Metadata = { ["revision"] = "1" } },
                BinaryData.FromString("Revision 1: Hotel availability is monitored with bounded retries."));
            Operation<KnowledgeSourceFile> ingestion = await indexClient.IngestKnowledgeSourceFileMultipartAsync(
                WaitUntil.Started, sourceName, upload, timeout.Token);
#pragma warning restore SCME0004
            // Started returns before ingestion finishes. Wait for searchable content, not merely an HTTP upload acknowledgement.
            KnowledgeSourceFile uploaded = (await ingestion.WaitForCompletionAsync(TimeSpan.FromSeconds(2), timeout.Token)).Value;
            Console.WriteLine($"Ingested {uploaded.FileName}: {uploaded.FileId}");
            #endregion
            Assert.That(ingestion.HasCompleted && ingestion.HasValue, Is.True);
            Assert.That(uploaded.Metadata["revision"], Is.EqualTo("1"));

            #region Snippet:Azure_Search_Documents_Sample28_FileIngestion_Replace
#pragma warning disable SCME0004 // Multipart request models are experimental.
            UpdateKnowledgeSourceFileContent replacement = new UpdateKnowledgeSourceFileContent(
                new FileUploadMetadata { FileName = "manuals/availability.txt", Metadata = { ["revision"] = "2" } },
                BinaryData.FromString("Revision 2: Monitor hotel availability and retry transient failures with bounded exponential backoff."));
            Operation<KnowledgeSourceFile> replacing = await indexClient.IngestKnowledgeSourceFileReplacementAsync(
                WaitUntil.Started, sourceName, uploaded.FileId, replacement, timeout.Token);
#pragma warning restore SCME0004
            KnowledgeSourceFile replaced = (await replacing.WaitForCompletionAsync(TimeSpan.FromSeconds(2), timeout.Token)).Value;
            Console.WriteLine($"Replaced {replaced.FileName}; revision: {replaced.Metadata["revision"]}");

            int completed = 0;
            await foreach (KnowledgeSourceFileIngestionInfo operation in indexClient.GetKnowledgeSourceFileIngestionOperationsAsync(sourceName))
            {
                KnowledgeSourceFileIngestionInfo details = await indexClient.GetKnowledgeSourceFileIngestionOperationAsync(sourceName, operation.Id);
                Console.WriteLine($"Ingestion status: {details.Status}");
                if (details.Status.ToString() == "Succeeded" && details.Result?.FileId == uploaded.FileId)
                {
                    completed++;
                }
            }
            #endregion
            Assert.That(replaced.FileId, Is.EqualTo(uploaded.FileId));
            Assert.That(replaced.Metadata["revision"], Is.EqualTo("2"));
            Assert.That(completed, Is.GreaterThanOrEqualTo(2));

            #region Snippet:Azure_Search_Documents_Sample28_FileIngestion_Retrieve
            await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName, new[] { new KnowledgeSourceReference(sourceName) })
            {
                RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort(),
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
            });
#if !SNIPPET
            resources.TrackBase(baseName);
#endif
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
#if !SNIPPET
            retrievalClient = CreatePreviewRetrievalClient(resources, baseName);
#endif
            KnowledgeBaseRetrievalRequest request = PreviewIntent("hotel availability retry transient failures");
            request.KnowledgeSourceParams.Add(new FileKnowledgeSourceParams(sourceName)
            {
                IncludeReferences = true,
                IncludeReferenceSourceData = true
            });
            KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(request);
            #endregion
            Assert.That(response.References.OfType<KnowledgeBaseFileReference>().Any(reference =>
                reference.DocName?.EndsWith("availability.txt", StringComparison.Ordinal) == true), Is.True);
            string sourceText = string.Join("\n", response.References.OfType<KnowledgeBaseFileReference>()
                .SelectMany(reference => reference.SourceData.Values).Select(value => value.ToString()));
            Assert.That(sourceText, Does.Contain("Revision 2").And.Contain("exponential backoff"));
            Assert.That(sourceText, Does.Not.Contain("Revision 1"));
            Assert.That(response.Activity.All(activity => activity.Error == null), Is.True);
        }
    }
}
