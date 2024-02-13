﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

    public MapsClient(Uri endpoint, ApiKeyCredential credential, MapsClientOptions options = default)
    {
        if (endpoint is null) throw new ArgumentNullException(nameof(endpoint));
        if (credential is null) throw new ArgumentNullException(nameof(credential));

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
        if (ipAddress is null)
            throw new ArgumentNullException(nameof(ipAddress));

        ClientResult output = await GetCountryCodeAsync(ipAddress.ToString()).ConfigureAwait(false);

        PipelineResponse response = output.GetRawResponse();
        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return ClientResult.FromValue(value, response);
    }

    public virtual async Task<ClientResult> GetCountryCodeAsync(string ipAddress, RequestOptions options = null)
    {
        if (ipAddress is null)
            throw new ArgumentNullException(nameof(ipAddress));

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

        ClientResult output = GetCountryCode(ipAddress.ToString());

        PipelineResponse response = output.GetRawResponse();
        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return ClientResult.FromValue(value, response);
    }

    public virtual ClientResult GetCountryCode(string ipAddress, RequestOptions options = null)
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
        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

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

        // Note: due to addition of SetHeader method on RequestOptions, we now
        // need to apply options at the end of the CreateRequest routine.
        message.Apply(options);

        return message;
    }
}
