# Stop, Start and Restart a Dev Box

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:Azure_DevCenter_BasicImport
using System;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
```

## Get a dev box

Create a `DevBoxesClient` and issue a request to get a dev box.

```C# Snippet:Azure_DevCenter_GetDevBox_Scenario
// Create DevBox-es client
string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
var endpoint = new Uri(devCenterUri);
var credential = new DefaultAzureCredential();
var devBoxesClient = new DevBoxesClient(endpoint, credential);

//Dev Box properties
var projectName = "MyProject";
var devBoxName = "MyDevBox";
var user = "me";

// Grab the dev box
DevBox devBox = await devBoxesClient.GetDevBoxAsync(projectName, user, devBoxName);
```

## Stop a dev box
Read the power state a dev box and stop it if the dev box is running.

```C# Snippet:Azure_DevCenter_StopDevBox_Scenario
if (devBox.PowerState == PowerState.Running)
{
    //Stop the dev box
    await devBoxesClient.StopDevBoxAsync(
        WaitUntil.Completed,
        projectName,
        user,
        devBoxName);

    Console.WriteLine($"Completed stopping the dev box.");
}
```

## Start a dev box

```C# Snippet:Azure_DevCenter_StartDevBox_Scenario
//Start the dev box
Operation response = await devBoxesClient.StartDevBoxAsync(
    WaitUntil.Started,
    projectName,
    user,
    devBoxName);

response.WaitForCompletionResponse();
Console.WriteLine($"Completed starting the dev box.");
```

## Restart a dev box


```C# Snippet:Azure_DevCenter_RestartDevBox_Scenario
//Restart the dev box
await devBoxesClient.RestartDevBoxAsync(
    WaitUntil.Completed,
    projectName,
    user,
    devBoxName);

Console.WriteLine($"Completed restarting the dev box.");
```
