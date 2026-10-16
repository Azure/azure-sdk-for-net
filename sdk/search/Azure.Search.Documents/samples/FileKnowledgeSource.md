# File Knowledge Source

This sample demonstrates the stable File knowledge source workflow in the `2026-10-01` API: create a source, check capacity, upload a file with metadata, update its content, list it by prefix, retrieve it through a knowledge base, and delete it. File sources support direct upload and indexing without an external data store such as Azure Blob Storage.

The caller needs **Search Service Contributor** to manage the source and knowledge base. The Search service's system-assigned managed identity needs **Cognitive Services OpenAI User** on the Azure OpenAI resource for the `text-embedding-3-large` and `gpt-5.4-mini` deployments. Uploads go directly to Search, so this workflow does not require a Storage role.

The SDK's typed multipart request helpers are currently marked experimental (`SCME0004`), and the sample suppresses that warning around those calls.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Namespaces
using Azure.Identity;
using Azure.Core;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a File Knowledge Source

Create a File knowledge source with ingestion parameters specifying the content extraction mode and an Azure OpenAI embedding model.

```C# Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a File knowledge source for direct file upload and indexing.
// The File source supports uploading documents directly to the search service
// without needing an external data store like Azure Blob Storage.
string knowledgeSourceName = "my-file-source";

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
```

## Upload Files to the Knowledge Source

Upload documents directly to the File knowledge source, list uploaded files, and delete them when no longer needed.

```C# Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_UploadFiles
                // Upload a file with a relative path and custom metadata.
                string filePath = "path/to/azure-search-overview.txt";
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
                await foreach (KnowledgeSourceFile file in indexClient.GetPagedKnowledgeSourceFilesAsync(
                    knowledgeSourceName,
                    prefix: "guides/",
                    pageSize: 1))
                {
                    Console.WriteLine($"  File: {file.FileName} (ID: {file.FileId})");
                    listedFileIds.Add(file.FileId);
                }
```

## Get and List File Knowledge Sources

Retrieve a specific File knowledge source and list all knowledge sources on the service.

```C# Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_GetAndList
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
```

## Attach to a Knowledge Base

Create a knowledge base that uses the File knowledge source with extractive data output mode.

```C# Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_AttachToKB
// Create a knowledge base that uses the file source
string knowledgeBaseName = "my-file-kb";
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
```

## Retrieve from the Knowledge Base

Retrieve content from the knowledge base backed by the File source.

```C# Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_Retrieve
// Retrieve from the knowledge base to verify the file source is wired up
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

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
```

## Delete the File

Delete the uploaded file after retrieval and other file operations are complete. Deleting it also removes indexed content derived from that file.

```C# Snippet:Azure_Search_Tests_Samples_FileKnowledgeSource_DeleteFile
// Delete the uploaded file after retrieval is complete.
await indexClient.DeleteKnowledgeSourceFileAsync(knowledgeSourceName, uploadedFile.FileId);
Console.WriteLine($"Deleted file '{uploadedFile.FileName}'");
```
