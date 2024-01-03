﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    private readonly ClientPipeline _pipeline;

    public OpenAIClient(Uri endpoint, KeyCredential credential, OpenAIClientOptions options = default)
    {
        if (endpoint is null) throw new ArgumentNullException(nameof(endpoint));
        if (credential is null) throw new ArgumentNullException(nameof(credential));

        options ??= new OpenAIClientOptions();

        _endpoint = endpoint;
        _credential = credential;

        var authenticationPolicy = KeyCredentialAuthenticationPolicy.CreateHeaderPolicy(_credential, "Authorization", "Bearer");
        _pipeline = ClientPipeline.Create(options, authenticationPolicy);
    }

    public virtual ClientResult<Completions> GetCompletions(string deploymentId, CompletionsOptions completionsOptions)
    {
        if (deploymentId is null) throw new ArgumentNullException(nameof(deploymentId));
        if (deploymentId.Length == 0) throw new ArgumentException("Value cannot be an empty string.", nameof(deploymentId));
        if (completionsOptions is null) throw new ArgumentNullException(nameof(completionsOptions));

        BinaryContent content = BinaryContent.Create(completionsOptions);
        ClientResult result = GetCompletions(deploymentId, content);

        PipelineResponse response = result.GetRawResponse();
        Completions completions = Completions.FromResponse(response);

        return ClientResult.FromValue(completions, response);
    }

    public virtual ClientResult GetCompletions(string deploymentId, BinaryContent content, RequestOptions options = null)
    {
        if (deploymentId is null) throw new ArgumentNullException(nameof(deploymentId));
        if (deploymentId.Length == 0) throw new ArgumentException("Value cannot be an empty string.", nameof(deploymentId));
        if (content is null) throw new ArgumentNullException(nameof(content));

        options ??= new RequestOptions();

        using PipelineMessage message = CreateGetCompletionsRequest(deploymentId, content, options);

        _pipeline.Send(message);

        PipelineResponse response = message.Response;

        if (response.IsError && options.ErrorBehavior == ErrorBehavior.Default)
        {
            throw new ClientRequestException(response);
        }

        return ClientResult.FromResponse(response);
    }

    internal PipelineMessage CreateGetCompletionsRequest(string deploymentId, BinaryContent content, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.Apply(options, MessageClassifier200);

        PipelineRequest request = message.Request;
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

    private static PipelineMessageClassifier _messageClassifier200;
    private static PipelineMessageClassifier MessageClassifier200 => _messageClassifier200 ??= new ResponseStatusClassifier(stackalloc ushort[] { 200 });
}
