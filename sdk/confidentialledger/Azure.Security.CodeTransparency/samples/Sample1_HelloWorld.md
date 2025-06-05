# Submission of a signature envelope to the service

<!-- cspell:ignore cose -->

This sample demonstrates how to submit your signature envelope (`COSE_Sign1`) to the service.

To get started, you'll need a url of the service.

Then, you will also need to have a valid `COSE_Sign1` envelope file. There are many ways you can obtain such an envelope, the assumption is that you have it already.

## Create a client

To create a new `CodeTransparencyClient` that will interact with the service, without explicit credentials if the service allows it or if you 
want to get the publicly accessible data only. Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample1_CreateClient
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"), null);
```

## Submit the file

The most basic usage is to submit a valid signature file to the service. Acceptance of the submission is a long running operation which is why the response will contain the operation id.

```C# Snippet:CodeTransparencySample1_SendSignature
FileStream fileStream = File.OpenRead("signature.cose");
BinaryData content = BinaryData.FromStream(fileStream);
Operation<GetOperationResult> operation = await client.CreateEntryAsync(content);
```

## Verify if operation was successful

If you want to be sure that the submission completed successfully it is necessary to check the status of the operation. The successful operation means that the signature was accepted by the service and it was countersigned, which in turn means you can get the cryptographic receipt afterwards.

Another important part of the operation check is that it will contain an identifier (entry ID) to be used to get the transaction receipt.

```C# Snippet:CodeTransparencySample1_WaitForResult
Response<GetOperationResult> response = await operation.WaitForCompletionAsync();
GetOperationResult value = response.Value;
Console.WriteLine($"The entry id to use to get the entry and receipt is {{{value.EntryId}}}");
```
