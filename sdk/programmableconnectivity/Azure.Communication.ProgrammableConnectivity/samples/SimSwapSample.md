# Sim Swap retrieve/verify

Following shows how to use the `/sim-swap:verify` endpoint

```C# Snippet:APC_Sample_SimSwapVerifyTest
string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
Uri _endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential _credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
var client = baseClient.GetSimSwapClient();
var content = new SimSwapVerificationContent(new NetworkIdentifier("NetworkCode", "Orange_Spain"))
{
    PhoneNumber = "+50000000000",
    MaxAgeHours = 120,
};

Response<SimSwapVerificationResult> response = client.Verify(ApcGatewayId, content);
Console.WriteLine(response.Value.VerificationResult);
```

Following shows how to use the `/sim-swap:retrieve` endpoint

```C# Snippet:APC_Sample_SimSwapRetrieveTest
string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";
Uri _endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential _credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(_endpoint, _credential);
var client = baseClient.GetSimSwapClient();
var content = new SimSwapRetrievalContent(new NetworkIdentifier("NetworkCode", "Orange_Spain"))
{
    PhoneNumber = "+50000000000",
};

Response<SimSwapRetrievalResult> response = client.Retrieve(ApcGatewayId, content);
Console.WriteLine(response.Value.Date);
```
