# Simple chat completions targeting Azure OpenAI

This sample demonstrates how to get a chat completions response from the service using a synchronous call, targetting an Azure OpenAI (AOAI) endpoint.

## Usage

Set these two environment variables before running the sample:

1. AZURE_OPENAI_CHAT_ENDPOINT - Your AOAI endpoint URL, with partial path, in the form `https://<your-unique-resouce-name>.openai.azure.com/openai/deployments/<your-deployment-name>` where `your-unique-resource-name` is your globally unique AOAI resource name, and `your-deployment-name` is your AI Model deployment name. For example: `https://your-unique-host.openai.azure.com/openai/deployments/gpt-4-turbo`
2. AZURE_OPENAI_CHAT_KEY - Your model key. Keep it secret. This is only required for key authentication.

In order to target AOAI, the auth key must currently be provided as a separate header. This can be done by creating a `HttpPipelinePolicy` like below:

```C# Snippet:Azure_AI_Inference_AoaiAuthHeaderPolicy
private class AddAoaiAuthHeaderPolicy : HttpPipelinePolicy
{
    public string AoaiKey { get; }

    public AddAoaiAuthHeaderPolicy(string key)
    {
        AoaiKey = key;
    }

    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        // Add your desired header name and value
        message.Request.Headers.Add("api-key", AoaiKey);

        ProcessNext(message, pipeline);
    }

    public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        // Add your desired header name and value
        message.Request.Headers.Add("api-key", AoaiKey);

        return ProcessNextAsync(message, pipeline);
    }
}
```

The policy can then be added to the `ChatCompletionsClientOptions` object, to configure the client to add the header at runtime.

```C# Snippet:Azure_AI_Inference_HelloWorldAoaiScenarioClientCreate
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_ENDPOINT"));
var key = System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_KEY");

// For AOAI, currently the key is passed via a different header not directly handled by the client, however
// the credential object is still required. So create with a dummy value.
var credential = new AzureKeyCredential("foo");

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

var client = new ChatCompletionsClient(endpoint, credential, clientOptions);
```

Alternatively, you can use EntraId to authenticate. This does not require the header policy, but it does currently require a separate built-in policy, `BearerTokenAuthenticationPolicy`, to apply the correct token scope.

```C# Snippet:Azure_AI_Inference_HelloWorldScenarioWithEntraIdClientCreate
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_CHAT_ENDPOINT"));
var credential = new DefaultAzureCredential(includeInteractiveCredentials: true);

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://cognitiveservices.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

var client = new ChatCompletionsClient(endpoint, credential, clientOptions);
```

After the client is created, you can make completion requests with it as shown

```C# Snippet:Azure_AI_Inference_HelloWorldAoaiScenarioCompleteRequest
var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("How many feet are in a mile?"),
    },
};

Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);
```

An `async` option is also available.

```C# Snippet:Azure_AI_Inference_HelloWorldAoaiScenarioCompleteRequestAsync
var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("How many feet are in a mile?"),
    },
};

Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
System.Console.WriteLine(response.Value.Content);
```
