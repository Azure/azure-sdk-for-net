# Authentication events trigger for Azure Functions client library for .NET

The authentication events trigger for Azure Functions allows you to implement a custom extension to handle Microsoft Entra authentication events. The authentication events trigger handles all the backend processing for incoming HTTP requests for Microsoft Entra authentication events and provides the developer with:

- Token validation for securing the API call
- Object model, typing, and IDE intellisense
- Inbound and outbound validation of the API request and response schemas

## Getting started

### Install the package

Install the authentication events trigger for Azure Functions with [NuGet](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents/):

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
```

### Prerequisites

- **Azure Subscription:** To use Azure services, including Azure Functions, you'll need a subscription. If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).

### Authenticate the client

When the Microsoft Entra authentication events service calls your custom extension, it sends an `Authorization` header with a `Bearer {token}`. This token represents a [service to service authentication](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-client-creds-grant-flow) in which:

* The '**resource**', also known as the **audience**, is the application that you register to represent your API. This is represented by the `aud` claim in the token.
* The '**client**' is a Microsoft application that represents the Microsoft Entra authentication events service. It has an `appId` value of `99045fe1-7639-4a75-9d4a-577b6ca3810f`. This is represented by:
  * The `azp` claim in the token if your application `accessTokenAcceptedVersion` property is set to `2`.
  * The `appid` claim in the token if your resource application's `accessTokenAcceptedVersion` property is set to `1` or `null`.

There are different approaches to authenticating HTTP requests to your function app and validating the token which can be found [here](https://learn.microsoft.com/entra/identity-platform/custom-extension-tokenissuancestart-setup?tabs=visual-studio%2Cazure-portal&pivots=nuget-library#configure-authentication-for-your-azure-function).

#### Bypass token validation

If you would like to _not_ authenticate the token while in local development, set the following application settings in the [local.settings.json](https://learn.microsoft.com/azure/azure-functions/functions-develop-local#local-settings-file) file:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "AzureWebJobsSecretStorageType": "files",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AuthenticationEvents__BypassTokenValidation" : true
  }
}
```

### How to get started

You can follow this article to start creating your function: [Create a REST API for a token issuance start event in Azure Functions](https://learn.microsoft.com/entra/identity-platform/custom-extension-tokenissuancestart-setup?tabs=visual-studio%2Cazure-portal&pivots=nuget-library)

## Key concepts

### .NET SDK

Key concepts of the Azure .NET SDK can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

### Microsoft Entra custom extensions

Custom extensions allow you to handle Microsoft Entra authentication events, integrate with external systems, and customize what happens in your application authentication experience. For example, a custom claims provider is a custom extension that allows you to enrich or customize application tokens with information from external systems that can't be stored as part of the Microsoft Entra directory. 

### Authentication events trigger

The authentication events trigger allows a function to be executed when an authentication event is sent from the Microsoft Entra event service.

### Authentication events trigger output binding

The authentication events trigger output binding allows a function to send authentication event actions to the Microsoft Entra event service.

## Examples

To test token augmentation, please do the following.

* Open the project that was created in the prior step. [How to get started](#how-to-get-started)
* Follow [these steps](https://learn.microsoft.com/entra/identity-platform/custom-extension-tokenissuancestart-setup?tabs=visual-studio%2Cazure-portal&pivots=nuget-library#build-and-run-the-project-locally) to test your app locally.

## Troubleshooting

### Visual Studio Code
  * If running in Visual Studio Code, you get an error along the lines of the local Azure Storage Emulator is unavailable, you can start the emulator manually. (Note: Azure Storage emulator is now deprecated and the suggested replacement is [Azurite](https://learn.microsoft.com/azure/storage/common/storage-use-azurite?tabs=visual-studio))
  * If using Visual Studio Code on Mac please use [Azurite](https://learn.microsoft.com/azure/storage/common/storage-use-azurite?tabs=visual-studio)

### Azure function endpoint

* To determine your published posting endpoint, combine the azure function endpoint you created, route to the listener and listener code, the listen code can be found by navigating to your azure function application, selecting "App Keys" and copying the value of AuthenticationEvents_extension.
  * For example: "https://azureautheventstriggerdemo.azurewebsites.net/runtime/webhooks/AuthenticationEvents?code=(AuthenticationEvents_extension_key)&function=OnTokenIssuanceStart"

## Next steps

Follow [Configure a custom claim provider for a token issuance event](https://learn.microsoft.com/entra/identity-platform/custom-extension-tokenissuancestart-configuration?tabs=azure-portal%2Cworkforce-tenant) to create a custom extension that will call your function.

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

Information about logging and metrics for the deployed function can be found [here](https://learn.microsoft.com/azure/azure-functions/monitor-functions?tabs=portal)


## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(e.g., label, comment). Simply follow the instructions provided by the
bot. You will only need to do this once across all repositories using
our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fentra%2FMicrosoft.Azure.WebJobs.Extensions.AuthenticationEvents%2FREADME.png)

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
