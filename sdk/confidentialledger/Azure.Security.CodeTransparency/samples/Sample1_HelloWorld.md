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

The most basic usage submits a valid signature file to the service. Accepting the submission is a long-running operation, so the response contains the operation ID.

```C# Snippet:CodeTransparencySubmission
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
FileStream fileStream = File.OpenRead("signature.cose");
BinaryData content = BinaryData.FromStream(fileStream);
Operation<BinaryData> operation = await client.CreateEntryAsync(WaitUntil.Started, content);
```

## Verify the operation was successful

To ensure the submission completes successfully, check the status of the operation. A successful operation means the service has accepted and countersigned the signed statement, which in turn allows you to obtain the cryptographic receipt.

Checking the operation also returns an identifier (entry ID) used to retrieve the transparent statement or a transaction receipt.

```C# Snippet:CodeTransparencySample1_WaitForResult
Response<BinaryData> operationResult = await operation.WaitForCompletionAsync();
string entryId = CborUtils.GetStringValueFromCborMapByKey(operationResult.Value.ToArray(), "EntryId");
Console.WriteLine($"The entry ID to use to retrieve the receipt and transparent statement is {{{entryId}}}");
```

## Download the transparent statement

Once the operation is complete, you can download the transparent statement so you can distribute it to verify this registration.

```C# Snippet:CodeTransparencySample1_DownloadStatement
Response<BinaryData> transparentStatementResponse = client.GetEntryStatement(entryId);
```
