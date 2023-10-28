// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text;
using System.Threading;

namespace Maps;

public class MapsClient
{
    private readonly Uri _endpoint;
    private readonly KeyCredential _credential;
    private readonly MessagePipeline _pipeline;
    private readonly string _apiVersion;

    public MapsClient(Uri endpoint, KeyCredential credential, MapsClientOptions options = default)
    {
        ClientUtilities.AssertNotNull(endpoint, nameof(endpoint));
        ClientUtilities.AssertNotNull(credential, nameof(credential));

        options ??= new MapsClientOptions();

        _credential = credential;
        _pipeline = MessagePipeline.Create(options, new KeyCredentialAuthenticationPolicy(_credential, "Authorization", "Bearer"));
        _endpoint = endpoint;
        _apiVersion = options.Version;
    }

    public virtual Result<IPAddressCountryPair> GetCountryCode(IPAddress ipAddress, CancellationToken cancellationToken = default)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        RequestOptions options = FromCancellationToken(cancellationToken);

        Result result = GetCountryCode(ipAddress.ToString(), options);

        PipelineResponse response = result.GetRawResponse();
        IPAddressCountryPair value = IPAddressCountryPair.FromResponse(response);

        return Result.FromValue(value, response);
    }

    public virtual Result GetCountryCode(string ipAddress, RequestOptions options = null)
    {
        if (ipAddress is null) throw new ArgumentNullException(nameof(ipAddress));

        options ??= new RequestOptions();
        options.MessageClassifier = MessageClassifier200;

        using PipelineMessage message = CreateGetLocationRequest(ipAddress, options);

        // TODO: do this out instead of using extensions
        PipelineResponse response = _pipeline.ProcessMessage(message, options);

        return Result.FromResponse(response);
    }

    internal PipelineMessage CreateGetLocationRequest(string ipAddress, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        options.Apply(message);

        PipelineRequest request = message.Request;
        request.Method = "GET";

        UriBuilder uriBuilder = new(_endpoint.ToString());
        StringBuilder path = new();
        path.Append("/geolocation/ip/");
        path.Append("json");
        path.Append("?api-version=");
        path.Append(Uri.EscapeDataString(_apiVersion));
        path.Append("&ip=");
        path.Append(Uri.EscapeDataString(ipAddress));
        uriBuilder.Path += path.ToString();
        request.Uri = uriBuilder.Uri;

        request.Headers.Add("Accept", "application/json");

        return message;
    }

    private static RequestOptions DefaultRequestOptions = new RequestOptions();
    internal static RequestOptions FromCancellationToken(CancellationToken cancellationToken = default)
    {
        if (!cancellationToken.CanBeCanceled)
        {
            return DefaultRequestOptions;
        }

        return new RequestOptions() { CancellationToken = cancellationToken };
    }

    private static MessageClassifier _messageClassifier200;
    private static MessageClassifier MessageClassifier200 => _messageClassifier200 ??= new ResponseStatusClassifier(stackalloc ushort[] { 200 });
}
