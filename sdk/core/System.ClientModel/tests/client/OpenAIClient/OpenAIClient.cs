﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Text;
using System.Threading;

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

        _pipeline = ClientPipeline.Create(options, new KeyCredentialAuthenticationPolicy(_credential, "Authorization", "Bearer"));
    }

    public virtual OutputMessage<Completions> GetCompletions(string deploymentId, CompletionsOptions completionsOptions, CancellationToken cancellationToken = default)
    {
        ClientUtilities.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
        ClientUtilities.AssertNotNull(completionsOptions, nameof(completionsOptions));

        RequestOptions context = FromCancellationToken(cancellationToken);
        OutputMessage result = GetCompletions(deploymentId, completionsOptions.ToRequestContent(), context);
        PipelineResponse response = result.GetRawResponse();
        Completions completions = Completions.FromResponse(response);
        return OutputMessage.FromValue(completions, response);
    }

    public virtual OutputMessage GetCompletions(string deploymentId, InputContent content, RequestOptions options = null)
    {
        ClientUtilities.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
        ClientUtilities.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateGetCompletionsRequest(deploymentId, content, options);

        PipelineResponse response = _pipeline.ProcessMessage(message, options);
        OutputMessage result = OutputMessage.FromResponse(response);
        return result;
    }

    internal PipelineMessage CreateGetCompletionsRequest(string deploymentId, InputContent content, RequestOptions options)
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

    private static RequestOptions DefaultRequestContext = new RequestOptions();
    internal static RequestOptions FromCancellationToken(CancellationToken cancellationToken = default)
    {
        if (!cancellationToken.CanBeCanceled)
        {
            return DefaultRequestContext;
        }

        return new RequestOptions() { CancellationToken = cancellationToken };
    }

    private static MessageClassifier _messageClassifier200;
    private static MessageClassifier MessageClassifier200 => _messageClassifier200 ??= new ResponseStatusClassifier(stackalloc ushort[] { 200 });
}
