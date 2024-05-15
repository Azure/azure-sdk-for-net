# # Azure.Developer.Signing samples - Get customer extended key usages

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/trustedsigning/Azure.Developer.Signing/README.md#getting-started) for details.

## Get customer extended key usages

The extended key usages are a piece of data used to describe the purpose of a certificate. This sample demonstrates how to get the available customer extended key usages from a certificate profile.

```C# Snippet:Azure_Developer_Signing_GetExtendedKeyUsages
CertificateProfile certificateProfileClient = new SigningClient(credential).GetCertificateProfileClient(region);

List<string> ekus = new();

foreach (BinaryData item in certificateProfileClient.GetExtendedKeyUsages(accountName, profileName, null))
{
    JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
    string eku = result.GetProperty("eku").ToString();

    ekus.Add(eku);
}
```
