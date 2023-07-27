// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.MediaStreaming
{
    internal class CallAutomationStreamingParserTests
    {
        [Test]
        public void ParseMetadata_Test()
        {
            string metadataJson = "{"
                + "\"kind\": \"AudioMetadata\","
                + "\"audioMetadata\": {"
                + "\"subscriptionId\": \"subscriptionId\","
                + "\"encoding\": \"encodingType\","
                + "\"sampleRate\": 8,"
                + "\"channels\": 2,"
                + "\"length\": 640"
                + "}"
                + "}";

            MediaStreamingMetadata streamingMetadata = (MediaStreamingMetadata)MediaStreamingPackageParser.Parse(metadataJson);
            ValidateMetadata(streamingMetadata);
        }

        [Test]
        public void ParseAudio_Test()
        {
            string audioJson = "{"
                + "\"kind\": \"AudioData\","
                + "\"audioData\": {"
                + "\"data\": \"AQIDBAU=\","      // [1, 2, 3, 4, 5]
                + "\"timestamp\": \"2022-08-23T11:48:05Z\","
                + "\"participantRawID\": \"participantId\","
                + "\"silent\": false"
                + "}"
                + "}";

            MediaStreamingAudioData streamingAudio = (MediaStreamingAudioData) MediaStreamingPackageParser.Parse(audioJson);
            ValidateAudioData(streamingAudio);
        }

        [Test]
        public void ParseAudio_NoParticipantIdSilent_Test()
        {
            string audioJson = "{"
                + "\"kind\": \"AudioData\","
                + "\"audioData\": {"
                + "\"data\": \"AQIDBAU=\","      // [1, 2, 3, 4, 5]
                + "\"timestamp\": \"2022-08-23T11:48:05Z\""
                + "}"
                + "}";

            MediaStreamingAudioData streamingAudio = (MediaStreamingAudioData)MediaStreamingPackageParser.Parse(audioJson);
            ValidateAudioDataNoParticipant(streamingAudio);
        }

        [Test]
        public void ParseBinaryData()
        {
            JObject jsonData = new JObject();
            jsonData["kind"] = "AudioData";
            jsonData["audioData"] = new JObject();
            jsonData["audioData"]["data"] = "AQIDBAU=";
            jsonData["audioData"]["timestamp"] = "2022-08-23T11:48:05Z";
            jsonData["audioData"]["participantRawID"] = "participantId";
            jsonData["audioData"]["silent"] = false;

            var binaryData = BinaryData.FromString(jsonData.ToString());

            MediaStreamingAudioData streamingAudio = (MediaStreamingAudioData)MediaStreamingPackageParser.Parse(binaryData);
            ValidateAudioData(streamingAudio);
        }

        [Test]
        public void ParseAudioEventsWithBynaryArray()
        {
            JObject jsonData = new JObject();
            jsonData["kind"] = "AudioData";
            jsonData["audioData"] = new JObject();
            jsonData["audioData"]["data"] = "AQIDBAU=";
            jsonData["audioData"]["timestamp"] = "2022-08-23T11:48:05Z";
            jsonData["audioData"]["participantRawID"] = "participantId";
            jsonData["audioData"]["silent"] = false;

            byte[] receivedBytes = System.Text.Encoding.UTF8.GetBytes(jsonData.ToString());
            MediaStreamingAudioData parsedPackage = (MediaStreamingAudioData) MediaStreamingPackageParser.Parse(receivedBytes);

            Assert.NotNull(parsedPackage);
            ValidateAudioData(parsedPackage);
        }

        private static void ValidateMetadata(MediaStreamingMetadata streamingMetadata)
        {
            Assert.IsNotNull(streamingMetadata);
            Assert.AreEqual("subscriptionId", streamingMetadata.MediaSubscriptionId);
            Assert.AreEqual("encodingType", streamingMetadata.Encoding);
            Assert.AreEqual(8, streamingMetadata.SampleRate);
            Assert.AreEqual(2, streamingMetadata.Channels);
            Assert.AreEqual(640, streamingMetadata.Length);
        }

        private static void ValidateAudioData(MediaStreamingAudioData streamingAudio)
        {
            Assert.IsNotNull(streamingAudio);
            Assert.AreEqual("AQIDBAU=", streamingAudio.Data);
            Assert.AreEqual(2022, streamingAudio.Timestamp.Year);
            Assert.IsTrue(streamingAudio.Participant is CommunicationIdentifier);
            Assert.AreEqual("participantId", streamingAudio.Participant.RawId);
            Assert.IsFalse(streamingAudio.IsSilent);
        }
        private static void ValidateAudioDataNoParticipant(MediaStreamingAudioData streamingAudio)
        {
            Assert.IsNotNull(streamingAudio);
            Assert.AreEqual("AQIDBAU=", streamingAudio.Data);
            Assert.AreEqual(2022, streamingAudio.Timestamp.Year);
            Assert.IsNull(streamingAudio.Participant);
            Assert.IsFalse(streamingAudio.IsSilent);
        }
    }
}
