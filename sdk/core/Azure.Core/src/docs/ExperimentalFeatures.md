# Experimental Feature Diagnostics

This document lists the experimental feature diagnostic IDs used in Azure.Core to mark APIs that are under development and subject to change.

## SCME0002 - Microsoft.Extensions.Configuration Integration Experimental API

### Description

The `Microsoft.Extensions.Configuration` and `Microsoft.Extensions.DependencyInjection` integration APIs are experimental features for configuring Azure SDK clients using .NET configuration patterns. These APIs are subject to change or removal in future updates as we gather feedback and refine the implementation.

### Affected APIs

- `Azure.Core.ClientOptions` constructor that accepts `IConfigurationSection`
- `Azure.Core.DiagnosticsOptions` constructor that accepts `IConfigurationSection`
- `Azure.Identity.ConfigurationExtensions` - Extension methods for `IConfiguration`, `IServiceCollection`, and `IHostApplicationBuilder`
  - `GetAzureClientSettings<T>` - Creates client settings from configuration with Azure credential resolution. Overloads accept caller-supplied `CredentialResolver` chains in addition to the built-in `AzureCredentialResolver`.
  - `GetAzureCredential` - Resolves a `TokenCredential` directly from a configuration section using the built-in `AzureCredentialResolver`, optionally with caller-supplied resolvers and overrides. Returns `null` when no resolver claims the section; never throws.
  - `AddAzureCredentialResolver` (on `IServiceCollection` and `IHostApplicationBuilder`) - Idempotently registers the `AzureCredentialResolver` in DI so libraries that want their own credential sources can compose with the Azure built-in chain.
  - `AddAzureClient<TClient, TSettings>` - Registers an Azure client in the DI container. The built-in `AzureCredentialResolver` is added automatically.
  - `AddKeyedAzureClient<TClient, TSettings>` - Registers a keyed Azure client in the DI container. The built-in `AzureCredentialResolver` is added automatically.
- `Azure.Identity.AzureCredentialResolver` - A `System.ClientModel.Primitives.CredentialResolver` that resolves Azure credential configuration sections (api-key, chained, single-source) into `TokenCredential` instances. Used implicitly by the Azure-flavored extensions; can also be registered directly via `AddCredentialResolver<AzureCredentialResolver>()` or `AddAzureCredentialResolver()`.

### Example Usage

See [ConfigurationAndDependencyInjection.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ConfigurationAndDependencyInjection.md) for detailed examples, including the
[Custom Credential Resolvers](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ConfigurationAndDependencyInjection.md#for-library-authors-custom-credential-resolvers)
section for library authors who want to publish their own credential sources.

### Composing with the Base `AddClient`

`AddAzureClient` is sugar that registers the `AzureCredentialResolver` for you and
then calls the base `AddClient`. If you prefer to call `AddClient` directly, register
the resolver explicitly first to get the same behavior:

```C# Snippet:Azure_Core_Samples_AzureClient_AddAzureClientEquivalence
#pragma warning disable SCME0002

// These two are equivalent:
builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

builder.AddAzureCredentialResolver();
builder.AddClient<MyClient, MyClientSettings>("MyClient");

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
