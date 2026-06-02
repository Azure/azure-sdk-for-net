# Registering and managing external keys

This sample demonstrates how to register a Managed HSM key whose material is held in a connected external HSM (External Key Management, or EKM), and then get, delete, and purge that key.

External keys are only supported on Managed HSM with service version `2026-01-01-preview` or newer, and the Managed HSM must be configured for EKM with an existing external key reachable by the identifier you pass to `ExternalKey`.

To get started, you'll need a URI to an EKM-connected Azure Managed HSM. See the [README][] for links and instructions.

## Creating a KeyClient

To create a new `KeyClient` to register, get, or delete external keys, you need the endpoint to an Azure Managed HSM and credentials.
You can use the [DefaultAzureCredential][] to try a number of common authentication methods optimized for both running as a service deployed to Azure and development.

In the sample below, you can set `managedHsmUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeysSample9KeyClient
var client = new KeyClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

## Registering an external key

To register an external key, build an `ExternalKey` with the identifier of the key that already exists in the connected external HSM and pass it to `CreateExternalKey`. Managed HSM stores a reference to that external material under the name you supply.

```C# Snippet:KeysSample9CreateExternalKey
string externalKeyName = $"ExternalKey-{Guid.NewGuid()}";
ExternalKey externalKey = new ExternalKey(externalId);

KeyVaultKey createdKey = client.CreateExternalKey(externalKeyName, externalKey);
Debug.WriteLine($"External key created with name {createdKey.Name} referencing external id {createdKey.Properties.ExternalKey.Id}");
```

## Getting an external key

Read the key back from Managed HSM. The `Properties.ExternalKey` reference round-trips so callers can confirm which external material is bound to the Managed HSM name.

```C# Snippet:KeysSample9GetExternalKey
KeyVaultKey fetchedKey = client.GetKey(externalKeyName);
Debug.WriteLine($"Fetched external key {fetchedKey.Name} still references external id {fetchedKey.Properties.ExternalKey.Id}");
```

## Deleting an external key

When the external key reference is no longer needed, delete it from Managed HSM. This removes the Managed HSM reference; the material in the external HSM is untouched.

```C# Snippet:KeysSample9DeleteExternalKey
DeleteKeyOperation operation = client.StartDeleteKey(externalKeyName);
```

## Purging a deleted external key

If the Managed HSM is soft delete-enabled and you want to permanently delete the key reference before its `ScheduledPurgeDate`, the deleted key needs to be purged. Before it can be purged, you need to wait until the key is fully deleted.

```C# Snippet:KeysSample9PurgeExternalKey
// You only need to wait for completion if you want to purge or recover the key.
while (!operation.HasCompleted)
{
    Thread.Sleep(2000);

    operation.UpdateStatus();
}

client.PurgeDeletedKey(externalKeyName);
```

## Purging a deleted external key asynchronously

When writing asynchronous code, you can instead await `WaitForCompletionAsync` to wait indefinitely.
You can optionally pass in a `CancellationToken` to cancel waiting after a certain period of time or any other trigger you require.

```C# Snippet:KeysSample9PurgeExternalKeyAsync
// You only need to wait for completion if you want to purge or recover the key.
await operation.WaitForCompletionAsync();

await client.PurgeDeletedKeyAsync(externalKeyName);
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md
