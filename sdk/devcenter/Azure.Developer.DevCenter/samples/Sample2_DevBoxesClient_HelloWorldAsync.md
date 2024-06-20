# Create Dev Boxes Client and Get a DevBox

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:Azure_DevCenter_BasicImport
using System;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
```

## Create dev boxes client

To manipulate any of the dev boxes operations use the `DevBoxesClient`.

```C# Snippet:Azure_DevCenter_CreateDevBoxesClient
string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
var endpoint = new Uri(devCenterUri);
var credential = new DefaultAzureCredential();

var devBoxesClient = new DevBoxesClient(endpoint, credential);
```

## Get a dev box 

Using the `DevBoxesClient` issue a request to get a dev box.

```C# Snippet:Azure_DevCenter_GetDevBoxAsync
DevBox devBox = await devBoxesClient.GetDevBoxAsync("MyProject", "me", "MyDevBox");
Console.WriteLine($"The dev box {devBox.Name} is located in the {devBox.Location} region.");
```

