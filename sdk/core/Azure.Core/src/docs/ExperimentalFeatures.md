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
  - `GetAzureCredentialSettings` - Returns a `CredentialSettings` bound from a credential section, with `TokenProvider` populated by the built-in `AzureCredentialResolver` when it claims the section. For inline ApiKey sections `Key` is populated and `TokenProvider` is `null`, letting callers dispatch on either shape without binding a `ClientSettings`. Returns `null` only when the section does not exist; never throws.
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

## AZID0004 - Identity: mTLS Token Binding Experimental API

### Description

The mTLS token binding and proof-of-possession APIs enable proof-of-possession token support for managed identity scenarios. These APIs allow transport-level certificate binding for token requests, enabling mTLS-based token binding on supported Azure VMs. The `DisableMtlsProofOfPossession` option provides a control to opt out of mTLS proof-of-possession token acquisition when the underlying requirements are met. These APIs are experimental and subject to change as the feature matures.

### Affected APIs

- `Azure.Core.Pipeline.BearerTokenAuthenticationPolicy` constructors accepting `HttpPipelineTransportOptions`
- `Azure.Core.Pipeline.BearerTokenAuthenticationPolicy.TransportOptionsChanged` event
- `Azure.Core.Pipeline.BearerTokenAuthenticationPolicy.OnTransportOptionsChanged` method
- `Azure.Identity.ManagedIdentityCredentialOptions.DisableMtlsProofOfPossession` property

### Example Usage

```csharp
#pragma warning disable AZID0004

// Disable mTLS proof-of-possession for managed identity
var credential = new ManagedIdentityCredential(new ManagedIdentityCredentialOptions
{
    DisableMtlsProofOfPossession = true
});

#pragma warning restore AZID0004
```

### Suppression

```csharp
#pragma warning disable AZID0004
```

Or in your project file:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);AZID0004</NoWarn>
</PropertyGroup>
```
