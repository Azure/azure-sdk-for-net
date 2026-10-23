// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Namespaces
using Azure.Identity;
using Azure.Core;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_10_01)]
    public partial class FileKnowledgeSourceSamples : SearchTestBase
    {
        public FileKnowledgeSourceSamples(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task CreateAndUseFileKnowledgeSource()
        {
            if (string.IsNullOrEmpty(TestEnvironment.OpenAIEndpoint))
            {
                Assert.Ignore("An Azure OpenAI endpoint with the required deployments is needed for File knowledge source ingestion.");
            }

            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                TokenCredential credential = new DefaultAzureCredential();
#if !SNIPPET
                credential = TestEnvironment.Credential;
#endif

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                // Create a File knowledge source for direct file upload and indexing.
                // The File source supports uploading documents directly to the search service
                // without needing an external data store like Azure Blob Storage.
                string knowledgeSourceName = "my-file-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif

                // Configure ingestion parameters with content extraction mode and embedding model
                string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");

                FileKnowledgeSource fileSource = new FileKnowledgeSource(
                    knowledgeSourceName,
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
                                    DeploymentName = "text-embedding-3-large",
                                    ModelName = "text-embedding-3-large"
                                }
                            }
                        }
                    })
                {
                    Description = "File-based knowledge source for uploaded documents"
                };

                KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(fileSource);
                Console.WriteLine($"Created file knowledge source '{createdSource.Name}'");
                KnowledgeSourceStatus sourceStatus = await indexClient.GetKnowledgeSourceStatusAsync(knowledgeSourceName);
                Console.WriteLine($"Remaining File capacity: {sourceStatus.FileCapacity?.RemainingFileCount}");
                #endregion Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Create

                Assert.AreEqual(testSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is FileKnowledgeSource);

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_UploadFiles
                // Upload a file with a relative path and custom metadata.
                string filePath = "path/to/azure-search-overview.txt";
#if !SNIPPET
                filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "azure-search-overview.txt");
#endif
                string fileName = Path.GetFileName(filePath);
                string relativeFileName = $"guides/{fileName}";
                BinaryData fileData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

                FileUploadMetadata uploadMetadata = new FileUploadMetadata
                {
                    FileName = relativeFileName,
                    Metadata =
                    {
                        ["category"] = "documentation",
                        ["language"] = "en"
                    }
                };

#pragma warning disable SCME0004 // Multipart file request types are experimental.
                UploadKnowledgeSourceFileMultipartRequest uploadRequest = new UploadKnowledgeSourceFileMultipartRequest(
                    uploadMetadata,
                    fileData);
                Response<KnowledgeSourceFile> uploadResponse = await indexClient.UploadKnowledgeSourceFileMultipartAsync(
                    knowledgeSourceName,
                    uploadRequest);
#pragma warning restore SCME0004

                KnowledgeSourceFile uploadedFile = uploadResponse.Value;
                Console.WriteLine($"Uploaded file '{uploadedFile.FileName}' (ID: {uploadedFile.FileId}, Size: {uploadedFile.FileSizeBytes} bytes)");
                Console.WriteLine($"  Prefix: {uploadedFile.Prefix}");
                Console.WriteLine($"  Parsing mode selected by the service: {uploadedFile.ParsingMode}");
                Console.WriteLine($"  Extraction mode selected by the service: {uploadedFile.ExtractionMode}");

                // Replace the content and metadata without changing the file ID.
                FileUploadMetadata updatedMetadata = new FileUploadMetadata
                {
                    FileName = relativeFileName,
                    Metadata =
                    {
                        ["category"] = "product-documentation",
                        ["language"] = "en"
                    }
                };
#pragma warning disable SCME0004 // Multipart file request types are experimental.
                BinaryData updatedFileData = BinaryData.FromString(
                    "Azure AI Search indexes content and uses semantic ranking to retrieve relevant information.");
                UpdateKnowledgeSourceFileRequest updateRequest = new UpdateKnowledgeSourceFileRequest(
                    updatedMetadata,
                    updatedFileData);
                KnowledgeSourceFile updatedFile = await indexClient.UpdateKnowledgeSourceFileAsync(
                    knowledgeSourceName,
                    uploadedFile.FileId,
                    updateRequest);
#pragma warning restore SCME0004
                Console.WriteLine($"Updated file metadata category: {updatedFile.Metadata["category"]}");

                // Prefixes are derived from relative paths. The pageable handles
                // continuation tokens internally; callers should not parse them.
                HashSet<string> listedFileIds = new HashSet<string>();
                await foreach (KnowledgeSourceFile file in indexClient.GetAllKnowledgeSourceFilesAsync(
                    knowledgeSourceName,
                    prefix: "guides/",
                    pageSize: 1))
                {
                    Console.WriteLine($"  File: {file.FileName} (ID: {file.FileId})");
                    listedFileIds.Add(file.FileId);
                }
                #endregion Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_UploadFiles

                Assert.AreEqual(uploadedFile.FileId, updatedFile.FileId);
                Assert.AreEqual("product-documentation", updatedFile.Metadata["category"]);
                Assert.AreEqual("guides/", updatedFile.Prefix);
                Assert.IsTrue(listedFileIds.SetEquals(new[] { uploadedFile.FileId }));
                Assert.IsTrue(
                    updatedFile.ExtractionMode == FileKnowledgeSourceExtractionMode.Minimal ||
                    updatedFile.ExtractionMode == FileKnowledgeSourceExtractionMode.Standard);

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_GetAndList
                // Get the file knowledge source back
                KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
                Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

                if (retrievedSource is FileKnowledgeSource retrievedFile)
                {
                    Console.WriteLine($"  Kind: File");
                    Console.WriteLine($"  Description: {retrievedFile.Description}");
                }

                // List all knowledge sources to see the file source alongside others
                await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
                {
                    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_GetAndList

                #region Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_AttachToKB
                // Create a knowledge base that uses the file source
                string knowledgeBaseName = "my-file-kb";
#if !SNIPPET
                knowledgeBaseName = testBaseName;
#endif
                KnowledgeBase knowledgeBase = new KnowledgeBase(
                    knowledgeBaseName,
                    knowledgeSources: new[]
                    {
                        new KnowledgeSourceReference(knowledgeSourceName)
                    })
                {
                    Description = "Knowledge base with file-uploaded documents",
                    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
                    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort()
                };

                // The Search service identity needs access to both configured deployments.
                knowledgeBase.Models.Add(
                    new KnowledgeBaseAzureOpenAIModel(
                        new AzureOpenAIVectorizerParameters
                        {
                            ResourceUri = new Uri(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT")),
                            DeploymentName = "gpt-5.4-mini",
                            ModelName = AzureOpenAIModelName.Gpt54Mini
                        }));

                KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                Console.WriteLine($"Created knowledge base '{createdBase.Name}' with file source");
                #endregion Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_AttachToKB

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Retrieve
                // Retrieve from the knowledge base to verify the file source is wired up
                KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                    endpoint, knowledgeBaseName, credential);
#if !SNIPPET
                retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                    endpoint, testBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

                KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
                {
                    IncludeActivity = true,
                    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
                };
                request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What is Azure AI Search?"));
                request.KnowledgeSourceParams.Add(new FileKnowledgeSourceParams(knowledgeSourceName)
                {
                    IncludeReferences = true
                });

                Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
                KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

                foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
                {
                    foreach (KnowledgeBaseMessageContent content in message.Content)
                    {
                        if (content is KnowledgeBaseMessageTextContent textContent)
                        {
                            Console.WriteLine($"Response: {textContent.Text}");
                        }
                    }
                }

                foreach (KnowledgeBaseReference reference in retrievalResponse.References)
                {
                    Console.WriteLine($"Reference ID: {reference.Id}");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Retrieve

                Assert.That(retrievalResponse.Response, Is.Not.Empty);
                Assert.That(retrievalResponse.References.OfType<KnowledgeBaseFileReference>(), Is.Not.Empty);

                #region Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_DeleteFile
                // Delete the uploaded file after retrieval is complete.
                await indexClient.DeleteKnowledgeSourceFileAsync(knowledgeSourceName, uploadedFile.FileId);
                Console.WriteLine($"Deleted file '{uploadedFile.FileName}'");
                #endregion Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_DeleteFile
            }
            finally
            {
                if (testClient != null)
                {
                    try
                    { await testClient.DeleteKnowledgeBaseAsync(testBaseName, cancellationToken: CancellationToken.None); }
                    catch { }
                    try
                    { await testClient.DeleteKnowledgeSourceAsync(testSourceName, cancellationToken: CancellationToken.None); }
                    catch { }
                }
            }
        }
    }
}
