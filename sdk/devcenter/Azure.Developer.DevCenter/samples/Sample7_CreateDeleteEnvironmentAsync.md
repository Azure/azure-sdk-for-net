# Deployment Environments Operations

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Get all projects in a dev center

Create a `DevCenterClient` and issue a request to get all projects the signed-in user can access.

```C# Snippet:Azure_DevCenter_GetProjects_Scenario
string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
var endpoint = new Uri(devCenterUri);
var credential = new DefaultAzureCredential();
var devCenterClient = new DevCenterClient(endpoint, credential);

List<DevCenterProject> projects = await devCenterClient.GetProjectsAsync().ToEnumerableAsync();
var projectName = projects.FirstOrDefault().Name;
```

## Get project catalogs

Create an `EnvironmentsClient` and issue a request to get all catalogs in a project.

```C# Snippet:Azure_DevCenter_GetCatalogs_Scenario
// Create deployment environments client from existing DevCenter client
var environmentsClient = devCenterClient.GetDeploymentEnvironmentsClient();

//List all catalogs and grab the first one
//Using foreach, but could also use a List
string catalogName = default;
await foreach (DevCenterCatalog catalog in environmentsClient.GetCatalogsAsync(projectName))
{
    catalogName = catalog.Name;
    break;
}
Console.WriteLine($"Using catalog {catalogName}");
```

## Get all environment definitions in a project for a catalog

```C# Snippet:Azure_DevCenter_GetEnvironmentDefinitionsFromCatalog_Scenario
//List all environment definition for a catalog and grab the first one
string environmentDefinitionName = default;
await foreach (EnvironmentDefinition environmentDefinition in environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(projectName, catalogName))
{
    environmentDefinitionName = environmentDefinition.Name;
    break;
}
Console.WriteLine($"Using environment definition {environmentDefinitionName}");
```

## Get all environment types in a project

Issue a request to get all environment types in a project.

```C# Snippet:Azure_DevCenter_GetEnvironmentTypes_Scenario
//List all environment types and grab the first one
string environmentTypeName = default;
await foreach (DevCenterEnvironmentType environmentType in environmentsClient.GetEnvironmentTypesAsync(projectName))
{
    environmentTypeName = environmentType.Name;
    break;
}
Console.WriteLine($"Using environment type {environmentTypeName}");
```

## Create an environment

Issue a request to create an environment using a specific definition item and environment type.

```C# Snippet:Azure_DevCenter_CreateEnvironment_Scenario
var requestEnvironment = new DevCenterEnvironment
(
    "DevEnvironment",
    environmentTypeName,
    catalogName,
    environmentDefinitionName
);

// Deploy the environment
Operation<DevCenterEnvironment> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(
    WaitUntil.Completed,
    projectName,
    "me",
    requestEnvironment);

DevCenterEnvironment environment = await environmentCreateOperation.WaitForCompletionAsync();
Console.WriteLine($"Completed provisioning for environment with status {environment.ProvisioningState}.");
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
