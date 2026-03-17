using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public class ResponseMutationsTests
{
    // ── SetCompleted ──────────────────────────────────────────

    [Test]
    public void SetCompleted_SetsStatusToCompleted()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetCompleted();

        Assert.AreEqual(ResponseStatus.Completed, response.Status);
    }

    [Test]
    public void SetCompleted_SetsCompletedAt()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var before = DateTimeOffset.UtcNow;

        response.SetCompleted();

        Assert.IsNotNull(response.CompletedAt);
        XAssert.InRange(response.CompletedAt.Value, before, DateTimeOffset.UtcNow.AddSeconds(1));
    }

    [Test]
    public void SetCompleted_WithUsage_SetsUsage()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var usage = new ResponseUsage(10, new ResponseUsageInputTokensDetails(0), 20, new ResponseUsageOutputTokensDetails(0), 30);

        response.SetCompleted(usage);

        Assert.AreSame(usage, response.Usage);
    }

    [Test]
    public void SetCompleted_WithoutUsage_LeavesUsageNull()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetCompleted();

        Assert.IsNull(response.Usage);
    }

    [Test]
    public void SetCompleted_ComputesOutputText()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var msg = new OutputItemOutputMessage(
            "msg_1",
            new OutputMessageContent[]
            {
                new OutputMessageContentOutputTextContent("Hello ", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            },
            OutputItemOutputMessageStatus.Completed);
        response.Output.Add(msg);

        response.SetCompleted();

        Assert.AreEqual("Hello ", response.OutputText);
    }

    // ── SetFailed ─────────────────────────────────────────────

    [Test]
    public void SetFailed_SetsStatusToFailed()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetFailed();

        Assert.AreEqual(ResponseStatus.Failed, response.Status);
    }

    [Test]
    public void SetFailed_SetsErrorCodeAndMessage()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetFailed(ResponseErrorCode.RateLimitExceeded, "Too many requests");

        Assert.IsNotNull(response.Error);
        Assert.AreEqual(ResponseErrorCode.RateLimitExceeded, response.Error.Code);
        Assert.AreEqual("Too many requests", response.Error.Message);
    }

    [Test]
    public void SetFailed_WithDefaults_UsesServerErrorAndDefaultMessage()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetFailed();

        Assert.IsNotNull(response.Error);
        Assert.AreEqual(ResponseErrorCode.ServerError, response.Error.Code);
        Assert.AreEqual("An internal server error occurred.", response.Error.Message);
    }

    [Test]
    public void SetFailed_DoesNotSetCompletedAt()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetFailed();

        Assert.IsNull(response.CompletedAt);
    }

    [Test]
    public void SetFailed_WithException_MapsResponsesApiExceptionWithFidelity()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var error = new Error("rate_limit_exceeded", "Rate limit hit", null!, "server_error", null!, null!, null!, null!);
        var ex = new ResponsesApiException(error, 429);

        response.SetFailed(ex);

        Assert.IsNotNull(response.Error);
        Assert.AreEqual(ResponseErrorCode.RateLimitExceeded, response.Error.Code);
        Assert.AreEqual("Rate limit hit", response.Error.Message);
        Assert.AreEqual(ResponseStatus.Failed, response.Status);
    }

    [Test]
    public void SetFailed_WithException_MapsBadRequestExceptionMessage()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var ex = new BadRequestException("Model not supported");

        response.SetFailed(ex);

        Assert.IsNotNull(response.Error);
        Assert.AreEqual(ResponseErrorCode.ServerError, response.Error.Code);
        Assert.AreEqual("Model not supported", response.Error.Message);
    }

    [Test]
    public void SetFailed_WithException_MapsGenericExceptionToGenericMessage()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var ex = new InvalidOperationException("Internal stack trace details");

        response.SetFailed(ex);

        Assert.IsNotNull(response.Error);
        Assert.AreEqual(ResponseErrorCode.ServerError, response.Error.Code);
        Assert.AreEqual(ApiErrorFactory.GenericServerErrorMessage, response.Error.Message);
    }

    [Test]
    public void SetFailed_WithUsage_SetsUsage()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var usage = new ResponseUsage(5, new ResponseUsageInputTokensDetails(0), 10, new ResponseUsageOutputTokensDetails(0), 15);

        response.SetFailed(usage: usage);

        Assert.AreSame(usage, response.Usage);
    }

    [Test]
    public void SetFailed_ComputesOutputText()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var msg = new OutputItemOutputMessage(
            "msg_1",
            new OutputMessageContent[]
            {
                new OutputMessageContentOutputTextContent("Partial", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            },
            OutputItemOutputMessageStatus.Completed);
        response.Output.Add(msg);

        response.SetFailed();

        Assert.AreEqual("Partial", response.OutputText);
    }

    // ── SetIncomplete ─────────────────────────────────────────

    [Test]
    public void SetIncomplete_SetsStatusToIncomplete()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetIncomplete();

        Assert.AreEqual(ResponseStatus.Incomplete, response.Status);
    }

    [Test]
    public void SetIncomplete_WithReason_SetsIncompleteDetails()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);

        Assert.IsNotNull(response.IncompleteDetails);
        Assert.AreEqual(ResponseIncompleteDetailsReason.MaxOutputTokens, response.IncompleteDetails.Reason);
    }

    [Test]
    public void SetIncomplete_WithoutReason_LeavesIncompleteDetailsNull()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetIncomplete();

        Assert.IsNull(response.IncompleteDetails);
    }

    [Test]
    public void SetIncomplete_DoesNotSetCompletedAt()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        response.SetIncomplete();

        Assert.IsNull(response.CompletedAt);
    }

    [Test]
    public void SetIncomplete_WithUsage_SetsUsage()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var usage = new ResponseUsage(5, new ResponseUsageInputTokensDetails(0), 3, new ResponseUsageOutputTokensDetails(0), 8);

        response.SetIncomplete(usage: usage);

        Assert.AreSame(usage, response.Usage);
    }

    [Test]
    public void SetIncomplete_ComputesOutputText()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var msg = new OutputItemOutputMessage(
            "msg_1",
            new OutputMessageContent[]
            {
                new OutputMessageContentOutputTextContent("Partial output", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            },
            OutputItemOutputMessageStatus.Completed);
        response.Output.Add(msg);

        response.SetIncomplete();

        Assert.AreEqual("Partial output", response.OutputText);
    }

    // ── ComputeOutputText ─────────────────────────────────────

    [Test]
    public void ComputeOutputText_ConcatenatesTextFromOutputMessages()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        response.Output.Add(new OutputItemOutputMessage(
            "msg_1",
            new OutputMessageContent[]
            {
                new OutputMessageContentOutputTextContent("Hello ", Array.Empty<Annotation>(), Array.Empty<LogProb>()),
                new OutputMessageContentOutputTextContent("World", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            },
            OutputItemOutputMessageStatus.Completed));

        var result = response.ComputeOutputText();

        Assert.AreEqual("Hello World", result);
    }

    [Test]
    public void ComputeOutputText_ReturnsEmptyStringForNoTextContent()
    {
        var response = new Models.Response("resp_test", "gpt-4o");

        var result = response.ComputeOutputText();

        Assert.AreEqual("", result);
    }

    [Test]
    public void ComputeOutputText_IgnoresNonMessageOutputItems()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var fc = new OutputItemFunctionToolCall("call1", "myFunc", "{}");
        fc.Id = "fc_1";
        response.Output.Add(fc);

        var result = response.ComputeOutputText();

        Assert.AreEqual("", result);
    }

    [Test]
    public void ComputeOutputText_ConcatenatesAcrossMultipleMessages()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        response.Output.Add(new OutputItemOutputMessage(
            "msg_1",
            new OutputMessageContent[]
            {
                new OutputMessageContentOutputTextContent("First ", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            },
            OutputItemOutputMessageStatus.Completed));
        response.Output.Add(new OutputItemOutputMessage(
            "msg_2",
            new OutputMessageContent[]
            {
                new OutputMessageContentOutputTextContent("Second", Array.Empty<Annotation>(), Array.Empty<LogProb>())
            },
            OutputItemOutputMessageStatus.Completed));

        var result = response.ComputeOutputText();

        Assert.AreEqual("First Second", result);
    }

    // ── CopyTerminalFields ──────────────────────────────────

    [Test]
    public void CopyTerminalFields_CopiesMutableFieldsExceptStatusAndOutput()
    {
        var source = new Models.Response("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
            CompletedAt = DateTimeOffset.UtcNow,
            Error = new Models.ResponseError(ResponseErrorCode.ServerError, "test"),
            IncompleteDetails = new ResponseIncompleteDetails { Reason = ResponseIncompleteDetailsReason.MaxOutputTokens },
            Usage = new ResponseUsage(10, new ResponseUsageInputTokensDetails(0), 20, new ResponseUsageOutputTokensDetails(0), 30),
            OutputText = "Hello",
        };

        var target = new Models.Response("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };

        ResponseMutations.CopyTerminalFields(source, target);

        // Status is NOT copied — managed by the pipeline
        Assert.AreEqual(ResponseStatus.InProgress, target.Status);
        Assert.AreEqual(source.CompletedAt, target.CompletedAt);
        Assert.AreSame(source.Error, target.Error);
        Assert.AreSame(source.IncompleteDetails, target.IncompleteDetails);
        Assert.AreSame(source.Usage, target.Usage);
        Assert.AreEqual("Hello", target.OutputText);
        // Output is NOT copied — accumulated via output item events
        Assert.IsEmpty(target.Output);
    }

    // ── UpdateFromEvent ───────────────────────────────────────

    [Test]
    public void UpdateFromEvent_ResponseCreatedEvent_IsNoOp()
    {
        // With B37 full replacement, UpdateFromEvent is a no-op for response.created
        // (ReplaceResponse handles the full replacement).
        var source = new Models.Response("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
            OutputText = "test",
        };
        var target = new Models.Response("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseCreatedEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.IsNull(target.OutputText);
    }

    [Test]
    public void UpdateFromEvent_ResponseCompletedEvent_IsNoOp()
    {
        // UpdateFromEvent no longer auto-sets terminal status;
        // handler is source of truth. ReplaceResponse handles full replacement (B37).
        var source = new Models.Response("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Completed,
            CompletedAt = DateTimeOffset.UtcNow,
            OutputText = "Done",
        };
        var target = new Models.Response("resp_tgt", "gpt-4o");
        var evt = new ResponseCompletedEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are set — handler must set status via SetCompleted()
        Assert.IsNull(target.Status);
        Assert.IsNull(target.CompletedAt);
        Assert.IsNull(target.OutputText);
    }

    [Test]
    public void UpdateFromEvent_ResponseFailedEvent_IsNoOp()
    {
        // UpdateFromEvent no longer auto-sets terminal status;
        // handler is source of truth. ReplaceResponse handles full replacement (B37).
        var source = new Models.Response("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Failed,
            Error = new Models.ResponseError(ResponseErrorCode.ServerError, "Oops"),
        };
        var target = new Models.Response("resp_tgt", "gpt-4o");
        var evt = new ResponseFailedEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are set — handler must set status via SetFailed()
        Assert.IsNull(target.Status);
        Assert.IsNull(target.Error);
    }

    [Test]
    public void UpdateFromEvent_ResponseIncompleteEvent_IsNoOp()
    {
        // UpdateFromEvent no longer auto-sets terminal status;
        // handler is source of truth. ReplaceResponse handles full replacement (B37).
        var source = new Models.Response("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Incomplete,
            IncompleteDetails = new ResponseIncompleteDetails { Reason = ResponseIncompleteDetailsReason.MaxOutputTokens },
        };
        var target = new Models.Response("resp_tgt", "gpt-4o");
        var evt = new ResponseIncompleteEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are set — handler must set status via SetIncomplete()
        Assert.IsNull(target.Status);
        Assert.IsNull(target.IncompleteDetails);
    }

    [Test]
    public void UpdateFromEvent_ResponseQueuedEvent_IsNoOp()
    {
        // With B37 full replacement, UpdateFromEvent is a no-op for response.queued
        // (ReplaceResponse handles the full replacement).
        var source = new Models.Response("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.Queued,
            OutputText = "queued",
        };
        var target = new Models.Response("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseQueuedEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.IsNull(target.OutputText);
    }

    [Test]
    public void UpdateFromEvent_ResponseInProgressEvent_IsNoOp()
    {
        // With B37 full replacement, UpdateFromEvent is a no-op for response.in_progress
        // (ReplaceResponse handles the full replacement).
        var source = new Models.Response("resp_src", "gpt-4o")
        {
            Status = ResponseStatus.InProgress,
            OutputText = "prog",
        };
        var target = new Models.Response("resp_tgt", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseInProgressEvent(0, source);

        target.UpdateFromEvent(evt);

        // No fields are copied — ReplaceResponse handles full replacement
        Assert.IsNull(target.OutputText);
    }

    [Test]
    public void UpdateFromEvent_OutputItemAddedEvent_SetsItemAtIndex()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var item = new OutputItemOutputMessage(
            "msg_1",
            Array.Empty<OutputMessageContent>(),
            OutputItemOutputMessageStatus.InProgress);
        var evt = new ResponseOutputItemAddedEvent(0, 0, item);

        response.UpdateFromEvent(evt);

        XAssert.Single(response.Output);
        Assert.AreSame(item, response.Output[0]);
    }

    [Test]
    public void UpdateFromEvent_OutputItemDoneEvent_SetsItemAtIndex()
    {
        var response = new Models.Response("resp_test", "gpt-4o");
        var item = new OutputItemOutputMessage(
            "msg_1",
            Array.Empty<OutputMessageContent>(),
            OutputItemOutputMessageStatus.Completed);
        var evt = new ResponseOutputItemDoneEvent(0, 0, item);

        response.UpdateFromEvent(evt);

        XAssert.Single(response.Output);
        Assert.AreSame(item, response.Output[0]);
    }

    [Test]
    public void UpdateFromEvent_UnrelatedEvent_IsNoOp()
    {
        var response = new Models.Response("resp_test", "gpt-4o") { Status = ResponseStatus.InProgress };
        var evt = new ResponseTextDeltaEvent(0, "item_1", 0, 0, "delta", Array.Empty<ResponseLogProb>());

        response.UpdateFromEvent(evt);

        Assert.AreEqual(ResponseStatus.InProgress, response.Status);
        Assert.IsEmpty(response.Output);
    }

    // ── SetOutputItemAtIndex ──────────────────────────────────

    [Test]
    public void SetOutputItemAtIndex_PadsListWithNulls()
    {
        var output = new List<OutputItem>();
        var item = new OutputItemOutputMessage(
            "msg_1",
            Array.Empty<OutputMessageContent>(),
            OutputItemOutputMessageStatus.Completed);

        output.SetOutputItemAtIndex(2, item);

        Assert.AreEqual(3, output.Count);
        Assert.IsNull(output[0]);
        Assert.IsNull(output[1]);
        Assert.AreSame(item, output[2]);
    }

    [Test]
    public void SetOutputItemAtIndex_ReplacesExistingItem()
    {
        var output = new List<OutputItem>();
        var item1 = new OutputItemOutputMessage("msg_1", Array.Empty<OutputMessageContent>(), OutputItemOutputMessageStatus.InProgress);
        var item2 = new OutputItemOutputMessage("msg_1", Array.Empty<OutputMessageContent>(), OutputItemOutputMessageStatus.Completed);

        output.SetOutputItemAtIndex(0, item1);
        output.SetOutputItemAtIndex(0, item2);

        XAssert.Single(output);
        Assert.AreSame(item2, output[0]);
    }
}
