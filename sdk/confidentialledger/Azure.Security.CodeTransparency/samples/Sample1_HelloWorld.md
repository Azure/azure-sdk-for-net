# Submission of a signed statement to the service

<!-- cspell:ignore cose -->

This sample demonstrates how to submit your signed statement (`COSE_Sign1`) to the service.

To get started, you'll need a URL for the service.

You will also need a valid `COSE_Sign1` file. There are many ways to obtain it; this sample assumes you already have one.

## Create a client

To create a new `CodeTransparencyClient` that will interact with the service without explicit credentials (if the service allows it, or if you only need publicly accessible data). Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample_CreateClient
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
```

## Submit the file

The most basic usage is to submit a valid signature file to the service. Accepting the submission is a long-running operation, which is why the response contains the operation ID.

```C# Snippet:CodeTransparencySubmission
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
FileStream fileStream = File.OpenRead("signature.cose");
BinaryData content = BinaryData.FromStream(fileStream);
Operation<BinaryData> operation = await client.CreateEntryAsync(WaitUntil.Started, content);
```

## Verify the operation was successful

To ensure the submission completed successfully, you must check the status of the operation. A successful operation means the signed statement was accepted by the service and countersigned, which in turn allows you to obtain the cryptographic receipt.

Another important aspect of checking the operation is that it returns an identifier (entry ID) used to retrieve the transparent statement or a transaction receipt.

```C# Snippet:CodeTransparencySample1_WaitForResult
Response<BinaryData> operationResult = await operation.WaitForCompletionAsync();

string entryId = string.Empty;
CborReader cborReader = new CborReader(operationResult.Value);
cborReader.ReadStartMap();
while (cborReader.PeekState() != CborReaderState.EndMap)
{
    string key = cborReader.ReadTextString();
    if (key == "EntryId")
    {
        entryId = cborReader.ReadTextString();
    }
    else
        cborReader.SkipValue();
}

Console.WriteLine($"The entry ID to use to retrieve the receipt and transparent statement is {{{entryId}}}");
```
```
