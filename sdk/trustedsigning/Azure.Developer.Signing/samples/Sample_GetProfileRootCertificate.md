# # Azure.Developer.Signing samples - Get certificate profile sign root certificate

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/trustedsigning/Azure.Developer.Signing/README.md#getting-started) for details.

# Get certificate profile sign root certificate

Interaction with the sign root certificate operation requires a `CertificateProfile` client. Certificates can be converted into valid X509 certificates using the `X509Certificate2` class from `System.Security.Cryptography.X509Certificates` namespace.

```C# Snippet:Azure_Developer_Signing_GetSignRootCertificate
CertificateProfile certificateProfileClient = new SigningClient(region, credential).GetCertificateProfileClient();

Response<BinaryData> response = certificateProfileClient.GetSignRootCertificate(accountName, profileName);

byte[] rootCertificate = response.Value.ToArray();
```
