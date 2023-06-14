# Azure.Developer.DevCenter samples - Dev Boxes

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

## Get all pools in a project

Create a `DevBoxesClient` and issue a request to get all pools in a project.

```C# Snippet:Azure_DevCenter_GetPools_Scenario
var devBoxesClient = new DevBoxesClient(endpoint, targetProjectName, credential);
string targetPoolName = null;
await foreach (BinaryData data in devBoxesClient.GetPoolsAsync(filter: null, maxCount: 1))
{
    JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
    targetPoolName = result.GetProperty("name").ToString();
}
```

## Create a dev box

Issue a request to create a dev box in a project using a specific pool.

```C# Snippet:Azure_DevCenter_CreateDevBox_Scenario
var content = new
{
    poolName = targetPoolName,
};

Operation<BinaryData> devBoxCreateOperation = await devBoxesClient.CreateDevBoxAsync(WaitUntil.Completed, "MyDevBox", RequestContent.Create(content));
BinaryData devBoxData = await devBoxCreateOperation.WaitForCompletionAsync();
JsonElement devBox = JsonDocument.Parse(devBoxData.ToStream()).RootElement;
Console.WriteLine($"Completed provisioning for dev box with status {devBox.GetProperty("provisioningState")}.");
```

## Connect to a dev box

Once your dev box is created, issue a request to get URLs for connecting to it via either web or desktop.

```C# Snippet:Azure_DevCenter_ConnectToDevBox_Scenario
Response remoteConnectionResponse = await devBoxesClient.GetRemoteConnectionAsync("MyDevBox");
JsonElement remoteConnectionData = JsonDocument.Parse(remoteConnectionResponse.ContentStream).RootElement;
Console.WriteLine($"Connect using web URL {remoteConnectionData.GetProperty("webUrl")}.");
```

## Create a dev box

Issue a request to delete a dev box.

```C# Snippet:Azure_DevCenter_DeleteDevBox_Scenario
Operation devBoxDeleteOperation = await devBoxesClient.DeleteDevBoxAsync(WaitUntil.Completed, "MyDevBox");
await devBoxDeleteOperation.WaitForCompletionResponseAsync();
Console.WriteLine($"Completed dev box deletion.");
```
