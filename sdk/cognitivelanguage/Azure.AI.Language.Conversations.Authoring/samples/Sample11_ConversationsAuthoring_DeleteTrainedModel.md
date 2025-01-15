# Deleting a Trained Model in Azure AI Language

This sample demonstrates how to delete a trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AnalyzeConversationClient`

To create an `AnalyzeConversationClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AnalyzeConversationClientOptions` instance.

```C# Snippet:CreateAnalyzeConversationClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AnalyzeConversationClientOptions options = new AnalyzeConversationClientOptions(AnalyzeConversationClientOptions.ServiceVersion.V2024_11_15_Preview);
AnalyzeConversationClient client = new AnalyzeConversationClient(endpoint, credential, options);
AnalyzeConversationAuthoring AnalyzeConversationClient = client.GetAnalyzeConversationAnalyzeConversationClient();
```

## Delete a Trained Model

To delete a trained model, call DeleteTrainedModel on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModel
Response response = AnalyzeConversationClient.DeleteTrainedModel(
    projectName: projectName,
    trainedModelLabel: trainedModelLabel
);

Console.WriteLine($"Delete Trained Model Response Status: {response.Status}");
```

To delete a trained model, use the DeleteTrainedModel method on the AnalyzeConversationAuthoring client. A successful response will typically return a 204 (No Content) status, indicating the deletion was completed successfully.
