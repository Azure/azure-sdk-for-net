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
        Assert.AreEqual("response.created", events[0].EventType);
        Assert.AreEqual("{\"type\":\"response.created\"}", events[0].Data);
    }

    [Test]
    public void Parse_MultipleBlocks_ReturnsMultipleEvents()
    {
        var raw = "event: response.created\ndata: {\"type\":\"response.created\"}\n\n"
                + "event: response.completed\ndata: {\"type\":\"response.completed\"}\n\n";

        var events = SseParser.Parse(raw);

        Assert.AreEqual(2, events.Count);
        Assert.AreEqual("response.created", events[0].EventType);
        Assert.AreEqual("response.completed", events[1].EventType);
    }

    [Test]
    public void Parse_KeepAliveComment_IsIgnored()
    {
        var raw = ": keep-alive\n\nevent: response.created\ndata: {\"type\":\"response.created\"}\n\n";

        var events = SseParser.Parse(raw);

        XAssert.Single(events);
        Assert.AreEqual("response.created", events[0].EventType);
    }

    [Test]
    public void Parse_EmptyInput_ReturnsEmptyList()
    {
        var events = SseParser.Parse("");

        Assert.IsEmpty(events);
    }

    [Test]
    public void Parse_BlockWithoutEventLine_IsSkipped()
    {
        var raw = "data: {\"type\":\"response.created\"}\n\n";

        var events = SseParser.Parse(raw);

        Assert.IsEmpty(events);
    }

    [Test]
    public void Parse_BlockWithoutDataLine_IsSkipped()
    {
        var raw = "event: response.created\n\n";

        var events = SseParser.Parse(raw);

        Assert.IsEmpty(events);
    }

    [Test]
    public void Parse_MixedEventsAndComments_ExtractsOnlyEvents()
    {
        var raw = "event: response.created\ndata: {\"seq\":1}\n\n"
                + ": keep-alive\n\n"
                + "event: response.completed\ndata: {\"seq\":2}\n\n"
                + ": keep-alive\n\n";

        var events = SseParser.Parse(raw);

        Assert.AreEqual(2, events.Count);
        Assert.AreEqual("response.created", events[0].EventType);
        Assert.AreEqual("response.completed", events[1].EventType);
    }
}
