# Managing EKM proxy private endpoints (Async)

This sample demonstrates how to create, inspect, list, and delete an External Key Manager (EKM) proxy private endpoint on an Azure Managed HSM using `KeyVaultEkmClient`.
To get started, you'll need a URI to an Azure Managed HSM. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions.

## Creating an EKM proxy private endpoint

Create a private endpoint that connects the Managed HSM EKM proxy pool to a Private Link Service. A proxy pool supports up to two private endpoints.

```C# Snippet:CreateEkmPrivateEndpointAsync
// Create an EKM proxy private endpoint. A pool may have up to two private endpoints. This is a
// long-running operation, so we wait for it to complete.
Operation<KeyVaultEkmPrivateEndpointOperation> createOperation = await Client.CreateEkmPrivateEndpointAsync(
    WaitUntil.Completed,
    _privateEndpointName,
    privateLinkServiceId,
    requestMessage: "Please approve this connection from my Managed HSM");

Console.WriteLine($"EKM private endpoint creation finished with status: {createOperation.Value.Status}");
```

## Getting an EKM proxy private endpoint

After the Private Link Service owner approves the connection, get the private endpoint to inspect its provisioning and connection states.

```C# Snippet:GetEkmPrivateEndpointAsync
// The Private Link Service owner has to approve the connection before the private endpoint can be
// used by an EKM connection.
Response<KeyVaultEkmPrivateEndpoint> privateEndpoint = await Client.GetEkmPrivateEndpointAsync(_privateEndpointName);

Console.WriteLine($"Provisioning state: {privateEndpoint.Value.ProvisioningState}");
Console.WriteLine($"Connection status: {privateEndpoint.Value.PrivateLinkServiceConnectionState?.Status}");
```

## Listing EKM proxy private endpoints

List the private endpoints configured for the Managed HSM EKM proxy pool.

```C# Snippet:GetEkmPrivateEndpointsAsync
// List all of the EKM proxy private endpoints on the Managed HSM.
Response<IReadOnlyList<KeyVaultEkmPrivateEndpoint>> privateEndpoints = await Client.GetEkmPrivateEndpointsAsync();

foreach (KeyVaultEkmPrivateEndpoint endpoint in privateEndpoints.Value)
{
    Console.WriteLine($"EKM private endpoint {endpoint.Name} is in state {endpoint.ProvisioningState}");
}
```

## Creating a private EKM connection

After the private endpoint is approved, configure the EKM connection to use it. Set `HostName` to the private endpoint name and preserve the EKM proxy's certificate subject name in `ServerSubjectCommonName`.

```C# Snippet:CreatePrivateEkmConnectionAsync
// Once the connection is approved, an EKM connection can reach the EKM proxy through the private
// endpoint. To do so, set the connection's HostName to the private endpoint's name and its
// ConnectivityMode to EkmConnectivityMode.PrivateEndpoint. Since the host is now the private endpoint's
// name rather than the proxy's real DNS name, ServerSubjectCommonName must be set so the proxy's
// certificate can still be validated.
byte[] serverCaCertificate = File.ReadAllBytes("ekm-proxy-ca.cer");
string serverSubjectCommonName = "ekm.contoso.com";
KeyVaultEkmConnection connection = new KeyVaultEkmConnection(_privateEndpointName, new[] { serverCaCertificate })
{
    PathPrefix = "/api/v1",
    ConnectivityMode = EkmConnectivityMode.PrivateEndpoint,
    ServerSubjectCommonName = serverSubjectCommonName,
};

Response<KeyVaultEkmConnection> createdConnection = await Client.CreateEkmConnectionAsync(connection);

Console.WriteLine($"EKM connection created with connectivity mode: {createdConnection.Value.ConnectivityMode}");
```

## Deleting an EKM proxy private endpoint

Delete the EKM connection before deleting the private endpoint it references.

```C# Snippet:DeleteEkmPrivateEndpointAsync
// Deletion is rejected while an EKM connection still references the private endpoint, so we delete the
// EKM connection first.
await Client.DeleteEkmConnectionAsync();

Operation<KeyVaultEkmPrivateEndpointOperation> deleteOperation = await Client.DeleteEkmPrivateEndpointAsync(
    WaitUntil.Completed, _privateEndpointName);

Console.WriteLine($"EKM private endpoint deletion finished with status: {deleteOperation.Value.Status}");
```