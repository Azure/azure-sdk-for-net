// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Maps;

public class MapsClient
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _credential;
    private readonly ClientPipeline _pipeline;
    private readonly string _apiVersion;

    public MapsClient(Uri endpoint, ApiKeyCredential credential, MapsClientOptions? options = default)
    {
        if (endpoint is null)
            throw new ArgumentNullException(nameof(endpoint));
        if (credential is null)
            throw new ArgumentNullException(nameof(credential));

        options ??= new MapsClientOptions();

        _endpoint = endpoint;
        _credential = credential;
        _apiVersion = options.Version;

        var authenticationPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "subscription-key");
        _pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { authenticationPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
    }

    public virtual async Task<ClientResult<IPAddressCountryPair>> GetCountryCodeAsync(IPAddress ipAddress)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        ClientResult result = await GetCountryCodeAsync(ipAddress.ToString()).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();
        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult> GetCountryCodeAsync(string ipAddress, RequestOptions? options = null)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        options ??= new RequestOptions();

        using PipelineMessage message = CreateGetLocationRequest(ipAddress, options);

        _pipeline.Send(message);

        PipelineResponse response = message.Response!;

        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
        }

        return ClientResult.FromResponse(response);
    }

    public virtual ClientResult<IPAddressCountryPair> GetCountryCode(IPAddress ipAddress)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        ClientResult result = GetCountryCode(ipAddress.ToString());

        PipelineResponse response = result.GetRawResponse();
        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return ClientResult.FromValue(value, response);
    }

    public virtual ClientResult GetCountryCode(string ipAddress, RequestOptions? options = null)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        options ??= new RequestOptions();

        using PipelineMessage message = CreateGetLocationRequest(ipAddress, options);

        _pipeline.Send(message);

        PipelineResponse response = message.Response!;

        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw new ClientResultException(response);
        }

        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateGetLocationRequest(string ipAddress, RequestOptions options)
    {
        // Create an instance of the message to send through the pipeline.
        PipelineMessage message = _pipeline.CreateMessage();

        // Set a response classifier with known success codes for the operation.
        message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

        // Set request values needed by the service.
        PipelineRequest request = message.Request;
        request.Method = "GET";

        UriBuilder uriBuilder = new(_endpoint.ToString());

        StringBuilder path = new();
        path.Append("geolocation/ip");
        path.Append("/json");
        uriBuilder.Path += path.ToString();

        StringBuilder query = new();
        query.Append("api-version=");
        query.Append(Uri.EscapeDataString(_apiVersion));
        query.Append("&ip=");
        query.Append(Uri.EscapeDataString(ipAddress));
        uriBuilder.Query = query.ToString();

        request.Uri = uriBuilder.Uri;

        request.Headers.Add("Accept", "application/json");

        message.Apply(options);

        return message;
    }

    // Fake method used to illlustrate creating input content in ClientModel
    // samples. No such operation exists on the Azure Maps service, and this
    // operation implementation will not succeed against a live service.

    #region Snippet:ClientImplementationConvenienceMethod
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
    #endregion

    #region Snippet:ClientImplementationProtocolMethod
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
    #endregion

    #region Snippet:ClientImplementationRequestHelper
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
    #endregion
}
