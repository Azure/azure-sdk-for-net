# Authentication events trigger for Azure Functions client library for .NET

The authentication events trigger for Azure Functions allows you to implement a custom extension to handle Microsoft Entra authentication events. The authentication events trigger handles all the backend processing for incoming HTTP requests for Microsoft Entra authentication events and provides the developer with:

- Token validation for securing the API call
- Object model, typing, and IDE intellisense
- Inbound and outbound validation of the API request and response schemas

## Getting started

You can follow this article to start creating your function: [Create a REST API for a token issuance start event in Azure Functions](https://learn.microsoft.com/entra/identity-platform/custom-extension-tokenissuancestart-setup?tabs=visual-studio%2Cazure-portal&pivots=nuget-library)

### Install the package

Install the Authentication Event extension with [NuGet](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents):

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
```

---

### Prerequisites

- A basic understanding of the concepts covered in [Custom authentication extensions overview](https://learn.microsoft.com/entra/identity-platform/custom-extension-overview).
- An Azure subscription with the ability to create Azure Functions. If you don't have an existing Azure account, sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).
- A Microsoft Entra ID tenant. You can use either a customer or workforce tenant for this how-to guide.
- One of the following IDEs and configurations:
    - Visual Studio with [Azure Development workload for Visual Studio](https://learn.microsoft.com/dotnet/azure/configure-visual-studio) configured.
    - Visual Studio Code, with the [Azure Functions](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions) extension enabled.

### Authenticate the client

There are three ways to set up authentication for your Azure Function:

- [Set up authentication in the Azure portal using environment variables](#set-up-authentication-in-the-azure-portal-using-environment-variables) (recommended)
- [Set up authentication in your code using `WebJobsAuthenticationEventsTriggerAttribute`](#set-up-authentication-in-your-code-using-webjobsauthenticationeventstriggerattribute)
- [Azure App service authentication and authorization](https://learn.microsoft.com/azure/app-service/configure-authentication-provider-aad?tabs=workforce-tenant)

By default, the code has been set up for authentication in the Azure portal using environment variables. Use the tabs below to select your preferred method of implementing environment variables, or alternatively, refer to the built-in [Azure App service authentication and authorization](https://learn.microsoft.com/azure/app-service/overview-authentication-authorization). For setting up environment variables, use the following values:

   | Name | Value |
   | ---- | ----- |
   | *AuthenticationEvents__AudienceAppId* | *Custom authentication extension app ID* which is set up in [Configure a custom claim provider for a token issuance event](https://learn.microsoft.com/entra/identity-platform/custom-extension-tokenissuancestart-configuration) |
   | *AuthenticationEvents__AuthorityUrl* | &#8226; Workforce tenant `https://login.microsoftonline.com/<tenantID>` <br> &#8226; External tenant `https://<mydomain>.ciamlogin.com/<tenantID>` |
   | *AuthenticationEvents__AuthorizedPartyAppId* | `99045fe1-7639-4a75-9d4a-577b6ca3810f` or another authorized party |


#### Set up authentication in the Azure portal using environment variables

1. Sign in to the [Azure portal](https://portal.azure.com) as at least an [Application Administrator](https://learn.microsoft.com/entra/identity/role-based-access-control/permissions-reference#application-developer) or [Authentication Administrator](https://learn.microsoft.com/entra/identity/role-based-access-control/permissions-reference#authentication-administrator).
2. Navigate to the function app you created, and under **Settings**, select **Configuration**.
3. Under **Application settings**, select **New application setting** and add the environment variables from the table and their associated values.
4. Select **Save** to save the application settings.

#### Set up authentication in your code using `WebJobsAuthenticationEventsTriggerAttribute`

1. Open your trigger class in your IDE.
2. Modify the `WebJobsAuthenticationEventsTriggerAttribute` include the `AuthorityUrl`, `AudienceAppId` and `AuthorizedPartyAppId` properties, as shown in the below snippet.

```C# Snippet:AuthEventsTriggerParameters
[FunctionName("onTokenIssuanceStart")]
public static WebJobsAuthenticationEventResponse Run(
[WebJobsAuthenticationEventsTriggerAttribute(
    AudienceAppId = "<custom_authentication_extension_app_id>",
    AuthorityUrl = "<authority_uri>", 
    AuthorizedPartyAppId = "<authorized_party_app_id>")] WebJobsTokenIssuanceStartRequest request, ILogger log)
```

## Key concepts

### .NET SDK

Key concepts of the Azure .NET SDK can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

### Microsoft Entra custom extensions

Custom extensions allow you to handle Microsoft Entra authentication events, integrate with external systems, and customize what happens in your application authentication experience. For example, a custom claims provider is a custom extension that allows you to enrich or customize application tokens with information from external systems that can't be stored as part of the Microsoft Entra directory.

### Authentication events trigger

The authentication events trigger allows a function to be executed when an authentication event is sent from the Microsoft Entra event service.

### Authentication events trigger output binding

The authentication events trigger output binding allows a function to send authentication event actions to the Microsoft Entra event service.


### Create and build the Azure Function app

The first step is to create an HTTP trigger function API using your IDE, install the required NuGet packages and copy in the sample code (found below). You can build the project and run the function to extract the local function URL.

## Examples

The function API is the source of extra claims for your token. For the purposes of this article, we're hardcoding the values for the sample app. In production, you can fetch information about the user from external data store.

In your trigger class (i.e: _AuthEventsTrigger.cs_), add the contents of the following snippet in your main function body:

```C# Snippet:AuthEventsTriggerExample
[FunctionName("onTokenIssuanceStart")]
public static WebJobsAuthenticationEventResponse Run(
[WebJobsAuthenticationEventsTriggerAttribute(
    AudienceAppId = "<custom_authentication_extension_app_id>",
    AuthorityUrl = "<authority_uri>", 
    AuthorizedPartyAppId = "<authorized_party_app_id>")] WebJobsTokenIssuanceStartRequest request, ILogger log)
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
```

### Build and run the project locally

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
    "source": "/tenants/30000000-0000-0000-0000-000000000003/applications/40000000-0000-0000-0000-000000000002",
    "data": {
        "@odata.type": "microsoft.graph.onTokenIssuanceStartCalloutData",
        "tenantId": "30000000-0000-0000-0000-000000000003",
        "authenticationEventListenerId": "10000000-0000-0000-0000-000000000001",
        "customAuthenticationExtensionId": "10000000-0000-0000-0000-000000000002",
        "authenticationContext": {
            "correlationId": "20000000-0000-0000-0000-000000000002",
            "client": {
                "ip": "127.0.0.1",
                "locale": "en-us",
                "market": "en-us"
            },
            "protocol": "OAUTH2.0",
            "clientServicePrincipal": {
                "id": "40000000-0000-0000-0000-000000000001",
                "appId": "40000000-0000-0000-0000-000000000002",
                "appDisplayName": "My Test application",
                "displayName": "My Test application"
            },
            "resourceServicePrincipal": {
                "id": "40000000-0000-0000-0000-000000000003",
                "appId": "40000000-0000-0000-0000-000000000004",
                "appDisplayName": "My Test application",
                "displayName": "My Test application"
            },
            "user": {
                "companyName": "Casey Jensen",
                "createdDateTime": "2023-08-16T00:00:00Z",
                "displayName": "Casey Jensen",
                "givenName": "Casey",
                "id": "60000000-0000-0000-0000-000000000006",
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

### Deploy the function and publish to Azure

Once it has been tested and working, deploy the function to Azure.

## Troubleshooting

### Visual Studio Code
  * If running in Visual Studio Code, you get an error along the lines of the local Azure Storage Emulator is unavailable, you can start the emulator manually. (Note: Azure Storage emulator is now deprecated and the suggested replacement is [Azurite](https://learn.microsoft.com/azure/storage/common/storage-use-azurite?tabs=visual-studio))
  * If using Visual Studio Code on Mac please use [Azurite](https://learn.microsoft.com/azure/storage/common/storage-use-azurite?tabs=visual-studio)

### Azure function endpoint

* To determine your published posting endpoint, combine the Azure function endpoint you created, route to the listener and listener code, the listen code can be found by navigating to your Azure function application, selecting "App Keys" and copying the value of AuthenticationEvents_extension.
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

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
