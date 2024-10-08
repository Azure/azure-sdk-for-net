// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.ReferenceClients.SimpleClient;

public class SimpleClient
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _credential;
    private readonly ClientPipeline _pipeline;
    private readonly string _apiVersion;

    public SimpleClient(SimpleClientOptions? options = default)
        : this(new Uri("https://www.example.com"), new ApiKeyCredential("fake_key"))
    {
        // Provided to make test illustrations simpler - not typical for a client implementation
    }

    public SimpleClient(Uri endpoint, ApiKeyCredential credential, SimpleClientOptions? options = default)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(credential, nameof(credential));

        options ??= new SimpleClientOptions();

        _endpoint = endpoint;
        _credential = credential;
        _apiVersion = options.Version;

        var authenticationPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "subscription-key");
        _pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { authenticationPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
    }

    // Convenience method - async
    public Task<ClientResult<OutputModel>> GetModelAsync(InputModel input, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // Convenience method - sync
    public ClientResult<OutputModel> GetModel(InputModel input, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    // Protocol method - async
    public Task<ClientResult> GetModelAsync(BinaryContent content, RequestOptions? options = default)
    {
        throw new NotImplementedException();
    }

    // Protocol method - sync
    public ClientResult GetModel(BinaryContent content, RequestOptions? options = default)
    {
        throw new NotImplementedException();
    }

    // Request creation helper
    private PipelineMessage CreateGetModelRequest(BinaryContent content, RequestOptions? options)
    {
        throw new NotImplementedException();
    }
}
