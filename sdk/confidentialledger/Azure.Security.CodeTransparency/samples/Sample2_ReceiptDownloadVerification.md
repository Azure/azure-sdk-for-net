# Download and verification of a transparent statement

<!-- cspell:ignore cose -->

This sample demonstrates how to download the transparent statement from the service for a given transaction.
It will also show how to verify it.

To get started, you'll need a URL for the service.

## Create a client

To create a new `CodeTransparencyClient` that will interact with the service without explicit credentials (if the service allows it, or if you only need publicly accessible data). Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample_CreateClient
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
```

## Download the transparent statement

The receipt on its own contains only the inclusion proof and the signature. You also need the original signed statement (`COSE_Sign1`) that was submitted to perform integrity verification. 

The easiest way is to download both the receipt and the signed statement together as a transparent statement. The receipt will be added to the unprotected header of the signed statement.

```C# Snippet:CodeTransparencySample2_GetEntryStatement
Response<BinaryData> transparentStatementResponse = await client.GetEntryStatementAsync(entryId);
```

### Raw receipt

If you already have the signed statement as a separate file, you can download only the raw receipt.

```C# Snippet:CodeTransparencySample2_GetRawReceipt
Response<BinaryData> receipt = await client.GetEntryAsync(entryId);
```

## Verify

Verification proves that the signed statement was registered in the immutable ledger for your service. Cryptographic verification needs three things: the original signed statement, the receipt, and the service public key. The latter is publicly accessible and advertised at a well-known service location. Verification runs locally.

The following examples use a default public key resolver to obtain the keys for verification.

### Using a transparent statement

The receipt will contain the service endpoint, which is used to download the public keys.

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

Alternatively, you can provide your own `JsonWebKey`, the receipt, and the corresponding signed claims:

```C# Snippet:CodeTransparencySample2_VerifyReceiptAndInputSignedStatement
// Create a JsonWebKey
JsonWebKey jsonWebKey = new JsonWebKey(<.....>);
byte[] inputSignedStatement = readFileBytes("<input_signed_claims");

try
{
    CcfReceiptVerifier.VerifyTransparentStatementReceipt(jsonWebKey, transparentStatementBytes, inputSignedStatement);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
```

### Verify a file without knowing the endpoint

The receipt contains issuer information needed to create the client instance. An alternative constructor allows automatic extraction of the issuer URL when creating an instance.

```C# Snippet:CodeTransparencyVerificationUsingTransparentStatementFile
byte[] transparentStatementBytes = File.ReadAllBytes("transparent_statement.cose");
try
{
    new CodeTransparencyClient(transparentStatementBytes).RunTransparentStatementVerification(transparentStatementBytes);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
```

