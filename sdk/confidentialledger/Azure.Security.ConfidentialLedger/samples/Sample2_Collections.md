# Collections — Organize entries by collection

This sample demonstrates how to organize ledger entries into collections and retrieve entries by collection ID.

## Write entries to different collections

You can specify a `collectionId` when posting a ledger entry to organize your data.

```C# Snippet:ConfidentialLedger_Collection
ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello from Chris!", collectionId = "Chris' messages" }));

ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello from Allison!", collectionId = "Allison's messages" }));
```

## Retrieve entries without specifying a collection

When no collection ID is specified, entries are stored in the default collection. You can retrieve them by transaction ID.

```C# Snippet:ConfidentialLedger_NoCollectionId
postOperation = ledgerClient.PostLedgerEntry(
    waitUntil: WaitUntil.Completed,
    RequestContent.Create(
        new { contents = "Hello world!" }));

string content = postOperation.GetRawResponse().Content.ToString();
transactionId = postOperation.Id;
string collectionId = "subledger:0";

// Try fetching the ledger entry until it is "loaded".
Response getByCollectionResponse = default;
JsonElement rootElement = default;
bool loaded = false;

while (!loaded)
{
    // Provide both the transactionId and collectionId.
    getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId, collectionId, new RequestContext());
    rootElement = JsonDocument.Parse(getByCollectionResponse.Content).RootElement;
    loaded = rootElement.GetProperty("state").GetString() != "Loading";
}

string contents = rootElement
    .GetProperty("entry")
    .GetProperty("contents")
    .GetString();

Console.WriteLine(contents); // "Hello world!"

// Now just provide the transactionId.
getByCollectionResponse = ledgerClient.GetLedgerEntry(transactionId, null, new RequestContext());

string collectionId2 = JsonDocument.Parse(getByCollectionResponse.Content)
    .RootElement
    .GetProperty("entry")
    .GetProperty("collectionId")
    .GetString();

Console.WriteLine($"{collectionId} == {collectionId2}");
```

## Query entries by range

You can retrieve a range of ledger entries by specifying a starting and ending transaction ID.

```C# Snippet:ConfidentialLedger_RangedQuery
ledgerClient.GetLedgerEntries(fromTransactionId: "2.1", toTransactionId: collectionTransactionId);
```
