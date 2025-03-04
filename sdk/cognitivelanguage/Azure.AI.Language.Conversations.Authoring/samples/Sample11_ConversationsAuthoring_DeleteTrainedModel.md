# Deleting a Trained Model in Azure AI Language

This sample demonstrates how to delete a trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Delete a Trained Model

To delete a trained model, call DeleteTrainedModel on the `ConversationAuthoringTrainedModel` client. A successful response will typically return a 204 (No Content) status, indicating the deletion was completed successfully.

```C# Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModel
string projectName = "SampleProject";
string trainedModelLabel = "SampleModel";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Response response = trainedModelClient.DeleteTrainedModel();

Console.WriteLine($"Delete Trained Model Response Status: {response.Status}");
```
