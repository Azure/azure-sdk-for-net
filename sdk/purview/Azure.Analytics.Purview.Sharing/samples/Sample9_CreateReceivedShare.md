# Azure purview share client samples - Create received share

## Import the namespaces

This sample demonstrates how to create a received share. This is typically done after an invitation has been sent. You can retrieve the received share id by listing all detached received shares.

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Create received share

```C# Snippet:ReceivedSharesClientSample_CreateReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

var data = new
{
    shareKind = "InPlace",
    properties = new
    {
        sink = new
        {
            storeKind = "AdlsGen2Account",
            storeReference = new
            {
                referenceName = "/subscriptions/suscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Storage/storageAccounts/receiverStorageAccount",

                type = "ArmResourceReference"
            },
            properties = new
            {
                containerName = "containerName",
                folder = "folder",
                mountPath = "mountPath",
            }
        },
        displayName = "displayName",
    }
};

Operation<BinaryData> createResponse = await receivedSharesClient.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, "receivedShareId", RequestContent.Create(data));
```
