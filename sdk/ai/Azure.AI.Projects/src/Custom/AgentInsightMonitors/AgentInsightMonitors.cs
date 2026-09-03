// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Azure.AI.Projects.Memory;

namespace Azure.AI.Projects;

[Experimental("AAIP001")]
[CodeGenSuppress("GetAll", typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAllAsync", typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAll", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetAllAsync", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetRuns", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(ProjectsJobStatus?), typeof(AgentInsightRunTrigger?), typeof(CancellationToken))]
[CodeGenSuppress("GetRunsAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(ProjectsJobStatus?), typeof(AgentInsightRunTrigger?), typeof(CancellationToken))]
[CodeGenSuppress("GetRuns", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetRunsAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetInsights", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(AgentInsightSeverity?), typeof(AgentInsightStatus?), typeof(bool?), typeof(CancellationToken))]
[CodeGenSuppress("GetInsightsAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(AgentInsightSeverity?), typeof(AgentInsightStatus?), typeof(bool?), typeof(CancellationToken))]
[CodeGenSuppress("GetInsights", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(RequestOptions))]
[CodeGenSuppress("GetInsightsAsync", typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(RequestOptions))]
public partial class AgentInsightMonitors
{
    /// <summary> List Agent Insights monitors, optionally filtered by agent name. </summary>
    /// <param name="after"> A cursor that identifies the last item in the previous page. </param>
    /// <param name="before"> A cursor that identifies the first item in the next page. </param>
    /// <param name="limit"> The maximum number of items to return. Defaults to 20. </param>
    /// <param name="order"> Sort order by creation time. Defaults to descending. </param>
    /// <param name="agentName"> Filter monitors by agent name. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentInsightMonitorListItem> GetAll(string after = default, string before = default, int? limit = default, MemoryStoreListOrder? order = default, string agentName = default, CancellationToken cancellationToken = default)
    {
        return new AgentInsightMonitorsGetAllCollectionResultOfT(
            client: this,
            after: after,
            before: before,
            limit: limit,
            order: order?.ToString(),
            agentName: agentName,
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> List Agent Insights monitors, optionally filtered by agent name. </summary>
    /// <param name="after"> A cursor that identifies the last item in the previous page. </param>
    /// <param name="before"> A cursor that identifies the first item in the next page. </param>
    /// <param name="limit"> The maximum number of items to return. Defaults to 20. </param>
    /// <param name="order"> Sort order by creation time. Defaults to descending. </param>
    /// <param name="agentName"> Filter monitors by agent name. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentInsightMonitorListItem> GetAllAsync(string after = default, string before = default, int? limit = default, MemoryStoreListOrder? order = default, string agentName = default, CancellationToken cancellationToken = default)
    {
        return new AgentInsightMonitorsGetAllAsyncCollectionResultOfT(
            client: this,
            after: after,
            before: before,
            limit: limit,
            order: order?.ToString(),
            agentName: agentName,
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> List Agent Insights runs for a monitor. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="after"> A cursor that identifies the last item in the previous page. </param>
    /// <param name="before"> A cursor that identifies the first item in the next page. </param>
    /// <param name="limit"> The maximum number of items to return. Defaults to 20. </param>
    /// <param name="order"> Sort order by creation time. Defaults to descending. </param>
    /// <param name="status"> Filter runs by status. </param>
    /// <param name="trigger"> Filter runs by trigger. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentInsightRun> GetRuns(string monitorId, string after = default, string before = default, int? limit = default, MemoryStoreListOrder? order = default, ProjectsJobStatus? status = default, AgentInsightRunTrigger? trigger = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        return new AgentInsightMonitorsGetRunsCollectionResultOfT(
            client: this,
            monitorId: monitorId,
            after: after,
            before: before,
            limit: limit,
            order: order?.ToString(),
            status: status?.ToString(),
            trigger: trigger?.ToString(),
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> List Agent Insights runs for a monitor. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="after"> A cursor that identifies the last item in the previous page. </param>
    /// <param name="before"> A cursor that identifies the first item in the next page. </param>
    /// <param name="limit"> The maximum number of items to return. Defaults to 20. </param>
    /// <param name="order"> Sort order by creation time. Defaults to descending. </param>
    /// <param name="status"> Filter runs by status. </param>
    /// <param name="trigger"> Filter runs by trigger. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentInsightRun> GetRunsAsync(string monitorId, string after = default, string before = default, int? limit = default, MemoryStoreListOrder? order = default, ProjectsJobStatus? status = default, AgentInsightRunTrigger? trigger = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        return new AgentInsightMonitorsGetRunsAsyncCollectionResultOfT(
            client: this,
            monitorId: monitorId,
            after: after,
            before: before,
            limit: limit,
            order: order?.ToString(),
            status: status?.ToString(),
            trigger: trigger?.ToString(),
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> List current insights for an Agent Insights monitor. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="after"> A cursor that identifies the last item in the previous page. </param>
    /// <param name="before"> A cursor that identifies the first item in the next page. </param>
    /// <param name="limit"> The maximum number of items to return. Defaults to 20. </param>
    /// <param name="order"> Sort order by creation time. Defaults to descending. </param>
    /// <param name="category"> Filter insights by category. </param>
    /// <param name="severity"> Filter insights by severity. </param>
    /// <param name="status"> Filter insights by lifecycle status. </param>
    /// <param name="includeDetails"> Whether to include expanded insight details such as evidence and run links in the response. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual CollectionResult<AgentInsight> GetInsights(string monitorId, string after = default, string before = default, int? limit = default, MemoryStoreListOrder? order = default, string category = default, AgentInsightSeverity? severity = default, AgentInsightStatus? status = default, bool? includeDetails = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        return new AgentInsightMonitorsGetInsightsCollectionResultOfT(
            client: this,
            monitorId: monitorId,
            after: after,
            before: before,
            limit: limit,
            order: order?.ToString(),
            category: category,
            severity: severity?.ToString(),
            status: status?.ToString(),
            includeDetails: includeDetails,
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> List current insights for an Agent Insights monitor. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="after"> A cursor that identifies the last item in the previous page. </param>
    /// <param name="before"> A cursor that identifies the first item in the next page. </param>
    /// <param name="limit"> The maximum number of items to return. Defaults to 20. </param>
    /// <param name="order"> Sort order by creation time. Defaults to descending. </param>
    /// <param name="category"> Filter insights by category. </param>
    /// <param name="severity"> Filter insights by severity. </param>
    /// <param name="status"> Filter insights by lifecycle status. </param>
    /// <param name="includeDetails"> Whether to include expanded insight details such as evidence and run links in the response. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual AsyncCollectionResult<AgentInsight> GetInsightsAsync(string monitorId, string after = default, string before = default, int? limit = default, MemoryStoreListOrder? order = default, string category = default, AgentInsightSeverity? severity = default, AgentInsightStatus? status = default, bool? includeDetails = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        return new AgentInsightMonitorsGetInsightsAsyncCollectionResultOfT(
            client: this,
            monitorId: monitorId,
            after: after,
            before: before,
            limit: limit,
            order: order?.ToString(),
            category: category,
            severity: severity?.ToString(),
            status: status?.ToString(),
            includeDetails: includeDetails,
            options: cancellationToken.ToRequestOptions());
    }
}
