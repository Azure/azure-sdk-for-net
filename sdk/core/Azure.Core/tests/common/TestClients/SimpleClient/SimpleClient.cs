// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Experimental.Tests;

public class SimpleClient
{
    private readonly Uri _endpoint;
    private readonly TokenCredential _credential;
    private readonly HttpPipeline _pipeline;
    private readonly string _apiVersion;
    private readonly SimpleClientOptions _options;

    public SimpleClient(Uri endpoint, TokenCredential credential, SimpleClientOptions options = default)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(credential, nameof(credential));

        options ??= new SimpleClientOptions();

        _endpoint = endpoint;
        _credential = credential;
        _apiVersion = options.Version;

        _pipeline = HttpPipelineBuilder.Build(options);

        _options = options;
    }

    public Uri Endpoint => _endpoint;

    public SimpleClientOptions Options => _options;

    public Task<Response<OutputModel>> GetModelAsync(InputModel input, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Response<OutputModel> GetModel(InputModel input, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Response> GetModelAsync(string content, RequestContext context = default)
    {
        throw new NotImplementedException();
    }

    public Response GetModel(string content, RequestContext context = default)
    {
        throw new NotImplementedException();
    }

    private HttpMessage CreateGetModelRequest(string content, RequestContext options)
    {
        throw new NotImplementedException();
    }
}
