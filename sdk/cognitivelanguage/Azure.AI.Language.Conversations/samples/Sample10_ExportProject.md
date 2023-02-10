# Export a project

This sample demonstrates how to export a project. To get started, you'll need to create a Cognitive Language service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/README.md) for links and instructions.

Start by importing the namespace for the `ConversationAuthoringClient` and related classes:

```C# Snippet:ConversationAuthoringClient_Namespaces
using Azure.Core;
using Azure.AI.Language.Conversations.Authoring;
```

To export a project, you'll need to first create a `ConversationAuthoringClient` using an endpoint and an API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:ConversationAuthoringClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAuthoringClient client = new ConversationAuthoringClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods. Typically, the content would come from a file but a small sample is shown here for demonstration purposes.

## Synchronous

Exporting a project returns an operation. Once this operation completes, you can get the `resultUrl` out of the response body and pass through the HTTP pipeline exposed by the client to download the project.

```C# Snippet:ConversationAuthoringClient_ExportProject
string projectName = "project-to-export";
Operation<BinaryData> exportOperation = client.ExportProject(WaitUntil.Completed, projectName);

// Get the resultUrl from the response, which contains the exported project.
using JsonDocument doc = JsonDocument.Parse(exportOperation.Value.ToStream());
string resultUrl = doc.RootElement.GetProperty("resultUrl").GetString();

// Use the client pipeline to create and send a request to download the raw URL.
RequestUriBuilder builder = new RequestUriBuilder();
builder.Reset(new Uri(resultUrl));

Request request = client.Pipeline.CreateRequest();
request.Method = RequestMethod.Get;
request.Uri = builder;

// Save the project to a file in the current working directory.
Response response = client.Pipeline.SendRequest(request, cancellationToken: default);

string path = "project.json";
response.ContentStream.CopyTo(File.Create(path));
```

## Asynchronous

```C# Snippet:ConversationAuthoringClient_ExportProjectAsync
string projectName = "project-to-export";
Operation<BinaryData> exportOperation = await client.ExportProjectAsync(WaitUntil.Completed, projectName);

// Get the resultUrl from the response, which contains the exported project.
using JsonDocument doc = JsonDocument.Parse(exportOperation.Value.ToStream());
string resultUrl = doc.RootElement.GetProperty("resultUrl").GetString();

// Use the client pipeline to create and send a request to download the raw URL.
RequestUriBuilder builder = new RequestUriBuilder();
builder.Reset(new Uri(resultUrl));

Request request = client.Pipeline.CreateRequest();
request.Method = RequestMethod.Get;
request.Uri = builder;

// Save the project to a file in the current working directory.
Response response = await client.Pipeline.SendRequestAsync(request, cancellationToken: default);

string path = "project.json";
await response.ContentStream.CopyToAsync(File.Create(path));
```
