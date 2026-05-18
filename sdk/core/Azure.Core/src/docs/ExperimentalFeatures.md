# Experimental Feature Diagnostics

This document lists the experimental feature diagnostic IDs used in Azure.Core to mark APIs that are under development and subject to change.

## SCME0002 - Microsoft.Extensions.Configuration Integration Experimental API

### Description

The `Microsoft.Extensions.Configuration` and `Microsoft.Extensions.DependencyInjection` integration APIs are experimental features for configuring Azure SDK clients using .NET configuration patterns. These APIs are subject to change or removal in future updates as we gather feedback and refine the implementation.

### Affected APIs

- `Azure.Core.ClientOptions` constructor that accepts `IConfigurationSection`
- `Azure.Core.DiagnosticsOptions` constructor that accepts `IConfigurationSection`
- `Azure.Identity.ConfigurationExtensions` - Extension methods for `IConfiguration` and `IHostApplicationBuilder`
  - `GetAzureClientSettings<T>` - Creates client settings from configuration with Azure credential resolution
  - `AddAzureClient<TClient, TSettings>` - Registers an Azure client in the DI container (automatically calls `WithAzureCredential`)
  - `AddKeyedAzureClient<TClient, TSettings>` - Registers a keyed Azure client in the DI container (automatically calls `WithAzureCredential`)
  - `WithAzureCredential` (on `ClientSettings`) - Configures settings to resolve Azure credentials from configuration
  - `WithAzureCredential` (on `IClientBuilder`) - Configures the client builder to resolve Azure credentials from configuration

### How AddAzureClient and WithAzureCredential Work Together

The `AddAzureClient` extension methods are convenience wrappers that call the base `AddClient` method from `System.ClientModel` and then automatically call `WithAzureCredential`. This means you don't need to manually configure Azure credential resolution — it's handled for you.

If you use the base `AddClient` method directly, you can call `WithAzureCredential` explicitly to get the same behavior:

```csharp
#pragma warning disable SCME0002

// These two are equivalent:
builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

builder.AddClient<MyClient, MyClientSettings>("MyClient")
    .WithAzureCredential();

#pragma warning restore SCME0002
```

### Example Usage

See [ConfigurationAndDependencyInjection.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ConfigurationAndDependencyInjection.md) for detailed examples.

### Suppression

If you want to use these experimental APIs and accept the risk that they may change, you can suppress the warning:

```csharp
#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates.
```

Or in your project file:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);SCME0002</NoWarn>
</PropertyGroup>
```
