# Network retrieve

To get the Network name from a network identifier (IPv4/IPv6/NetworkCode), run the following code.

```C#
using Azure.Communication.ProgrammableConnectivity;

private readonly Uri _endpoint = new Uri("https://eastus.prod.apcgatewayapi.azure.com");
private const string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";

DeviceNetwork client = ProgrammableConnectivityClient(_endpoint, DefaultAzureCredential()).GetDeviceNetworkClient()
NetworkIdentifier networkIdentifier = new NetworkIdentifier("IPv4", "189.88.1.1");
Response<NetworkRetrievalResult> response = client.Retrieve(ApcGatewayId, networkIdentifier);

Console.WriteLine($"Network Code is: {response.Value.NetworkCode}");
```
