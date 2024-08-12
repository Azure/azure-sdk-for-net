# Sim Swap retrieve/verify

Following shows how to use the `/sim-swap:verify` endpoint

```C# Snippet:APC_Sample_SimSwapVerifyTest
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
SimSwap client = baseClient.GetSimSwapClient();

SimSwapVerificationContent content = new SimSwapVerificationContent(
    new NetworkIdentifier("NetworkCode", "Orange_Spain"))
{
    PhoneNumber = "+50000000000",
    MaxAgeHours = 120,
};

Response<SimSwapVerificationResult> response = await client.VerifyAsync(apcGatewayId, content);
Console.WriteLine(response.Value.VerificationResult);
```

Following shows how to use the `/sim-swap:retrieve` endpoint

```C# Snippet:APC_Sample_SimSwapRetrieveTest
string apcGatewayId = "/subscriptions/abcdefgh/resourceGroups/.../Microsoft.programmableconnectivity/...";
Uri endpoint = new Uri("https://your-endpoint-here.com");
TokenCredential credential = new DefaultAzureCredential();
ProgrammableConnectivityClient baseClient = new ProgrammableConnectivityClient(endpoint, credential);
SimSwap client = baseClient.GetSimSwapClient();

SimSwapRetrievalContent content = new SimSwapRetrievalContent(
    new NetworkIdentifier("NetworkCode", "Orange_Spain"))
{
    PhoneNumber = "+50000000000",
};

Response<SimSwapRetrievalResult> response = await client.RetrieveAsync(apcGatewayId, content);
Console.WriteLine(response.Value.Date);
```
