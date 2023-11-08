// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text;

namespace OpenAI;

public class OpenAIClient
{
    private readonly Uri _endpoint;
    private readonly KeyCredential _credential;
    private readonly PipelineOptions _pipelineOptions;
    private readonly PipelinePolicy[] _clientPolicies;

    public OpenAIClient(Uri endpoint, KeyCredential credential, PipelineOptions options = default)
    {
        if (endpoint is null) throw new ArgumentNullException(nameof(endpoint));
        if (credential is null) throw new ArgumentNullException(nameof(credential));

        _endpoint = endpoint;
        _credential = credential;

        options ??= new PipelineOptions();

        _clientPolicies = new PipelinePolicy[1];
        _clientPolicies[0] = new KeyCredentialAuthenticationPolicy(_credential, "Authorization", "Bearer");

        MessagePipeline.Create(options, _clientPolicies);

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

    public virtual Result GetCompletions(string deploymentId, RequestBodyContent content, RequestOptions options = null)
    {
        if (deploymentId is null) throw new ArgumentNullException(nameof(deploymentId));
        if (deploymentId.Length == 0) throw new ArgumentException("Value cannot be an empty string.", nameof(deploymentId));
        if (content is null) throw new ArgumentNullException(nameof(content));

        options ??= new RequestOptions(_pipelineOptions);

        using ClientMessage message = CreateGetCompletionsRequest(deploymentId, content, options);

        options.Pipeline.Send(message);

        MessageResponse response = message.Response;

        if (response.IsError && options.ErrorBehavior == ErrorBehavior.Default)
        {
            throw new UnsuccessfulRequestException(response);
        }

        return Result.FromResponse(response);
    }

    internal ClientMessage CreateGetCompletionsRequest(string deploymentId, RequestBodyContent content, RequestOptions options)
    {
        // TODO: per precedence rules, we should not override a customer-specified message classifier.
        options.PipelineOptions.MessageClassifier = MessageClassifier200;

        MessagePipeline.Create(options.PipelineOptions, _clientPolicies);

        ClientMessage message = options.Pipeline.CreateMessage(options);

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
