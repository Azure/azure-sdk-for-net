---
page_type: sample
languages:
- csharp
products:
- azure
- azure-key-vault
name: Cache certain responses from Key Vault
description: Shows how to implement a pipeline policy to cache certain responses from Key Vault to mitigate rate limiting.
---

# Azure Key Vault Proxy

This is a sample showing how to use an `HttpPipelinePolicy` to cache and proxy secrets, keys, and certificates from Azure Key Vault. The [Azure.Core](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md) packages provides a number of useful HTTP pipeline policies like configurable retries, logging, and more; and, you can add your own policies.

## Getting started

To use this sample, you will need to install the [Azure.Core](https://nuget.org/packages/Azure.Core) package, which is installed automatically when installing any of the Azure Key Vault packages:

* [Azure.Security.KeyVault.Certificates](https://nuget.org/packages/Azure.Security.KeyVault.Certificates/)
* [Azure.Security.KeyVault.Keys](https://nuget.org/packages/Azure.Security.KeyVault.Keys/)
* [Azure.Security.KeyVault.Secrets](https://nuget.org/packages/Azure.Security.KeyVault.Secrets/)

Once you build this project, you can reference this sample in your own project by either:

* Adding a `<ProjectReference>` to this sample project in your own project, or
* Running `dotnet pack` on this sample project, publish it to a private NuGet source, and add a `<PackageReference>` to `AzureSamples.Security.KeyVault.Proxy`.

After you reference this sample, in your own project source, add the following:

```csharp
using AzureSamples.Security.KeyVault.Proxy;
```

## Examples

All HTTP clients for Azure.* packages allow you to customize the HTTP pipeline using their respective client options classes, such as the `SecretClientOptions` class below:

```csharp
SecretClientOptions options = new SecretClientOptions();
options.AddPolicy(new KeyVaultProxy(), HttpPipelinePosition.PerCall);

SecretClient client = new SecretClient(
    new Uri("https://myvault.vault.azure.net"),
    new DefaultAzureCredential(),
    options);
```

Whenever you make a call to a resource with given a unique URI, it will be cached, by default, for 1 hour. You can change the default time-to-live (TTL) like so:

```csharp
SecretClientOptions options = new SecretClientOptions();
options.AddPolicy(new KeyVaultProxy(TimeSpan.FromSeconds(30)), HttpPipelinePosition.PerCall);
```

When the resource has expired, the next request will go to the server and a successful `GET` response for certificates, keys, or secrets will be cached.

## License

This project is licensed under the [MIT license](https://github.com/Azure/azure-sdk-for-net/blob/main/LICENSE.txt).
