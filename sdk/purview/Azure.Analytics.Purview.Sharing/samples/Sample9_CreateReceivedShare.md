# Azure Share Client Samples - Create Received Share

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
```

## Create Received Share

```C# Snippet:ReceivedSharesClientSample_CreateReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
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
                referenceName = "/subscriptions/<suscriptionId>/resourceGroups/<resourceGroup>/providers/Microsoft.Storage/storageAccounts/<storageAccount>",

                type = "ArmResourceReference"
            },
            properties = new
            {
                containerName = <>,
                folder = <>,
                mountPath = <>,
            }
        },
        displayName = <displayName>,
    }
};

Operation<BinaryData> createResponse = await receivedSharesClient.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, <receivedShareId>, RequestContent.Create(data));
```
