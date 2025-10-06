# Deleting a Project in Azure AI Language

This sample demonstrates how to delete a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Delete a Project

To delete a project, call DeleteProject on the `ConversationAuthoringProject` client. The method returns an Operation object containing the status of the deletion request, and the operation-location header can be used to track the deletion process.

```C# Snippet:Sample5_ConversationsAuthoring_DeleteProject
string projectName = "{projectName}";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = projectClient.DeleteProject(
    waitUntil: WaitUntil.Completed
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
```

## Delete a Project Async

To delete a project, call DeleteProjectAsync on the `ConversationAuthoringProject` client. The method returns an Operation object containing the status of the deletion request, and the operation-location header can be used to track the deletion process.

```C# Snippet:Sample5_ConversationsAuthoring_DeleteProjectAsync
string projectName = "{projectName}";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = await projectClient.DeleteProjectAsync(
    waitUntil: WaitUntil.Completed
);

// Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
```
