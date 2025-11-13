# Sample for image generation in Azure.AI.Projects.OpenAI.

In this example we will demonstrate how to generate an image based on prompt.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClient_ImageGeneration
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var imageGenerationModelName = System.Environment.GetEnvironmentVariable("IMAGE_GENERATION_DEPLOYMENT_NAME");
AIProjectClientOptions projectOptions = new();
projectOptions.AddPolicy(new HeaderPolicy(imageGenerationModelName), PipelinePosition.PerCall);
AIProjectClient projectClient = new(
    endpoint: new Uri(projectEndpoint),
    tokenProvider: new DefaultAzureCredential(),
    options: projectOptions
);
```

2. Use the client to create the versioned agent object. To generate images, we need to provide agent with the `ImageGenerationTool` when we are creating this tool. The `ImageGenerationTool` parameters include the image generation model, image quality and resolution. Supported image generation models are `gpt-image-1` and `gpt-image-1-mini`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_ImageGeneration_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "Generate images based on user prompts.",
    Tools = {
        ResponseTool.CreateImageGenerationTool(
            model: imageGenerationModelName,
            quality: ImageGenerationToolQuality.Low,
            size:ImageGenerationToolSize.W1024xH1024
        )
    }
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_ImageGeneration_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "Generate images based on user prompts.",
    Tools = {
        ResponseTool.CreateImageGenerationTool(
            model: imageGenerationModelName,
            quality: ImageGenerationToolQuality.Low,
            size:ImageGenerationToolSize.W1024xH1024
        )
    }
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. To use image generation, we will need to provide the custom header to web requests, containing model deployment name, for example `x-ms-oai-image-generation-deployment: gpt-image-1`. To implement it we need to create custom header policy.

```C# Snippet:Sample_CustomHeader_ImageGeneration
internal class HeaderPolicy(string image_deployment) : PipelinePolicy
{
    private const string image_deployment_header = "x-ms-oai-image-generation-deployment";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(image_deployment_header, image_deployment);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        // Add your desired header name and value
        message.Request.Headers.Add(image_deployment_header, image_deployment);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
```

4. Use the policy to create the `OpenAIClient` object and create the `OpenAIResponseClient` by asking the Agent to generate the image.

Synchronous sample:
```C# Snippet:Sample_GetResponse_ImageGeneration_Sync
ProjectOpenAIClientOptions options = new();
ProjectOpenAIClient openAIClient = projectClient.GetProjectOpenAIClient();
ProjectResponsesClient responseClient = openAIClient.GetProjectResponsesClientForAgent(new AgentReference(name: agentVersion.Name));

OpenAIResponse response = responseClient.CreateResponse("Generate parody of Newton with apple.");
```

Asynchronous sample:
```C# Snippet:Sample_GetResponse_ImageGeneration_Async
ProjectOpenAIClientOptions options = new();
ProjectOpenAIClient openAIClient = projectClient.GetProjectOpenAIClient(options: options);
ProjectResponsesClient responseClient = openAIClient.GetProjectResponsesClientForAgent(new AgentReference(name: agentVersion.Name));

OpenAIResponse response = await responseClient.CreateResponseAsync("Generate parody of Newton with apple.");
```

5. Waiting for response.

Synchronous sample:
```C# Snippet:Sample_WaitForRun_ImageGeneration_Sync
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    response = responseClient.GetResponse(responseId: response.Id);
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForRun_ImageGeneration_Async
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed){
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    response = await responseClient.GetResponseAsync(responseId:  response.Id);
}
```

6. Parse the `OpenAIResponse` object and save the generated image.

```C# Snippet:Sample_SaveImage_ImageGeneration
foreach (ResponseItem item in response.OutputItems)
{
    if (item is ImageGenerationCallResponseItem imageItem)
    {
        File.WriteAllBytes("newton.png", imageItem.ImageResultBytes.ToArray());
        Console.WriteLine($"Image downloaded and saved to: {Path.GetFullPath("newton.png")}");
    }
}
```

7. Clean up resources by deleting the Agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_ImageGeneration_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_ImageGeneration_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
