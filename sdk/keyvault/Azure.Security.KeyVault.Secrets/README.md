# Azure Key Vault secret client library for .NET

Azure Key Vault is a cloud service that provides a secure storage of secrets, such as passwords and database connection strings.

The Azure Key Vault secrets client library allows you to securely store and control the access to tokens, passwords, API keys, and other secrets. This library offers operations to create, retrieve, update, delete, purge, backup, restore, and list the secrets and its versions.

[Source code][secret_client_src] | [Package (NuGet)][secret_client_nuget_package] | [API reference documentation][API_reference] | [Product documentation][keyvault_docs] | [Samples][secret_client_samples] | [Migration guide][migration_guide]

## Getting started

### Install the package

Install the Azure Key Vault secrets client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Security.KeyVault.Secrets
```

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Azure Key Vault. If you need to create an Azure Key Vault, you can use the Azure Portal or [Azure CLI][azure_cli].
* Authorization to an existing Azure Key Vault using either [RBAC][rbac_guide] (recommended) or [access control][access_policy].

If you use the Azure CLI, replace `<your-resource-group-name>` and `<your-key-vault-name>` with your own, unique names:

```PowerShell
az keyvault create --resource-group <your-resource-group-name> --name <your-key-vault-name>
```

### Authenticate the client

In order to interact with the Azure Key Vault service, you'll need to create an instance of the [SecretClient][secret_client_class] class. You need a **vault url**, which you may see as "DNS Name" in the portal,
and credentials to instantiate a client object.

The examples shown below use a [`DefaultAzureCredential`][DefaultAzureCredential], which is appropriate for most scenarios including local development and production environments.
Additionally, we recommend using a managed identity for authentication in production environments.
You can find more information on different ways of authenticating and their corresponding credential types in the [Azure Identity][azure_identity] documentation.

To use the `DefaultAzureCredential` provider shown below,
or other credential providers provided with the Azure SDK, you must first install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

Instantiate a `DefaultAzureCredential` to pass to the client.
The same instance of a token credential can be used with multiple clients if they will be authenticating with the same identity.

```C# Snippet:CreateSecretClient
// Create a new secret client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
var client = new SecretClient(vaultUri: new Uri(vaultUrl), credential: new DefaultAzureCredential());

// Create a new secret using the secret client.
KeyVaultSecret secret = client.SetSecret("secret-name", "secret-value");

// Retrieve a secret using the secret client.
secret = client.GetSecret("secret-name");
```

## Key concepts

### KeyVaultSecret

A `KeyVaultSecret` is the fundamental resource within Azure Key Vault. From a developer's perspective, Azure Key Vault APIs accept and return secret values as strings.

### SecretClient

A `SecretClient` provides both synchronous and asynchronous operations in the SDK allowing for selection of a client based on an application's use case.
Once you've initialized a `SecretClient`, you can interact with secrets in Azure Key Vault.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The Azure.Security.KeyVault.Secrets package supports synchronous and asynchronous APIs.

The following section provides several code snippets using the `client` created above, covering some of the most common Azure Key Vault secret service related tasks:

### Sync examples

* [Create a secret](#create-a-secret)
* [Retrieve a secret](#retrieve-a-secret)
* [Update an existing secret](#update-an-existing-secret)
* [Delete a secret](#delete-a-secret)
* [Delete and purge a secret](#delete-and-purge-a-secret)
* [List Secrets](#list-secrets)

### Async examples

* [Create a secret asynchronously](#create-a-secret-asynchronously)
* [List secrets asynchronously](#list-secrets-asynchronously)
* [Delete a secret asynchronously](#delete-a-secret-asynchronously)

### Create a secret

`SetSecret` creates a `KeyVaultSecret` to be stored in the Azure Key Vault. If a secret with the same name already exists, then a new version of the secret is created.

```C# Snippet:CreateSecret
KeyVaultSecret secret = client.SetSecret("secret-name", "secret-value");

Console.WriteLine(secret.Name);
Console.WriteLine(secret.Value);
Console.WriteLine(secret.Properties.Version);
Console.WriteLine(secret.Properties.Enabled);
```

### Retrieve a secret

`GetSecret` retrieves a secret previously stored in the Azure Key Vault.

```C# Snippet:RetrieveSecret
KeyVaultSecret secret = client.GetSecret("secret-name");

Console.WriteLine(secret.Name);
Console.WriteLine(secret.Value);
```

### Update an existing secret

`UpdateSecretProperties` updates a secret previously stored in the Azure Key Vault. Only the attributes of the secret are updated. To update the value, call `SecretClient.SetSecret` on a secret with the same name.

```C# Snippet:UpdateSecret
KeyVaultSecret secret = client.GetSecret("secret-name");

// Clients may specify the content type of a secret to assist in interpreting the secret data when its retrieved.
secret.Properties.ContentType = "text/plain";

// You can specify additional application-specific metadata in the form of tags.
secret.Properties.Tags["foo"] = "updated tag";

SecretProperties updatedSecretProperties = client.UpdateSecretProperties(secret.Properties);

Console.WriteLine(updatedSecretProperties.Name);
Console.WriteLine(updatedSecretProperties.Version);
Console.WriteLine(updatedSecretProperties.ContentType);
```

### Delete a secret

`StartDeleteSecret` starts a long-running operation to delete a secret previously stored in the Azure Key Vault.
You can retrieve the secret immediately without waiting for the operation to complete.
When [soft-delete][soft_delete] is not enabled for the Azure Key Vault, this operation permanently deletes the secret.

```C# Snippet:DeleteSecret
DeleteSecretOperation operation = client.StartDeleteSecret("secret-name");

DeletedSecret secret = operation.Value;
Console.WriteLine(secret.Name);
Console.WriteLine(secret.Value);
```

### Delete and purge a secret

You will need to wait for the long-running operation to complete before trying to purge or recover the secret.
You can do this by calling `UpdateStatus` in a loop as shown below:

```C# Snippet:DeleteAndPurgeSecret
DeleteSecretOperation operation = client.StartDeleteSecret("secret-name");

// You only need to wait for completion if you want to purge or recover the secret.
// You should call `UpdateStatus` in another thread or after doing additional work like pumping messages.
while (!operation.HasCompleted)
{
    Thread.Sleep(2000);

    operation.UpdateStatus();
}

DeletedSecret secret = operation.Value;
client.PurgeDeletedSecret(secret.Name);
```

### List secrets

This example lists all the secrets in the specified Azure Key Vault. The value is not returned when listing all secrets. You will need to call `SecretClient.GetSecret` to retrieve the value.

```C# Snippet:ListSecrets
Pageable<SecretProperties> allSecrets = client.GetPropertiesOfSecrets();

foreach (SecretProperties secretProperties in allSecrets)
{
    Console.WriteLine(secretProperties.Name);
}
```

### Create a secret asynchronously

The asynchronous APIs are identical to their synchronous counterparts, but return with the typical "Async" suffix for asynchronous methods and return a `Task`.

This example creates a secret in the Azure Key Vault with the specified optional arguments.

```C# Snippet:CreateSecretAsync
KeyVaultSecret secret = await client.SetSecretAsync("secret-name", "secret-value");

Console.WriteLine(secret.Name);
Console.WriteLine(secret.Value);
```

### List secrets asynchronously

Listing secrets does not rely on awaiting the `GetPropertiesOfSecretsAsync` method, but returns an `AsyncPageable<SecretProperties>` that you can use with the `await foreach` statement:

```C# Snippet:ListSecretsAsync
AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

await foreach (SecretProperties secretProperties in allSecrets)
{
    Console.WriteLine(secretProperties.Name);
}
```

### Delete a secret asynchronously

When deleting a secret asynchronously before you purge it, you can await the `WaitForCompletionAsync` method on the operation.
By default, this loops indefinitely but you can cancel it by passing a `CancellationToken`.

```C# Snippet:DeleteAndPurgeSecretAsync
DeleteSecretOperation operation = await client.StartDeleteSecretAsync("secret-name");

// You only need to wait for completion if you want to purge or recover the secret.
await operation.WaitForCompletionAsync();

DeletedSecret secret = operation.Value;
await client.PurgeDeletedSecretAsync(secret.Name);
```

## Troubleshooting

See our [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/TROUBLESHOOTING.md)
for details on how to diagnose various failure scenarios.

### General

When you interact with the Azure Key Vault secret client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

For example, if you try to retrieve a secret that doesn't exist in your Azure Key Vault, a `404` error is returned, indicating `Not Found`.

```C# Snippet:SecretNotFound
try
{
    KeyVaultSecret secret = client.GetSecret("some_secret");
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the Client Request ID of the operation.

```text
Message:
    Azure.RequestFailedException : Service request failed.
    Status: 404 (Not Found)
Content:
    {"error":{"code":"SecretNotFound","message":"Secret not found: some_secret"}}

Headers:
    Cache-Control: no-cache
    Pragma: no-cache
    Server: Microsoft-IIS/10.0
    x-ms-keyvault-region: westus
    x-ms-request-id: 625f870e-10ea-41e5-8380-282e5cf768f2
    x-ms-keyvault-service-version: 1.1.0.866
    x-ms-keyvault-network-info: addr=131.107.174.199;act_addr_fam=InterNetwork;
    X-AspNet-Version: 4.0.30319
    X-Powered-By: ASP.NET
    Strict-Transport-Security: max-age=31536000;includeSubDomains
    X-Content-Type-Options: nosniff
    Date: Tue, 18 Jun 2019 16:02:11 GMT
    Content-Length: 75
    Content-Type: application/json; charset=utf-8
    Expires: -1
```

## Next steps

Several Azure Key Vault secrets client library samples are available to you in this GitHub repository. These samples provide example code for additional scenarios commonly encountered while working with Azure Key Vault:

* [Sample1_HelloWorld.md][hello_world_sample] - for working with Azure Key Vault, including:
  * Create a secret
  * Get an existing secret
  * Update an existing secret
  * Delete secret

* [Sample2_BackupAndRestore.md][backup_and_restore_sample] - contains the code snippets working with Azure Key Vault secrets, including:
  * Backup and recover a secret

* [Sample3_GetSecrets.md][get_secrets_sample] - example code for working with Azure Key Vault secrets, including:
  * Create secrets
  * List all secrets in the Key Vault
  * Update secrets in the Key Vault
  * List versions of a specified secret
  * Delete secrets from the Key Vault
  * List deleted secrets in the Key Vault

### Additional Documentation

* For more extensive documentation on Azure Key Vault, see the [API reference documentation][keyvault_rest].
* For Keys client library see [Keys client library][keys_client_library].
* For Certificates client library see [Certificates client library][certificates_client_library].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to these libraries.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact <opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[API_reference]: https://learn.microsoft.com/dotnet/api/azure.security.keyvault.secrets
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[backup_and_restore_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/samples/Sample2_BackupAndRestore.md
[certificates_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Certificates
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[get_secrets_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/samples/Sample3_GetSecrets.md
[hello_world_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/samples/Sample1_HelloWorld.md
[keys_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Keys
[keyvault_docs]: https://learn.microsoft.com/azure/key-vault/
[keyvault_rest]: https://learn.microsoft.com/rest/api/keyvault/
[nuget]: https://www.nuget.org/
[secret_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/src/SecretClient.cs
[secret_client_nuget_package]: https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets/
[secret_client_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/samples
[secret_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/src
[soft_delete]: https://learn.microsoft.com/azure/key-vault/general/soft-delete-overview
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/CONTRIBUTING.md
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[migration_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/MigrationGuide.md
[access_policy]: https://learn.microsoft.com/azure/key-vault/general/assign-access-policy
[rbac_guide]: https://learn.microsoft.com/azure/key-vault/general/rbac-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fkeyvault%2FAzure.Security.KeyVault.Secrets%2FREADME.png)
