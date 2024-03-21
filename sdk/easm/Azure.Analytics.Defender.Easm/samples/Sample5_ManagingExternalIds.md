# Managing external Ids

External IDs can be a useful method of keeping track of assets in multiple systems, but it can be time consuming to manually tag each asset. In this example, we'll take a look at how you can, with a map of name/kind/external id, tag each asset in your inventory with an external id automatically using the SDK.

## Create an EASM Client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample5_ExternalIds_Create_Client
            string endpoint = "https://<region>.easm.defender.microsoft.com/subscriptions/<Your_Subscription_Id>/resourceGroups/<Your_Resource_Group_Name>/workspaces/<Your_Workspace_Name>";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                new DefaultAzureCredential());
```

## Initialize external id mapping

Assets in EASM can be uniquely distinguished by `name` and `kind`, so we can create a simple dictionary containing `name`, `kind`, and `external_id`. In a more realistic case, this could be generated using an export from the external system we're using for tagging

```C# Snippet:Sample5_ExternalIds_Initialize_Mapping
            Dictionary<string, string> asset1 = new Dictionary<string, string> {
    {"name", "example.com" },
    {"kind", "host" },
    {"external_id", "EXT040" } };
Dictionary<string, string> asset2 = new Dictionary<string, string> {
    {"name", "example.com" },
    {"kind", "domain" },
    {"external_id", "EXT041" } };
List<Dictionary<string, string>> mapping = new List<Dictionary<string, string>> {
    asset1, asset2
};
```

## Update assets

Using the client, we can update each asset and append the tracking id of the update to our update ID list, so that we can keep track of the progress on each update later.


```C# Snippet:Sample5_ExternalIds_Update_Assets
List<String> updateIds = new List<String>();
List<String> externalIds = new List<String>();
mapping.ForEach(asset =>
{
    externalIds.Add(asset["external_id"]);
    AssetUpdatePayload assetUpdateRequest = new AssetUpdatePayload();
    assetUpdateRequest.ExternalId = asset["external_id"];
    string filter = $"kind = {asset["kind"]} AND name = {asset["name"]}";
    var taskResponse = client.UpdateAssets(filter, assetUpdateRequest);
    updateIds.Add(taskResponse.Value.Id);
});
```

## View update progress

Using the client, we can view the progress of each update using the `TasksGet` method

```C# Snippet:Sample5_ExternalIds_View_Update_Progress
updateIds.ForEach(id =>
{
    var taskResponse = client.GetTask(id);
    Console.WriteLine($"{taskResponse.Value.Id}: {taskResponse.Value.State}");
});
```

The updates can be viewed using the `AssetsList` method by creating a filter that matches on each external id using an `in` query

```C# Snippet:Sample5_ExternalIds_View_Updates
string assetFilter = $"External ID in (\"{string.Join("\", \"", externalIds)}\")";

var assetPageResponse = client.GetAssetResources(assetFilter);
foreach (AssetResource assetResponse in assetPageResponse)
{
    Console.WriteLine($"{assetResponse.ExternalId}, {assetResponse.Name}");
}
```