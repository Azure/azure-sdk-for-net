// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

/// <summary>
/// Codec-level tests for envelope validation and inbound parsing. The full
/// suite additionally requires in-process WebSocket end-to-end tests exercising
/// activation, output modes, binary rejection, close diagnostics, and tracing.
/// </summary>
public class VoiceProtocolCodecTests
{
    [Test]
    public void DecodeFrameRejectsNonJson()
    {
        Assert.Throws<VoiceBridgeProtocolException>(() => VoiceProtocolCodec.DecodeFrame("not json"));
    }

    [Test]
    public void DecodeFrameRequiresEnvelopeFields()
    {
        var exception = Assert.Throws<VoiceBridgeProtocolException>(() =>
            VoiceProtocolCodec.DecodeFrame("""{"id":"m_1","ts":"2026-07-29T00:00:00.000Z"}"""));
        Assert.That(exception!.Message, Does.Contain("type"));
    }

    [Test]
    public void DecodeFrameAcceptsOpaqueEnvelopeId()
    {
        var decoded = VoiceProtocolCodec.DecodeFrame(
            """{"type":"session.ready","id":"018f4f6e-opaque","ts":"2026-07-29T00:00:00.000Z"}""");

        Assert.That(decoded.GetProperty("id").GetString(), Is.EqualTo("018f4f6e-opaque"));
    }

    [Test]
    public void DecodeFrameRejectsDuplicateObjectKeys()
    {
        var exception = Assert.Throws<VoiceBridgeProtocolException>(() =>
            VoiceProtocolCodec.DecodeFrame("""{"type":"session.ready","id":"m_1","id":"m_2","ts":"2026-07-29T00:00:00.000Z"}"""));
        Assert.That(exception!.Message, Does.Contain("duplicate"));
    }

    [TestCase("NaN")]
    [TestCase("Infinity")]
    [TestCase("1e999")]
    public void DecodeFrameRejectsNonFiniteNumbers(string value)
    {
        var exception = Assert.Throws<VoiceBridgeProtocolException>(() =>
            VoiceProtocolCodec.DecodeFrame($$"""{"type":"future.message","id":"m_1","ts":"2026-07-29T00:00:00.000Z","value":{{value}}}"""));
        Assert.That(exception!.Message, Does.Contain("finite").Or.Contain("JSON"));
    }

    [TestCase("2026-07-29 00:00:00.000Z")]
    [TestCase("2026-07-29T00:00:00.000")]
    [TestCase("2026-07-29T24:00:00.000Z")]
    public void DecodeFrameRejectsTimestampOutsideRfc3339Profile(string timestamp)
    {
        Assert.Throws<VoiceBridgeProtocolException>(() =>
            VoiceProtocolCodec.DecodeFrame($$"""{"type":"future.message","id":"m_1","ts":"{{timestamp}}"}"""));
    }

    [Test]
    public void CanonicalDigestIgnoresObjectKeyOrderButIncludesUnknownFields()
    {
        var first = VoiceProtocolCodec.DecodeFrame(
            """{"type":"future.message","id":"m_1","ts":"2026-07-29T00:00:00.000Z","b":1,"a":2}""");
        var reordered = VoiceProtocolCodec.DecodeFrame(
            """{"a":2,"ts":"2026-07-29T00:00:00.000Z","id":"m_1","b":1,"type":"future.message"}""");
        var changed = VoiceProtocolCodec.DecodeFrame(
            """{"type":"future.message","id":"m_1","ts":"2026-07-29T00:00:00.000Z","b":1,"a":2,"unknown":true}""");

        Assert.Multiple(() =>
        {
            Assert.That(
                VoiceProtocolCodec.ComputeCanonicalDigest(first),
                Is.EqualTo(VoiceProtocolCodec.ComputeCanonicalDigest(reordered)));
            Assert.That(
                VoiceProtocolCodec.ComputeCanonicalDigest(first),
                Is.Not.EqualTo(VoiceProtocolCodec.ComputeCanonicalDigest(changed)));
        });
    }

    [Test]
    public void ParseSessionStartReadsTimeoutsAndReconnect()
    {
        var frame = """
        {
          "type":"session.start","id":"m_1","ts":"2026-07-29T00:00:00.000Z",
          "protocol_version":"1.0","reconnect":false,
          "response_timeouts":{"first_output_ms":5000,"idle_ms":8000,"max_duration_ms":60000}
        }
        """;
        var root = VoiceProtocolCodec.DecodeFrame(frame);
        var start = VoiceProtocolCodec.ParseSessionStart(root);

        Assert.Multiple(() =>
        {
            Assert.That(start.ProtocolVersion, Is.EqualTo("1.0"));
            Assert.That(start.Reconnect, Is.False);
            Assert.That(start.ResponseTimeouts.FirstOutputMs, Is.EqualTo(5000));
            Assert.That(start.ResponseTimeouts.MaxDurationMs, Is.EqualTo(60000));
        });
    }

    [Test]
    public void ParseSessionStartDeeplyFreezesCallerMetadata()
    {
        var frame = """
        {"type":"session.start","id":"m_1","ts":"2026-07-29T00:00:00.000Z",
         "protocol_version":"1.0","reconnect":false,
         "response_timeouts":{"first_output_ms":1,"idle_ms":1,"max_duration_ms":1},
         "caller":{"custom_parameters":{"campaign":"renewals"},"flags":[true,false]}}
        """;

        var start = VoiceProtocolCodec.ParseSessionStart(VoiceProtocolCodec.DecodeFrame(frame));

        Assert.Multiple(() =>
        {
            Assert.That(start.Caller, Is.Not.InstanceOf<Dictionary<string, object?>>());
            Assert.That(start.Caller!["custom_parameters"], Is.AssignableTo<IReadOnlyDictionary<string, object?>>());
            Assert.That(start.Caller["flags"], Is.AssignableTo<IReadOnlyList<object?>>());
        });
    }

    [Test]
    public void ParseSessionStartPreservesLargeCallerInteger()
    {
        var frame = """
        {"type":"session.start","id":"m_1","ts":"2026-07-29T00:00:00.000Z",
         "protocol_version":"1.0","reconnect":false,
         "response_timeouts":{"first_output_ms":1,"idle_ms":1,"max_duration_ms":1},
         "caller":{"custom_parameters":{"order_id":9007199254740993}}}
        """;

        var start = VoiceProtocolCodec.ParseSessionStart(VoiceProtocolCodec.DecodeFrame(frame));
        var customParameters = (IReadOnlyDictionary<string, object?>)start.Caller!["custom_parameters"]!;

        Assert.That(customParameters["order_id"], Is.EqualTo(9007199254740993m));
    }

    [Test]
    public void ParseSessionStartRejectsWrongVersion()
    {
        var frame = """
        {"type":"session.start","id":"m_1","ts":"2026-07-29T00:00:00.000Z",
         "protocol_version":"2.0","reconnect":false,
         "response_timeouts":{"first_output_ms":1,"idle_ms":1,"max_duration_ms":1}}
        """;
        var root = VoiceProtocolCodec.DecodeFrame(frame);
        Assert.Throws<VoiceBridgeProtocolException>(() => VoiceProtocolCodec.ParseSessionStart(root));
    }

    [Test]
    public void ParseSessionStartRejectsNonStringGreeting()
    {
        var root = VoiceProtocolCodec.DecodeFrame(
            """{"type":"session.start","id":"m_1","ts":"2026-07-29T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":1,"max_duration_ms":1},"greeting":42}""");

        Assert.Throws<VoiceBridgeProtocolException>(() => VoiceProtocolCodec.ParseSessionStart(root));
    }

    [Test]
    public void ParseSessionStartAcceptsExplicitNullCaller()
    {
        var root = VoiceProtocolCodec.DecodeFrame(
            """{"type":"session.start","id":"m_1","ts":"2026-07-29T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":1,"max_duration_ms":1},"caller":null}""");

        Assert.That(VoiceProtocolCodec.ParseSessionStart(root).Caller, Is.Null);
    }

    [Test]
    public void ParseUserMessagePreservesOrderedTextParts()
    {
        var frame = """
        {"type":"user.message","id":"m_2","ts":"2026-07-29T00:00:00.000Z",
         "item_id":"in_1",
         "content":[{"type":"input_text","text":"hello"},{"type":"input_text","text":"world"}]}
        """;
        var root = VoiceProtocolCodec.DecodeFrame(frame);
        var message = VoiceProtocolCodec.ParseUserMessage(root);

        Assert.Multiple(() =>
        {
            Assert.That(message.ItemId, Is.EqualTo("in_1"));
            Assert.That(message.Content, Has.Count.EqualTo(2));
            Assert.That(message.Text, Is.EqualTo("hello world"));
        });
    }

    [Test]
    public void ParseUserMessageSkipsUnknownContentParts()
    {
        var frame = """
        {"type":"user.message","id":"m_2","ts":"2026-07-29T00:00:00.000Z",
         "item_id":"in_1","content":[{"type":"future_part","value":"ignored"}]}
        """;
        var root = VoiceProtocolCodec.DecodeFrame(frame);

        var message = VoiceProtocolCodec.ParseUserMessage(root);

        Assert.That(message.Content, Is.Empty);
    }

    [Test]
    public void ParseResponseTimeoutRequiresExactlyOneTarget()
    {
        var neither = VoiceProtocolCodec.DecodeFrame(
            """{"type":"response.timeout","id":"m_3","ts":"2026-07-29T00:00:00.000Z","stage":"idle"}""");
        var both = VoiceProtocolCodec.DecodeFrame(
            """{"type":"response.timeout","id":"m_4","ts":"2026-07-29T00:00:00.000Z","stage":"idle","response_id":"r_1","item_ids":["in_1"]}""");

        Assert.Multiple(() =>
        {
            Assert.Throws<VoiceBridgeProtocolException>(() => VoiceProtocolCodec.ParseResponseTimeout(neither));
            Assert.Throws<VoiceBridgeProtocolException>(() => VoiceProtocolCodec.ParseResponseTimeout(both));
        });
    }

    [Test]
    public void ParseResponseTimeoutTreatsExplicitNullAsPresent()
    {
        var root = VoiceProtocolCodec.DecodeFrame(
            """{"type":"response.timeout","id":"m_4","ts":"2026-07-29T00:00:00.000Z","stage":"idle","response_id":null,"item_ids":["in_1"]}""");

        Assert.Throws<VoiceBridgeProtocolException>(() => VoiceProtocolCodec.ParseResponseTimeout(root));
    }

    [Test]
    public void ParseResponseTimeoutPreservesOrderedInputBatch()
    {
        var root = VoiceProtocolCodec.DecodeFrame(
            """{"type":"response.timeout","id":"m_3","ts":"2026-07-29T00:00:00.000Z","stage":"first_output","item_ids":["in_1","in_2"]}""");

        var timeout = VoiceProtocolCodec.ParseResponseTimeout(root);

        Assert.Multiple(() =>
        {
            Assert.That(timeout.ResponseId, Is.Null);
            Assert.That(timeout.ItemIds, Is.EqualTo(new[] { "in_1", "in_2" }));
            Assert.That(timeout.Stage, Is.EqualTo("first_output"));
        });
    }

    [Test]
    public void ParsePlaybackTerminalRequiresMatchingIdNamespaces()
    {
        var root = VoiceProtocolCodec.DecodeFrame(
            """{"type":"barge_in","id":"m_7","ts":"2026-07-29T00:00:00.000Z","response_id":"r_1","item_id":"in_wrong","heard_text":"heard"}""");

        Assert.Throws<VoiceBridgeProtocolException>(() => VoiceProtocolCodec.ParseBargeIn(root));
    }
}
