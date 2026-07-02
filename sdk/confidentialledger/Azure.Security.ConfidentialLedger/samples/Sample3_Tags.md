# Tags — Create and query entries with tags

This sample demonstrates how to create ledger entries with tags and query entries by tag.

## Create a ledger entry with tags

You can attach comma-separated tags to a ledger entry when creating it. Tags enable efficient filtering when querying entries.

```C# Snippet:ConfidentialLedger_CreateLedgerEntryWithTags
RequestContent content = RequestContent.Create(new { contents = "Hello world with tags!" });
string collectionId = "my-collection";
string tags = "tag1,tag2";

Response result = await client.CreateLedgerEntryAsync(content, collectionId, tags);
```

## Query ledger entries by tag

You can retrieve entries from a specific collection filtered by a single tag. Only one tag is permitted per retrieval operation.

```C# Snippet:ConfidentialLedger_GetLedgerEntriesWithTags
string collectionIdForQuery = "my-collection";

// Specify collection ID and tag. Optionally add a range of transaction IDs.
// Only one tag is permitted in each retrieval operation.
var queryResult = client.GetLedgerEntriesAsync(collectionIdForQuery, tag: "tag1");
```
