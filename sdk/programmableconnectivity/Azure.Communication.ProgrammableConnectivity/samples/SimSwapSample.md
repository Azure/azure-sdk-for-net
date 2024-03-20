# Sim Swap retrieve/verify

Following shows how to use the `/sim-swap:verify` endpoint

```C#
using Azure.Communication.ProgrammableConnectivity;

private readonly Uri _endpoint = new Uri("https://eastus.prod.apcgatewayapi.azure.com");
private const string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";

SimSwap client = ProgrammableConnectivityClient(_endpoint, DefaultAzureCredential()).GetSimSwapClient()
SimSwapVerificationContent content = new SimSwapVerificationContent(new NetworkIdentifier("NetworkCode", "Orange_Spain"))
{
    PhoneNumber = "+34665439999",
    MaxAgeHours = 120,
};

Response<SimSwapVerificationResult> response = client.Verify(ApcGatewayId, content);
Console.WriteLine($"Verification result: {response.Value.VerificationResult}");
```

Following shows how to use the `/sim-swap:retrieve` endpoint

```C#
using Azure.Communication.ProgrammableConnectivity;

private readonly Uri _endpoint = new Uri("https://eastus.prod.apcgatewayapi.azure.com");
private const string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";

SimSwap client = ProgrammableConnectivityClient(_endpoint, DefaultAzureCredential()).GetSimSwapClient()
SimSwapRetrievalResult content = new SimSwapRetrievalResult(new NetworkIdentifier("NetworkCode", "Orange_Spain"))
{
    PhoneNumber = "+34665439999",
};

Response<SimSwapVerificationResult> response = client.Retrieve(ApcGatewayId, content);
Console.WriteLine($"Date last swapped: {response.Value.Date}");
```
