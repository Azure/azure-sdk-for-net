# Azure Personalizer client library for .NET

[Azure Personalizer](https://learn.microsoft.com/azure/cognitive-services/personalizer/)
is a cloud-based service that helps your applications choose the best content item to show your users. You can use the Personalizer service to determine what product to suggest to shoppers or to figure out the optimal position for an advertisement. After the content is shown to the user, your application monitors the user's reaction and reports a reward score back to the Personalizer service. This ensures continuous improvement of the machine learning model, and Personalizer's ability to select the best content item based on the contextual information it receives.

## Getting started

### Install the package

Install the Azure Personalizer client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.Personalizer --prerelease
```

## Key concepts
Functionality is exposed through several client libraries:

- [Azure.AI.Personalizer](https://www.nuget.org/packages/Azure.AI.Personalizer) is built on top of [Azure.Core](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md) and the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).

- [Microsoft.Azure.Personalizer](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitiveservices/Personalizer) is the previous .NET client library for Personalizer.
