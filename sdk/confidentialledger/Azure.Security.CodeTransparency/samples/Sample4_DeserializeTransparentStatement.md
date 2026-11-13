# Deserialize transparent statement

The transparent statement file's byte structure follows the CBOR format. Specifically, it uses the COSE_Sign1 signing envelope format with the added receipt(s) in the unprotected headers. The file also contains the original signed payload.

After you verify the transparent statement, you can deserialize its parts to inspect them for your own needs.

```C# Snippet:DeserializeTransparentStatement_Sample1
// Read the transparent statement bytes from disk.
byte[] transparentStatement = File.ReadAllBytes("<input_file>");

CoseSign1Message inputSignedStatement;
try
{
    inputSignedStatement = CoseMessage.DecodeSign1(transparentStatement);
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to decode transparent statement: {ex.Message}");
    return; // Stop if decoding fails.
}

// Access the signed payload.
ReadOnlyMemory<byte> payload = inputSignedStatement.Content ?? ReadOnlyMemory<byte>.Empty;
// Use payload as needed.

// Access the embedded receipts in unprotected headers.
if (!inputSignedStatement.UnprotectedHeaders.TryGetValue(
        new CoseHeaderLabel(CcfReceipt.CoseHeaderEmbeddedReceipts),
        out CoseHeaderValue embeddedReceipts))
{
    Console.WriteLine("Receipts are not present.");
    return;
}

// Parse CBOR array of receipt COSE_Sign1 messages.
var reader = new CborReader(embeddedReceipts.EncodedValue);
if (reader.PeekState() != CborReaderState.StartArray)
{
    Console.WriteLine("Embedded receipts value is not a CBOR array.");
    return;
}

reader.ReadStartArray();
var receiptBytesList = new List<byte[]>();
while (reader.PeekState() != CborReaderState.EndArray)
{
    receiptBytesList.Add(reader.ReadByteString());
}
reader.ReadEndArray();

for (int i = 0; i < receiptBytesList.Count; i++)
{
    try
    {
        CoseSign1Message receipt = CoseMessage.DecodeSign1(receiptBytesList[i]);
        // Inspect receipt (headers/signature) as needed.
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to decode receipt #{i}: {ex.Message}");
    }
}
```

