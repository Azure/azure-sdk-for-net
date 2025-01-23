# Deleting a Project Synchronously in Azure AI Language

This sample demonstrates how to delete a project synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Delete a Project Synchronously

To delete a project, call DeleteProject on the TextAnalysisAuthoring client.

```C# Snippet:Sample4_TextAuthoring_DeleteProject
string projectName = "ProjectToDelete";

Operation operation = authoringClient.DeleteProject(
    waitUntil: WaitUntil.Completed,
    projectName: projectName
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a project, the DeleteProject method sends a request with the project name. The method returns an Operation object indicating the deletion status.
