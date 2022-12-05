# Azure Share Client Samples - View accepted shares

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_07_Namespaces
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
```

## View accepted shares

```C# Snippet:Azure_Analytics_Purview_Share_Samples_ViewAcceptedShares
var sentShareName = "sample-Share";
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var acceptedSentSharesClient = new AcceptedSentSharesClient(endPoint, credential);

// View accepted shares
var acceptedSentShares = await acceptedSentSharesClient.GetAcceptedSentSharesAsync(sentShareName).ToEnumerableAsync();

var acceptedSentShare = acceptedSentShares.FirstOrDefault();

if (acceptedSentShare == null)
{
    //No accepted sent shares
    return;
}
using var jsonDocument = JsonDocument.Parse(acceptedSentShare);
var receiverEmail = jsonDocument.RootElement.GetProperty("properties").GetProperty("receiverEmail").GetString();
```
