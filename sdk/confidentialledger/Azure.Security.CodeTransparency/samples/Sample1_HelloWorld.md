# Submit a signed statement to the service

<!-- cspell:ignore cose -->

This sample demonstrates how to submit your signed statement (`COSE_Sign1`) to the service.

To get started, you'll need the service URL.

You will also need a valid `COSE_Sign1` file. There are many ways to obtain one; this sample assumes you already have one.

## Create a client

Create a new `CodeTransparencyClient` that interacts with the service without explicit credentials (if the service allows it or if you only need publicly accessible data). Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample_CreateClient
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
```

## Submit the file

The most basic usage submits a valid signature file to the service. The response will contain the receipt bytes.

```C# Snippet:CodeTransparencySubmissionSyncReceipt
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
FileStream fileStream = File.OpenRead("signature.cose");
BinaryData content = BinaryData.FromStream(fileStream);
bool waitForCommit = true;
Response<BinaryData> receiptResponse = await client.CreateEntryAsync(content, waitForCommit);
```

## Transparent statement

Once you have the receipt it can be added to the unprotected header of the signed statement to create a transparent statement. The embedded-receipts header value is a CBOR array of receipts. The transparent statement can be distributed to verify this registration.

```C# Snippet:CodeTransparencySample1_CreateStatement
BinaryData receipt = receiptResponse.Value;
// Add the receipt to the embedded-receipts unprotected header of the signed statement to create a transparent statement.
CoseSign1Message signedStatement = CoseMessage.DecodeSign1(content.ToArray());
CborWriter cborWriter = new CborWriter();
cborWriter.WriteStartArray(1);
cborWriter.WriteByteString(receipt.ToArray());
cborWriter.WriteEndArray();
signedStatement.UnprotectedHeaders[new CoseHeaderLabel(CcfReceipt.CoseHeaderEmbeddedReceipts)] =
    CoseHeaderValue.FromEncodedValue(cborWriter.Encode());
byte[] transparentStatement = signedStatement.Encode();
```

Alternatively you can use the entry ID to retrieve the transparent statement from the service. The entry ID (registration transaction id) can be extracted directly from the receipt, which works regardless of whether the service committed the entry inline or via a `303 See Other` redirect.

```C# Snippet:CodeTransparencySample1_ExtractEntryId
string entryId = CcfReceipt.GetRegistrationTransactionId(receipt.ToArray());
```

```C# Snippet:CodeTransparencySample1_DownloadStatement
Response<BinaryData> transparentStatementResponse = client.GetEntryStatement(entryId);
```
