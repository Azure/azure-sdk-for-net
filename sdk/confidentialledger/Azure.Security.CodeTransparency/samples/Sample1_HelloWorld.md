# Submission of a signature envelope to the service

<!-- cspell:ignore cose -->

This sample demonstrates how to submit your signature envelope (`COSE_Sign1`) to the service.

To get started, you'll need a url of the service.

Then, you will also need to have a valid `COSE_Sign1` envelope file. There are many ways you can obtain such an envelope, the assumption is that you have it already.

## Create a client

To create a new `CodeTransparencyClient` that will interact with the service, without explicit credentials if the service allows it or if you 
want to get the publicly accessible data only. Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample_CreateClient
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
```

## Submit the file

The most basic usage is to submit a valid signature file to the service. Acceptance of the submission is a long running operation which is why the response will contain the operation id.

```C# Snippet:CodeTransparencySubmission
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
FileStream fileStream = File.OpenRead("signature.cose");
BinaryData content = BinaryData.FromStream(fileStream);
Operation<BinaryData> operation = await client.CreateEntryAsync(WaitUntil.Started, content);
```

## Verify if operation was successful

If you want to be sure that the submission completed successfully it is necessary to check the status of the operation. The successful operation means that the signature was accepted by the service and it was countersigned, which in turn means you can get the cryptographic receipt afterwards.

Another important part of the operation check is that it will contain an identifier (entry ID) to be used to get the transaction receipt.

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

Console.WriteLine($"The entry id to use to get the receipt and Transparent Statement is {{{entryId}}}");
```
