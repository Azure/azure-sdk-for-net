# Model compose

Model compose allows multiple models to be composed and called with a single model ID. This is useful when you have created different models and want to aggregate a group of them into a single model that could be used to analyze a document. When doing so, you can let the service decide which model more accurately represents the document, instead of manually trying each model against the document.

To get started you'll need a Cognitive Services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceAdministrationClient`

To create a new `DocumentIntelligenceAdministrationClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Document Intelligence API key credential by creating an `AzureKeyCredential` object that, if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceAdministrationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Compose a model

We will be writing an application that collects the expenses a company is making. There are 4 main areas where we get purchase orders from: office supplies, office equipment, furniture, and cleaning supplies. Because each area has its own document with its own structure, we need to create a model per document type.

```C# Snippet:DocumentIntelligenceSampleBuildVariousModels
// For this sample, you can use the training documents found in the `trainingFiles` folder.
// Upload the documents to your storage container and then generate a container SAS URL.
// For instructions on setting up documents for training in an Azure Storage Blob Container, see
// https://aka.ms/azsdk/formrecognizer/buildtrainingset

string officeSuppliesModelId = "<officeSuppliesModelId>";
Uri officeSuppliesUri = new Uri("<officeSuppliesUri>");
var officeSuppliesContent = new BuildDocumentModelContent(officeSuppliesModelId, DocumentBuildMode.Template)
{
    AzureBlobSource = new AzureBlobContentSource(officeSuppliesUri),
    Description = "Purchase order - Office supplies"
};

Operation<DocumentModelDetails> officeSuppliesOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesContent);
DocumentModelDetails officeSuppliesModel = officeSuppliesOperation.Value;

string officeEquipmentModelId = "<officeEquipmentModelId>";
Uri officeEquipmentUri = new Uri("<officeEquipmentUri>");
var officeEquipmentContent = new BuildDocumentModelContent(officeEquipmentModelId, DocumentBuildMode.Template)
{
    AzureBlobSource = new AzureBlobContentSource(officeEquipmentUri),
    Description = "Purchase order - Office Equipment"
};

Operation<DocumentModelDetails> officeEquipmentOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeEquipmentContent);
DocumentModelDetails officeEquipmentModel = officeEquipmentOperation.Value;

string furnitureModelId = "<furnitureModelId>";
Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
var furnitureContent = new BuildDocumentModelContent(furnitureModelId, DocumentBuildMode.Template)
{
    AzureBlobSource = new AzureBlobContentSource(furnitureUri),
    Description = "Purchase order - Furniture"
};

Operation<DocumentModelDetails> furnitureOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, furnitureContent);
DocumentModelDetails furnitureModel = furnitureOperation.Value;

string cleaningSuppliesModelId = "<cleaningSuppliesModelId>";
Uri cleaningSuppliesUri = new Uri("<cleaningSuppliesUri>");
var cleaningSuppliesContent = new BuildDocumentModelContent(cleaningSuppliesModelId, DocumentBuildMode.Template)
{
    AzureBlobSource = new AzureBlobContentSource(cleaningSuppliesUri),
    Description = "Purchase order - Cleaning Supplies"
};

Operation<DocumentModelDetails> cleaningSuppliesOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, cleaningSuppliesContent);
DocumentModelDetails cleaningSuppliesModel = cleaningSuppliesOperation.Value;
```

When a purchase order happens, the employee in charge uploads the document to our application. The application then needs to analyze the document to extract the total value of the purchase order. Instead of asking the user to look for the specific `modelId` according to the nature of the document, you can compose a model that aggregates the four models and pass it to `AnalyzeDocument` to let the service decide which model fits best according to the document provided.

```C# Snippet:DocumentIntelligenceSampleComposeModel
string purchaseOrderModelId = "<purchaseOrderModelId>";
var componentModelIds = new List<ComponentDocumentModelDetails>()
{
    new ComponentDocumentModelDetails(officeSuppliesModelId),
    new ComponentDocumentModelDetails(officeEquipmentModelId),
    new ComponentDocumentModelDetails(furnitureModelId),
    new ComponentDocumentModelDetails(cleaningSuppliesModelId)
};
var purchaseOrderContent = new ComposeDocumentModelContent(purchaseOrderModelId, componentModelIds)
{
    Description = "Composed Purchase order"
};

Operation<DocumentModelDetails> purchaseOrderOperation = await client.ComposeModelAsync(WaitUntil.Completed, purchaseOrderContent);
DocumentModelDetails purchaseOrderModel = purchaseOrderOperation.Value;

Console.WriteLine($"Model ID: {purchaseOrderModel.ModelId}");
Console.WriteLine($"Model description: {purchaseOrderModel.Description}");
Console.WriteLine($"Created on: {purchaseOrderModel.CreatedDateTime}");
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
