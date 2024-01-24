// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Net;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Maps;

public class MapsClient
{
    private readonly Uri _endpoint;
    private readonly AzureKeyCredential _credential;
    private readonly HttpPipeline _pipeline;
    private readonly string _apiVersion;

    public MapsClient(Uri endpoint, AzureKeyCredential credential, MapsClientOptions options = default)
    {
        if (endpoint is null) throw new ArgumentNullException(nameof(endpoint));
        if (credential is null) throw new ArgumentNullException(nameof(credential));

        options ??= new MapsClientOptions();

        _endpoint = endpoint;
        _credential = credential;
        _apiVersion = options.Version;

        _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_credential, "subscription-key") }, new ResponseClassifier());
    }

    public virtual Response<IPAddressCountryPair> GetCountryCode(IPAddress ipAddress, CancellationToken cancellationToken = default)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        RequestContext options = cancellationToken.CanBeCanceled ?
            new RequestContext() { CancellationToken = cancellationToken } :
            new RequestContext();

        Response response = GetCountryCode(ipAddress.ToString(), options);

        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return Response.FromValue(value, response);
    }

    public virtual Response GetCountryCode(string ipAddress, RequestContext context = null)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        context ??= new RequestContext();

        using HttpMessage message = CreateGetLocationRequest(ipAddress, context);

        _pipeline.Send(message, context.CancellationToken);

        Response response = message.Response;

        if (response.IsError && context.ErrorOptions == ErrorOptions.Default)
        {
            throw new RequestFailedException(response);
        }

        return response;
    }

    private HttpMessage CreateGetLocationRequest(string ipAddress, RequestContext context)
    {
        HttpMessage message = _pipeline.CreateMessage();
        message.Apply(context);
        message.ErrorClassifier = ErrorResponseClassifier.Create(stackalloc ushort[] { 200 });

        Request request = message.Request;
        request.Method = RequestMethod.Get;

        RawRequestUriBuilder uriBuilder = new();
        uriBuilder.Reset(_endpoint);
        uriBuilder.AppendRaw("geolocation/ip", false);
        uriBuilder.AppendPath("/json", false);
        uriBuilder.AppendQuery("api-version", _apiVersion, true);
        uriBuilder.AppendQuery("ip", ipAddress, true);
        request.Uri = uriBuilder;

        request.Headers.Add("Accept", "application/json");

        return message;
    }
}
