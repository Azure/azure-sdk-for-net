# Sample using `Chat Completion` in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `GetChatCompletionsClient()` method.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.

## Synchronous Sample

```C# Snippet:AI_Projects_ChatClientSync
var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

var credential = new DefaultAzureCredential();
BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

ChatCompletionsClient chatClient = new ChatCompletionsClient(new Uri(inferenceEndpoint), credential, clientOptions);

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
    Model = modelDeploymentName
};
Response<ChatCompletions> response = chatClient.Complete(requestOptions);
Console.WriteLine(response.Value.Content);
```
## Asynchronous Sample

```C# Snippet:AI_Projects_ChatClientAsync
var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT"));
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

var credential = new DefaultAzureCredential();
BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

ChatCompletionsClient chatClient = new ChatCompletionsClient(new Uri(inferenceEndpoint), credential, clientOptions);

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
    Model = modelDeploymentName
};
Response<ChatCompletions> response = await chatClient.CompleteAsync(requestOptions);
Console.WriteLine(response.Value.Content);
```
