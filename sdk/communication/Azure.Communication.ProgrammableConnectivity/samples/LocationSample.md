# Location verify

```C# Snippet:APC_Sample_LocationVerifyTest
string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
var client = baseClient.GetDeviceLocationClient();
var deviceLocationVerificationContent = new DeviceLocationVerificationContent(new NetworkIdentifier("NetworkCode", "Telefonica_Brazil"), 80.0, 85.1, 50, new LocationDevice
{
    PhoneNumber = "+8000000000000",
});

Response<DeviceLocationVerificationResult> result = client.Verify(ApcGatewayId, deviceLocationVerificationContent);

Console.WriteLine(result.Value.VerificationResult);
```
