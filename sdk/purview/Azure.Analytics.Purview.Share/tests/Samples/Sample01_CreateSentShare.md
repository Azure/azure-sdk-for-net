# Azure Share Client Samples - Create Sent Share

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_01_Namespaces
using Azure.Core;
using Azure.Identity;
```

## Create Sent Share

```C# Snippet:Azure_Analytics_Purview_Share_Samples_CreateSentShare
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
