// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;

/// <summary>
/// HTTP-backed implementation of <see cref="ITaskStore"/> that persists tasks
/// to the Azure AI Foundry task storage API using an Azure.Core
/// <see cref="HttpPipeline"/> for retry, authentication, telemetry, and tracing.
/// </summary>
internal sealed class HostedTaskStore : ITaskStore
{
    private const string ApiVersion = "v1";
    private const string JsonContentType = "application/json; charset=utf-8";

    // Opt into the server-side "Routines" preview behavior the durable-tasks protocol depends on.
    // Python sends this on every hosted task-storage request (HeadersPolicy base header); the .NET
    // client must send the identical value so a hosted Foundry backend enables the same feature set.
    private const string FoundryFeaturesHeader = "Foundry-Features";
    private const string FoundryFeaturesValue = "Routines=V1Preview";

    private readonly HttpPipeline _pipeline;
    private readonly Uri _storageBaseUri;

    /// <summary>
    /// Initializes a new instance of <see cref="HostedTaskStore"/>.
    /// </summary>
    /// <param name="pipeline">The Azure.Core HTTP pipeline (includes retry, auth, telemetry).</param>
    /// <param name="storageBaseUri">The base URI for the Foundry task storage API — the project
    /// endpoint with a trailing slash (e.g. <c>https://host/api/projects/p/</c>); request paths
    /// (<c>tasks</c>, <c>tasks/{id}</c>) are appended to it.</param>
    public HostedTaskStore(HttpPipeline pipeline, Uri storageBaseUri)
    {
        _pipeline = pipeline;
        _storageBaseUri = storageBaseUri;
    }

    /// <inheritdoc/>
    public async Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        var bodyBytes = SerializeCreateBody(request);

        // Lease parameters travel as query parameters, never in the body
        // (foundry-task-storage-protocol-spec §7.1: "Lease Query Parameters").
        var leaseQuery = BuildLeaseQuery(request.LeaseOwner, request.LeaseInstanceId, request.LeaseDurationSeconds);

        using var message = CreateRequest(RequestMethod.Post, "tasks", leaseQuery);
        message.Request.Content = RequestContent.Create(bodyBytes);
        message.Request.Headers.SetValue("Content-Type", JsonContentType);

        await SendStorageRequestAsync(message, null, cancellationToken).ConfigureAwait(false);

        return ParseRecordResponse(message.Response);
    }

    /// <inheritdoc/>
    public async Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
    {
        using var message = CreateRequest(RequestMethod.Get, $"tasks/{Uri.EscapeDataString(taskId)}");
        message.Request.Headers.SetValue("Accept", "application/json");

        try
        {
            await SendStorageRequestAsync(message, taskId, cancellationToken).ConfigureAwait(false);
        }
        catch (TaskStoreException ex) when (ex.StatusCode == 404)
        {
            return null;
        }

        return ParseRecordResponse(message.Response);
    }

    /// <inheritdoc/>
    public async Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(patch);

        var patchBody = BuildPatchBody(patch);
        var bodyBytes = CanonicalJson.SerializeToUtf8Bytes(JsonSerializer.SerializeToElement(patchBody));

        // Lease parameters travel as query parameters, never in the body
        // (foundry-task-storage-protocol-spec §7.3: "Lease operations live in query parameters").
        var leaseQuery = BuildLeaseQuery(patch.LeaseOwner, patch.LeaseInstanceId, patch.LeaseDurationSeconds);

        using var message = CreateRequest(RequestMethod.Patch, $"tasks/{Uri.EscapeDataString(taskId)}", leaseQuery);
        message.Request.Content = RequestContent.Create(bodyBytes);
        message.Request.Headers.SetValue("Content-Type", JsonContentType);

        if (ifMatch is not null)
        {
            message.Request.Headers.SetValue("If-Match", ifMatch);
        }

        await SendStorageRequestAsync(message, taskId, cancellationToken).ConfigureAwait(false);

        return ParseRecordResponse(message.Response);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
    {
        var deleteQuery = BuildDeleteQuery(force, cascade);

        using var message = CreateRequest(RequestMethod.Delete, $"tasks/{Uri.EscapeDataString(taskId)}", deleteQuery);

        if (ifMatch is not null)
        {
            message.Request.Headers.SetValue("If-Match", ifMatch);
        }

        await SendStorageRequestAsync(message, taskId, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        var extraQuery = BuildListQuery(query);

        using var message = CreateRequest(RequestMethod.Get, "tasks", extraQuery);
        message.Request.Headers.SetValue("Accept", "application/json");

        await SendStorageRequestAsync(message, null, cancellationToken).ConfigureAwait(false);

        return ParseListResponse(message.Response);
    }

    private async Task SendStorageRequestAsync(HttpMessage message, string? taskId, CancellationToken cancellationToken)
    {
        try
        {
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex) when (!ex.Data.Contains(TaskStorageErrorMapper.PlatformErrorDataKey))
        {
            ex.Data[TaskStorageErrorMapper.PlatformErrorDataKey] = true;
            throw;
        }

        TaskStorageErrorMapper.ThrowIfError(message.Response, taskId);
    }

    private HttpMessage CreateRequest(RequestMethod method, string path, IReadOnlyList<KeyValuePair<string, string>>? queryParams = null)
    {
        var message = _pipeline.CreateMessage();
        var request = message.Request;
        request.Method = method;

        var uri = new RequestUriBuilder();
        uri.Reset(_storageBaseUri);
        uri.AppendPath(path, escape: false);
        uri.AppendQuery("api-version", ApiVersion, escapeValue: true);

        if (queryParams is not null)
        {
            // Values are pre-escaped by the query builders; append verbatim.
            foreach (var pair in queryParams)
            {
                uri.AppendQuery(pair.Key, pair.Value, escapeValue: false);
            }
        }

        request.Uri = uri;

        // Every hosted request carries the Foundry-Features opt-in (Python parity).
        request.Headers.SetValue(FoundryFeaturesHeader, FoundryFeaturesValue);

        return message;
    }

    private static byte[] SerializeCreateBody(TaskCreateRequest request)
    {
        // Only the create-request fields defined by the protocol contract
        // (foundry-task-storage-protocol-spec §7.1 "Body Fields") — never the
        // full task object envelope (no `object`, timestamps, `etag`, or
        // `lease`; lease travels as query parameters). Id is omitted when the
        // caller did not supply one so the server generates it.
        var obj = new JsonObject
        {
            [TaskWireKeys.AgentName] = request.AgentName,
            [TaskWireKeys.SessionId] = request.SessionId,
        };

        if (request.Id is not null)
        {
            obj[TaskWireKeys.Id] = request.Id;
        }

        string? status = request.Status;
        if (string.Equals(status, TaskWireKeys.StatusDoneAlias, StringComparison.Ordinal))
        {
            status = TaskWireKeys.StatusCompleted;
        }

        if (status is not null && !string.Equals(status, TaskWireKeys.StatusPending, StringComparison.Ordinal))
        {
            obj[TaskWireKeys.Status] = status;
        }

        if (request.Title is not null)
        {
            obj[TaskWireKeys.Title] = request.Title;
        }

        if (request.Description is not null)
        {
            obj[TaskWireKeys.Description] = request.Description;
        }

        if (request.Payload is not null)
        {
            obj[TaskWireKeys.Payload] = request.Payload.DeepClone();
        }

        if (request.Source is not null)
        {
            obj[TaskWireKeys.Source] = request.Source.DeepClone();
        }

        if (request.Tags is not null)
        {
            var tagsObj = new JsonObject();
            foreach (var kvp in request.Tags)
            {
                tagsObj[kvp.Key] = kvp.Value;
            }

            obj[TaskWireKeys.Tags] = tagsObj;
        }

        if (request.Attachments is not null)
        {
            obj[TaskWireKeys.Attachments] = request.Attachments.DeepClone();
        }

        var element = JsonSerializer.SerializeToElement(obj);
        return CanonicalJson.SerializeToUtf8Bytes(element);
    }

    private static IReadOnlyList<KeyValuePair<string, string>>? BuildLeaseQuery(string? owner, string? instanceId, int? durationSeconds)
    {
        if (owner is null && instanceId is null && durationSeconds is null)
        {
            return null;
        }

        var parts = new List<KeyValuePair<string, string>>();
        if (owner is not null)
        {
            parts.Add(new("lease_owner", Uri.EscapeDataString(owner)));
        }

        if (instanceId is not null)
        {
            parts.Add(new("lease_instance_id", Uri.EscapeDataString(instanceId)));
        }

        if (durationSeconds.HasValue)
        {
            parts.Add(new("lease_duration_seconds", durationSeconds.Value.ToString(CultureInfo.InvariantCulture)));
        }

        return parts;
    }

    private static IReadOnlyList<KeyValuePair<string, string>>? BuildDeleteQuery(bool force, bool cascade)
    {
        var parts = new List<KeyValuePair<string, string>>();
        if (force)
        {
            parts.Add(new("force", "true"));
        }

        if (cascade)
        {
            parts.Add(new("cascade", "true"));
        }

        return parts.Count > 0 ? parts : null;
    }

    private static JsonObject BuildPatchBody(TaskPatchRequest patch)
    {
        var body = new JsonObject();

        if (patch.Status is not null)
        {
            body[TaskWireKeys.Status] = patch.Status;
        }

        if (patch.PayloadSupplied)
        {
            body[TaskWireKeys.Payload] = patch.Payload?.DeepClone();
        }

        if (patch.Tags is not null)
        {
            var tagsObj = new JsonObject();
            foreach (var kvp in patch.Tags)
            {
                tagsObj[kvp.Key] = kvp.Value?.DeepClone();
            }

            body[TaskWireKeys.Tags] = tagsObj;
        }

        if (patch.ClearAllAttachments)
        {
            // Clear-all is the explicit JSON null sentinel (SOT §"attachments: null"),
            // distinct from an additive per-key merge object.
            body[TaskWireKeys.Attachments] = null;
        }
        else if (patch.Attachments is not null)
        {
            body[TaskWireKeys.Attachments] = patch.Attachments.DeepClone();
        }

        if (patch.Error is not null)
        {
            body[TaskWireKeys.Error] = patch.Error.DeepClone();
        }

        if (patch.SuspensionReason is not null)
        {
            body[TaskWireKeys.SuspensionReason] = patch.SuspensionReason;
        }

        return body;
    }

    private static IReadOnlyList<KeyValuePair<string, string>>? BuildListQuery(TaskListQuery query)
    {
        var parts = new List<KeyValuePair<string, string>>();

        int limit = Math.Clamp(query.Limit <= 0 ? 20 : query.Limit, 1, 100);
        parts.Add(new("limit", limit.ToString(CultureInfo.InvariantCulture)));

        parts.Add(new("order", query.Ascending ? "asc" : "desc"));

        if (query.AgentName is not null)
        {
            parts.Add(new("agent_name", Uri.EscapeDataString(query.AgentName)));
        }

        if (query.SessionId is not null)
        {
            parts.Add(new("session_id", Uri.EscapeDataString(query.SessionId)));
        }

        if (query.HasError.HasValue)
        {
            parts.Add(new("has_error", query.HasError.Value ? "true" : "false"));
        }

        if (query.LeaseExpired.HasValue)
        {
            parts.Add(new("lease_expired", query.LeaseExpired.Value ? "true" : "false"));
        }

        if (query.LeaseOwner is not null)
        {
            parts.Add(new("lease_owner", Uri.EscapeDataString(query.LeaseOwner)));
        }

        if (query.Tags is not null)
        {
            // Tag-equality filters use the `tag.<key>=<value>` query shape (one param per key,
            // AND-combined) — matching the Foundry task-storage client that runs against the live
            // backend. (The SOT protocol spec's `tag=key:value` wording is being corrected to this.)
            foreach (var tag in query.Tags)
            {
                parts.Add(new($"tag.{Uri.EscapeDataString(tag.Key)}", Uri.EscapeDataString(tag.Value)));
            }
        }

        if (query.SourceType is not null)
        {
            parts.Add(new("source_type", Uri.EscapeDataString(query.SourceType)));
        }

        if (query.Status is not null)
        {
            parts.Add(new("status", Uri.EscapeDataString(query.Status)));
        }

        if (query.After is not null)
        {
            parts.Add(new("after", Uri.EscapeDataString(query.After)));
        }

        if (query.OmitAttachmentValues)
        {
            parts.Add(new("omit_attachment_values", "true"));
        }

        return parts.Count > 0 ? parts : null;
    }

    private static TaskRecord ParseRecordResponse(Response response)
    {
        var body = response.Content.ToString();
        var node = JsonNode.Parse(body);
        if (node is not JsonObject obj)
        {
            throw new TaskStoreException(TaskStoreException.CodeInternalError, 500, "Invalid response body from task storage.");
        }

        var record = TaskRecord.FromJson(obj);

        // Prefer ETag from response header if body doesn't carry one.
        if (record.Etag is null && response.Headers.TryGetValue("ETag", out var etagHeader))
        {
            record.Etag = etagHeader;
        }

        return record;
    }

    private static TaskListResult ParseListResponse(Response response)
    {
        var body = response.Content.ToString();
        var node = JsonNode.Parse(body);
        if (node is not JsonObject obj)
        {
            return new TaskListResult();
        }

        var items = new List<TaskRecordRef>();
        if (obj["data"] is JsonArray dataArr)
        {
            foreach (var item in dataArr)
            {
                if (item is JsonObject itemObj)
                {
                    var record = TaskRecord.FromJson(itemObj);
                    items.Add(new TaskRecordRef(record, record.Id));
                }
            }
        }

        // Pagination follows the protocol list response (foundry-task-storage-protocol-spec
        // §7.5): advance only when `has_more` is true, using `last_id` as the next cursor.
        bool hasMore = (bool?)obj["has_more"] ?? false;
        string? nextAfter = hasMore ? (string?)obj["last_id"] : null;

        return new TaskListResult { Items = items, NextAfter = nextAfter };
    }
}
