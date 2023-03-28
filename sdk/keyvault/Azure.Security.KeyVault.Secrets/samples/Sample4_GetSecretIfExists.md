# Get a secret without throwing if it is not defined

This sample demonstrates how to get a secret without throwing an exception if it is not defined.
This may be useful in some application configuration managers that attempt to fetch key/value pairs from a collection of providers and when exceptions may break startup or are otherwise costly.
To better configure ASP.NET applications or other applications that use common [.NET Configuration], see our documentation on [Azure.Extensions.AspNetCore.Configuration.Secrets].
To get started, you'll need a URI to an Azure Key Vault. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md) for links and instructions.

## Creating a SecretClient

To create a new `SecretClient` to create get a secret, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:SecretsSample4SecretClient
var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Get a secret

To prevent throwing a `RequestFailedException` when a secret does not exist, or to alter other behaviors of a specific API call, you can create a `RequestContext` and pass that to the API call:

```C# Snippet:SecretsSample4GetSecretIfExists
// Do not treat HTTP 404 responses as errors.
RequestContext context = new RequestContext();
context.AddClassifier(404, false);

// Try getting the latest application connection string using the context above.
NullableResponse<KeyVaultSecret> response = client.GetSecret("appConnectionString", null, context);
if (response.HasValue)
{
    KeyVaultSecret secret = response.Value;
    Debug.WriteLine($"Secret is returned with name {secret.Name} and value {secret.Value}");
}
```

You can also do this asynchronously:

```C# Snippet:SecretsSample4GetSecretIfExistsAsync
// Do not treat HTTP 404 responses as errors.
RequestContext context = new RequestContext();
context.AddClassifier(404, false);

// Try getting the latest application connection string using the context above.
NullableResponse<KeyVaultSecret> response = await client.GetSecretAsync("appConnectionString", null, context);
if (response.HasValue)
{
    KeyVaultSecret secret = response.Value;
    Debug.WriteLine($"Secret is returned with name {secret.Name} and value {secret.Value}");
}
```

[.NET Configuration]: https://learn.microsoft.com/dotnet/core/extensions/configuration
[Azure.Extensions.AspNetCore.Configuration.Secrets]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/extensions/Azure.Extensions.AspNetCore.Configuration.Secrets/README.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
