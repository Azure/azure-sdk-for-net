# Release History

## 1.0.0-preview.1

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

### Migration from Previous Version of Azure Management SDK

#### Package Name
The package name has been changed from `Microsoft.Azure.Management.ResourceManager` to `Azure.ResourceManager.Resources`

#### Management Client Changes

Example: Create one deployment with string template and parameters:

Before upgrade:
```csharp
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;

var tokenCredentials = new TokenCredentials("YOUR ACCESS TOKEN");
var resourceManagerManagementClient = new ResourceManagerManagementClient(tokenCredentials);
resourceManagerManagementClient.SubscriptionId = subscriptionId;

var parameters = new Deployment
{
    Properties = new DeploymentProperties()
    {
        Template = File.ReadAllText("storage-account.json")),
        Parameters = File.ReadAllText("account-parameters.json")),
        Mode = DeploymentMode.Incremental,
    }
};

resourceManagerManagementClient.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "westus" });
resourceManagerManagementClient.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);
```

storage-account.json
```json
{
  "$schema": "http://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "parameters": {
    "storageAccountName": {
      "type": "string"
    }
  },
  "resources": [
    {
      "type": "Microsoft.Storage/storageAccounts",
      "name": "[parameters('storageAccountName')]",
      "apiVersion": "2015-06-15",
      "location": "[resourceGroup().location]",
      "properties": {
        "accountType": "Standard_LRS"
      }
    }
  ],
  "outputs": {}
}
```

account-parameters.json
```json
{
  "$schema": "http://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#",
  "contentVersion": "1.0.0.0",
  "parameters": {
    "storageAccountName": {
      "value": "ramokaSATestAnother"
    }
  }
}
```

After upgrade:
```csharp
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

var resourcesManagementClient = new ResourcesManagementClient(subscriptionId, new DefaultAzureCredential());
var resourceGroupsClient = resourcesManagementClient.ResourceGroups;
var deploymentsClient = resourcesManagementClient.Deployments;

var templateString = File.ReadAllText("storage-account.json");
var parameterString = File.ReadAllText("account-parameters.json");
JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(parameterString);
if(!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
{
    parameter = jsonParameter;
}
var parameters = new Deployment
(
    new DeploymentProperties(DeploymentMode.Incremental)
    {
        Template = templateString,
        Parameters = parameter.ToString()
    }
);
await resourceGroupsClient.CreateOrUpdateAsync(groupName, new ResourceGroup("westus"));
var rawResult = await deploymentsClient.StartCreateOrUpdateAsync(groupName, deploymentName, parameters);
await rawResult.WaitForCompletionAsync();
```

#### Object Model Changes

Example: Create Deployment Model

Before upgrade:
```csharp
var parameters = new Deployment
{
    Properties = new DeploymentProperties()
    {
        Template = File.ReadAllText("storage-account.json")),
        Parameters = File.ReadAllText("account-parameters.json")),
        Mode = DeploymentMode.Incremental,
    }
};

```

After upgrade:
```csharp
var parameterString = File.ReadAllText("account-parameters.json");
JsonElement jsonParameter = JsonSerializer.Deserialize<JsonElement>(parameterString);
if(!jsonParameter.TryGetProperty("parameters", out JsonElement parameter))
{
    parameter = jsonParameter;
}
var parameters = new Deployment
(
    new DeploymentProperties(DeploymentMode.Incremental)
    {
        Template = File.ReadAllText("storage-account.json");,
        Parameters = parameter.ToString()
    }
);
```
