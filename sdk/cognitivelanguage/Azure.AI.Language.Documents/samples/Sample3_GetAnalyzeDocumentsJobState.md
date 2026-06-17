# Get a document analysis job state

This sample demonstrates how to retrieve the state of a previously submitted document analysis job. To get started, you'll need to create an Azure AI Language resource endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Documents/README.md) for links and instructions.

Start by importing the namespace for the `DocumentsServiceClient` and related classes:

```C# Snippet:DocumentsServiceClient_Namespaces
```

Create a client:

```C# Snippet:CreateDocumentsServiceClientForSpecificApiVersion
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:DocumentsService_GetJobState
using System.Linq;

AzureBlobDocumentLocation sourceLocation = new AzureBlobDocumentLocation("{sourceSasUrl}");
AzureContainerFolderDocumentLocation targetLocation = new AzureContainerFolderDocumentLocation("{targetFolderSasUrl}");

MultiLanguageDocumentCollection documents = new MultiLanguageDocumentCollection();
documents.Documents.Add(
    new MultiLanguageInput("1", sourceLocation, targetLocation)
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

Operation operation = client.AnalyzeDocumentsSubmitOperation(
    WaitUntil.Started,
    request);

if (!operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string operationLocation))
{
    throw new InvalidOperationException("Operation-Location header was not found.");
}

Guid jobId = Guid.Parse(new Uri(operationLocation).AbsolutePath.TrimEnd('/').Split('/').Last());

Response<AnalyzeDocumentsJobState> response = client.GetAnalyzeDocumentsJobState(jobId);

Console.WriteLine($"Job Id: {response.Value.JobId}");
Console.WriteLine($"Status: {response.Value.Status}");
```

## Asynchronous

Using the same `request` definition above, you can make an asynchronous request by calling `GetAnalyzeDocumentsJobStateAsync`:

```C# Snippet:DocumentsService_GetJobStateAsync
Operation operation = await client.AnalyzeDocumentsSubmitOperationAsync(
    WaitUntil.Started,
    request);

if (!operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string operationLocation))
{
    throw new InvalidOperationException("Operation-Location header was not found.");
}

Guid jobId = Guid.Parse(new Uri(operationLocation).AbsolutePath.TrimEnd('/').Split('/').Last());

Response<AnalyzeDocumentsJobState> response = await client.GetAnalyzeDocumentsJobStateAsync(jobId);

Console.WriteLine($"Job Id: {response.Value.JobId}");
Console.WriteLine($"Status: {response.Value.Status}");
```
