# Cancel a document analysis job

This sample demonstrates how to cancel a previously submitted document analysis job. To get started, you'll need to create an Azure AI Language resource endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Documents/README.md) for links and instructions.

Start by importing the namespace for the `DocumentsServiceClient` and related classes:

```C# Snippet:DocumentsServiceClient_Namespaces
using Azure.AI.Language.Documents;
```

Create a client:

```C# Snippet:CreateDocumentsServiceClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();
DocumentsServiceClientOptions options = new DocumentsServiceClientOptions(DocumentsServiceClientOptions.ServiceVersion.V2026_05_15_Preview);
DocumentsServiceClient client = new DocumentsServiceClient(endpoint, credential, options);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:DocumentsService_CancelJob
string sourceLocation = "https://<storage-account>.blob.core.windows.net/input/document.txt?<sas-token>";
string targetLocation = "https://<storage-account>.blob.core.windows.net/output/pii?<sas-token>";

MultiLanguageDocumentCollection documents = new MultiLanguageDocumentCollection();
documents.Documents.Add(
    new MultiLanguageInput(
        "1",
        new AzureBlobDocumentLocation(sourceLocation),
        new AzureContainerFolderDocumentLocation(targetLocation))
    {
        Language = "en",
    });

PiiEntityRecognitionAction piiAction = new PiiEntityRecognitionAction
{
    Parameters = DocumentsServiceModelFactory.PiiActionContent(
        redactionPolicies: new[]
        {
            new EntityMaskRedactionPolicy
            {
                PolicyName = "defaultPolicy",
                IsDefault = true,
            },
        }),
};

AnalyzeDocumentsOperationInput request = new AnalyzeDocumentsOperationInput(
    documents,
    new AnalyzeDocumentsOperationAction[] { piiAction })
{
    DisplayName = "Document Analysis.",
};

Operation submitOperation = client.AnalyzeDocumentsSubmitOperation(
    WaitUntil.Started,
    request);

string operationLocation = submitOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string headerValue)
    ? headerValue
    : throw new InvalidOperationException("Operation-Location header was not found.");

Guid jobId = Guid.Parse(new Uri(operationLocation).AbsolutePath.TrimEnd('/').Split('/').Last());

Operation cancelOperation = client.AnalyzeDocumentsCancelOperation(
    WaitUntil.Started,
    jobId);
```

## Asynchronous

Using the same `request` definition above, you can make an asynchronous request by calling `AnalyzeDocumentsCancelOperationAsync`:

```C# Snippet:DocumentsService_CancelJobAsync
Operation cancelOperation = await client.AnalyzeDocumentsCancelOperationAsync(
    WaitUntil.Started,
    jobId);
```
