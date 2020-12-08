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
// https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

string purchaseOrderOfficeSuppliesUrl = "<purchaseOrderOfficeSupplies>";
string purchaseOrderOfficeEquipmentUrl = "<purchaseOrderOfficeEquipment>";
string purchaseOrderFurnitureUrl = "<purchaseOrderFurniture>";
string purchaseOrderCleaningSuppliesUrl = "<purchaseOrderCleaningSupplies>";

Response<CustomFormModel> purchaseOrderOfficeSuppliesModel = await client.StartTrainingAsync(new Uri(purchaseOrderOfficeSuppliesUrl), useTrainingLabels: true, new TrainingOptions() { ModelDisplayName = "Purchase order - Office supplies" }).WaitForCompletionAsync();
Response<CustomFormModel> purchaseOrderOfficeEquipmentModel = await client.StartTrainingAsync(new Uri(purchaseOrderOfficeEquipmentUrl), useTrainingLabels: true, new TrainingOptions() { ModelDisplayName = "Purchase order - Office Equipment" }).WaitForCompletionAsync();
Response<CustomFormModel> purchaseOrderFurnitureModel = await client.StartTrainingAsync(new Uri(purchaseOrderFurnitureUrl), useTrainingLabels: true, new TrainingOptions() { ModelDisplayName = "Purchase order - Furniture" }).WaitForCompletionAsync();
Response<CustomFormModel> purchaseOrderCleaningSuppliesModel = await client.StartTrainingAsync(new Uri(purchaseOrderCleaningSuppliesUrl), useTrainingLabels: true, new TrainingOptions() { ModelDisplayName = "Purchase order - Cleaning Supplies" }).WaitForCompletionAsync();
```

When a purchase order happens, the employee in charge uploads the form to our application. The application then needs to recognize the form to extract the total value of the purchase order. Instead of asking the user to look for the specific `modelId` according to the nature of the form, you can create a composed model that aggregates the previous models, and use that model in `StartRecognizeCustomForms` and let the service decide which model fits best according to the form provided.

```C# Snippet:FormRecognizerSampleCreateComposedModel
List<string> modelIds = new List<string>()
{
    purchaseOrderOfficeSuppliesModel.Value.ModelId,
    purchaseOrderOfficeEquipmentModel.Value.ModelId,
    purchaseOrderFurnitureModel.Value.ModelId,
    purchaseOrderCleaningSuppliesModel.Value.ModelId
};

Response<CustomFormModel> purchaseOrderModelResponse = await client.StartCreateComposedModelAsync(modelIds).WaitForCompletionAsync();
CustomFormModel purchaseOrderModel = purchaseOrderModelResponse.Value;

Console.WriteLine($"Purchase Order Model Info:");
Console.WriteLine($"    Is composed model: {purchaseOrderModel.Properties.IsComposedModel}");
Console.WriteLine($"    Model Id: {purchaseOrderModel.ModelId}");
Console.WriteLine($"    Model Status: {purchaseOrderModel.Status}");
Console.WriteLine($"    Create model started on: {purchaseOrderModel.TrainingStartedOn}");
Console.WriteLine($"    Create model completed on: {purchaseOrderModel.TrainingCompletedOn}");
```

Note that a way to differentiate a composed model and a single model is by using the `IsComposedModel` property under `CustomFormModel.Properties` like shown in the snippet above.

## Recognize a custom form using a composed model.
Use the `modelId` of the composed model that we just created. This way the service will be in charge of matching the input form with the models created.
Now you can get the total value of the purchase order, independent of where it came. For the purposes of this sample, we will only look into the `Total value` of the purchase order if the confidence level of the model used against the form is above `0.9`.

```C# Snippet:FormRecognizerSampleRecognizeCustomFormWithComposedModel
string purchaseOrderFilePath = "<purchaseOrderFilePath>";
FormRecognizerClient formRecognizerClient = client.GetFormRecognizerClient();

RecognizedFormCollection forms;
using (FileStream stream = new FileStream(purchaseOrderFilePath, FileMode.Open))
{
    forms = await formRecognizerClient.StartRecognizeCustomFormsAsync(purchaseOrderModel.ModelId, stream).WaitForCompletionAsync();

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
}
```

## Models that are part in a composed model
For administration purposes, you can always check which models are the ones that are part of a composed model in the `CustomFormModel.Submodels` property of your composed model.

```C# Snippet:FormRecognizerSampleSubmodelsInComposedModel
Dictionary<string, List<TrainingDocumentInfo>> trainingDocsPerModel = purchaseOrderModel.TrainingDocuments.GroupBy(doc => doc.ModelId).ToDictionary(g => g.Key, g => g.ToList());

Console.WriteLine($"The purchase order model is based on {purchaseOrderModel.Submodels.Count} model{(purchaseOrderModel.Submodels.Count > 1 ? "s" : "")}.");
foreach (CustomFormSubmodel model in purchaseOrderModel.Submodels)
{
    Console.WriteLine($"    Model Id: {model.ModelId}");
    Console.WriteLine("    The documents used to trained the model are: ");
    foreach (var doc in trainingDocsPerModel[model.ModelId])
    {
        Console.WriteLine($"        {doc.Name}");
    }
}
```

To see the full example source files, see:

* [Composed Model](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample11_ComposedModel.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[labeling_tool]: https://docs.microsoft.com/azure/cognitive-services/form-recognizer/quickstarts/label-tool
