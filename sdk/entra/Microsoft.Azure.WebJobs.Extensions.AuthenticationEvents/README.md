# Authentication events trigger for Azure Functions client library for .NET

The authentication events trigger for Azure Functions allows you to implement a custom extension to handle Microsoft Entra authentication events. The authentication events trigger handles all the backend processing for incoming HTTP requests for Microsoft Entra authentication events and provides the developer with:

- Token validation for securing the API call
- Object model, typing, and IDE intellisense
- Inbound and outbound validation of the API request and response schemas

## Getting started

You can follow this article to start creating your function: [Create a REST API for a token issuance start event in Azure Functions](https://learn.microsoft.com/entra/identity-platform/custom-extension-tokenissuancestart-setup?tabs=visual-studio%2Cazure-portal&pivots=nuget-library)

### Prerequisites

- A basic understanding of the concepts covered in [Custom authentication extensions overview](https://learn.microsoft.com/en-us/entra/identity-platform/custom-extension-overview).
- An Azure subscription with the ability to create Azure Functions. If you don't have an existing Azure account, sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).
- A Microsoft Entra ID tenant. You can use either a customer or workforce tenant for this how-to guide.
- One of the following IDEs and configurations:
    - Visual Studio with [Azure Development workload for Visual Studio](https://learn.microsoft.com/en-us/dotnet/azure/configure-visual-studio) configured.
    - Visual Studio Code, with the [Azure Functions](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions) extension enabled.

## Create and build the Azure Function app

In this step, you create an HTTP trigger function API using your IDE, install the required NuGet packages and copy in the sample code. You build the project and run the function to extract the local function URL.

### Create the application

To create an Azure Function app, follow these steps:

### [Visual Studio](#tab/visual-studio)

1. Open Visual Studio, and select **Create a new project**.
2. Search for and select **Azure Functions**, then select **Next**.
3. Give the project a name, such as *AuthEventsTrigger*. It's a good idea to match the solution name with the project name.
4. Select a location for the project. Select **Next**.
5. Select **.NET 6.0 (Long Term Support)** as the target framework. 
6. Select *Http trigger* as the **Function** type, and that **Authorization level** is set to *Function*. Select **Create**.
7. In the **Solution Explorer**, rename the *Function1.cs* file to *AuthEventsTrigger.cs*, and accept the rename change suggestion.

### [Visual Studio Code](#tab/visual-studio-code)

1. Open Visual Studio Code.
2. Select the **New Folder** icon in the **Explorer** window, and create a new folder for your project, for example *AuthEventsTrigger*.
3. Select the Azure extension icon on the left-hand side of the screen. Sign in to your Azure account if you haven't already. 
4. Under the **Workspace** bar, select the **Azure Functions** icon > **Create New Project**.
5. In the top bar, select the location to create the project.
6. Select **C#** as the language, and **.NET 6.0 LTS** as the .NET runtime. 
7. Select **HTTP trigger** as the template.
8. Provide a name for the project, such as *AuthEventsTrigger*.
9. Accept **Company.Function** as the namespace, with **AccessRights** set to *Function*. 

---

### Install NuGet packages and build the project (Install the package)

After creating the project, you'll need to install the required NuGet packages and build the project.

### [Visual Studio](#tab/visual-studio)

1. In the top menu of Visual Studio, select **Project**, then **Manage NuGet packages**.
2. Select the **Browse** tab, then search for and select *Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents* in the right pane. Select **Install**.
3. Apply and accept the changes in the popups that appear.

### [Visual Studio Code](#tab/visual-studio-code)

1. Open the **Terminal** in Visual Studio Code, and navigate to the project folder.
2. Enter the following command into the console to install the *Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents* NuGet package.

```console
dotnet add package Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
```

---

### Add the sample code

The function API is the source of extra claims for your token. For the purposes of this article, we're hardcoding the values for the sample app. In production, you can fetch information about the user from external data store.

In your *AuthEventsTrigger.cs* file, replace the entire contents of the file with the following code:

```cs
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;

namespace AuthEventsTrigger
{
    public static class AuthEventsTrigger
    {
        [FunctionName("onTokenIssuanceStart")]
        public static WebJobsAuthenticationEventResponse Run(
            [WebJobsAuthenticationEventsTrigger] WebJobsTokenIssuanceStartRequest request, ILogger log)
        {
            try
            {
                // Checks if the request is successful and did the token validation pass
                if (request.RequestStatus == WebJobsAuthenticationEventsRequestStatusType.Successful)
                {
                    // Fetches information about the user from external data store
                    // Add new claims to the token's response
                    request.Response.Actions.Add(
                        new WebJobsProvideClaimsForToken(
                            new WebJobsAuthenticationEventsTokenClaim("dateOfBirth", "01/01/2000"),
                            new WebJobsAuthenticationEventsTokenClaim("customRoles", "Writer", "Editor"),
                            new WebJobsAuthenticationEventsTokenClaim("apiVersion", "1.0.0"),
                            new WebJobsAuthenticationEventsTokenClaim(
                                "correlationId", 
                                request.Data.AuthenticationContext.CorrelationId.ToString())));
                }
                else
                {
                    // If the request fails, such as in token validation, output the failed request status, 
                    // such as in token validation or response validation.
                    log.LogInformation(request.StatusMessage);
                }
                return request.Completed();
            }
            catch (Exception ex) 
            { 
                return request.Failed(ex);
            }
        }
    }
}
```

### Build and run the project locally

The project has been created, and the sample code has been added. Using your IDE, we need to build and run the project locally to extract the local function URL.

### [Visual Studio](#tab/visual-studio)

1. Navigate to **Build** in the top menu, and select **Build Solution**.
2. Press **F5** or select *AuthEventsTrigger* from the top menu to run the function. 
3. Copy the **Function url** from the terminal that popups up when running the function. This can be used when setting up a custom authentication extension.

### [Visual Studio Code](#tab/visual-studio-code)

1. In the top menu, select **Run** > **Start Debugging** or press **F5** to run the function.
2. In the terminal, copy the **Function url** that appears. This can be used when setting up a custom authentication extension.

---

## Run the function locally (recommended)

It's a good idea to test the function locally before deploying it to Azure. We can use a dummy JSON body that imitates the request that Microsoft Entra ID sends to your REST API. Use your preferred API testing tool to call the function directly.

1. In your IDE, open *local.settings.json* and replace the code with the following JSON. We can set `"AuthenticationEvents__BypassTokenValidation"` to `true` for local testing purposes.

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

2. Using your preferred API testing tool, create a new HTTP request and set the **HTTP method** to `POST`.
3. Use the following JSON body that imitates the request Microsoft Entra ID sends to your REST API.

```json
{
    "type": "microsoft.graph.authenticationEvent.tokenIssuanceStart",
    "source": "/tenants/aaaabbbb-0000-cccc-1111-dddd2222eeee/applications/00001111-aaaa-2222-bbbb-3333cccc4444",
    "data": {
        "@odata.type": "microsoft.graph.onTokenIssuanceStartCalloutData",
        "tenantId": "aaaabbbb-0000-cccc-1111-dddd2222eeee",
        "authenticationEventListenerId": "11112222-bbbb-3333-cccc-4444dddd5555",
        "customAuthenticationExtensionId": "22223333-cccc-4444-dddd-5555eeee6666",
        "authenticationContext": {
            "correlationId": "aaaa0000-bb11-2222-33cc-444444dddddd",
            "client": {
                "ip": "127.0.0.1",
                "locale": "en-us",
                "market": "en-us"
            },
            "protocol": "OAUTH2.0",
            "clientServicePrincipal": {
                "id": "aaaaaaaa-0000-1111-2222-bbbbbbbbbbbb",
                "appId": "00001111-aaaa-2222-bbbb-3333cccc4444",
                "appDisplayName": "My Test application",
                "displayName": "My Test application"
            },
            "resourceServicePrincipal": {
                "id": "aaaaaaaa-0000-1111-2222-bbbbbbbbbbbb",
                "appId": "00001111-aaaa-2222-bbbb-3333cccc4444",
                "appDisplayName": "My Test application",
                "displayName": "My Test application"
            },
            "user": {
                "companyName": "Casey Jensen",
                "createdDateTime": "2023-08-16T00:00:00Z",
                "displayName": "Casey Jensen",
                "givenName": "Casey",
                "id": "00aa00aa-bb11-cc22-dd33-44ee44ee44ee",
                "mail": "casey@contoso.com",
                "onPremisesSamAccountName": "Casey Jensen",
                "onPremisesSecurityIdentifier": "<Enter Security Identifier>",
                "onPremisesUserPrincipalName": "Casey Jensen",
                "preferredLanguage": "en-us",
                "surname": "Jensen",
                "userPrincipalName": "casey@contoso.com",
                "userType": "Member"
            }
        }
    }
}
```

4. Select **Send**, and you should receive a JSON response similar to the following:

```json
{
    "data": {
        "@odata.type": "microsoft.graph.onTokenIssuanceStartResponseData",
        "actions": [
            {
                "@odata.type": "microsoft.graph.tokenIssuanceStart.provideClaimsForToken",
                "claims": {
                    "customClaim1": "customClaimValue1",
                    "customClaim2": [
                        "customClaimString1",
                        "customClaimString2" 
                    ]
                }
            }
        ]
    }
}
```

## Deploy the function and publish to Azure 

The function needs to be deployed to Azure using our IDE. Check that you're correctly signed in to your Azure account so the function can be published.

### [Visual Studio](#tab/visual-studio)

1. In the Solution Explorer, right-click on the project and select **Publish**. 
1. In **Target**, select **Azure**, then select **Next**.
1. Select **Azure Function App (Windows)** for the **Specific Target**, select **Azure Function App (Windows)**, then select **Next**.
1. In the **Function instance**, use the **Subscription name** dropdown to select the subscription under which the new function app will be created in.
1. Select where you want to publish the new function app, and select **Create New**.
1. On the **Function App (Windows)** page, use the function app settings as specified in the following table, then select **Create**.
 
    |   Setting    | Suggested value  | Description |
    | ------------ | ---------------- | ----------- |
    | **Name** | Globally unique name | A name that identifies the new function app. Valid characters are `a-z` (case insensitive), `0-9`, and `-`. |
    | **Subscription** | Your subscription | The subscription under which the new function app is created. |
    | **[Resource Group](https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/overview)** |  *myResourceGroup* | Select an existing resource group, or name the new one in which you'll create your function app. |
    | **Plan type** | Consumption (Serverless) | Hosting plan that defines how resources are allocated to your function app.  |
    | **Location** | Preferred region | Select a [region](https://azure.microsoft.com/regions/) that's near you or near other services that your functions can access. |
    | **Azure Storage** | Your storage account | An Azure storage account is required by the Functions runtime. Select New to configure a general-purpose storage account. |
    | **Application Insights** | *Default* | A feature of Azure Monitor. This is autoselected, select the one you wish to use or configure a new one. |
    

2. Wait a few moments for your function app to be deployed. Once the window closes, select **Finish**.
3. A new **Publish** pane opens. At the top, select **Publish**. Wait a few minutes for your function app to be deployed and show up in the Azure portal.

### [Visual Studio Code](#tab/visual-studio-code)

1. Select the **Azure** extension icon. In **Resources**, select the **+** icon to **Create a resource**.
1. Select **Create Function App in Azure**. Use the following settings for setting up your function app.
1. Give the function app a name, such as *AuthEventsTriggerNuGet*, and press **Enter**.
1. Select the **.NET 6 (LTS) In-Process** runtime stack. 
1. Select a location for the function app, such as *East US*.
1. Wait a few minutes for your function app to be deployed and show up in the Azure portal.

---

## Configure authentication for your Azure Function (Authenticate the client)

There are three ways to set up authentication for your Azure Function: 

- [Set up authentication in the Azure portal using environment variables](#set-up-authentication-in-the-azure-portal-using-environment-variables) (recommended)
- [Set up authentication in your code using `WebJobsAuthenticationEventsTriggerAttribute`](#set-up-authentication-in-your-code-using-webjobsauthenticationeventstriggerattribute)
- [Azure App service authentication and authorization](https://learn.microsoft.com/en-us/azure/app-service/configure-authentication-provider-aad?tabs=workforce-tenant)

By default, the code has been set up for authentication in the Azure portal using environment variables. Use the tabs below to select your preferred method of implementing environment variables, or alternatively, refer to the built-in [Azure App service authentication and authorization](https://learn.microsoft.com/en-us/azure/app-service/overview-authentication-authorization). For setting up environment variables, use the following values:

   | Name | Value |
   | ---- | ----- | 
   | *AuthenticationEvents__AudienceAppId* | *Custom authentication extension app ID* which is set up in [Configure a custom claim provider for a token issuance event](https://learn.microsoft.com/en-us/entra/identity-platform/custom-extension-tokenissuancestart-configuration) |
   | *AuthenticationEvents__AuthorityUrl* | &#8226; Workforce tenant `https://login.microsoftonline.com/<tenantID>` <br> &#8226; External tenant `https://<mydomain>.ciamlogin.com/<tenantID>` | 
   | *AuthenticationEvents__AuthorizedPartyAppId* | `99045fe1-7639-4a75-9d4a-577b6ca3810f` or another authorized party | 

### [Set up authentication in Azure portal](#tab/azure-portal)

### Set up authentication in the Azure portal using environment variables

1. Sign in to the [Azure portal](https://portal.azure.com) as at least an [Application Administrator](https://learn.microsoft.com/en-us/entra/identity/role-based-access-control/permissions-reference#application-developer) or [Authentication Administrator](https://learn.microsoft.com/en-us/entra/identity/role-based-access-control/permissions-reference#authentication-administrator).
2. Navigate to the function app you created, and under **Settings**, select **Configuration**.
3. Under **Application settings**, select **New application setting** and add the environment variables from the table and their associated values.  
4. Select **Save** to save the application settings.

### [Set up authentication in your code](#tab/nuget-library)

### Set up authentication in your code using `WebJobsAuthenticationEventsTriggerAttribute`

1. Open the *AuthEventsTrigger.cs* file in your IDE.
1. Modify the `WebJobsAuthenticationEventsTriggerAttribute` include the `AuthorityUrl`, `AudienceAppId` and `AuthorizedPartyAppId` properties, as shown in the below snippet.

```cs
    [FunctionName("onTokenIssuanceStart")]
    public static WebJobsAuthenticationEventResponse Run(
        [WebJobsAuthenticationEventsTriggerAttribute(
            AudienceAppId = "Enter custom authentication extension app ID here",
            AuthorityUrl = "Enter authority URI here", 
            AuthorizedPartyAppId = "Enter the Authorized Party App Id here")]WebJobsTokenIssuanceStartRequest request, ILogger log)
```

---

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
