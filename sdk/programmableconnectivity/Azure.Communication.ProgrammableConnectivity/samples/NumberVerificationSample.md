# NumberVerification verify

Number verification involves 2 steps. In the first request, you receive a redirect URL that must be followed, in order to get teh `ApcCode`. Then in the second request, the `ApcCode` gets sent in.

```C#
using Azure.Communication.ProgrammableConnectivity;

private readonly Uri _endpoint = new Uri("https://eastus.prod.apcgatewayapi.azure.com");
private const string ApcGatewayId = "/subscriptions/abcdefgh/resourceGroups/dev-testing-eastus/providers/Microsoft.programmableconnectivity/gateways/apcg-eastus";

NumberVerification client = ProgrammableConnectivityClient(_endpoint, DefaultAzureCredential()).GetNumberVerificationClient()

NumberVerificationWithoutCodeContent numberVerificationWithoutCodeContent = new NumberVerificationWithoutCodeContent(new NetworkIdentifier("NetworkCode", "Telefonica_Brazil"), new Uri("http://your-redirect-url.com"))
{
    PhoneNumber = "<phoneNumber>",
};
Response response = await client.VerifyWithoutCodeAsync(ApcGatewayId, numberVerificationWithoutCodeContent);

var locationUrl = response.GetRawResponse().Headers.TryGetValue("location", out var location) ? location : "not found";

Console.WriteLine($"location redirect URL: {locationUrl}");

// The `locationUrl` now has to be followed by you.
```

For the second call

```C#
NumberVerificationWithCodeContent numberVerificationWithCodeContent = new NumberVerificationWithCodeContent("<apcCode>");
Response<NumberVerificationResult> response = await client.VerifyWithCodeAsync(ApcGatewayId, numberVerificationWithCodeContent);
```
