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

## Key concepts

The library uses three main clients. The `DevCenterClient` provides access to common APIs for interacting with projects and listing resources across projects.
The `DevBoxesClient` is scoped to a single project, and provides access to Dev Box resources such as Pools and Dev Boxes.
The `DeploymentEnvironmentsClient` is scoped to a single project, and provides access to Environments resources such as Environment Definitions, Environment Types, and Environments.

Use these clients to interact with DevCenter resources based on your scenario.

```C# Snippet:Azure_DevCenter_CreateClients_Scenario
var credential = new DefaultAzureCredential();

var devCenterClient = new DevCenterClient(endpoint, credential);
var devBoxesClient = new DevBoxesClient(endpoint, credential);
var environmentsClient = new DeploymentEnvironmentsClient(endpoint, credential);
```

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/devcenter/Azure.Developer.DevCenter/samples).

### Get all projects in a dev center

`DevCenterClient` allows you to list projects and retrieve projects by their name.

```C# Snippet:Azure_DevCenter_GetProjects_Scenario
string targetProjectName = null;
await foreach (BinaryData data in devCenterClient.GetProjectsAsync(null, null, null))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    targetProjectName = result.GetProperty("name").ToString();
}
```

### List available Dev Box Pools

Interaction with DevBox pools is facilitated through the `DevBoxesClient`. Pools can be listed for a specific project or fetched individually.

```C# Snippet:Azure_DevCenter_GetPools_Scenario
string targetPoolName = null;
await foreach (BinaryData data in devBoxesClient.GetPoolsAsync(targetProjectName, null, null, null))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    targetPoolName = result.GetProperty("name").ToString();
}
```

### Provision a Dev Box

To create a new DevBox, provide the pool name in the content and specify the desired DevBox name. Upon successful execution of this operation, a DevBox should appear in the portal.

```C# Snippet:Azure_DevCenter_CreateDevBox_Scenario
var content = new
{
    poolName = targetPoolName,
};

Operation<BinaryData> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(
    WaitUntil.Completed,
    targetProjectName,
    "me",
    "MyDevBox",
    RequestContent.Create(content));

BinaryData devBoxData = await devBoxCreateOperation.WaitForCompletionAsync();
JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;
Console.WriteLine($"Completed provisioning for dev box with status {devBox.GetProperty("provisioningState")}.");
```

### Connect to your Dev Box

Once a DevBox is provisioned, you can connect to it using an RDP connection string. Below is a sample code that demonstrates how to retrieve it.

```C# Snippet:Azure_DevCenter_ConnectToDevBox_Scenario
Response remoteConnectionResponse = await devBoxesClient.GetRemoteConnectionAsync(
    targetProjectName,
    "me",
    "MyDevBox",
    null);
JsonElement remoteConnectionData = JsonDocument.Parse(remoteConnectionResponse.ContentStream).RootElement;
Console.WriteLine($"Connect using web URL {remoteConnectionData.GetProperty("webUrl")}.");
```

### Delete the Dev Box

Deleting a DevBox is easy. It's much faster operation than creating a new DevBox. 

```C# Snippet:Azure_DevCenter_DeleteDevBox_Scenario
Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(
    WaitUntil.Completed,
    targetProjectName,
    "me",
    "MyDevBox");
await devBoxDeleteOperation.WaitForCompletionResponseAsync();
Console.WriteLine($"Completed dev box deletion.");
```

## Get project catalogs

`DeploymentEnvironmentsClient` can be used to issue a request to get all catalogs in a project.

```C# Snippet:Azure_DevCenter_GetCatalogs_Scenario
string catalogName = null;

await foreach (BinaryData data in environmentsClient.GetCatalogsAsync(projectName, null, null))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    catalogName = result.GetProperty("name").ToString();
}
```

## Get all environment definitions in a project for a catalog

Environment definitions are a part of the catalog associated with your project. If you don't see the expected environment definitions in the results, please ensure that you have pushed your changes to the catalog repository and synchronized the catalog.

```C# Snippet:Azure_DevCenter_GetEnvironmentDefinitionsFromCatalog_Scenario
string environmentDefinitionName = null;
await foreach (BinaryData data in environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(projectName, catalogName, maxCount: 1, context: new()))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    environmentDefinitionName = result.GetProperty("name").ToString();
}
```

## Get all environment types in a project

Issue a request to get all environment types in a project.

```C# Snippet:Azure_DevCenter_GetEnvironmentTypes_Scenario
string environmentTypeName = null;
await foreach (BinaryData data in environmentsClient.GetEnvironmentTypesAsync(projectName, null, null))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    environmentTypeName = result.GetProperty("name").ToString();
}
```

## Create an environment

Issue a request to create an environment using a specific definition item and environment type.

```C# Snippet:Azure_DevCenter_CreateEnvironment_Scenario
var content = new
{
    catalogName = catalogName,
    environmentType = environmentTypeName,
    environmentDefinitionName = environmentDefinitionName,
};

// Deploy the environment
Operation<BinaryData> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(
    WaitUntil.Completed,
    projectName,
    "me",
    "DevEnvironment",
    RequestContent.Create(content));

BinaryData environmentData = await environmentCreateOperation.WaitForCompletionAsync();
JsonElement environment = JsonDocument.Parse(environmentData.ToStream()).RootElement;
Console.WriteLine($"Completed provisioning for environment with status {environment.GetProperty("provisioningState")}.");
```

## Delete an environment

Issue a request to delete an environment.

```C# Snippet:Azure_DevCenter_DeleteEnvironment_Scenario
Operation environmentDeleteOperation = await environmentsClient.DeleteEnvironmentAsync(
    WaitUntil.Completed,
    projectName,
    "me",
    "DevEnvironment");
await environmentDeleteOperation.WaitForCompletionResponseAsync();
Console.WriteLine($"Completed environment deletion.");
```

## Troubleshooting

Errors may occur during Dev Box provisioning due to problems with other resources or your Azure configuration. You can view the operation error or the `errorDetails` property on the Dev Box if provisioning fails, which will show more information about the problem and how to resolve it.
Ensure that your Pool, Network Connection, and Dev Box Definition resources are all in a healthy state before attempting to create a Dev Box. Problems with their configurations will prevent successful creation of your Dev Box.

Errors may occur during Environment deployment due to problems with your template, parameters, or the configuration of other resources. You can view the operation error, which will provide more information about the problem and how to resolve it.
Ensure that your Project Environment Type's identity has the correct permissions to the target subscription, that you are passing all parameters which are required by the template, and that all parameters are valid.

## Contributing

See the [DevCenter CONTRIBUTING.md][azdevcenter_contrib] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[azdevcenter_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/CONTRIBUTING.md
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/devcenter/Azure.Developer.DevCenter/README.png)

## Next steps

For more information on Azure SDK, please refer to [this website](https://azure.github.io/azure-sdk/)
