# Handle service errors

This sample demonstrates how to handle an error returned by the Azure AI Language Documents service using Microsoft Entra ID authentication. To get started, you'll need to create an Azure AI Language resource endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Documents/README.md) for links and instructions.

Start by importing the namespace for the `DocumentsServiceClient` and related classes:

```C# Snippet:DocumentsServiceClient_Namespaces
using Azure.AI.Language.Documents;
```

Create a client:

```C# Snippet:DocumentsService_Identity_Namespace
using Azure.Identity;
```

```C# Snippet:CreateDocumentsServiceClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();
DocumentsServiceClientOptions options = new DocumentsServiceClientOptions(DocumentsServiceClientOptions.ServiceVersion.V2026_05_15_Preview);
DocumentsServiceClient client = new DocumentsServiceClient(endpoint, credential, options);
```

If the service returns an error, the SDK throws a `RequestFailedException`:

```C# Snippet:DocumentsServiceClient_BadRequest
try
{
    Response<AnalyzeDocumentsJobState> response = client.GetAnalyzeDocumentsJobState(
        Guid.Parse("00000000-0000-0000-0000-000000000000"));
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Status: {ex.Status}");
    Console.WriteLine($"ErrorCode: {ex.ErrorCode}");
    Console.WriteLine(ex.Message);
}
```
