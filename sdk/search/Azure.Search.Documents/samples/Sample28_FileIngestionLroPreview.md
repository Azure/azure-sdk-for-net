# File ingestion and replacement as long-running operations

Use the [common preview and native embedding setup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample23_NovemberPreview.md).
The complete `FileIngestionLroUploadReplaceAndRetrieve` flow is in
[`Sample28_FileIngestionLroPreview.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/tests/Samples/Sample28_FileIngestionLroPreview.cs).
Create a unique `sourceName`/`baseName` and a ten-minute
`CancellationTokenSource timeout`.

## Create the file knowledge source

```C# Snippet:Azure_Search_Documents_Sample28_FileIngestion_Create
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
```

## Start ingestion and wait for its result

```C# Snippet:Azure_Search_Documents_Sample28_FileIngestion_Ingest
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
```

`WaitUntil.Started` is not an ingestion-success acknowledgement. Poll the returned
`Operation<KnowledgeSourceFile>` and use its final file identifier. The narrow
experimental warning suppression applies to multipart request models.

## Replace the same file and inspect durable operation records

```C# Snippet:Azure_Search_Documents_Sample28_FileIngestion_Replace
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
```

The full sample verifies the identifier is unchanged, metadata has revision 2,
and both retained operations succeeded. It then creates a minimal KB and requests
reference source data:

```C# Snippet:Azure_Search_Documents_Sample28_FileIngestion_Retrieve
await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName, new[] { new KnowledgeSourceReference(sourceName) })
{
    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort(),
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
});
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
KnowledgeBaseRetrievalRequest request = PreviewIntent("hotel availability retry transient failures");
request.KnowledgeSourceParams.Add(new FileKnowledgeSourceParams(sourceName)
{
    IncludeReferences = true,
    IncludeReferenceSourceData = true
});
KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(request);
```

The executable checks the returned file reference, actual revision-2 text and
exponential-backoff guidance, absence of stale revision-1 text, and activity errors
before removing its KB/source. Metadata alone does not prove replacement content
is searchable.

These feature-local operations demonstrate the public durable-operations
framework. There is no separate customer-facing generic operations framework or
serverless-teardown API to call.
