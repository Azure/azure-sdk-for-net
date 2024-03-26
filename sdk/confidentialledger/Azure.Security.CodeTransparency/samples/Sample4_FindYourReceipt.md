# Find your receipt

<!-- cspell:ignore cose -->

This sample shows how to iterate over the entries and find the one you are looking for. 
The search functionality as such does not exist hence the process is manual in nature.

To get started, you'll need a url of the service.

## Create a client

To create a new `CodeTransparencyClient` that will interact with the service, without explicit credentials if the service allows it or if you 
want to get the publicly accessible data only. Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample4_CreateClient
CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"), null);
```

## Find the entry

You can only find a entry or receipt if you know its id (e.g. `17.157`) but if you are searching based on other attribute that could be in the payload of the signature that was submitted then you need to iterate over the submissions and find the matching one locally.

```C# Snippet:CodeTransparencySample4_IterateOverEntries
byte[] signature = null;
AsyncPageable<string> response = client.GetEntryIdsAsync();
await foreach (Page<string> page in response.AsPages())
{
    // Process ids in the page response
    foreach (string entryId in page.Values)
    {
        // Download the signature and check if it contains the value you are looking for
        BinaryData entry = client.GetEntry(entryId, false);
        byte[] entryBytes = entry.ToArray();
        CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(entryBytes);
        // Check if the payload embedded in the signature contains a value
        if (Encoding.ASCII.GetString(coseSign1Message.Content.Value.ToArray()).Contains("\"foo\""))
        {
            signature = entryBytes;
            break;
        }
    }
    if (signature != null)
    {
        // do not fetch any further pages
        break;
    }
}
```
