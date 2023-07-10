# Azure.Developer.DevCenter samples - Deployment Environments

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Get all projects in a dev center

Create a `DevCenterClient` and issue a request to get all projects the signed-in user can access.

```C# Snippet:Azure_DevCenter_GetProjects_Scenario
var credential = new DefaultAzureCredential();
var devCenterClient = new DevCenterClient(endpoint, credential);
string targetProjectName = null;
await foreach (BinaryData data in devCenterClient.GetProjectsAsync(filter: null, maxCount: 1))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    targetProjectName = result.GetProperty("name").ToString();
}
```

## Get all catalog items in a project

Create an `EnvironmentsClient` and issue a request to get all catalog items in a project.

```C# Snippet:Azure_DevCenter_GetCatalogItems_Scenario
var environmentsClient = new EnvironmentsClient(endpoint, projectName, credential);
string catalogItemName = null;
await foreach (BinaryData data in environmentsClient.GetCatalogItemsAsync(maxCount: 1))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    catalogItemName = result.GetProperty("name").ToString();
}
```

## Get all environment types in a project

Issue a request to get all environment types in a project.

```C# Snippet:Azure_DevCenter_GetEnvironmentTypes_Scenario
string environmentTypeName = null;
await foreach (BinaryData data in environmentsClient.GetEnvironmentTypesAsync(maxCount: 1))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    environmentTypeName = result.GetProperty("name").ToString();
}
```

## Create an environment

Issue a request to create an environment using a specific catalog item and environment type.

```C# Snippet:Azure_DevCenter_CreateEnvironment_Scenario
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
```

## Delete an environment

Issue a request to delete an environment.

```C# Snippet:Azure_DevCenter_DeleteEnvironment_Scenario
Operation environmentDeleteOperation = await environmentsClient.DeleteEnvironmentAsync(WaitUntil.Completed, projectName, "DevEnvironment");
await environmentDeleteOperation.WaitForCompletionResponseAsync();
Console.WriteLine($"Completed environment deletion.");
```
