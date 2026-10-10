// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Conformance;

/// <summary>
/// In-memory transport that simulates the Foundry task storage HTTP protocol by
/// delegating to a <see cref="LocalTaskStore"/>. Used by the Hosted conformance
/// suite so that both stores exercise identical server-equivalent semantics.
/// </summary>
internal sealed class FoundryProtocolHarness : HttpPipelineTransport
{
    private readonly LocalTaskStore _store;

    public FoundryProtocolHarness()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), "foundry-harness-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(tempDir);
        _store = new LocalTaskStore(tempDir);
    }

    public override Request CreateRequest() => new MockRequest();

    public override void Process(HttpMessage message)
    {
        ProcessAsync(message).AsTask().GetAwaiter().GetResult();
    }

    public override async ValueTask ProcessAsync(HttpMessage message)
    {
        var request = message.Request;
        var method = request.Method.ToString().ToUpperInvariant();
        var uri = request.Uri.ToUri();
        var path = uri.AbsolutePath;
        var query = System.Web.HttpUtility.ParseQueryString(uri.Query);

        // Normalize to the task-storage relative path, independent of the project-path prefix
        // (the real route is `{FOUNDRY_PROJECT_ENDPOINT}/tasks`, with no extra `/storage` segment).
        // Anchor on the LAST `/tasks` so a project path that itself contains a `/tasks…` segment
        // cannot mis-truncate — the appended route (`/tasks` or `/tasks/{id}`) is always last.
        var tasksIdx = path.LastIndexOf("/tasks", StringComparison.Ordinal);
        if (tasksIdx >= 0)
        {
            path = path.Substring(tasksIdx);
        }

        // Parse If-Match header
        string? ifMatch = null;
        if (request.Headers.TryGetValue("If-Match", out var ifMatchValue))
        {
            ifMatch = ifMatchValue;
        }

        try
        {
            if (method == "POST" && path == "/tasks")
            {
                var body = await ReadRequestBodyAsync(request);
                var record = await HandleCreate(body, query);
                SetJsonResponse(message, 201, record.ToJson());
            }
            else if (method == "GET" && path.StartsWith("/tasks/") && !path.Substring("/tasks/".Length).Contains('/'))
            {
                var taskId = Uri.UnescapeDataString(path.Substring("/tasks/".Length));
                var record = await _store.GetAsync(taskId);
                if (record is null)
                {
                    SetErrorResponse(message, 404, TaskStoreException.CodeTaskNotFound, $"Task '{taskId}' not found.");
                }
                else
                {
                    SetJsonResponse(message, 200, record.ToJson());
                }
            }
            else if (method == "PATCH" && path.StartsWith("/tasks/"))
            {
                var taskId = Uri.UnescapeDataString(path.Substring("/tasks/".Length));
                var body = await ReadRequestBodyAsync(request);
                var patch = ParsePatch(body, query);
                var record = await _store.PatchAsync(taskId, patch, ifMatch);
                SetJsonResponse(message, 200, record.ToJson());
            }
            else if (method == "DELETE" && path.StartsWith("/tasks/"))
            {
                var taskId = Uri.UnescapeDataString(path.Substring("/tasks/".Length));
                bool force = string.Equals(query["force"], "true", StringComparison.OrdinalIgnoreCase);
                bool cascade = string.Equals(query["cascade"], "true", StringComparison.OrdinalIgnoreCase);
                await _store.DeleteAsync(taskId, ifMatch, force, cascade);
                SetEmptyResponse(message, 204);
            }
            else if (method == "GET" && path == "/tasks")
            {
                var listQuery = ParseListQuery(query);
                var result = await _store.ListAsync(listQuery);
                var responseObj = new JsonObject();
                var dataArr = new JsonArray();
                foreach (var item in result.Items)
                {
                    dataArr.Add(item.Record.ToJson());
                }

                responseObj["data"] = dataArr;

                // Protocol list response shape (foundry-task-storage-protocol-spec §7.5).
                responseObj["has_more"] = result.NextAfter is not null;
                if (result.NextAfter is not null)
                {
                    responseObj["last_id"] = result.NextAfter;
                }

                SetJsonResponse(message, 200, responseObj);
            }
            else
            {
                SetErrorResponse(message, 404, "not_found", $"Unknown route: {method} {path}");
            }
        }
        catch (TaskStoreException ex)
        {
            SetErrorResponse(message, ex.StatusCode, ex.Code, ex.Message);
        }
    }

    private async Task<TaskRecord> HandleCreate(JsonObject body, System.Collections.Specialized.NameValueCollection query)
    {
        var createReq = new TaskCreateRequest
        {
            Id = (string?)body[TaskWireKeys.Id],
            AgentName = (string?)body[TaskWireKeys.AgentName] ?? string.Empty,
            SessionId = (string?)body[TaskWireKeys.SessionId] ?? string.Empty,
            Title = (string?)body[TaskWireKeys.Title],
            Description = (string?)body[TaskWireKeys.Description],
            Status = (string?)body[TaskWireKeys.Status],
        };

        if (body[TaskWireKeys.Payload] is JsonObject payload)
        {
            createReq.Payload = (JsonObject)payload.DeepClone();
        }

        if (body[TaskWireKeys.Tags] is JsonObject tags)
        {
            var dict = new Dictionary<string, string>();
            foreach (var kvp in tags)
            {
                dict[kvp.Key] = (string?)kvp.Value ?? string.Empty;
            }

            createReq.Tags = dict;
        }

        if (body[TaskWireKeys.Source] is JsonObject source)
        {
            createReq.Source = (JsonObject)source.DeepClone();
        }

        if (body[TaskWireKeys.Attachments] is JsonObject attachments)
        {
            createReq.Attachments = (JsonObject)attachments.DeepClone();
        }

        // Lease parameters arrive as query parameters, never in the body
        // (foundry-task-storage-protocol-spec §7.1).
        if (query["lease_owner"] is string createOwner)
        {
            createReq.LeaseOwner = createOwner;
            createReq.LeaseInstanceId = query["lease_instance_id"];
            if (query["lease_duration_seconds"] is string ds && int.TryParse(ds, out var dsec))
            {
                createReq.LeaseDurationSeconds = dsec;
            }
        }

        return await _store.CreateAsync(createReq);
    }

    private static TaskPatchRequest ParsePatch(JsonObject body, System.Collections.Specialized.NameValueCollection query)
    {
        var patch = new TaskPatchRequest
        {
            Status = (string?)body[TaskWireKeys.Status],
            SuspensionReason = (string?)body[TaskWireKeys.SuspensionReason],
        };

        if (body.ContainsKey(TaskWireKeys.Payload))
        {
            patch.PayloadSupplied = true;
            patch.Payload = body[TaskWireKeys.Payload]?.DeepClone();
        }

        if (body[TaskWireKeys.Tags] is JsonObject tags)
        {
            var dict = new Dictionary<string, JsonNode?>();
            foreach (var kvp in tags)
            {
                dict[kvp.Key] = kvp.Value?.DeepClone();
            }

            patch.Tags = dict;
        }

        if (body.ContainsKey(TaskWireKeys.Attachments))
        {
            // Clear-all is the explicit JSON null sentinel; a non-null object is a per-key merge.
            if (body[TaskWireKeys.Attachments] is null)
            {
                patch.ClearAllAttachments = true;
            }
            else if (body[TaskWireKeys.Attachments] is JsonObject att)
            {
                patch.Attachments = (JsonObject)att.DeepClone();
            }
        }

        if (body[TaskWireKeys.Error] is JsonNode error)
        {
            patch.Error = error.DeepClone();
        }

        // Lease parameters arrive as query parameters, never in the body
        // (foundry-task-storage-protocol-spec §7.3).
        if (query["lease_owner"] is string patchOwner)
        {
            patch.LeaseOwner = patchOwner;
            patch.LeaseInstanceId = query["lease_instance_id"];
            if (query["lease_duration_seconds"] is string ds && int.TryParse(ds, out var dsec))
            {
                patch.LeaseDurationSeconds = dsec;
            }
        }

        return patch;
    }

    private static TaskListQuery ParseListQuery(System.Collections.Specialized.NameValueCollection query)
    {
        var q = new TaskListQuery();

        if (query["limit"] is string limitStr && int.TryParse(limitStr, out var limit))
        {
            q.Limit = limit;
        }

        if (query["order"] is string order)
        {
            q.Ascending = string.Equals(order, "asc", StringComparison.OrdinalIgnoreCase);
        }

        q.AgentName = query["agent_name"];
        q.SessionId = query["session_id"];
        q.Status = query["status"];
        q.LeaseOwner = query["lease_owner"];
        q.SourceType = query["source_type"];

        if (query["has_error"] is string hasError)
        {
            q.HasError = string.Equals(hasError, "true", StringComparison.OrdinalIgnoreCase);
        }

        if (query["lease_expired"] is string leaseExpired)
        {
            q.LeaseExpired = string.Equals(leaseExpired, "true", StringComparison.OrdinalIgnoreCase);
        }

        if (query["after"] is string after)
        {
            q.After = after;
        }

        if (query["omit_attachment_values"] is string omit)
        {
            q.OmitAttachmentValues = string.Equals(omit, "true", StringComparison.OrdinalIgnoreCase);
        }

        // Tag filters arrive as one param per key in `tag.<key>=<value>` form (AND-combined),
        // matching the corrected Foundry client wire shape.
        var tags = new List<KeyValuePair<string, string>>();
        foreach (var name in query.AllKeys)
        {
            if (name is not null && name.StartsWith("tag.", StringComparison.Ordinal) && name.Length > 4)
            {
                var value = query[name];
                if (value is not null)
                {
                    tags.Add(new KeyValuePair<string, string>(name.Substring(4), value));
                }
            }
        }

        if (tags.Count > 0)
        {
            q.Tags = tags;
        }

        return q;
    }

    private static async Task<JsonObject> ReadRequestBodyAsync(Request request)
    {
        if (request.Content is null)
        {
            return new JsonObject();
        }

        using var ms = new MemoryStream();
        await request.Content.WriteToAsync(ms, default);
        ms.Position = 0;
        var text = Encoding.UTF8.GetString(ms.ToArray());
        var node = JsonNode.Parse(text);
        return node as JsonObject ?? new JsonObject();
    }

    private static void SetJsonResponse(HttpMessage message, int status, JsonObject body)
    {
        var json = body.ToJsonString();
        var bytes = Encoding.UTF8.GetBytes(json);
        var response = new MockResponse(status);
        response.SetContent(bytes);
        response.AddHeader("Content-Type", "application/json");

        // Set ETag from record body if present
        if (body[TaskWireKeys.Etag] is JsonNode etagNode)
        {
            var etag = (string?)etagNode;
            if (etag is not null)
            {
                response.AddHeader("ETag", etag);
            }
        }

        message.Response = response;
    }

    private static void SetErrorResponse(HttpMessage message, int status, string code, string errorMessage)
    {
        var errorObj = new JsonObject
        {
            ["error"] = new JsonObject
            {
                ["code"] = code,
                ["message"] = errorMessage,
            }
        };

        var json = errorObj.ToJsonString();
        var bytes = Encoding.UTF8.GetBytes(json);
        var response = new MockResponse(status);
        response.SetContent(bytes);
        response.AddHeader("Content-Type", "application/json");
        message.Response = response;
    }

    private static void SetEmptyResponse(HttpMessage message, int status)
    {
        var response = new MockResponse(status);
        response.SetContent(Array.Empty<byte>());
        message.Response = response;
    }
}

/// <summary>A minimal mock Request implementation for the in-memory transport.</summary>
internal sealed class MockRequest : Request
{
    private readonly Dictionary<string, string> _headers = new(StringComparer.OrdinalIgnoreCase);

    public override string ClientRequestId { get; set; } = Guid.NewGuid().ToString();

    protected override void SetHeader(string name, string value) => _headers[name] = value;

    protected override void AddHeader(string name, string value)
    {
        if (_headers.TryGetValue(name, out var existing))
        {
            _headers[name] = existing + "," + value;
        }
        else
        {
            _headers[name] = value;
        }
    }

    protected override bool TryGetHeader(string name, out string? value) => _headers.TryGetValue(name, out value);

    protected override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
    {
        if (_headers.TryGetValue(name, out var value))
        {
            values = new[] { value };
            return true;
        }

        values = null;
        return false;
    }

    protected override bool ContainsHeader(string name) => _headers.ContainsKey(name);

    protected override bool RemoveHeader(string name) => _headers.Remove(name);

    protected override IEnumerable<HttpHeader> EnumerateHeaders()
    {
        foreach (var kvp in _headers)
        {
            yield return new HttpHeader(kvp.Key, kvp.Value);
        }
    }

    public override void Dispose() { }
}

/// <summary>A minimal mock Response implementation for the in-memory transport.</summary>
internal sealed class MockResponse : Response
{
    private readonly int _status;
    private readonly Dictionary<string, string> _headers = new(StringComparer.OrdinalIgnoreCase);
    private BinaryData? _content;

    public MockResponse(int status)
    {
        _status = status;
    }

    public override int Status => _status;

    public override string ReasonPhrase => _status switch
    {
        200 => "OK",
        201 => "Created",
        204 => "No Content",
        400 => "Bad Request",
        404 => "Not Found",
        409 => "Conflict",
        412 => "Precondition Failed",
        429 => "Too Many Requests",
        _ => "Error",
    };

    public override Stream? ContentStream { get; set; }

    public override string ClientRequestId { get; set; } = string.Empty;

    public override BinaryData Content => _content ?? BinaryData.FromBytes(Array.Empty<byte>());

    public void SetContent(byte[] bytes)
    {
        _content = BinaryData.FromBytes(bytes);
        ContentStream = new MemoryStream(bytes);
    }

    public void AddHeader(string name, string value) => _headers[name] = value;

    protected override bool TryGetHeader(string name, out string? value) => _headers.TryGetValue(name, out value);

    protected override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
    {
        if (_headers.TryGetValue(name, out var value))
        {
            values = new[] { value };
            return true;
        }

        values = null;
        return false;
    }

    protected override bool ContainsHeader(string name) => _headers.ContainsKey(name);

    protected override IEnumerable<HttpHeader> EnumerateHeaders()
    {
        foreach (var kvp in _headers)
        {
            yield return new HttpHeader(kvp.Key, kvp.Value);
        }
    }

    public override void Dispose() { }
}
