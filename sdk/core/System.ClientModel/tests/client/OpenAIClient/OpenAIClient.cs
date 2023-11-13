// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ClientModel.Internal;
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
        ClientUtilities.AssertNotNull(endpoint, nameof(endpoint));
        ClientUtilities.AssertNotNull(credential, nameof(credential));
        options ??= new OpenAIClientOptions();

        _endpoint = endpoint;
        _credential = credential;

        if (options.PerCallPolicies is null)
        {
            options.PerCallPolicies = new PipelinePolicy[1];
        }
        else
        {
            var perCallPolicies = new PipelinePolicy[options.PerCallPolicies.Length + 1];
            options.PerCallPolicies.CopyTo(perCallPolicies.AsSpan());
        }

        options.PerCallPolicies[options.PerCallPolicies.Length - 1] = new KeyCredentialAuthenticationPolicy(_credential, "Authorization", "Bearer");

        _pipeline = ClientPipeline.Create(options);
    }

    public virtual Result<Completions> GetCompletions(string deploymentId, CompletionsOptions completionsOptions, CancellationToken cancellationToken = default)
    {
        ClientUtilities.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
        ClientUtilities.AssertNotNull(completionsOptions, nameof(completionsOptions));

        RequestOptions context = FromCancellationToken(cancellationToken);
        Result result = GetCompletions(deploymentId, completionsOptions.ToRequestContent(), context);
        MessageResponse response = result.GetRawResponse();
        Completions completions = Completions.FromResponse(response);
        return Result.FromValue(completions, response);
    }

    public virtual Result GetCompletions(string deploymentId, InputContent content, RequestOptions options = null)
    {
        ClientUtilities.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
        ClientUtilities.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateGetCompletionsRequest(deploymentId, content, options);

        // TODO: per precedence rules, we should not override a customer-specified message classifier.
        options.MessageClassifier = MessageClassifier200;

        MessageResponse response = _pipeline.ProcessMessage(message, options);
        Result result = Result.FromResponse(response);
        return result;
    }

    internal PipelineMessage CreateGetCompletionsRequest(string deploymentId, InputContent content, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
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
