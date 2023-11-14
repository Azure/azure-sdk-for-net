// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text;

namespace OpenAI;

public class OpenAIClient
{
    private readonly Uri _endpoint;
    private readonly KeyCredential _credential;

    private readonly PipelineOptions _pipelineOptions;
    private readonly PipelinePolicy[] _clientPolicies;

    public OpenAIClient(Uri endpoint, KeyCredential credential, OpenAIClientOptions options = default)
    {
        if (endpoint is null) throw new ArgumentNullException(nameof(endpoint));
        if (credential is null) throw new ArgumentNullException(nameof(credential));

        _endpoint = endpoint;
        _credential = credential;

        options ??= new OpenAIClientOptions();

        _clientPolicies = new PipelinePolicy[1];
        _clientPolicies[0] = new KeyCredentialAuthenticationPolicy(_credential, "Authorization", "Bearer");

        ClientPipeline.GetPipeline(this, options, _clientPolicies);

        _pipelineOptions = options;
    }

    public virtual Result<Completions> GetCompletions(string deploymentId, CompletionsOptions completionsOptions)
    {
        if (deploymentId is null) throw new ArgumentNullException(nameof(deploymentId));
        if (deploymentId.Length == 0) throw new ArgumentException("Value cannot be an empty string.", nameof(deploymentId));
        if (completionsOptions is null) throw new ArgumentNullException(nameof(completionsOptions));

        Result result = GetCompletions(deploymentId, completionsOptions.ToRequestContent());

        MessageResponse response = result.GetRawResponse();
        Completions completions = Completions.FromResponse(response);

        return Result.FromValue(completions, response);
    }

    public virtual Result GetCompletions(string deploymentId, InputContent content, RequestOptions options = null)
    {
        if (deploymentId is null) throw new ArgumentNullException(nameof(deploymentId));
        if (deploymentId.Length == 0) throw new ArgumentException("Value cannot be an empty string.", nameof(deploymentId));
        if (content is null) throw new ArgumentNullException(nameof(content));

        options ??= new RequestOptions(_pipelineOptions);

        using PipelineMessage message = CreateGetCompletionsRequest(deploymentId, content, options);

        ClientPipeline pipeline = ClientPipeline.GetPipeline(this, options, _clientPolicies);
        pipeline.Send(message);

        MessageResponse response = message.Response;

        if (response.IsError && options.ErrorBehavior == ErrorBehavior.Default)
        {
            throw new ClientRequestException(response);
        }

        return Result.FromResponse(response);
    }

    internal PipelineMessage CreateGetCompletionsRequest(string deploymentId, InputContent content, RequestOptions options)
    {
        ClientPipeline pipeline = ClientPipeline.GetPipeline(this, options, _clientPolicies);
        PipelineMessage message = pipeline.CreateMessage();
        options.Apply(message, MessageClassifier200);

        MessageRequest request = message.Request;
        request.Method = "POST";

        UriBuilder uriBuilder = new(_endpoint.ToString());
        StringBuilder path = new();
        path.Append("v1");
        path.Append("/completions");
        uriBuilder.Path += path.ToString();
        request.Uri = uriBuilder.Uri;

        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("Content-Type", "application/json");

        request.Content = content;

        return message;
    }

    private static MessageClassifier _messageClassifier200;
    private static MessageClassifier MessageClassifier200 => _messageClassifier200 ??= new ResponseStatusClassifier(stackalloc ushort[] { 200 });
}
