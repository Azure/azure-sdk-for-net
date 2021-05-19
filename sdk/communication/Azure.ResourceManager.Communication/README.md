# Azure Communication Services management client library for .NET

Azure Communication Services enable developers to securely bring human connected experiences to their own
applications and websites. This includes voice, video, calling and chat capabilities.

Use the management library for Azure Communication Services to:

- Create or update a resource
- Get the keys for that resource
- Delete a resource

## Getting started

### Prerequisites

- An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/dotnet/).
- The latest version [.NET Core client library](https://dotnet.microsoft.com/download/dotnet-core) for your operating system.
- Get the latest version of the [.NET Identity client library](https://docs.microsoft.com/dotnet/api/azure.identity?view=azure-dotnet).

### Install the package

Install the Azure Management SDK for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.ResourceManager.Communication --version 1.0.0-beta.3
``` 

### Include the client library

Include the Communication Services Management client library in your C# project:

```csharp
using Azure.ResourceManager.Communication;
```

### Subscription ID

You'll need to know the ID of your Azure subscription. This can be acquired from the portal:

1.  Login into your Azure account
2.  Select Subscriptions in the left sidebar
3.  Select whichever subscription is needed
4.  Click on Overview
5.  Select your Subscription ID

For the purposes of the samples, we will assume that you have stored the subscription ID in an environment
variable called `AZURE_SUBSCRIPTION_ID`.

### Resource Group

You will need to have a resource group to put your Azure Communication Services resource in. If you do not already have a resource
group, create one by using the [Azure
portal](https://docs.microsoft.com/azure/azure-resource-manager/management/manage-resource-groups-portal)
or the [ARM Management
SDK](https://github.com/Azure/azure-sdk-for-net/blob/master/doc/mgmt_preview_quickstart.md).

### Authenticate the client

In order to call Azure Communication Services, you must first authenticate yourself to Azure. Most commonly,
you will do this using a service principal identity, although it's also possible to authenticate using an
interactive user's identity.

#### **Option 1: Managed Identity**

If your code is running as a service in Azure, the easiest way to authenticate is to acquire a managed identity from Azure. Learn more about [managed identities](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/overview).

[Azure services that support Managed Identities](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities)

[How to use managed identities for App Service and Azure Functions](https://docs.microsoft.com/azure/app-service/overview-managed-identity?tabs=dotnet)

##### [System-assigned Managed Identity](https://docs.microsoft.com/azure/app-service/overview-managed-identity?tabs=dotnet#add-a-system-assigned-identity)

```csharp
using Azure.Identity;
using Azure.ResourceManager.Communication;
using Azure.ResourceManager.Communication.Models;
using System;
...
var subscriptionId = "AZURE_SUBSCRIPTION_ID";
var communicationServiceClient = new CommunicationManagementClient(subscriptionId, new ManagedIdentityCredential());
```

##### [User-assigned Managed Identity](https://docs.microsoft.com/azure/app-service/overview-managed-identity?tabs=dotnet#add-a-user-assigned-identity)

ClientId of the managed identity that you created must be passed to the `ManagedIdentityCredential` explicitly.

```csharp
using Azure.Identity;
using Azure.ResourceManager.Communication;
using Azure.ResourceManager.Communication.Models;
using System;
...
var subscriptionId = "AZURE_SUBSCRIPTION_ID";
var managedIdentityCredential = new ManagedIdentityCredential("AZURE_CLIENT_ID");
var communicationServiceClient = new CommunicationManagementClient(subscriptionId, managedIdentityCredential);
```

#### **Option 2: Service Principal**

Instead of using a managed identity, you may want to authenticate to Azure using a service principal that you manage yourself. Learn more using documentation on [creating and managing a service principal in Azure Active Directory](https://docs.microsoft.com/azure/active-directory/develop/howto-create-service-principal-portal).

After you've created your service principal, you'll need to collect the following information about it from the Azure portal:

- **Client ID**
- **Client Secret**
- **Tenant ID**

Store these values in environment variables named `AZURE_CLIENT_ID`, `AZURE_CLIENT_SECRET`, and `AZURE_TENANT_ID` respectively. You can then create a Communication Services management client like this:

```csharp
using Azure.Identity;
using Azure.ResourceManager.Communication;
using Azure.ResourceManager.Communication.Models;
using System;
...
var subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
var communicationServiceClient = new CommunicationManagementClient(subscriptionId, new EnvironmentCredential());
```

#### **Option 3: User Identity**

If you want to call Azure on behalf of an interactive user, rather than using a service identity, you can use the following code to create an Azure Communication Services Management client. This will open a browser window to prompt the user for their MSA or AAD credentials.

```csharp
using Azure.Identity;
using Azure.ResourceManager.Communication;
using Azure.ResourceManager.Communication.Models;
using System;
...
var subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID");
var communicationServiceClient = new CommunicationManagementClient(subscriptionId, new InteractiveBrowserCredential());
```

## Key concepts

`CommunicationManagementClient` is the root class which the authorization and configuration options will be
given to. You should design your application to only have a single instance of this class. From this class you
will gain a `CommunicationServiceOperations` instance to call on.

`CommunicationServiceOperations` contains the operational functions to create, read, update and delete a Azure Communication Services
instance.

## Examples

### Create and manage a Communication Services resource

Your instance of the Communication Services Management client library client (``Azure.ResourceManager.Communication.CommunicationManagementClient``) can be used to perform operations on Communication Services resources.

#### Create a Communication Services resource

When creating a Communication Services resource, you'll specify the resource group name and resource name. Note that the `Location` property will always be `global`, and during public preview the `DataLocation` value must be `UnitedStates`.

```csharp
var resourceGroupName = "myResourceGroupName";
var resourceName = "myResource";
var resource = new CommunicationServiceResource { Location = "Global", DataLocation = "UnitedStates"  };
var operation = await communicationServiceClient.CommunicationService.StartCreateOrUpdateAsync(resourceGroupName, resourceName, resource);
await operation.WaitForCompletionAsync();
```

#### Update a Communication Services resource

```csharp
...
var resourceGroupName = "myResourceGroupName";
var resourceName = "myResource";
var resource = new CommunicationServiceResource { Location = "Global", DataLocation = "UnitedStates" };
resource.Tags.Add("environment","test");
resource.Tags.Add("department","tech");
// Use existing resource name and new resource object
var operation = await communicationServiceClient.CommunicationService.StartCreateOrUpdateAsync(resourceGroupName, resourceName, resource);
await operation.WaitForCompletionAsync();
```

#### List all Communication Services resources

```csharp
var resources = communicationServiceClient.CommunicationService.ListBySubscription();
foreach (var resource in resources)
{
    Console.WriteLine(resource.Name);
}
```

#### Delete a Communication Services resource

```csharp
var resourceGroupName = "myResourceGroupName";
var resourceName = "myResource";
await communicationServiceClient.CommunicationService.StartDeleteAsync(resourceGroupName, resourceName);
```

### Managing keys and connection strings

Every Communication Services resource has a pair of access keys and corresponding connection strings. These keys can be accessed with the Management client library and then used by other Communication Services client libraries to authenticate themselves to Azure Communication Services.

#### Get access keys for a Communication Services resource

```csharp
var resourceGroupName = "myResourceGroupName";
var resourceName = "myResource";
var keys = await communicationServiceClient.CommunicationService.ListKeysAsync(resourceGroupName, resourceName);

Console.WriteLine(keys.Value.PrimaryConnectionString);
Console.WriteLine(keys.Value.SecondaryConnectionString);
```

#### Regenerate an access key for a Communication Services resource

```csharp
var resourceGroupName = "myResourceGroupName";
var resourceName = "myResource";
var keyParams = new RegenerateKeyParameters { KeyType = KeyType.Primary };
var keys = await communicationServiceClient.CommunicationService.RegenerateKeyAsync(resourceGroupName, resourceName, keyParams);

Console.WriteLine(keys.Value.PrimaryKey);
```

## Troubleshooting

### Environment variables are not fully configured

If calls on your `CommunicationManagementClient` created using a `EnvironmentCredential` throw an exception of:

```
EnvironmentCredential authentication unavailable. Environment variables are not fully configured.
```

Make sure these values exist in the environment the application is running. This can be done by using the
`ClientSecretCredential`:

```csharp
var clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
var clientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");
var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");

var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
return new CommunicationManagementClient(subscriptionId, credential);
```

### 404 for non-allow listed subscription

If calls on a `CommunicationManagementClient` result in an exception:

```
Service request failed.
Status: 404 (Not Found)

Content:
{"error":{"code":"InvalidResourceType","message":"The resource type could not be found in the namespace 'Microsoft.Communication' for api version '2019-10-10-preview'."}}

Headers:
Cache-Control: no-cache
Pragma: no-cache
x-ms-failure-cause: REDACTED
x-ms-request-id: REDACTED
x-ms-correlation-request-id: REDACTED
x-ms-routing-request-id: REDACTED
Strict-Transport-Security: REDACTED
X-Content-Type-Options: REDACTED
Date: Wed, 05 Aug 2020 20:14:30 GMT
Content-Type: application/json; charset=utf-8
Expires: -1
Content-Length: 170
```

This is due to the Azure Subscription used not being allow listed for Private Preview.

## Next steps

<!--TODO-->

<!--* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.-->
<!--* If appropriate, point users to other packages that might be useful.-->
<!--* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.-->

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://worldready.cloudapp.net/Styleguide/Read?id=2696&topicid=25357
[nuget]: https://www.nuget.org/

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)
