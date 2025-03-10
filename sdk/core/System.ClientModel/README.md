# System.ClientModel library for .NET

`System.ClientModel` contains building blocks for communicating with cloud services.  It provides shared primitives, abstractions, and helpers for .NET service client libraries.

`System.ClientModel` allows client libraries built from its components to expose common functionality in a consistent fashion, so that once you learn how to use these APIs in one client library, you'll know how to use them in other client libraries as well.

[Source code][source] | [Package (NuGet)][package]

## Getting started

Typically, you will not need to install `System.ClientModel`.  It will be installed for you when you install a client library that uses it.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/packages/System.ClientModel).

```dotnetcli
dotnet add package System.ClientModel
```

### Prerequisites

None needed for `System.ClientModel`.

## Key concepts

`System.ClientModel` contains two major categories of types: (1) types used to author service clients, and (2) types exposed in the public APIs of clients built using `System.ClientModel` types.  The latter are intended for use by the end-users of service clients to communicate with cloud services.

Types used to author service clients appear in the `System.ClientModel.Primitives` namespace.  Key concepts involving these types include:

- Client pipeline used to send and receive HTTP messages (`ClientPipeline`).
- Interfaces used to read and write input and output models exposed in client convenience APIs (`IPersistableModel<T>` and `IJsonModel<T>`).

Service methods that end-users of clients call to invoke service operations fall into two categories: [convenience](https://devblogs.microsoft.com/dotnet/the-convenience-of-dotnet/) methods and lower-level protocol methods.  Types used in clients' [convenience methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#convenience-methods) appear in the root `System.ClientModel` namespace.  Types used in [protocol methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#protocol-methods) and other lower-level scenarios appear in the `System.ClientModel.Primitives` namespace.  Key concepts involving these types include:

- Results that provide access to the service response and the HTTP response details (`ClientResult<T>`, `ClientResult`).
- Exceptions that result from failed requests (`ClientResultException`).
- Options used to configure the service client pipeline (`ClientPipelineOptions`).
- Options used to customize HTTP requests (`RequestOptions`).
- Content sent in an HTTP request body (`BinaryContent`).

Below, you will find sections explaining these shared concepts in more detail.

## Examples

### Send a message using ClientPipeline

`System.ClientModel`-based clients, or **service clients**, use the `ClientPipeline` type to send and receive HTTP messages. The following sample shows a minimal example of what a service client implementation might look like.

```C# Snippet:ReadmeSampleClient
public class SampleClient
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _credential;
    private readonly ClientPipeline _pipeline;

    // Constructor takes service endpoint, credential used to authenticate
    // with the service, and options for configuring the client pipeline.
    public SampleClient(Uri endpoint, ApiKeyCredential credential, SampleClientOptions? options = default)
    {
        // Default options are used if none are passed by the client's user.
        options ??= new SampleClientOptions();

        _endpoint = endpoint;
        _credential = credential;

        // Authentication policy instance is created from the user-provided
        // credential and service authentication scheme.
        ApiKeyAuthenticationPolicy authenticationPolicy = ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(credential);

        // Pipeline is created from user-provided options and policies
        // specific to the service client implementation.
        _pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { authenticationPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
    }

    // Service method takes an input model representing a service resource
    // and returns `ClientResult<T>` holding an output model representing
    // the value returned in the service response.
    public ClientResult<SampleResource> UpdateResource(SampleResource resource)
    {
        // Create a message that can be sent via the client pipeline.
        using PipelineMessage message = _pipeline.CreateMessage();

        // Modify the request as needed to invoke the service operation.
        PipelineRequest request = message.Request;
        request.Method = "PATCH";
        request.Uri = new Uri($"https://www.example.com/update?id={resource.Id}");
        request.Headers.Add("Accept", "application/json");

        // Add request body content that will be written using methods
        // defined by the model's implementation of the IJsonModel<T> interface.
        request.Content = BinaryContent.Create(resource);

        // Send the message.
        _pipeline.Send(message);

        // Obtain the response from the message Response property.
        // The PipelineTransport ensures that the Response value is set
        // so that every policy in the pipeline can access the property.
        PipelineResponse response = message.Response!;

        // If the response is considered an error response, throw an
        // exception that exposes the response details.
        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        // Read the content from the response body and create an instance of
        // a model from it, to include in the type returned by this method.
        SampleResource updated = ModelReaderWriter.Read<SampleResource>(response.Content)!;

        // Return a ClientResult<T> holding the model instance and the HTTP
        // response details.
        return ClientResult.FromValue(updated, response);
    }
}
```

For more information on authoring clients, see [Client implementation samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ClientImplementation.md).

### Reading and writing model content to HTTP messages

Service clients provide **model types** representing service resources as input parameters and return values from service clients' [convenience methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#convenience-methods).  Client authors can implement the `IPersistableModel<T>` and `IJsonModel<T>` interfaces their in model implementations to make it easy for clients to write input model content to request message bodies, and to read response content and create instances of output models from it.  An example of how clients' service methods might use such models is shown in [Send a message using the ClientPipeline](#send-a-message-using-clientpipeline).  The following sample shows a minimal example of what a persistable model implementation might look like.

```C# Snippet:ReadmeSampleModel
public class SampleResource : IJsonModel<SampleResource>
{
    public SampleResource(string id)
    {
        Id = id;
    }

    public string Id { get; init; }

    SampleResource IJsonModel<SampleResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => FromJson(reader);

    SampleResource IPersistableModel<SampleResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        => FromJson(new Utf8JsonReader(data));

    string IPersistableModel<SampleResource>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => options.Format;

    void IJsonModel<SampleResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ToJson(writer);

    BinaryData IPersistableModel<SampleResource>.Write(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options);

    // Write the model JSON that will populate the HTTP request content.
    private void ToJson(Utf8JsonWriter writer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("id");
        writer.WriteStringValue(Id);
        writer.WriteEndObject();
    }

    // Read the JSON response content and create a model instance from it.
    private static SampleResource FromJson(Utf8JsonReader reader)
    {
        reader.Read(); // start object
        reader.Read(); // property name
        reader.Read(); // id value

        return new SampleResource(reader.GetString()!);
    }
}
```

For more information on reading and writing persistable models, see [Model reader writer samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ModelReaderWriter.md).

### Accessing the service response

Service clients have methods that are used to call cloud services to invoke service operations.  These methods on a client are called **service methods**, and they send a request to the service and return a representation of its response to the caller.  Service clients expose two types of service methods: [convenience methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#convenience-methods) and [protocol methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#protocol-methods).

**Convenience methods** provide a [convenient](https://devblogs.microsoft.com/dotnet/the-convenience-of-dotnet/) way to invoke a service operation.  They are methods that take a strongly-typed model as input and return a `ClientResult<T>` that holds a strongly-typed representation of the service response.  Details from the HTTP response may also be obtained from the return value.

**Protocol method** are low-level methods that take parameters that correspond to the service HTTP API and return a `ClientResult` holding only the raw HTTP response details.  These methods also take an optional `RequestOptions` parameter that allows the client pipeline and the request to be configured for the duration of the call.

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

For more information on client service methods, see [Client service method samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md).

### Handling exceptions that result from failed requests

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

Whether or not a response is considered an error by the client is determined by the `PipelineMessageClassifier` held by a message when it is sent through the client pipeline.  For more information on how client authors can customize error classification, see [Configuring error response classification samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ClientImplementation.md#configuring-error-response-classification).

### Configuring service clients

Service clients provide a constructor that takes a service endpoint and a credential used to authenticate with the service.  They also provide a constructor overload that takes an endpoint, a credential, and an instance of `ClientPipelineOptions`.
Passing `ClientPipelineOptions` when a client is created will configure the pipeline that the client uses to send and receive HTTP requests and responses.  Client pipeline options can be used to override default values such as the network timeout used to send or retry a request.

```C# Snippet:ClientModelConfigurationReadme
MapsClientOptions options = new()
{
    NetworkTimeout = TimeSpan.FromSeconds(120),
};

string? key = Environment.GetEnvironmentVariable("MAPS_API_KEY");
ApiKeyCredential credential = new(key!);
MapsClient client = new(new Uri("https://atlas.microsoft.com"), credential, options);
```

For more information on client configuration, see [Client configuration samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/Configuration.md).

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

For more information on customizing requests, see [Protocol method samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#protocol-methods).

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

#### From an anonymous type

```C# Snippet:ServiceMethodsBinaryContentAnonymous
// Create a BinaryData instance from an anonymous object representing
// the JSON the service expects for the service operation.
BinaryData input = BinaryData.FromObjectAsJson(new
{
    countryRegion = new
    {
        isoCode = "US"
    }
});

// Create the BinaryContent instance to pass to the protocol method.
BinaryContent content = BinaryContent.Create(input);

// Call the protocol method.
ClientResult result = await client.AddCountryCodeAsync(content);
```

#### From an input stream

```C# Snippet:ServiceMethodsBinaryContentStream
// Create a BinaryData instance from a file stream
FileStream stream = File.OpenRead(@"c:\path\to\file.txt");
BinaryData input = BinaryData.FromStream(stream);

// Create the BinaryContent instance to pass to the protocol method.
BinaryContent content = BinaryContent.Create(input);

// Call the protocol method.
ClientResult result = await client.AddCountryCodeAsync(content);
```

#### From a model type

```C# Snippet:ServiceMethodsBinaryContentModel
// Create an instance of a model that implements the IJsonModel<T> interface.
CountryRegion region = new("US");

// Create BinaryContent from the input model.
BinaryContent content = BinaryContent.Create(region);

// Call the protocol method, passing the content and options.
ClientResult result = await client.AddCountryCodeAsync(content);
```

## Troubleshooting

You can troubleshoot service clients by inspecting the result of any `ClientResultException` thrown from a client's service method.

For more information on client service method errors, see [Handling exceptions that result from failed requests](#handling-exceptions-that-result-from-failed-requests).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/System.ClientModel/src
[package]: https://www.nuget.org/packages/System.ClientModel
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
