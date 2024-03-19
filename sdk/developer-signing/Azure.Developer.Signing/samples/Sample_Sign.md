# Azure.Developer.Signing samples - Signing

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/developersigning/Azure.Developer.Signing/README.md#getting-started) for details.

# Submit a signing action

The signing action is used to sign a certificate. This sample demonstrates how to submit a request to sign a byte array using a signature algorithm.

```C# Snippet:Azure_Developer_Signing_SigningBytes
    CertificateProfile certificateProfileClient = new SigningClient(credential).GetCertificateProfileClient(region);

    using RequestContent content = RequestContent.Create(new
    {
        signatureAlgorithm,
        digest,
    });

    Operation<BinaryData> operation = certificateProfileClient.Sign(WaitUntil.Completed, accountName, profileName, content);
    BinaryData responseData = operation.Value;

    JsonElement result = JsonDocument.Parse(responseData.ToStream()).RootElement;
```
