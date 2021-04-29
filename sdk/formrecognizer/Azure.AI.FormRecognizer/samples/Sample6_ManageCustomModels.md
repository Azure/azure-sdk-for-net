# Manage custom models

This sample demonstrates how to manage the custom models stored in your account.

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

## Operations

Operations that can be executed are:
- Check the number of models in the FormRecognizer resource account, and the maximum number of models that can be stored there.
- List the models currently stored in the resource account.
- Get a specific model using the model's Id.
- Delete a model from the resource account.

## Manage Custom Models Asynchronously

```C# Snippet:FormRecognizerSampleManageCustomModelsAsync
FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
AccountProperties accountProperties = await client.GetAccountPropertiesAsync();
Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

// List the models currently stored in the account.
AsyncPageable<CustomFormModelInfo> models = client.GetCustomModelsAsync();

await foreach (CustomFormModelInfo modelInfo in models)
{
    Console.WriteLine($"Custom Model Info:");
    Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
    Console.WriteLine($"  Model name: {modelInfo.ModelName}");
    Console.WriteLine($"  Is composed model: {modelInfo.Properties.IsComposedModel}");
    Console.WriteLine($"  Model Status: {modelInfo.Status}");
    Console.WriteLine($"  Training model started on: {modelInfo.TrainingStartedOn}");
    Console.WriteLine($"  Training model completed on: : {modelInfo.TrainingCompletedOn}");
}

// Create a new model to store in the account
Uri trainingFileUri = <trainingFileUri>;
TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: false, "My new model");
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel model = operationResponse.Value;

// Get the model that was just created
CustomFormModel modelCopy = await client.GetCustomModelAsync(model.ModelId);

Console.WriteLine($"Custom Model with Id {modelCopy.ModelId}  and name {modelCopy.ModelName} recognizes the following form types:");

foreach (CustomFormSubmodel submodel in modelCopy.Submodels)
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

// Delete the model from the account.
await client.DeleteModelAsync(model.ModelId);
```

## Manage Custom Models Synchronously

Note that we are still making an asynchronous call to `WaitForCompletionAsync` for training, since this method does not have a synchronous counterpart.

```C# Snippet:FormRecognizerSampleManageCustomModels
FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Check number of models in the FormRecognizer account, and the maximum number of models that can be stored.
AccountProperties accountProperties = client.GetAccountProperties();
Console.WriteLine($"Account has {accountProperties.CustomModelCount} models.");
Console.WriteLine($"It can have at most {accountProperties.CustomModelLimit} models.");

// List the first ten or fewer models currently stored in the account.
Pageable<CustomFormModelInfo> models = client.GetCustomModels();

foreach (CustomFormModelInfo modelInfo in models.Take(10))
{
    Console.WriteLine($"Custom Model Info:");
    Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
    Console.WriteLine($"  Model name: {modelInfo.ModelName}");
    Console.WriteLine($"  Is composed model: {modelInfo.Properties.IsComposedModel}");
    Console.WriteLine($"  Model Status: {modelInfo.Status}");
    Console.WriteLine($"  Training model started on: {modelInfo.TrainingStartedOn}");
    Console.WriteLine($"  Training model completed on: {modelInfo.TrainingCompletedOn}");
}

// Create a new model to store in the account

Uri trainingFileUri = <trainingFileUri>;
TrainingOperation operation = client.StartTraining(trainingFileUri, useTrainingLabels: false, "My new model");
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel model = operationResponse.Value;

// Get the model that was just created
CustomFormModel modelCopy = client.GetCustomModel(model.ModelId);

Console.WriteLine($"Custom Model with Id {modelCopy.ModelId}  and name {modelCopy.ModelName} recognizes the following form types:");

foreach (CustomFormSubmodel submodel in modelCopy.Submodels)
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

// Delete the model from the account.
client.DeleteModel(model.ModelId);
```

To see the full example source files, see:

* [Manage custom models (Asynchronous)](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample7_ManageCustomModelsAsync.cs)
* [Manage custom models (Synchronous)](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample7_ManageCustomModels.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started