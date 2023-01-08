# Exporting a Text Analytics project.
This sample demonstrates how to export a text analytics project, using a cognitive services for language resource.

## Create a `TextAuthoringClient`
To create a new `TextAuthoringClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAuthoringClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
TextAuthoringClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Exporting the project
To export a project, call `ExportProject` on the `TextAuthoringClient`, which returns a `Response` object with the project training jobId, creation time, status, and more.

```C# Snippet:Export a Project
var operation = client.ExportProject(WaitUntil.Completed, "<projectName>", "Utf16CodeUnit");
BinaryData response = operation.WaitForCompletion();
```

You can then check whether the operation was successful by checking the `response.status`.
```C# Snippet:Print Export Response
JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
if (result.GetProperty("status").ToString().Equals("succeeded"))
    Console.WriteLine("Project exporting succeeded!");
else
    Console.WriteLine("Project exporting failed, check \"result\" error message for more information");
```

If the export was successful, you can get its url using
```C# Snippet:Export Url
string url = result.GetProperty("resultUrl").ToString();
```

See the [README][README] of the Text Analytics Authoring client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics.Authoring/README.md