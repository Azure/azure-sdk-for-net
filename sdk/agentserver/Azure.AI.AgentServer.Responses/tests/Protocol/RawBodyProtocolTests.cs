// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for ResponseContext.RawBody (S-005).
/// Verifies the handler can access the full raw JSON request body,
/// including custom fields not in the typed model.
/// </summary>
public sealed class RawBodyProtocolTests : ProtocolTestBase
{
    private BinaryData? _capturedRawBody;
    private int _rawBodyAccessCount;

    public RawBodyProtocolTests()
    {
        // Capture RawBody inside the handler
        Handler.EventFactory = (request, context, ct) =>
        {
            _capturedRawBody = context.RawBody;
            _rawBodyAccessCount++;
            return YieldDefault(request, context, ct);
        };
    }

    private static async IAsyncEnumerable<Azure.AI.AgentServer.Responses.Models.ResponseStreamEvent> YieldDefault(
        Azure.AI.AgentServer.Responses.Models.CreateResponse request,
        ResponseContext context,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Azure.AI.AgentServer.Responses.Models.ResponseObject(context.ResponseId, request.Model ?? "test-model");
        yield return new Azure.AI.AgentServer.Responses.Models.ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new Azure.AI.AgentServer.Responses.Models.ResponseCompletedEvent(0, response);
    }

    /// <summary>Parses the captured BinaryData into a JsonElement for assertion convenience.</summary>
    private JsonElement ParseCapturedBody()
    {
        Assert.That(_capturedRawBody, Is.Not.Null, "RawBody should be set by the handler");
        return JsonDocument.Parse(_capturedRawBody!).RootElement;
    }

    [Test]
    public async Task RawBody_ContainsStandardFields()
    {
        // T028 / S-005: RawBody contains standard fields
        await PostResponsesAsync(new { model = "gpt-4o" });

        var root = ParseCapturedBody();
        Assert.That(root.ValueKind, Is.EqualTo(JsonValueKind.Object));
        Assert.That(root.TryGetProperty("model", out var modelProp), Is.True);
        Assert.That(modelProp.GetString(), Is.EqualTo("gpt-4o"));
    }

    [Test]
    public async Task RawBody_ContainsCustomFields()
    {
        // T029 / S-005: RawBody contains custom fields not in typed model
        // Use x_ prefix to avoid collision with known schema fields
        var json = JsonSerializer.Serialize(new
        {
            model = "test",
            x_custom_extension = "hello-world",
            x_extra_info = new { key1 = "value1", key2 = "value2" }
        });
        var response = await PostResponsesAsync(json);

        Assert.That(response.IsSuccessStatusCode, Is.True, $"Request failed with {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
        var root = ParseCapturedBody();
        Assert.That(root.TryGetProperty("x_custom_extension", out var customProp), Is.True, "RawBody should include x_custom_extension field");
        Assert.That(customProp.GetString(), Is.EqualTo("hello-world"));

        Assert.That(root.TryGetProperty("x_extra_info", out var extraProp), Is.True, "RawBody should include x_extra_info field");
        Assert.That(extraProp.ValueKind, Is.EqualTo(JsonValueKind.Object));
        Assert.That(extraProp.GetProperty("key1").GetString(), Is.EqualTo("value1"));
    }

    [Test]
    public async Task RawBody_IsStableAcrossMultipleAccesses()
    {
        // T030 / S-005: RawBody returns same value on multiple accesses
        BinaryData? firstAccess = null;
        BinaryData? secondAccess = null;

        Handler.EventFactory = (request, context, ct) =>
        {
            firstAccess = context.RawBody;
            secondAccess = context.RawBody;
            _rawBodyAccessCount++;
            return YieldDefault(request, context, ct);
        };

        await PostResponsesAsync(new { model = "test" });

        Assert.That(firstAccess, Is.Not.Null);
        Assert.That(secondAccess, Is.Not.Null);
        Assert.That(firstAccess, Is.SameAs(secondAccess), "BinaryData instance should be the same object on repeated access");
    }

    [Test]
    public async Task RawBody_ContainsStreamField()
    {
        // Additional: verify boolean fields are preserved as-is in raw body
        var json = JsonSerializer.Serialize(new
        {
            model = "test",
            stream = true
        });
        await PostResponsesAsync(json);

        var root = ParseCapturedBody();
        Assert.That(root.TryGetProperty("stream", out var streamProp), Is.True);
        Assert.That(streamProp.GetBoolean(), Is.True);
    }
}
