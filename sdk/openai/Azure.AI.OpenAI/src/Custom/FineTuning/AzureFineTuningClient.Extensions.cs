// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Pipeline;
using OpenAI.FineTuning;

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// Extension methods for Azure fine tuning clients.
/// </summary>
internal static class AzureFineTuningClientExtensions
{
    internal static PipelineMessageClassifier PipelineMessageClassifier { get; } =
            PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });

    /// <summary>
    /// Deletes an Azure OpenAI fine tuning job.
    /// </summary>
    /// <param name="client">The Azure OpenAI fine tuning client.</param>
    /// <param name="jobId">The identifier for the fine tuning job to delete.</param>
    /// <param name="options">(Optional) The request options to use.</param>
    /// <returns>True if the job deletion request was sent successfully, false otherwise.</returns>
    /// <remarks>The Azure OpenAI service will always return a success (HTTP 204) regardless of whether or not
    /// the job you are trying to delete exists.</remarks>
    [Experimental("AOAI001")]
    public static bool DeleteJob(this FineTuningClient client, string jobId, RequestOptions? options = null)
#pragma warning disable AZC0106 // Non-public asynchronous method needs 'async' parameter.
        => DeleteJobSyncOrAsync(client, false, jobId, options).EnsureCompleted();
#pragma warning restore AZC0106 // Non-public asynchronous method needs 'async' parameter.

    /// <summary>
    /// Deletes an Azure OpenAI fine tuning job.
    /// </summary>
    /// <param name="client">The Azure OpenAI fine tuning client.</param>
    /// <param name="jobId">The identifier for the fine tuning job to delete.</param>
    /// <param name="options">(Optional) The request options to use.</param>
    /// <returns>True if the job deletion request was sent successfully, false otherwise.</returns>
    /// <remarks>The Azure OpenAI service will always return a success (HTTP 204) regardless of whether or not
    /// the job you are trying to delete exists.</remarks>
    [Experimental("AOAI001")]
    public static Task<bool> DeleteJobAsync(this FineTuningClient client, string jobId, RequestOptions? options = null)
        => DeleteJobSyncOrAsync(client, true, jobId, options).AsTask();

    /// <summary>
    /// Deletes an Azure OpenAI fine tuning job.
    /// </summary>
    /// <param name="client">The Azure OpenAI fine tuning client.</param>
    /// <param name="isAsync">True if this should be an async network request, false otherwise/</param>
    /// <param name="jobId">The identifier for the fine tuning job to delete.</param>
    /// <param name="options">(Optional) The request options to use.</param>
    /// <returns>True if the job deletion request was sent successfully, false otherwise.</returns>
    /// <remarks>The Azure OpenAI service will always return a success (HTTP 204) regardless of whether or not
    /// the job you are trying to delete exists.</remarks>
    [Experimental("AOAI001")]
    internal static async ValueTask<bool> DeleteJobSyncOrAsync(this FineTuningClient client, bool isAsync, string jobId, RequestOptions? options = null)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

        var azureClient = client as AzureFineTuningClient;
        if (azureClient == null)
        {
            throw new InvalidOperationException("Only supported on Azure OpenAI fine tuning clients");
        }

        PipelineMessage message = azureClient.Pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifier;
        message.BufferResponse = options?.BufferResponse ?? true;
        message.Apply(options);

        ClientUriBuilder builder = new();
        builder.Reset(azureClient._endpoint);
        builder.AppendPath("/openai", false);
        builder.AppendPath("/fine_tuning", false);
        builder.AppendPath("/jobs/", false);
        builder.AppendPath(jobId, true);
        builder.AppendQuery("api-version", azureClient._apiVersion, false);

        PipelineRequest request = message.Request;
        request.Method = HttpMethod.Delete.Method;
        request.Uri = builder.ToUri();

        PipelineResponse response;
        if (isAsync)
        {
            response = await azureClient.Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        }
        else
        {
            response = azureClient.Pipeline.ProcessMessage(message, options);
        }

        return !response.IsError;
    }
}
