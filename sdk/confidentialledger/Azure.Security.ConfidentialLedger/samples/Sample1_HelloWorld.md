# Hello World — Create a client, append entries and check status

This sample demonstrates the basics of the Azure Confidential Ledger client library: creating a client, appending a ledger entry, checking transaction status, and retrieving a receipt.

## Create a ConfidentialLedgerClient

To interact with Azure Confidential Ledger, you need to instantiate a `ConfidentialLedgerClient`. You can use a ledger URI and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials).

The ledger URI is available from the Azure Portal page for your confidential ledger under the `Ledger URI` field in the `Properties` section.

```C# Snippet:ConfidentialLedger_CreateClient
var ledgerClient = new ConfidentialLedgerClient(new Uri("https://my-ledger-url.confidential-ledger.azure.com"), new DefaultAzureCredential());
```

## Append an entry to the ledger

Use `PostLedgerEntry` to write an entry. The operation returns a transaction ID that you can use to check status and retrieve a receipt.

```C# Snippet:ConfidentialLedger_AppendToLedger
Operation postOperation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello world!" }));

string transactionId = postOperation.Id;
Console.WriteLine($"Appended transaction with Id: {transactionId}");
```

## Check transaction status

After appending an entry you can verify that the transaction has been committed.

```C# Snippet:ConfidentialLedger_GetStatus
Response statusResponse = ledgerClient.GetTransactionStatus(transactionId, new RequestContext());

string status = JsonDocument.Parse(statusResponse.Content)
    .RootElement
    .GetProperty("state")
    .GetString();

Console.WriteLine($"Transaction status: {status}");

// Wait for the entry to be committed
while (status == "Pending")
{
    statusResponse = ledgerClient.GetTransactionStatus(transactionId, new RequestContext());
    status = JsonDocument.Parse(statusResponse.Content)
        .RootElement
        .GetProperty("state")
        .GetString();
}

Console.WriteLine($"Transaction status: {status}");
```

## Get a receipt

Once the transaction is committed you can retrieve a cryptographic receipt.

```C# Snippet:ConfidentialLedger_GetReceipt
Response receiptResponse = ledgerClient.GetReceipt(transactionId, new RequestContext());
string receiptJson = new StreamReader(receiptResponse.ContentStream).ReadToEnd();

Console.WriteLine(receiptJson);
```
