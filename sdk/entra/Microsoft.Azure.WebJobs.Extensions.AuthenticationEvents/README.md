# Authentication Events Trigger for Azure Functions client library for .NET

Authentication Event Trigger for Azure Functions handles all the backend processing, (e.g. token/json schema validation) for incoming Http requests for Authentication events. And provides the developer with a strongly typed, versioned object model to work with, meaning the developer need not have any prior knowledge of the request and response json payloads.

This project framework provides the following features:

* Token validation for securing the API call
* Object model, typing, and IDE intellisense
* Inbound and outbound validation of the API request and response schemas
* Versioning
* No need for boilerplate code.

## Getting started

### Install the package

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents --prerelease
```

### Prerequisites

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) for Windows **OR** [Visual Studio Code >= 1.61](https://code.visualstudio.com/download)
* [Dotnet core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
* [Azure function tools 3.30](https://github.com/Azure/azure-functions-core-tools)
* [Nuget](https://docs.microsoft.com/nuget/install-nuget-client-tools)
* [Azure Function Core Tools](https://github.com/Azure/azure-functions-core-tools#installing)
* If using Visual Studio Code the following extensions:
  * [ms-azuretools.vscode-azurefunctions](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions)
  * [ms-dotnettools.csharp](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* For private preview register a Nuget source either using Nuget''s cli **OR** Visual Studio's Nuget Package Manager.
  * Generate a GIT Personal Access Token. Go to [https://github.com/settings/tokens](https://github.com/settings/tokens)
    * When generating the token, it needs to have the following permissions/scope: **read:package**
    * Authorize **Azure** to use the Personal Access Token. (::Only if you are a member of the Azure Organization on GitHub::)

  * Nuget CLI (**Recommended**):
    * **GIT-USERNAME**: Your GIT username that you log into GIT with.
    * **GIT-PERSONAL-ACCESS-TOKEN**: Your GIT Personal access token (see below reference on how to generate one)

    ```shell
    nuget sources add -Name "Azure" -Source "https://nuget.pkg.github.com/Azure/index.json" -username "**[GIT-USERNAME]**" -password "**[GIT-PERSONAL-ACCESS-TOKEN]**"
    ```

    * More details can be found here
      * [Nuget Source](https://docs.microsoft.com/nuget/reference/cli-reference/cli-ref-sources)
      * [How to Generate a GIT Personal Access Token](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token)
  * Visual Studio's Nuget Package Manager
    * You'll be prompted for credentials when accessing the source, so keep you Personal Access Token handy as this would be your password.

### Authenticate the Client

When Azure AD authentication events service calls your custom extension, it will send an `Authorization` header with a `Bearer {token}`. This token will represent a [service to service authentication](https://review.docs.microsoft.com/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow) in which:

* The '**resource**', also known as the **audience**, is the application that you register to represent your API. This is represented by the `aud` claim in the token.
* The '**client**' is a Microsoft application that represents the Azure AD authentication events service. It has an `appId` value of `99045fe1-7639-4a75-9d4a-577b6ca3810f`. This is represented by:
  * The `azp` claim in the token if your application `accessTokenAcceptedVersion` property is set to `2`.
  * The `appid` claim in the token if your resource application's `accessTokenAcceptedVersion` property is set to `1` or `null`.

There are three approaches to dealing with the token. You can customize the behavior using [application settings](https://docs.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings?tabs=portal#settings) as shown below or via the [local.settings.json](https://docs.microsoft.com/azure/azure-functions/functions-develop-local#local-settings-file) file in local environments.

#### Validate tokens using Azure Functions Azure AD authentication integration

When running your function in production, it is **highly recommended** to use the [Azure Functions Azure AD authentication integration](https://docs.microsoft.com/azure/app-service/configure-authentication-provider-aad#-option-2-use-an-existing-registration-created-separately) for validating incoming tokens.

1. Go to the "Authentication" tab in your Function App
2. Click on "Add identity provider"
3. Select "Microsoft" as the identity provider
4. Select "Provide the details of an existing app registration"
5. Enter the `Application ID` of the app that represents your API in Azure AD

The issuer and allowed audience depends on the [`accessTokenAcceptedVersion`](https://review.docs.microsoft.com/azure/active-directory/develop/access-tokens) property of your application (can be found in the "Manifest" of the application).

If the `accessTokenAcceptedVersion` property is set to `2`:
6. Set the `Issuer URL to "https://login.microsoftonline.com/{tenantId}/v2.0"
7. Set an 'Allowed Audience' to the Application ID (`appId`)

If the `accessTokenAcceptedVersion` property is set to `1` or `null`:
6. Set the `Issuer URL to "https://sts.windows.net/{tenantId}/"
7. Set an 'Allowed Audience' to the Application ID URI (also known as`identifierUri`). It should be in the format of`api://{azureFunctionAppName}.azurewebsites.net/{resourceApiAppId}` or `api://{FunctionAppFullyQualifiedDomainName}/{resourceApiAppId}` if using a [custom domain name](https://docs.microsoft.com/azure/dns/dns-custom-domain#:~:text=Azure%20Function%20App%201%20Navigate%20to%20Function%20App,Custom%20domain%20text%20field%20and%20select%20Validate.%20).

By default, the Authentication event trigger will validate that Azure Function authentication integration is configured and it will check that the **client** in the token is set to `99045fe1-7639-4a75-9d4a-577b6ca3810f` (via the `azp` or `appid` claims in the token).

If you want to test your API against some other client that is not Azure AD authentication events service, like using Postman, you can configure an _optional_ application setting:

* **AuthenticationEvents__CustomCallerAppId** - the guid of your desired client. If not provided, `99045fe1-7639-4a75-9d4a-577b6ca3810f` is assumed.

#### Have the trigger validate the token

In local environments or environments that aren't hosted in the Azure Function service, the trigger can do the token validation. Set the following application settings:

* **AuthenticationEvents__TenantId** - your tenant ID
* **AuthenticationEvents__AudienceAppId** - the same value as "Allowed audience" in option 1.
* **AuthenticationEvents__CustomCallerAppId** (_optional_) - the guid of your desired client. If not provided, `99045fe1-7639-4a75-9d4a-577b6ca3810f` is assumed.

An example `local.settings.json` file:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AuthenticationEvents__TenantId": "8615397b-****-****-****-********06c8",
    "AuthenticationEvents__AudienceAppId": "api://46f98993-****-****-****-********0038",
    "AuthenticationEvents__CustomCallerAppId": "46f98993-****-****-****-********0038"
  }
}
```

#### No token validation

If you would like to _not_ authenticate the token while in local development, set the following application setting:

* **AuthenticationEvents__BypassTokenValidation** - value of `true` will make the trigger not check for a validation of the token.

### Quickstart

* Visual Studio 2019
  * Start Visual Studio
  * Select "Create a new project"
  * In the template search area search and select "AzureAuthEventsTrigger"
  * Give your project a meaningful Project Name, Location, Solution and Solution Name.

* Visual Studio Code
  * Start Visual Studio Code
  * Run the command "Create Azure Authentication Events Trigger Project" via the command palette
  * Follow the project creation prompts
* Please note: that on a first time run it might take awhile to download the the required packages.
* For development purpose turn of token validation for testing:
* Add the **AuthenticationEvents__BypassTokenValidation** application key to the "Values" section in the local.settings.json file and set it's value to **true**.  If you do not have a local.settings.json file in your local environment, create one in the root of your Function App.

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AuthenticationEvents__BypassTokenValidation": true
  }
}
```

* Once the project is loaded, you can run the sample code and you should see the Azure functions developer's application load your end point.

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html)

## Documentation

* One the function has been published, there's some good reading about logging and metrics that can be found [here](https://docs.microsoft.com/azure/azure-functions/functions-monitor-log-analytics?tabs=csharp)

* For API Documentation, please see the (Link TBD)
* Once this moves to preview, we except no breaking changes and would be as simple as removing the the nuget source that points to the private preview.

## Examples

To Test Token Augmentation, please do the following.

* Start Visual Studio.
* Open the project that was created in the prior step. (QuickStart)
* Run the Application. (F5)
* Once the Azure functions developer's application has started, copy the listening url that is displayed with the application starts up.
* Note: All Authentication functions are listed, in the case we have one function listener registered called "**OnTokenIssuanceStart**"
* Your function endpoint will then be a combination of the listening url and function, for example: "http://localhost:7071/runtime/webhooks/AuthenticationEvents?code=(YOUR_CODE)&function=OnTokenIssuanceStart"
* Post the following payload using something like Postman or Fiddler.
* Steps for using Postman can be found (Link TBD)

```json
{
  "type":"microsoft.graph.authenticationEvent.TokenIssuanceStart",
  "source":"/tenants/{tenantId}/applications/{resourceAppId}",
  "data":{
    "@odata.type": "microsoft.graph.onTokenIssuanceStartCalloutData",
    "tenantId": "30000000-0000-0000-0000-000000000003",
    "authenticationEventListenerId1": "10000000-0000-0000-0000-000000000001",
    "customAuthenticationExtensionId": "10000000-0000-0000-0000-000000000002",
    "authenticationContext1":{
      "correlationId": "20000000-0000-0000-0000-000000000002",
      "client": {
        "ip": "127.0.0.1",
        "locale": "en-us",
        "market": "en-au"
      },
      "authenticationProtocol": "OAUTH2.0",
      "clientServicePrincipal": {
        "id": "40000000-0000-0000-0000-000000000001",
        "appId": "40000000-0000-0000-0000-000000000002",
        "appDisplayName": "Test client app",
        "displayName": "Test client application"
      },
      "resourceServicePrincipal": {
        "id": "40000000-0000-0000-0000-000000000003",
        "appId": "40000000-0000-0000-0000-000000000004",
        "appDisplayName": "Test resource app",
        "displayName": "Test resource application"
      },
      "user": {
        "companyName": "Nick Gomez",
        "country": "USA",
        "createdDateTime": "0001-01-01T00:00:00Z",
        "displayName": "Dummy display name",
        "givenName": "Example",
        "id": "60000000-0000-0000-0000-000000000006",
        "mail": "test@example.com",
        "onPremisesSamAccountName": "testadmin",
        "onPremisesSecurityIdentifier": "DummySID",
        "onPremisesUserPrincipalName": "Dummy Name",
        "preferredDataLocation": "DummyDataLocation",
        "preferredLanguage": "DummyLanguage",
        "surname": "Test",
        "userPrincipalName": "testadmin@example.com",
        "userType": "UserTypeCloudManaged"
      }
    }
  }
}
```

* You should see this response:

```json
{
    "data": {
        "@odata.type": "microsoft.graph.onTokenIssuanceStartResponseData",
        "actions": [
            {
                "@odata.type": "ProvideClaimsForToken",
                "claims": [
                    {
                        "DateOfBirth": "01/01/2000"
                    },
                    {
                        "CustomRoles": [
                            "Writer",
                            "Editor"
                        ]
                    }
                ]
            }
        ]
    }
}
```

## Troubleshooting

* Visual Studio Code
  * If running in Visual Studio Code, you get an error along the lines of the local Azure Storage Emulator is unavailable, you can start the emulator manually.! (Note: Azure Storage emulator is now deprecated and the suggested replacement is [Azurite](https://docs.microsoft.com/azure/storage/common/storage-use-azurite?tabs=visual-studio))
  * If using Visual Studio Code on Mac please use [Azurite](https://docs.microsoft.com/azure/storage/common/storage-use-azurite?tabs=visual-studio)
  * If you see the following error on Windows (it's a bug) when trying to run the created projected.
  * This can be resolved by executing this command in powershell `Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope LocalMachine` more info on this can be found [here](https://github.com/Azure/azure-functions-core-tools/issues/1821) and [here](https://docs.microsoft.com/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7)

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)

## Publish

* Follow the instruction here to create and publish your Azure Application. <https://docs.microsoft.com/azure/azure-functions/functions-develop-vs?tabs=in-process#publish-to-azure>
* To determine your published posting endpoint, combine the azure function endpoint you created, route to the listener and listener code, the listen code can be found by navigating to your azure function application, selecting "App Keys" and copying the value of AuthenticationEvents_extension.
* For example: "https://azureautheventstriggerdemo.azurewebsites.net/runtime/webhooks/AuthenticationEvents?code=(AuthenticationEvents_extension_key)&function=OnTokenIssuanceStart"
* Make sure your production environment has the correct application settings for token authentication.
* Once again you can test the published function by posting the above payload to the new endpoint.

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