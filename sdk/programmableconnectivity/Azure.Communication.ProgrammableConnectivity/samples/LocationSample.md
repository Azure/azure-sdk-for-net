# Location verify

```C#
using Azure.Communication.ProgrammableConnectivity;

private readonly Uri _endpoint = new Uri("https://eastus.prod.apcgatewayapi.azure.com");
private const string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";

DeviceLocation client = ProgrammableConnectivityClient(_endpoint, DefaultAzureCredential()).GetDeviceLocationClient()
DeviceLocationVerificationContent deviceLocationVerificationContent = new DeviceLocationVerificationContent(new NetworkIdentifier("NetworkCode", "Telefonica_Brazil"), 80.0, 85.1, 50, new LocationDevice
{
    PhoneNumber = "+5551980449999",
});

Response<DeviceLocationVerificationResult> result = client.Verify(ApcGatewayId, deviceLocationVerificationContent);

Console.WriteLine($"Date last swapped: {response.Value.VerificationResult}");
```

