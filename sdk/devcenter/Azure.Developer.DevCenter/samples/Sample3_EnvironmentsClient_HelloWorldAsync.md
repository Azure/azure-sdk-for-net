# Create Deployment Environment Client and Get an Environment

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:Azure_DevCenter_BasicImport
using System;
using Azure.Developer.DevCenter;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
```

## Create deployment environments client

To manipulate any of the deployment environment operations use the `DeploymentEnvironmentsClient`.

```C# Snippet:Azure_DevCenter_CreateDeploymentEnvironmentsClient
string devCenterUri = "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com";
var endpoint = new Uri(devCenterUri);
var credential = new DefaultAzureCredential();

var environmentsClient = new DeploymentEnvironmentsClient(endpoint, credential);
```

## Get a dev box 

Using the `DeploymentEnvironmentsClient` issue a request to get an environment.

```C# Snippet:Azure_DevCenter_GetEnvironmentAsync
DevCenterEnvironment environment = await environmentsClient.GetEnvironmentAsync("MyProject", "me", "MyEnvironment");
Console.WriteLine($"The environment {environment.Name} is in {environment.ProvisioningState} state");
```

