# Submit a document analysis job

This sample demonstrates how to submit a document analysis job for documents stored in Azure Blob Storage. To get started, you'll need to create an Azure AI Language resource endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Documents/README.md) for links and instructions.

Start by importing the namespace for the `DocumentsServiceClient` and related classes:

```C# Snippet:DocumentsServiceClient_Namespaces
```

To submit a job, first create a `DocumentsServiceClient`:

```C# Snippet:CreateDocumentsServiceClientForSpecificApiVersion
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

```C# Snippet:DocumentsService_SubmitJob 
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

Console.WriteLine($"Operation Id: {operation.Id}");
```

## Asynchronous

Using the same `request` definition above, you can make an asynchronous request by calling `AnalyzeDocumentsSubmitOperationAsync`:

```C# Snippet:DocumentsService_SubmitJobAsync
Operation operation = await client.AnalyzeDocumentsSubmitOperationAsync(
    WaitUntil.Started,
    request);

Console.WriteLine($"Operation Id: {operation.Id}");
```
