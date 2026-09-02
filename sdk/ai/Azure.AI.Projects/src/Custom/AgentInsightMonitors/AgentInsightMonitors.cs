// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Memory;

namespace Azure.AI.Projects;

[CodeGenSuppress("Create", typeof(AgentInsightMonitorCreate), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("CreateAsync", typeof(AgentInsightMonitorCreate), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("Get", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("GetAsync", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("GetAll", typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetAllAsync", typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("Delete", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("DeleteAsync", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("CreateRun", typeof(bool), typeof(string), typeof(AgentInsightRunCreate), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("CreateRunAsync", typeof(bool), typeof(string), typeof(AgentInsightRunCreate), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("GetRuns", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(ProjectsJobStatus?), typeof(AgentInsightRunTrigger?), typeof(CancellationToken))]
[CodeGenSuppress("GetRunsAsync", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(ProjectsJobStatus?), typeof(AgentInsightRunTrigger?), typeof(CancellationToken))]
[CodeGenSuppress("GetRun", typeof(string), typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("GetRunAsync", typeof(string), typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("CancelRun", typeof(string), typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("CancelRunAsync", typeof(string), typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(CancellationToken))]
[CodeGenSuppress("GetInsights", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(AgentInsightSeverity?), typeof(AgentInsightStatus?), typeof(bool?), typeof(CancellationToken))]
[CodeGenSuppress("GetInsightsAsync", typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(string), typeof(string), typeof(int?), typeof(MemoryStoreListOrder?), typeof(string), typeof(AgentInsightSeverity?), typeof(AgentInsightStatus?), typeof(bool?), typeof(CancellationToken))]
[CodeGenSuppress("GetInsight", typeof(string), typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(bool?), typeof(CancellationToken))]
[CodeGenSuppress("GetInsightAsync", typeof(string), typeof(string), typeof(FoundryFeaturesOptInKeys?), typeof(bool?), typeof(CancellationToken))]
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
            foundryFeatures: default,
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
            foundryFeatures: default,
            after: after,
            before: before,
            limit: limit,
            order: order?.ToString(),
            agentName: agentName,
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> Create an Agent Insights monitor for an agent. </summary>
    /// <param name="monitor"> The monitor to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitor"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentInsightMonitor> Create(AgentInsightMonitorCreate monitor, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(monitor, nameof(monitor));

        ClientResult result = Create(monitor, default, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((AgentInsightMonitor)result, result.GetRawResponse());
    }

    /// <summary> Create an Agent Insights monitor for an agent. </summary>
    /// <param name="monitor"> The monitor to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitor"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentInsightMonitor>> CreateAsync(AgentInsightMonitorCreate monitor, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(monitor, nameof(monitor));

        ClientResult result = await CreateAsync(monitor, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((AgentInsightMonitor)result, result.GetRawResponse());
    }

    /// <summary> Get an Agent Insights monitor. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentInsightMonitor> Get(string monitorId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        ClientResult result = Get(monitorId, default, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((AgentInsightMonitor)result, result.GetRawResponse());
    }

    /// <summary> Get an Agent Insights monitor. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentInsightMonitor>> GetAsync(string monitorId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        ClientResult result = await GetAsync(monitorId, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((AgentInsightMonitor)result, result.GetRawResponse());
    }

    /// <summary> Delete an Agent Insights monitor and all of its runs, insights, and state. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult Delete(string monitorId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        return Delete(monitorId, default, cancellationToken.ToRequestOptions());
    }

    /// <summary> Delete an Agent Insights monitor and all of its runs, insights, and state. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> DeleteAsync(string monitorId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        return await DeleteAsync(monitorId, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <summary>
    /// [Protocol Method] Update an Agent Insights monitor.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult Update(string monitorId, BinaryContent content, RequestOptions options = null)
    {
        return Update(
            monitorId: monitorId,
            content: content,
            foundryFeatures: default,
            options: options
            );
    }

    /// <summary>
    /// [Protocol Method] Update an Agent Insights monitor.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> UpdateAsync(string monitorId, BinaryContent content, RequestOptions options = null)
    {
        return await UpdateAsync(
            monitorId: monitorId,
            content: content,
            foundryFeatures: default,
            options: options
        ).ConfigureAwait(false);
    }

    /// <summary> Reset an Agent Insights monitor's overview, checkpoint, and active insight state. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult Reset(string monitorId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        return Reset(monitorId, default, cancellationToken.ToRequestOptions());
    }

    /// <summary> Reset an Agent Insights monitor's overview, checkpoint, and active insight state. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult> ResetAsync(string monitorId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));

        return await ResetAsync(monitorId, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
    }

    /// <summary> Start an Agent Insights run for a monitor. </summary>
    /// <param name="waitUntilCompleted"> Whether the method should wait until the long-running operation has completed on the service. </param>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="run"> Run inputs. Send an empty object to use the default 168-hour lookback window. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="run"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    [Experimental("SCME0006")]
    public virtual OperationResult CreateRun(bool waitUntilCompleted, string monitorId, AgentInsightRunCreate run, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));
        Argument.AssertNotNull(run, nameof(run));

        OperationResult result = CreateRun(waitUntilCompleted, monitorId, run, default, cancellationToken.ToRequestOptions());
        return result;
    }

    /// <summary> Start an Agent Insights run for a monitor. </summary>
    /// <param name="waitUntilCompleted"> Whether the method should wait until the long-running operation has completed on the service. </param>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="run"> Run inputs. Send an empty object to use the default 168-hour lookback window. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="run"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> is an empty string, and was expected to be non-empty. </exception>
    [Experimental("SCME0006")]
    public virtual async Task<OperationResult> CreateRunAsync(bool waitUntilCompleted, string monitorId, AgentInsightRunCreate run, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));
        Argument.AssertNotNull(run, nameof(run));

        OperationResult result = await CreateRunAsync(waitUntilCompleted, monitorId, run, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return result;
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
            foundryFeatures: default,
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
            foundryFeatures: default,
            after: after,
            before: before,
            limit: limit,
            order: order?.ToString(),
            status: status?.ToString(),
            trigger: trigger?.ToString(),
            options: cancellationToken.ToRequestOptions());
    }

    /// <summary> Get an Agent Insights run. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="runId"> The identifier of the run. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="runId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentInsightRun> GetRun(string monitorId, string runId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        ClientResult result = GetRun(monitorId, runId, default, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((AgentInsightRun)result, result.GetRawResponse());
    }

    /// <summary> Get an Agent Insights run. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="runId"> The identifier of the run. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="runId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentInsightRun>> GetRunAsync(string monitorId, string runId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        ClientResult result = await GetRunAsync(monitorId, runId, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((AgentInsightRun)result, result.GetRawResponse());
    }

    /// <summary> Cancel an Agent Insights run. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="runId"> The identifier of the run. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="runId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentInsightRun> CancelRun(string monitorId, string runId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        ClientResult result = CancelRun(monitorId, runId, default, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((AgentInsightRun)result, result.GetRawResponse());
    }

    /// <summary> Cancel an Agent Insights run. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="runId"> The identifier of the run. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="runId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> or <paramref name="runId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentInsightRun>> CancelRunAsync(string monitorId, string runId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));
        Argument.AssertNotNullOrEmpty(runId, nameof(runId));

        ClientResult result = await CancelRunAsync(monitorId, runId, default, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((AgentInsightRun)result, result.GetRawResponse());
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
            foundryFeatures: default,
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
            foundryFeatures: default,
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

    /// <summary> Get a full insight for an Agent Insights monitor. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="insightId"> The identifier of the insight. </param>
    /// <param name="includeDetails"> Whether to include expanded insight details such as evidence and run links in the response. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="insightId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> or <paramref name="insightId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual ClientResult<AgentInsight> GetInsight(string monitorId, string insightId, bool? includeDetails = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));
        Argument.AssertNotNullOrEmpty(insightId, nameof(insightId));

        ClientResult result = GetInsight(monitorId, insightId, default, includeDetails, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue((AgentInsight)result, result.GetRawResponse());
    }

    /// <summary> Get a full insight for an Agent Insights monitor. </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="insightId"> The identifier of the insight. </param>
    /// <param name="includeDetails"> Whether to include expanded insight details such as evidence and run links in the response. Defaults to false. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/> or <paramref name="insightId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> or <paramref name="insightId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    public virtual async Task<ClientResult<AgentInsight>> GetInsightAsync(string monitorId, string insightId, bool? includeDetails = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(monitorId, nameof(monitorId));
        Argument.AssertNotNullOrEmpty(insightId, nameof(insightId));

        ClientResult result = await GetInsightAsync(monitorId, insightId, default, includeDetails, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue((AgentInsight)result, result.GetRawResponse());
    }

    /// <summary>
    /// [Protocol Method] Update the lifecycle status of an insight.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="insightId"> The identifier of the insight. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/>, <paramref name="insightId"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> or <paramref name="insightId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual ClientResult UpdateInsight(string monitorId, string insightId, BinaryContent content, RequestOptions options = null)
    {
        return UpdateInsight(
            monitorId: monitorId,
            insightId: insightId,
            content: content,
            foundryFeatures: default,
            options: options
        );
    }

    /// <summary>
    /// [Protocol Method] Update the lifecycle status of an insight.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="monitorId"> The identifier of the monitor. </param>
    /// <param name="insightId"> The identifier of the insight. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="monitorId"/>, <paramref name="insightId"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="monitorId"/> or <paramref name="insightId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    public virtual async Task<ClientResult> UpdateInsightAsync(string monitorId, string insightId, BinaryContent content, RequestOptions options = null)
    {
        return await UpdateInsightAsync(
            monitorId: monitorId,
            insightId: insightId,
            content: content,
            foundryFeatures: default,
            options: options
        ).ConfigureAwait(false);
    }
}
