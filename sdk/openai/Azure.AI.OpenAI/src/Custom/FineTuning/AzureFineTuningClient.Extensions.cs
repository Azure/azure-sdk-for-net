// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

#nullable enable

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using OpenAI.FineTuning;

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// Extension methods for Azure fine tuning clients.
/// </summary>
[Experimental("AOAI001")]
internal static class AzureFineTuningClientExtensions
{
    /// <summary>
    /// Deletes an Azure OpenAI fine tuning job.
    /// </summary>
    /// <param name="client">The Azure OpenAI fine tuning client.</param>
    /// <param name="jobId">The identifier for the fine tuning job to delete.</param>
    /// <param name="options">(Optional) The request options to use.</param>
    /// <returns>The request result.</returns>
    /// <remarks>The Azure OpenAI service will always return a success (HTTP 204) regardless of whether or not
    /// the job you are trying to delete exists.</remarks>
    [Experimental("AOAI001")]
    public static ClientResult DeleteJob(this FineTuningClient client, string jobId, RequestOptions? options = null)
    {
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
        return Cast(client).DeleteJob(jobId, options);
    }

    /// <summary>
    /// Deletes an Azure OpenAI fine tuning job.
    /// </summary>
    /// <param name="client">The Azure OpenAI fine tuning client.</param>
    /// <param name="jobId">The identifier for the fine tuning job to delete.</param>
    /// <param name="options">(Optional) The request options to use.</param>
    /// <returns>The request result.</returns>
    /// <remarks>The Azure OpenAI service will always return a success (HTTP 204) regardless of whether or not
    /// the job you are trying to delete exists.</remarks>
    [Experimental("AOAI001")]
    public static Task<ClientResult> DeleteJobAsync(this FineTuningClient client, string jobId, RequestOptions? options = null)
    {
        Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
        return Cast(client).DeleteJobAsync(jobId, options);
    }

    private static AzureFineTuningClient Cast(FineTuningClient? client)
    {
        Argument.AssertNotNull(client, nameof(client));
        var azureClient = client as AzureFineTuningClient;
        if (azureClient == null)
        {
            throw new InvalidOperationException("Only supported on Azure OpenAI fine tuning clients");
        }

        return azureClient;
    }
}

#endif