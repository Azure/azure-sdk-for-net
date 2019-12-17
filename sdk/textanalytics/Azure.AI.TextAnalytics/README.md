# Azure Cognitive Services Text Analytics client library for .NET
Azure Cognitive Services Text Analytics is a cloud service ithat provides advanced natural language processing over raw text. and includes six main functions: sentiment analysis, key phrase extraction, named entity recognition, linked entity recognition, recognition of personally identifiable information, and language detection.

[Source code][textanalytics_client_src] | [Package (NuGet)][textanalytics_nuget_package] | [API reference documentation]() | [Product documentation][textanalytics_docs] | [Samples][textanalytics_samples]

## Getting started

### Install the package
Install the Azure Text Analytics client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.AI.TextAnalytics
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing [Cognitive Services][cognitive_resource] or Text Analytics resource. If you need to create the resource, you can use the [Azure Portal][azure_portal] or [Azure CLI][azure_cli].

If you use the Azure CLI, replace `<your-resource-group-name>` and `<your-resource-name>` with your own, unique names:

```PowerShell
az cognitiveservices account create --kind TextAnalytics --resource-group <your-resource-group-name> --name <your-resource-name>
```

### Authenticate the client
In order to interact with the Text Analytics service, you'll need to create an instance of the [TextAnalyticsClient][textanalytics_client_class] class. You will need an **endpoint**, and a **subscription key** to instantiate a client object.

Client subscription key authentication is used in this getting started section but you can find more ways to authenticate with [Azure identity][azure_identity]. To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
```

#### Get credentials

Use the [Azure CLI][azure_cli] snippet below to get the subscription key from the Text Analytics resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

Alternatively, you can get the endpoint and subscription key from the [Azure Portal][azure_portal].

#### Create TextAnalyticsClient
Once you have the values for endpoint and subscription key, you can create the [TextAnalyticsClient][textanalytics_client_class]:

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string subscriptionKey = "<subscriptionKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
```

## Key concepts

### TextAnalyticsClient
A `TextAnalyticsClient` is the primary interface for developers using the Text Analytics client library.  It provides both synchronous and asynchronous operations to access a specific use of Text Analytics, such as language detection or key phrase extraction. 

### Text Input
A **text input**, sometimes called a **document**, is a single unit of input to be analyzed by the predictive models in the Text Analytics service.  Operations on `TextAnalyticsClient` may take a single text input or a collection of inputs to be analyzed as a batch.

### Operation Result
An operation result, such as `AnalyzeSentimentResult`, is the result of a Text Analytics operation, containing a prediction or predictions about a single text input.  An operation's result type also may optionally include information about the input document and how it was processed.

### Operation Result Collection
 An operation result collection, such as `AnalyzeSentimentResultCollection`, is a collection of operation results, where each corresponds to one of the text inputs provided in the input batch.  A text input and its result will have the same index the input and result collections.  An operation result collection may optionally include information about the input batch and how it was processed.

 ## Examples
 The following section provides several code snippets using the `client` [created above](#create-textanalyticsclient), and covers the main functions of Text Analytics.

 <!-- TODO: Add async snippets too. -->

### Detect Language
Run a Text Analytics predictive model to determine the language that the passed-in input text or batch of input text documents are written in.

```C# Snippet:DetectLanguage
```

### Analyze Sentiment



### Extract Key Phrases

### Recognize Entities

### Recognize PII Entities

### Recognize Linked Entities


## Contributing

See the [App Configuration CONTRIBUTING.md][azconfig_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftextanalytics%2FAzure.AI.TextAnalytics%2FREADME.png)


<!-- LINKS -->
[textanalytics_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/src
[textanalytics_docs]: https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/
[textanalytics_nuget_package]: https://www.nuget.org/packages/Azure.AI.TextAnalytics
[textanalytics_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples
[cognitive_resource]: https://docs.microsoft.com/en-us/azure/cognitive-services/cognitive-services-apis-create-account

[textanalytics_client_class]: src/TextAnalyticsClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
