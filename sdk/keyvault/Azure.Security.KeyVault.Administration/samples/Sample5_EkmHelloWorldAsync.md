# Managing an External Key Manager (EKM) connection (Async)

This sample demonstrates how to create, inspect, update, and delete an External Key Manager (EKM) connection on an Azure Managed HSM using `KeyVaultEkmClient`.
To get started, you'll need a URI to an Azure Managed HSM. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions.

## Creating a KeyVaultEkmClient

To create a new `KeyVaultEkmClient`, you'll need the endpoint to an Azure Managed HSM and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `managedHsmUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:HelloCreateKeyVaultEkmClient
KeyVaultEkmClient client = new KeyVaultEkmClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

## Creating an EKM connection

Configure the Managed HSM to talk to your External Key Manager proxy by creating a `KeyVaultEkmConnection`. The connection requires the fullyQualifiedHostName of the EKM proxy and the proxy's server CA certificate. You can also set a `PathPrefix` and the expected `ServerSubjectCommonName`.

```C# Snippet:EkmCreateConnectionAsync
// Read the EKM proxy's CA certificate bytes.
byte[] serverCaCertificate = File.ReadAllBytes("ekm-proxy-ca.cer");

// Build the EKM connection with the EKM proxy's HostName
KeyVaultEkmConnection connection = new KeyVaultEkmConnection("ekm.contoso.com", new[] { serverCaCertificate })
{
    PathPrefix = "v1",
    ServerSubjectCommonName = "ekm.contoso.com",
};

// Create the EKM connection on the Managed HSM.
Response<KeyVaultEkmConnection> created = await Client.CreateEkmConnectionAsync(connection);
```

## Reading the current EKM connection

Use `GetEkmConnectionAsync` to inspect the EKM connection currently configured on the Managed HSM.

```C# Snippet:EkmGetConnectionAsync
// Retrieve the current EKM connection.
Response<KeyVaultEkmConnection> current = await Client.GetEkmConnectionAsync();

Console.WriteLine($"EKM host: {current.Value.HostName}");
Console.WriteLine($"Path prefix: {current.Value.PathPrefix}");
```

## Checking the EKM connection

`CheckEkmConnectionAsync` validates connectivity and authentication between the Managed HSM and the EKM proxy and returns metadata about the proxy.

```C# Snippet:EkmCheckConnectionAsync
// Verify connectivity and authentication with the EKM proxy.
Response<EkmProxyInfo> info = await Client.CheckEkmConnectionAsync();

Console.WriteLine($"EKM vendor: {info.Value.EkmVendor}, product: {info.Value.EkmProduct}");
```

## Retrieving the EKM client certificate

The Managed HSM presents a client certificate to the EKM proxy. Use `GetEkmCertificateAsync` to retrieve the public information about that certificate so it can be trusted by the proxy.

```C# Snippet:EkmGetCertificateAsync
// Retrieve the client certificate the Managed HSM uses to authenticate with the EKM proxy.
Response<EkmProxyClientCertificateInfo> certificateInfo = await Client.GetEkmCertificateAsync();

string subject = certificateInfo.Value.SubjectCommonName;
```

## Updating an EKM connection

Use `UpdateEkmConnectionAsync` to change properties of an existing connection — for example, to rotate the server CA certificate or change the path prefix.

```C# Snippet:EkmUpdateConnectionAsync
// Update an existing EKM connection (for example, to rotate the server CA certificate
// by replacing the value in ServerCaCertificates).
Response<KeyVaultEkmConnection> updated = await Client.UpdateEkmConnectionAsync(current.Value);
```

## Deleting an EKM connection

Use `DeleteEkmConnectionAsync` to remove the EKM connection. This operation requires the `ekm/delete` permission.

```C# Snippet:EkmDeleteConnectionAsync
// Remove the EKM connection.
await Client.DeleteEkmConnectionAsync();
```

<!-- LINKS -->
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
