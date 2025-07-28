# Deleting a Project in Azure AI Language

This sample demonstrates how to delete a project synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient

To create a `TextAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `TextAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `TextAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Delete a Project Synchronously

To delete a project, call DeleteProject on the TextAnalysisAuthoring client.

```C# Snippet:Sample5_TextAuthoring_DeleteProject
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = projectClient.DeleteProject(
    waitUntil: WaitUntil.Completed
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a project, the DeleteProject method sends a request with the project name. The method returns an Operation object indicating the deletion status.

## Delete a Project Asynchronously

To delete a project, call DeleteProjectAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample5_TextAuthoring_DeleteProjectAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = await projectClient.DeleteProjectAsync(
    waitUntil: WaitUntil.Completed
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a project, the DeleteProjectAsync method sends a request with the project name. The method returns an Operation object indicating the deletion status.
