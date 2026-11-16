# Collections — Organize entries by collection

This sample demonstrates how to organize ledger entries into collections and retrieve entries by collection ID.

## Write entries to different collections

You can specify a `collectionId` when posting a ledger entry to organize your data.

```C# Snippet:ConfidentialLedger_Collection
ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    new LedgerEntry("Hello from Chris!"),
    collectionId: "Chris' messages");

ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    new LedgerEntry("Hello from Allison!"),
    collectionId: "Allison's messages");
```

## Retrieve entries without specifying a collection

When no collection ID is specified, entries are stored in the default collection. You can retrieve them by transaction ID.

```C# Snippet:ConfidentialLedger_NoCollectionId
postOperation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    new LedgerEntry("Hello world!"));

transactionId = postOperation.Value.TransactionId;
string collectionId = postOperation.Value.CollectionId; // "subledger:0"

// Try fetching the ledger entry until it is "loaded".
LedgerQueryResult queryResult;
do
{
    // Provide both the transactionId and collectionId.
    queryResult = ledgerClient.GetLedgerEntry(transactionId, collectionId).Value;
}
while (queryResult.State == ConfidentialLedgerQueryState.Loading);

string contents = queryResult.Entry.Contents;

Console.WriteLine(contents); // "Hello world!"

// Now just provide the transactionId.
queryResult = ledgerClient.GetLedgerEntry(transactionId).Value;

string collectionId2 = queryResult.Entry.CollectionId;

Console.WriteLine($"{collectionId} == {collectionId2}");
```

## Query entries by range

You can retrieve a range of ledger entries by specifying a starting and ending transaction ID.

```C# Snippet:ConfidentialLedger_RangedQuery
ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: collectionTransactionId);
```
