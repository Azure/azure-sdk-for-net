# System.ClientModel-based client implementation samples

## Introduction

`System.ClientModel`-based clients, or **service clients**, are built using types provided in the `System.ClientModel` library.

## Basic client implementation

The following sample shows a minimal example of what a service client implementation might look like.

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

### Reading and writing model content to HTTP messages

Service clients provide **model types** representing service resources as input parameters and return values from service clients' [convenience methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#convenience-methods).  Client authors can implement the `IPersistableModel<T>` and `IJsonModel<T>` interfaces their in model implementations to make it easy for clients to write input model content to request message bodies, and to read response content and create instances of output models from it.  An example of how clients' service methods might use such models is shown in [Basic client implementation](#basic-client-implementation).  The following sample shows a minimal example of what a persistable model implementation might look like.

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

### Implementing protocol methods

The example shown in [Basic client implementation](#basic-client-implementation) illustrates what a service client [convenience method](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#convenience-methods) method implementation might look like.  That is, the sample client defines a single service method that takes a model type parameter as input and returns a `ClientResult<T>` holding an output model type.

In contrast to convenience methods, client [protocol methods](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/samples/ServiceMethods.md#protocol-methods) take `BinaryContent` as input and an optional `RequestOptions` parameter that holds user-provided options for configuring the request and the client pipeline for the duration of the service call.  The following sample shows a minimal example of what a client that implements both convenience methods and protocol methods might look like.

#### Convenience method

The client's convenience method converts model types to request content and from response content, and calls through to the protocol method.

```C# Snippet:ClientImplementationConvenienceMethod
// A convenience method takes a model type and returns a ClientResult<T>.
public virtual async Task<ClientResult<CountryRegion>> AddCountryCodeAsync(CountryRegion country)
{
    // Validate input parameters.
    if (country is null) throw new ArgumentNullException(nameof(country));

    // Create the request body content to pass to the protocol method.
    // The content will be written using methods defined by the model's
    // implementation of the IJsonModel<T> interface.
    BinaryContent content = BinaryContent.Create(country);

    // Call the protocol method.
    ClientResult result = await AddCountryCodeAsync(content).ConfigureAwait(false);

    // Obtain the response from the ClientResult.
    PipelineResponse response = result.GetRawResponse();

    // Create an instance of the model type representing the service response.
    CountryRegion value = ModelReaderWriter.Read<CountryRegion>(response.Content)!;

    // Create the instance of ClientResult<T> to return from the convenience method.
    return ClientResult.FromValue(value, response);
}
```

#### Protocol method

The client's protocol method calls a helper method to create the message and request, passes the message to `ClientPipeline.Send`, and throws an exception if the response is an error response.

```C# Snippet:ClientImplementationProtocolMethod
// Protocol method.
public virtual async Task<ClientResult> AddCountryCodeAsync(BinaryContent country, RequestOptions? options = null)
{
    // Validate input parameters.
    if (country is null) throw new ArgumentNullException(nameof(country));

    // Use default RequestOptions if none were provided by the caller.
    options ??= new RequestOptions();

    // Create a message that can be sent through the client pipeline.
    using PipelineMessage message = CreateAddCountryCodeRequest(country, options);

    // Send the message.
    _pipeline.Send(message);

    // Obtain the response from the message Response property.
    // The PipelineTransport ensures that the Response value is set
    // so that every policy in the pipeline can access the property.
    PipelineResponse response = message.Response!;

    // If the response is considered an error response, throw an
    // exception that exposes the response details.  The protocol method
    // caller can change the default exception behavior by setting error
    // options differently.
    if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
    {
        // Use the CreateAsync factory method to create an exception instance
        // in an async context. In a sync method, the exception constructor can be used.
        throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
    }

    // Return a ClientResult holding the HTTP response details.
    return ClientResult.FromResponse(response);
}
```

For more information on response classification, see [Configuring error response classification](#configuring-error-response-classification).

#### Request creation helper method

```C# Snippet:ClientImplementationRequestHelper
private PipelineMessage CreateAddCountryCodeRequest(BinaryContent content, RequestOptions options)
{
    // Create an instance of the message to send through the pipeline.
    PipelineMessage message = _pipeline.CreateMessage();

    // Set a response classifier with known success codes for the operation.
    message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

    // Obtain the request to set its values directly.
    PipelineRequest request = message.Request;

    // Set the request method.
    request.Method = "PATCH";

    // Create the URI to set on the request.
    UriBuilder uriBuilder = new(_endpoint.ToString());

    StringBuilder path = new();
    path.Append("countries");
    uriBuilder.Path += path.ToString();

    StringBuilder query = new();
    query.Append("api-version=");
    query.Append(Uri.EscapeDataString(_apiVersion));
    uriBuilder.Query = query.ToString();

    // Set the URI on the request.
    request.Uri = uriBuilder.Uri;

    // Add headers to the request.
    request.Headers.Add("Accept", "application/json");

    // Set the request content.
    request.Content = content;

    // Apply the RequestOptions to the method. This sets properties on the
    // message that the client pipeline will use during processing,
    // including CancellationToken and any headers provided via calls to
    // AddHeader or SetHeader. It also stores policies that will be added
    // to the client pipeline before the first policy processes the message.
    message.Apply(options);

    return message;
}
```

### Configuring error response classification

When a client sends a request to a service, the service may respond with a success response or an error response.  The `PipelineTransport` used by the client's `ClientPipeline` sets the `IsError` property on the response to indicate to the client which category the response falls in.  Service method implementations are expected to check the value of `response.IsError` and throw a `ClientResultException` when it is `true`, as shown in [Basic client implementation](#basic-client-implementation).

To classify the response, the transport uses the `PipelineMessageClassifier` value on the `PipelineMessage.ResponseClassifier` property.  By default, the transport sets `IsError` to `true` for responses with a `4xx` or `5xx` HTTP status code.  Clients can override the default behavior by setting the message classifier before the request is sent.  Typically, a client creates a classifier that sets `response.IsError` to `false` for only response codes that are listed as success codes for the operation in the service's API definition.  This type of status code-based classifier can be created using the `PipelineMessageClassifier.Create` factory method and passing the list of success status codes, as shown in the sample below.

```C# Snippet:ClientStatusCodeClassifier
// Create a message that can be sent via the client pipeline.
PipelineMessage message = _pipeline.CreateMessage();

// Set a classifier that will categorize only responses with status codes
// indicating success for the service operation as non-error responses.
message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 202 });
```

Client authors can also customize classifier logic by creating a custom classifier type derived from `PipelineMessageClassifier`.
