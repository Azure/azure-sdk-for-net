# Listing secrets, secret versions, and deleted secrets

This sample demonstrates how to list secrets, versions of a secret, and listing deleted secrets in a soft delete-enabled Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md) for links and instructions.

## Creating a SecretClient

To create a new `SecretClient` to create, get, update, or delete secrets, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:SecretsSample3SecretClient
var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating secrets

Let's next create secrets holding a bank account credential and storage account password valid for 1 year.
If the secret already exists in the Azure Key Vault, a new version of the secret is created.

```C# Snippet:SecretsSample3CreateSecret
string bankSecretName = $"BankAccountPassword-{Guid.NewGuid()}";
string storageSecretName = $"StorageAccountPassword{Guid.NewGuid()}";

var bankSecret = new KeyVaultSecret(bankSecretName, "f4G34fMh8v");
bankSecret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

var storageSecret = new KeyVaultSecret(storageSecretName, "f4G34fMh8v547");
storageSecret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

client.SetSecret(bankSecret);
client.SetSecret(storageSecret);
```

## Listing secrets

We need to check if any of the secrets are sharing the same values. Let's list the secrets and print their values.
List operations don't return the secrets with values. Instead, they return the name and other information aboutt the secret.
So, for each returned secret name we must call `GetSecret` to get the secret with its secret value.

```C# Snippet:SecretsSample3ListSecrets
Dictionary<string, string> secretValues = new Dictionary<string, string>();

IEnumerable<SecretProperties> secrets = client.GetPropertiesOfSecrets();
foreach (SecretProperties secret in secrets)
{
    // Getting a disabled secret will fail, so skip disabled secrets.
    if (!secret.Enabled.GetValueOrDefault())
    {
        continue;
    }

    KeyVaultSecret secretWithValue = client.GetSecret(secret.Name);
    if (secretValues.ContainsKey(secretWithValue.Value))
    {
        Debug.WriteLine($"Secret {secretWithValue.Name} shares a value with secret {secretValues[secretWithValue.Value]}");
    }
    else
    {
        secretValues.Add(secretWithValue.Value, secretWithValue.Name);
    }
}
```

## Listing secret versions

The bank account password was updated, so you want to update the secret in Azure Key Vault to ensure it reflects the new password.
Calling `SetSecret` on an existing secret creates a new version of the secret in the Azure Key Vault with the new value.
You need to check that all previous values are different from the new value.

```C# Snippet:SecretsSample3ListSecretVersions
string newBankSecretPassword = "sskdjfsdasdjsd";

IEnumerable<SecretProperties> secretVersions = client.GetPropertiesOfSecretVersions(bankSecretName);
foreach (SecretProperties secret in secretVersions)
{
    // Secret versions may also be disabled if compromised and new versions generated, so skip disabled versions, too.
    if (!secret.Enabled.GetValueOrDefault())
    {
        continue;
    }

    KeyVaultSecret oldBankSecret = client.GetSecret(secret.Name, secret.Version);
    if (newBankSecretPassword == oldBankSecret.Value)
    {
        Debug.WriteLine($"Secret {secret.Name} reuses a password");
    }
}

client.SetSecret(bankSecretName, newBankSecretPassword);
```

## Deleting secrets

The bank account was closed. You need to delete the credential from the Azure Key Vault.
You also want to delete information about your storage account.
To list deleted secrets, we also need to wait until they are fully deleted.

```C# Snippet:SecretsSample3DeleteSecrets
DeleteSecretOperation bankSecretOperation = client.StartDeleteSecret(bankSecretName);
DeleteSecretOperation storageSecretOperation = client.StartDeleteSecret(storageSecretName);

// You only need to wait for completion if you want to purge or recover the secret.
while (!bankSecretOperation.HasCompleted || !storageSecretOperation.HasCompleted)
{
    Thread.Sleep(2000);

    bankSecretOperation.UpdateStatus();
    storageSecretOperation.UpdateStatus();
}
```

## Listing deleted secrets

You can now list all the deleted and non-purged secrets, assuming Azure Key Vault is soft delete-enabled.

```C# Snippet:SecretsSample3ListDeletedSecrets
IEnumerable<DeletedSecret> secretsDeleted = client.GetDeletedSecrets();
foreach (DeletedSecret secret in secretsDeleted)
{
    Debug.WriteLine($"Deleted secret's recovery Id {secret.RecoveryId}");
}
```

## Source

To see the full example source, see:

* [Synchronous Sample3_GetSecrets.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/tests/samples/Sample3_GetSecrets.cs)
* [Asynchronous Sample3_GetSecrets.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/tests/samples/Sample3_GetSecretsAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
