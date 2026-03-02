# Configuration and Dependency Injection for Azure SDK Clients

This document demonstrates how to use the configuration and dependency injection
features with Azure SDK clients. These extensions build on top of the
[System.ClientModel configuration support](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ConfigurationAndDependencyInjection.md)
and add Azure-specific credential handling.

> [!NOTE]
> These APIs are experimental and marked with diagnostic ID `SCME0002`.
> See the [Experimental Features](https://github.com/Azure/azure-sdk-for-net/blob/release/Azure.Identity_1.18.0/sdk/identity/Azure.Identity/src/docs/ExperimentalFeatures.md) documentation for suppression guidance.

> [!IMPORTANT]
> Not all Azure SDK clients support this feature yet. Support is being rolled out incrementally. A client supports configuration and dependency injection if it has a constructor that accepts a single parameter inheriting from `System.ClientModel.Primitives.ClientSettings`.

> [!NOTE]
> For each of the examples using environment variable configuration the name is derived from the convention defined [here](https://learn.microsoft.com/dotnet/core/extensions/configuration-providers#environment-variable-configuration-provider).

## Table of Contents

- [How It Works](#how-it-works)
- [Simple Configuration Example](#simple-configuration-example)
- [Simple Dependency Injection Example](#simple-dependency-injection-example)
- [Keyed Services Example](#keyed-services-example)
- [Using WithAzureCredential Explicitly](#using-withazurecredential-explicitly)
- [Common Client Configuration](#common-client-configuration)
- [Credential Configuration](#credential-configuration)
  - [Common Properties](#common-properties)
  - [Credential Sources](#credential-sources)
- [Configuration Reference Syntax](#configuration-reference-syntax)

## How It Works

The `Azure.Identity` package provides `AddAzureClient` and `GetAzureClientSettings`
extension methods that wrap the base `System.ClientModel` configuration methods. The
key difference is that `AddAzureClient` automatically calls `WithAzureCredential` to
configure Azure credential resolution. This means you don't need to manually set up
token credentials — they are resolved from your configuration's `Credential` section
automatically.

If you prefer more control, you can use the base `AddClient` method from
`System.ClientModel` and call `WithAzureCredential` yourself.

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

```csharp
ConfigurationManager configuration = new();
configuration.AddJsonFile("appsettings.json");

// GetAzureClientSettings calls WithAzureCredential automatically
MyClientSettings settings = configuration.GetAzureClientSettings<MyClientSettings>("MyClient");
MyClient client = new(settings);

```

## Simple Dependency Injection Example

Use `AddAzureClient` to register an Azure client with the DI container. This
automatically calls `WithAzureCredential` to configure credential resolution.

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

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

// AddAzureClient calls WithAzureCredential automatically
builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

IServiceProvider provider = builder.Services.BuildServiceProvider();
MyClient client = provider.GetRequiredService<MyClient>();

```

All settings are configurable from `IConfiguration`, but you can optionally provide
a callback to override values programmatically after they are bound from configuration:

```csharp
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

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddKeyedAzureClient<MyClient, MyClientSettings>("primary", "PrimaryClient");
builder.AddKeyedAzureClient<MyClient, MyClientSettings>("secondary", "SecondaryClient");

IServiceProvider provider = builder.Services.BuildServiceProvider();
MyClient primary = provider.GetRequiredKeyedService<MyClient>("primary");
MyClient secondary = provider.GetRequiredKeyedService<MyClient>("secondary");

```

## Using WithAzureCredential Explicitly

If you want to use the base `System.ClientModel` `AddClient` method while still
getting Azure credential resolution, you can call `WithAzureCredential` explicitly:

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

// Use base AddClient and call WithAzureCredential explicitly
builder.AddClient<MyClient, MyClientSettings>("MyClient")
    .WithAzureCredential();

```

This is equivalent to calling `AddAzureClient` and gives you access to the
`IClientBuilder` for additional chaining such as `PostConfigure`.

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

// Chain WithAzureCredential with PostConfigure
builder.AddClient<MyClient, MyClientSettings>("MyClient")
    .WithAzureCredential()
    .PostConfigure(settings =>
    {
        // Additional programmatic configuration
    });

```

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
    "CredentialProcessTimeout": "00:00:30"
  }
}
```

**AzureDeveloperCliCredential:**
```json
{
  "Credential": {
    "CredentialSource": "AzureDeveloperCliCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "CredentialProcessTimeout": "00:00:30"
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
    "AzurePipelinesServiceConnectionId": "00000000-0000-0000-0000-000000000000",
    "AzurePipelinesSystemAccessToken": "$(System.AccessToken)",
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
    "CredentialProcessTimeout": "00:00:30"
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

**EnvironmentCredential:**
```json
{
  "Credential": {
    "CredentialSource": "EnvironmentCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "DisableInstanceDiscovery": false
  }
}
```

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

**VisualStudioCredential:**
```json
{
  "Credential": {
    "CredentialSource": "VisualStudioCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "CredentialProcessTimeout": "00:00:30"
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
    "IsAzureProxyEnabled": false,
    "DisableInstanceDiscovery": false
  }
}
```

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

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddKeyedAzureClient<MyClient, MyClientSettings>("svc1", "Client1");
builder.AddKeyedAzureClient<MyClient, MyClientSettings>("svc2", "Client2");

```

## Related Documentation

- [System.ClientModel Configuration and Dependency Injection](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ConfigurationAndDependencyInjection.md) — Base configuration patterns
- [System.ClientModel Experimental Features](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ExperimentalFeatures.md) — SCME0002 diagnostic details
- [Azure.Identity Experimental Features](https://github.com/Azure/azure-sdk-for-net/blob/release/Azure.Identity_1.18.0/sdk/identity/Azure.Identity/src/docs/ExperimentalFeatures.md) — Identity-specific experimental APIs
