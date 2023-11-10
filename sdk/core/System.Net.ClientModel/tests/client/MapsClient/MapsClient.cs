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
    private readonly Uri _endpoint;
    private readonly KeyCredential _credential;
    private readonly string _serviceVersion;

    private readonly PipelineOptions _pipelineOptions;
    private readonly PipelinePolicy[] _clientPolicies;

    public MapsClient(Uri endpoint, KeyCredential credential, MapsClientOptions options = default)
    {
        if (endpoint is null) throw new ArgumentNullException(nameof(endpoint));
        if (credential is null) throw new ArgumentNullException(nameof(credential));

        options ??= new MapsClientOptions();

        _endpoint = endpoint;
        _credential = credential;
        _serviceVersion = options.Version;

        _clientPolicies = new PipelinePolicy[1];
        _clientPolicies[0] = new KeyCredentialAuthenticationPolicy(_credential, "subscription-key");

        // This creates the pipeline, caches it in options, and freezes the options.
        ClientPipeline.GetPipeline(this, options, _clientPolicies);

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

        using PipelineMessage message = CreateGetLocationRequest(ipAddress, options);

        ClientPipeline pipeline = ClientPipeline.GetPipeline(this, options, _clientPolicies);
        pipeline.Send(message);

        MessageResponse response = message.Response;

        if (response.IsError && options.ErrorBehavior == ErrorBehavior.Default)
        {
            throw new ClientRequestException(response);
        }

        return Result.FromResponse(response);
    }

    private PipelineMessage CreateGetLocationRequest(string ipAddress, RequestOptions options)
    {
        // TODO: this overrides anything the caller passed, so we need to fix that.
        // We have classifier-chaining logic in Azure.Core we can use if that's what we want.
        options.MessageClassifier = new ResponseStatusClassifier(stackalloc ushort[] { 200 });

        ClientPipeline pipeline = ClientPipeline.GetPipeline(this, options, _clientPolicies);
        PipelineMessage message = pipeline.CreateMessage(options);

        MessageRequest request = message.Request;
        request.Method = "GET";

        UriBuilder uriBuilder = new(_endpoint.ToString());

        StringBuilder path = new();
        path.Append("geolocation/ip");
        path.Append("/json");
        uriBuilder.Path += path.ToString();

        StringBuilder query = new();
        query.Append("api-version=");
        query.Append(Uri.EscapeDataString(_serviceVersion));
        query.Append("&ip=");
        query.Append(Uri.EscapeDataString(ipAddress));
        uriBuilder.Query = query.ToString();

        request.Uri = uriBuilder.Uri;

        request.Headers.Add("Accept", "application/json");

        return message;
    }
}
