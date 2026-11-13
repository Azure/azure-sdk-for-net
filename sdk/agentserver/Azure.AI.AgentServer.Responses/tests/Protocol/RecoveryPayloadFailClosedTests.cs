// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Fail-closed negative tests for <see cref="ResponseRecoveryPayload"/>. Malformed, missing, or
/// wrong-typed persisted input MUST fail deterministically (before any handler dispatch) rather
/// than silently re-invoking with partial input. Matches the Python fail-closed
/// <c>from_task_input</c> boundary.
/// </summary>
public class RecoveryPayloadFailClosedTests
{
    [Test]
    public void FromTaskInput_NotJson_Throws()
    {
        Assert.Throws<RecoveryPayloadFormatException>(
            () => ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString("not-json{")));
    }

    [Test]
    public void FromTaskInput_NotAnObject_Throws()
    {
        Assert.Throws<RecoveryPayloadFormatException>(
            () => ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString("[1,2,3]")));
    }

    [Test]
    public void FromTaskInput_MissingResponseId_Throws()
    {
        var json = """{ "request": { }, "disposition": "re-invoke" }""";
        var ex = Assert.Throws<RecoveryPayloadFormatException>(
            () => ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json)));
        Assert.That(ex!.Message, Does.Contain("response_id"));
    }

    [Test]
    public void FromTaskInput_EmptyResponseId_Throws()
    {
        var json = """{ "response_id": "", "request": { } }""";
        Assert.Throws<RecoveryPayloadFormatException>(
            () => ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json)));
    }

    [Test]
    public void FromTaskInput_WrongTypeResponseId_Throws()
    {
        var json = """{ "response_id": 123, "request": { } }""";
        Assert.Throws<RecoveryPayloadFormatException>(
            () => ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json)));
    }

    [Test]
    public void FromTaskInput_MissingRequest_Throws()
    {
        var json = """{ "response_id": "caresp_x" }""";
        var ex = Assert.Throws<RecoveryPayloadFormatException>(
            () => ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json)));
        Assert.That(ex!.Message, Does.Contain("request"));
    }

    [Test]
    public void FromTaskInput_RequestWrongType_Throws()
    {
        var json = """{ "response_id": "caresp_x", "request": "not-an-object" }""";
        Assert.Throws<RecoveryPayloadFormatException>(
            () => ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json)));
    }

    [Test]
    public void FromTaskInput_MissingDisposition_DefaultsToReinvoke()
    {
        // Backward-compat default (matches Python `disposition=params.get(...) or "re-invoke"`).
        var json = """{ "response_id": "caresp_x", "request": { } }""";
        var payload = ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json));
        Assert.That(payload.Disposition, Is.EqualTo(ResponseRecoveryPayload.DispositionReinvoke));
    }

    [Test]
    public void FromTaskInput_UnrecognizedDisposition_Throws()
    {
        // Fail-closed: an unknown disposition must NOT silently fall through to re-invoke (which
        // would run handler side effects on ambiguous intent). It is rejected before dispatch.
        var json = """{ "response_id": "caresp_x", "request": { }, "disposition": "obliterate" }""";
        var ex = Assert.Throws<RecoveryPayloadFormatException>(
            () => ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json)));
        Assert.That(ex!.Message, Does.Contain("disposition"));
    }

    [Test]
    public void FromTaskInput_MarkFailedDisposition_Preserved()
    {
        var json = """{ "response_id": "caresp_x", "request": { }, "disposition": "mark-failed" }""";
        var payload = ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json));
        Assert.That(payload.Disposition, Is.EqualTo(ResponseRecoveryPayload.DispositionMarkFailed));
    }

    [Test]
    public void FromTaskInput_MissingOptionalFields_DefaultToNullOrEmpty()
    {
        var json = """{ "response_id": "caresp_x", "request": { } }""";
        var payload = ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(json));

        Assert.Multiple(() =>
        {
            Assert.That(payload.AgentReference, Is.Null);
            Assert.That(payload.AgentSessionId, Is.Null);
            Assert.That(payload.UserIdKey, Is.Null);
            Assert.That(payload.CallId, Is.Null);
            Assert.That(payload.ClientHeaders, Is.Empty);
            Assert.That(payload.QueryParameters, Is.Empty);
        });
    }

    [Test]
    public void Constructor_NullResponseId_Throws()
    {
        Assert.Throws<ArgumentNullException>(
            () => new ResponseRecoveryPayload(null!, ResponseRecoveryPayload.DispositionReinvoke, new CreateResponse()));
    }

    [Test]
    public void Constructor_NullRequest_Throws()
    {
        Assert.Throws<ArgumentNullException>(
            () => new ResponseRecoveryPayload("caresp_x", ResponseRecoveryPayload.DispositionReinvoke, null!));
    }
}
