# Location verify

```C# Snippet:APC_Sample_LocationVerifyTest
string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
Uri _endpoint = new Uri("https://eastus.prod.apcgatewayapi.azure.com");
TokenCredential _credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
var client = baseClient.GetDeviceLocationClient();
var deviceLocationVerificationContent = new DeviceLocationVerificationContent(new NetworkIdentifier("NetworkCode", "Telefonica_Brazil"), 80.0, 85.1, 50, new LocationDevice
{
    PhoneNumber = "+5551980449999",
});

Response<DeviceLocationVerificationResult> result = client.Verify(ApcGatewayId, deviceLocationVerificationContent);

Console.WriteLine(result.Value.VerificationResult);
```
