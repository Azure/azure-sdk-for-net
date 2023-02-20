# Azure Share Client Samples - Get Received Share

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using Azure.Core;
using Azure.Identity;
```

## Get Received Share

```C# Snippet:ReceivedSharesClientSample_GetReceivedShare
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
