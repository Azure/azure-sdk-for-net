# Model compose

Model compose allows multiple models to be composed and called with a single model ID. This is useful when you have created different models and want to aggregate a group of them into a single model that you (or a user) could use to analyze a document.
When doing so, you can let the service decide which model more accurately represents the document, instead of manually trying each model against the document and selecting the most appropiate one.

Please note that models can also be composed using a graphical user interface such as the [Form Recognizer Labeling Tool][labeling_tool].

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

## Compose a model
In our case, we will be writing an application that collects the expenses a company is making. There are 4 main areas where we get purchase orders from (office supplies, office equipment, furniture, and cleaning supplies). Because each area has its own document with its own structure, we need to create a model per document type.

```C# Snippet:FormRecognizerSampleBuildVariousModels
// For this sample, you can use the training documents found in the `trainingFiles` folder.
// Upload the documents to your storage container and then generate a container SAS URL.
// For instructions on setting up documents for training in an Azure Storage Blob Container, see
// https://aka.ms/azsdk/formrecognizer/buildtrainingset

Uri officeSuppliesUri = new Uri("<purchaseOrderOfficeSuppliesUri>");
var officeSupplieOptions = new BuildDocumentModelOptions() { Description = "Purchase order - Office supplies" };

BuildDocumentModelOperation suppliesOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: officeSupplieOptions);
DocumentModelDetails officeSuppliesModel = suppliesOperation.Value;

Uri officeEquipmentUri = new Uri("<purchaseOrderOfficeEquipmentUri>");
var equipmentOptions = new BuildDocumentModelOptions() { Description = "Purchase order - Office Equipment" };

BuildDocumentModelOperation equipmentOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
DocumentModelDetails officeEquipmentModel = equipmentOperation.Value;

Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
var furnitureOptions = new BuildDocumentModelOptions() { Description = "Purchase order - Furniture" };

BuildDocumentModelOperation furnitureOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
DocumentModelDetails furnitureModel = furnitureOperation.Value;

Uri cleaningSuppliesUri = new Uri("<purchaseOrderCleaningSuppliesUri>");
var cleaningOptions = new BuildDocumentModelOptions() { Description = "Purchase order - Cleaning Supplies" };

BuildDocumentModelOperation cleaningOperation = await client.BuildDocumentModelAsync(WaitUntil.Completed, officeSuppliesUri, DocumentBuildMode.Template, options: equipmentOptions);
DocumentModelDetails cleaningSuppliesModel = cleaningOperation.Value;
```

When a purchase order happens, the employee in charge uploads the document to our application. The application then needs to analyze the document to extract the total value of the purchase order. Instead of asking the user to look for the specific `modelId` according to the nature of the document, you can compose a model that aggregates the previous models, and use that model in `AnalyzeDocument` and let the service decide which model fits best according to the document provided.

```C# Snippet:FormRecognizerSampleComposeModel
List<string> modelIds = new List<string>()
{
    officeSuppliesModel.ModelId,
    officeEquipmentModel.ModelId,
    furnitureModel.ModelId,
    cleaningSuppliesModel.ModelId
};

ComposeDocumentModelOperation operation = await client.ComposeDocumentModelAsync(WaitUntil.Completed, modelIds, description: "Composed Purchase order");
DocumentModelDetails purchaseOrderModel = operation.Value;

Console.WriteLine($"  Model Id: {purchaseOrderModel.ModelId}");
if (string.IsNullOrEmpty(purchaseOrderModel.Description))
    Console.WriteLine($"  Model description: {purchaseOrderModel.Description}");
Console.WriteLine($"  Created on: {purchaseOrderModel.CreatedOn}");
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[labeling_tool]: https://aka.ms/azsdk/formrecognizer/labelingtool
