# Deleting a Trained Model Synchronously in Azure AI Language

This sample demonstrates how to delete a trained model synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Delete a Trained Model Synchronously

To delete a trained model, call DeleteTrainedModel on the TextAnalysisAuthoring client.

```C# Snippet:Sample9_TextAuthoring_DeleteTrainedModel
string projectName = "LoanAgreements";
string trainedModelLabel = "ModelLabel"; // Replace with the actual model label.

Response response = authoringClient.DeleteTrainedModel(
    projectName: projectName,
    trainedModelLabel: trainedModelLabel
);

Console.WriteLine($"Trained model deleted. Response status: {response.Status}");
```

To delete a trained model, the DeleteTrainedModel method sends a request with the project name and the model label. The method returns a Response object indicating the deletion status.
