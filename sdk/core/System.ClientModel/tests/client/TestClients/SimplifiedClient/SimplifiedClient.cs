// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.ReferenceClients.SimplifiedClient;

public class SimplifiedClient
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _credential;
    private readonly ClientPipeline _pipeline;
    private readonly string _apiVersion;

    public SimplifiedClient(Uri endpoint, ApiKeyCredential credential, SimplifiedClientOptions? options = default)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNull(credential, nameof(credential));

        options ??= new SimplifiedClientOptions();

        _endpoint = endpoint;
        _credential = credential;
        _apiVersion = options.Version;

        var authenticationPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "subscription-key");
        _pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { authenticationPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
    }

    public ClientPipeline Pipeline => _pipeline;

    // Convenience method - async
    public virtual async Task<ClientResult<OutputModel>> GetModelAsync(InputModel inputModel, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputModel, nameof(inputModel));

        BinaryContent content = (BinaryContent)inputModel;

        ClientResult result = await GetModelAsync(content, cancellationToken.ToRequestOptions());

        OutputModel outputModel = (OutputModel)result;

        return ClientResult.FromValue(outputModel, result.GetRawResponse());
    }

    // Convenience method - sync
    public virtual ClientResult<OutputModel> GetModel(InputModel inputModel, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(inputModel, nameof(inputModel));

        BinaryContent content = (BinaryContent)inputModel;

        ClientResult result = GetModel(content, cancellationToken.ToRequestOptions());

        OutputModel outputModel = (OutputModel)result;

        return ClientResult.FromValue(outputModel, result.GetRawResponse());
    }

    // Protocol method - async
    public virtual Task<ClientResult> GetModelAsync(BinaryContent content, RequestOptions? options = default)
    {
        throw new NotImplementedException();
    }

    // Protocol method - sync
    public virtual ClientResult GetModel(BinaryContent content, RequestOptions? options = default)
    {
        throw new NotImplementedException();
    }

    // Request creation helper
    private PipelineMessage CreateGetModelRequest(BinaryContent content, RequestOptions? options)
    {
        PipelineMessage message = Pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier200;
        PipelineRequest request = message.Request;
        request.Method = "POST";
        ClientUriBuilder uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/literal", false);
        request.Uri = uri.ToUri();
        request.Headers.Set("Content-Type", "application/json");
        request.Headers.Set("Accept", "application/json");
        request.Content = content;
        message.Apply(options);
        return message;
    }

    private static PipelineMessageClassifier? _pipelineMessageClassifier200;
    private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}
