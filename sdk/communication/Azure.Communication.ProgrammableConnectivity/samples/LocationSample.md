# Location verify

```C# Snippet:APC_Sample_LocationVerifyTest
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
DeviceLocation client = baseClient.GetDeviceLocationClient();

DeviceLocationVerificationContent content = new DeviceLocationVerificationContent(
    networkIdentifier: new NetworkIdentifier("NetworkCode", "Telefonica_Brazil"),
    latitude: 80.0,
    longitude: 85.0,
    accuracy: 50,
    device: new LocationDevice
    {
        PhoneNumber = "+8000000000000"
    }
);

Response<DeviceLocationVerificationResult> result = await client.VerifyAsync(apcGatewayId, content);

Console.WriteLine(result.Value.VerificationResult);
```
