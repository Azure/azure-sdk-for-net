# Sample on getting the responses from published Agent in Azure.AI.Projects.OpenAI.

Published Agents are available outside the Microsoft Foundry and can be used by external applications. In this example we will demonstrate how to get a response from the published Agent.

## Publish Agent

1. Click **New foundry** switch at the top of Microsoft Foundry UI.
2. Click **Build** at the upper right.
3. Click **Create agent** button and name your Agent.
4. Select the created Agent at the central panel and click **Publish** at the upper right corner.

After the Agent is published, you will be provided with two URLs
- `https://<Fondry Name>.services.ai.azure.com/api/projects/<Project Name>/applications/<Agent Name>/protocols/activityprotocol?api-version=2025-11-15-preview`
- `https://<Fondry Name>.services.ai.azure.com/api/projects/<Project Name>/applications/<Agent Name>/protocols/openai/responses?=2025-11-15-preview`

The second URL can be usedto call responses API, we will use it to run sample.

## Run the sample

1. The URL, returned during Agent publishing contains `/openai/responses` path and query parameter, setting `api-version`. These parts need to be removed by `CleanEndpoint` method.

```C# Snippet:Sample_CleanUri_PublishedAgent
private static Uri CleanEndpoint(string endpoint)
{
    Uri uriEndpoint = new(endpoint);
    // Remove the Query part.
    if (!string.IsNullOrEmpty(uriEndpoint.Query))
    {
        uriEndpoint = new(uriEndpoint.AbsolutePath);
    }
    // Remove /openai/responses path as it will be added back by framework.
    string responsesSuffix = "/openai/responses";
    if (uriEndpoint.LocalPath.EndsWith(responsesSuffix))
    {
        return new(uriEndpoint.AbsolutePath.Substring(0, uriEndpoint.AbsolutePath.Length - responsesSuffix.Length));
    }
    return uriEndpoint;
}
```

2. Read the environment variables, which will be used in the next steps and get the clean endpoint URL.

```C# Snippet:Sample_ReadEndpoint_PublishedAgent
var publishedEndpoint = System.Environment.GetEnvironmentVariable("PUBLISHED_ENDPOINT");
Uri endpoint = CleanEndpoint(publishedEndpoint);
```

3. Create a `ProjectResponsesClient`, get the response from Agent and print the output.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_ReadEndpoint_Sync
ProjectResponsesClient responseClient = new(
    projectEndpoint: endpoint,
    tokenProvider: new DefaultAzureCredential()
);
OpenAIResponse response = responseClient.CreateResponse("What is the size of France in square miles?");
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_ReadEndpoint_Async
ProjectResponsesClient responseClient = new(
    projectEndpoint: endpoint,
    tokenProvider: new DefaultAzureCredential()
);
OpenAIResponse response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
Console.WriteLine(response.GetOutputText());
```
