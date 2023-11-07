// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text;

namespace Maps;

public class MapsClient
{
    private const string LatestServiceVersion = "1.0";

    private readonly Uri _endpoint;
    private readonly KeyCredential _credential;
    private PipelineOptions _pipelineOptions;

    public MapsClient(Uri endpoint, KeyCredential credential, PipelineOptions options = default)
    {
        if (endpoint is null) throw new ArgumentNullException(nameof(endpoint));
        if (credential is null) throw new ArgumentNullException(nameof(credential));

        _endpoint = endpoint;
        _credential = credential;

        // We modify options in-place so callers can get the cached pipeline to save for later.
        options ??= new PipelineOptions();
        options.ServiceVersion ??= LatestServiceVersion;

        // TODO: Can this be simplified?
        if (options.PerCallPolicies is null)
        {
            options.PerCallPolicies = new PipelinePolicy[1];
        }
        else
        {
            var perCallPolicies = new PipelinePolicy[options.PerCallPolicies.Length + 1];
            options.PerCallPolicies.CopyTo(perCallPolicies.AsSpan().Slice(1));
        }

        options.PerCallPolicies[0] = new KeyCredentialAuthenticationPolicy(_credential, "subscription-key");

        // TODO: Do we need to call this here?
        // Is it just to freeze it?  Can we do that differently?
        // Might be nice for only RequestOptions to hold the pipeline?
        // Why?  Thinking about how to separate client-user APIs from client-author APIs
        // and not have to EBN GetPipeline....
        options.GetPipeline();

        _pipelineOptions = options;
    }

    public virtual Result<IPAddressCountryPair> GetCountryCode(IPAddress ipAddress)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        Result result = GetCountryCode(ipAddress.ToString());

        MessageResponse response = result.GetRawResponse();
        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return Result.FromValue(value, response);
    }

    public virtual Result GetCountryCode(string ipAddress, RequestOptions options = null)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        options ??= new RequestOptions(_pipelineOptions);

        using ClientMessage message = CreateGetLocationRequest(ipAddress, options);

        MessagePipeline pipeline = options.GetPipeline();
        pipeline.Send(message);

        MessageResponse response = message.Response;

        if (response.IsError && options.ErrorBehavior == ErrorBehavior.Default)
        {
            throw new UnsuccessfulRequestException(response);
        }

        return Result.FromResponse(response);
    }

    private ClientMessage CreateGetLocationRequest(string ipAddress, RequestOptions options)
    {
        MessagePipeline pipeline = options.GetPipeline();
        ClientMessage message = pipeline.CreateMessage();

        // TODO: this overrides anything the caller passed, so we need to fix that.
        // We have classifier-chaining logic in Azure.Core we can use if that's what we want.
        options.PipelineOptions.MessageClassifier = new ResponseStatusClassifier(stackalloc ushort[] { 200 });
        options.Apply(message);

        MessageRequest request = message.Request;
        request.Method = "GET";

        UriBuilder uriBuilder = new(_endpoint.ToString());

        StringBuilder path = new();
        path.Append("geolocation/ip");
        path.Append("/json");
        uriBuilder.Path += path.ToString();

        StringBuilder query = new();
        query.Append("api-version=");
        query.Append(Uri.EscapeDataString(options.PipelineOptions.ServiceVersion));
        query.Append("&ip=");
        query.Append(Uri.EscapeDataString(ipAddress));
        uriBuilder.Query = query.ToString();

        request.Uri = uriBuilder.Uri;

        request.Headers.Add("Accept", "application/json");

        return message;
    }
}
