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
    private readonly MessagePipeline _pipeline;

    public OpenAIClient(Uri endpoint, KeyCredential credential, PipelineOptions options = default)
    {
        if (endpoint is null) throw new ArgumentNullException(nameof(endpoint));
        if (credential is null) throw new ArgumentNullException(nameof(credential));

        options ??= new PipelineOptions();

        _endpoint = endpoint;
        _credential = credential;

        if (options.PerCallPolicies is null)
        {
            options.PerCallPolicies = new PipelinePolicy[1];
        }
        else
        {
            var perCallPolicies = new PipelinePolicy[options.PerCallPolicies.Length + 1];
            options.PerCallPolicies.CopyTo(perCallPolicies.AsSpan().Slice(1));
        }

        options.PerCallPolicies[0] = new KeyCredentialAuthenticationPolicy(_credential, "Authorization", "Bearer");

        _pipeline = MessagePipeline.Create(options);
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

    public virtual Result GetCompletions(string deploymentId, RequestBody content, RequestOptions options = null)
    {
        if (deploymentId is null) throw new ArgumentNullException(nameof(deploymentId));
        if (deploymentId.Length == 0) throw new ArgumentException("Value cannot be an empty string.", nameof(deploymentId));
        if (content is null) throw new ArgumentNullException(nameof(content));

        options ??= new RequestOptions();

        using ClientMessage message = CreateGetCompletionsRequest(deploymentId, content, options);

        _pipeline.Send(message);

        MessageResponse response = message.Response;

        if (response.IsError && options.ErrorBehavior == ErrorBehavior.Default)
        {
            throw new UnsuccessfulRequestException(response);
        }

        return Result.FromResponse(response);
    }

    internal ClientMessage CreateGetCompletionsRequest(string deploymentId, RequestBody content, RequestOptions options)
    {
        ClientMessage message = _pipeline.CreateMessage();

        // TODO: per precedence rules, we should not override a customer-specified message classifier.
        options.MessageClassifier = MessageClassifier200;
        options.Apply(message);

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

        request.Body = content;

        return message;
    }

    private static MessageClassifier _messageClassifier200;
    private static MessageClassifier MessageClassifier200 => _messageClassifier200 ??= new ResponseStatusClassifier(stackalloc ushort[] { 200 });
}
