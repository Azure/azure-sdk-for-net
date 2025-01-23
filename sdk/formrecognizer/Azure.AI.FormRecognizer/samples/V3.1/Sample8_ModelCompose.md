# Model compose

Model compose allows multiple models to be composed and called with a single model ID. This is useful when you have trained different models and want to aggregate a group of them into a single model that you (or a user) could use to recognize a form.
When doing so, you can let the service decide which model more accurately represents the form to recognize, instead of manually trying each trained model against the form and selecting the most accurate one.

This sample demonstrates how to:
- Create a composed model from existing models.
- Differentiate between a composed model and a single model.
- Recognize a custom form using a composed model.
- Explore the models that are part of a composed model.

Please note that composed models can also be created using a graphical user interface such as the [Form Recognizer Labeling Tool][labeling_tool].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `FormTrainingClient`

Model compose management is located in the `FormTrainingClient`. To create a new `FormTrainingClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateFormTrainingClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new FormTrainingClient(new Uri(endpoint), credential);
```

## Create a composed model
In our case, we will be writing an application that collects the expenses a company is making. There are 4 main areas where we get purchase orders from (office supplies, office equipment, furniture, and cleaning supplies). Because each area has its own form with its own structure, we need to train a model per form.

```C# Snippet:FormRecognizerSampleTrainVariousModels
// For this sample, you can use the training forms found in the `trainingFiles` folder.
// Upload the forms to your storage container and then generate a container SAS URL.
// For instructions on setting up forms for training in an Azure Storage Blob Container, see
// https://learn.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

bool useLabels = true;

Uri officeSuppliesUri = new Uri("<purchaseOrderOfficeSuppliesUri>");
string suppliesModelName = "Purchase order - Office supplies";

TrainingOperation suppliesOperation = await client.StartTrainingAsync(officeSuppliesUri, useLabels, suppliesModelName);
Response<CustomFormModel> suppliesOperationResponse = await suppliesOperation.WaitForCompletionAsync();
CustomFormModel officeSuppliesModel = suppliesOperationResponse.Value;

Uri officeEquipmentUri = new Uri("<purchaseOrderOfficeEquipmentUri>");
string equipmentModelName = "Purchase order - Office Equipment";

TrainingOperation equipmentOperation = await client.StartTrainingAsync(officeEquipmentUri, useLabels, equipmentModelName);
Response<CustomFormModel> equipmentOperationResponse = await equipmentOperation.WaitForCompletionAsync();
CustomFormModel officeEquipmentModel = equipmentOperationResponse.Value;

Uri furnitureUri = new Uri("<purchaseOrderFurnitureUri>");
string furnitureModelName = "Purchase order - Furniture";

TrainingOperation furnitureOperation = await client.StartTrainingAsync(furnitureUri, useLabels, furnitureModelName);
Response<CustomFormModel> furnitureOperationResponse = await furnitureOperation.WaitForCompletionAsync();
CustomFormModel furnitureModel = furnitureOperationResponse.Value;

Uri cleaningSuppliesUri = new Uri("<purchaseOrderCleaningSuppliesUri>");
string cleaningModelName = "Purchase order - Cleaning Supplies";

TrainingOperation cleaningOperation = await client.StartTrainingAsync(cleaningSuppliesUri, useLabels, cleaningModelName);
Response<CustomFormModel> cleaningOperationResponse = await cleaningOperation.WaitForCompletionAsync();
CustomFormModel cleaningSuppliesModel = cleaningOperationResponse.Value;
```

When a purchase order happens, the employee in charge uploads the form to our application. The application then needs to recognize the form to extract the total value of the purchase order. Instead of asking the user to look for the specific `modelId` according to the nature of the form, you can create a composed model that aggregates the previous models, and use that model in `StartRecognizeCustomForms` and let the service decide which model fits best according to the form provided.

```C# Snippet:FormRecognizerSampleCreateComposedModelV3
List<string> modelIds = new List<string>()
{
    officeSuppliesModel.ModelId,
    officeEquipmentModel.ModelId,
    furnitureModel.ModelId,
    cleaningSuppliesModel.ModelId
};

string purchaseModelName = "Composed Purchase order";
CreateComposedModelOperation operation = await client.StartCreateComposedModelAsync(modelIds, purchaseModelName);
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel purchaseOrderModel = operationResponse.Value;

Console.WriteLine($"Purchase Order Model Info:");
Console.WriteLine($"  Is composed model: {purchaseOrderModel.Properties.IsComposedModel}");
Console.WriteLine($"  Model Id: {purchaseOrderModel.ModelId}");
Console.WriteLine($"  Model name: {purchaseOrderModel.ModelName}");
Console.WriteLine($"  Model Status: {purchaseOrderModel.Status}");
Console.WriteLine($"  Create model started on: {purchaseOrderModel.TrainingStartedOn}");
Console.WriteLine($"  Create model completed on: {purchaseOrderModel.TrainingCompletedOn}");
```

Note that a way to differentiate a composed model and a single model is by using the `IsComposedModel` property under `CustomFormModel.Properties` like shown in the snippet above.

## Recognize a custom form using a composed model.
Use the `modelId` of the composed model that we just created. This way the service will be in charge of matching the input form with the models created.
Now you can get the total value of the purchase order, independent of where it came. For the purposes of this sample, we will only look into the `Total value` of the purchase order if the confidence level of the model used against the form is above `0.9`.

```C# Snippet:FormRecognizerSampleRecognizeCustomFormWithComposedModel
string purchaseOrderFilePath = "<purchaseOrderFilePath>";
FormRecognizerClient recognizeClient = client.GetFormRecognizerClient();
using var stream = new FileStream(purchaseOrderFilePath, FileMode.Open);

RecognizeCustomFormsOperation recognizeOperation = await recognizeClient.StartRecognizeCustomFormsAsync(purchaseOrderModel.ModelId, stream);
Response<RecognizedFormCollection> recognizeOperationResponse = await recognizeOperation.WaitForCompletionAsync();
RecognizedFormCollection forms = recognizeOperationResponse.Value;

// Find labeled field.
foreach (RecognizedForm form in forms)
{
    // Setting an arbitrary confidence level
    if (form.FormTypeConfidence.Value > 0.9)
    {
        if (form.Fields.TryGetValue("Total", out FormField field))
        {
            Console.WriteLine($"Total value in the form `{form.FormType}` is `{field.ValueData.Text}`");
        }
    }
    else
    {
        Console.WriteLine("Unable to recognize form.");
    }
}
```

## Models that are part in a composed model
For administration purposes, you can always check which models are the ones that are part of a composed model in the `CustomFormModel.Submodels` property of your composed model.

```C# Snippet:FormRecognizerSampleSubmodelsInComposedModel
Dictionary<string, List<TrainingDocumentInfo>> trainingDocsPerModel;
trainingDocsPerModel = purchaseOrderModel.TrainingDocuments.GroupBy(doc => doc.ModelId).ToDictionary(g => g.Key, g => g.ToList());

Console.WriteLine($"The purchase order model is based on {purchaseOrderModel.Submodels.Count} models");

foreach (CustomFormSubmodel model in purchaseOrderModel.Submodels)
{
    Console.WriteLine($"  Model Id: {model.ModelId}");
    Console.WriteLine("  The documents used to trained the model are: ");
    foreach (var doc in trainingDocsPerModel[model.ModelId])
    {
        Console.WriteLine($"    {doc.Name}");
    }
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[labeling_tool]: https://learn.microsoft.com/azure/cognitive-services/form-recognizer/label-tool?tabs=v2-1
