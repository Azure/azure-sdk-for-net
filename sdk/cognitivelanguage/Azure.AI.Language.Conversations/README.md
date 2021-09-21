# Azure Cognitive Language Services Conversations client library for .NET

Conversations (aka LuisVNext) is a cloud-based conversational AI service that applies custom machine-learning intelligence to a user's conversational, natural language text to predict overall meaning, and pull out relevant, detailed information. The service utilizes state-of-the-art technology to create and utilize natively multilingual models, which means that users would be able to train their models in one language but predict in others. 

[Source code][conversationanalysis_client_src] | [Package (NuGet)][conversationanalysis_nuget_package] | [API reference documentation][conversationanalysis_refdocs] | [Product documentation][conversationanalysis_docs] | [Samples][conversationanalysis_samples]

## Getting started

### Install the package

Install the Azure Cognitive Language Services Conversations client library for .NET with [NuGet][nuget]:

```powershell
dotnet add package Azure.AI.Language.Conversations --prerelease
```

### Prerequisites

* An [Azure subscription][azure_subscription]
* An existing Text Analytics resource

> Note: the new unified Cognitive Language Services are not currently available for deployment.

### Authenticate the client

In order to interact with the Conversations service, you'll need to create an instance of the [`ConversationAnalysisClient`][conversationanalysis_client_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the **endpoint** and an **API key** from the Cognitive Services resource in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] command shown below to get the API key from the Cognitive Service resource.

```powershell
az cognitiveservices account keys list --resource-group <resource-group-name> --name <resource-name>
```

#### Create a ConversationAnalysisClient

Once you've determined your **endpoint** and **API key** you can instantiate a `ConversationAnalysisClient`:

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

## Key concepts

### ConversationAnalysisClient

The [`ConversationAnalysisClient`][conversationanalysis_client_class] is the primary interface for making predictions using your deployed Conversation models. It provides both synchronous and asynchronous APIs to submit queries.

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

The Azure.AI.Language.Conversations client library provides both synchronous and asynchronous APIs.

The following examples show common scenarios using the `client` [created above](#Create a ConversationAnalysisClient).

### Analyze a Conversation

To analyze a conversation, we can then simply call the `client.AnalyzeConversation()` method, which takes the project name, deployment name and query as parameters.

```C# Snippet:ConversationAnalysis_AnalyzeConversation
Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
    "Menu",
    "production",
    "We'll have 2 plates of seared salmon nigiri.");

Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
```

To set additional properties such as language of the query and verbosity, you can initialise an `AnalyzeConversationOptions` instance with your chosen parameters. You can then call `AnalyzeConversation()` using the options as a parameter.

## Troubleshooting

### General

When you interact with the Cognitive Language Services Conversations client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][conversationanalysis_rest_docs] requests.

For example, if you submit a query to a non-existant project, a `400` error is returned indicating "Bad Request".

```C# Snippet:ConversationAnalysisClient_BadRequest
try
{
    Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
        "invalid-project",
        "production",
        "We'll have 2 plates of seared salmon nigiri.");
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

### Setting up console logging

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console use the `AzureEventSourceListener.CreateConsoleLogger` method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][core_logging].

## Next steps

* View our [samples][conversationanalysis_samples].
* Read about the different [features][conversationanalysis_docs_features] of the Conversations service.
* Try our service [demos][conversationanalysis_docs_demos].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure/
[azure_portal]: https://portal.azure.com/
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication/
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[core_logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[nuget]: https://www.nuget.org/

<!--References after mergin to main repo-->
[conversationanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/src/ConversationAnalysisClient.cs
[conversationanalysis_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/src/
[conversationanalysis_nuget_package]: https://nuget.org/packages/Azure.AI.Language.Conversations/
[conversationanalysis_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/

<!--Will be updated once service documentation is public-->
[conversationanalysis_docs]: https://docs.microsoft.com/azure/cognitive-services/qnamaker/ 
[conversationanalysis_docs_demos]: https://azure.microsoft.com/services/cognitive-services/qna-maker/#demo
[conversationanalysis_docs_features]: https://azure.microsoft.com/services/cognitive-services/qna-maker/#features
[conversationanalysis_refdocs]: https://docs.microsoft.com/dotnet/api/Azure.AI.Language.QuestionAnswering/
[conversationanalysis_rest_docs]: https://docs.microsoft.com/rest/api/cognitiveservices-qnamaker/
