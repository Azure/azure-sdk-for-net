// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests.Events
{
    public class EventTests : CallingServerTestBase
    {
        [Test]
        public void CallRecordingStateChangeEventTest()
        {
            var json = "{\"recordingId\":\"id\",\"state\":\"active\",\"startDateTime\":\"2021-06-18T18:59:23.5718812-07:00\",\"serverCallId\":\"callServerId\"}";

            var c = CallRecordingStateChangeEvent.Deserialize(json);

            Assert.AreEqual("id", c.RecordingId);
            Assert.AreEqual(CallRecordingState.Active, c.State);
            Assert.AreEqual("callServerId", c.ServerCallId);
            Assert.AreEqual("2021-06-18", c.StartDateTime.ToString("yyyy-MM-dd"));
        }

        [Test]
        public void CallConnectionStateChangedEventTest()
        {
            var json = "{\"serverCallId\":\"serverCallId\",\"callConnectionId\":\"callConnectionId\",\"callConnectionState\":\"connected\"}";

            var c = CallConnectionStateChangedEvent.Deserialize(json);

            Assert.AreEqual("serverCallId", c.ServerCallId);
            Assert.AreEqual("callConnectionId", c.CallConnectionId);
            Assert.AreEqual(CallConnectionState.Connected, c.CallConnectionState);
        }

        [Test]
        public void AddParticipantResultEventTest()
        {
            var json = "{\"resultInfo\":{\"code\":400,\"subcode\":415,\"message\":\"failure message\"},\"operationContext\":\"operatingContext\",\"status\":\"failed\"}";

            var c = AddParticipantResultEvent.Deserialize(json);

            Assert.AreEqual("operatingContext", c.OperationContext);
            Assert.AreEqual(OperationStatus.Failed, c.Status);
            Assert.IsNotNull(c.ResultInfo);
            Assert.AreEqual(400, c.ResultInfo.Code);
            Assert.AreEqual(415, c.ResultInfo.Subcode);
            Assert.AreEqual("failure message", c.ResultInfo.Message);

            json = "{\"operationContext\":\"operatingContext\",\"status\":\"running\"}";
            c = AddParticipantResultEvent.Deserialize(json);

            Assert.AreEqual("operatingContext", c.OperationContext);
            Assert.AreEqual(OperationStatus.Running, c.Status);
            Assert.IsNull(c.ResultInfo);
        }

        [Test]
        public void PlayAudioResultEventTest()
        {
            var json = "{\"resultInfo\":{\"code\":500,\"subcode\":505,\"message\":\"failure message\"},\"operationContext\":\"operatingContext\",\"status\":\"failed\"}";

            var c = PlayAudioResultEvent.Deserialize(json);

            Assert.AreEqual("operatingContext", c.OperationContext);
            Assert.AreEqual(OperationStatus.Failed, c.Status);
            Assert.IsNotNull(c.ResultInfo);
            Assert.AreEqual(500, c.ResultInfo.Code);
            Assert.AreEqual(505, c.ResultInfo.Subcode);
            Assert.AreEqual("failure message", c.ResultInfo.Message);

            json = "{\"operationContext\":\"operatingContext\",\"status\":\"completed\"}";
            c = PlayAudioResultEvent.Deserialize(json);

            Assert.AreEqual("operatingContext", c.OperationContext);
            Assert.AreEqual(OperationStatus.Completed, c.Status);
            Assert.IsNull(c.ResultInfo);
        }

        [Test]
        public void ToneReceivedEventTest()
        {
            var json = "{\"toneInfo\":{\"sequenceId\":1,\"tone\":\"A\"},\"callConnectionId\": \"8e6ff9fd-dd81-47f9-963a-1989bb95779c\"}";

            var c = ToneReceivedEvent.Deserialize(json);

            Assert.AreEqual("8e6ff9fd-dd81-47f9-963a-1989bb95779c", c.CallConnectionId);
            Assert.IsNotNull(c.ToneInfo);
            Assert.AreEqual(1, c.ToneInfo.SequenceId);
            Assert.AreEqual(ToneValue.A, c.ToneInfo.Tone);
        }

        [Test]
        [Ignore("Issue will fix later: A property 'phoneNumber' defined as non-nullable but received as null from the service.")]
        public void ParticipantUpdatedEventTest()
        {
            var json = "{\"callConnectionId\":\"c0623fc9-f723-44e1-b18e-ec2da390fba0\",\"participants\":[{\"identifier\":{\"rawId\":\"8:acs:resource_guid1\",\"communicationUser\":{\"id\":\"8:acs:resource_guid1\"},\"phoneNumber\":null,\"microsoftTeamsUser\":null},\"participantId\":\"participant1\",\"isMuted\":false},{\"identifier\":{\"rawId\":\"8:acs:resource_guid2\",\"communicationUser\":null,\"phoneNumber\":{\"value\":\"\\u002B14250000000\"},\"microsoftTeamsUser\":null},\"participantId\":\"participant2\",\"isMuted\":true}]}";

            var c = ParticipantsUpdatedEvent.Deserialize(json);

            Assert.AreEqual("c0623fc9-f723-44e1-b18e-ec2da390fba0", c.CallConnectionId);
            Assert.IsNotNull(c.Participants);
            Assert.AreEqual(2, c.Participants.Count());
            Assert.AreEqual("participant1", c.Participants.ElementAt(0).ParticipantId);
            Assert.AreEqual(false, c.Participants.ElementAt(0).IsMuted);
            Assert.AreEqual(new CommunicationUserIdentifier("8:acs:resource_guid1"), c.Participants.ElementAt(0).Identifier);
            Assert.AreEqual("participant2", c.Participants.ElementAt(1).ParticipantId);
            Assert.AreEqual(true, c.Participants.ElementAt(1).IsMuted);
            Assert.AreEqual(new PhoneNumberIdentifier("+14250000000"), c.Participants.ElementAt(1).Identifier);
        }
    }
}
