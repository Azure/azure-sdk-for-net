# Initializing the Online Experimentation Client

This sample demonstrates how to initialize the Azure Online Experimentation client library.

## Basic Initialization

The Azure Online Experimentation client library initialization requires two parameters:

- The `endpoint` property value from the [`Microsoft.OnlineExperimentation/workspaces`](https://learn.microsoft.com/azure/templates/microsoft.onlineexperimentation/workspaces) resource.
- A `TokenCredential` for authentication, the simplest approach is to use [`DefaultAzureCredential`](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

```C# Snippet:OnlineExperimentation_InitializeClient
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential());
```

## Initialization with Specific API Version

The client library can be initialized to use a specific API version instead of the latest available.

```C# Snippet:OnlineExperimentation_InitializeClientApiVersion
var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_ONLINEEXPERIMENTATION_ENDPOINT"));
var options = new OnlineExperimentationClientOptions(OnlineExperimentationClientOptions.ServiceVersion.V2025_05_31_Preview);
var client = new OnlineExperimentationClient(endpoint, new DefaultAzureCredential(), options);
```
