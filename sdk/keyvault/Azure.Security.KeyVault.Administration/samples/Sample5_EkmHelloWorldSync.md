# Managing an External Key Manager (EKM) connection (Sync)

This sample demonstrates how to create, inspect, and delete an External Key Manager (EKM) connection on an Azure Managed HSM using `KeyVaultEkmClient` synchronously.
To get started, you'll need a URI to an Azure Managed HSM. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions.

## Creating a KeyVaultEkmClient

To create a new `KeyVaultEkmClient`, you'll need the endpoint to an Azure Managed HSM and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

```C# Snippet:HelloCreateKeyVaultEkmClient
KeyVaultEkmClient client = new KeyVaultEkmClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

## Creating an EKM connection


```C# Snippet:EkmCreateConnectionSync
// Read the EKM proxy's CA certificate bytes (DER- or PEM-encoded).
byte[] serverCaCertificate = File.ReadAllBytes("ekm-proxy-ca.cer");

// Build the EKM connection. Host is the FQDN of the EKM proxy.
KeyVaultEkmConnection connection = new KeyVaultEkmConnection("ekm.contoso.com", new[] { serverCaCertificate })
{
    PathPrefix = "v1",
    ServerSubjectCommonName = "ekm.contoso.com",
};

Response<KeyVaultEkmConnection> created = Client.CreateEkmConnection(connection);
```

## Reading the current EKM connection

Use `GetEkmConnection` to inspect the EKM connection currently configured on the Managed HSM.

```C# Snippet:EkmGetConnectionSync
// Retrieve the current EKM connection.
Response<KeyVaultEkmConnection> current = Client.GetEkmConnection();

Console.WriteLine($"EKM host: {current.Value.Host}");
Console.WriteLine($"Path prefix: {current.Value.PathPrefix}");
```

## Checking the EKM connection

`CheckEkmConnection` validates connectivity and authentication between the Managed HSM and the EKM proxy.

```C# Snippet:EkmCheckConnectionSync
// Verify connectivity and authentication with the EKM proxy.
Response<EkmProxyInfo> info = Client.CheckEkmConnection();
```

## Deleting an EKM connection

```C# Snippet:EkmDeleteConnectionSync
// Remove the EKM connection.
Client.DeleteEkmConnection();
```

<!-- LINKS -->
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
