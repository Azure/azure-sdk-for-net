# Create, Retrieve and Delete a Secret Reference

The AppConfiguration service supports KeyVault Secret reference settings.
Secret references are settings that follow specific JSON schema for the `Value`, and the `application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8` content type.
The `Azure.Data.AppConfiguration` library provides a strongly-typed way of managing Secret references.
This sample shows how to use the library to create, retrieve, and delete Secret references.

## Create a Secret Reference

To create a secret reference, use the `SecretReferenceConfigurationSetting` class:

```C# Snippet:Sample_CreateSecretReference
var secretReferenceSetting = new SecretReferenceConfigurationSetting("setting", new Uri("https://<keyvault_name>.vault.azure.net/secrets/<secret_name>"));
```

## Set a Secret Reference

The `SecretReferenceConfigurationSetting` inherits from the `ConfigurationSetting` class and can be passed to any method that accepts the `ConfigurationSetting`.

To set the secret reference, pass the instance to the `SetConfigurationSetting` method:

```C# Snippet:Sample_SetSecretReference
client.SetConfigurationSetting(secretReferenceSetting);
```

## Retrieve a Secret Reference

You can use the `GetConfigurationSetting` method to retrieve the secret reference.

```C# Snippet:Sample_GetSecretReference
Response<ConfigurationSetting> response = client.GetConfigurationSetting("setting");
if (response.Value is SecretReferenceConfigurationSetting secretReference)
{
    Console.WriteLine($"Setting {secretReference.Key} references {secretReference.SecretId}");
}
```

## Delete a Secret Reference

Use the `DeleteConfigurationSetting` method to remove the secret reference:

```C# Snippet:Sample_DeleteSecretReference
client.DeleteConfigurationSetting(secretReferenceSetting);
```
