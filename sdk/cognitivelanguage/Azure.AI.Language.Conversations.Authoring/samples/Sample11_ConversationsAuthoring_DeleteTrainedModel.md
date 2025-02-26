# Deleting a Trained Model in Azure AI Language

This sample demonstrates how to delete a trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
string projectName = "MyNewProject";
ConversationAuthoringProjects projectAuthoringClient = client.GetProjects(projectName);
```

## Delete a Trained Model

To delete a trained model, call DeleteTrainedModel on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModel
Response response = modelAuthoringClient.DeleteTrainedModel(
    trainedModelLabel: trainedModelLabel
);

Console.WriteLine($"Delete Trained Model Response Status: {response.Status}");
```

To delete a trained model, use the DeleteTrainedModel method on the AnalyzeConversationAuthoring client. A successful response will typically return a 204 (No Content) status, indicating the deletion was completed successfully.
