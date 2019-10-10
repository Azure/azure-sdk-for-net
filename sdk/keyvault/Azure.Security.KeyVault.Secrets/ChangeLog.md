# Release History

## 4.0.0-preview.5 (2019-10-07)

### Breaking changes

- `SecretBase` has been renamed to `SecretProperties`.
- `Secret` and `DeletedSecret` no longer extend `SecretProperties`, but instead contain a `SecretProperties` property named `Properties`.
- `SecretClient.Update` has been renamed to `SecretClient.UpdateProperties`.
- `SecretProperties.Vault` has been renamed to `SecretProperties.VaultUri`.
- All methods in `SecretClient` now include the word "Secret" consistent with `KeyClient` and `CertificateClient`.

## 4.0.0-preview.1 (2019-06-28)
Version 4.0.0-preview.1 is the first preview of our efforts to create a user-friendly client library for Azure Key Vault. For more information about
preview releases of other Azure SDK libraries, please visit
https://aka.ms/azure-sdk-preview1-net.

This library is not a direct replacement for `Microsoft.Azure.KeyVault`. Applications
using that library would require code changes to use `Azure.Security.KeyVault.Secrets`.
This package's
[documentation](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/Readme.md)
and
[samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/samples)
demonstrate the new API.

### Major changes from `Microsoft.Azure.KeyVault`
- Packages scoped by functionality
    - `Azure.Security.KeyVault.Secrets` contains a client for secret operations.
    - `Azure.Security.KeyVault.Keys` contains a client for key operations.
- Client instances are scoped to vaults (an instance interacts with one vault
only).
- Asynchronous and synchronous APIs in the `Azure.Security.KeyVault.Secrets` package.
- Authentication using `Azure.Identity` credentials
  - see this package's
  [documentation](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/Readme.md)
  , and the
  [Azure Identity documentation](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity)
  for more information

### `Microsoft.Azure.KeyVault` features not implemented in this release:
- Certificate management APIs
- National cloud support. This release supports public global cloud vaults,
    e.g. https://{vault-name}.vault.azure.net
