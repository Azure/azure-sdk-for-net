# Download and verification of receipt

<!-- cspell:ignore cose -->

This sample demonstrates how to download the receipt from the service for a given transaction.
It will also how to verify the integrity of the receipt.

To get started, you'll need a url of the service.

## Create a client

To create a new `CodeTransparencyClient` that will interact with the service, without explicit credentials if the service allows it or if you 
want to get the publicly accessible data only. Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample2_CreateClient
var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
```

## Download receipt

The receipt on its own contains only the inclusion proof and the signature. You also need the original signature (`COSE_Sign1`) which was submitted to be able to run integrity verification. 

### Embedded receipt

The easiest way is to download the receipt and the signature together which was stored after the submission. The receipt will be added to the unprotected header of the signature.

```C# Snippet:CodeTransparencySample2_GetEntryWithEmbeddedReceipt
var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
Response<BinaryData> response = await client.GetEntryAsync("4.44", true);
```

### Raw receipt

If you have the signature as a separate file already then you can download the raw receipt file.

```C# Snippet:CodeTransparencySample2_GetRawReceipt
var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
Response<BinaryData> response = await client.GetEntryAsync("4.44");
```

## Verify

Verification is the process of proving that the signature was registered in the immutable ledger in your service. The cryptographic process needs three things: the original signature, the receipt and the service public key. The latter is publicly accessible to anyone and is advertised in a well known service location. The verification process will run on your host.

The following examples will use a default public key resolver to get the keys for verification.

### Embedded receipt

When receipt is embedded in the signature then passing just the signature is enough.

```C# Snippet:CodeTransparencySample2_VerifyEntryWithEmbeddedReceipt
byte[] receiptBytes = readFileBytes("sbom.descriptor.2022-12-10.embedded.did.2023-02-13.cose");
var didDocBytes = readFileBytes("service.2023-03.did.json");
var didDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didDocBytes).RootElement);
CcfReceiptVerifier.RunVerification(receiptBytes, null, didRef => {
    Assert.AreEqual("https://preview-test.scitt.azure.net/.well-known/did.json", didRef.DidDocUrl.ToString());
    return didDoc;
});
```

### Raw receipt

If the receipt is a separate file then it needs to be passed as a second argument next to the signature.

```C# Snippet:CodeTransparencySample2_VerifyEntryAndReceipt
byte[] receiptBytes = readFileBytes("artifact.2023-03-03.receipt.did.2023-03-03.cbor");
byte[] coseSign1Bytes = readFileBytes("artifact.2023-03-03.cose");
var didDocBytes = readFileBytes("service.2023-02.did.json");
var didDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didDocBytes).RootElement);
CcfReceiptVerifier.RunVerification(receiptBytes, coseSign1Bytes, didRef => {
    Assert.AreEqual("https://127.0.0.1:42399/.well-known/did.json", didRef.DidDocUrl.ToString());
    return didDoc;
});
```