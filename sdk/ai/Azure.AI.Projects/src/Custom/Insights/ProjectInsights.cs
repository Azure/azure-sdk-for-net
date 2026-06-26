// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Evaluation;

[Experimental("AAIP001")]
[CodeGenType("Insights")]
public partial class ProjectInsights
{
    /// <summary> Generates an insights report from the provided evaluation configuration. </summary>
    /// <param name="insight"> Complete evaluation configuration including data source, evaluators, and result settings. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="insight"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsInsight> Generate(ProjectsInsight insight, CancellationToken cancellationToken = default)
    {
        return Generate(
            insight: insight,
            foundryFeatures: default,
            cancellationToken: cancellationToken);
    }

    /// <summary> Generates an insights report from the provided evaluation configuration. </summary>
    /// <param name="insight"> Complete evaluation configuration including data source, evaluators, and result settings. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="insight"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsInsight>> GenerateAsync(ProjectsInsight insight, CancellationToken cancellationToken = default)
    {
        return await GenerateAsync(
            insight: insight,
            foundryFeatures: default,
            cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary> Retrieves the specified insight report and its results. </summary>
    /// <param name="id"> The unique identifier for the insights report. </param>
    /// <param name="includeCoordinates"> Whether to include coordinates for visualization in the response. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<ProjectsInsight> Get(string id, bool? includeCoordinates = default, CancellationToken cancellationToken = default)
    {
        return Get(
            id: id,
            foundryFeatures: default,
            includeCoordinates: includeCoordinates,
            cancellationToken: cancellationToken);
    }

    /// <summary> Retrieves the specified insight report and its results. </summary>
    /// <param name="id"> The unique identifier for the insights report. </param>
    /// <param name="includeCoordinates"> Whether to include coordinates for visualization in the response. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<ProjectsInsight>> GetAsync(string id, bool? includeCoordinates = default, CancellationToken cancellationToken = default)
    {
        return await GetAsync(
            id:id,
            foundryFeatures: default,
            includeCoordinates: includeCoordinates,
            cancellationToken: cancellationToken).ConfigureAwait(false);
    }

    /// <summary> Returns insights in reverse chronological order, with the most recent entries first. </summary>
    /// <param name="type"> Filter by the type of analysis. </param>
    /// <param name="evalId"> Filter by the evaluation ID. </param>
    /// <param name="runId"> Filter by the evaluation run ID. </param>
    /// <param name="agentName"> Filter by the agent name. </param>
    /// <param name="includeCoordinates"> Whether to include coordinates for visualization in the response. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<ProjectsInsight> GetAll(InsightType? @type = default, string evalId = default, string runId = default, string agentName = default, bool? includeCoordinates = default, CancellationToken cancellationToken = default)
    {
        return new ProjectInsightsGetAllCollectionResultOfT(
            this,
            default,
            @type?.ToString(),
            evalId,
            runId,
            agentName,
            includeCoordinates,
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns insights in reverse chronological order, with the most recent entries first. </summary>
    /// <param name="type"> Filter by the type of analysis. </param>
    /// <param name="evalId"> Filter by the evaluation ID. </param>
    /// <param name="runId"> Filter by the evaluation run ID. </param>
    /// <param name="agentName"> Filter by the agent name. </param>
    /// <param name="includeCoordinates"> Whether to include coordinates for visualization in the response. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<ProjectsInsight> GetAllAsync(InsightType? @type = default, string evalId = default, string runId = default, string agentName = default, bool? includeCoordinates = default, CancellationToken cancellationToken = default)
    {
        return new ProjectInsightsGetAllAsyncCollectionResultOfT(
            this,
            default,
            @type?.ToString(),
            evalId,
            runId,
            agentName,
            includeCoordinates,
            cancellationToken.ToRequestOptions());
    }
}
