# Azure OpenAI client library for .NET

Azure OpenAI is a managed service that allows developers to deploy, tune, and generate content from OpenAI models on Azure resouces.

Use the client library for Azure OpenAI to:

* [Create a completion for text][msdocs_openai_completion]
* [Create a text embedding for comparisons][msdocs_openai_embedding]

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.OpenAI.Inference/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.OpenAI.Inference --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [OpenAI access](https://learn.microsoft.com/azure/cognitive-services/openai/overview#how-do-i-get-access-to-azure-openai).

### Authenticate the client

In order to interact with the App Configuration service, you'll need to create an instance of the [OpenAIClient][openai_client_class] class. To make this possible, you'll need the endpoint string for your OpenAI resource, as well as your Azure Subscription Key.

#### Get credentials

You can obtain the endpoint string and subscription key from the Azure OpenAI Portal.

#### Create OpenAIClient

Once you have the value of the endpoint string and subscription key, you can create the OpenAIClient:

```C# Snippet:CreateOpenAIClient
string endpointString = "<endpoint_string>";
string subscriptionKey = "<azure_subscription_key>";
var client = new OpenAIClient(new Uri(endpointString), new AzureKeyCredential(subscriptionKey));
```

#### Create OpenAIClient with Azure Active Directory Credential

Client subscription key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity]. To use the [DefaultAzureCredential][azure_identity_dac] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

You will also need to [register a new AAD application][aad_register_app] and [grant access][aad_grant_access] to Configuration Store by assigning the `"App Configuration Data Reader"` or `"App Configuration Data Owner"` role to your service principal.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```C# Snippet:CreateOpenAIClientTokenCredential
string endpoint = "<endpoint>";
var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());
```


## Key concepts

The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

Include the *Thread safety* and *Additional concepts* sections below at the end of your *Key concepts* section. You may remove or add links depending on what your library makes use of:

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/openai/Azure.OpenAI.Inference/samples).

### Get secret

The `GetSecret` method retrieves a secret from the service.

```C# Snippet:Azure_OpenAI_GetSecret
string endpoint = "http://myaccount.openai.azure.com/";
string key = "myKey";

OpenAIClient client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
CompletionsRequest completionsRequest = new CompletionsRequest();
completionsRequest.Prompt.Add("Hello world");
completionsRequest.Prompt.Add("running over the same old ground");
Completion response = client.Completions("myModelDeployment", completionsRequest);

foreach (Choice choice in response.Choices)
{
    Console.WriteLine(choice.Text);
}
```

### Generate Chatbot Responses

The `GenerateChatbotResponses` method gives an example of generating text responses to input prompts.

```C# Snippet:GenerateChatbotResponses
List<string> examplePrompts = new(){
    "How are you today?",
    "What is Azure OpenAI?",
    "Why do children love dinosaurs?",
    "Generate a proof of Euler's identity",
    "Describe in single words only the good things that come into your mind about your mother.",
};

foreach (var prompt in examplePrompts)
{
    Console.Write($"Input: {prompt}");
    var request = new CompletionsRequest();
    request.Prompt.Add(prompt);

    Completion completion = client.Completions("myModelDeployment", request);
    var response = completion.Choices[0].Text;
    Console.WriteLine($"Chatbot: {response}");
}
```

### Generate Chatbot Responses With Token

The `GenerateChatbotResponsesWithToken` method authenticates using a DefaultAzureCredential, then generates text responses to input prompts.

```C# Snippet:GenerateChatbotResponsesWithToken
string endpoint = "http://myaccount.openai.azure.com/";
OpenAIClient client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

List<string> examplePrompts = new(){
    "How are you today?",
    "What is Azure OpenAI?",
    "Why do children love dinosaurs?",
    "Generate a proof of Euler's identity",
    "Describe in single words only the good things that come into your mind about your mother.",
};

foreach (var prompt in examplePrompts)
{
    Console.Write($"Input: {prompt}");
    var request = new CompletionsRequest();
    request.Prompt.Add(prompt);

    Completion completion = client.Completions("myModelDeployment", request);
    var response = completion.Choices[0].Text;
    Console.WriteLine($"Chatbot: {response}");
}
```

### Summarize Text with Completion

The `SummarizeText` method generates a summarization of the given input prompt.

```C# Snippet:SummarizeText
string endpoint = "http://myaccount.openai.azure.com/";
string textToSummarize = @"
    Two independent experiments reported their results this morning at CERN, Europe's high-energy physics laboratory near Geneva in Switzerland. Both show convincing evidence of a new boson particle weighing around 125 gigaelectronvolts, which so far fits predictions of the Higgs previously made by theoretical physicists.

    ""As a layman I would say: 'I think we have it'. Would you agree?"" Rolf-Dieter Heuer, CERN's director-general, asked the packed auditorium. The physicists assembled there burst into applause.
:";
OpenAIClient client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

string summarizationPrompt = @$"
    Summarize the following text.

    Text:
    """"""
    {textToSummarize}
    """"""

    Summary:
";

Console.Write($"Input: {summarizationPrompt}");
var request = new CompletionsRequest();
request.Prompt.Add(summarizationPrompt);

Completion completion = client.Completions("myModelDeployment", request);
var response = completion.Choices[0].Text;
Console.WriteLine($"Summarization: {response}");
```
## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[msdocs_openai_completion]: https://learn.microsoft.com/azure/cognitive-services/openai/how-to/completions
[msdocs_openai_embedding]: https://learn.microsoft.com/azure/cognitive-services/openai/concepts/understand-embeddings
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[openai_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.OpenAI.Inference/src/Generated/OpenAIClient.cs

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/openai/Azure.OpenAI.Inference/README.png)
