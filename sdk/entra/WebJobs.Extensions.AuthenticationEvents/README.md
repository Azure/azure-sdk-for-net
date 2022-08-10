[![.NET](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/actions/workflows/codeql-analysis.yml)

# Authentication Events Trigger for Azure Functions

Authentication Event Trigger for Azure Functions handles all the backend processing, (e.g. token/json schema validation) for incoming Http requests for Authentication events. And provides the developer with a strongly typed, versioned object model to work with, meaning the developer need not have any prior knowledge of the request and response json payloads.


## Features

This project framework provides the following features:

* Token validation for securing the API call 
* Object model, typing, and IDE intellisense
* Inbound and outbound validation of the API request and response schemas
* Versioning
* No need for boilerplate code.

## Getting Started

### Prerequisites
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) for Windows **OR** [Visual Studio Code >= 1.61](https://code.visualstudio.com/download)
- [Dotnet core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
- [Azure function tools 3.30](https://github.com/Azure/azure-functions-core-tools)
- [Nuget](https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools)
- [Azure Function Core Tools](https://github.com/Azure/azure-functions-core-tools#installing)
- If using Visual Studio Code the following extensions:
  - [ms-azuretools.vscode-azurefunctions](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions)
  - [ms-dotnettools.csharp](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- For private preview register a Nuget source either using Nugets cli **OR** Visual Studio's Nuget Package Manager. 
  - Generate a GIT Personal Access Token. Go to [https://github.com/settings/tokens](https://github.com/settings/tokens)
    - When generating the token, it needs to have the following permissions/scope: **read:package**
![PAT.png](markdown/PAT.png)x
    - Authorise **Azure** to use the Personal Access Token. (::Only if you are a member of the Azure Organisation on GitHub::)
![PAT2.png](markdown/PAT2.png)

    
  - Nuget CLI (**Recommended**):
    - **GIT-USERNAME**: Your GIT username that you log into GIT with.
    - **GIT-PERSONAL-ACCESS-TOKEN**: Your GIT Personal access token (see below reference on how to generate one)
    ```
    nuget sources add -Name "Azure" -Source "https://nuget.pkg.github.com/Azure/index.json" -username "**[GIT-USERNAME]**" -password "**[GIT-PERSONAL-ACCESS-TOKEN]**"
    ```
    - More details can be found here
      - [Nuget Source](https://docs.microsoft.com/en-us/nuget/reference/cli-reference/cli-ref-sources)
      - [How to Generate a GIT Personal Access Token](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token)
  - Visual Studio's Nuget Package Manager
    - You'll be prompted for credentials when accessing the source, so keep you Personal Access Token handy as this would be your password. 
![vs-pack-manager.png](markdown/vs-pack-manager.png)
  

### Installation

- Visual Studio 2019 Install (**Recommended**)
  - Install the latest **WebJobs.Extensions.AuthenticationEvents.vsix** release Visual Studio plug-in under the release section of this repo. Which can be found [**here**](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/releases/latest) (under "Assets")
  
- Visual Studio Code
  - Install the latest **WebJobs.Extensions.AuthenticationEvents.VSCode.vsix** release Visual Studio Code extension under the release section of this repo. Which can be found [**here**](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/releases/latest)
  - Install the extension by executing the following command in cmd.
  - `code --install-extension WebJobs.Extensions.AuthenticationEvents.VSCode.vsix`
  - **OR** via the UI
![code.png](markdown/code.png)

### Quickstart

- Visual Studio 2019
  - Start Visual Studio
  - Select "Create a new project"
  - In the template search area search and select "AzureAuthEventsTrigger"
  - Give your project a meaningful Project Name, Location, Solution and Solution Name.
  
- Visual Studio Code
  - Start Visual Studio Code
  - Run the command "Create Azure Authentication Events Trigger Project" via the command palette 
  - Follow the project creation prompts
- Please note: that on a first time run it might take awhile to download the the required packages.
- For development purpose turn of token validation for testing:
- Add the **AuthenticationEventTrigger__BypassTokenValidation** application key to the "Values" section in the local.settings.json file and set it's value to **true**.  If you do not have a local.settings.json file in your local environment, create one in the root of your Function App.
```
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AuthenticationEventTrigger__BypassTokenValidation": true
  }
}
```
- Once the project is loaded, you can run the sample code and you should see the Azure functions developer's application load your end point. 
![funct.png](markdown/funct.png)

### Authentication
When Azure AD authentication events service calls your custom extension, it will send an `Authorization` header with a `Bearer {token}`. This token will represent a [service to service authentication](/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow) in which:
- The '**resource**', also known as the **audience**, is the application that you register to represent your API. This is represented by the `aud` claim in the token. 
- The '**client**' is a Microsoft application that represents the Azure AD authentication events service. It has an `appId` value of `99045fe1-7639-4a75-9d4a-577b6ca3810f`. This is represented by:
  - The `azp` claim in the token if your application `accessTokenAcceptedVersion` property is set to `2`. 
  - The `appid` claim in the token if your resource application's `accessTokenAcceptedVersion` property is set to `1` or `null`. 

There are three approaches to dealing with the token. You can customize the behavior using [application settings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-how-to-use-azure-function-app-settings?tabs=portal#settings) as shown below or via the [local.settings.json](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-local#local-settings-file) file in local environments. 

![configure_app_setting_azure_function_portal.png](markdown/configure_app_setting_azure_function_portal.png)

#### Validate tokens using Azure Functions Azure AD authentication integration
When running your function in production, it is **highly recommended** to use the [Azure Functions Azure AD authentication integration](https://docs.microsoft.com/en-us/azure/app-service/configure-authentication-provider-aad#-option-2-use-an-existing-registration-created-separately) for validating incoming tokens. 

1. Go to the "Authentication" tab in your Function App
2. Click on "Add identity provider"
3. Select "Microsoft" as the identity provider
4. Select "Provide the details of an existing app registration"
5. Enter the `Application ID` of the app that represents your API in Azuure AD

The issuer and allowed audience depends on the [`accessTokenAcceptedVersion`](https://review.docs.microsoft.com/en-us/azure/active-directory/develop/access-tokens) property of your application (can be found in the "Manifest" of the application).

If the `accessTokenAcceptedVersion` property is set to `2`:
6. Set the `Issuer URL to "https://login.microsoftonline.com/{tenantId}/v2.0"
7. Set an 'Allowed Audience' to the the Application ID (`appId`)

If the `accessTokenAcceptedVersion` property is set to `1` or `null`:
6. Set the `Issuer URL to "https://sts.windows.net/{tenantId}/"
7. Set an 'Allowed Audience' to the the Application ID URI (also known as `identifierUri`). It should be in the format of `api://{azureFunctionAppName}.azurewebsites.net/{resourceApiAppId}` or `api://{FunctionAppFullyQualifiedDomainName}/{resourceApiAppId}` if using a [custom domain name](https://docs.microsoft.com/en-us/azure/dns/dns-custom-domain#:~:text=Azure%20Function%20App%201%20Navigate%20to%20Function%20App,Custom%20domain%20text%20field%20and%20select%20Validate.%20).

  - **App ID URI**
![TokenAppIDV1.png](markdown/TokenAppIDV1.png)
  - **App ID and Tenant ID**
![TokenAppIDV2.png](markdown/TokenAppIDV2.png)

By default, the Authentication event trigger will validate that Azure Function authentication integration is configured and it will check that the **client** in the token is set to `99045fe1-7639-4a75-9d4a-577b6ca3810f` (via the `azp` or `appid` claims in the token).

If you want to test your API against some other client that is not Azure AD authentication events service, like using Postman, you can configure an _optional_ application setting:
- **AuthenticationEventTrigger__CustomCallerAppId** - the guid of your desired client. If not provided, `99045fe1-7639-4a75-9d4a-577b6ca3810f` is assumed.

#### Have the trigger validate the token 
In local environments or environments that aren't hosted in the Azure Function service, the trigger can do the token validation. Set the following application settings:
  - **AuthenticationEventTrigger__TenantId** - your tenant ID
  - **AuthenticationEventTrigger__AudienceAppId** - the same value as "Allowed audience" in option 1.
  - **AuthenticationEventTrigger__CustomCallerAppId** (_optional_) - the guid of your desired client. If not provided, `99045fe1-7639-4a75-9d4a-577b6ca3810f` is assumed.

An example `local.settings.json` file:
```
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AuthenticationEventTrigger__TenantId": "8615397b-****-****-****-********06c8",
    "AuthenticationEventTrigger__AudienceAppId": "api://46f98993-****-****-****-********0038", 
    "AuthenticationEventTrigger__CustomCallerAppId": "46f98993-****-****-****-********0038"
  }
}
```

#### No token validation
If you would like to _not_ authenticate the token while in local development, set the following application setting:
- **AuthenticationEventTrigger__BypassTokenValidation** - value of `true` will make the trigger not check for a validation of the token.


## Demo

To Test Token Augmentation, please do the following. 

- Start Visual Studio.
- Open the project that was created in the prior step. (QuickStart)
- Run the Application. (F5)
- Once the Azure functions developer's application has started, copy the listening url that is displayed with the application starts up.
![url.png](markdown/url.png)
- Note: All Authentication functions are listed, in the case we have one function listener registered called "**OnTokenIssuanceStart**"
- Your function endpoint will then be a combination of the listening url and function, for example: http://localhost:7071/runtime/webhooks/customauthenticationextension?code=[YOUR_CODE]&function=OnTokenIssuanceStart
- Post the following payload using something like Postman or Fiddler.
- Steps for using Postman can be found [here](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/wiki/Using-Postman)
```
{
	"eventListenerId": "10000000-0000-0000-0000-000000000001",
	"time": "2021-05-17T00:00:00.0000000Z",
	"type": "onTokenIssuanceStartCustomExtension",
	"apiSchemaVersion": "10-01-2021-preview",
	"customExtensionId":"10000000-0000-0000-0000-000000000001",
	"context": {
		"correlationId": "20000000-0000-0000-0000-000000000002",
		"client": {
			"ip": "127.0.0.1"
		},
		"authProtocol": {
			"type": "OAUTH2.0",
			"tenantId": "30000000-0000-0000-0000-000000000003"
		},
		"clientServicePrincipal": {
			"id": "40000000-0000-0000-0000-000000000001",
			"appId": "40000000-0000-0000-0000-000000000002",
			"appDisplayName": "Test client app",
			"displayName": "Test client application",
			"servicePrincipalNames": [
				"40000000-0000-0000-0000-000000000002",
				"http://example.com/client/app1"
			]
		},
		"resourceServicePrincipal": {
			"id": "40000000-0000-0000-0000-000000000003",
			"appId": "40000000-0000-0000-0000-000000000004",
			"appDisplayName": "Test resourceapp",
			"displayName": "Test resourceapplication",
			"servicePrincipalNames": [
				"40000000-0000-0000-0000-000000000004",
				"https://example.com/resource2"
			]
		},
		"roles": [
			{
				"id": "50000000-0000-0000-0000-000000000005",
				"value": "DummyRole"
			}
		],
		"user": {
			"ageGroup": "Adult",
			"companyName": "Evo Sts Test",
			"country": "USA",
			"createdDateTime": "0001-01-01T00:00:00Z",
			"creationType": "Invitation",
			"department": "Dummy department",
			"displayName": "Dummy display name",
			"givenName": "Example",
			"id": "60000000-0000-0000-0000-000000000006",
			"lastPasswordChangeDateTime": "0001-01-01T00:00:00Z",
			"mail": "test@example.com",
			"onPremisesSamAccountName": "testadmin",
			"onPremisesSecurityIdentifier": "DummySID",
			"onPremiseUserPrincipalName": "Dummy Name",
			"preferredDataLocation": "DummyDataLocation",
			"preferredLanguage": "DummyLanguage",
			"surname": "Test",
			"userPrincipalName": "testadmin@example.com",
			"userType": "UserTypeCloudManaged"
		}
	}
}
```
- You should see this reponse:
```
{
	"type": "onTokenIssuanceStartCustomExtension",
	"apiSchemaVersion": "10-01-2021-preview",
	"actions": [
        {
            "type": "ProvideClaimsForToken",
            "claims": [
                {
                    "id": "DateOfBirth",
                    "value": "01/01/2000"
                },
                {
                    "id": "CustomRoles",
                    "value": [
                        "Writer",
                        "Editor"
                    ]
                }
            ]
        }
    ]
}
```


## Publish

- Follow the instruction here to create and publish your Azure Application. https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs?tabs=in-process#publish-to-azure
- To determine your published posting endpoint, combine the azure function endpoint you created, route to the listener and listener code, the listen code can be found by navigating to your azure function application, selecting "App Keys" and copying the value of customauthenticationextension_extension. 
![Portal.png](markdown/Portal.png)
- For example: https://azureautheventstriggerdemo.azurewebsites.net/runtime/webhooks/customauthenticationextension?code=[customauthenticationextension_extension_key]&function=OnTokenIssuanceStart
- Make sure your production environment has the correct application settings for token authentication.
- Once again you can test the published function by posting the above payload to the new endpoint.

## Trouble Shooting

- Visual Studio Code
  - If running in Visual Studio Code, you get an error along the lines of the local Azure Storage Emulator is unavailable, you can start the emulator manually.! (Note: Azure Storage emulator is now deprecated and the suggested replacement is [Azurite](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio))
  - If using Visual Studio Code on Mac please use [Azurite](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio)
![Emulator.png](markdown/Emulator.png)
  - If you see the following error on Windows (it's a bug) when trying to run the created projected.
![error1.png](markdown/error1.png)
  - This can be resolved by executing this command in powershell `Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope LocalMachine` more info on this can be found [here](https://github.com/Azure/azure-functions-core-tools/issues/1821) and [here](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7)


## Remarks
- One the function has been published, there's some good reading about logging and metrics that can be found [here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-monitor-log-analytics?tabs=csharp)
- For API Documentation, please see the [wiki](https://github.com/Azure/microsoft-azure-webJobs-extensions-authentication-events/wiki)
- Once this moves to preview, we except no breaking changes and would be as simple as removing the the nuget source that points to the private preview. 
