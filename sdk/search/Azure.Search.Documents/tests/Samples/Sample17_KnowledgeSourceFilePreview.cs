// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public partial class KnowledgeSourceFilePreview : SearchTestBase
    {
        public KnowledgeSourceFilePreview(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateAndUseFileKnowledgeSource()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", TestEnvironment.OpenAIKey);

            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Create
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

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
                string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");

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
                                    ApiKey = openAIKey,
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
                #endregion Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Create

                Assert.AreEqual(testSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is FileKnowledgeSource);

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_UploadFiles
                // Upload files directly to the File knowledge source.
                // Files are uploaded as binary content with a Content-Disposition header
                // specifying the filename.
                string filePath = "path/to/azure-search-overview.txt";
#if !SNIPPET
                filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "azure-search-overview.txt");
#endif
                string fileName = Path.GetFileName(filePath);
                BinaryData fileData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

                Response<KnowledgeSourceFile> uploadResponse = await indexClient.UploadKnowledgeSourceFileAsync(
                    knowledgeSourceName,
                    contentDisposition: $"attachment; filename=\"{fileName}\"",
                    file: fileData);

                KnowledgeSourceFile uploadedFile = uploadResponse.Value;
                Console.WriteLine($"Uploaded file '{uploadedFile.FileName}' (ID: {uploadedFile.FileId}, Size: {uploadedFile.FileSizeBytes} bytes)");

                // List all files in the knowledge source
                await foreach (KnowledgeSourceFile file in indexClient.GetKnowledgeSourceFilesAsync(knowledgeSourceName))
                {
                    Console.WriteLine($"  File: {file.FileName} (ID: {file.FileId})");
                }

                // Delete a file from the knowledge source if needed
                await indexClient.DeleteKnowledgeSourceFileAsync(uploadedFile.FileId, knowledgeSourceName);
                Console.WriteLine($"Deleted file '{uploadedFile.FileName}'");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_UploadFiles

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_GetAndList
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
                #endregion Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_GetAndList

                #region Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_AttachToKB
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

                // Add an Azure OpenAI model for query planning
#if !SNIPPET
                string openAIEndpoint2 = TestEnvironment.OpenAIEndpoint;
                string openAIKey2 = TestEnvironment.OpenAIKey;
                if (!string.IsNullOrEmpty(openAIEndpoint2))
                {
                    knowledgeBase.Models.Add(
                        new KnowledgeBaseAzureOpenAIModel(
                            new AzureOpenAIVectorizerParameters
                            {
                                ResourceUri = new Uri(openAIEndpoint2),
                                ApiKey = openAIKey2,
                                DeploymentName = "gpt-5.4-mini",
                                ModelName = AzureOpenAIModelName.Gpt54Mini
                            }));
                }
#endif

                KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                Console.WriteLine($"Created knowledge base '{createdBase.Name}' with file source");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_AttachToKB

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Retrieve
                // Retrieve from the knowledge base to verify the file source is wired up
                KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                    endpoint, knowledgeBaseName, credential);
#if !SNIPPET
                retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                    endpoint, testBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

                KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
                {
                    IncludeActivity = true
                };
                request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What is Azure AI Search?"));

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
                #endregion Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Retrieve

                Assert.IsNotNull(retrievalResponse);
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
