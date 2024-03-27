# Network retrieve

To get the Network name from a network identifier (IPv4/IPv6/NetworkCode), run the following code.

```C# Snippet:APC_Sample_NetworkRetrievalTest
string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
Uri _endpoint = new Uri("https://eastus.prod.apcgatewayapi.azure.com");
TokenCredential _credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
var client = baseClient.GetDeviceNetworkClient();
var networkIdentifier = new NetworkIdentifier("IPv4", "189.88.1.1");

Response<NetworkRetrievalResult> response = client.Retrieve(ApcGatewayId, networkIdentifier);
Console.WriteLine(response.Value.NetworkCode);
```
