# Sample on getting the responses from published Agent in Azure.AI.Projects.OpenAI.

Publishing promotes an agent from a development asset into a managed Azure resource with a dedicated endpoint, independent identity, and governance capabilities. In this example we will demonstrate how to get a response from the published Agent. Please see [this article](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/publish-agent) for more information on Agent publishing.

## Publish Agent

1. Click **New foundry** switch at the top of Microsoft Foundry UI.
2. Click **Build** at the upper right.
3. Click **Create agent** button and name your Agent.
4. Select the created Agent at the central panel and click **Publish** at the upper right corner.

After the Agent is published, you will be provided with two URLs
- `https://<Account name>.services.ai.azure.com/api/projects/<Project Name>/applications/<Agent Name>/protocols/activityprotocol?api-version=2025-11-15-preview`
- `https://<Account name>.services.ai.azure.com/api/projects/<Project Name>/applications/<Agent Name>/protocols/openai/responses?=2025-11-15-preview`

These URLs can be used to call responses API after removing path following `/protocols`, resulting in `https://<Account name>.services.ai.azure.com/api/projects/<Project Name>/applications/<Agent Name>/protocols`.

## Run the sample

1. Read the environment variables, which will be used in the next steps and get the clean endpoint URL.

```C# Snippet:Sample_ReadEndpoint_PublishedAgent
var publishedEndpoint = System.Environment.GetEnvironmentVariable("PUBLISHED_ENDPOINT");
Uri endpoint = new(publishedEndpoint);
```

2. Create a `ProjectResponsesClient`, get the response from Agent and print the output.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_ReadEndpoint_Sync
ProjectResponsesClient responseClient = new(
    projectEndpoint: endpoint,
    tokenProvider: new DefaultAzureCredential()
);
ResponseResult response = responseClient.CreateResponse("What is the size of France in square miles?");
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_ReadEndpoint_Async
ProjectResponsesClient responseClient = new(
    projectEndpoint: endpoint,
    tokenProvider: new DefaultAzureCredential()
);
ResponseResult response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
Console.WriteLine(response.GetOutputText());
```
