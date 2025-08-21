# Deleting a Trained Model in Azure AI Language

This sample demonstrates how to delete a trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Delete a Trained Model

To delete a trained model, call DeleteTrainedModel on the `ConversationAuthoringTrainedModel` client. A successful response will typically return a 204 (No Content) status, indicating the deletion was completed successfully.

```C# Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModel
string projectName = "{projectName}";
string trainedModelLabel = "{trainedModelLabel}";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Response response = trainedModelClient.DeleteTrainedModel();

Console.WriteLine($"Delete Trained Model Response Status: {response.Status}");
```

## Delete a Trained Model Async

To delete a trained model asynchronously, call DeleteTrainedModelAsync on the `ConversationAuthoringTrainedModel` client. A successful response will typically return a 204 (No Content) status, indicating the deletion was completed successfully.

```C# Snippet:Sample11_ConversationsAuthoring_DeleteTrainedModelAsync
string projectName = "{projectName}";
string trainedModelLabel = "{trainedModelLabel}";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Response response = await trainedModelClient.DeleteTrainedModelAsync();

Console.WriteLine($"Delete Trained Model Async Response Status: {response.Status}");
```
