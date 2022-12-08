---
page_type: sample
languages:
- csharp
products:
- azure
- azure-key-vault
urlFragment: get-certificate-private-key
name: Get a Certificate Including the Private Key
description: Gets a full certificate including the private key from Azure Key Vault.
---

# Get a Certificate Including the Private Key

[Azure Key Vault certificates][azure-keyvault-certificates] are a great way to manage certificates. They allow you to set policies, automatically renew near-expiring certificates, and permit cryptographic operations with access to the private key. There are times, however, when you may want to download and use the entire certificate - including the private key - locally. You might have a legacy application, for example, that needs access to a key pair.

> [!CAUTION]
> We recommend you keep cryptographic operations using the private key - including decryption, signing, and unwrapping - in Key Vault to minimize access to the private and mitigate possible breaches with a properly secured Key Vault.

> [!NOTE]
> The functions `CertificateClient.DownloadCertificate` and `CertificateClient.DownloadCertificateAsync` were [added](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Certificates/CHANGELOG.md#420-2021-06-15) in [Azure.Security.KeyVault.Certificates](https://www.nuget.org/packages/Azure.Security.KeyVault.Certificates/4.2.0) 4.2.0. Those new functions effectively replace this sample, though we have retained this sample that shows some best practices and to notify any developers redirected here of these new functions.

Key Vault stores the public key as a managed key but the entire key pair including the private key - if created or imported as exportable - as a [secret][azure-keyvault-secrets]. This example shows you how download the key pair and uses it to encrypt and decrypt a plain text message.

## Getting Started

This sample requires creating a certificate with an exportable private key. You'll also need to download and install the [Azure CLI](https://aka.ms/azure-cli).

1. Log into Azure using the CLI:

   ```bash
   az login
   ```

2. Create a Key Vault if you haven't already:

   ```bash
   az keyvault create -n <KeyVaultName> -g <ResourceGroupName> -l <Location>
   ```

3. Create a certificate policy. You can get the default policy for a self-signed certificate as shown below:

   > [!NOTE]
   > Saving program output to a variable may vary depending on your shell.

   ```bash
   p=$(az keyvault certificate get-default-policy)
   echo $p
   ```

4. Create a certificate using that policy:

   ```bash
   az keyvault certificate create --vault-name <KeyVaultName> -n <CertificateName> -p "$p"
   ```

## Building the Sample

To build the sample:

1. Install [.NET Core 3.1](https://dot.net) or newer.

2. Run in the project directory:

   ```dotnetcli
   dotnet build
   ```

## Running the Sample

You can either run the executable you just build, or build and run the project at the same time:

```dotnetcli
dotnet run -- --vault-name <KeyVaultName> -n <CertificateName> -m "Message you want to encrypt and decrypt"
```

The sample will get information about the specified certificate, download the key pair as a secret, then encrypt and decrypt your message as a test.

## Links

- [About Azure Key Vault certificates][azure-keyvault-certificates]
- [About Azure Key Vault secrets][azure-keyvault-secrets]
- [Azure Key Vault samples](https://aka.ms/azsdk/net/keyvault/samples)

[azure-keyvault-certificates]: https://learn.microsoft.com/azure/key-vault/certificates/about-certificates
[azure-keyvault-secrets]: https://learn.microsoft.com/azure/key-vault/secrets/about-secrets
