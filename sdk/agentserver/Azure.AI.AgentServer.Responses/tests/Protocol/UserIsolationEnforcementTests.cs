// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E tests verifying user isolation key enforcement across all endpoints.
/// When a response is created with a user isolation key, all subsequent
/// GET / Cancel / DELETE / InputItems calls must send the same key.
/// Mismatch or missing key → 404 (indistinguishable from "not found").
/// No enforcement when the response was created without a user isolation key.
/// </summary>
public class UserIsolationEnforcementTests : ProtocolTestBase
{
    private const string UserKeyA = "user-key-alpha";
    private const string UserKeyB = "user-key-beta";

    // ─── GET JSON ─────────────────────────────────────────────

    [Test]
    public async Task GET_WithMatchingUserKey_Returns200()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var get = await GetWithUserKeyAsync(responseId, UserKeyA);

        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task GET_WithMismatchedUserKey_Returns404()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var get = await GetWithUserKeyAsync(responseId, UserKeyB);

        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GET_WithMissingUserKey_WhenCreatedWithOne_Returns404()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        // No user key header on GET
        var get = await GetResponseAsync(responseId);

        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GET_WithUserKey_WhenCreatedWithout_Returns200()
    {
        // Create without any isolation key (local dev scenario)
        var responseId = await CreateDefaultResponseAsync();

        // GET with a user key — no enforcement, should succeed
        var get = await GetWithUserKeyAsync(responseId, UserKeyA);

        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task GET_Mismatch_ReturnsStandard404ErrorBody()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var get = await GetWithUserKeyAsync(responseId, UserKeyB);

        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        using var doc = await ParseJsonAsync(get);
        // Must match normal 404 error envelope
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
    }

    // ─── CANCEL ───────────────────────────────────────────────

    [Test]
    public async Task Cancel_WithMatchingUserKey_Succeeds()
    {
        var responseId = await CreateBackgroundResponseWithUserKeyAsync(UserKeyA);
        await WaitForBackgroundCompletionWithUserKeyAsync(responseId, UserKeyA);

        var cancel = await CancelWithUserKeyAsync(responseId, UserKeyA);

        // Completed bg response → cancel returns 200 with the completed response (idempotent)
        // or 400 "Cannot cancel a completed response." — either is fine, both prove isolation passed.
        Assert.That(cancel.StatusCode, Is.Not.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task Cancel_WithMismatchedUserKey_Returns404()
    {
        var responseId = await CreateBackgroundResponseWithUserKeyAsync(UserKeyA);
        await WaitForBackgroundCompletionWithUserKeyAsync(responseId, UserKeyA);

        var cancel = await CancelWithUserKeyAsync(responseId, UserKeyB);

        Assert.That(cancel.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task Cancel_WithMissingUserKey_WhenCreatedWithOne_Returns404()
    {
        var responseId = await CreateBackgroundResponseWithUserKeyAsync(UserKeyA);
        await WaitForBackgroundCompletionWithUserKeyAsync(responseId, UserKeyA);

        // No user key header
        var cancel = await CancelResponseAsync(responseId);

        Assert.That(cancel.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ─── DELETE ───────────────────────────────────────────────

    [Test]
    public async Task DELETE_WithMatchingUserKey_Returns200()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var delete = await DeleteWithUserKeyAsync(responseId, UserKeyA);

        Assert.That(delete.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task DELETE_WithMismatchedUserKey_Returns404()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var delete = await DeleteWithUserKeyAsync(responseId, UserKeyB);

        Assert.That(delete.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task DELETE_WithMissingUserKey_WhenCreatedWithOne_Returns404()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var delete = await Client.DeleteAsync($"/responses/{responseId}");

        Assert.That(delete.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ─── INPUT ITEMS ─────────────────────────────────────────

    [Test]
    public async Task InputItems_WithMatchingUserKey_Returns200()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var items = await GetInputItemsWithUserKeyAsync(responseId, UserKeyA);

        Assert.That(items.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task InputItems_WithMismatchedUserKey_Returns404()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var items = await GetInputItemsWithUserKeyAsync(responseId, UserKeyB);

        Assert.That(items.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task InputItems_WithMissingUserKey_WhenCreatedWithOne_Returns404()
    {
        var responseId = await CreateResponseWithUserKeyAsync(UserKeyA);

        var items = await Client.GetAsync($"/responses/{responseId}/input_items");

        Assert.That(items.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ─── IN-FLIGHT (background, not yet completed) ───────────

    [Test]
    public async Task GET_InFlight_WithMatchingUserKey_Returns200()
    {
        var gate = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, gate.Task, ct);

        var responseId = await CreateBackgroundResponseWithUserKeyAsync(UserKeyA);

        // Response is in-flight — GET with matching key should succeed
        var get = await PollUntilAsync(
            () => GetWithUserKeyAsync(responseId, UserKeyA),
            r => r.StatusCode == HttpStatusCode.OK,
            TimeSpan.FromSeconds(3));
        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        gate.SetResult();
    }

    [Test]
    public async Task GET_InFlight_WithMismatchedUserKey_Returns404()
    {
        var gate = new TaskCompletionSource();
        var handlerStarted = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStreamWithSignal(ctx, gate.Task, handlerStarted, ct);

        var responseId = await CreateBackgroundResponseWithUserKeyAsync(UserKeyA);
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(3));

        var get = await GetWithUserKeyAsync(responseId, UserKeyB);
        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        gate.SetResult();
    }

    [Test]
    public async Task Cancel_InFlight_WithMismatchedUserKey_Returns404()
    {
        var gate = new TaskCompletionSource();
        var handlerStarted = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStreamWithSignal(ctx, gate.Task, handlerStarted, ct);

        var responseId = await CreateBackgroundResponseWithUserKeyAsync(UserKeyA);
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(3));

        var cancel = await CancelWithUserKeyAsync(responseId, UserKeyB);
        Assert.That(cancel.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        gate.SetResult();
    }

    // ─── async enumerator helpers (yield not allowed in lambdas) ──

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingStream(
        ResponseContext ctx,
        Task waitTask,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await waitTask.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingStreamWithSignal(
        ResponseContext ctx,
        Task waitTask,
        TaskCompletionSource signal,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        signal.TrySetResult();
        await waitTask.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }

    // ─── helpers ──────────────────────────────────────────────

    private async Task<string> CreateResponseWithUserKeyAsync(string userKey, string model = "test")
    {
        var response = await PostWithUserKeyAsync(new { model }, userKey);
        using var doc = await ParseJsonAsync(response);
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    private async Task<string> CreateBackgroundResponseWithUserKeyAsync(string userKey, string model = "test")
    {
        var response = await PostWithUserKeyAsync(new { model, background = true }, userKey);
        using var doc = await ParseJsonAsync(response);
        return doc.RootElement.GetProperty("id").GetString()!;
    }

    private async Task<HttpResponseMessage> PostWithUserKeyAsync(object requestObj, string userKey)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(requestObj),
                Encoding.UTF8,
                "application/json")
        };
        request.Headers.Add(PlatformHeaders.UserId, userKey);
        return await Client.SendAsync(request);
    }

    private Task<HttpResponseMessage> GetWithUserKeyAsync(string responseId, string userKey)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/responses/{responseId}");
        request.Headers.Add(PlatformHeaders.UserId, userKey);
        return Client.SendAsync(request);
    }

    private Task<HttpResponseMessage> CancelWithUserKeyAsync(string responseId, string userKey)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"/responses/{responseId}/cancel");
        request.Headers.Add(PlatformHeaders.UserId, userKey);
        return Client.SendAsync(request);
    }

    private Task<HttpResponseMessage> DeleteWithUserKeyAsync(string responseId, string userKey)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/responses/{responseId}");
        request.Headers.Add(PlatformHeaders.UserId, userKey);
        return Client.SendAsync(request);
    }

    private Task<HttpResponseMessage> GetInputItemsWithUserKeyAsync(string responseId, string userKey)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/responses/{responseId}/input_items");
        request.Headers.Add(PlatformHeaders.UserId, userKey);
        return Client.SendAsync(request);
    }

    private async Task WaitForBackgroundCompletionWithUserKeyAsync(string responseId, string userKey, TimeSpan? timeout = null)
    {
        var effectiveTimeout = timeout ?? TimeSpan.FromSeconds(5);
        var deadline = DateTimeOffset.UtcNow + effectiveTimeout;
        string lastObservedState = "no response received";
        while (DateTimeOffset.UtcNow < deadline)
        {
            var response = await GetWithUserKeyAsync(responseId, userKey);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                lastObservedState = "HTTP 404 NotFound";
                await Task.Delay(50);
                continue;
            }

            using var doc = await ParseJsonAsync(response);
            if (doc.RootElement.TryGetProperty("status", out var statusProp))
            {
                var status = statusProp.GetString();
                lastObservedState = $"status '{status}'";
                if (status is "completed" or "failed" or "incomplete" or "cancelled")
                {
                    return;
                }
            }
            else
            {
                lastObservedState = $"HTTP {(int)response.StatusCode} {response.StatusCode} without status property";
            }

            await Task.Delay(50);
        }

        Assert.Fail($"Timed out after {effectiveTimeout} waiting for response '{responseId}' to reach a terminal status. Last observed state: {lastObservedState}.");
    }
}
