# System.ClientModel-based client service method samples

## Introduction

`System.ClientModel`-based clients, or **service clients**, provide an interface to cloud services by translating library calls to HTTP requests.

In service clients, there are two ways to expose the schematized body in the request or response, known as the **message body**:

- **Convenience methods** take strongly-typed models as parameters.  These models are C# classes which map to the message body of the REST call.

- **Protocol method** take primitive types as parameters and their `BinaryContent` input parameters mirror the message body directly. Protocol methods provide more direct access to the HTTP API protocol used by the service.

## Convenience methods

**Convenience methods** provide a convenient way to invoke a service operation.  They are service methods that take a strongly-typed model representing schematized data sent to the service as input, and return a strongly-typed model representing the payload from the service response as output. Having strongly-typed models that represent service concepts provides a layer of convenience over working with the raw payload format. This is because these models unify the client user experience when cloud services differ in payload formats.  That is, a client-user can learn the patterns for strongly-typed models that `System.ClientModel`-based clients provide, and use them together without having to reason about whether a cloud service represents resources using, for example, JSON or XML formats.

The following sample illustrates how to call a convenience method and access the output model created from the service response.

```C# Snippet:ReadmeClientResultT
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential);

// Call a convenience method, which returns ClientResult<T>
IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);

// Access the output model from the service response.
IPAddressCountryPair value = result.Value;
Console.WriteLine($"Country is {value.CountryRegion.IsoCode}.");
```

If needed, callers can obtain the details of the HTTP response by calling the result's `GetRawResponse` method.

```C# Snippet:ReadmeGetRawResponse
// Access the HTTP response details.
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

### Customizing HTTP requests

Service clients expose low-level [protocol methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#protocol-methods) that allow callers to customize HTTP requests by passing an optional `RequestOptions` parameter.  `RequestOptions` can be used to modify various aspects of the request sent by the service method, such as adding a request header, or adding a policy to the client pipeline that can modify the request directly before sending it to the service. `RequestOptions` also allows a client user to pass a `CancellationToken` to the method.

```C# Snippet:RequestOptionsReadme
// Create RequestOptions instance.
RequestOptions options = new();

// Set the CancellationToken.
options.CancellationToken = cancellationToken;

// Add a header to the request.
options.AddHeader("CustomHeader", "CustomHeaderValue");

// Create an instance of a model that implements the IJsonModel<T> interface.
CountryRegion region = new("US");

// Create BinaryContent from the input model.
BinaryContent content = BinaryContent.Create(region);

// Call the protocol method, passing the content and options.
ClientResult result = await client.AddCountryCodeAsync(content, options);
```

### Provide request content

In service clients' [protocol methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#protocol-methods), users pass the request content as a `BinaryContent` parameter.  There are a variety of ways to create a `BinaryContent` instance:

1. From `BinaryData`, which can be created from a string, a stream, an object, or from a byte array containing the serialized UTF-8 bytes
1. From a model type that implements the `IPersistableModel<T>` or `IJsonModel<T>` interfaces.

The following examples illustrate some of the different ways to create `BinaryContent` and pass it to a protocol method.

#### From a string literal

```C# Snippet:ServiceMethodsProtocolMethod
// Create a BinaryData instance from a JSON string literal.
BinaryData input = BinaryData.FromString("""
    {
        "countryRegion": {
            "isoCode": "US"
        },
    }
    """);

// Create a BinaryContent instance to set as the HTTP request content.
BinaryContent requestContent = BinaryContent.Create(input);

// Call the protocol method.
ClientResult result = await client.AddCountryCodeAsync(requestContent);

// Obtain the output response content from the returned ClientResult.
BinaryData output = result.GetRawResponse().Content;

using JsonDocument outputAsJson = JsonDocument.Parse(output.ToString());
string isoCode = outputAsJson.RootElement
    .GetProperty("countryRegion")
    .GetProperty("isoCode")
    .GetString();

Console.WriteLine($"Code for added country is '{isoCode}'.");
```

## Handling exceptions

When a service call fails, service clients throw a `ClientResultException`.  The exception exposes the HTTP status code and the details of the service response if available.

```C# Snippet:ClientResultExceptionReadme
try
{
    IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
    ClientResult<IPAddressCountryPair> result = await client.GetCountryCodeAsync(ipAddress);
}
// Handle exception with status code 404
catch (ClientResultException e) when (e.Status == 404)
{
    // Handle not found error
    Console.Error.WriteLine($"Error: Response failed with status code: '{e.Status}'");
}
```
