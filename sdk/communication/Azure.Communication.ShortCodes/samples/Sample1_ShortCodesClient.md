## Create a `ShortCodesClient`

To create a new `ShortCodesClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you create a relevant resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateShortCodesClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new ShortCodesClient(connectionString);
```

## Get a Short Code

The `ShortCodesClient` can be used to retrieve owned Short Codes.

```C# Snippet:GetShortCodes
var pageable = client.GetShortCodesAsync();
await foreach (var shortCode in pageable)
{
    Console.WriteLine($"Short Code Number: {shortCode.Number}");
}
```
