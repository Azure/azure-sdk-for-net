// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class MapsClient
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _credential;
    private readonly ClientPipeline _pipeline;

    public MapsClient()
    {
    }

    public MapsClient(Uri endpoint, ApiKeyCredential credential, MapsClientOptions options = default)
    {
        options ??= new MapsClientOptions();
        _endpoint = endpoint;
        _credential = credential;
        var authenticationPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "subscription-key");
        _pipeline = ClientPipeline.Create(options, [], [authenticationPolicy], []);
    }

    public virtual async Task<ClientResult<IPAddressCountryPair>> GetCountryCodeAsync(IPAddress ipAddress)
    {
        ClientResult result = await GetCountryCodeAsync(ipAddress.ToString()).ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();
        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult> GetCountryCodeAsync(string ipAddress, RequestOptions options = null)
    {
        options ??= new RequestOptions();

        using PipelineMessage message = CreateGetLocationRequest(ipAddress, options);

        await _pipeline.SendAsync(message);

        PipelineResponse response = message.Response!;

        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
        }

        return ClientResult.FromResponse(response);
    }

    public virtual ClientResult<IPAddressCountryPair> GetCountryCode(IPAddress ipAddress)
    {
        ClientResult result = GetCountryCode(ipAddress.ToString());

        PipelineResponse response = result.GetRawResponse();
        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return ClientResult.FromValue(value, response);
    }

    public virtual ClientResult GetCountryCode(string ipAddress, RequestOptions options = null)
    {
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
        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier.Create([200]);

        PipelineRequest request = message.Request;
        request.Method = "GET";
        UriBuilder uriBuilder = new(_endpoint.ToString());
        StringBuilder path = new();
        path.Append("geolocation/ip");
        path.Append("/json");
        uriBuilder.Path += path.ToString();
        StringBuilder query = new();
        query.Append("&ip=");
        query.Append(Uri.EscapeDataString(ipAddress));
        uriBuilder.Query = query.ToString();
        request.Uri = uriBuilder.Uri;
        request.Headers.Add("Accept", "application/json");

        message.Apply(options);
        return message;
    }

    public virtual async Task<ClientResult<CountryRegion>> AddCountryCodeAsync(CountryRegion country)
    {
        BinaryContent content = BinaryContent.Create(country);

        ClientResult result = await AddCountryCodeAsync(content).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();

        CountryRegion value = ModelReaderWriter.Read<CountryRegion>(response.Content)!;

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult> AddCountryCodeAsync(BinaryContent country, RequestOptions options = null)
    {
        options ??= new RequestOptions();

        using PipelineMessage message = CreateAddCountryCodeRequest(country, options);

        _pipeline.Send(message);
        PipelineResponse response = message.Response!;

        if (response.IsError && options.ErrorOptions == ClientErrorBehaviors.Default)
        {
            throw await ClientResultException.CreateAsync(response).ConfigureAwait(false);
        }

        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateAddCountryCodeRequest(BinaryContent content, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier.Create([200]);

        PipelineRequest request = message.Request;
        request.Method = "PATCH";
        UriBuilder uriBuilder = new(_endpoint.ToString());
        StringBuilder path = new();
        path.Append("countries");
        uriBuilder.Path += path.ToString();
        request.Uri = uriBuilder.Uri;
        request.Headers.Add("Accept", "application/json");
        request.Content = content;

        message.Apply(options);
        return message;
    }
}
