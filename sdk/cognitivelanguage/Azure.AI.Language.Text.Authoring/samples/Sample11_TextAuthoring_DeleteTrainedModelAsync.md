# Deleting a Trained Model Asynchronously in Azure AI Language

This sample demonstrates how to delete a trained model asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

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
