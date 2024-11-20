# Deleting a Trained Model Asynchronously in Azure AI Language

This sample demonstrates how to delete a trained model asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```c# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your-api-key");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();
```
## Delete a Trained Model

To delete a trained model asynchronously, call DeleteTrainedModelAsync on the ConversationalAnalysisAuthoring client.

```c#
string projectName = "SampleProject";
string trainedModelLabel = "SampleModel";

Response response = await authoringClient.DeleteTrainedModelAsync(
    projectName: projectName,
    trainedModelLabel: trainedModelLabel
);

Console.WriteLine($"Delete Trained Model Async Response Status: {response.Status}");
```

To delete a trained model asynchronously, use the DeleteTrainedModelAsync method on the ConversationalAnalysisAuthoring client. A successful response will typically return a 204 (No Content) status, indicating the deletion was completed successfully.
