// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for error source classification headers.
/// Validates that <c>x-platform-error-source</c> and <c>x-platform-error-detail</c>
/// are set correctly on error responses per container-image-spec §8.
/// </summary>
public class ErrorSourceHeaderTests : ProtocolTestBase
{
    // ── User errors ─────────────────────────────────────────

    [Test]
    public async Task POST_EmptyBody_ErrorSource_IsUser()
    {
        var response = await PostResponsesAsync("");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        AssertErrorSource(response, "user");
        AssertNoErrorDetail(response);
    }

    [Test]
    public async Task POST_InvalidJson_ErrorSource_IsUser()
    {
        var response = await PostResponsesAsync("{invalid!");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        AssertErrorSource(response, "user");
    }

    [Test]
    public async Task GET_UnknownId_ErrorSource_IsUser()
    {
        var response = await GetResponseAsync(IdGenerator.NewResponseId());

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        AssertErrorSource(response, "user");
    }

    [Test]
    public async Task Cancel_UnknownId_ErrorSource_IsUser()
    {
        var response = await CancelResponseAsync(IdGenerator.NewResponseId());

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        AssertErrorSource(response, "user");
    }

    [Test]
    public async Task POST_MalformedResponseId_ErrorSource_IsUser()
    {
        var response = await PostResponsesAsync("""{"previous_response_id":"not-a-valid-id"}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        AssertErrorSource(response, "user");
    }

    // ── Upstream errors (handler exceptions) ────────────────

    [Test]
    public async Task POST_HandlerThrows_BeforeCreated_ErrorSource_IsUpstream()
    {
        // Handler throws before yielding any events — exception filter catches it
        // and returns 500 with upstream error source.
        // Error detail is omitted for upstream errors (developer code — not our concern).
        Handler.EventFactory = (req, ctx, ct) => ThrowingHandler(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        AssertErrorSource(response, "upstream");
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorDetail), Is.False,
            "Upstream errors should not include error detail");
    }

    // ── Assertion helpers ───────────────────────────────────

    private static void AssertErrorSource(HttpResponseMessage response, string expected)
    {
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorSource), Is.True,
            $"Expected {PlatformHeaders.ErrorSource} header to be present");
        var value = response.Headers.GetValues(PlatformHeaders.ErrorSource).First();
        Assert.That(value, Is.EqualTo(expected));
    }

    private static void AssertNoErrorDetail(HttpResponseMessage response)
    {
        // User errors typically don't include error detail
        Assert.That(response.Headers.Contains(PlatformHeaders.ErrorDetail), Is.False);
    }

    // ── Helpers ─────────────────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingHandler(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        throw new InvalidOperationException("Handler failed");
#pragma warning disable CS0162 // Unreachable code — required for async enumerable compilation
        yield break;
#pragma warning restore CS0162
    }
}
