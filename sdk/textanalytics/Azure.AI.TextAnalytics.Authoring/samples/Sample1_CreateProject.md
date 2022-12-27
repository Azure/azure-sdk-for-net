# Creating a Text Analytics project.
This sample demonstrates how to create a text analytics project, using a cognitive services for language resource.

## Create a `TextAuthoringClient`
To create a new `TextAuthoringClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAuthoringClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
TextAuthoringClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Creating the project
To create a project, call `CreateProject` on the `TextAuthoringClient`, which returns a `Response` object with the project creation jobId, creation time, status, and more.

```C# Snippet:Create a Project
var projectOptions = new
{
    projectKind = "CustomSingleLabelClassification",
    storageInputContainerName = "<containerName>",
    projectName = "<projectName>",
    multilingual = true,
    description = "Sample Description",
    language = "en",
};

Response response = client.CreateProject("<projectName>", RequestContent.Create(projectOptions));
```
Note that the `projectOptions.projectName` must be the same as the `projectName` passed as a first parameter to `client.CreateProject`.

You can then print the returned response to the screen.
```C# Snippet:Print Creation Response
JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
Console.WriteLine(result.GetProperty("jobId").ToString());
Console.WriteLine(result.GetProperty("createdDateTime").ToString());
Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
Console.WriteLine(result.GetProperty("status").ToString());
```

See the [README][README] of the Text Analytics Authoring client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics.Authoring/README.md