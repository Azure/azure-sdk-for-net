## Create a `AlphaIdsClient`

To create a new `AlphaIdsClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you create a relevant resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:Azure_Communication_AlphaIds_CreateAlphaIdsClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
AlphaIdsClient client = new AlphaIdsClient(connectionString);
```

## Get the current applied configuration

The `AlphaIdsClient` can be used to retrieve the Alpha ID configuration.

```C# Snippet:Azure_Communication_AlphaIds_GetConfiguration
try
{
    AlphaIdConfiguration configuration = await client.GetConfigurationAsync();

    Console.WriteLine($"The usage of Alpha IDs is currently {(configuration.Enabled ? "enabled" : "disabled")}");
}
catch (RequestFailedException ex)
{
    if (ex.Status == 403)
    {
        Console.WriteLine("Resource is not eligible for Alpha ID usage");
    }
}
```
