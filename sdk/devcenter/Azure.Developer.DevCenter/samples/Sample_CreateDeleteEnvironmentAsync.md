# Azure.Developer.DevCenter samples - Deployment Environments

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Get all projects in a dev center

Create a `DevCenterClient` and issue a request to get all projects the signed-in user can access.

```C# Snippet:Azure_DevCenter_GetProjects_Scenario
string targetProjectName = null;
await foreach (BinaryData data in devCenterClient.GetProjectsAsync(null, null, null))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    targetProjectName = result.GetProperty("name").ToString();
}
```

## Get project catalogs

Create an `EnvironmentsClient` and issue a request to get all catalogs in a project.

```C# Snippet:Azure_DevCenter_GetCatalogs_Scenario
string catalogName = null;

await foreach (BinaryData data in environmentsClient.GetCatalogsAsync(projectName, null, null))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    catalogName = result.GetProperty("name").ToString();
}
```

## Get all environment definitions in a project for a catalog

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
