# Deleting a Trained Model Asynchronously in Azure AI Language

This sample demonstrates how to delete a trained model asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

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

To delete a trained model asynchronously, call DeleteTrainedModelAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModelAsync
Response response = await AnalyzeConversationClient.DeleteTrainedModelAsync(
    projectName: projectName,
    trainedModelLabel: trainedModelLabel
);

Console.WriteLine($"Delete Trained Model Async Response Status: {response.Status}");
```

To delete a trained model asynchronously, use the DeleteTrainedModelAsync method on the AnalyzeConversationAuthoring client. A successful response will typically return a 204 (No Content) status, indicating the deletion was completed successfully.
