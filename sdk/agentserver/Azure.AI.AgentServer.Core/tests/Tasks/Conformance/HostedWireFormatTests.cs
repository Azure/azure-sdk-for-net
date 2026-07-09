// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Conformance;

/// <summary>
/// Asserts that <see cref="HostedTaskStore"/> speaks the exact Foundry task storage
/// wire protocol: lease parameters travel as query parameters, create bodies are
/// restricted to protocol §7.1 fields, pagination uses <c>has_more</c>/<c>last_id</c>,
/// and clear-all attachments is the JSON <c>null</c> sentinel.
/// </summary>
[TestFixture]
public sealed class HostedWireFormatTests
{
    private sealed class CapturingTransport : HttpPipelineTransport
    {
        private readonly FoundryProtocolHarness _inner = new();

        public List<CapturedRequest> Requests { get; } = new();

        public override Request CreateRequest() => _inner.CreateRequest();

        public override void Process(HttpMessage message)
        {
            Capture(message);
            _inner.Process(message);
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            Capture(message);
            await _inner.ProcessAsync(message).ConfigureAwait(false);
        }

        private void Capture(HttpMessage message)
        {
            var req = message.Request;
            var uri = req.Uri.ToUri();
            string? body = null;
            if (req.Content is not null)
            {
                using var ms = new MemoryStream();
                req.Content.WriteTo(ms, CancellationToken.None);
                body = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }

            Requests.Add(new CapturedRequest(
                req.Method.ToString().ToUpperInvariant(),
                uri.AbsolutePath,
                System.Web.HttpUtility.ParseQueryString(uri.Query),
                body,
                req.Headers.TryGetValue("Foundry-Features", out var features) ? features : null));
        }
    }

    private sealed record CapturedRequest(
        string Method,
        string Path,
        System.Collections.Specialized.NameValueCollection Query,
        string? Body,
        string? FoundryFeatures);

    private static (HostedTaskStore Store, CapturingTransport Transport) CreateStore()
    {
        var transport = new CapturingTransport();
        var options = new HostedTaskStoreClientOptions { Transport = transport };
        options.Retry.MaxRetries = 0;
        var pipeline = HttpPipelineBuilder.Build(options);
        var store = new HostedTaskStore(pipeline, new Uri("https://test.example.com/api/projects/proj/"));
        return (store, transport);
    }

    private static TaskCreateRequest NewCreate(string id) => new()
    {
        Id = id,
        AgentName = "agent-a",
        SessionId = "sess-1",
        Title = "wire-format-test",
    };

    [Test]
    public async Task CreateSendsLeaseAsQueryParametersNotBody()
    {
        var (store, transport) = CreateStore();
        var req = NewCreate("wf-lease");
        req.Status = "in_progress";
        req.LeaseOwner = "agent-a|session:sess-1";
        req.LeaseInstanceId = "worker-1";
        req.LeaseDurationSeconds = 30;

        await store.CreateAsync(req);

        var create = transport.Requests.Find(r => r.Method == "POST");
        Assert.That(create, Is.Not.Null);
        Assert.That(create!.Query["lease_owner"], Is.EqualTo("agent-a|session:sess-1"));
        Assert.That(create.Query["lease_instance_id"], Is.EqualTo("worker-1"));
        Assert.That(create.Query["lease_duration_seconds"], Is.EqualTo("30"));

        // Body must NOT carry any lease structure.
        var body = JsonNode.Parse(create.Body!)!.AsObject();
        Assert.That(body.ContainsKey("lease"), Is.False);
        Assert.That(body.ContainsKey("lease_owner"), Is.False);
    }

    [Test]
    public async Task CreateBodyIsRestrictedToProtocolFields()
    {
        var (store, transport) = CreateStore();
        await store.CreateAsync(NewCreate("wf-body"));

        var create = transport.Requests.Find(r => r.Method == "POST");
        var body = JsonNode.Parse(create!.Body!)!.AsObject();

        // Only §7.1 create-fields are permitted; server-owned fields must never be sent.
        foreach (var forbidden in new[] { "etag", "created_at", "updated_at", "started_at", "completed_at", "lease", "metadata" })
        {
            Assert.That(body.ContainsKey(forbidden), Is.False, $"create body must not contain '{forbidden}'");
        }
    }

    [Test]
    public async Task PatchSendsLeaseAsQueryParametersNotBody()
    {
        var (store, transport) = CreateStore();
        await store.CreateAsync(NewCreate("wf-patch"));
        transport.Requests.Clear();

        await store.PatchAsync("wf-patch", new TaskPatchRequest
        {
            Status = "in_progress",
            LeaseOwner = "owner-x",
            LeaseInstanceId = "worker-9",
            LeaseDurationSeconds = 45,
        }, ifMatch: null);

        var patch = transport.Requests.Find(r => r.Method == "PATCH");
        Assert.That(patch, Is.Not.Null);
        Assert.That(patch!.Query["lease_owner"], Is.EqualTo("owner-x"));
        Assert.That(patch.Query["lease_instance_id"], Is.EqualTo("worker-9"));
        Assert.That(patch.Query["lease_duration_seconds"], Is.EqualTo("45"));

        var body = JsonNode.Parse(patch.Body!)!.AsObject();
        Assert.That(body.ContainsKey("lease"), Is.False);
        Assert.That(body.ContainsKey("lease_owner"), Is.False);
    }

    [Test]
    public async Task ClearAllAttachmentsSendsJsonNull()
    {
        var (store, transport) = CreateStore();
        var req = NewCreate("wf-att");
        req.Status = "in_progress";
        req.LeaseOwner = "o";
        req.LeaseInstanceId = "w";
        req.LeaseDurationSeconds = 60;
        req.Attachments = new JsonObject { ["k"] = "v" };
        await store.CreateAsync(req);
        transport.Requests.Clear();

        await store.PatchAsync("wf-att", new TaskPatchRequest { ClearAllAttachments = true }, ifMatch: null);

        var patch = transport.Requests.Find(r => r.Method == "PATCH");
        var body = JsonNode.Parse(patch!.Body!)!.AsObject();
        Assert.That(body.ContainsKey("attachments"), Is.True);
        Assert.That(body["attachments"], Is.Null, "clear-all must serialize attachments as JSON null");

        var record = await store.GetAsync("wf-att");
        Assert.That(record!.Attachments is null || record.Attachments.Count == 0, Is.True);
    }

    [Test]
    public async Task DeleteSendsForceAndCascadeAsQuery()
    {
        var (store, transport) = CreateStore();
        await store.CreateAsync(NewCreate("wf-del"));
        transport.Requests.Clear();

        await store.DeleteAsync("wf-del", force: true, cascade: true);

        var del = transport.Requests.Find(r => r.Method == "DELETE");
        Assert.That(del, Is.Not.Null);
        Assert.That(del!.Query["force"], Is.EqualTo("true"));
        Assert.That(del.Query["cascade"], Is.EqualTo("true"));
    }

    [Test]
    public async Task EveryRequestSendsFoundryFeaturesHeader()
    {
        var (store, transport) = CreateStore();
        await store.CreateAsync(NewCreate("wf-hdr"));
        await store.GetAsync("wf-hdr");
        await store.ListAsync(new TaskListQuery { AgentName = "agent-a" });

        Assert.That(transport.Requests, Is.Not.Empty);
        foreach (var req in transport.Requests)
        {
            Assert.That(req.FoundryFeatures, Is.EqualTo("Routines=V1Preview"),
                $"{req.Method} {req.Path} must carry the Foundry-Features opt-in header");
        }
    }

    [Test]
    public async Task ListEncodesTagsAsDottedKeyEqualsValuePerFoundryClient()
    {
        var (store, transport) = CreateStore();
        await store.ListAsync(new TaskListQuery
        {
            Tags = new List<KeyValuePair<string, string>> { new("priority", "high") },
        });

        var list = transport.Requests.Find(r => r.Method == "GET");
        // Foundry task-storage client wire shape: tag filters are `tag.<key>=<value>` (one param
        // per key, AND-combined), matching the live backend client in azure-ai-agentserver-core.
        Assert.That(list!.Query["tag.priority"], Is.EqualTo("high"));
    }
}
