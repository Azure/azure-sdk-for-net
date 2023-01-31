# Update account settings

This sample demonstrates how to retrieve and update account settings for Managed HSM.
To get started, you'll need a URI to an Azure Managed HSM. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions.

## Creating a KeyVaultSettingsClient

To create a new `KeyVaultSettingsClient`, you'll need the endpoint to an Azure Managed HSM and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `managedHsmUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:KeyVaultSettingsClient_Create
KeyVaultSettingsClient client = new KeyVaultSettingsClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

## Update a setting

You can get and update an account setting as shown below. You cannot define account settings now returned by `GetSettings()` or `GetSettingsAsync()`.

```C# Snippet:KeyVaultSettingsClient_UpdateSettingSync
KeyVaultSetting current = client.GetSetting("AllowKeyManagementOperationsThroughARM");

KeyVaultSetting updated = new KeyVaultSetting(current.Name, true);
client.UpdateSetting(updated);
```

## Updating a setting asynchronously

You can also get and update account settings asynchronously:

```C# Snippet:KeyVaultSettingsClient_UpdateSettingAsync
KeyVaultSetting current = await client.GetSettingAsync("AllowKeyManagementOperationsThroughARM");

KeyVaultSetting updated = new KeyVaultSetting(current.Name, true);
await client.UpdateSettingAsync(updated);
```

<!-- LINKS -->
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
