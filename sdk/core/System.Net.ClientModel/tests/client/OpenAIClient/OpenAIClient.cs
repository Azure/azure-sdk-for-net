// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Core.Pipeline;
using System.Net.ClientModel.Internal;
using System.Text;
using System.Threading;

namespace OpenAI;

public class OpenAIClient
{
    private readonly Uri _endpoint;
    private readonly KeyCredential _credential;
    private readonly MessagePipeline _pipeline;
    private readonly TelemetrySource _telemetry;

    public OpenAIClient(Uri endpoint, KeyCredential credential, OpenAIClientOptions options = default)
    {
        ClientUtilities.AssertNotNull(endpoint, nameof(endpoint));
        ClientUtilities.AssertNotNull(credential, nameof(credential));
        options ??= new OpenAIClientOptions();

        _telemetry = new TelemetrySource(options, true);
        _credential = credential;
        _pipeline = MessagePipeline.Create(options, new KeyCredentialPolicy(_credential, "Authorization", "Bearer"));
        _endpoint = endpoint;
    }

    public virtual Result<Completions> GetCompletions(string deploymentId, CompletionsOptions completionsOptions, CancellationToken cancellationToken = default)
    {
        ClientUtilities.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
        ClientUtilities.AssertNotNull(completionsOptions, nameof(completionsOptions));

        RequestOptions context = FromCancellationToken(cancellationToken);
        Result result = GetCompletions(deploymentId, completionsOptions.ToRequestContent(), context);
        PipelineResponse response = result.GetRawResponse();
        Completions completions = Completions.FromResponse(response);
        return Result.FromValue(completions, response);
    }
    public virtual Result GetCompletions(string deploymentId, PipelineContent content, RequestOptions context = null)
    {
        ClientUtilities.AssertNotNullOrEmpty(deploymentId, nameof(deploymentId));
        ClientUtilities.AssertNotNull(content, nameof(content));

        using var scope = _telemetry.CreateSpan("OpenAIClient.GetCompletions");
        scope.Start();
        try
        {
            using PipelineMessage message = CreateGetCompletionsRequest(deploymentId, content, context);
            PipelineResponse response = _pipeline.ProcessMessage(message, context);
            Result result = Result.FromResponse(response);
            return result;
        }
        catch (Exception e)
        {
            scope.Failed(e);
            throw;
        }
    }

    internal PipelineMessage CreateGetCompletionsRequest(string deploymentId, PipelineContent content, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        options.Apply(message);
        PipelineRequest request = message.Request;
        request.Method = "POST";
        UriBuilder uriBuilder = new UriBuilder(_endpoint.ToString());
        StringBuilder path = new StringBuilder();
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
}
