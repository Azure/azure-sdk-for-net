# Azure Personalizer client library for .NET

[Azure Personalizer](https://docs.microsoft.com/azure/cognitive-services/personalizer/)
is a cloud-based service that helps your applications choose the best content item to show your users. You can use the Personalizer service to determine what product to suggest to shoppers or to figure out the optimal position for an advertisement. After the content is shown to the user, your application monitors the user's reaction and reports a reward score back to the Personalizer service. This ensures continuous improvement of the machine learning model, and Personalizer's ability to select the best content item based on the contextual information it receives.

# Quickstart Samples
[comment]: <> (TODO -- 1. change the version in the quickstart once the SDK is realeased. 2. Change multi-slot quickstart to use sdk instead of HTTP)
[Personalizer Quickstart](https://docs.microsoft.com/azure/cognitive-services/personalizer/quickstart-personalizer-sdk?pivots=programming-language-csharp)

[Personalizer multi-slot-quickstart](https://docs.microsoft.com/azure/cognitive-services/personalizer/how-to-multi-slot?pivots=programming-language-csharp)

# REST API Reference 
[Personazlier REST API Reference](https://docs.microsoft.com/rest/api/personalizer/)

## Getting started

### Install the package

Install the Azure Personalizer client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Personalizer --version 1.1.0-beta.1
```

### Prerequisites

[Personalizer Prerequisites](https://docs.microsoft.com/azure/cognitive-services/personalizer/quickstart-personalizer-sdk?pivots=programming-language-csharp#prerequisites)

### Authenticate the client

[Personazlier client authentication](https://docs.microsoft.com/azure/cognitive-services/personalizer/quickstart-personalizer-sdk?pivots=programming-language-csharp#authenticate-the-client)

## Key concepts

[Personazlier Concepts](https://docs.microsoft.com/azure/cognitive-services/personalizer/terminology)

## Examples

[Personalizer Quickstart](https://docs.microsoft.com/azure/cognitive-services/personalizer/quickstart-personalizer-sdk?pivots=programming-language-csharp)

[Personalizer multi-slot-quickstart](https://docs.microsoft.com/azure/cognitive-services/personalizer/how-to-multi-slot?pivots=programming-language-csharp)

[Use Personalizer in Azure Notebook](https://docs.microsoft.com/azure/cognitive-services/personalizer/tutorial-use-azure-notebook-generate-loop-data)

[Add Personalizer to a .NET web app](https://docs.microsoft.com/azure/cognitive-services/personalizer/tutorial-use-personalizer-web-app)

[Use Personalizer in .NET chat bot](https://docs.microsoft.com/azure/cognitive-services/personalizer/tutorial-use-personalizer-chat-bot)


## Troubleshooting

You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig
deeper into the requests you're making against the service.

## Next steps

* Read more about the [Azure Personalizer](https://docs.microsoft.com/azure/cognitive-services/personalizer/what-is-personalizer)

## Contributing

N/A
