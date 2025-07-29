# Deleting a Trained Model in Azure AI Language

This sample demonstrates how to delete a trained model synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient

To create a `TextAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `TextAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `TextAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Delete a Trained Model Synchronously

To delete a trained model, call DeleteTrainedModel on the TextAnalysisAuthoring client.

```C# Snippet:Sample11_TextAuthoring_DeleteTrainedModel
string projectName = "{projectName}";
string trainedModelLabel = "{modelLabel}";
TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Response response = trainedModelClient.DeleteTrainedModel();

Console.WriteLine($"Trained model deleted. Response status: {response.Status}");
```

To delete a trained model, the DeleteTrainedModel method sends a request with the project name and the model label. The method returns a Response object indicating the deletion status.

## Delete a Trained Model Asynchronously

To delete a trained model, call DeleteTrainedModelAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample11_TextAuthoring_DeleteTrainedModelAsync
string projectName = "{projectName}";
string trainedModelLabel = "{modelLabel}";
TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Response response = await trainedModelClient.DeleteTrainedModelAsync();

Console.WriteLine($"Trained model deleted. Response status: {response.Status}");
```

To delete a trained model, the DeleteTrainedModelAsync method sends a request with the project name and the model label. The method returns a Response object indicating the deletion status.
