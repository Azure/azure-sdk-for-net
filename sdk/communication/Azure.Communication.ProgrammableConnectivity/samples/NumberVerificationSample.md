# NumberVerification verify

Number verification involves 2 steps. In the first request, you receive a redirect URL that must be followed, in order to get the `apcCode` value. Then in the second request, the `apcCode` gets sent in, and you receive the verification result.

## Part 1
```C# Snippet:APC_Sample_NumberVerificationWithoutCodeTest
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);

NumberVerification client = baseClient.GetNumberVerificationClient();

NumberVerificationWithoutCodeContent content = new NumberVerificationWithoutCodeContent(
    new NetworkIdentifier("NetworkCode", "Orange_Spain"),
    new Uri("https://somefakebackend.com"))
{
    PhoneNumber = "+8000000000000",
};

Response response = await client.VerifyWithoutCodeAsync(apcGatewayId, content);
string locationUrl = response.Headers.TryGetValue("location", out var location) ? location : "Not found";

Console.WriteLine(locationUrl);
```

The `locationUrl` now has to be followed by you.

## Part 2
```C# Snippet:APC_Sample_NumberVerificationWithCodeTest
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");

ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
NumberVerification client = baseClient.GetNumberVerificationClient();

NumberVerificationWithCodeContent content = new NumberVerificationWithCodeContent("apc_1231231231232");

Response<NumberVerificationResult> response = await client.VerifyWithCodeAsync(apcGatewayId, content);
Console.WriteLine(response.Value.VerificationResult);
```
