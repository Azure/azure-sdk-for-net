# Release History

## 4.0.0-preview.5 (2019-10-07)

### Breaking changes

- `KeyType` enumeration values have been changed to match other languages, e.g. `KeyType.EllipticCurve` is now `KeyType.Ec`.
- `KeyOperations` has been renamed `KeyOperation`.
- Enumerations including `KeyCurveName`, `KeyOperation`, and `KeyType` are now structures that define well-known, supported static fields.
- `KeyBase` has been renamed to `KeyProperties`.
- `Key` and `DeletedKey` no longer extend `KeyProperties`, but instead contain a `KeyProperties` property named `Properties`.
- `KeyClient.UpdateKey` has been renamed to `KeyClient.UpdateKeyProperties`.

### Major changes

- `KeyClient.UpdateKey` and `KeyClient.UpdateKeyAsync` now allow the `keyOperations` parameter to be null, resulting in no changes to the allowed key operations.
- `RSA` and `ECDsa` support have been implemented for `CryptographyClient` to use locally if key operations and key material allow; otherwise, operations will be performed in Azure Key Vault.

## 4.0.0-preview.1 (2019-06-28)

Version 4.0.0-preview.1 is the first preview of our efforts to create a user-friendly client library for Azure Key Vault. For more information about
preview releases of other Azure SDK libraries, please visit
https://aka.ms/azure-sdk-preview1-net.

This library is not a direct replacement for `Microsoft.Azure.KeyVault`. Applications
using that library would require code changes to use `Azure.Security.KeyVault.Keys`.
This package's
[documentation](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys/Readme.md)
and
[samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys/samples)
demonstrate the new API.

### Major changes from `Microsoft.Azure.KeyVault`

- Packages scoped by functionality
  - `Azure.Security.KeyVault.Keys` contains a client for key operations.
  - `Azure.Security.KeyVault.Secrets` contains a client for secret operations.
- Client instances are scoped to vaults (an instance interacts with one vault
only).
- Asynchronous and synchronous APIs in the `Azure.Security.KeyVault.Keys` package.
- Authentication using `Azure.Identity` credentials
  - see this package's
  [documentation](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys/Readme.md)
  , and the
  [Azure Identity documentation](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity)
  for more information

### `Microsoft.Azure.KeyVault` features not implemented in this release:

- Certificate management APIs
- Cryptographic operations, e.g. sign, un/wrap, verify, en- and
decrypt
- National cloud support. This release supports public global cloud vaults,
    e.g. `https://{vault-name}.vault.azure.net`
