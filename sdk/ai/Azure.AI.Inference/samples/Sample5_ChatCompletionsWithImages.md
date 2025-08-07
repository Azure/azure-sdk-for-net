# Chat Completions with an Image Input

This sample demonstrates how to get a chat completions response from the service using a synchronous call. It shows different ways to include an image in the input chat messages.

This sample will only work on AI models that support image input.

## Usage

Set these two environment variables before running the sample:

1. AZURE_AI_CHAT_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_AI_CHAT_KEY - Your model key. Keep it secret.

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithImageUrlScenario
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

ChatMessageImageContentItem imageContentItem =
    new ChatMessageImageContentItem(
        new Uri("https://example.com/image.jpg"),
        ChatMessageImageDetailLevel.Low
    );

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
        new ChatRequestUserMessage(
            new ChatMessageTextContentItem("describe this image"),
            imageContentItem),
    },
};

Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);
```

An `async` option is also available.

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithImageUrlScenarioAsync
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

ChatMessageImageContentItem imageContentItem =
    new ChatMessageImageContentItem(
        new Uri("https://example.com/image.jpg"),
        ChatMessageImageDetailLevel.Low
    );

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
        new ChatRequestUserMessage(
            new ChatMessageTextContentItem("describe this image"),
            imageContentItem),
    },
};

Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
System.Console.WriteLine(response.Value.Content);
```

Alternatively, you can provide a Stream object:

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithImageStreamScenario
Stream imageStream = File.OpenRead("sample_image_path");

ChatMessageImageContentItem imageContentItem =
    new ChatMessageImageContentItem(
        imageStream,
        "image/jpg",
        ChatMessageImageDetailLevel.Low
    );

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
        new ChatRequestUserMessage(
            new ChatMessageTextContentItem("describe this image"),
            imageContentItem),
    },
};

Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);
```

Or a direct pointer to a file on disk:

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithImagePathScenario
ChatMessageImageContentItem imageContentItem =
    new ChatMessageImageContentItem(
        "sample_image_path",
        "image/jpg",
        ChatMessageImageDetailLevel.Low
    );
```
