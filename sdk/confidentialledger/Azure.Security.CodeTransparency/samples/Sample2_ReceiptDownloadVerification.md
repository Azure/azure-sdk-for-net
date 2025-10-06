# Download and verification of receipt

<!-- cspell:ignore cose -->

This sample demonstrates how to download the receipt from the service for a given transaction.
It will also how to verify the integrity of the receipt.

To get started, you'll need a url of the service.

## Create a client

To create a new `CodeTransparencyClient` that will interact with the service, without explicit credentials if the service allows it or if you 
want to get the publicly accessible data only. Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample_CreateClient
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
```

## Download receipt

The receipt on its own contains only the inclusion proof and the signature. You also need the original signature (`COSE_Sign1`) which was submitted to be able to run integrity verification. 

### Embedded receipt

The easiest way is to download the receipt and the signature together which was stored after the submission. The receipt will be added to the unprotected header of the signature.

```C# Snippet:CodeTransparencySample2_GetEntryStatement
Response<BinaryData> signatureWithReceiptResponse = await client.GetEntryStatementAsync(entryId);
```

### Raw receipt

If you have the signature as a separate file already then you can download the raw receipt file.

```C# Snippet:CodeTransparencySample2_GetRawReceipt
Response<BinaryData> receipt = await client.GetEntryAsync(entryId);
```

## Verify

Verification is the process of proving that the signature was registered in the immutable ledger in your service. The cryptographic process needs three things: the original signature, the receipt and the service public key. The latter is publicly accessible to anyone and is advertised in a well known service location. The verification process will run on your host.

The following examples will use a default public key resolver to get the keys for verification.

### Embedded receipt

When receipt is embedded in the signature then passing just the signature is enough.

```C# Snippet:CodeTransparencyVerification
Response<BinaryData> transparentStatement = client.GetEntryStatement(entryId);
byte[] transparentStatementBytes = transparentStatement.Value.ToArray();

try
{
    client.RunTransparentStatementVerification(transparentStatementBytes);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
```

Alternatively, you can provide your own JsonWebKey, the receipt and the corresponding signed claims

```C# Snippet:CodeTransparencySample2_VerifyReceiptAndInputSignedStatement
// Create a JsonWebKey
JsonWebKey jsonWebKey = new JsonWebKey(<.....>);
byte[] inputSignedStatement = readFileBytes("<input_signed_claims");

try
{
    CcfReceiptVerifier.VerifyTransparentStatementReceipt(jsonWebKey, signatureWithReceiptBytes, inputSignedStatement);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
```
