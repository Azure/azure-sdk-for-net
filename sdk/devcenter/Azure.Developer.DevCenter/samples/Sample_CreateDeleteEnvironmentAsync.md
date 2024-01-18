# Azure.Developer.DevCenter samples - Deployment Environments

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Get all projects in a dev center

Create a `DevCenterClient` and issue a request to get all projects the signed-in user can access.

```C# Snippet:Azure_DevCenter_GetProjects_Scenario
string targetProjectName = null;
await foreach (DevCenterProject project in devCenterClient.GetProjectsAsync())
{
    targetProjectName = project.Name;
}
```

## Get project catalogs

Create an `EnvironmentsClient` and issue a request to get all catalogs in a project.

```C# Snippet:Azure_DevCenter_GetCatalogs_Scenario
string catalogName = null;

await foreach (DevCenterCatalog catalog in environmentsClient.GetCatalogsAsync(projectName))
{
    catalogName = catalog.Name;
}
```

## Get all environment definitions in a project for a catalog

```C# Snippet:Azure_DevCenter_GetEnvironmentDefinitionsFromCatalog_Scenario
string environmentDefinitionName = null;
await foreach (EnvironmentDefinition environmentDefinition in environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(projectName, catalogName))
{
    environmentDefinitionName = environmentDefinition.Name;
}
```

## Get all environment types in a project

Issue a request to get all environment types in a project.

```C# Snippet:Azure_DevCenter_GetEnvironmentTypes_Scenario
string environmentTypeName = null;
await foreach (DevCenterEnvironmentType environmentType in environmentsClient.GetEnvironmentTypesAsync(projectName))
{
    environmentTypeName = environmentType.Name;
}
```

## Create an environment

Issue a request to create an environment using a specific definition item and environment type.

```C# Snippet:Azure_DevCenter_CreateEnvironment_Scenario
var requestEnvironment = new DevCenterEnvironment
(
    environmentTypeName,
    catalogName,
    environmentDefinitionName
);

// Deploy the environment
Operation<DevCenterEnvironment> environmentCreateOperation = await environmentsClient.CreateOrUpdateEnvironmentAsync(
    WaitUntil.Completed,
    projectName,
    "me",
    "DevEnvironment",
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
