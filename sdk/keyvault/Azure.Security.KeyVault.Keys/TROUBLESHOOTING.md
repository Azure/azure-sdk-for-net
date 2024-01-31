# Troubleshooting Azure Key Vault Keys SDK Issues

The `Azure.Security.KeyVault.Keys` package provides APIs for operations on both Azure Key Vault and Managed HSMs using
both the `KeyClient` and `CryptographyClient` classes. This troubleshooting guide contains steps for diagnosing issues
specific to the `Azure.Security.KeyVault.Keys` package.

See our [Azure Key Vault SDK Troubleshooting Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/TROUBLESHOOTING.md)
to troubleshoot issues common to the Azure Key Vault SDKs for .NET.

## Table of Contents

* [Troubleshooting Azure.Security.KeyVault.Keys Issues](#troubleshooting-azuresecuritykeyvaultkeys-issues)
  * [Serialized JSON Web Key Does Not Conform to IETF Standards](#serialized-json-web-key-does-not-conform-to-ietf-standards)

## Troubleshooting Azure.Security.KeyVault.Keys Issues

### Serialized JSON Web Key does not Conform to IETF Standards

If you try to serialize an instance of the `JsonWebKey` (JWK) class defined by the `Azure.Security.KeyVault.Keys` package,
the output may not conform to [RFC 7517](https://datatracker.ietf.org/doc/html/rfc7517).

To properly serialize or deserialize a `JsonWebKey`, you must use .NET's `System.Text.Json` serialization as shown
in [our samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/samples/Sample7_SerializeJsonWebKey.md).
