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

        Assert.That(response.CompletedAt, Is.Not.Null);
        XAssert.InRange(response.CompletedAt!.Value, before, DateTimeOffset.UtcNow.AddSeconds(1));
    }

    [Test]
    public void SetCompleted_WithUsage_SetsUsage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var usage = new ResponseUsage(10, new ResponseUsageInputTokensDetails(0), 20, new ResponseUsageOutputTokensDetails(0), 30);

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
    public void SetCompleted_ComputesOutputText()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var msg = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[]
            {
                new MessageContentOutputTextContent("Hello ", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            });
        response.Output.Add(msg);

        response.SetCompleted();

        Assert.That(response.OutputText, Is.EqualTo("Hello "));
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

        response.SetFailed(ResponseErrorCode.RateLimitExceeded, "Too many requests");

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(ResponseErrorCode.RateLimitExceeded));
        Assert.That(response.Error.Message, Is.EqualTo("Too many requests"));
    }

    [Test]
    public void SetFailed_WithDefaults_UsesServerErrorAndDefaultMessage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetFailed();

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(response.Error.Message, Is.EqualTo("An internal server error occurred."));
    }

    [Test]
    public void SetFailed_DoesNotSetCompletedAt()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetFailed();

        Assert.That(response.CompletedAt, Is.Null);
    }

    [Test]
    public void SetFailed_WithException_MapsResponsesApiExceptionWithFidelity()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var error = new Error("rate_limit_exceeded", "Rate limit hit", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 429);

        response.SetFailed(ex);

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(ResponseErrorCode.RateLimitExceeded));
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
        Assert.That(response.Error.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(response.Error.Message, Is.EqualTo("Model not supported"));
    }

    [Test]
    public void SetFailed_WithException_MapsGenericExceptionToGenericMessage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var ex = new InvalidOperationException("Internal stack trace details");

        response.SetFailed(ex);

        Assert.That(response.Error, Is.Not.Null);
        Assert.That(response.Error.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(response.Error.Message, Is.EqualTo(ApiErrorFactory.GenericServerErrorMessage));
    }

    [Test]
    public void SetFailed_WithUsage_SetsUsage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var usage = new ResponseUsage(5, new ResponseUsageInputTokensDetails(0), 10, new ResponseUsageOutputTokensDetails(0), 15);

        response.SetFailed(usage: usage);

        Assert.That(response.Usage, Is.SameAs(usage));
    }

    [Test]
    public void SetFailed_ComputesOutputText()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var msg = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[]
            {
                new MessageContentOutputTextContent("Partial", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            });
        response.Output.Add(msg);

        response.SetFailed();

        Assert.That(response.OutputText, Is.EqualTo("Partial"));
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

        Assert.That(response.IncompleteDetails, Is.Not.Null);
        Assert.That(response.IncompleteDetails.Reason, Is.EqualTo(ResponseIncompleteDetailsReason.MaxOutputTokens));
    }

    [Test]
    public void SetIncomplete_WithoutReason_LeavesIncompleteDetailsNull()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetIncomplete();

        Assert.That(response.IncompleteDetails, Is.Null);
    }

    [Test]
    public void SetIncomplete_DoesNotSetCompletedAt()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        response.SetIncomplete();

        Assert.That(response.CompletedAt, Is.Null);
    }

    [Test]
    public void SetIncomplete_WithUsage_SetsUsage()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var usage = new ResponseUsage(5, new ResponseUsageInputTokensDetails(0), 3, new ResponseUsageOutputTokensDetails(0), 8);

        response.SetIncomplete(usage: usage);

        Assert.That(response.Usage, Is.SameAs(usage));
    }

    [Test]
    public void SetIncomplete_ComputesOutputText()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var msg = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[]
            {
                new MessageContentOutputTextContent("Partial output", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            });
        response.Output.Add(msg);

        response.SetIncomplete();

        Assert.That(response.OutputText, Is.EqualTo("Partial output"));
    }

    // ── ComputeOutputText ─────────────────────────────────────

    [Test]
    public void ComputeOutputText_ConcatenatesTextFromOutputMessages()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        response.Output.Add(new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[]
            {
                new MessageContentOutputTextContent("Hello ", Array.Empty<Annotation>(), Array.Empty<LogProb>()),
                new MessageContentOutputTextContent("World", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            }));

        var result = response.ComputeOutputText();

        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void ComputeOutputText_ReturnsEmptyStringForNoTextContent()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");

        var result = response.ComputeOutputText();

        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void ComputeOutputText_IgnoresNonMessageOutputItems()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var fc = new OutputItemFunctionToolCall("call1", "myFunc", "{}");
        fc.Id = "fc_1";
        response.Output.Add(fc);

        var result = response.ComputeOutputText();

        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void ComputeOutputText_ConcatenatesAcrossMultipleMessages()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        response.Output.Add(new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[]
            {
                new MessageContentOutputTextContent("First ", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            }));
        response.Output.Add(new OutputItemMessage(
            "msg_2",
            MessageStatus.Completed,
            new MessageContent[]
            {
                new MessageContentOutputTextContent("Second", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            }));

        var result = response.ComputeOutputText();

        Assert.That(result, Is.EqualTo("First Second"));
    }

    // ── CopyTerminalFields ──────────────────────────────────

    [Test]
    public void CopyTerminalFields_CopiesMutableFieldsExceptStatusAndOutput()
    {
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
            CompletedAt = DateTimeOffset.UtcNow,
            Error = new Models.ResponseErrorInfo(ResponseErrorCode.ServerError, "test"),
            IncompleteDetails = new ResponseIncompleteDetails { Reason = ResponseIncompleteDetailsReason.MaxOutputTokens },
            Usage = new ResponseUsage(10, new ResponseUsageInputTokensDetails(0), 20, new ResponseUsageOutputTokensDetails(0), 30),
            OutputText = "Hello",
        };

        var target = new Models.ResponseObject("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };

        ResponseMutations.CopyTerminalFields(source, target);

        // Status is NOT copied — managed by the pipeline
        Assert.That(target.Status, Is.EqualTo(ResponseStatus.InProgress));
        Assert.That(target.CompletedAt, Is.EqualTo(source.CompletedAt));
        Assert.That(target.Error, Is.SameAs(source.Error));
        Assert.That(target.IncompleteDetails, Is.SameAs(source.IncompleteDetails));
        Assert.That(target.Usage, Is.SameAs(source.Usage));
        Assert.That(target.OutputText, Is.EqualTo("Hello"));
        // Output is NOT copied — accumulated via output item events
        Assert.That(target.Output, Is.Empty);
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
            OutputText = "test",
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseCreatedEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.That(target.OutputText, Is.Null);
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
            OutputText = "Done",
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o");
        var evt = new ResponseCompletedEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are set — handler must set status via SetCompleted()
        Assert.That(target.Status, Is.Null);
        Assert.That(target.CompletedAt, Is.Null);
        Assert.That(target.OutputText, Is.Null);
    }

    [Test]
    public void UpdateFromEvent_ResponseFailedEvent_IsNoOp()
    {
        // UpdateFromEvent no longer auto-sets terminal status;
        // handler is source of truth. ReplaceResponse handles full replacement (B37).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Failed,
            Error = new Models.ResponseErrorInfo(ResponseErrorCode.ServerError, "Oops"),
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o");
        var evt = new ResponseFailedEvent(0, source);

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
            IncompleteDetails = new ResponseIncompleteDetails { Reason = ResponseIncompleteDetailsReason.MaxOutputTokens },
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o");
        var evt = new ResponseIncompleteEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are set — handler must set status via SetIncomplete()
        Assert.That(target.Status, Is.Null);
        Assert.That(target.IncompleteDetails, Is.Null);
    }

    [Test]
    public void UpdateFromEvent_ResponseQueuedEvent_IsNoOp()
    {
        // With B37 full replacement, UpdateFromEvent is a no-op for response.queued
        // (ReplaceResponse handles the full replacement).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Queued,
            OutputText = "queued",
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseQueuedEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.That(target.OutputText, Is.Null);
    }

    [Test]
    public void UpdateFromEvent_ResponseInProgressEvent_IsNoOp()
    {
        // With B37 full replacement, UpdateFromEvent is a no-op for response.in_progress
        // (ReplaceResponse handles the full replacement).
        var source = new Models.ResponseObject("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
            OutputText = "prog",
        };
        var target = new Models.ResponseObject("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseInProgressEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.That(target.OutputText, Is.Null);
    }

    [Test]
    public void UpdateFromEvent_OutputItemAddedEvent_SetsItemAtIndex()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var item = new OutputItemMessage(
            "msg_1",
            MessageStatus.InProgress,
            Array.Empty<MessageContent>());
        var evt = new ResponseOutputItemAddedEvent(0, 0, item);

        response.UpdateFromEvent(evt);

        XAssert.Single(response.Output);
        Assert.That(response.Output[0], Is.SameAs(item));
    }

    [Test]
    public void UpdateFromEvent_OutputItemDoneEvent_SetsItemAtIndex()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var item = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            Array.Empty<MessageContent>());
        var evt = new ResponseOutputItemDoneEvent(0, 0, item);

        response.UpdateFromEvent(evt);

        XAssert.Single(response.Output);
        Assert.That(response.Output[0], Is.SameAs(item));
    }

    [Test]
    public void UpdateFromEvent_UnrelatedEvent_IsNoOp()
    {
        var response = new Models.ResponseObject("resp_test", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseTextDeltaEvent(0, "item_1", 0, 0, "delta", Array.Empty<ResponseLogProb>());

        response.UpdateFromEvent(evt);

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.InProgress));
        Assert.That(response.Output, Is.Empty);
    }

    // ── SetOutputItemAtIndex ──────────────────────────────────

    [Test]
    public void SetOutputItemAtIndex_PadsListWithNulls()
    {
        var output = new List<OutputItem>();
        var item = new OutputItemMessage(
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
        var item1 = new OutputItemMessage("msg_1", MessageStatus.InProgress, Array.Empty<MessageContent>());
        var item2 = new OutputItemMessage("msg_1", MessageStatus.Completed, Array.Empty<MessageContent>());

        output.SetOutputItemAtIndex(0, item1);
        output.SetOutputItemAtIndex(0, item2);

        XAssert.Single(output);
        Assert.That(output[0], Is.SameAs(item2));
    }
}
