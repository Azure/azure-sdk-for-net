# Manage Text Blocklist

This sample shows how to create a text blocklist and analyze text with blocklists using Azure AI Content Safety.
To get started, make sure you have satisfied all the prerequisites and got all the resources required by [README][README].

## Create a ContentSafetyClient

To create a new `ContentSafetyClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Content Safety API key credential by creating an `AzureKeyCredential` object.

You can set `endpoint` and `key` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_AI_ContentSafety_CreateClient
string endpoint = TestEnvironment.Endpoint;
string key = TestEnvironment.Key;

ContentSafetyClient client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(key));
```

## Create a text blocklist

You can create or update a text blocklist by `CreateOrUpdateTextBlocklist`, the blocklist name is unique. If the new blocklist is created successfully it will return `201`, if an existed blocklist is updated successfully it will return `200`.

```C# Snippet:Azure_AI_ContentSafety_CreateNewBlocklist
var blocklistName = "TestBlocklist";
var blocklistDescription = "Test blocklist management";

var data = new
{
    description = blocklistDescription,
};

var createResponse = blocklistClient.CreateOrUpdateTextBlocklist(blocklistName, RequestContent.Create(data));
if (createResponse.Status == 201)
{
    Console.WriteLine("\nBlocklist {0} created.", blocklistName);
}
else if (createResponse.Status == 200)
{
    Console.WriteLine("\nBlocklist {0} updated.", blocklistName);
}
```

## Add blockItems to text blocklist

You can add multiple blockItems once by calling `AddBlockItems`. There is a maximum limit of **10,000 items** in total across all lists. You can add at most **100 blockItems** in one request.

```C# Snippet:Azure_AI_ContentSafety_AddBlockItems
string blockItemText1 = "k*ll";
string blockItemText2 = "h*te";

var blockItems = new TextBlocklistItem[] { new TextBlocklistItem(blockItemText1), new TextBlocklistItem(blockItemText2) };
var addedBlockItems = blocklistClient.AddOrUpdateBlocklistItems(blocklistName, new AddOrUpdateTextBlocklistItemsOptions(blockItems));

if (addedBlockItems != null && addedBlockItems.Value != null)
{
    Console.WriteLine("\nBlockItems added:");
    foreach (var addedBlockItem in addedBlockItems.Value.BlocklistItems)
    {
        Console.WriteLine("BlockItemId: {0}, Text: {1}, Description: {2}", addedBlockItem.BlocklistItemId, addedBlockItem.Text, addedBlockItem.Description);
    }
}
```

## Load text and analyze text with blocklists

You can read in the text and initialize `AnalyzeTextOptions` with it. Then attach the blocklists you would like to use by adding their blocklist names, and call `AnalyzeText` to get analysis result. Note that after you edit your blocklist, it usually takes effect in **5 minutes**, please wait some time before analyzing with blocklist after editing.

```C# Snippet:Azure_AI_ContentSafety_AnalyzeTextWithBlocklist
// After you edit your blocklist, it usually takes effect in 5 minutes, please wait some time before analyzing with blocklist after editing.
var request = new AnalyzeTextOptions("I h*te you and I want to k*ll you");
request.BlocklistNames.Add(blocklistName);
request.HaltOnBlocklistHit = true;

Response<AnalyzeTextResult> response;
try
{
    response = contentSafetyClient.AnalyzeText(request);
}
catch (RequestFailedException ex)
{
    Console.WriteLine("Analyze text failed.\nStatus code: {0}, Error code: {1}, Error message: {2}", ex.Status, ex.ErrorCode, ex.Message);
    throw;
}

if (response.Value.BlocklistsMatch != null)
{
    Console.WriteLine("\nBlocklist match result:");
    foreach (var matchResult in response.Value.BlocklistsMatch)
    {
        Console.WriteLine("BlocklistName: {0}, BlocklistItemId: {1}, BlocklistText: {2}, ", matchResult.BlocklistName, matchResult.BlocklistItemId, matchResult.BlocklistItemText);
    }
}
```

## Other text blocklist management samples

### List text blocklists

```C# Snippet:Azure_AI_ContentSafety_ListBlocklists
var blocklists = blocklistClient.GetTextBlocklists();
Console.WriteLine("\nList blocklists:");
foreach (var blocklist in blocklists)
{
    Console.WriteLine("BlocklistName: {0}, Description: {1}", blocklist.Name, blocklist.Description);
}
```

### Get text blocklist

```C# Snippet:Azure_AI_ContentSafety_GetBlocklist
var getBlocklist = blocklistClient.GetTextBlocklist(blocklistName);
if (getBlocklist != null && getBlocklist.Value != null)
{
    Console.WriteLine("\nGet blocklist:");
    Console.WriteLine("BlocklistName: {0}, Description: {1}", getBlocklist.Value.Name, getBlocklist.Value.Description);
}
```

### List blockItems

```C# Snippet:Azure_AI_ContentSafety_ListBlockItems
var allBlockitems = blocklistClient.GetTextBlocklistItems(blocklistName);
Console.WriteLine("\nList BlockItems:");
foreach (var blocklistItem in allBlockitems)
{
    Console.WriteLine("BlocklistItemId: {0}, Text: {1}, Description: {2}", blocklistItem.BlocklistItemId, blocklistItem.Text, blocklistItem.Description);
}
```

### Get blockItem

```C# Snippet:Azure_AI_ContentSafety_GetBlockItem
var getBlockItemId = addedBlockItems.Value.BlocklistItems[0].BlocklistItemId;
var getBlockItem = blocklistClient.GetTextBlocklistItem(blocklistName, getBlockItemId);
Console.WriteLine("\nGet BlockItem:");
Console.WriteLine("BlockItemId: {0}, Text: {1}, Description: {2}", getBlockItem.Value.BlocklistItemId, getBlockItem.Value.Text, getBlockItem.Value.Description);
```

### Remove blockItems

```C# Snippet:Azure_AI_ContentSafety_RemoveBlockItems
var removeBlockItemId = addedBlockItems.Value.BlocklistItems[0].BlocklistItemId;
var removeBlockItemIds = new List<string> { removeBlockItemId };
var removeResult = blocklistClient.RemoveBlocklistItems(blocklistName, new RemoveTextBlocklistItemsOptions(removeBlockItemIds));

if (removeResult != null && removeResult.Status == 204)
{
    Console.WriteLine("\nBlockItem removed: {0}.", removeBlockItemId);
}
```

### Delete text blocklist

```C# Snippet:Azure_AI_ContentSafety_DeleteBlocklist
var deleteResult = blocklistClient.DeleteTextBlocklist(blocklistName);
if (deleteResult != null && deleteResult.Status == 204)
{
    Console.WriteLine("\nDeleted blocklist.");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentsafety/Azure.AI.ContentSafety/README.md
