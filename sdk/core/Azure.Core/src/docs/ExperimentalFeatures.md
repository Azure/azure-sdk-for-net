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

## AZID0001 - Identity: AdditionalQueryParameters Experimental API

### Description

The `AdditionalQueryParameters` property on `TokenCredentialOptions` allows forwarding extra query string parameters to MSAL during authentication. Each entry maps a parameter name to its value and a flag that controls whether the parameter is part of the token cache key.

### Affected APIs

- `Azure.Identity.TokenCredentialOptions.AdditionalQueryParameters`

### Suppression

```csharp
#pragma warning disable AZID0001
```

Or in your project file:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);AZID0001</NoWarn>
</PropertyGroup>
```

## AZID0002 - Identity: IsAzureProxyEnabled Experimental API

### Description

The `IsAzureProxyEnabled` property on `WorkloadIdentityCredentialOptions` enables the Azure Kubernetes Service proxy for workload identity authentication.

### Affected APIs

- `Azure.Identity.WorkloadIdentityCredentialOptions.IsAzureProxyEnabled`

### Suppression

```csharp
#pragma warning disable AZID0002
```

Or in your project file:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);AZID0002</NoWarn>
</PropertyGroup>
```

## AZID0003 - Identity: TokenRequestCallback Experimental API

### Description

The `TokenRequestCallback` property on MSAL-backed credential options types allows customizing the token request before it is sent to the identity provider. The callback receives a `TokenRequestCallbackContext` which exposes `BodyParameters` for adding custom body parameters to the OAuth token request.

### Affected APIs

- `Azure.Identity.TokenRequestCallbackContext`
- `TokenRequestCallback` property on:
  - `Azure.Identity.ClientSecretCredentialOptions`
  - `Azure.Identity.ClientCertificateCredentialOptions`
  - `Azure.Identity.ClientAssertionCredentialOptions`
  - `Azure.Identity.OnBehalfOfCredentialOptions`
  - `Azure.Identity.AuthorizationCodeCredentialOptions`
  - `Azure.Identity.DeviceCodeCredentialOptions`
  - `Azure.Identity.InteractiveBrowserCredentialOptions`

### Example Usage

```csharp
#pragma warning disable AZID0003

var credential = new ClientSecretCredential(tenantId, clientId, clientSecret, new ClientSecretCredentialOptions
{
    TokenRequestCallback = data =>
    {
        data.BodyParameters["custom_param"] = "value";
    }
});

#pragma warning restore AZID0003
```

### Suppression

```csharp
#pragma warning disable AZID0003
```

Or in your project file:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);AZID0003</NoWarn>
</PropertyGroup>
```
