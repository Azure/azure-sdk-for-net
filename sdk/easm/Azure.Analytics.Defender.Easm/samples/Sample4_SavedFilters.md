# Use Saved Filters

Saved Filters are used to store a query within EASM, these saved queries can be used to synchronize exact queries across multiple scripts, or to ensure a team is looking at the same assets
In this example, we'll go over how a saved filter could be used to synchronize the a query across multiple scripts

## Create an EASM Client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample4_SavedFilters_Create_Client
            string endpoint = "https://<region>.easm.defender.microsoft.com";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                "<Your_Subscription_Id>",
                "<Your_Resource_Group_Name>",
                "<Your_Workspace_Name>",
                new DefaultAzureCredential());
```

## Create a Saved Filter

To create a Saved Filter, we need to send a filter, name, and description to the `SavedFiltersCreateOrReplace` endpoint.

```C# Snippet:Sample4_SavedFilters_Create_Saved_Filter
string savedFilterName = "Sample saved filter";
SavedFilterData savedFilterRequest = new SavedFilterData("IP Address = 1.1.1.1", "Monitored Addresses");
client.CreateOrReplaceSavedFilter(savedFilterName, savedFilterRequest);
```

## Monitor Assets with the Saved Filter

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

## Update the Monitored Assets


The monitored assets can be updated with an assets update call:

```C# Snippet:Sample4_SavedFilters_Update_Monitored_Assets
AssetUpdateData assetUpdateRequest = new AssetUpdateData();
assetUpdateRequest.State = AssetUpdateState.Confirmed;
client.UpdateAssets(monitorFilter, assetUpdateRequest);
```


## Update Filter if Needed

Should your needs change, the filter can be updated with no need to update the scripts it's used in. Simply submit a new `SavedFiltersPut` request to replace the old description and filter with a new set.

```C# Snippet:Sample4_SavedFilters_New_Saved_Filter
SavedFilterData newSavedFilterData = new SavedFilterData("IP Address = 0.0.0.0", "Monitoring Addresses");
client.CreateOrReplaceSavedFilter(savedFilterName, newSavedFilterData);
```