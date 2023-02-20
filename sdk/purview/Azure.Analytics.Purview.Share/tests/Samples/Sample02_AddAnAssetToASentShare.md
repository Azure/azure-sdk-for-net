# Azure Share Client Samples - Add an assset to a sent share

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_02_Namespaces
using Azure.Core;
using Azure.Identity;
```

## Add an asset to a sent share

```C# Snippet:Azure_Analytics_Purview_Share_Samples_AddAnAssetToASentShare
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";

// Add asset to sent share
var sentShareName = "sample-Share";
var assetName = "fabrikam-blob-asset";
var assetNameForReceiver = "receiver-visible-asset-name";
var senderStorageResourceId = "<SENDER_STORAGE_ACCOUNT_RESOURCE_ID>";
var senderStorageContainer = "fabrikamcontainer";
var senderPathToShare = "folder/sample.txt";
var pathNameForReceiver = "from-fabrikam";

var assetData = new
{
    // For Adls Gen2 asset use "AdlsGen2Account"
    kind = "blobAccount",
    properties = new
    {
        storageAccountResourceId = senderStorageResourceId,
        receiverAssetName = assetNameForReceiver,
        paths = new[]
        {
            new
            {
                containerName = senderStorageContainer,
                senderPath = senderPathToShare,
                receiverPath = pathNameForReceiver
            }
        }
    }
};
var assetsClient = new AssetsClient(endPoint, credential);
await assetsClient.CreateAsync(WaitUntil.Started, sentShareName, assetName, RequestContent.Create(assetData));
```
