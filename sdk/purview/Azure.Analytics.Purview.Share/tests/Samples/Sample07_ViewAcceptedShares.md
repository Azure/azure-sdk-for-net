# Azure Share Client Samples - View accepted shares

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_07_Namespaces
using System.Linq;
using System.Text.Json;
using Azure.Identity;
```

## View accepted shares

```C# Snippet:Azure_Analytics_Purview_Share_Samples_ViewAcceptedShares
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com";
var sentShareName = "sample-Share";

// View accepted shares
var acceptedSentSharesClient = new AcceptedSentSharesClient(endPoint, credential);
var acceptedSentShares = acceptedSentSharesClient.GetAcceptedSentShares(sentShareName);

var acceptedSentShare = acceptedSentShares.FirstOrDefault();

if (acceptedSentShare == null)
{
    //No accepted sent shares
    return;
}

var receiverEmail = JsonDocument.Parse(acceptedSentShare).RootElement.GetProperty("properties").GetProperty("receiverEmail").GetString();
```
