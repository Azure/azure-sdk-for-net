# Azure.Developer.DevCenter samples - Dev Boxes

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

## Get all pools in a project

Create a `DevBoxesClient` and issue a request to get all pools in a project.

```C# Snippet:Azure_DevCenter_GetPools_Scenario
string targetPoolName = null;
await foreach (DevBoxPool pool in devBoxesClient.GetPoolsAsync(targetProjectName))
{
    targetPoolName = pool.Name;
}
```

## Create a dev box

Issue a request to create a dev box in a project using a specific pool.

```C# Snippet:Azure_DevCenter_CreateDevBox_Scenario
var content = new DevBox(targetPoolName);

Operation<DevBox> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(
    WaitUntil.Completed,
    targetProjectName,
    "me",
    "MyDevBox",
    content);

DevBox devBox = await devBoxCreateOperation.WaitForCompletionAsync();
Console.WriteLine($"Completed provisioning for dev box with status {devBox.ProvisioningState}.");
```

## Connect to a dev box

Once your dev box is created, issue a request to get URLs for connecting to it via either web or desktop.

```C# Snippet:Azure_DevCenter_ConnectToDevBox_Scenario
RemoteConnection remoteConnection = await devBoxesClient.GetRemoteConnectionAsync(
    targetProjectName,
    "me",
    "MyDevBox");

Console.WriteLine($"Connect using web URL {remoteConnection.WebUri}.");
```

## Delete a dev box

Issue a request to delete a dev box.

```C# Snippet:Azure_DevCenter_DeleteDevBox_Scenario
Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(
    WaitUntil.Completed,
    targetProjectName,
    "me",
    "MyDevBox");
await devBoxDeleteOperation.WaitForCompletionResponseAsync();
Console.WriteLine($"Completed dev box deletion.");
```
