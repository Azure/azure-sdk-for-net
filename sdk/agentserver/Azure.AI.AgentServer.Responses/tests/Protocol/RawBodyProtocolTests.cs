// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for IResponseContext.RawBody (US7 / FR-019..022).
/// Verifies the handler can access the full raw JSON request body,
/// including custom fields not in the typed model.
/// </summary>
public sealed class RawBodyProtocolTests : ProtocolTestBase
{
    private JsonElement _capturedRawBody;
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
        IResponseContext context,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Azure.AI.AgentServer.Responses.Models.Response(context.ResponseId, request.Model ?? "test-model");
        yield return new Azure.AI.AgentServer.Responses.Models.ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new Azure.AI.AgentServer.Responses.Models.ResponseCompletedEvent(0, response);
    }

    [Test]
    public async Task RawBody_ContainsStandardFields()
    {
        // T028 / FR-019, FR-021: RawBody contains standard fields
        await PostResponsesAsync(new { model = "gpt-4o" });

        Assert.AreNotEqual(default, _capturedRawBody);
        Assert.AreEqual(JsonValueKind.Object, _capturedRawBody.ValueKind);
        Assert.IsTrue(_capturedRawBody.TryGetProperty("model", out var modelProp));
        Assert.AreEqual("gpt-4o", modelProp.GetString());
    }

    [Test]
    public async Task RawBody_ContainsCustomFields()
    {
        // T029 / FR-021: RawBody contains custom fields not in typed model
        // Use x_ prefix to avoid collision with known schema fields
        var json = JsonSerializer.Serialize(new
        {
            model = "test",
            x_custom_extension = "hello-world",
            x_extra_info = new { key1 = "value1", key2 = "value2" }
        });
        var response = await PostResponsesAsync(json);

        Assert.IsTrue(response.IsSuccessStatusCode,
            $"Request failed with {response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
        Assert.AreNotEqual(default, _capturedRawBody);
        Assert.IsTrue(_capturedRawBody.TryGetProperty("x_custom_extension", out var customProp),
            "RawBody should include x_custom_extension field");
        Assert.AreEqual("hello-world", customProp.GetString());

        Assert.IsTrue(_capturedRawBody.TryGetProperty("x_extra_info", out var extraProp),
            "RawBody should include x_extra_info field");
        Assert.AreEqual(JsonValueKind.Object, extraProp.ValueKind);
        Assert.AreEqual("value1", extraProp.GetProperty("key1").GetString());
    }

    [Test]
    public async Task RawBody_IsStableAcrossMultipleAccesses()
    {
        // T030 / FR-022: RawBody returns same value on multiple accesses
        JsonElement firstAccess = default;
        JsonElement secondAccess = default;

        Handler.EventFactory = (request, context, ct) =>
        {
            firstAccess = context.RawBody;
            secondAccess = context.RawBody;
            _rawBodyAccessCount++;
            return YieldDefault(request, context, ct);
        };

        await PostResponsesAsync(new { model = "test" });

        Assert.AreNotEqual(default, firstAccess);
        Assert.AreNotEqual(default, secondAccess);
        Assert.AreEqual(firstAccess.GetRawText(), secondAccess.GetRawText());
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

        Assert.AreNotEqual(default, _capturedRawBody);
        Assert.IsTrue(_capturedRawBody.TryGetProperty("stream", out var streamProp));
        Assert.IsTrue(streamProp.GetBoolean());
    }
}
