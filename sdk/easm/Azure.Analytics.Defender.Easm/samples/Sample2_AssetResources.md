# Listing assets

After the discovery run is finished, your workspace will be populated with assets. The sample provided demonstrates how you can retrieve the assets from your workspace.

## Create an EASM client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample1_AssetResources_Create_Client
            string endpoint = "https://<region>.easm.defender.microsoft.com/subscriptions/<Your_Subscription_Id>/resourceGroups/<Your_Resource_Group_Name>/workspaces/<Your_Workspace_Name>";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                new DefaultAzureCredential());
```
## List assets

You can call the client's `AssetsList` method to view your assets.

```C# Snippet:Sample1_AssetResources_Get_Assets
var response = client.GetAssetResources();
int index = 0;
foreach (AssetResource asset in response)
{
    Console.WriteLine($"Asset Name: {asset.Name}, Kind: {asset.GetType()}");
    if (index++ > 5)
    {
        break;
    }
}
```
