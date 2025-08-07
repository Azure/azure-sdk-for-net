# Network retrieve

To get the network name from a network identifier (IPv4/IPv6/NetworkCode), run the following code.

```C# Snippet:APC_Sample_NetworkRetrievalTest
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
DeviceNetwork client = baseClient.GetDeviceNetworkClient();

NetworkIdentifier networkIdentifier = new NetworkIdentifier("IPv4", "127.0.0.1");

Response<NetworkRetrievalResult> response = await client.RetrieveAsync(apcGatewayId, networkIdentifier);
Console.WriteLine(response.Value.NetworkCode);
```
