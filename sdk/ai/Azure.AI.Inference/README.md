# Azure Inference client library for .NET

The client library (in preview) does inference, including chat completions, for AI models deployed by [Azure AI Foundry](https://ai.azure.com) and [Azure Machine Learning Studio](https://ml.azure.com/). It supports Serverless API endpoints and Managed Compute endpoints (formerly known as Managed Online Endpoints). The client library makes services calls using REST API version `2024-05-01-preview`, as documented in [Azure AI Model Inference API](https://learn.microsoft.com/azure/ai-studio/reference/reference-model-inference-api). For more information see [Overview: Deploy AI models in Azure AI Foundry portal](https://learn.microsoft.com/azure/ai-studio/concepts/deployments-overview).

Use the model inference client library to:

* Authenticate against the service
* Get information about the model
* Do chat completions
<!-- * Get text embeddings -->
<!-- * Get image embeddings -->

With some minor adjustments, this client library can also be configured to do inference for Azure OpenAI endpoints. See samples with `azure_openai` in their name, in the [samples folder](https://aka.ms/azsdk/azure-ai-inference/csharp/samples).

[Product documentation](https://learn.microsoft.com/azure/ai-studio/reference/reference-model-inference-api)
| [Samples](https://aka.ms/azsdk/azure-ai-inference/csharp/samples)
| [API reference documentation](https://aka.ms/azsdk/azure-ai-inference/csharp/reference)
| [Package (NuGet)](https://aka.ms/azsdk/azure-ai-inference/csharp/package)
| [SDK source code](https://aka.ms/azsdk/azure-ai-inference/csharp/source)

## Getting started

### Prerequisites

* An [Azure subscription](https://azure.microsoft.com/free).
* An [AI Model from the catalog](https://ai.azure.com/explore/models) deployed through Azure AI Foundry.
* To construct the client library, you will need to pass in the endpoint URL. The endpoint URL has the form `https://your-host-name.your-azure-region.inference.ai.azure.com`, where `your-host-name` is your unique model deployment host name and `your-azure-region` is the Azure region where the model is deployed (e.g. `eastus2`).
* Depending on your model deployment and authentication preference, you either need a key to authenticate against the service, or Entra ID credentials.

### Install the package

Install the client library for .NET with [NuGet](https://aka.ms/azsdk/azure-ai-inference/csharp/package):

```dotnetcli
dotnet add package Azure.AI.Inference --prerelease
```

### Authenticate the client

The package makes use of common Azure credential providers. To use credential providers provided with the Azure SDK, please install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

## Key concepts

### Create and authenticate a client directly, using key

The package includes `ChatCompletionsClient` <!-- and `EmbeddingsClient`and `ImageGenerationClients`-->. It is created by providing your endpoint and credential information to the object:

```C# Snippet:Azure_AI_Inference_InitializeChatCompletionsClient
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
```

<!--
### Create and authenticate a client directly, using Entra ID

_Note: At the time of this package release, not all deployments support Entra ID authentication. For those who do, follow the instructions below._

To use an Entra ID token credential, first install the [azure-identity](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/identity/azure-identity) package:

```python
pip install azure.identity
```

You will need to provide the desired credential type obtained from that package. A common selection is [DefaultAzureCredential](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/identity/azure-identity#defaultazurecredential) and it can be used as follows:

```python
from azure.ai.inference import ChatCompletionsClient
from azure.identity import DefaultAzureCredential

client = ChatCompletionsClient(
    endpoint=endpoint,
    credential=DefaultAzureCredential(exclude_interactive_browser_credential=False)
)
```

During application development, you would typically set up the environment for authentication using Entra ID by first [Installing the Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli), running `az login` in your console window, then entering your credentials in the browser window that was opened. The call to `DefaultAzureCredential()` will then succeed. Setting `exclude_interactive_browser_credential=False` in that call will enable launching a browser window if the user isn't already logged in.
-->

### Get AI model information

All clients provide a `get_model_info` method to retrive AI model information. This makes a REST call to the `/info` route on the provided endpoint, as documented in [the REST API reference](https://learn.microsoft.com/azure/ai-studio/reference/reference-model-inference-info).

```C# Snippet:Azure_AI_Inference_GetModelInfo
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
Response<ModelInfo> modelInfo = client.GetModelInfo();

Console.WriteLine($"Model name: {modelInfo.Value.ModelName}");
Console.WriteLine($"Model type: {modelInfo.Value.ModelType}");
Console.WriteLine($"Model provider name: {modelInfo.Value.ModelProviderName}");
```

AI model information is cached in the client, and futher calls to `get_model_info` will access the cached value and wil not result in a REST API call.

### Chat Completions

The `ChatCompletionsClient` has a method named `complete`. The method makes a REST API call to the `/chat/completions` route on the provided endpoint, as documented in [the REST API reference](https://learn.microsoft.com/azure/ai-studio/reference/reference-model-inference-chat-completions).

See simple chat completion examples below. More can be found in the [samples](https://aka.ms/azsdk/azure-ai-inference/csharp/samples) folder.

### Text Embeddings

The `EmbeddingsClient` has a method named `embed`. The method makes a REST API call to the `/embeddings` route on the provided endpoint, as documented in [the REST API reference](https://learn.microsoft.com/azure/ai-studio/reference/reference-model-inference-embeddings).

See simple text embedding example below. More can be found in the [samples](https://github.com/Azure/azure-sdk-for-python/tree/main/sdk/ai/azure-ai-inference/samples) folder.

<!--
### Image Embeddings

TODO: Add overview and link to explain image embeddings.

Embeddings operations target the URL route `images/embeddings` on the provided endpoint.
-->

### Sending proprietary model parameters

The REST API defines common model parameters for chat completions<!--, text embeddings, etc-->. If the model you are targeting has additional parameters you would like to set, the client library allows you easily do so. See [Chat completions with additional model-specific parameters](#chat-completions-with-additional-model-specific-parameters).

### Inference using Azure OpenAI endpoints

The request and response payloads of the [Azure AI Model Inference API](https://learn.microsoft.com/azure/ai-studio/reference/reference-model-inference-api) is mostly compatible with OpenAI REST APIs for chat completions. Therefore, with some minor adjustments, this client library can be configured to do inference using Azure OpenAI endpoints. See samples with `azure_openai` in their name, in the [samples folder](https://aka.ms/azsdk/azure-ai-inference/csharp/samples), and the comments there.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

In the following sections you will find simple examples of:

* [Chat completions](#chat-completions-example)
* [Streaming chat completions](#streaming-chat-completions-example)
* [Chat completions with additional model-specific parameters](#chat-completions-with-additional-model-specific-parameters)
* [Text Embeddings](#text-embeddings-example)
<!-- * [Image Embeddings](#image-embeddings-example) -->

The examples create a client as mentioned in [Create and authenticate a client directly, using key](#create-and-authenticate-a-client-directly-using-key). Only mandatory input settings are shown for simplicity.

See the [Samples](https://aka.ms/azsdk/azure-ai-inference/csharp/samples) folder for full working samples for synchronous and asynchronous handling.

### Chat completions example

This example demonstrates how to generate a single chat completions, with key authentication.

```C# Snippet:Azure_AI_Inference_HelloWorldScenario
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

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

The following types or messages are supported: `SystemMessage`,`UserMessage`, `AssistantMessage`, `ToolMessage`. See also samples:

* [Sample5_ChatCompletionsWithImages.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Inference/samples/Sample5_ChatCompletionsWithImages.md) for usage of `UserMessage` that includes sending an image URL or image data from a local file.
* [Sample7_ChatCompletionsWithTools.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Inference/samples/Sample7_ChatCompletionsWithTools.md) for usage of `ToolMessage`.

Alternatively, you can read a `BinaryData` object based on a JSON string instead of using the strongly typed classes like `ChatRequestSystemMessage` and `ChatRequestUserMessage`:

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithJsonInput
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("How many feet are in a mile?"),
    },
};

string jsonMessages = "{\"messages\": [{\"role\": \"system\", \"content\": \"You are a helpful assistant.\"}, {\"role\": \"user\", \"content\": \"How many feet are in a mile?\"}]}";
BinaryData messages = BinaryData.FromString(jsonMessages);
requestOptions = ModelReaderWriter.Read<ChatCompletionsOptions>(messages);

Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);
```

To generate completions for additional messages, simply call `client.Complete` multiple times using the same `client`.

### Streaming chat completions example

This example demonstrates how to generate a single chat completions with streaming response, with key authentication.

```C# Snippet:Azure_AI_Inference_ReadmeStreamingChatCompletions
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("How many feet are in a mile?"),
    },
};

StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(requestOptions);

StringBuilder contentBuilder = new();
await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
{
    if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
    {
        contentBuilder.Append(chatUpdate.ContentUpdate);
    }
}

System.Console.WriteLine(contentBuilder.ToString());
```

In the above `foreach` loop, the updates are progressively added to a string builder as they are streamed in, and then printed out once complete. The updates could be printed as they come in as well.

To generate completions for additional messages, simply call `client.complete` multiple times using the same `client`.

### Chat completions with additional model-specific parameters

In this example, extra JSON elements are inserted at the root of the request body by setting `AdditonalProperties` when calling the `Complete` method. These are intended for AI models that require extra parameters beyond what is defined in the REST API.

Note that by default, the service will reject any request payload that includes unknown parameters (ones that are not defined in the REST API [Request Body table](https://learn.microsoft.com/azure/ai-studio/reference/reference-model-inference-chat-completions#request-body)). In order to change the default service behaviour, when the `Complete` method includes `AdditonalProperties`, the client library will automatically add the HTTP request header `"unknown_params": "pass-through"`.

Azure_AI_Inference_ChatCompletionsWithAdditionalPropertiesScenario

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithAdditionalPropertiesScenario
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("How many feet are in a mile?"),
    },
    AdditionalProperties = { { "foo", BinaryData.FromString("\"bar\"") } }, // Optional, add additional properties to the request to pass to the model
};
Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Choices[0].Message.Content);
```

### Text Embeddings example

This example demonstrates how to get text embeddings, with key authentication, assuming `endpoint` and `key` are already defined.

```C# Snippet:Azure_AI_Inference_BasicEmbedding
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_EMBEDDINGS_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_EMBEDDINGS_KEY"));

var client = new EmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var input = new List<string> { "King", "Queen", "Jack", "Page" };
var requestOptions = new EmbeddingsOptions(input);

Response<EmbeddingsResult> response = client.Embed(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```

The length of the embedding vector depends on the model, but you should see something like this:

```text
data[0]: length=1024, [0.0013399124, -0.01576233, ..., 0.007843018, 0.000238657]
data[1]: length=1024, [0.036590576, -0.0059547424, ..., 0.011405945, 0.004863739]
data[2]: length=1024, [0.04196167, 0.029083252, ..., -0.0027484894, 0.0073127747]
```

To generate embeddings for additional phrases, simply call `client.embed` multiple times using the same `client`.

<!--
### Image Embeddings example

This example demonstrates how to get image embeddings.

 <! -- SNIPPET:sample_image_embeddings.image_embeddings -- >

```python
from azure.ai.inference import ImageEmbeddingsClient
from azure.ai.inference.models import EmbeddingInput
from azure.core.credentials import AzureKeyCredential

with open("sample1.png", "rb") as f:
    image1: str = base64.b64encode(f.read()).decode("utf-8")
with open("sample2.png", "rb") as f:
    image2: str = base64.b64encode(f.read()).decode("utf-8")

client = ImageEmbeddingsClient(endpoint=endpoint, credential=AzureKeyCredential(key))

response = client.embed(input=[EmbeddingInput(image=image1), EmbeddingInput(image=image2)])

for item in response.data:
    length = len(item.embedding)
    print(
        f"data[{item.index}]: length={length}, [{item.embedding[0]}, {item.embedding[1]}, "
        f"..., {item.embedding[length-2]}, {item.embedding[length-1]}]"
    )
```

-- END SNIPPET --

The printed result of course depends on the model, but you should see something like this:

```txt
TBD
```

To generate embeddings for additional phrases, simply call `client.embed` multiple times using the same `client`.
-->

## Troubleshooting

### Observability with OpenTelemetry

Azure AI Inference client library supports tracing and metrics with OpenTelemetry. Refer to
[Azure SDK Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#distributed-tracing)
documentation for general information on OpenTelemetry support in Azure client libraries.

Distributed tracing and metrics with OpenTelemetry are supported in Azure AI Inference in experimental mode and could be enabled through either
of these steps:

- Set the `AZURE_EXPERIMENTAL_ENABLE_ACTIVITY_SOURCE` environment variable to `true`.
- Set the `Azure.Experimental.EnableActivitySource` context switch to `true` in your application code

Refer to [Azure Monitor documentation](https://learn.microsoft.com/azure/azure-monitor/app/opentelemetry-enable?tabs=aspnetcore) on how to use
Azure Monitor OpenTelemetry Distro.

> [!NOTE]
> With the Azure Monitor OpenTelemetry Distro, you only need to opt-into Azure SDK experimental telemetry features with one of the ways documented at
> the beginning of this section.
> The distro enables activity sources and meters for Azure AI Inference automatically.

The following section provides an example on how to configure OpenTelemetry and enable Azure AI Inference tracing and metrics if your
OpenTelemetry distro does not include Azure AI Inference by default.

#### Generic OpenTelemetry configuration

In this example we're going to export traces and metrics to console, and to the local [OTLP](https://opentelemetry.io/docs/specs/otel/protocol/) destination.
[Aspire dashboard](https://learn.microsoft.com/dotnet/aspire/fundamentals/dashboard/standalone) can be used for local testing and exploration.

To run this example, you'll need to install the following dependencies (HTTP tracing and metrics instrumentation
as well as console and OTLP exporters):

```dotnetcli
dotnet add package OpenTelemetry.Instrumentation.Http
dotnet add package OpenTelemetry.Exporter.Console
dotnet add package OpenTelemetry.Exporter.OpenTelemetryProtocol
```

These packages also bring [OpenTelemetry SDK](https://www.nuget.org/packages/OpenTelemetry) as a dependency.

```C# Snippet:Azure_AI_Inference_EnableOpenTelemetry
// Enables experimental Azure SDK observability
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);

// By default instrumentation captures chat messages without content
// since content can be very verbose and have sensitive information.
// The following AppContext switch enables content recording.
AppContext.SetSwitch("Azure.Experimental.TraceGenAIMessageContent", true);

using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddHttpClientInstrumentation()
    .AddSource("Azure.AI.Inference.*")
    .ConfigureResource(r => r.AddService("sample"))
    .AddConsoleExporter()
    .AddOtlpExporter()
    .Build();

using var meterProvider = Sdk.CreateMeterProviderBuilder()
    .AddHttpClientInstrumentation()
    .AddMeter("Azure.AI.Inference.*")
    .ConfigureResource(r => r.AddService("sample"))
    .AddConsoleExporter()
    .AddOtlpExporter()
    .Build();
```

Check out [OpenTelemetry .NET](https://opentelemetry.io/docs/languages/net/) and your observability provider documentation on how to configure OpenTelemetry.

### Exceptions

The `complete`, `get_model_info` methods raise a `RequestFailedException` for a non-success HTTP status code response from the service. The exception's `code` will hold the HTTP response status code. The exception's `message` contains a detailed message that may be helpful in diagnosing the issue:

```C# Snippet:Azure_AI_Inference_ChatCompletionsExceptionHandling
try
{
    client.Complete(requestOptions);
}
catch (RequestFailedException e)
{
    Console.WriteLine($"Exception status code: {e.Status}");
    Console.WriteLine($"Exception message: {e.Message}");
    Assert.IsTrue(e.Message.Contains("Extra inputs are not permitted"));
}
```

### Reporting issues

To report issues with the client library, or request additional features, please open a GitHub issue [here](https://github.com/Azure/azure-sdk-for-net/issues)

## Next steps

Have a look at the [Samples](https://aka.ms/azsdk/azure-ai-inference/csharp/samples) folder, containing fully runnable C# code for doing inference using synchronous and asynchronous methods.

## Contributing

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution.
For details, visit [https://cla.microsoft.com](https://cla.microsoft.com).

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately (e.g., label,
comment). Simply follow the instructions provided by the bot. You will only
need to do this once across all repos using our CLA.

This project has adopted the
[Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct). For more information,
see the Code of Conduct FAQ or contact opencode@microsoft.com with any
additional questions or comments.

<!-- LINKS -->
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
