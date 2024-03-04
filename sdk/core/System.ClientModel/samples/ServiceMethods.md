# System.ClientModel-based client service methods

## Introduction

`System.ClientModel`-based clients , or **service clients**, provide an interface to cloud services by translating library calls to HTTP requests.

In service clients, there are two ways to expose the schematized body in the request or response, known as the **message body**:

- Most service clients expose methods that take strongly-typed models as parameters, C# classes which map to the message body of the REST call.  These methods are called **convenience methods**.

- However, some clients expose methods that mirror the message body directly. Those methods are called here **protocol methods**, as they provide more direct access to the HTTP API protocol used by the service.

## Convenience methods

**Convenience methods** provide a convenient way to invoke a service operation.  They are service methods that take a strongly-typed model representing schematized data sent to the service as input, and return a strongly-typed model representing the payload from the service response as output. Having strongly-typed models that represent service concepts provides a layer of convenience over working with the raw payload format. This is because these models unify the client user experience when cloud services differ in payload formats.  That is, a client-user can learn the patterns for strongly-typed models that `System.ClientModel`-based clients provide, and use them together without having to reason about whether a cloud service represents resources using, for example, JSON or XML formats.

The following sample illustrates how to call a convenience method and access both the strongly-typed output model and the details of the HTTP response.

```C# Snippet:ClientResultTReadme
// create a client
string key = Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? string.Empty;
ApiKeyCredential credential = new(key);
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential);

// call a service method, which returns ClientResult<T>
IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);

// ClientResult<T> has two members:
//
// (1) A Value property to access the strongly-typed output
IPAddressCountryPair value = result.Value;
Console.WriteLine($"Country is {value.CountryRegion.IsoCode}.");

// (2) A GetRawResponse method for accessing the details of the HTTP response
PipelineResponse response = result.GetRawResponse();

Console.WriteLine($"Response status code: '{response.Status}'.");
Console.WriteLine("Response headers:");
foreach (KeyValuePair<string, string> header in response.Headers)
{
    Console.WriteLine($"Name: '{header.Key}', Value: '{header.Value}'.");
}
```

## Protocol methods

In contrast to convenience methods, **protocol methods** are service methods that provide very little convenience over the raw HTTP APIs a cloud service exposes. They represent request and response message bodies using types that are very thin layers over raw JSON/binary/other formats. Users of client protocol methods must reference a service's API documentation directly, rather than relying on the client to provide developer conveniences via strongly-typing service schemas.

The following sample illustrates how to call a protocol method, including creating the request payload, accessing the details of the HTTP response.

```C# Snippet:ServiceMethodsProtocolMethod
// Create a BinaryData instance from a JSON string literal
BinaryData input = BinaryData.FromString("""   
    {
        "countryRegion": {
            "isoCode": "US"
        },
    }
    """);

// Call the protocol method
ClientResult result = await client.AddCountryCodeAsync(BinaryContent.Create(input));

// Obtain the output response content from the returned ClientResult
BinaryData output = result.GetRawResponse().Content;

using JsonDocument outputAsJson = JsonDocument.Parse(output.ToString());
string isoCode = outputAsJson.RootElement
    .GetProperty("countryRegion")
    .GetProperty("isoCode")
    .GetString();

Console.WriteLine($"Code for added country is '{isoCode}'.");
```

Protocol methods take an optional `RequestOptions` value that allows callers to add a header to the request, or to add a policy to the client pipeline that can modify the request in any way before sending it to the service.  `RequestOptions` also allows passing a `CancellationToken` to the method.

```C# Snippet:RequestOptionsReadme
// Create RequestOptions instance
RequestOptions options = new();

// Set CancellationToken
options.CancellationToken = cancellationToken;

// Add a header to the request
options.AddHeader("CustomHeader", "CustomHeaderValue");

// Call protocol method to pass RequestOptions
ClientResult output = await client.GetCountryCodeAsync(ipAddress.ToString(), options);
```

## Handling exceptions

When a service call fails, service clients throw a `ClientResultException`.  The exception exposes the HTTP status code and the details of the service response if available.

```C# Snippet:ClientResultExceptionReadme
try
{
    IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
    ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);
}
// handle exception with status code 404
catch (ClientResultException e) when (e.Status == 404)
{
    // handle not found error
    Console.Error.WriteLine($"Error: Response failed with status code: '{e.Status}'");
}
```
