# Use saved filters

Saved Filters are used to store a query within EASM, these saved queries can be used to synchronize exact queries across multiple scripts, or to ensure a team is looking at the same assets
In this example, we'll go over how a saved filter could be used to synchronize the a query across multiple scripts

## Create an EASM client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample4_SavedFilters_Create_Client
            string endpoint = "https://<region>.easm.defender.microsoft.com/subscriptions/<Your_Subscription_Id>/resourceGroups/<Your_Resource_Group_Name>/workspaces/<Your_Workspace_Name>";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                new DefaultAzureCredential());
```

## Create a saved filter

To create a Saved Filter, we need to send a filter, name, and description to the `SavedFiltersCreateOrReplace` endpoint.

```C# Snippet:Sample4_SavedFilters_Create_Saved_Filter
string savedFilterName = "Sample saved filter";
SavedFilterPayload savedFilterRequest = new SavedFilterPayload("IP Address = 1.1.1.1", "Monitored Addresses");
client.CreateOrReplaceSavedFilter(savedFilterName, savedFilterRequest);
```

## Monitor assets with the saved filter

Set up an asset list call that could be used to monitor the assets:

```C# Snippet:Sample4_SavedFilters_Monitor
private void monitor(SavedFilter response)
{
    // your monitor logic here
}
```

The saved filter can now be used in scripts to monitor the assets. First, retrieve the saved filter by name, then use it in an asset list or update call.

```C# Snippet:Sample4_SavedFilters_Monitor_Assets
var savedFilterResponse = client.GetSavedFilter(savedFilterName);
string monitorFilter = savedFilterResponse.Value.Filter;
            var savedFilterPageResponse = client.GetSavedFilters(monitorFilter);
                        foreach (SavedFilter savedFilter in savedFilterPageResponse)
{
    monitor(savedFilter);
}
```

## Update the monitored assets

The monitored assets can be updated with an assets update call:

```C# Snippet:Sample4_SavedFilters_Update_Monitored_Assets
AssetUpdatePayload assetUpdateRequest = new AssetUpdatePayload();
assetUpdateRequest.State = AssetUpdateState.Confirmed;
client.UpdateAssets(monitorFilter, assetUpdateRequest);
```

## Update Filter if Needed

Should your needs change, the filter can be updated with no need to update the scripts it's used in. Simply submit a new `SavedFiltersPut` request to replace the old description and filter with a new set.

```C# Snippet:Sample4_SavedFilters_New_Saved_Filter
SavedFilterPayload newSavedFilterData = new SavedFilterPayload("IP Address = 0.0.0.0", "Monitoring Addresses");
client.CreateOrReplaceSavedFilter(savedFilterName, newSavedFilterData);
```