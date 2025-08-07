---
page_type: sample
languages:
- csharp
products:
# Including relevant stubs from https://review.learn.microsoft.com/help/contribute/metadata-taxonomies#product
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
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
DeviceNetwork client = baseClient.GetDeviceNetworkClient();

NetworkIdentifier networkIdentifier = new NetworkIdentifier("IPv5", "127.0.0.1");
try
{
    Response<NetworkRetrievalResult> response = await client.RetrieveAsync(apcGatewayId, networkIdentifier);
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
Response<SimSwapVerificationResult> response = await client.VerifyAsync(apcGatewayId, content);
string xMsResponseId = response.GetRawResponse().Headers.TryGetValue("x-ms-response-id", out var responseId)
    ? responseId
    : "not found";
Console.WriteLine($"x-ms-response-id: {xMsResponseId}");
```
