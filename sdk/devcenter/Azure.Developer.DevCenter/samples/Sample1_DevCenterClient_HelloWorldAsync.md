# Create Dev Center Client and Get a Project

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:Azure_DevCenter_BasicImport
using System;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
```

## Create dev center client

To get a project first instantiate the dev center client.

```C# Snippet:Azure_DevCenter_CreateDevCenterClient
string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
var endpoint = new Uri(devCenterUri);
var credential = new DefaultAzureCredential();

var devCenterClient = new DevCenterClient(endpoint, credential);
```

## Get a project in the dev center 

Using the `DevCenterClient` issue a request to get a specific project.

```C# Snippet:Azure_DevCenter_GetProjectAsync
DevCenterProject project = await devCenterClient.GetProjectAsync("MyProject");
Console.WriteLine(project.Name);
```

