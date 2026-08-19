// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Voice;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceCodecTests
{
    private static readonly DateTimeOffset Timestamp =
        DateTimeOffset.Parse("2026-08-13T00:00:00.000Z", System.Globalization.CultureInfo.InvariantCulture);

    private static IEnumerable<TestCaseData> InboundMessages()
    {
        yield return Inbound("session.start", """
            {"protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
            """, typeof(VoiceSessionStartEvent));
        yield return Inbound("user.message", """
            {"item_id":"in_1","content":[{"type":"input_text","text":"hello"}]}
            """, typeof(VoiceUserMessageEvent));
        yield return Inbound("user.no_input", """{"item_id":"in_2","count":1}""", typeof(VoiceUserNoInputEvent));
        yield return Inbound("user.speech_started", "{}", typeof(VoiceUserSpeechStartedEvent));
        yield return Inbound("barge_in", """{"response_id":"r_1","item_id":"it_1","heard_text":"heard"}""", typeof(VoiceBargeInEvent));
        yield return Inbound("response.accepted", """{"response_id":"r_2"}""", typeof(VoiceResponseAcceptedEvent));
        yield return Inbound("response.dropped", """{"response_id":"r_3","reason":"queue_full"}""", typeof(VoiceResponseDroppedEvent));
        yield return Inbound("response.cancelled", """{"response_id":"r_4","heard_text":"heard"}""", typeof(VoiceResponseCancelledEvent));
        yield return Inbound("response.timeout", """{"item_ids":["in_3"],"stage":"first_output"}""", typeof(VoiceResponseTimeoutEvent));
        yield return Inbound("session.end", """{"reason":"caller_hangup"}""", typeof(VoiceSessionEndEvent));
    }

    private static TestCaseData Inbound(string type, string fields, Type expectedType)
    {
        var inner = fields.Trim();
        var suffix = inner == "{}" ? string.Empty : $",{inner[1..^1]}";
        var frame = $$"""{"type":"{{type}}","id":"m_1","ts":"2026-08-13T00:00:00.000Z"{{suffix}}}""";
        return new TestCaseData(frame, expectedType).SetName($"Decode_{type}");
    }

    [TestCaseSource(nameof(InboundMessages))]
    public void DecodeSelectedInboundMessages(string frame, Type expectedType)
    {
        var message = VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame));

        Assert.Multiple(() =>
        {
            Assert.That(message, Is.TypeOf(expectedType));
            Assert.That(message!.Id, Is.EqualTo("m_1"));
            Assert.That(message.Timestamp, Is.EqualTo(Timestamp));
        });
    }

    private static IEnumerable<VoiceOutboundMessage> OutboundMessages()
    {
        yield return new VoiceSessionReadyMessage("m_1", Timestamp);
        yield return new VoiceSessionRejectedMessage("startup_failed", retriable: false, id: "m_1", timestamp: Timestamp);
        yield return new VoiceResponseCreatedMessage("r_1", new[] { "in_1" }, id: "m_1", timestamp: Timestamp);
        yield return new VoiceResponseNoneMessage(new[] { "in_1" }, id: "m_1", timestamp: Timestamp);
        yield return new VoiceResponseOutputTextDeltaMessage("r_1", "it_1", "hel", id: "m_1", timestamp: Timestamp);
        yield return new VoiceResponseOutputTextDoneMessage("r_1", "it_1", "hello", id: "m_1", timestamp: Timestamp);
        yield return new VoiceResponseDoneMessage("r_1", id: "m_1", timestamp: Timestamp);
        yield return new VoiceResponseCancelMessage("r_1", id: "m_1", timestamp: Timestamp);
        yield return new VoiceEndCallMessage("completed", VoiceEndCallMode.Drain, id: "m_1", timestamp: Timestamp);
        yield return new VoiceErrorMessage("backend_error", "failed", id: "m_1", timestamp: Timestamp);
    }

    [TestCaseSource(nameof(OutboundMessages))]
    public void EncodeSelectedOutboundMessages(VoiceOutboundMessage message)
    {
        using var payload = JsonDocument.Parse(VoiceProtocolCodec.Encode(message));

        Assert.Multiple(() =>
        {
            Assert.That(payload.RootElement.GetProperty("type").GetString(), Is.EqualTo(message.MessageType));
            Assert.That(payload.RootElement.GetProperty("id").GetString(), Is.EqualTo("m_1"));
            Assert.That(payload.RootElement.GetProperty("ts").GetString(), Is.EqualTo("2026-08-13T00:00:00.0000000Z"));
        });
    }

    [Test]
    public void CodecRetainsNoMessageIdState()
    {
        var frame = Frame("session.end", "\"reason\":\"caller_hangup\"");

        var first = VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame));
        var second = VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame));

        Assert.Multiple(() =>
        {
            Assert.That(first, Is.TypeOf<VoiceSessionEndEvent>());
            Assert.That(second, Is.TypeOf<VoiceSessionEndEvent>());
            Assert.That(second, Is.Not.SameAs(first));
        });
    }

    [Test]
    public void UnknownFutureTopLevelTypeIsIgnored()
    {
        Assert.That(
            VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(Frame("future.message", "\"value\":1"))),
            Is.Null);
    }

    [Test]
    public void UnknownFutureMessageAcceptsDeepAdditiveJsonWithinFrameLimit()
    {
        var nested = new string('[', 128) + new string(']', 128);
        var frame = Frame("future.message", $"\"value\":{nested}");

        Assert.That(
            VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame)),
            Is.Null);
    }

    [Test]
    public void UnknownFutureMessageAcceptsLargeExponentNumber()
    {
        var frame = Frame("future.message", "\"value\":1e999");

        Assert.That(
            VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame)),
            Is.Null);
    }

    [TestCase("conversation.item.create")]
    [TestCase("conversation.item.delete")]
    [TestCase("dtmf")]
    [TestCase("dtmf.collect.cancelled")]
    [TestCase("dtmf.collect.rejected")]
    [TestCase("handoff.failed")]
    [TestCase("conversation.item.created")]
    [TestCase("conversation.item.deleted")]
    [TestCase("conversation.item.failed")]
    [TestCase("handoff")]
    [TestCase("dtmf.collect")]
    [TestCase("dtmf.collect.cancel")]
    public void KnownExcludedFamilyFailsLoud(string type)
    {
        var exception = Assert.Throws<VoiceProtocolException>(() =>
            VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(Frame(type, string.Empty))));

        Assert.That(exception!.CloseCode, Is.EqualTo(1003));
    }

    [Test]
    public void AgentToBridgeTypeReceivedInboundIsProtocolError()
    {
        var exception = Assert.Throws<VoiceProtocolException>(() =>
            VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(Frame("response.done", "\"response_id\":\"r_1\""))));

        Assert.That(exception!.CloseCode, Is.EqualTo(1002));
    }

    [Test]
    public void UnknownContentPartIsSkippedButInputImageFailsLoud()
    {
        var supported = VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(Frame(
            "user.message",
            "\"item_id\":\"in_1\",\"content\":[{\"type\":\"future_part\"},{\"type\":\"input_text\",\"text\":\"hello\"}]")));
        var ignored = VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(Frame(
            "user.message",
            "\"item_id\":\"in_1\",\"content\":[{\"type\":\"future_part\"}]")));
        var exception = Assert.Throws<VoiceProtocolException>(() => VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(Frame(
            "user.message",
            "\"item_id\":\"in_1\",\"content\":[{\"type\":\"input_image\",\"image_ref\":\"https://example.test/i\",\"mime_type\":\"image/png\"}]"))));

        Assert.Multiple(() =>
        {
            Assert.That(((VoiceUserMessageEvent)supported!).Content, Has.Count.EqualTo(1));
            Assert.That(ignored, Is.Null);
            Assert.That(exception!.CloseCode, Is.EqualTo(1003));
        });
    }

    [TestCase("[]")]
    [TestCase("{\"type\":\"session.end\",\"type\":\"session.end\",\"id\":\"m_1\",\"ts\":\"2026-08-13T00:00:00Z\",\"reason\":\"done\"}")]
    [TestCase("{\"type\":\"session.end\",\"id\":\"m_1\",\"ts\":\"٢٠٢٦-08-13T00:00:00Z\",\"reason\":\"done\"}")]
    [TestCase("{\"type\":\"session.start\",\"id\":\"m_1\",\"ts\":\"2026-08-13T00:00:00Z\",\"protocol_version\":\"1.0\",\"reconnect\":true,\"greeting\":null,\"response_timeouts\":{\"first_output_ms\":1,\"idle_ms\":2,\"max_duration_ms\":3}}")]
    [TestCase("{\"type\":\"response.timeout\",\"id\":\"m_1\",\"ts\":\"2026-08-13T00:00:00Z\",\"response_id\":\"r_1\",\"item_ids\":[\"in_1\"],\"stage\":\"idle\"}")]
    public void InvalidInboundShapeIsRejected(string frame)
    {
        Assert.That(
            () => VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame)),
            Throws.TypeOf<VoiceProtocolException>());
    }

    [Test]
    public void ResponseTimeoutItemIdsRejectWrongPrefixAsProtocolError()
    {
        var validFrame = Frame(
            "response.timeout",
            "\"item_ids\":[\"in_1\"],\"stage\":\"first_output\"");
        var invalidFrame = Frame(
            "response.timeout",
            "\"item_ids\":[\"bad\"],\"stage\":\"first_output\"");

        var valid = (VoiceResponseTimeoutEvent)VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(validFrame))!;
        var exception = Assert.Throws<VoiceProtocolException>(() =>
            VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(invalidFrame)));
        var retry = (VoiceResponseTimeoutEvent)VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(validFrame))!;

        Assert.Multiple(() =>
        {
            Assert.That(valid.ItemIds, Is.EqualTo(new[] { "in_1" }));
            Assert.That(exception!.CloseCode, Is.EqualTo(1002));
            Assert.That(retry.ItemIds, Is.EqualTo(new[] { "in_1" }));
        });
    }

    [Test]
    public void InvalidUnicodeObjectKeyIsRejected()
    {
        var frame = Frame(
            "session.start",
            "\"protocol_version\":\"1.0\",\"reconnect\":false,\"response_timeouts\":{\"first_output_ms\":1,\"idle_ms\":2,\"max_duration_ms\":3},\"caller\":{\"\\ud800\":\"value\"}");

        Assert.That(
            () => VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame)),
            Throws.TypeOf<VoiceProtocolException>());
    }

    [Test]
    public void CallerContextRejectsCredentialFields()
    {
        var frame = Frame(
            "session.start",
            "\"protocol_version\":\"1.0\",\"reconnect\":false,\"response_timeouts\":{\"first_output_ms\":1,\"idle_ms\":2,\"max_duration_ms\":3},\"caller\":{\"custom_parameters\":{\"api_key\":\"secret\"}}");

        Assert.That(
            () => VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame)),
            Throws.TypeOf<VoiceProtocolException>());
    }

    [TestCase("APIKey")]
    [TestCase("API_KEY")]
    [TestCase("CREDENTIAL")]
    public void CallerContextRejectsCredentialAcronyms(string fieldName)
    {
        var frame = Frame(
            "session.start",
            $"\"protocol_version\":\"1.0\",\"reconnect\":false,\"response_timeouts\":{{\"first_output_ms\":1,\"idle_ms\":2,\"max_duration_ms\":3}},\"caller\":{{\"{fieldName}\":\"secret\"}}");

        Assert.That(
            () => VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame)),
            Throws.TypeOf<VoiceProtocolException>());
    }

    [TestCase("\"channel\":42")]
    [TestCase("\"ani\":false")]
    [TestCase("\"dnis\":[]")]
    [TestCase("\"customer_id\":{}")]
    [TestCase("\"custom_parameters\":[]")]
    public void CallerKnownFieldsValidateShape(string callerFields)
    {
        var frame = Frame(
            "session.start",
            $"\"protocol_version\":\"1.0\",\"reconnect\":false,\"response_timeouts\":{{\"first_output_ms\":1,\"idle_ms\":2,\"max_duration_ms\":3}},\"caller\":{{{callerFields}}}");

        Assert.That(
            () => VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame)),
            Throws.TypeOf<VoiceProtocolException>());
    }

    [Test]
    public void CallerUnknownFieldsRemainAvailable()
    {
        var frame = Frame(
            "session.start",
            "\"protocol_version\":\"1.0\",\"reconnect\":false,\"response_timeouts\":{\"first_output_ms\":1,\"idle_ms\":2,\"max_duration_ms\":3},\"caller\":{\"future_context\":{\"value\":1}}");

        var start = (VoiceSessionStartEvent)VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(frame))!;
        using var caller = JsonDocument.Parse(start.Caller!);

        Assert.That(caller.RootElement.GetProperty("future_context").GetProperty("value").GetInt32(), Is.EqualTo(1));
    }

    [Test]
    public void ProactiveAdmissionTimeoutEnforcesProtocolMaximum()
    {
        Assert.DoesNotThrow(() => VoiceProtocolCodec.Encode(
            new VoiceResponseCreatedMessage("r_1", admissionTimeoutMs: 60000)));
        Assert.That(
            () => VoiceProtocolCodec.Encode(new VoiceResponseCreatedMessage("r_1", admissionTimeoutMs: 60001)),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void ConditionalOutboundFieldsAreValidatedContextFree()
    {
        Assert.That(
            () => VoiceProtocolCodec.Encode(new VoiceResponseCreatedMessage(
                "r_1",
                new[] { "in_1" },
                admissionTimeoutMs: 1)),
            Throws.TypeOf<ArgumentException>());
        Assert.That(
            () => VoiceProtocolCodec.Encode(new VoiceErrorMessage(
                "error",
                "failed",
                itemId: "it_1")),
            Throws.TypeOf<ArgumentException>());
        Assert.DoesNotThrow(() => VoiceProtocolCodec.Encode(new VoiceResponseDoneMessage("r_not_opened_here")));
    }

    [Test]
    public void CollectionsAreDefensivelyCopiedAndRepresentationsAreContentFree()
    {
        var inputIds = new List<string> { "in_1" };
        var created = new VoiceResponseCreatedMessage("r_1", inputIds);
        inputIds[0] = "in_changed";
        var user = (VoiceUserMessageEvent)VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(Frame(
            "user.message",
            "\"item_id\":\"in_1\",\"content\":[{\"type\":\"input_text\",\"text\":\"customer-secret\"}]")))!;

        Assert.Multiple(() =>
        {
            Assert.That(created.InReplyTo, Is.EqualTo(new[] { "in_1" }));
            Assert.That(created.InReplyTo, Is.Not.InstanceOf<string[]>());
            Assert.That(user.ToString(), Does.Not.Contain("customer-secret"));
            Assert.That(new VoiceErrorMessage("error", "customer-secret").ToString(), Does.Not.Contain("customer-secret"));
        });
    }

    [Test]
    public void VoiceConfigurationIsCopiedAndAliasIsNormalized()
    {
        var voice = BinaryData.FromString("""{"type":"azure-platform","name":"en-US-Ava"}""");
        var message = new VoiceResponseOutputTextDoneMessage("r_1", "it_1", "hello", voice);

        using var payload = JsonDocument.Parse(VoiceProtocolCodec.Encode(message));

        Assert.That(payload.RootElement.GetProperty("voice").GetProperty("type").GetString(), Is.EqualTo("azure-standard"));
    }

    [Test]
    public void VoicePatchAcceptsSynthesisStringFields()
    {
        var message = new VoiceResponseOutputTextDoneMessage(
            "r_1",
            "it_1",
            "hello",
            BinaryData.FromString("""
                {"locale":"en-US","style":"cheerful","pitch":"+5Hz","rate":"+10%","volume":"-2dB"}
                """));

        using var payload = JsonDocument.Parse(VoiceProtocolCodec.Encode(message));

        Assert.Multiple(() =>
        {
            var voice = payload.RootElement.GetProperty("voice");
            Assert.That(voice.GetProperty("locale").GetString(), Is.EqualTo("en-US"));
            Assert.That(voice.GetProperty("style").GetString(), Is.EqualTo("cheerful"));
            Assert.That(voice.GetProperty("pitch").GetString(), Is.EqualTo("+5Hz"));
            Assert.That(voice.GetProperty("rate").GetString(), Is.EqualTo("+10%"));
            Assert.That(voice.GetProperty("volume").GetString(), Is.EqualTo("-2dB"));
        });
    }

    [TestCase("{\"temperature\":2}")]
    [TestCase("{\"temperature\":\"hot\"}")]
    [TestCase("{\"prefer_locales\":\"en-US\"}")]
    [TestCase("{\"prefer_locales\":[\"en-US\",1]}")]
    [TestCase("{\"name\":42}")]
    [TestCase("{\"type\":42}")]
    [TestCase("{\"type\":\"\"}")]
    [TestCase("{\"avatar_character\":\"internal\"}")]
    [TestCase("{\"avatar_style\":\"internal\"}")]
    [TestCase("{\"custom_lexicon_url\":\"http://[\"}")]
    [TestCase("{\"custom_text_normalization_url\":\"http://[\"}")]
    public void VoicePatchValidatesKnownFields(string voiceJson)
    {
        var message = new VoiceResponseOutputTextDoneMessage(
            "r_1",
            "it_1",
            "hello",
            BinaryData.FromString(voiceJson));

        Assert.That(
            () => VoiceProtocolCodec.Encode(message),
            Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void VoicePatchPreservesUnknownAdditiveFields()
    {
        var message = new VoiceResponseOutputTextDoneMessage(
            "r_1",
            "it_1",
            "hello",
            BinaryData.FromString("""{"future_field":{"value":1}}"""));

        using var payload = JsonDocument.Parse(VoiceProtocolCodec.Encode(message));

        Assert.That(
            payload.RootElement.GetProperty("voice").GetProperty("future_field").GetProperty("value").GetInt32(),
            Is.EqualTo(1));
    }

    [Test]
    public void OversizedOutboundFrameIsRejectedBeforeTransport()
    {
        var message = new VoiceResponseOutputTextDoneMessage(
            "r_1",
            "it_1",
            new string('x', VoiceProtocolCodec.MaxFrameBytes));

        Assert.That(
            () => VoiceProtocolCodec.Encode(message),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void OutboundFrameAllowsExactlyOneMiBAndRejectsOneMoreByte()
    {
        var empty = new VoiceResponseOutputTextDoneMessage(
            "r_1",
            "it_1",
            string.Empty,
            id: "m_1",
            timestamp: Timestamp);
        var overhead = VoiceProtocolCodec.Encode(empty).Length;
        var exact = new VoiceResponseOutputTextDoneMessage(
            "r_1",
            "it_1",
            new string('x', VoiceProtocolCodec.MaxFrameBytes - overhead),
            id: "m_1",
            timestamp: Timestamp);
        var oversized = new VoiceResponseOutputTextDoneMessage(
            "r_1",
            "it_1",
            new string('x', VoiceProtocolCodec.MaxFrameBytes - overhead + 1),
            id: "m_1",
            timestamp: Timestamp);

        Assert.That(VoiceProtocolCodec.Encode(exact).Length, Is.EqualTo(VoiceProtocolCodec.MaxFrameBytes));
        Assert.That(
            () => VoiceProtocolCodec.Encode(oversized),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void FutureMessageDoesNotApplyUndocumentedIdentifierNodeOrIntegerLimits()
    {
        var manyNodes = Frame(
            "future.message",
            $"\"value\":[{string.Join(',', Enumerable.Repeat("0", 8192))}]");
        var largeInteger = Frame("future.message", $"\"value\":{new string('9', 129)}");
        var longId = manyNodes.Replace("\"m_1\"", $"\"m_{new string('x', 256)}\"");

        Assert.Multiple(() =>
        {
            Assert.That(VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(manyNodes)), Is.Null);
            Assert.That(VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(largeInteger)), Is.Null);
            Assert.That(VoiceProtocolCodec.Decode(Encoding.UTF8.GetBytes(longId)), Is.Null);
        });
    }

    [Test]
    public void OutboundTimestampPreservesTickPrecision()
    {
        var timestamp = DateTimeOffset.Parse(
            "2026-08-13T00:00:00.1234567Z",
            System.Globalization.CultureInfo.InvariantCulture);

        using var payload = JsonDocument.Parse(VoiceProtocolCodec.Encode(
            new VoiceSessionReadyMessage(timestamp: timestamp)));
        var encoded = DateTimeOffset.Parse(
            payload.RootElement.GetProperty("ts").GetString()!,
            System.Globalization.CultureInfo.InvariantCulture);

        Assert.That(encoded, Is.EqualTo(timestamp));
    }

    private static string Frame(string type, string fields)
    {
        var suffix = string.IsNullOrEmpty(fields) ? string.Empty : $",{fields}";
        return $$"""{"type":"{{type}}","id":"m_1","ts":"2026-08-13T00:00:00.000Z"{{suffix}}}""";
    }
}
