// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol parity tests for <see cref="ResponseRecoveryPayload"/> — the persisted resilient
/// recovery payload. Verifies the exact 9-field schema, type/nullability/casing, and the
/// explicit "persisted vs re-derived" boundary against the Python
/// <c>ResilientResponseInput</c> contract.
/// </summary>
public class RecoveryPayloadParityProtocolTests
{
    private static CreateResponse SampleRequest() => new()
    {
        Model = "gpt-4o",
        Background = true,
        Store = true,
        Stream = true,
        PreviousResponseId = "caresp_prev123",
    };

    [Test]
    public void ToTaskInput_EmitsExactlyTheNinePersistedFields()
    {
        var payload = new ResponseRecoveryPayload(
            responseId: "caresp_abc",
            disposition: ResponseRecoveryPayload.DispositionReinvoke,
            request: SampleRequest(),
            agentReference: new AgentReference("my-agent") { Version = "1.0" },
            agentSessionId: "sess_123",
            userIdKey: "user_key_1",
            callId: "call_1",
            clientHeaders: new Dictionary<string, string> { ["x-client-a"] = "1" },
            queryParameters: new Dictionary<string, string> { ["stream"] = "true" });

        using var doc = JsonDocument.Parse(payload.ToTaskInput().ToMemory());
        var root = doc.RootElement;

        var keys = root.EnumerateObject().Select(p => p.Name).OrderBy(n => n, StringComparer.Ordinal).ToArray();
        Assert.That(keys, Is.EqualTo(new[]
        {
            "agent_reference",
            "agent_session_id",
            "call_id",
            "client_headers",
            "disposition",
            "query_parameters",
            "request",
            "response_id",
            "user_id_key",
        }));
    }

    [Test]
    public void ToTaskInput_DoesNotPersistReDerivedFields()
    {
        var payload = new ResponseRecoveryPayload(
            "caresp_abc", ResponseRecoveryPayload.DispositionReinvoke, SampleRequest());

        using var doc = JsonDocument.Parse(payload.ToTaskInput().ToMemory());
        var root = doc.RootElement;

        // These are re-derived from `request` on recovery — must NOT appear as top-level fields.
        foreach (var reDerived in new[] { "store", "stream", "background", "model", "previous_response_id", "conversation_id", "input_items" })
        {
            Assert.That(root.TryGetProperty(reDerived, out _), Is.False, $"'{reDerived}' must not be a top-level persisted field");
        }
    }

    [Test]
    public void ToTaskInput_FieldTypesAndCasingMatchSchema()
    {
        var payload = new ResponseRecoveryPayload(
            "caresp_abc", ResponseRecoveryPayload.DispositionMarkFailed, SampleRequest(),
            agentSessionId: null, userIdKey: null, callId: null);

        using var doc = JsonDocument.Parse(payload.ToTaskInput().ToMemory());
        var root = doc.RootElement;

        Assert.Multiple(() =>
        {
            Assert.That(root.GetProperty("response_id").ValueKind, Is.EqualTo(JsonValueKind.String));
            Assert.That(root.GetProperty("response_id").GetString(), Is.EqualTo("caresp_abc"));
            Assert.That(root.GetProperty("disposition").GetString(), Is.EqualTo("mark-failed"));
            Assert.That(root.GetProperty("request").ValueKind, Is.EqualTo(JsonValueKind.Object));
            Assert.That(root.GetProperty("client_headers").ValueKind, Is.EqualTo(JsonValueKind.Object));
            Assert.That(root.GetProperty("query_parameters").ValueKind, Is.EqualTo(JsonValueKind.Object));
            // Absent optionals are persisted as explicit JSON null (never omitted).
            Assert.That(root.GetProperty("agent_session_id").ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(root.GetProperty("user_id_key").ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(root.GetProperty("call_id").ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(root.GetProperty("agent_reference").ValueKind, Is.EqualTo(JsonValueKind.Null));
        });
    }

    [Test]
    public void RoundTrip_PreservesAllPersistedFields()
    {
        var original = new ResponseRecoveryPayload(
            "caresp_rt",
            ResponseRecoveryPayload.DispositionReinvoke,
            SampleRequest(),
            agentReference: new AgentReference("agent-x") { Version = "2.1" },
            agentSessionId: "sess_rt",
            userIdKey: "u_rt",
            callId: "c_rt",
            clientHeaders: new Dictionary<string, string> { ["x-client-trace"] = "abc" },
            queryParameters: new Dictionary<string, string> { ["starting_after"] = "5" });

        var restored = ResponseRecoveryPayload.FromTaskInput(original.ToTaskInput());

        Assert.Multiple(() =>
        {
            Assert.That(restored.ResponseId, Is.EqualTo("caresp_rt"));
            Assert.That(restored.Disposition, Is.EqualTo(ResponseRecoveryPayload.DispositionReinvoke));
            Assert.That(restored.Request.Model, Is.EqualTo("gpt-4o"));
            Assert.That(restored.Request.PreviousResponseId, Is.EqualTo("caresp_prev123"));
            Assert.That(restored.AgentReference, Is.Not.Null);
            Assert.That(restored.AgentReference!.Name, Is.EqualTo("agent-x"));
            Assert.That(restored.AgentReference.Version, Is.EqualTo("2.1"));
            Assert.That(restored.AgentSessionId, Is.EqualTo("sess_rt"));
            Assert.That(restored.UserIdKey, Is.EqualTo("u_rt"));
            Assert.That(restored.CallId, Is.EqualTo("c_rt"));
            Assert.That(restored.ClientHeaders["x-client-trace"], Is.EqualTo("abc"));
            Assert.That(restored.QueryParameters["starting_after"], Is.EqualTo("5"));
        });
    }

    [Test]
    public void ClientHeadersAndQueryParameters_PreservedVerbatimNotDroppedToEmpty()
    {
        // Spec 033 FR-002b regression: headers/query must not be silently dropped to {}.
        var payload = new ResponseRecoveryPayload(
            "caresp_h", ResponseRecoveryPayload.DispositionReinvoke, SampleRequest(),
            clientHeaders: new Dictionary<string, string> { ["x-client-a"] = "1", ["x-client-b"] = "2" },
            queryParameters: new Dictionary<string, string> { ["p"] = "q" });

        var restored = ResponseRecoveryPayload.FromTaskInput(payload.ToTaskInput());

        Assert.That(restored.ClientHeaders, Has.Count.EqualTo(2));
        Assert.That(restored.ClientHeaders["x-client-a"], Is.EqualTo("1"));
        Assert.That(restored.ClientHeaders["x-client-b"], Is.EqualTo("2"));
        Assert.That(restored.QueryParameters["p"], Is.EqualTo("q"));
    }
}
