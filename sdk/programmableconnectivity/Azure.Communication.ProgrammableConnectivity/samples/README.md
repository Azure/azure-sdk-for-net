---
page_type: sample
languages:
- csharp
products:
# Including relevant stubs from https://review.docs.microsoft.com/help/contribute/metadata-taxonomies#product
- azure
name: Azure.Communication.ProgrammableConnectivity samples for .NET
description: Samples for the Azure.Communication.ProgrammableConnectivity client library.
---

# Azure.Communication.ProgrammableConnectivity Samples

See each file for example usage on each API exposed by Azure Programmable Connectivity

This file contains an example of how to handle errors.


## Common patterns
### Handling exceptions
If you'd like to catch exceptions and log out details, do the following

```C# Snippet:APC_Sample_NetworkRetrievalBadIdentifierTest
string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
Uri _endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential _credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
var client = baseClient.GetDeviceNetworkClient();
var networkIdentifier = new NetworkIdentifier("IPv5", "127.0.0.1");
try
{
    Response<NetworkRetrievalResult> response = client.Retrieve(ApcGatewayId, networkIdentifier);
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Exception Message: {ex.Message}");
    Console.WriteLine($"Status Code: {ex.Status}");
    Console.WriteLine($"Error Code: {ex.ErrorCode}");
}
```


### Getting headers from response
To log out a header received from APC, use the following

```C# Snippet:SimSwapVerifyHeaderRetrievalTest
Response<SimSwapVerificationResult> response = client.Verify(ApcGatewayId, content);
var xMsResponseId = response.GetRawResponse().Headers.TryGetValue("x-ms-response-id", out var responseId) ? responseId : "not found";
Console.WriteLine($"x-ms-response-id: {xMsResponseId}");
```
