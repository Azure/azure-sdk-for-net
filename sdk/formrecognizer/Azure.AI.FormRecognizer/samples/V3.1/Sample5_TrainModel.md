# Train a model

This sample demonstrates how to train a model with your own data. A trained model can output structured data that includes the relationships in the original form document. After you train the model, you can test and retrain it and eventually use it to reliably extract data from more forms according to your needs.

Please note that models can also be trained using a graphical user interface such as the [Form Recognizer Labeling Tool][labeling_tool].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `FormTrainingClient`

To create a new `FormTrainingClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateFormTrainingClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new FormTrainingClient(new Uri(endpoint), credential);
```

## Train a model with forms

Train custom models to recognize all fields and values found in your custom forms. A `CustomFormModel` is returned indicating the form types the model will recognize, and the fields it will extract from each form type.

```C# Snippet:FormRecognizerSampleTrainModelWithForms
// For this sample, you can use the training forms found in the `trainingFiles` folder.
// Upload the forms to your storage container and then generate a container SAS URL. Note
// that a container URI without SAS is accepted only when the container is public or has a
// managed identity configured.
//
// For instructions on setting up forms for training in an Azure Blob Storage Container, see
// https://learn.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

Uri trainingFileUri = new Uri("<trainingFileUri>");
FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: false, "My Model");
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel model = operationResponse.Value;

Console.WriteLine($"Custom Model Info:");
Console.WriteLine($"  Model Id: {model.ModelId}");
Console.WriteLine($"  Model name: {model.ModelName}");
Console.WriteLine($"  Model Status: {model.Status}");
Console.WriteLine($"  Is composed model: {model.Properties.IsComposedModel}");
Console.WriteLine($"  Training model started on: {model.TrainingStartedOn}");
Console.WriteLine($"  Training model completed on: {model.TrainingCompletedOn}");

foreach (CustomFormSubmodel submodel in model.Submodels)
{
    Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
    foreach (CustomFormModelField field in submodel.Fields.Values)
    {
        Console.Write($"  FieldName: {field.Name}");
        if (field.Label != null)
        {
            Console.Write($", FieldLabel: {field.Label}");
        }
        Console.WriteLine("");
    }
}
```

## Train a model with forms and labels

Train custom models to recognize specific fields and values you specify by labeling your custom forms. A `CustomFormModel` is returned indicating the fields the model will extract, as well as the estimated accuracy for each field.

```C# Snippet:FormRecognizerSampleTrainModelWithFormsAndLabels
// For this sample, you can use the training forms found in the `trainingFiles` folder.
// Upload the forms to your storage container and then generate a container SAS URL. Note
// that a container URI without SAS is accepted only when the container is public or has a
// managed identity configured.
//
// For instructions to set up forms for training in an Azure Blob Storage Container, please see:
// https://learn.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

// For instructions to create a label file for your training forms, please see:
// https://learn.microsoft.com/azure/cognitive-services/form-recognizer/label-tool?tabs=v2-1

Uri trainingFileUri = new Uri("<trainingFileUri>");
string modelName = "My Model with labels";
FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: true, modelName);
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel model = operationResponse.Value;

Console.WriteLine($"Custom Model Info:");
Console.WriteLine($"  Model Id: {model.ModelId}");
Console.WriteLine($"  Model name: {model.ModelName}");
Console.WriteLine($"  Model Status: {model.Status}");
Console.WriteLine($"  Is composed model: {model.Properties.IsComposedModel}");
Console.WriteLine($"  Training model started on: {model.TrainingStartedOn}");
Console.WriteLine($"  Training model completed on: {model.TrainingCompletedOn}");

foreach (CustomFormSubmodel submodel in model.Submodels)
{
    Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
    foreach (CustomFormModelField field in submodel.Fields.Values)
    {
        Console.Write($"  FieldName: {field.Name}");
        if (field.Accuracy != null)
        {
            Console.Write($", Accuracy: {field.Accuracy}");
        }
        Console.WriteLine("");
    }
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[labeling_tool]: https://learn.microsoft.com/azure/cognitive-services/form-recognizer/label-tool?tabs=v2-1
