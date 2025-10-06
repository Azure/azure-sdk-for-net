# Downloading and verifying a transparent statement

<!-- cspell:ignore cose -->

This sample demonstrates how to download and verify a transparent statement for a given transaction.

To get started, you'll need the service URL.

## Create a client

Create a new `CodeTransparencyClient` that interacts with the service without explicit credentials (if the service allows it or if you only need publicly accessible data). Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample_CreateClient
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
```

## Download the transparent statement

The receipt alone contains only the inclusion proof and signature. You also need the original signed statement (`COSE_Sign1`) that was submitted for integrity verification.

The easiest approach is to download both the receipt and the signed statement together as a single transparent statement. The receipt is added to the unprotected header of the signed statement.

```C# Snippet:CodeTransparencySample2_GetEntryStatement
Response<BinaryData> transparentStatementResponse = await client.GetEntryStatementAsync(entryId);
```

### Raw receipt

If you already have the signed statement as a separate file, you can download just the raw receipt.

```C# Snippet:CodeTransparencySample2_GetRawReceipt
Response<BinaryData> receipt = await client.GetEntryAsync(entryId);
```

## Verify

Verification proves that the signed statement was registered in the immutable ledger for your service. Cryptographic verification requires three things: the original signed statement, the receipt, and the service public key. The public key is available at a well-known service endpoint. Verification runs locally.

The following examples use a default public key resolver to obtain the keys for verification.

### Using a transparent statement

The receipt included in the unprotected header of the signed statement contains the service endpoint used to download the public keys.

```C# Snippet:CodeTransparencyVerification
Response<BinaryData> transparentStatementResponse = client.GetEntryStatement(entryId);
byte[] transparentStatementBytes = transparentStatementResponse.Value.ToArray();
try
{
    client.RunTransparentStatementVerification(transparentStatementBytes);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
```

### Verify a file without knowing the service endpoint

The receipt contains the issuer information needed to create the client instance. An alternate constructor automatically extracts the issuer URL.

```C# Snippet:CodeTransparencyVerificationUsingTransparentStatementFile
byte[] transparentStatementBytes = File.ReadAllBytes("transparent_statement.cose");
try
{
    CodeTransparencyClient client = new(transparentStatementBytes);
    client.RunTransparentStatementVerification(transparentStatementBytes);
    Console.WriteLine("Verification succeeded: The statement was registered in the immutable ledger.");
}
catch (Exception e)
{
    Console.WriteLine($"Verification failed: {e.Message}");
}
```

### Using a receipt and a signed statement

Alternatively, you can provide separate files for the receipt and the signed statement, plus a `JsonWebKey` obtained from the service:

```C# Snippet:CodeTransparencyVerification_VerifyReceiptAndInputSignedStatement
JsonWebKey jsonWebKey = new JsonWebKey(<.....>);
byte[] inputSignedStatement = readFileBytes("<input_signed_claims>");
byte[] inputReceipt = readFileBytes("<input_receipt>");
try
{
    CcfReceiptVerifier.VerifyTransparentStatementReceipt(jsonWebKey, inputReceipt, inputSignedStatement);
    Console.WriteLine("Verification succeeded: The statement was registered in the immutable ledger.");
}
catch (Exception e)
{
    Console.WriteLine($"Verification failed: {e.Message}");
}
```

