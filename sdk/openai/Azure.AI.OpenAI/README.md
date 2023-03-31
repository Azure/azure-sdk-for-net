# Azure OpenAI client library for .NET

The Azure OpenAI client library for .NET is an adaptation of OpenAI's REST APIs that provides an idiomatic interface
and rich integration with the rest of the Azure SDK ecosystem. It can connect to Azure OpenAI resources *or* to the
non-Azure OpenAI inference endpoint, making it a great choice for even non-Azure OpenAI development.

Use the client library for Azure OpenAI to:

* [Create a completion for text][msdocs_openai_completion]
* [Create a text embedding for comparisons][msdocs_openai_embedding]

Azure OpenAI is a managed service that allows developers to deploy, tune, and generate content from OpenAI models on Azure resources.

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.AI.OpenAI) | [API reference documentation](https://learn.microsoft.com/azure/cognitive-services/openai/reference) | [Product documentation](https://learn.microsoft.com/azure/cognitive-services/openai/) | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/tests/Samples)

## Getting started

### Prerequisites

If you'd like to use an Azure OpenAI resource, you must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/)
and [Azure OpenAI access](https://learn.microsoft.com/azure/cognitive-services/openai/overview#how-do-i-get-access-to-azure-openai).
This will allow you to create an Azure OpenAI resource and get both a connection URL as well as API keys. For more
information, see [Quickstart: Get started generating text using Azure OpenAI Service](https://learn.microsoft.com/azure/cognitive-services/openai/quickstart).

If you'd like to use the Azure OpenAI .NET client library to connect to non-Azure OpenAI, you'll need an API key
from a developer account at https://platform.openai.com/.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.OpenAI --prerelease
```

### Authenticate the client

In order to interact with Azure OpenAI or OpenAI, you'll need to create an instance of the [OpenAIClient][openai_client_class]
class. To configure a client for use with Azure OpenAI, provide a valid endpoint URI to an Azure OpenAI resource
along with a corresponding key credential, token credential, or Azure identity credential that's authorized to use the
Azure OpenAI resource. To instead configure the client to connect to OpenAI's service, provide an API key from OpenAI's
developer portal.

```C# Snippet:MakeClientWithAzureOrNonAzureOpenAI
OpenAIClient client = useAzureOpenAI
    ? new OpenAIClient(
        new Uri("https://your-azure-openai-resource.com/"),
        new AzureKeyCredential("your-azure-openai-resource-api-key"))
    : new OpenAIClient("your-api-key-from-platform.openai.com");
```

#### Create OpenAIClient with an Azure Active Directory Credential

Client subscription key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity]. To use the [DefaultAzureCredential][azure_identity_dac] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

```C# Snippet:CreateOpenAIClientTokenCredential
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

The main concept to understand is [Completions][azure_openai_completions_docs]. Briefly explained, completions provides its functionality in the form of a text prompt, which by using a specific [model](https://learn.microsoft.com/azure/cognitive-services/openai/concepts/models), will then attempt to match the context and patterns, providing an output text. The following code snippet provides a rough overview (more details can be found in the `GenerateChatbotResponsesWithToken` sample code):

```C# Snippet:UseAzureOrNonAzureOpenAI
OpenAIClient client = useAzureOpenAI
    ? new OpenAIClient(
        new Uri("https://your-azure-openai-resource.com/"),
        new AzureKeyCredential("your-azure-openai-resource-api-key"))
    : new OpenAIClient("your-api-key-from-platform.openai.com");

Response<Completions> response = await client.GetCompletionsAsync(
    "text-davinci-003", // assumes a matching model deployment or model name
    "Hello, world!");

foreach (Choice choice in response.Value.Choices)
{
    Console.WriteLine(choice.Text);
}
```

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/openai/Azure.AI.OpenAI/tests/Samples).

### Generate Chatbot Response

The `GenerateChatbotResponse` method authenticates using a DefaultAzureCredential, then generates text responses to input prompts.

```C# Snippet:GenerateChatbotResponse
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

string deploymentName = "text-davinci-003";
string prompt = "What is Azure OpenAI?";
Console.Write($"Input: {prompt}");

Response<Completions> completionsResponse = client.GetCompletions(deploymentName, prompt);
string completion = completionsResponse.Value.Choices[0].Text;
Console.WriteLine($"Chatbot: {completion}");
```

### Generate Multiple Chatbot Responses With Subscription Key

The `GenerateMultipleChatbotResponsesWithSubscriptionKey` method gives an example of generating text responses to input prompts using an Azure subscription key

```C# Snippet:GenerateMultipleChatbotResponsesWithSubscriptionKey
// Replace with your Azure OpenAI key
string key = "YOUR_AZURE_OPENAI_KEY";
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));

List<string> examplePrompts = new(){
    "How are you today?",
    "What is Azure OpenAI?",
    "Why do children love dinosaurs?",
    "Generate a proof of Euler's identity",
    "Describe in single words only the good things that come into your mind about your mother.",
};

string deploymentName = "text-davinci-003";

foreach (string prompt in examplePrompts)
{
    Console.Write($"Input: {prompt}");
    CompletionsOptions completionsOptions = new CompletionsOptions();
    completionsOptions.Prompts.Add(prompt);

    Response<Completions> completionsResponse = client.GetCompletions(deploymentName, completionsOptions);
    string completion = completionsResponse.Value.Choices[0].Text;
    Console.WriteLine($"Chatbot: {completion}");
}
```

### Summarize Text with Completion

The `SummarizeText` method generates a summarization of the given input prompt.

```C# Snippet:SummarizeText
string endpoint = "https://myaccount.openai.azure.com/";
var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

string textToSummarize = @"
    Two independent experiments reported their results this morning at CERN, Europe's high-energy physics laboratory near Geneva in Switzerland. Both show convincing evidence of a new boson particle weighing around 125 gigaelectronvolts, which so far fits predictions of the Higgs previously made by theoretical physicists.

    ""As a layman I would say: 'I think we have it'. Would you agree?"" Rolf-Dieter Heuer, CERN's director-general, asked the packed auditorium. The physicists assembled there burst into applause.
:";

string summarizationPrompt = @$"
    Summarize the following text.

    Text:
    """"""
    {textToSummarize}
    """"""

    Summary:
";

Console.Write($"Input: {summarizationPrompt}");
var completionsOptions = new CompletionsOptions()
{
    Prompts = { summarizationPrompt },
};

string deploymentName = "text-davinci-003";

Response<Completions> completionsResponse = client.GetCompletions(deploymentName, completionsOptions);
string completion = completionsResponse.Value.Choices[0].Text;
Console.WriteLine($"Summarization: {completion}");
```

### Stream Chat Messages with non-Azure OpenAI

```C# Snippet:StreamChatMessages
string nonAzureOpenAIApiKey = "your-api-key-from-platform.openai.com";
var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions());
var chatCompletionsOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatMessage(ChatRole.System, "You are a helpful assistant. You will talk like a pirate."),
        new ChatMessage(ChatRole.User, "Can you help me?"),
        new ChatMessage(ChatRole.Assistant, "Arrrr! Of course, me hearty! What can I do for ye?"),
        new ChatMessage(ChatRole.User, "What's the best way to train a parrot?"),
    }
};

Response<StreamingChatCompletions> response = await client.GetChatCompletionsStreamingAsync(
    deploymentOrModelName: "gpt-3.5-turbo",
    chatCompletionsOptions);
using StreamingChatCompletions streamingChatCompletions = response.Value;

await foreach (StreamingChatChoice choice in streamingChatCompletions.GetChoicesStreaming())
{
    await foreach (ChatMessage message in choice.GetMessageStreaming())
    {
        Console.Write(message.Content);
    }
    Console.WriteLine();
}
```

## Troubleshooting

When you interact with Azure OpenAI using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][openai_rest] requests.

For example, if you try to create a client using an endpoint that doesn't match your Azure OpenAI Resource endpoint, a `404` error is returned, indicating `Resource Not Found`.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

See the [OpenAI CONTRIBUTING.md][openai_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[azure_identity_dac]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[msdocs_openai_completion]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[msdocs_openai_embedding]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[openai_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/src/Generated/OpenAIClient.cs
[openai_rest]: https://learn.microsoft.com/azure/cognitive-services/openai/reference
[azure_openai_completions_docs]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[azure_openai_embeddgings_docs]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[openai_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/openai/Azure.AI.OpenAI/README.png)
