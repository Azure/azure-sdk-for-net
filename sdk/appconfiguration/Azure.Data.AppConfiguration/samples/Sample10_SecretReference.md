# Create, Retrieve and Delete a Secret Reference

App Configuration helps you use the services together by creating keys that reference values stored in Key Vault.
When App Configuration creates such keys, it stores the URIs of Key Vault values rather than the values themselves.

Your application is responsible for authenticating properly to both App Configuration and Key Vault and resolving values.
The two services don't communicate directly.

You can use the [configuration provider](https://github.com/Azure/AppConfiguration-DotnetProvider) to resolve Secret references automatically.

Secret references are settings that follow specific JSON schema for the `Value`, and the `application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8` content type.
The `Azure.Data.AppConfiguration` library provides a strongly-typed way of managing Secret references.
This sample shows how to use the library to create, retrieve, and delete Secret references.

## Create a Secret Reference

To create a secret reference, use the `SecretReferenceConfigurationSetting` class:

```C# Snippet:Sample_CreateSecretReference
var secretId = "https://keyvault_name.vault.azure.net/secrets/<secret_name>";
var secretReferenceSetting = new SecretReferenceConfigurationSetting("setting", new Uri(secretId));
```

**NOTE** you can retrieve the secret identifier from the Azure Portal or using the `KeyVaultSecret.Id` property.

## Set a Secret Reference

The `SecretReferenceConfigurationSetting` inherits from the `ConfigurationSetting` class and can be passed to any method that accepts the `ConfigurationSetting`.

To set the secret reference, pass the instance to the `SetConfigurationSetting` method:

```C# Snippet:Sample_SetSecretReference
client.SetConfigurationSetting(secretReferenceSetting);
```

## Retrieve a Secret Reference

You can use the `GetConfigurationSetting` method to retrieve the secret reference.

If you'd like to get the secret value you would need to reference the [Azure.Security.KeyVault.Secrets](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md) library and use the `KeyVaultSecretIdentifier` to parse the `SecretId`, and `SecretClient.GetSecretAsync` to get the secret value.

```C# Snippet:Sample_GetSecretReference
Response<ConfigurationSetting> response = client.GetConfigurationSetting("setting");
if (response.Value is SecretReferenceConfigurationSetting secretReference)
{
    var identifier = new KeyVaultSecretIdentifier(secretReference.SecretId);
    var secretClient = new SecretClient(identifier.VaultUri, new DefaultAzureCredential());
    var secret = await secretClient.GetSecretAsync(identifier.Name, identifier.Version);

    Console.WriteLine($"Setting {secretReference.Key} references {secretReference.SecretId} Secret Value: {secret.Value.Value}");
}
```

**NOTE**: The `KeyVaultSecretIdentifier` type was added in `Azure.Security.KeyVault.Secrets` version 4.2.0.

## Delete a Secret Reference

Use the `DeleteConfigurationSetting` method to remove the secret reference:

```C# Snippet:Sample_DeleteSecretReference
client.DeleteConfigurationSetting(secretReferenceSetting);
```
