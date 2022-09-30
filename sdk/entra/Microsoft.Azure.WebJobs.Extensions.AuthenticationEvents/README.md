# Authentication events trigger for Azure Functions client library for .NET

The authentication events trigger for Azure Functions allows you to implement a custom extension to handle Azure Active Directory (Azure AD) authentication events. The authentication events trigger handles all the backend processing for incoming HTTP requests for Azure AD authentication events and provides the developer with:

- Token validation for securing the API call
- Object model, typing, and IDE intellisense
- Inbound and outbound validation of the API request and response schemas

## Getting started

### Install the package

Install the authentication events trigger for Azure Functions with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents --prerelease
```

### Prerequisites

- **Azure Subscription:** To use Azure services, including Azure Functions, you'll need a subscription. If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).

### Authenticate the client

When the Azure AD authentication events service calls your custom extension, it sends an `Authorization` header with a `Bearer {token}`. This token represents a [service to service authentication](https://learn.microsoft.com/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow) in which:

* The '**resource**', also known as the **audience**, is the application that you register to represent your API. This is represented by the `aud` claim in the token.
* The '**client**' is a Microsoft application that represents the Azure AD authentication events service. It has an `appId` value of `99045fe1-7639-4a75-9d4a-577b6ca3810f`. This is represented by:
  * The `azp` claim in the token if your application `accessTokenAcceptedVersion` property is set to `2`.
  * The `appid` claim in the token if your resource application's `accessTokenAcceptedVersion` property is set to `1` or `null`.

There are three approaches to authenticating HTTP requests to your function app and validating the token.

- Validate tokens using Azure Functions Azure AD authentication integration: When running your function in production, it is **highly recommended** to use the [Azure Functions Azure AD authentication integration](https://learn.microsoft.com/azure/app-service/configure-authentication-provider-aad#-option-2-use-an-existing-registration-created-separately) for validating incoming tokens.
- Have the trigger validate the token: In local environments or environments that aren't hosted in the Azure Function service, the trigger can do the token validation.
- Don't validate the token: If you would like to _not_ authenticate the token during local development.

To learn more, read about [testing your custom claims provider API](https://learn.microsoft.com/en-us/azure/active-directory/develop/custom-claims-provider-test-function-trigger).  

## Key concepts

### Azure AD custom extensions

Custom extensions allow you to handle Azure AD events, integrate with external systems, and customize what happens in your application authentication experience. For example, a custom claims provider is a custom extension that allows you to enrich or customize application tokens with information from external systems that can't be stored as part of the Azure AD directory. Read [Custom claims providers overview](https://learn.microsoft.com/azure/active-directory/develop/custom-claims-provider-overview) to learn more about custom extensions and custom claims providers.

### Authentication events trigger

The authentication events trigger allows a function to be executed when an authentication event is sent from the Azure AD event service.

Read [Configure a SAML app to receive tokens with claims from an external store](https://learn.microsoft.com/azure/active-directory/develop/custom-claims-provider-source-claims-from-external-system-saml-app) and [Configure an OIDC app to receive tokens with claims from an external store](https://learn.microsoft.com/azure/active-directory/develop/custom-claims-provider-source-claims-from-external-system-oidc-app) to learn more about using the authentication events trigger.

### Authentication events trigger output binding

The authentication events trigger output binding allows a function to send authentication event actions to the Azure AD event service.

## Documentation

Learn about custom [claims providers and custom extensions](https://learn.microsoft.com/en-us/azure/active-directory/develop/custom-claims-provider-overview).  Learn how to create and register your custom claims provider API, how to add tokens from external stores, and how to test and troubleshoot your API.

## Examples

### Quickstart

#### Prerequisites

1. [Download Postman](https://www.postman.com/downloads/)
2. Download the [Authentication_Events_Collection.json](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/wiki/collection/Authentication_Events_Collection.json) for the Authentication Events Trigger.
3. In the Postman app, [create a new workspace](https://learning.postman.com/docs/getting-started/creating-your-first-workspace/) and [import](https://learning.postman.com/docs/getting-started/importing-and-exporting-data/) the Authentication Events Collection JSON file.

#### Create the project

##### Visual Studio

1. Open Visual Studio and select **Create a new project**.

2. In **Search for a template**, search for "AzureAuthEventsTrigger" and select it from the returned results.

3. Select **Next**.

4. Give your project a meaningful **Project name**, **Empty Location**, and **Solution name** and select **Create**. The name of the project created is the `{functionAppName}`. For example, "authenticationeventsAPI".

##### Visual Studio Code

1. Open Visual Studio Code.

2. Select **View** -> **Command Palette** and run the command `Create Azure Authentication Events Trigger Project`.

3. Give your project a meaningful **Project name**, **Empty Location**, and **Solution name** and select **Create**. The name of the project created is the `{functionAppName}`. For example, "authenticationeventsAPI".

#### Update the function configuration and run locally

For local development and testing purposes, you can turn off token validation. Open the *local.settings.json* file in the project. Add the *AuthenticationEventTrigger__BypassTokenValidation* setting and a value of "true":

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AuthenticationEventTrigger__BypassTokenValidation": true
  }
}
```

Run the function app from Visual Studio or Visual Studio Code. In the output, you should see the Azure functions developer's application load your end point. Find the **Host** value (for example, "localhost:7071") and **Code** value (for example, "Z4pp0zA3zoA...FuJWxaog==").

#### Update Postman variables

In Postman, select the **Authentication Events** collection. Select the **Variable** tab. Copy and paste the **Host** and **Code** variables values from the running function app into the host and code variables (in the **CURRENT VALUE** column). Save the collection.

In Postman, select the **Local** request. Select the **Body** tab. Verify or change sample payload values.

#### Send the request using Postman

While the function app is running locally, send the payload to your function app by clicking **Send**. A debugger is already attached your running function app code, so any breakpoints that are passed through will break into the debugger.

Verify the function app was executed successfully by checking the HTTP response and status code in the **Postman console**.

## Troubleshooting

* Visual Studio Code
  * If running in Visual Studio Code, you get an error along the lines of the local Azure Storage Emulator is unavailable, you can start the emulator manually.! (Note: Azure Storage emulator is now deprecated and the suggested replacement is [Azurite](https://learn.microsoft.com/azure/storage/common/storage-use-azurite?tabs=visual-studio))
  * If using Visual Studio Code on Mac please use [Azurite](https://learn.microsoft.com/azure/storage/common/storage-use-azurite?tabs=visual-studio)
  * If you see the following error on Windows (it's a bug) when trying to run the created projected.
  * This can be resolved by executing this command in powershell `Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope LocalMachine` more info on this can be found [here](https://github.com/Azure/azure-functions-core-tools/issues/1821) and [here](https://learn.microsoft.com/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7)

For information on troubleshooting you custom claims provider, please read [Troubleshooting](https://learn.microsoft.com/azure/active-directory/develop/custom-claims-provider-troubleshoot).

## Next steps

Learn how to [create, publish, and register a custom claims provider API](https://learn.microsoft.com/azure/active-directory/develop/custom-claims-provider-create-register-api).

If you already have a custom claims provider registered, you can configure a [SAML application](https://learn.microsoft.com/azure/active-directory/develop/custom-claims-provider-source-claims-from-external-system-saml-app) or an [OIDC](https://learn.microsoft.com/azure/active-directory/develop/custom-claims-provider-source-claims-from-external-system-oidc-app) application to receive tokens with claims sourced from an external store.

Learn how to [test your custom claims provider API](https://learn.microsoft.com/azure/active-directory/develop/custom-claims-provider-test-function-trigger).

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

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/