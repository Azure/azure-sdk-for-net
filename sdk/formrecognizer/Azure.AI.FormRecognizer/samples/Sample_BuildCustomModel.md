# Build a custom model

This sample demonstrates how to build a custom model with your own data. A custom model can output structured data that includes the relationships in the original document.

Please note that models can also be created using a graphical user interface such as the [Document Intelligence Studio][fr_studio].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `DocumentModelAdministrationClient`

To create a new `DocumentModelAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentModelAdministrationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new DocumentModelAdministrationClient(new Uri(endpoint), credential);
```

## Build a custom model

Build custom models to extract text, field values, selection marks, and table data from documents. Custom models are trained with your own data, so they're tailored to your documents.

When building a custom model, you'll need to choose a build mode that's appropriate to the type of documents you have:
- Template build mode: recommended when the custom documents all have the same layout. Fields are expected to be in the same place across documents. Build time tends to be considerably shorter than the neural build mode.
- Neural build mode: recommended when custom documents have different layouts. Fields are expected to be the same but they can be placed in different positions across documents.

A `DocumentModelDetails` instance is returned indicating the document types the model will recognize, and the fields it will extract from each document type.

```C# Snippet:FormRecognizerSampleBuildModel
// For this sample, you can use the training documents found in the `trainingFiles` folder.
// Upload the documents to your storage container and then generate a container SAS URL. Note
// that a container URI without SAS is accepted only when the container is public or has a
// managed identity configured.
//
// For instructions to set up documents for training in an Azure Blob Storage Container, please see:
// https://aka.ms/azsdk/formrecognizer/buildcustommodel

Uri blobContainerUri = new Uri("<blobContainerUri>");
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// We are selecting the Template build mode in this sample. For more information about the available
// build modes and their differences, please see:
// https://aka.ms/azsdk/formrecognizer/buildmode

BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, blobContainerUri, DocumentBuildMode.Template);
DocumentModelDetails model = operation.Value;

Console.WriteLine($"  Model Id: {model.ModelId}");
Console.WriteLine($"  Created on: {model.CreatedOn}");

Console.WriteLine("  Document types the model can recognize:");
foreach (KeyValuePair<string, DocumentTypeDetails> documentType in model.DocumentTypes)
{
    Console.WriteLine($"    Document type: {documentType.Key} which has the following fields:");
    foreach (KeyValuePair<string, DocumentFieldSchema> schema in documentType.Value.FieldSchema)
    {
        Console.WriteLine($"    Field: {schema.Key} with confidence {documentType.Value.FieldConfidence[schema.Key]}");
    }
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[fr_studio]: https://aka.ms/azsdk/formrecognizer/formrecognizerstudio
