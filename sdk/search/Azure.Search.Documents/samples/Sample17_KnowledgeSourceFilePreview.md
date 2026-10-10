# File Knowledge Source

This sample demonstrates how to create and use a File knowledge source. File sources support direct document upload and indexing without needing an external data store like Azure Blob Storage. You can configure ingestion parameters including content extraction mode and an embedding model for vectorization, then upload, list, and delete files in the source.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a File Knowledge Source

Create a File knowledge source with ingestion parameters specifying the content extraction mode and an Azure OpenAI embedding model.

```C# Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a File knowledge source for direct file upload and indexing.
// The File source supports uploading documents directly to the search service
// without needing an external data store like Azure Blob Storage.
string knowledgeSourceName = "my-file-source";

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
```

## Upload Files to the Knowledge Source

Upload documents directly to the File knowledge source, list uploaded files, and delete them when no longer needed.

```C# Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_UploadFiles
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
                UpdateKnowledgeSourceFileRequest updateRequest = new UpdateKnowledgeSourceFileRequest(
                    updatedMetadata,
                    fileData);
                KnowledgeSourceFile updatedFile = await indexClient.UpdateKnowledgeSourceFileAsync(
                    uploadedFile.FileId,
                    knowledgeSourceName,
                    updateRequest);
#pragma warning restore SCME0004
                Console.WriteLine($"Updated file metadata category: {updatedFile.Metadata["category"]}");

                // Prefixes are derived from relative paths. The pageable handles
                // continuation tokens internally; callers should not parse them.
                HashSet<string> listedFileIds = new HashSet<string>();
                await foreach (KnowledgeSourceFile file in indexClient.GetKnowledgeSourceFilesAsync(
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

```C# Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_GetAndList
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

```C# Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_AttachToKB
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

// Add an Azure OpenAI model for query planning

KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Created knowledge base '{createdBase.Name}' with file source");
```

## Retrieve from the Knowledge Base

Retrieve content from the knowledge base backed by the File source.

```C# Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_Retrieve
// Retrieve from the knowledge base to verify the file source is wired up
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

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
```

## Delete the File

Delete the uploaded file after retrieval and other file operations are complete. Deleting it also removes indexed content derived from that file.

```C# Snippet:Azure_Search_Tests_Samples_Sample17_FileKS_DeleteFile
// Delete the uploaded file after retrieval is complete.
await indexClient.DeleteKnowledgeSourceFileAsync(uploadedFile.FileId, knowledgeSourceName);
Console.WriteLine($"Deleted file '{uploadedFile.FileName}'");
```
