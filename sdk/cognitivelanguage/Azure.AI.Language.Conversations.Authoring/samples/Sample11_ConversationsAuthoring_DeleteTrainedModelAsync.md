# Deleting a Trained Model Asynchronously in Azure AI Language

This sample demonstrates how to delete a trained model asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```
## Delete a Trained Model

To delete a trained model asynchronously, call DeleteTrainedModelAsync on the `ConversationAuthoringTrainedModel` client. A successful response will typically return a 204 (No Content) status, indicating the deletion was completed successfully.

```C# Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModelAsync
string projectName = "SampleProject";
string trainedModelLabel = "SampleModel";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Response response = await trainedModelClient.DeleteTrainedModelAsync();

Console.WriteLine($"Delete Trained Model Async Response Status: {response.Status}");
```
