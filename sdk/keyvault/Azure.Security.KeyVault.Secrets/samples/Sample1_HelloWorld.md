# Creating, getting, updating, and deleting secrets

This sample demonstrates how to create, get, update, and delete a secret in Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](../README.md) for links and instructions.

## Creating a SecretClient

To create a new `SecretClient` to create, get, update, or delete secrets, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:SecretsSample1SecretClient
var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Creating a secret

Let's next create a secret holding a bank account credential valid for 1 year.
If the secret already exists in the Azure Key Vault, a new version of the secret is created.

```C# Snippet:SecretsSample1CreateSecret
string secretName = $"BankAccountPassword-{Guid.NewGuid()}";

var secret = new KeyVaultSecret(secretName, "f4G34fMh8v");
secret.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

client.SetSecret(secret);
```

## Getting a secret

Now let's get the bank secret from the Azure Key Vault.

```C# Snippet:SecretsSample1GetSecret
KeyVaultSecret bankSecret = client.GetSecret(secretName);
Debug.WriteLine($"Secret is returned with name {bankSecret.Name} and value {bankSecret.Value}");
```

## Updating secret properties

After one year if the bank account is still active, we need to update the expiration time of the secret.
The update method can be used to update the expiration attribute of the secret. It cannot be used to update the value of the secret.

```C# Snippet:SecretsSample1UpdateSecretProperties
bankSecret.Properties.ExpiresOn = bankSecret.Properties.ExpiresOn.Value.AddYears(1);
SecretProperties updatedSecret = client.UpdateSecretProperties(bankSecret.Properties);
Debug.WriteLine($"Secret's updated expiry time is {updatedSecret.ExpiresOn}");
```

## Updating a secret value

Assume the bank forced a password update for security purposes. Let's change the value of the secret in the Azure Key Vault.
To achieve this, we need to create a new version of the secret in the Azure Key Vault. The update operation cannot change the value of the secret.

```C# Snippet:SecretsSample1UpdateSecret
var secretNewValue = new KeyVaultSecret(secretName, "bhjd4DDgsa");
secretNewValue.Properties.ExpiresOn = DateTimeOffset.Now.AddYears(1);

client.SetSecret(secretNewValue);
```

## Deleting a secret

The bank account was closed. You need to delete its credentials from the Azure Key Vault.

```C# Snippet:SecretsSample1DeleteSecret
DeleteSecretOperation operation = client.StartDeleteSecret(secretName);
```

## Purging a deleted secret

If the Azure Key Vault is soft delete-enabled and you want to permanently delete the secret before its `ScheduledPurgeDate`,
the deleted secret needs to be purged. Before it can be purged, you need to wait until the secret is fully deleted.

```C# Snippet:SecretsSample1PurgeSecret
// You only need to wait for completion if you want to purge or recover the secret.
while (!operation.HasCompleted)
{
    Thread.Sleep(2000);

    operation.UpdateStatus();
}

client.PurgeDeletedSecret(secretName);
```

## Purging a deleted secret asynchronously

When writing asynchronous code, you can instead await `WaitForCompletionAsync` to wait indefinitely.
You can optionally pass in a `CancellationToken` to cancel waiting after a certain period or time or any other trigger you require.

```C# Snippet:SecretsSample1PurgeSecretAsync
// You only need to wait for completion if you want to purge or recover the secret.
await operation.WaitForCompletionAsync();

await client.PurgeDeletedSecretAsync(secretName);
```

## Source

To see the full example source, see:

* [Synchronous Sample1_HelloWorld.cs](../tests/samples/Sample1_HelloWorld.cs)
* [Asynchronous Sample1_HelloWorld.cs](../tests/samples/Sample1_HelloWorldAsync.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md
