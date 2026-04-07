// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

/// <summary>
/// T003: Tests for Models.ResponseObject.Snapshot() deep copy via ModelReaderWriter round-trip.
/// Verifies snapshot independence, round-trip fidelity, and polymorphic subtype support.
/// </summary>
public class ResponseSnapshotTests
{
    [Test]
    public void Snapshot_ReturnsIndependentCopy_StatusMutationDoesNotAffectSnapshot()
    {
        // Arrange
        var original = new Models.ResponseObject("resp_snap1", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
        };

        // Act
        var snapshot = original.Snapshot();
        original.Status = ResponseStatus.Completed;

        // Assert
        Assert.That(snapshot.Status, Is.EqualTo(ResponseStatus.InProgress));
        Assert.That(original.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public void Snapshot_ReturnsIndependentCopy_AddingOutputDoesNotAffectSnapshot()
    {
        // Arrange
        var original = new Models.ResponseObject("resp_snap2", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
        };
        var message = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            MessageRole.Assistant,
            Array.Empty<MessageContent>());
        original.Output.Add(message);

        // Act
        var snapshot = original.Snapshot();
        var message2 = new OutputItemMessage(
            "msg_2",
            MessageStatus.Completed,
            MessageRole.Assistant,
            Array.Empty<MessageContent>());
        original.Output.Add(message2);

        // Assert
        XAssert.Single(snapshot.Output);
        Assert.That(original.Output.Count, Is.EqualTo(2));
    }

    [Test]
    public void Snapshot_PreservesAllCoreProperties()
    {
        // Arrange
        var original = new Models.ResponseObject("resp_snap3", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
            CompletedAt = new DateTimeOffset(2026, 3, 8, 12, 0, 0, TimeSpan.Zero),
        };

        // Act
        var snapshot = original.Snapshot();

        // Assert
        Assert.That(snapshot.Id, Is.EqualTo(original.Id));
        Assert.That(snapshot.Model, Is.EqualTo(original.Model));
        Assert.That(snapshot.Status, Is.EqualTo(original.Status));
        // CreatedAt is auto-set by the constructor; JSON round-trip truncates to seconds
        Assert.That(snapshot.CreatedAt.ToUnixTimeSeconds(), Is.EqualTo(original.CreatedAt.ToUnixTimeSeconds()));
        Assert.That(snapshot.CompletedAt, Is.EqualTo(original.CompletedAt));
    }

    [Test]
    public void Snapshot_PreservesPolymorphicOutputItems()
    {
        // Arrange
        var message = new OutputItemMessage(
            "msg_poly",
            MessageStatus.Completed,
            MessageRole.Assistant,
            Array.Empty<MessageContent>());

        var functionCall = new OutputItemFunctionToolCall(
            "call_fn1",
            "get_weather",
            """{"location":"Seattle"}""");

        var original = new Models.ResponseObject("resp_snap4", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
        };
        original.Output.Add(message);
        original.Output.Add(functionCall);

        // Act
        var snapshot = original.Snapshot();

        // Assert — polymorphic types preserved
        Assert.That(snapshot.Output.Count, Is.EqualTo(2));

        var snappedMessage = XAssert.IsType<OutputItemMessage>(snapshot.Output[0]);
        Assert.That(snappedMessage.Id, Is.EqualTo("msg_poly"));
        Assert.That(snappedMessage.Role, Is.EqualTo(MessageRole.Assistant));

        var snappedFunction = XAssert.IsType<OutputItemFunctionToolCall>(snapshot.Output[1]);
        Assert.That(snappedFunction.CallId, Is.EqualTo("call_fn1"));
        Assert.That(snappedFunction.Name, Is.EqualTo("get_weather"));
        Assert.That(snappedFunction.Arguments, Is.EqualTo("""{"location":"Seattle"}"""));
    }

    [Test]
    public void Snapshot_PreservesMetadata()
    {
        // Arrange
        var original = new Models.ResponseObject("resp_snap5", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
            Metadata = new Metadata
            {
                AdditionalProperties = { ["user_id"] = "u_123", ["session"] = "s_456" },
            },
        };

        // Act
        var snapshot = original.Snapshot();

        // Assert
        Assert.That(snapshot.Metadata, Is.Not.Null);
        Assert.That(snapshot.Metadata.AdditionalProperties["user_id"], Is.EqualTo("u_123"));
        Assert.That(snapshot.Metadata.AdditionalProperties["session"], Is.EqualTo("s_456"));
    }

    [Test]
    public void Snapshot_MetadataMutationDoesNotAffectSnapshot()
    {
        // Arrange
        var original = new Models.ResponseObject("resp_snap6", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
            Metadata = new Metadata
            {
                AdditionalProperties = { ["key1"] = "value1" },
            },
        };

        // Act
        var snapshot = original.Snapshot();
        original.Metadata.AdditionalProperties["key2"] = "value2";

        // Assert — snapshot unaffected by mutation of original's metadata
        Assert.That(snapshot.Metadata.AdditionalProperties.ContainsKey("key2"), Is.False);
        XAssert.Single(snapshot.Metadata.AdditionalProperties);
    }

    [Test]
    public void Snapshot_PreservesErrorField()
    {
        // Arrange
        var original = new Models.ResponseObject("resp_snap7", "gpt-4o")
        {
            Status = ResponseStatus.Failed,
            Error = ResponsesModelFactory.ResponseErrorInfo(
                code: ResponseErrorCode.ServerError,
                message: "Something went wrong"),
        };

        // Act
        var snapshot = original.Snapshot();

        // Assert
        Assert.That(snapshot.Error, Is.Not.Null);
        Assert.That(snapshot.Error.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(snapshot.Error.Message, Is.EqualTo("Something went wrong"));
    }

    [Test]
    public void Snapshot_ReturnsNewInstance_NotSameReference()
    {
        // Arrange
        var original = new Models.ResponseObject("resp_snap8", "gpt-4o");

        // Act
        var snapshot = original.Snapshot();

        // Assert
        Assert.That(snapshot, Is.Not.SameAs(original));
    }

    [Test]
    public void Snapshot_EmptyResponse_RoundTripsSuccessfully()
    {
        // Arrange — minimal response with no output, no error, no metadata
        var original = new Models.ResponseObject("resp_snap9", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
        };

        // Act
        var snapshot = original.Snapshot();

        // Assert
        Assert.That(snapshot.Id, Is.EqualTo("resp_snap9"));
        Assert.That(snapshot.Model, Is.EqualTo("gpt-4o"));
        Assert.That(snapshot.Status, Is.EqualTo(ResponseStatus.InProgress));
        Assert.That(snapshot.Output, Is.Empty);
    }
}
