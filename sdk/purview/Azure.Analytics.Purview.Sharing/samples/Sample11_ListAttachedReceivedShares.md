# Azure Share Client Samples - List Attached Received Shares

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using Azure.Core;
using Azure.Identity;
```

## List Attached Received Shares

```C# Snippet:ReceivedSharesClientSample_ListAttachedReceivedShares
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

// Create sent share
var sentShareName = "sample-Share";

var inPlaceSentShareDto = new
{
    shareKind = "InPlace",
    properties = new
    {
        description = "demo share",
        collection = new
        {
            // for root collection else name of any accessible child collection in the Purview account.
            referenceName = "<purivewAccountName>",
            type = "CollectionReference"
        }
    }
};

var sentShare = await sentShareClient.CreateOrUpdateAsync(sentShareName, RequestContent.Create(inPlaceSentShareDto));
```
