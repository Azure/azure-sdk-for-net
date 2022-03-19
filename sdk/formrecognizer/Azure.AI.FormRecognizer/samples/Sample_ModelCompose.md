# Model compose

Model compose allows multiple models to be composed and called with a single model ID. This is useful when you have created different models and want to aggregate a group of them into a single model that you (or a user) could use to analyze a document.
When doing so, you can let the service decide which model more accurately represents the document, instead of manually trying each model against the document and selecting the most appropiate one.

Please note that composed models can also be created using a graphical user interface such as the [Form Recognizer Labeling Tool][labeling_tool].

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

## Create a composed model
In our case, we will be writing an application that collects the expenses a company is making. There are 4 main areas where we get purchase orders from (office supplies, office equipment, furniture, and cleaning supplies). Because each area has its own document with its own structure, we need to create a model per document type.

```C# Snippet:FormRecognizerSampleBuildVariousModels
// For this sample, you can use the training forms found in the `trainingFiles` folder.
// Upload the forms to your storage container and then generate a container SAS URL.
// For instructions on setting up forms for training in an Azure Storage Blob Container, see
// https://aka.ms/azsdk/formrecognizer/buildtrainingset

Uri officeSuppliesUri = new Uri("<purchaseOrderOfficeSuppliesUri>");
var officeSupplieOptions = new BuildModelOptions() { ModelDescription = "Purchase order - Office supplies" };

BuildModelOperation suppliesOperation = await client.StartBuildModelAsync(officeSuppliesUri, DocumentBuildMode.Template, buildModelOptions: officeSupplieOptions);
Response<DocumentModel> suppliesOperationResponse = await suppliesOperation.WaitForCompletionAsync();
DocumentModel officeSuppliesModel = suppliesOperationResponse.Value;

Uri officeEquipmentUri = new Uri("<purchaseOrderOfficeEquipmentUri>");
var equipmentOptions = new BuildModelOptions() { ModelDescription = "Purchase order - Office Equipment" };

BuildModelOperation equipmentOperation = await client.StartBuildModelAsync(officeSuppliesUri, DocumentBuildMode.Template, buildModelOptions: equipmentOptions);
Response<DocumentModel> equipmentOperationResponse = await equipmentOperation.WaitForCompletionAsync();
DocumentModel officeEquipmentModel = equipmentOperationResponse.Value;

Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
var furnitureOptions = new BuildModelOptions() { ModelDescription = "Purchase order - Furniture" };

BuildModelOperation furnitureOperation = await client.StartBuildModelAsync(officeSuppliesUri, DocumentBuildMode.Template, buildModelOptions: equipmentOptions);
Response<DocumentModel> furnitureOperationResponse = await furnitureOperation.WaitForCompletionAsync();
DocumentModel furnitureModel = furnitureOperationResponse.Value;

Uri cleaningSuppliesUri = new Uri("<purchaseOrderCleaningSuppliesUri>");
var cleaningOptions = new BuildModelOptions() { ModelDescription = "Purchase order - Cleaning Supplies" };

BuildModelOperation cleaningOperation = await client.StartBuildModelAsync(officeSuppliesUri, DocumentBuildMode.Template, buildModelOptions: equipmentOptions);
Response<DocumentModel> cleaningOperationResponse = await cleaningOperation.WaitForCompletionAsync();
DocumentModel cleaningSuppliesModel = cleaningOperationResponse.Value;
```

When a purchase order happens, the employee in charge uploads the document to our application. The application then needs to analyze the document to extract the total value of the purchase order. Instead of asking the user to look for the specific `modelId` according to the nature of the document, you can create a composed model that aggregates the previous models, and use that model in `StartAnalyzeDocument` and let the service decide which model fits best according to the document provided.

```C# Snippet:FormRecognizerSampleCreateComposedModel
List<string> modelIds = new List<string>()
{
    officeSuppliesModel.ModelId,
    officeEquipmentModel.ModelId,
    furnitureModel.ModelId,
    cleaningSuppliesModel.ModelId
};

BuildModelOperation operation = await client.StartCreateComposedModelAsync(modelIds, modelDescription: "Composed Purchase order");
Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
DocumentModel purchaseOrderModel = operationResponse.Value;

Console.WriteLine($"  Model Id: {purchaseOrderModel.ModelId}");
if (string.IsNullOrEmpty(purchaseOrderModel.Description))
    Console.WriteLine($"  Model description: {purchaseOrderModel.Description}");
Console.WriteLine($"  Created on: {purchaseOrderModel.CreatedOn}");
```

To see the full example source files, see:
* [Composed Model](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_CreateComposedModelAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[labeling_tool]: https://aka.ms/azsdk/formrecognizer/labelingtool
