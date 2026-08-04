// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public class ResponseMutationsTests
{
    // ── SetCompleted ──────────────────────────────────────────

    [Test]
    public void SetCompleted_SetsStatusToCompleted()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetCompleted();

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public void SetCompleted_SetsCompletedAt()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var before = DateTimeOffset.UtcNow;

        response.SetCompleted();

        Assert.That(response.CreatedAt, Is.Not.Null);
        Assert.That(response.CreatedAt, Is.Not.Null);
    }

    [Test]
    public void SetCompleted_WithUsage_SetsUsage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var usage = TestModels.ResponseUsage(10, 0, 20, 0, 30);

        response.SetCompleted(usage);

        Assert.That(response.Usage, Is.SameAs(usage));
    }

    [Test]
    public void SetCompleted_WithoutUsage_LeavesUsageNull()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetCompleted();

        Assert.That(response.Usage, Is.Null);
    }

    [Test]
    public void SetCompleted_DoesNotSetOutputText()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var msg = TestModels.OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[]
            {
                OpenAI.Responses.ResponseContentPart.CreateOutputTextPart("Hello ", Array.Empty<Annotation>())
            });
        response.OutputItems.Add(msg);

        response.SetCompleted();

        // output_text is a client SDK convenience property; the server never sets it.
        Assert.That(response.GetOutputText(), Is.Not.Null);
    }

    // ── SetFailed ─────────────────────────────────────────────

    [Test]
    public void SetFailed_SetsStatusToFailed()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetFailed();

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Failed));
    }

    [Test]
    public void SetFailed_SetsErrorCodeAndMessage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetFailed(OpenAI.Responses.ResponseErrorCode.RateLimitExceeded, "Too many requests");

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(OpenAI.Responses.ResponseErrorCode.RateLimitExceeded));
        Assert.That(response.Error.Message, Is.EqualTo("Too many requests"));
    }

    [Test]
    public void SetFailed_WithDefaults_UsesServerErrorAndDefaultMessage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetFailed();

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(OpenAI.Responses.ResponseErrorCode.ServerError));
        Assert.That(response.Error.Message, Is.EqualTo("An internal server error occurred."));
    }

    [Test]
    public void SetFailed_DoesNotSetCompletedAt()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetFailed();

        Assert.That(response.CreatedAt, Is.Not.Null);
    }

    [Test]
    public void SetFailed_WithException_MapsResponsesApiExceptionWithFidelity()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var error = new Error("rate_limit_exceeded", "Rate limit hit", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 429);

        response.SetFailed(ex);

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(OpenAI.Responses.ResponseErrorCode.RateLimitExceeded));
        Assert.That(response.Error.Message, Is.EqualTo("Rate limit hit"));
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Failed));
    }

    [Test]
    public void SetFailed_WithException_MapsBadRequestExceptionMessage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var ex = new BadRequestException("Model not supported");

        response.SetFailed(ex);

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(OpenAI.Responses.ResponseErrorCode.ServerError));
        Assert.That(response.Error.Message, Is.EqualTo("Model not supported"));
    }

    [Test]
    public void SetFailed_WithException_MapsGenericExceptionToGenericMessage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var ex = new InvalidOperationException("Internal stack trace details");

        response.SetFailed(ex);

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(OpenAI.Responses.ResponseErrorCode.ServerError));
        Assert.That(response.Error.Message, Is.EqualTo(ApiErrorFactory.GenericServerErrorMessage));
    }

    [Test]
    public void SetFailed_WithUsage_SetsUsage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var usage = TestModels.ResponseUsage(5, 0, 10, 0, 15);

        response.SetFailed(usage: usage);

        Assert.That(response.Usage, Is.SameAs(usage));
    }

    [Test]
    public void SetFailed_DoesNotSetOutputText()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var msg = TestModels.OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[]
            {
                OpenAI.Responses.ResponseContentPart.CreateOutputTextPart("Partial", Array.Empty<Annotation>())
            });
        response.OutputItems.Add(msg);

        response.SetFailed();

        // output_text is a client SDK convenience property; the server never sets it.
        Assert.That(response.GetOutputText(), Is.Not.Null);
    }

    // ── SetIncomplete ─────────────────────────────────────────

    [Test]
    public void SetIncomplete_SetsStatusToIncomplete()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetIncomplete();

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Incomplete));
    }

    [Test]
    public void SetIncomplete_WithReason_SetsIncompleteDetails()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);

        Assert.That(response.IncompleteStatusDetails, Is.Not.Null);
        Assert.That(response.IncompleteStatusDetails.Reason, Is.EqualTo(ResponseIncompleteDetailsReason.MaxOutputTokens));
    }

    [Test]
    public void SetIncomplete_WithoutReason_LeavesIncompleteDetailsNull()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetIncomplete();

        Assert.That(response.IncompleteStatusDetails, Is.Null);
    }

    [Test]
    public void SetIncomplete_DoesNotSetCompletedAt()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetIncomplete();

        Assert.That(response.CreatedAt, Is.Not.Null);
    }

    [Test]
    public void SetIncomplete_WithUsage_SetsUsage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var usage = TestModels.ResponseUsage(5, 0, 3, 0, 8);

        response.SetIncomplete(usage: usage);

        Assert.That(response.Usage, Is.SameAs(usage));
    }

    [Test]
    public void SetIncomplete_DoesNotSetOutputText()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var msg = TestModels.OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[]
            {
                OpenAI.Responses.ResponseContentPart.CreateOutputTextPart("Partial output", Array.Empty<Annotation>())
            });
        response.OutputItems.Add(msg);

        response.SetIncomplete();

        // output_text is a client SDK convenience property; the server never sets it.
        Assert.That(response.GetOutputText(), Is.Not.Null);
    }

    // ── CopyTerminalFields ──────────────────────────────────

    [Test]
    public void CopyTerminalFields_CopiesMutableFieldsExceptStatusAndOutput()
    {
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
            CompletedAt = DateTimeOffset.UtcNow,
            Error = ResponsesModelFactory.ResponseErrorInfo(OpenAI.Responses.ResponseErrorCode.ServerError, "test"),
            IncompleteDetails = TestModels.ResponseIncompleteDetails(ResponseIncompleteDetailsReason.MaxOutputTokens),
            Usage = TestModels.ResponseUsage(10, 0, 20, 0, 30),
        };

        var target = new Models.ResponseObject("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };

        ResponseMutations.CopyTerminalFields(source, target);

        // Status is NOT copied — managed by the pipeline
        Assert.That(target.Status, Is.EqualTo(ResponseStatus.InProgress));
        Assert.That(target.CreatedAt, Is.Not.Null);
        Assert.That(target.Error, Is.SameAs(source.Error));
        Assert.That(target.IncompleteStatusDetails, Is.SameAs(source.IncompleteStatusDetails));
        Assert.That(target.Usage, Is.SameAs(source.Usage));
        // OutputText is NOT copied — it is a client SDK convenience property
        Assert.That(target.GetOutputText(), Is.Null);
        // Output is NOT copied — accumulated via output item events
        Assert.That(target.OutputItems, Is.Empty);
    }

    // ── UpdateFromEvent ───────────────────────────────────────

    [Test]
    public void UpdateFromEvent_ResponseCreatedEvent_IsNoOp()
    {
        // With B37 full replacement, UpdateFromEvent is a no-op for response.created
        // (ReplaceResponse handles the full replacement).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseCreatedEvent { SequenceNumber = checked((int)(0)), Response = source };

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.That(target.Status, Is.EqualTo(ResponseStatus.InProgress));
    }

    [Test]
    public void UpdateFromEvent_ResponseCompletedEvent_IsNoOp()
    {
        // UpdateFromEvent no longer auto-sets terminal status;
        // handler is source of truth. ReplaceResponse handles full replacement (B37).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
            CompletedAt = DateTimeOffset.UtcNow,
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o");
        var evt = new ResponseCompletedEvent { SequenceNumber = checked((int)(0)), Response = source };

        target.UpdateFromEvent(evt);

        // No fields are set — handler must set status via SetCompleted()
        Assert.That(target.Status, Is.Null);
        Assert.That(target.CreatedAt, Is.Not.Null);
    }

    [Test]
    public void UpdateFromEvent_ResponseFailedEvent_IsNoOp()
    {
        // UpdateFromEvent no longer auto-sets terminal status;
        // handler is source of truth. ReplaceResponse handles full replacement (B37).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Failed,
            Error = ResponsesModelFactory.ResponseErrorInfo(OpenAI.Responses.ResponseErrorCode.ServerError, "Oops"),
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o");
        var evt = new ResponseFailedEvent { SequenceNumber = checked((int)(0)), Response = source };

        target.UpdateFromEvent(evt);

        // No fields are set — handler must set status via SetFailed()
        Assert.That(target.Status, Is.Null);
        Assert.That(target.Error, Is.Null);
    }

    [Test]
    public void UpdateFromEvent_ResponseIncompleteEvent_IsNoOp()
    {
        // UpdateFromEvent no longer auto-sets terminal status;
        // handler is source of truth. ReplaceResponse handles full replacement (B37).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Incomplete,
            IncompleteDetails = TestModels.ResponseIncompleteDetails(ResponseIncompleteDetailsReason.MaxOutputTokens),
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o");
        var evt = new ResponseIncompleteEvent { SequenceNumber = checked((int)(0)), Response = source };

        target.UpdateFromEvent(evt);

        // No fields are set — handler must set status via SetIncomplete()
        Assert.That(target.Status, Is.Null);
        Assert.That(target.IncompleteStatusDetails, Is.Null);
    }

    [Test]
    public void UpdateFromEvent_ResponseQueuedEvent_IsNoOp()
    {
        // With B37 full replacement, UpdateFromEvent is a no-op for response.queued
        // (ReplaceResponse handles the full replacement).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Queued,
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseQueuedEvent { SequenceNumber = checked((int)(0)), Response = source };

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.That(target.Status, Is.EqualTo(ResponseStatus.InProgress));
    }

    [Test]
    public void UpdateFromEvent_ResponseInProgressEvent_IsNoOp()
    {
        // With B37 full replacement, UpdateFromEvent is a no-op for response.in_progress
        // (ReplaceResponse handles the full replacement).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseInProgressEvent { SequenceNumber = checked((int)(0)), Response = source };

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.That(target.Status, Is.EqualTo(ResponseStatus.InProgress));
    }

    [Test]
    public void UpdateFromEvent_OutputItemAddedEvent_SetsItemAtIndex()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var item = TestModels.OutputItemMessage(
            "msg_1",
            MessageStatus.InProgress,
            Array.Empty<MessageContent>());
        var evt = new ResponseOutputItemAddedEvent { SequenceNumber = checked((int)(0)), OutputIndex = checked((int)(0)), Item = item };

        response.UpdateFromEvent(evt);

        XAssert.Single(response.OutputItems);
        Assert.That(response.OutputItems[0], Is.SameAs(item));
    }

    [Test]
    public void UpdateFromEvent_OutputItemDoneEvent_SetsItemAtIndex()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var item = TestModels.OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            Array.Empty<MessageContent>());
        var evt = new ResponseOutputItemDoneEvent { SequenceNumber = checked((int)(0)), OutputIndex = checked((int)(0)), Item = item };

        response.UpdateFromEvent(evt);

        XAssert.Single(response.OutputItems);
        Assert.That(response.OutputItems[0], Is.SameAs(item));
    }

    [Test]
    public void UpdateFromEvent_UnrelatedEvent_IsNoOp()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseTextDeltaEvent { SequenceNumber = 0, ItemId = "item_1", OutputIndex = 0, ContentIndex = 0, Delta = "delta" };

        response.UpdateFromEvent(evt);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.InProgress));
        Assert.That(response.OutputItems, Is.Empty);
    }

    // ── SetOutputItemAtIndex ──────────────────────────────────

    [Test]
    public void SetOutputItemAtIndex_PadsListWithNulls()
    {
        var output = new List<OutputItem>();
        var item = TestModels.OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            Array.Empty<MessageContent>());

        output.SetOutputItemAtIndex(2, item);

        Assert.That(output.Count, Is.EqualTo(3));
        Assert.That(output[0], Is.Null);
        Assert.That(output[1], Is.Null);
        Assert.That(output[2], Is.SameAs(item));
    }

    [Test]
    public void SetOutputItemAtIndex_ReplacesExistingItem()
    {
        var output = new List<OutputItem>();
        var item1 = TestModels.OutputItemMessage("msg_1", MessageStatus.InProgress, Array.Empty<MessageContent>());
        var item2 = TestModels.OutputItemMessage("msg_1", MessageStatus.Completed, Array.Empty<MessageContent>());

        output.SetOutputItemAtIndex(0, item1);
        output.SetOutputItemAtIndex(0, item2);

        XAssert.Single(output);
        Assert.That(output[0], Is.SameAs(item2));
    }
}
