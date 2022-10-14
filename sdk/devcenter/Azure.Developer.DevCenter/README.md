# Azure DevCenter client library for .NET

The DevCenter client library provides access to manage resources for Microsoft Dev Box and Azure Deployment Environments. This SDK enables managing developer machines and environments in Azure.

Use the client library for Azure DevCenter to:
> Create, access, manage, and delete [Dev Box](https://learn.microsoft.com/azure/dev-box) resources
> Create, deploy, manage, and delete [Environment](https://learn.microsoft.com/azure/deployment-environments) resources

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/src) | [Package (NuGet)](https://www.nuget.org/packages/) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Developer.DevCenter --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

You must have [configured](https://learn.microsoft.com/azure/dev-box/quickstart-configure-dev-box-service) a DevCenter, Project, Network Connection, Dev Box Definition, and Pool before you can create Dev Boxes 

You must have configured a DevCenter, Project, Catalog, and Environment Type before you can create Environments

### Authenticate the client

You can use standard Azure Active Directory [Token Credential authentication](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential) to access the client. The identity interacting with all resources must have a minimum of Read access on the Project resources it is interacting with. The identity managing Dev Boxes must have the [DevCenter Project Admin](https://learn.microsoft.com/azure/dev-box/how-to-project-admin) or [DevCenter Dev Box User](https://learn.microsoft.com/azure/dev-box/how-to-dev-box-user) roles for Dev Box scenarios. These roles can be assigned directly to the project, or inherited from a broader scope (such as the resource group or subscription).
To use Azure Active Directory authentication, add the Azure Identity package:

`dotnet add package Azure.Identity`

You will also need to register a new AAD application, or run locally or in an environment with a managed identity.
If using an application, set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```
string tenantId = "<tenant-id>";
string devCenterName = "<dev-center-name>";
var client = new DevCenterClient(
                tenantId,
                devCenterName,
                new DefaultAzureCredential());
```

## Key concepts

The library uses three main clients. The `DevCenterClient` provides access to common APIs for interacting with projects and listing resources across projects.
The `DevBoxesClient` is scoped to a single project, and provides access to Dev Box resources such as Pools and Dev Boxes.
The `EnvironmentsClient` is scoped to a single project, and provides access to Environments resources such as Catalog Items, Environment Types, and Environments.

Use these clients to interact with DevCenter resources based on your scenario.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/devcenter/Azure.Developer.DevCenter/samples).

### Dev Box Usage

```C# Snippet:Azure_DevCenter_DevBox_Scenario
public async Task CreateDeleteDevBoxAsync(string tenantId, string devCenterName)
{
    // Create and delete a user devbox
    var credential = new DefaultAzureCredential();
    var devCenterClient = new DevCenterClient(tenantId, devCenterName, credential);
    string targetProjectName = null;
    await foreach (BinaryData data in devCenterClient.GetProjectsAsync(filter: null, maxCount: 1))
    {
        JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        targetProjectName = result.GetProperty("name").ToString();
    }

    if (targetProjectName is null)
    {
        throw new InvalidOperationException($"No valid project resources found in DevCenter {devCenterName}/tenant {tenantId}.");
    }

    // Grab a pool
    var devBoxesClient = new DevBoxesClient(tenantId, devCenterName, targetProjectName, credential);
    string targetPoolName = null;
    await foreach (BinaryData data in devBoxesClient.GetPoolsAsync(filter: null, maxCount: 1))
    {
        JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        targetPoolName = result.GetProperty("name").ToString();
    }

    if (targetPoolName is null)
    {
        throw new InvalidOperationException($"No valid pool resources found in Project {targetProjectName}/DevCenter {devCenterName}/tenant {tenantId}.");
    }

    // Provision your dev box in the selected pool
    var content = new
    {
        poolName = targetPoolName,
    };

    Operation<BinaryData> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(WaitUntil.Completed, "MyDevBox", RequestContent.Create(content));
    BinaryData devBoxData = await devBoxCreateOperation.WaitForCompletionAsync();
    JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;
    Console.WriteLine($"Completed provisioning for dev box with status {devBox.GetProperty("provisioningState")}.");

    // Fetch the web connection URL to access your dev box from the browser
    Response remoteConnectionResponse = await devBoxesClient.GetRemoteConnectionAsync("MyDevBox");
    JsonElement remoteConnectionData = JsonDocument.Parse(remoteConnectionResponse.ContentStream).RootElement;
    Console.WriteLine($"Connect using web URL {remoteConnectionData.GetProperty("webUrl")}.");

    // Delete your dev box when finished
    Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(WaitUntil.Completed, "MyDevBox");
    await devBoxDeleteOperation.WaitForCompletionResponseAsync();
    Console.WriteLine($"Completed dev box deletion.");
}
```

### Environment Usage

```C# Snippet:Azure_DevCenter_Environment_Scenario
public async Task CreateDeleteEnvironmentAsync(string tenantId, string devCenterName)
{
    // Create and delete a user environment
    var credential = new DefaultAzureCredential();
    var devCenterClient = new DevCenterClient(tenantId, devCenterName, credential);
    string projectName = null;
    await foreach (BinaryData data in devCenterClient.GetProjectsAsync(filter: null, maxCount: 1))
    {
        JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        projectName = result.GetProperty("name").ToString();
    }

    if (projectName is null)
    {
        throw new InvalidOperationException($"No valid project resources found in DevCenter {devCenterName}/tenant {tenantId}.");
    }

    var environmentsClient = new EnvironmentsClient(tenantId, devCenterName, projectName, credential);
    string catalogItemName = null;
    await foreach (BinaryData data in environmentsClient.GetCatalogItemsAsync(maxCount: 1))
    {
        JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        catalogItemName = result.GetProperty("name").ToString();
    }

    if (catalogItemName is null)
    {
        throw new InvalidOperationException($"No valid catalog item resources found in Project {projectName}/DevCenter {devCenterName}/tenant {tenantId}.");
    }

    string environmentTypeName = null;
    await foreach (BinaryData data in environmentsClient.GetEnvironmentTypesAsync(maxCount: 1))
    {
        JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        environmentTypeName = result.GetProperty("name").ToString();
    }

    if (environmentTypeName is null)
    {
        throw new InvalidOperationException($"No valid catalog item resources found in Project {projectName}/DevCenter {devCenterName}/tenant {tenantId}.");
    }

    var content = new
    {
        environmentType = environmentTypeName,
        catalogItemName = catalogItemName,
    };

    // Deploy the environment
    Operation<BinaryData> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(WaitUntil.Completed, "DevEnvironment", RequestContent.Create(content));
    BinaryData environmentData = await environmentCreateOperation.WaitForCompletionAsync();
    JsonElement environment = JsonDocument.Parse(environmentData.ToStream()).RootElement;
    Console.WriteLine($"Completed provisioning for environment with status {environment.GetProperty("provisioningState")}.");

    // Fetch and output the deployment artifacts
    await foreach (BinaryData data in environmentsClient.GetArtifactsByEnvironmentAsync(projectName, "DevEnvironment"))
    {
        JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        Console.WriteLine(result.GetProperty("name").ToString());
        Console.WriteLine(result.GetProperty("isDirectory").ToString());
        Console.WriteLine(result.GetProperty("downloadUri").ToString());
    }

    // Delete the environment when finished
    Operation environmentDeleteOperation = await environmentsClient.DeleteEnvironmentAsync(WaitUntil.Completed, projectName, "DevEnvironment");
    await environmentDeleteOperation.WaitForCompletionResponseAsync();
    Console.WriteLine($"Completed environment deletion.");
}
```

## Troubleshooting

Errors may occur during Dev Box provisioning due to problems with other resources or your Azure configuration. You can view the operation error or the `errorDetails` property on the Dev Box if provisioning fails, which will show more information about the problem and how to resolve it.
Ensure that your Pool, Network Connection, and Dev Box Definition resources are all in a healthy state before attempting to create a Dev Box. Problems with their configurations will prevent successful creation of your Dev Box.

Errors may occur during Environment deployment due to problems with your template, parameters, or the configuration of other resources. You can view the operation error, which will provide more information about the problem and how to resolve it.
Ensure that your Project Environment Type's identity has the correct permissions to the target subscription, that you are passing all parameters which are required by the template, and that all parameters are valid.

## Contributing

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/devcenter/Azure.Developer.DevCenter/README.png)

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)
