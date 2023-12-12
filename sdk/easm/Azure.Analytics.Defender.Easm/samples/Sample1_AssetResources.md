# Listing Assets

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/easm/Azure.Analytics.Defender.Easm/README.md#getting-started) for details.

## Create an EASM Client

To create an EasmClient, you need your subscription ID, region, and some sort of credential.

```C# Snippet:Sample1_AssetResources_Create_Client
string endpoint = "https://<region>.easm.defender.microsoft.com";
EasmClient client = new EasmClient(new System.Uri(endpoint),
                "<Your_Subscription_Id>",
                "<Your_Resource_Group_Name>",
                "<Your_Workspace_Name>",
                new DefaultAzureCredential());
```
## List Assets

You can call the client's `AssetsList` method to view your assets.

```C# Snippet:Sample1_AssetResources_Get_Assets
var response = client.GetAssetResources();
foreach (AssetResource asset in response)
{
    Console.WriteLine(asset.Name);
}
```
