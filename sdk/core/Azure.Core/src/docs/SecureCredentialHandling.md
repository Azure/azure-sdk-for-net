# Secure credential handling

This document describes best practices for keeping secrets out of
`appsettings.json` when configuring `System.ClientModel`-based clients.

## Never store API keys in configuration files

Configuration files such as `appsettings.json` are typically checked into
source control. Storing API keys, connection strings, or other secrets in
these files risks accidental exposure.

```json
// ❌ DON'T — secret will end up in source control
{
  "Clients": {
    "MyClient": {
      "Credential": {
        "CredentialSource": "ApiKeyCredential",
        "Key": "my-secret-key"
      }
    }
  }
}
```

If you attempt to add a `Key` property in `appsettings.json`, the JSON
Schema IntelliSense will display a validation warning reminding you not to
store secrets in configuration files.

## Recommended approaches

### 1. Environment variables

Use an environment variable to supply the API key at runtime. The .NET
configuration system automatically maps environment variables to
configuration keys using the `__` (double underscore) separator.

**appsettings.json:**

```json
{
  "Clients": {
    "MyClient": {
      "Endpoint": "https://api.example.com",
      "Credential": {
        "CredentialSource": "ApiKeyCredential"
      }
    }
  }
}
```

Set the environment variable:

```bash
# Linux / macOS
export Clients__MyClient__Credential__Key=my-secret-key

# Windows (PowerShell)
$env:Clients__MyClient__Credential__Key = "my-secret-key"
```

**Configuration code:**

```csharp
ConfigurationManager configuration = new();
configuration.AddJsonFile("appsettings.json");
configuration.AddEnvironmentVariables();

MyClientSettings settings = configuration.GetClientSettings<MyClientSettings>("Clients:MyClient");
MyClient client = new(settings);
```

> [!NOTE]
> For details on the environment variable naming convention, see
> [Environment variable configuration provider](https://learn.microsoft.com/dotnet/core/extensions/configuration-providers#environment-variable-configuration-provider).

### 2. User secrets (development)

During local development, use the .NET
[Secret Manager](https://learn.microsoft.com/aspnet/core/security/app-secrets)
tool to store secrets outside of your project tree:

```bash
dotnet user-secrets set "Clients:MyClient:Credential:Key" "my-secret-key"
```

**Configuration code:**

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.AddClient<MyClient, MyClientSettings>("Clients:MyClient");
```

User secrets are added automatically in the Development environment.

### 3. Azure Key Vault (production)

For production workloads, store secrets in
[Azure Key Vault](https://learn.microsoft.com/azure/key-vault/general/overview)
and use the
[Azure.Extensions.AspNetCore.Configuration.Secrets](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.Configuration.Secrets)
package to load them into the .NET configuration system at startup.

```bash
dotnet add package Azure.Extensions.AspNetCore.Configuration.Secrets
```

Create a secret in Key Vault. The secret manager maps `--` in secret
names to `:` in configuration keys:

```bash
az keyvault secret set \
  --vault-name my-vault \
  --name "Clients--MyClient--Credential--Key" \
  --value "my-secret-key"
```

This maps the Key Vault secret to the configuration path `Clients:MyClient:Credential:Key`. The value will not appear in your `appsettings.json`, but it will effectively act as if the secret from Key Vault is at that path.

**appsettings.json:**

```json
{
  "AzureClients": {
    "KeyVault": {
      "VaultUri": "https://my-vault.vault.azure.net/",
      "Credential": {
        "CredentialSource": "ManagedIdentityCredential",
        "ManagedIdentityIdKind": "ClientId",
        "ManagedIdentityId": "<your-client-id>"
      }
    }
  },
  "Clients": {
    "MyClient": {
      "Endpoint": "https://api.example.com",
      "Credential": {
        "CredentialSource": "ApiKeyCredential"
      }
    }
  }
}
```

**Configuration code:**

```csharp
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

builder.Configuration.AddKeyVaultSecrets("AzureClients:KeyVault");

builder.AddClient<MyClient, MyClientSettings>("Clients:MyClient");
```
