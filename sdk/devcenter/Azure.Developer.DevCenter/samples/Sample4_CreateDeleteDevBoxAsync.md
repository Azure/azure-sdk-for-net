# Create, Connect and Delete a Dev Box

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:Azure_DevCenter_LongImports
using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
```

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

## Get all pools in a project

Create a `DevBoxesClient` and issue a request to get all pools in a project.

```C# Snippet:Azure_DevCenter_GetPools_Scenario
// Create DevBox-es client from existing DevCenter client
var devBoxesClient = devCenterClient.GetDevBoxesClient();

// Grab a pool
List<DevBoxPool> pools = await devBoxesClient.GetPoolsAsync(projectName).ToEnumerableAsync();
var poolName = pools.FirstOrDefault().Name;
```

## Create a dev box

Issue a request to create a dev box in a project using a specific pool.

```C# Snippet:Azure_DevCenter_CreateDevBox_Scenario
var devBoxName = "MyDevBox";
var devBox = new DevBox(devBoxName, poolName);

Operation<DevBox> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(
    WaitUntil.Completed,
    projectName,
    "me",
    devBox);

devBox = await devBoxCreateOperation.WaitForCompletionAsync();
Console.WriteLine($"Completed provisioning for dev box with status {devBox.ProvisioningState}.");
```

## Connect to a dev box

Once your dev box is created, issue a request to get URI for connecting to it via either web or desktop.

```C# Snippet:Azure_DevCenter_ConnectToDevBox_Scenario
RemoteConnection remoteConnection = await devBoxesClient.GetRemoteConnectionAsync(
    projectName,
    "me",
    devBoxName);

Console.WriteLine($"Connect using web URL {remoteConnection.WebUri}.");
```

## Delete a dev box

Issue a request to delete a dev box.

```C# Snippet:Azure_DevCenter_DeleteDevBox_Scenario
Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(
    WaitUntil.Completed,
    projectName,
    "me",
    devBoxName);
await devBoxDeleteOperation.WaitForCompletionResponseAsync();
Console.WriteLine($"Completed dev box deletion.");
```
