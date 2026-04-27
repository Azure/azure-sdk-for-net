// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

public class SseParserTests
{
    [Test]
    public void Parse_ValidSseBlock_ReturnsSingleEvent()
    {
        var raw = "event: response.created\ndata: {\"type\":\"response.created\"}\n\n";

        var events = SseParser.Parse(raw);

        XAssert.Single(events);
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
        Assert.That(events[0].Data, Is.EqualTo("{\"type\":\"response.created\"}"));
    }

    [Test]
    public void Parse_MultipleBlocks_ReturnsMultipleEvents()
    {
        var raw = "event: response.created\ndata: {\"type\":\"response.created\"}\n\n"
                + "event: response.completed\ndata: {\"type\":\"response.completed\"}\n\n";

        var events = SseParser.Parse(raw);

        Assert.That(events.Count, Is.EqualTo(2));
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
        Assert.That(events[1].EventType, Is.EqualTo("response.completed"));
    }

    [Test]
    public void Parse_KeepAliveComment_IsIgnored()
    {
        var raw = ": keep-alive\n\nevent: response.created\ndata: {\"type\":\"response.created\"}\n\n";

        var events = SseParser.Parse(raw);

        XAssert.Single(events);
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
    }

    [Test]
    public void Parse_EmptyInput_ReturnsEmptyList()
    {
        var events = SseParser.Parse("");

        Assert.That(events, Is.Empty);
    }

    [Test]
    public void Parse_BlockWithoutEventLine_IsSkipped()
    {
        var raw = "data: {\"type\":\"response.created\"}\n\n";

        var events = SseParser.Parse(raw);

        Assert.That(events, Is.Empty);
    }

    [Test]
    public void Parse_BlockWithoutDataLine_IsSkipped()
    {
        var raw = "event: response.created\n\n";

        var events = SseParser.Parse(raw);

        Assert.That(events, Is.Empty);
    }

    [Test]
    public void Parse_MixedEventsAndComments_ExtractsOnlyEvents()
    {
        var raw = "event: response.created\ndata: {\"seq\":1}\n\n"
                + ": keep-alive\n\n"
                + "event: response.completed\ndata: {\"seq\":2}\n\n"
                + ": keep-alive\n\n";

        var events = SseParser.Parse(raw);

        Assert.That(events.Count, Is.EqualTo(2));
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
        Assert.That(events[1].EventType, Is.EqualTo("response.completed"));
    }
}
