# Network retrieve

To get the network name from a network identifier (IPv4/IPv6/NetworkCode), run the following code.

```C# Snippet:APC_Sample_NetworkRetrievalTest
string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
var client = baseClient.GetDeviceNetworkClient();
var networkIdentifier = new NetworkIdentifier("IPv4", "127.0.0.1");

Response<NetworkRetrievalResult> response = client.Retrieve(ApcGatewayId, networkIdentifier);
Console.WriteLine(response.Value.NetworkCode);
```
