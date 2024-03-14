# Find your receipt

<!-- cspell:ignore cose -->

This sample shows how to iterate over the entries and find the one you are looking for. 
The search functionality as such does not exist hence the process is manual in nature.

To get started, you'll need a url of the service.

## Create a client

To create a new `CodeTransparencyClient` that will interact with the service, without explicit credentials if the service allows it or if you 
want to get the publicly accessible data only. Then use a subclient to work with entries:

```C# Snippet:CodeTransparencySample4_CreateClient
var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
```

## Find the entry

You can only find a entry or receipt if you know its id (e.g. `17.157`) but if you are searching based on other attribute that could be in the payload of the signature that was submitted then you need to iterate over the submissions and find the matching one locally.

```C# Snippet:CodeTransparencySample4_IterateOverEntries
AsyncPageable<string> response = client.GetEntryIdsAsync();
List<string> ids = new();
await foreach (Page<string> page in response.AsPages())
{
    ids.AddRange(page.Values);
}
```
