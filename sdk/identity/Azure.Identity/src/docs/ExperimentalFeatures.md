# Experimental Feature Diagnostics

This document lists the experimental feature diagnostic IDs used in Azure.Identity to mark APIs that are under development and subject to change.

## SCME0002 - Microsoft.Extensions.Configuration Integration Experimental API

### Description

The Microsoft.Extensions.Configuration and Microsoft.Extensions.DependencyInjection integration APIs are experimental features for configuring Azure SDK clients using .NET configuration patterns. These APIs are subject to change or removal in future updates as we gather feedback and refine the implementation.

### Affected APIs

- `Azure.Identity.ConfigurationExtensions` - Extension methods for IConfiguration and IHostApplicationBuilder
  - `GetAzureClientSettings<T>` - Creates client settings from configuration
  - `AddAzureClient<TClient, TSettings>` - Registers an Azure client in the DI container
  - `AddKeyedAzureClient<TClient, TSettings>` - Registers a keyed Azure client in the DI container
  - `WithAzureCredential` - Configures settings to use Azure credential

### Example Usage

```csharp
#pragma warning disable SCME0002

// Get client settings from configuration
var settings = configuration.GetAzureClientSettings<MyClientSettings>("MyClient");

// Or use dependency injection
builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

#pragma warning restore SCME0002
```

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

### Related Documentation

For more information about the configuration and dependency injection integration in System.ClientModel, see:
- [System.ClientModel ExperimentalFeatures.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ExperimentalFeatures.md)
- [ConfigurationAndDependencyInjection.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ConfigurationAndDependencyInjection.md)
