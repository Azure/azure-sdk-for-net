// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Responses.Tests;

[TestFixture]
public class ResponsesExceptionFilterTests
{
    [Test]
    public void RecordException_SetsErrorStatus()
    {
        using var activity = new Activity("test").Start();
        var exception = new InvalidOperationException("test error");

        ResponsesExceptionFilter.RecordException(activity, exception);

        Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
        Assert.That(activity.StatusDescription, Is.EqualTo("test error"));
    }

    [Test]
    public void RecordException_SetsErrorTags()
    {
        using var activity = new Activity("test").Start();
        var exception = new InvalidOperationException("test error");

        ResponsesExceptionFilter.RecordException(activity, exception);

        var tags = activity.TagObjects.ToDictionary(t => t.Key, t => t.Value);
        Assert.That(tags["azure.ai.agentserver.responses.error.code"], Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(tags["azure.ai.agentserver.responses.error.message"], Is.EqualTo("test error"));
        Assert.That(tags["error.type"], Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(tags["otel.status_description"], Is.EqualTo("test error"));
    }

    [Test]
    public void RecordException_AddsExceptionEvent()
    {
        using var activity = new Activity("test").Start();
        var exception = new InvalidOperationException("test error");

        ResponsesExceptionFilter.RecordException(activity, exception);

        var events = activity.Events.ToList();
        Assert.That(events, Has.Count.EqualTo(1));
        Assert.That(events[0].Name, Is.EqualTo("exception"));

        var tags = events[0].Tags.ToDictionary(t => t.Key, t => t.Value);
        Assert.That(tags["exception.type"], Is.EqualTo(typeof(InvalidOperationException).FullName));
        Assert.That(tags["exception.message"], Is.EqualTo("test error"));
        Assert.That(tags["exception.stacktrace"], Does.Contain("InvalidOperationException"));
    }

    [Test]
    public void RecordException_WithNullActivity_DoesNotThrow()
    {
        var exception = new InvalidOperationException("should not throw");

        Assert.That(
            () => ResponsesExceptionFilter.RecordException(null, exception),
            Throws.Nothing);
    }

    [Test]
    public void RecordException_WithNullException_DoesNotThrow()
    {
        using var activity = new Activity("test").Start();

        Assert.That(
            () => ResponsesExceptionFilter.RecordException(activity, null),
            Throws.Nothing);

        Assert.That(activity.Status, Is.Not.EqualTo(ActivityStatusCode.Error));
    }

    // --- FormatErrorDetail: must produce an HTTP-header-safe single-line value ---
    // Regression guard for the hosted-deploy crash where the multi-line stack trace
    // from ex.ToString() was written into the x-platform-error-detail header and
    // Kestrel threw "Invalid non-ASCII or control character in header: 0x000A".

    [Test]
    public void FormatErrorDetail_StripsNewlinesAndControlChars()
    {
        // A real exception ToString() is multi-line (message + "\n" + stack trace).
        Exception exception;
        try
        {
            throw new InvalidOperationException("boom\r\nsecond line\tafter tab");
        }
        catch (InvalidOperationException ex)
        {
            exception = ex;
        }

        var detail = ResponsesExceptionFilter.FormatErrorDetail(exception);

        Assert.That(detail, Does.Not.Contain("\n"));
        Assert.That(detail, Does.Not.Contain("\r"));
        Assert.That(detail, Does.Not.Contain("\t"));
        // Every character must be legal in an HTTP header value (visible ASCII or space).
        Assert.That(detail, Is.All.Matches<char>(c => c == ' ' || (c >= (char)0x21 && c <= (char)0x7E)));
        // Diagnostic content is preserved (words survive, only separators change).
        Assert.That(detail, Does.Contain("boom"));
        Assert.That(detail, Does.Contain("second"));
    }

    [Test]
    public void FormatErrorDetail_StripsNonAsciiCharacters()
    {
        var exception = new InvalidOperationException("caf\u00e9 na\u00efve \u2014 emoji \U0001F600");

        var detail = ResponsesExceptionFilter.FormatErrorDetail(exception);

        Assert.That(detail, Is.All.Matches<char>(c => c == ' ' || (c >= (char)0x21 && c <= (char)0x7E)));
        // ASCII fragments survive.
        Assert.That(detail, Does.Contain("na"));
        Assert.That(detail, Does.Contain("emoji"));
    }

    [Test]
    public void FormatErrorDetail_UnwrapsSingleInnerAggregateException()
    {
        var inner = new InvalidOperationException("the real error");
        var aggregate = new AggregateException(inner);

        var detail = ResponsesExceptionFilter.FormatErrorDetail(aggregate);

        Assert.That(detail, Does.Contain("the real error"));
        Assert.That(detail, Does.Not.Contain("\n"));
    }
}
