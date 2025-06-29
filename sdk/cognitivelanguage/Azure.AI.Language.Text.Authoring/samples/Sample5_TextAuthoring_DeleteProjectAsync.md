# Deleting a Project Asynchronously in Azure AI Language

This sample demonstrates how to delete a project asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Delete a Project Asynchronously

To delete a project, call DeleteProjectAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample5_TextAuthoring_DeleteProjectAsync
string projectName = "ProjectToDelete";
TextAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = await projectClient.DeleteProjectAsync(
    waitUntil: WaitUntil.Completed
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a project, the DeleteProjectAsync method sends a request with the project name. The method returns an Operation object indicating the deletion status.
