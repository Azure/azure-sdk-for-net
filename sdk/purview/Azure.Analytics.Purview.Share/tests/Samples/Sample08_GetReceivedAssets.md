# Azure Share Client Samples - Get received assets

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_08_Namespaces
using System;
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
```

## Get received assets

```C# Snippet:Azure_Analytics_Purview_Share_Samples_GetReceivedAssets
var receivedShareName = "sample-share";
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var receivedAssetsClient = new ReceivedAssetsClient(endPoint, credential);

// Get received assets
var receivedAssets = await receivedAssetsClient.GetReceivedAssetsAsync(receivedShareName).ToEnumerableAsync();
using var jsonDocument = JsonDocument.Parse(receivedAssets.First());
var receivedAssetName = jsonDocument.RootElement.GetProperty("name").GetString();

string assetMappingName = "receiver-asset-mapping";
string receiverContainerName = "receivedcontainer";
string receiverFolderName = "receivedfolder";
string receiverMountPath = "receivedmountpath";
string receiverStorageResourceId = "<RECEIVER_STORAGE_ACCOUNT_RESOURCE_ID>";

var assetMappingData = new
{
    // For Adls Gen2 asset use "AdlsGen2Account"
    kind = "BlobAccount",
    properties = new
    {
        assetId = Guid.Parse(receivedAssetName),
        storageAccountResourceId = receiverStorageResourceId,
        containerName = receiverContainerName,
        folder = receiverFolderName,
        mountPath = receiverMountPath
    }
};

var assetMappingsClient = new AssetMappingsClient(endPoint, credential);
var assetMapping = await assetMappingsClient.CreateAsync(WaitUntil.Completed, receivedShareName, assetMappingName, RequestContent.Create(assetMappingData));
```
