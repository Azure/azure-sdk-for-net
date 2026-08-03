# Configuration and Dependency Injection for Azure SDK Clients

This document demonstrates how to use the configuration and dependency injection
features with Azure SDK clients. These extensions build on top of the
[System.ClientModel configuration support](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ConfigurationAndDependencyInjection.md)
and add Azure-specific credential handling.

> [!NOTE]
> These APIs are experimental and marked with diagnostic ID `SCME0002`.
> See the [Experimental Features](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ExperimentalFeatures.md) documentation for suppression guidance.

> [!IMPORTANT]
> Not all Azure SDK clients support this feature yet. Support is being rolled out incrementally. A client supports configuration and dependency injection if it has a constructor that accepts a single parameter inheriting from `System.ClientModel.Primitives.ClientSettings`.

> [!NOTE]
> For each of the examples using environment variable configuration the name is derived from the convention defined [here](https://learn.microsoft.com/dotnet/core/extensions/configuration-providers#environment-variable-configuration-provider).

## Table of Contents

- [How It Works](#how-it-works)
- [Simple Configuration Example](#simple-configuration-example)
- [Simple Dependency Injection Example](#simple-dependency-injection-example)
- [Keyed Services Example](#keyed-services-example)
- [Resolving Credentials Directly](#resolving-credentials-directly)
- [Chaining Additional Configuration](#chaining-additional-configuration)
- [Common Client Configuration](#common-client-configuration)
- [Credential Configuration](#credential-configuration)
  - [Common Properties](#common-properties)
  - [Credential Sources](#credential-sources)
- [Configuration Reference Syntax](#configuration-reference-syntax)
- [For Library Authors: Custom Credential Resolvers](#for-library-authors-custom-credential-resolvers)

## How It Works

The `Azure.Identity` package provides `AddAzureClient` and `GetAzureClientSettings`
extension methods that wrap the base `System.ClientModel` configuration methods. The
key difference is that they automatically configure Azure credential resolution, so
token credentials are resolved from your configuration's `Credential` section without
any extra setup.

Service-specific `AddXxxClient` extensions (such as `AddSecretClient`,
`AddBlobServiceClient`) provided by individual Azure SDK libraries are convenience
wrappers built on top of `AddAzureClient` — they handle any service-specific
credential or configuration concerns for you. Library authors who want to publish
custom credential sources should see
[For Library Authors: Custom Credential Resolvers](#for-library-authors-custom-credential-resolvers).

## Simple Configuration Example

Use `GetAzureClientSettings` to create client settings from configuration. This
automatically configures Azure credential resolution.

**appsettings.json:**
```json
{
  "MyClient": {
    "Endpoint": "https://myservice.azure.com",
    "Credential": {
      "CredentialSource": "AzureCli"
    }
  }
}
```

```C# Snippet:Azure_Core_Samples_AzureClient_SimpleConfiguration
ConfigurationManager configuration = new();
configuration.AddJsonFile("appsettings.json");

// GetAzureClientSettings resolves the credential automatically via the built-in AzureCredentialResolver
MyClientSettings settings = configuration.GetAzureClientSettings<MyClientSettings>("MyClient");
MyClient client = new(settings);
```

## Simple Dependency Injection Example

Use `AddAzureClient` to register an Azure client with the DI container. This
automatically adds the built-in `AzureCredentialResolver` so credentials are
resolved from configuration.

**appsettings.json:**
```json
{
  "MyClient": {
    "Endpoint": "https://myservice.azure.com",
    "Credential": {
      "CredentialSource": "AzureCli"
    }
  }
}
```

```C# Snippet:Azure_Core_Samples_AzureClient_SimpleDI
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

// AddAzureClient resolves the credential automatically via the built-in AzureCredentialResolver
builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

IServiceProvider provider = builder.Services.BuildServiceProvider();
MyClient client = provider.GetRequiredService<MyClient>();
```

All settings are configurable from `IConfiguration`, but you can optionally provide
a callback to override values programmatically after they are bound from configuration:

```C# Snippet:Azure_Core_Samples_AzureClient_SimpleDIOverride
builder.AddAzureClient<MyClient, MyClientSettings>("MyClient", settings =>
{
    settings.Options.NetworkTimeout = TimeSpan.FromSeconds(60);
});
```

## Keyed Services Example

Register multiple instances of the same client type with different configurations
using keyed services.

**appsettings.json:**
```json
{
  "PrimaryClient": {
    "Endpoint": "https://primary.azure.com",
    "Credential": {
      "CredentialSource": "AzureCli"
    }
  },
  "SecondaryClient": {
    "Endpoint": "https://secondary.azure.com",
    "Credential": {
      "CredentialSource": "AzureCli"
    }
  }
}
```

```C# Snippet:Azure_Core_Samples_AzureClient_KeyedServices
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddKeyedAzureClient<MyClient, MyClientSettings>("primary", "PrimaryClient");
builder.AddKeyedAzureClient<MyClient, MyClientSettings>("secondary", "SecondaryClient");

IServiceProvider provider = builder.Services.BuildServiceProvider();
MyClient primary = provider.GetRequiredKeyedService<MyClient>("primary");
MyClient secondary = provider.GetRequiredKeyedService<MyClient>("secondary");
```

## Resolving Credentials Directly

If you need a credential separately from a client settings object — for example, to
share one credential across multiple non-`ClientSettings` consumers, or to handle
both token credentials and inline API keys at the same call site — use
`GetAzureCredentialSettings`:

```C# Snippet:Azure_Core_Samples_AzureClient_GetCredentialSettings
CredentialSettings credential = configuration.GetAzureCredentialSettings("MyClient:Credential");

if (credential?.TokenProvider is TokenCredential token)
{
    // Use the resolved TokenCredential.
}
else if (credential?.CredentialSource == "apikeycredential" && credential.Key is string key)
{
    // Use the inline API key.
}
else
{
    // Section missing, or no resolver claimed it.
}
```

`GetAzureCredentialSettings` returns `null` only when the named section does not
exist. When the section exists, the returned `CredentialSettings` always exposes
the bound `Key`, `CredentialSource`, and `AdditionalProperties` — for inline ApiKey
sections `TokenProvider` is `null` and the caller dispatches on `CredentialSource`
to use the `Key` directly. It never throws.

## Chaining Additional Configuration

`AddAzureClient` accepts an optional `Action<TSettings>` callback that lets you
override settings programmatically after they are bound from `IConfiguration`:

```C# Snippet:Azure_Core_Samples_AzureClient_ChainingAdditionalConfiguration
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

builder.AddAzureClient<MyClient, MyClientSettings>("MyClient", settings =>
{
    settings.Options.NetworkTimeout = TimeSpan.FromSeconds(60);
});
```

The same overload is available on `AddKeyedAzureClient`. For non-DI scenarios,
`GetAzureClientSettings<T>` has equivalent overloads that take a callback for
overriding either the settings or the credential configuration section.

## Common Client Configuration

Every Azure SDK client settings class contains an `Options` property that inherits
from `ClientOptions`. This means the `Diagnostics` and `Retry` sections are always
available for any client, regardless of the specific service.

```json
{
  "MyClient": {
    "Credential": {
      "CredentialSource": "AzureCliCredential"
    },
    "Options": {
      "Diagnostics": {
        "ApplicationId": "my-app",
        "IsLoggingEnabled": true,
        "IsTelemetryEnabled": true,
        "IsDistributedTracingEnabled": true,
        "IsLoggingContentEnabled": false,
        "LoggedContentSizeLimit": 8192,
        "LoggedHeaderNames": [ "x-ms-request-id", "x-ms-client-request-id" ],
        "LoggedQueryParameters": [ "api-version" ]
      },
      "Retry": {
        "MaxRetries": 3,
        "Delay": "00:00:00.800",
        "MaxDelay": "00:01:00",
        "Mode": "Exponential",
        "NetworkTimeout": "00:01:40"
      }
    }
  }
}
```

Individual clients may define additional service-specific properties on their
`ClientOptions` subclass. Any public settable property on the client's options
class can be set via configuration using the same property name. The configuration
property names always match the property names on the options class.

## Credential Configuration

The `Credential` section in configuration controls how Azure credentials are
resolved. You can specify which credential source to use and provide additional
properties. The `CredentialSource` value is case-insensitive.

### Common Properties

The following properties are available for all token credential sources (not
applicable to `ApiKeyCredential`). Credential option classes also inherit from
`ClientOptions`, so the `Diagnostics` and `Retry` sections shown in
[Common Client Configuration](#common-client-configuration) are available within
the `Credential` section as well.

```json
{
  "Credential": {
    "CredentialSource": "AzureCliCredential",
    "AdditionallyAllowedTenants": [ "*" ]
  }
}
```

### Credential Sources

> **ApiKeyCredential note:** `ApiKeyCredential` is a configuration-schema source
> recognized by `System.ClientModel`, but `AzureCredentialResolver` does not
> claim it. `GetAzureCredentialSettings` still returns a populated
> `CredentialSettings` for an inline API-key section (with `Key`,
> `CredentialSource`, and `AdditionalProperties` bound) but with `TokenProvider`
> set to `null`. Service-specific Azure clients that accept an API key inspect
> `Credential.CredentialSource` themselves at construction time and read
> `Credential.Key` directly. From an application-author perspective nothing
> changes — `AddAzureClient`/`GetAzureClientSettings<T>` still bind the
> `Credential` section as documented; the resolver chain just doesn't synthesize
> a `TokenCredential` for the API-key case.

**ApiKeyCredential:**
```json
{
  "Credential": {
    "CredentialSource": "ApiKeyCredential"
    // "Key" should be loaded from an environment variable or Key Vault secret
    // e.g., environment variable MyClient__Credential__Key
  }
}
```

**AzureCliCredential:**
```json
{
  "Credential": {
    "CredentialSource": "AzureCliCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "Subscription": "my-subscription-name",
    "ProcessTimeout": "00:00:30"
  }
}
```

**AzureDeveloperCliCredential:**
```json
{
  "Credential": {
    "CredentialSource": "AzureDeveloperCliCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ProcessTimeout": "00:00:30"
  }
}
```

**AzurePipelinesCredential:**
```json
{
  "Credential": {
    "CredentialSource": "AzurePipelinesCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ClientId": "00000000-0000-0000-0000-000000000000",
    "ServiceConnectionId": "00000000-0000-0000-0000-000000000000",
    "SystemAccessToken": "$(System.AccessToken)",
    "DisableInstanceDiscovery": false,
    "TokenCachePersistenceOptions": {
      "Name": "my-app-cache",
      "UnsafeAllowUnencryptedStorage": false
    }
  }
}
```

**AzurePowerShellCredential:**
```json
{
  "Credential": {
    "CredentialSource": "AzurePowerShellCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ProcessTimeout": "00:00:30"
  }
}
```

**BrokerCredential:**
```json
{
  "Credential": {
    "CredentialSource": "BrokerCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "UseDefaultBrokerAccount": true,
    "IsLegacyMsaPassthroughEnabled": false,
    "DisableInstanceDiscovery": false,
    "DisableAutomaticAuthentication": false,
    "TokenCachePersistenceOptions": {
      "Name": "my-app-cache",
      "UnsafeAllowUnencryptedStorage": false
    }
  }
}
```

> `BrokerCredential` requires the `Azure.Identity.Broker` package.

**EnvironmentCredential:**
```json
{
  "Credential": {
    "CredentialSource": "EnvironmentCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ClientId": "00000000-0000-0000-0000-000000000000",
    "ClientSecret": "...",
    "ClientCertificatePath": "/path/to/cert.pem",
    "ClientCertificatePassword": "...",
    "SendCertificateChain": false,
    "DisableInstanceDiscovery": false
  }
}
```

> `EnvironmentCredential` resolves authentication in priority order: client secret → client
> certificate. Only one set of auth properties needs to be configured.
> Username/password (ROPC) authentication is not supported via configuration.

**InteractiveBrowserCredential:**
```json
{
  "Credential": {
    "CredentialSource": "InteractiveBrowserCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ClientId": "00000000-0000-0000-0000-000000000000",
    "LoginHint": "user@example.com",
    "RedirectUri": "http://localhost:8400",
    "DisableInstanceDiscovery": false,
    "DisableAutomaticAuthentication": false,
    "TokenCachePersistenceOptions": {
      "Name": "my-app-cache",
      "UnsafeAllowUnencryptedStorage": false
    },
    "BrowserCustomization": {
      "SuccessMessage": "Authentication complete. You can close this window.",
      "ErrorMessage": "Authentication failed. Please try again."
    }
  }
}
```

**ManagedIdentityCredential:**
```json
{
  "Credential": {
    "CredentialSource": "ManagedIdentityCredential",
    "ManagedIdentityIdKind": "ClientId",
    "ManagedIdentityId": "00000000-0000-0000-0000-000000000000"
  }
}
```

`ManagedIdentityIdKind` can be `SystemAssigned`, `ClientId`, `ResourceId`, or `ObjectId`.

**ManagedIdentityAsFederatedIdentityCredential:**
```json
{
  "Credential": {
    "CredentialSource": "ManagedIdentityAsFederatedIdentityCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ClientId": "00000000-0000-0000-0000-000000000000",
    "ManagedIdentityIdKind": "ClientId",
    "ManagedIdentityId": "00000000-0000-0000-0000-000000000000",
    "AzureCloud": "public",
    "DisableInstanceDiscovery": false,
    "TokenCachePersistenceOptions": {
      "Name": "my-app-cache",
      "UnsafeAllowUnencryptedStorage": false
    }
  }
}
```

`ManagedIdentityIdKind` can be `ClientId`, `ResourceId`, or `ObjectId`. `AzureCloud` can be `public`, `usgov`, or `china`.

**VisualStudioCodeCredential:**
```json
{
  "Credential": {
    "CredentialSource": "VisualStudioCodeCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000"
  }
}
```

> `VisualStudioCodeCredential` requires the `Azure.Identity.Broker` package.

**VisualStudioCredential:**
```json
{
  "Credential": {
    "CredentialSource": "VisualStudioCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ProcessTimeout": "00:00:30"
  }
}
```

**WorkloadIdentityCredential:**
```json
{
  "Credential": {
    "CredentialSource": "WorkloadIdentityCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ClientId": "00000000-0000-0000-0000-000000000000",
    "TokenFilePath": "/path/to/token",
    "IsAzureProxyEnabled": false,
    "DisableInstanceDiscovery": false
  }
}
```

> `TokenFilePath` falls back to the `AZURE_FEDERATED_TOKEN_FILE` environment variable
> when not specified in configuration.

## Configuration Reference Syntax

Use reference syntax to share credential configuration across multiple clients.
Reference another configuration value using a `$` followed by the path to the
section you want to reference.

**appsettings.json:**
```json
{
  "Shared": {
    "Credential": {
      "CredentialSource": "AzureCli"
    }
  },
  "Client1": {
    "Endpoint": "https://service1.azure.com",
    "Credential": "$Shared:Credential"
  },
  "Client2": {
    "Endpoint": "https://service2.azure.com",
    "Credential": "$Shared:Credential"
  }
}
```

```C# Snippet:Azure_Core_Samples_AzureClient_ConfigReference
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddKeyedAzureClient<MyClient, MyClientSettings>("svc1", "Client1");
builder.AddKeyedAzureClient<MyClient, MyClientSettings>("svc2", "Client2");
```

## For Library Authors: Custom Credential Resolvers

> This section is for authors of Azure SDK libraries (or third-party libraries
> that integrate with the configuration system). Application authors who consume
> Azure SDK clients via `AddXxxClient` extensions do not need to read this section
> — service-specific extensions handle any custom credential sources internally.

Credential resolution is driven by a chain of
`System.ClientModel.Primitives.CredentialResolver` instances. The built-in
`AzureCredentialResolver` handles the token-based credential sources documented
under [Credential Sources](#credential-sources). `ApiKeyCredential` sections are
intentionally not claimed by the resolver — service-specific clients that
accept an API key dispatch on `Credential.CredentialSource` themselves and read
`Credential.Key` directly. Library authors can publish their own
`CredentialResolver` to handle new credential source values (for example, a
secret-manager-backed source defined by their library).

### Implementing a Resolver

```C# Snippet:Azure_Core_Samples_AzureClient_CustomCredentialResolver
public sealed class MyVaultCredentialResolver : CredentialResolver
{
    public override bool TryResolve(
        IConfigurationSection credentialSection,
        out AuthenticationTokenProvider provider)
    {
        if (credentialSection?["CredentialSource"] is not "MyVaultCredential")
        {
            provider = null;
            return false;
        }

        provider = new MyVaultTokenCredential(credentialSection["VaultUri"]);
        return true;
    }
}
```

A resolver should return `false` when it does not recognize the section so the
next resolver in the chain gets a chance. Caller-supplied resolvers are evaluated
before the built-in `AzureCredentialResolver` — register a custom resolver and it
will win for matching source values, but built-in Azure handling remains intact
for everything else. Source values should be unique; overriding a built-in source
name is an anti-pattern.

### Registering the Resolver in Your `AddXxxClient` Extension

Service-specific `AddXxxClient` extensions should register any credential
resolvers their service requires, so application authors don't have to think about
it. Use `AddCredentialResolver<T>` (from `System.ClientModel`) — registrations are
idempotent so repeated calls from multiple `AddXxxClient` invocations are safe.

```C# Snippet:Azure_Core_Samples_AzureClient_AddMyClientWithAzure
public static IClientBuilder AddMyClient(
    this IHostApplicationBuilder builder,
    string sectionName)
{
    builder.Services.AddCredentialResolver<MyVaultCredentialResolver>();
    return builder.AddAzureClient<MyClient, MyClientSettings>(sectionName);
}
```

`AddAzureClient` automatically registers `AzureCredentialResolver`, so the Azure
built-in chain is already in place.

### Composing with `AddClient` Instead of `AddAzureClient`

If you are building on top of `System.ClientModel`'s base `AddClient` rather than
`AddAzureClient`, call `AddAzureCredentialResolver` to bring in the Azure built-in
resolver alongside your custom one. Both registrations are idempotent.

```C# Snippet:Azure_Core_Samples_AzureClient_AddMyClientWithBase
public static IClientBuilder AddMyClient(
    this IHostApplicationBuilder builder,
    string sectionName)
{
    builder.AddAzureCredentialResolver();
    builder.Services.AddCredentialResolver<MyVaultCredentialResolver>();
    return builder.AddClient<MyClient, MyClientSettings>(sectionName);
}
```

### Standalone (Non-DI) Use

For non-DI scenarios — for example, console tools that call `GetAzureClientSettings`
or `GetAzureCredentialSettings` directly — resolvers can be passed as arguments
without any DI container:

```C# Snippet:Azure_Core_Samples_AzureClient_StandaloneCustomResolver
MyClientSettings settings = configuration.GetAzureClientSettings<MyClientSettings>(
    "MyClient",
    new MyVaultCredentialResolver());

CredentialSettings credential = configuration.GetAzureCredentialSettings(
    "MyClient:Credential",
    new MyVaultCredentialResolver());
```

The built-in `AzureCredentialResolver` is appended automatically; you only pass the
custom resolvers your call site needs.

## Related Documentation

- [System.ClientModel Configuration and Dependency Injection](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ConfigurationAndDependencyInjection.md) — Base configuration patterns
- [System.ClientModel Experimental Features](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ExperimentalFeatures.md) — SCME0002 diagnostic details
- [Azure.Core Experimental Features](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ExperimentalFeatures.md) — Identity-specific experimental APIs
