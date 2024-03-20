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

See each file for example usage on each API exposed by Azure Programmable Connectivity, as well as examples of how to handle errors.
<!-- please refer to <https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/samples/README.md> to write sample readme. -->

## Common patterns
### Handling exceptions
If you'd like to catch exceptions and log out details, do the following

```C#
...
...
try
{
    // client.Verify(...);
    // client.Retrieve(...);
    // etc
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

```C#
Response<NetworkRetrievalResult> response = client.Retrieve(ApcGatewayId, networkIdentifier);
var xMsResponseId = response.GetRawResponse().Headers.TryGetValue("x-ms-response-id", out var responseId) ? responseId : "not found";

Console.WriteLine($"x-ms-response-id: {xMsResponseId}");
```
