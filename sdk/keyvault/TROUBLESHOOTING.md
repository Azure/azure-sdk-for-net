# Troubleshooting Azure Key Vault SDK Issues

The Azure Key Vault SDKs for .NET use a common HTTP pipeline and authentication to create, update, and delete secrets,
keys, and certificates in Key Vault and Managed HSM. This troubleshooting guide contains steps for diagnosing issues
common to these SDKs.

For any package-specific troubleshooting guides, see any of the following:

* [Troubleshooting Azure Key Vault Administration SDK Issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/TROUBLESHOOTING.md)
* [Troubleshooting Azure Key Vault Certificates SDK Issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/TROUBLESHOOTING.md)
* [Troubleshooting Azure Key Vault Keys SDK Issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/TROUBLESHOOTING.md)
* [Troubleshooting Azure Key Vault Secrets SDK Issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Secrets/TROUBLESHOOTING.md)

See [Azure SDK diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md)
for help diagnosing various problems across all our Azure SDKs for .NET.

## Table of Contents

* [Troubleshooting Authentication Issues](#troubleshooting-authentication-issues)
  * [HTTP 401 Errors](#http-401-errors)
    * [Frequent HTTP 401 Errors in Logs](#frequent-http-401-errors-in-logs)
    * [AKV10032: Invalid issuer](#akv10032-invalid-issuer)
    * [Other Authentication Issues](#other-authentication-issues)
  * [HTTP 403 Errors](#http-403-errors)
    * [Operation Not Permitted](#operation-not-permitted)
    * [Access Denied to First Party Service](#access-denied-to-first-party-service)
  * [Other Authentication Errors](#other-authentication-issues)
    * [Multi-tenant Authentication Issues](#multi-tenant-authentication-issues)
    * [Incorrect Challenge Resource](#incorrect-challenge-resource)
* [Other Service Errors](#other-service-errors)
  * [HTTP 429: Too Many Request](#http-429-too-many-requests)
* [Support](#support)

## Troubleshooting Authentication Issues

### HTTP 401 Errors

HTTP 401 errors may indicate problems authenticating.

#### Frequent HTTP 401 Errors in Logs

Most often, this is expected. Azure Key Vault issues a challenge for initial requests that force authentication. You may
see these errors most often during application startup, but may also see these periodically during the application's
lifetime when authentication tokens are near expiration.

If you are not seeing subsequent exceptions from the Key Vault SDKs, authentication challenges are likely the cause.

#### AKV10032: Invalid issuer

You may see an error similar to:

```text
Azure.RequestFailedException : Service request failed.
Status: 401 (Unauthorized)

Content:
{"error":{"code":"Unauthorized","message":"AKV10032: Invalid issuer. Expected one of https://sts.windows.net/{tenant 1}/, found https://sts.windows.net/{tenant 2}/."}}
```

This is most often caused by being logged into a different tenant than the Key Vault authenticates.
See our [DefaultAzureCredential] documentation to see the order credentials are read. You may be logged into a different
tenant for one credential that gets read before another credential. For example, you might be logged into Visual Studio
under the wrong tenant even though you're logged into the Azure CLI under the right tenant.

Automatic tenant discovery support has been added when referencing package `Azure.Identity` version
1.5.0 or newer, and any of the following Key Vault SDK package versions or newer:

Package | Minimum Version
--- | ---
`Azure.Security.KeyVault.Administration` | 4.1.0
`Azure.Security.KeyVault.Certificates` | 4.3.0
`Azure.Security.KeyVault.Keys` | 4.3.0
`Azure.Security.KeyVault.Secrets` | 4.3.0

Upgrading to the package versions should resolve any "Invalid Issuer" errors as long as the application or user is a
member of the resource's tenant.

#### Other Authentication Issues

If you are using the `Azure.Identity` package - which contains [DefaultAzureCredential] - to authenticate requests to
Azure Key Vault, please see our [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md).

### HTTP 403 Errors

HTTP 403 errors indicate the user is not authorized to perform a specific operation in Key Vault or Managed HSM.

#### Operation Not Permitted

You may see an error similar to:

```text
Azure.RequestFailedException : Service request failed.
Status: 403 (Forbidden)

Content:
{"error":{"code":"Forbidden","message":"Operation decrypt is not permitted on this key.","innererror":{"code":"KeyOperationForbidden"}}}
```

The operation and inner `code` may vary, but the rest of the text will indicate which operation is not permitted.
This error indicates that the authenticated application or user does not have permissions to perform that operation,
though the cause may vary.

1. Check that the application or user has the appropriate permissions:
   * [Access policies](https://learn.microsoft.com/azure/key-vault/general/assign-access-policy) (Key Vault)
   * [Role-Based Access Control (RBAC)](https://learn.microsoft.com/azure/key-vault/general/rbac-guide) (Key Vault and Managed HSM)
2. If the appropriate permissions are assigned to your application or user, make sure you are authenticating as that user.
   If using the [DefaultAzureCredential] a different credential might've been used than one you expected.
   [Enable logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#logging)
   and you will see which credential the [DefaultAzureCredential] used as shown below, and why previously-attempted credentials
   were rejected.

   ```text
   [Informational] DefaultAzureCredential credential selected: Azure.Identity.EnvironmentCredential
   ```

#### Access Denied to First Party Service

You may see an error similar to:

```text
Azure.RequestFailedException : Service request failed.
Status: 403 (Forbidden)

Content:
{"error":{"code":"Forbidden","message":"Access denied to first party service. ...","innererror":{"code":"AccessDenied"}}}
```

The error `message` may also contain the tenant ID (`tid`) and application ID (`appid`). This error may occur because:

1. You have the **Allow trust services** option enabled and are trying to access the Key Vault from a service not on
   [this list](https://learn.microsoft.com/azure/key-vault/general/overview-vnet-service-endpoints#trusted-services) of
   trusted services.
2. You are authenticated against a Microsoft Account (MSA) in Visual Studio or another credential provider. See
   [above](#operation-not-permitted) for troubleshooting steps.

### Other Authentication Errors

See our [Azure.Identity troubleshooting guide] for general guidance on authentication errors.

#### Multi-tenant Authentication Issues

If an `AuthenticationFailedException` is thrown with a message similar to:

> The current credential is not configured to acquire tokens for tenant

See our [troubleshooting guide for multi-tenant authentication issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md#troubleshoot-multi-tenant-authentication-issues).
Read our [release notes](https://aka.ms/azsdk/blog/multi-tenant-guidance) for more information about this change.

#### Incorrect Challenge Resource

If an `InvalidOperationException` is thrown with a message similar to:

> The challenge resource 'myvault.vault.azure.net' does not match the requested domain. Set DisableChallengeResourceVerification to true in your client options to disable. See https://aka.ms/azsdk/blog/vault-uri for more information.

Check that the resources is expected - that you're not receiving a challenge from an unknown host which may indicate an incorrect request URI.
If it is correct but you are using a mock service or non-transparent proxy for testing, set the `DisableChallengeResourceVerification` to `true` in your client options:

```C#
SecretClientOptions options = new SecretClientOptions()
{
   DisableChallengeResourceVerification = true
};

SecretClient client = new SecretClient(vaultUri, credential, options);
```

Read our [release notes](https://aka.ms/azsdk/blog/vault-uri) for more information about this change.

## Other Service Errors

To troubleshoot additional HTTP service errors not described below,
see [Azure Key Vault REST API Error Codes](https://learn.microsoft.com/azure/key-vault/general/rest-error-codes).

### HTTP 429: Too Many Requests

If you get an exception or see logs that describe HTTP 429, you may be making too many requests to Key Vault too quickly.

Possible solutions include:

1. Use a singleton for any `CertificateClient`, `KeyClient`, or `SecretClient` in your application for a single Key Vault.
   How you code this will depend on what application configuration library you use. You can find several examples using
   our [Microsoft.Extensions.Azure](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/extensions/Microsoft.Extensions.Azure/README.md)
   package designed for configuring [ASP.NET](https://learn.microsoft.com/aspnet/core/fundamentals/configuration)
   and other [.NET applications](https://learn.microsoft.com/dotnet/core/extensions/configuration).
2. Use a single instance of [DefaultAzureCredential] or other credential you use to authenticate your clients for each
   Key Vault or Managed HSM endpoint you need to access.
3. You could cache a certificate, key, or secret in memory for a time to reduce calls to retrieve them. See our
   [caching proxy sample](https://learn.microsoft.com/samples/azure/azure-sdk-for-net/azure-key-vault-proxy/)
   for one possible implementation.
4. Use Azure App Configuration for storing non-secrets and references to Key Vault secrets. Storing all app configuration
   in Key Vault will increase the likelihood of requests being throttled as more application instances are started. See
   [our sample](https://github.com/Azure/azure-sdk-for-net/blob/main/samples/AppSecretsConfig/README.md) for more information.
5. If you are performing encryption or decryption operations, consider using wrap and unwrap operations
   for a symmetric key which may also improve application throughput.

See our [Azure Key Vault throttling guide](https://learn.microsoft.com/azure/key-vault/general/overview-throttling)
for more information.

## Support

For additional support, please search our [existing issues](https://github.com/Azure/azure-sdk-for-net/issues) or [open a new issue](https://github.com/Azure/azure-sdk-for-net/issues/new/choose).
You may also find existing answers on community sites like [Stack Overflow](https://stackoverflow.com/questions/tagged/azure-keyvault+.net).

[Azure.Identity troubleshooting guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/TROUBLESHOOTING.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
