// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Tests for RTC call SDP negotiation server events.
    /// Note: ClientEventRtcCallSdpCreate is internal and tested indirectly via the wire.
    /// </summary>
    [TestFixture]
    public class RtcCallSdpEventsTests
    {
        private static TestableVoiceLiveSession CreateSessionWithFakeSocket(out FakeWebSocket fakeSocket)
        {
            var client = new VoiceLiveClient(new Uri("https://example.org"), new AzureKeyCredential("test-key"));
            var session = new TestableVoiceLiveSession(client, new Uri("wss://example.org/realtime"), new AzureKeyCredential("test-key"));
            fakeSocket = new FakeWebSocket();
            session.SetWebSocket(fakeSocket);
            return session;
        }

        [Test]
        public void RtcCallEventTypeStrings_AreRegistered()
        {
            Assert.That(ServerEventType.RtcCallSdpCreated.ToString(), Is.EqualTo("rtc.call.sdp.created"));
            Assert.That(ServerEventType.RtcCallError.ToString(), Is.EqualTo("rtc.call.error"));
            Assert.That(ClientEventType.RtcCallSdpCreate.ToString(), Is.EqualTo("rtc.call.sdp.create"));
        }

        [Test]
        public async Task ServerEventRtcCallSdpCreated_ParsesCorrectly()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            fake.EnqueueTextMessage("""{"type":"rtc.call.sdp.created","event_id":"s1","rtc_call_id":"call-123","sdp_answer":"v=0\r\no=- 2 2 IN IP4 0.0.0.0\r\n"}""");

            await foreach (SessionUpdate update in session.GetUpdatesAsync())
            {
                Assert.That(update, Is.TypeOf<ServerEventRtcCallSdpCreated>());
                var sdp = (ServerEventRtcCallSdpCreated)update;
                Assert.That(sdp.RtcCallId, Is.EqualTo("call-123"));
                Assert.That(sdp.SdpAnswer, Does.StartWith("v=0"));
                break;
            }
        }

        [Test]
        public async Task ServerEventRtcCallError_ParsesCorrectly()
        {
            var session = CreateSessionWithFakeSocket(out var fake);
            fake.EnqueueTextMessage("""
                {
                    "type": "rtc.call.error",
                    "event_id": "s2",
                    "operation": "rtc.call.sdp.create",
                    "rtc_call_id": "call-9",
                    "error": { "type": "invalid_request_error", "code": "bad_sdp", "message": "Malformed SDP" }
                }
                """);

            await foreach (SessionUpdate update in session.GetUpdatesAsync())
            {
                Assert.That(update, Is.TypeOf<ServerEventRtcCallError>());
                var err = (ServerEventRtcCallError)update;
                Assert.That(err.Operation, Is.EqualTo("rtc.call.sdp.create"));
                Assert.That(err.RtcCallId, Is.EqualTo("call-9"));
                Assert.That(err.Error, Is.Not.Null);
                Assert.That(err.Error.Type, Is.EqualTo("invalid_request_error"));
                Assert.That(err.Error.Code, Is.EqualTo("bad_sdp"));
                Assert.That(err.Error.Message, Is.EqualTo("Malformed SDP"));
                break;
            }
        }
    }
}
