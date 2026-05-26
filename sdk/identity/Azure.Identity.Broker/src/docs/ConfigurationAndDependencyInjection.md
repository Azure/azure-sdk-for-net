# Configuration and Dependency Injection for Broker Credentials

This document explains how to wire the `Azure.Identity.Broker` package into
the Azure SDK configuration and dependency-injection flow so that credential
sections with `"CredentialSource": "BrokerCredential"` or
`"CredentialSource": "VisualStudioCodeCredential"` resolve to a credential
that requires this package. `BrokerCredential` produces an
`InteractiveBrowserCredential` configured with the system authentication
broker; `VisualStudioCodeCredential` produces a credential that performs SSO
with Visual Studio Code via the broker.

For everything that is not broker- or VS Code-specific (Azure CLI, Managed
Identity, Environment, Workload Identity, Chained, etc.), see the
[Azure.Core Configuration and Dependency Injection guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ConfigurationAndDependencyInjection.md).

> [!NOTE]
> These APIs are experimental and marked with diagnostic ID `SCME0002`.
> See [Experimental Features](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/docs/ExperimentalFeatures.md) for suppression guidance.

## Table of Contents

- [How It Works](#how-it-works)
- [Dependency Injection with `AddAzureClient`](#dependency-injection-with-addazureclient)
- [Standalone Configuration with `GetAzureClientSettings`](#standalone-configuration-with-getazureclientsettings)
- [Credential-Only Resolution with `GetAzureCredentialSettings`](#credential-only-resolution-with-getazurecredentialsettings)
- [Direct `System.ClientModel` `GetCredentialSettings` Call](#direct-systemclientmodel-getcredentialsettings-call)
- [Resolver Ordering](#resolver-ordering)
- [Broker `Credential` JSON Reference](#broker-credential-json-reference)

## How It Works

The Azure SDK uses a chain of `CredentialResolver` instances (defined in
`System.ClientModel.Primitives`) to bind a `Credential` configuration section
to a `TokenCredential`. Each resolver claims sections whose `CredentialSource`
value it recognizes and defers (returns `false`) for everything else.

- **`AzureCredentialResolver`** (in `Azure.Core`) is registered automatically
  by `AddAzureClient` and auto-appended by `GetAzureClientSettings` /
  `GetAzureCredentialSettings`. It claims every Azure source.
- **`BrokerCredentialResolver`** (in `Azure.Identity.Broker`, this package) is
  registered explicitly by your application. It claims `BrokerCredential` and
  `VisualStudioCodeCredential` sections (the two credential sources that
  require this package to function) and constructs the corresponding
  credential.

Until Azure.Core stops claiming `BrokerCredential` and `VisualStudioCodeCredential`
in a future release, you must register `BrokerCredentialResolver` **before**
`AzureCredentialResolver` so the broker resolver gets the first chance to
claim those sections. With the wrappers below this happens automatically.

## Dependency Injection with `AddAzureClient`

Call `AddBrokerCredentialResolver()` **before** `AddAzureClient`. `AddAzureClient`
registers the built-in `AzureCredentialResolver` for you, so both resolvers
end up in the chain with broker first.

**appsettings.json:**
```json
{
  "MyClient": {
    "Endpoint": "https://myservice.azure.com",
    "Credential": {
      "CredentialSource": "BrokerCredential",
      "TenantId": "00000000-0000-0000-0000-000000000000",
      "UseDefaultBrokerAccount": true
    }
  }
}
```

**Program.cs:**
```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Register broker first so it claims BrokerCredential sections.
builder.AddBrokerCredentialResolver();

// AddAzureClient registers AzureCredentialResolver internally as the fallback.
builder.AddAzureClient<MyClient, MyClientSettings>("MyClient");

IHost host = builder.Build();
```

The same pattern works on a plain `IServiceCollection`:

```csharp
services.AddBrokerCredentialResolver();
services.AddAzureClient<MyClient, MyClientSettings>(configuration, "MyClient");
```

`AddBrokerCredentialResolver()` is idempotent — calling it multiple times
produces a single registration.

## Standalone Configuration with `GetAzureClientSettings`

If you are not using a DI container, pass a `BrokerCredentialResolver`
instance to `GetAzureClientSettings`. The built-in `AzureCredentialResolver`
is auto-appended as the fallback, so a single new-up wires both resolvers.

```csharp
ConfigurationManager configuration = new();
configuration.AddJsonFile("appsettings.json");

MyClientSettings settings = configuration.GetAzureClientSettings<MyClientSettings>(
    "MyClient",
    new BrokerCredentialResolver());

MyClient client = new(settings);
```

## Credential-Only Resolution with `GetAzureCredentialSettings`

When you want just the credential (no client settings binding), use
`GetAzureCredentialSettings`. It behaves the same way — your resolver
runs first, the built-in Azure resolver is appended as the fallback.

```csharp
ConfigurationManager configuration = new();
configuration.AddJsonFile("appsettings.json");

CredentialSettings credential = configuration.GetAzureCredentialSettings(
    "MyClient:Credential",
    new BrokerCredentialResolver());

TokenCredential tokenCredential = (TokenCredential)credential.TokenProvider;
```

## Direct `System.ClientModel` `GetCredentialSettings` Call

If you are not using any of the Azure wrappers, you can compose the chain
yourself by passing both resolvers explicitly to the base
`System.ClientModel` `GetCredentialSettings` method:

```csharp
CredentialSettings credential = configuration.GetCredentialSettings(
    "MyClient:Credential",
    new BrokerCredentialResolver(),
    new AzureCredentialResolver()); // omit if you don't need non-broker sources
```

In this flow there is no auto-append — you control the chain order yourself.

## Resolver Ordering

`CredentialResolver` registrations are walked **in registration order** and
the first resolver to claim a section wins. Each resolver claims only the
sources it knows about:

- `BrokerCredentialResolver` claims `BrokerCredential` and
  `VisualStudioCodeCredential` only.
- `AzureCredentialResolver` claims every Azure source — including
  `BrokerCredential` and `VisualStudioCodeCredential` in the current
  Azure.Core release. (Azure.Core will stop claiming those two sources in a
  future release so the broker resolver can be registered in any order.)

Recommended composition today:

```csharp
services.AddBrokerCredentialResolver(); // first — claims BrokerCredential / VisualStudioCodeCredential
services.AddAzureCredentialResolver();  // second — fallback for everything else
```

The wrapper APIs (`AddAzureClient`, `GetAzureClientSettings`,
`GetAzureCredentialSettings`) place the built-in `AzureCredentialResolver`
**after** your explicit resolvers, so the order above is what they produce
by default.

## Broker `Credential` JSON Reference

### `BrokerCredential`

```json
{
  "Credential": {
    "CredentialSource": "BrokerCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "ClientId": "00000000-0000-0000-0000-000000000000",
    "UseDefaultBrokerAccount": true,
    "IsLegacyMsaPassthroughEnabled": false,
    "DisableInstanceDiscovery": false,
    "DisableAutomaticAuthentication": false,
    "AdditionallyAllowedTenants": [ "*" ],
    "TokenCachePersistenceOptions": {
      "Name": "my-app-cache",
      "UnsafeAllowUnencryptedStorage": false
    }
  }
}
```

| Property | Description |
| --- | --- |
| `CredentialSource` | Must be `BrokerCredential` (case-insensitive; `Broker` is also accepted). |
| `TenantId` | Azure Active Directory tenant ID. |
| `ClientId` | Optional. Application (client) ID. Defaults to the Azure SDK developer sign-on client. |
| `UseDefaultBrokerAccount` | When `true`, authenticates with the default broker account instead of prompting. |
| `IsLegacyMsaPassthroughEnabled` | Enables Microsoft Account (MSA) passthrough. |
| `DisableInstanceDiscovery` | Skips authority instance discovery (use in sovereign clouds). |
| `DisableAutomaticAuthentication` | Disables silent automatic authentication. |
| `AdditionallyAllowedTenants` | Additional tenants to allow token acquisition for. |
| `TokenCachePersistenceOptions` | Configures persistent token caching. |

### `VisualStudioCodeCredential`

```json
{
  "Credential": {
    "CredentialSource": "VisualStudioCodeCredential",
    "TenantId": "00000000-0000-0000-0000-000000000000",
    "AdditionallyAllowedTenants": [ "*" ]
  }
}
```

| Property | Description |
| --- | --- |
| `CredentialSource` | Must be `VisualStudioCodeCredential` (case-insensitive; `visualstudiocode` is also accepted). |
| `TenantId` | Optional. Tenant ID to authenticate against. |
| `AdditionallyAllowedTenants` | Additional tenants to allow token acquisition for. |
