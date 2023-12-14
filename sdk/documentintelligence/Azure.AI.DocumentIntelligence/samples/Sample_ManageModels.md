# Manage models

This sample demonstrates how to manage the models stored in your resource.

To get started you'll need a Cognitive Services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceAdministrationClient`

To create a new `DocumentIntelligenceAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Document Intelligence API key credential by creating an `AzureKeyCredential` object that, if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceAdministrationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Model administration operations

Supported operations:
- Get quota details about the resource, such as the number of custom models or the maximum quota of models allowed.
- Get a specific model using its ID.
- List the models currently stored in the resource.
- Delete a custom model from the resource.

## Manage Models

```C# Snippet:DocumentIntelligenceSampleManageModelsAsync
// Check number of custom models in the Document Intelligence resource, and the maximum number
// of custom models that can be stored.

ResourceDetails resourceDetails = await client.GetResourceInfoAsync();

Console.WriteLine($"Resource has {resourceDetails.CustomDocumentModels.Count} custom models.");
Console.WriteLine($"It can have at most {resourceDetails.CustomDocumentModels.Limit} custom models.");

// Get a model by ID.
string modelId = "<modelId>";
DocumentModelDetails model = await client.GetModelAsync(modelId);

Console.WriteLine($"Details about model with ID '{model.ModelId}':");
Console.WriteLine($"  Created on: {model.CreatedDateTime}");
Console.WriteLine($"  Expires on: {model.ExpirationDateTime}");

// List up to 10 models currently stored in the resource.
int count = 0;

await foreach (DocumentModelDetails modelItem in client.GetModelsAsync())
{
    Console.WriteLine($"Model details:");
    Console.WriteLine($"  Model ID: {modelItem.ModelId}");
    Console.WriteLine($"  Description: {modelItem.Description}");
    Console.WriteLine($"  Created on: {modelItem.CreatedDateTime}");
    Console.WriteLine($"  Expires on: {model.ExpirationDateTime}");

    if (++count == 10)
    {
        break;
    }
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
